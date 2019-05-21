
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


Public Class frmInventoryOrders
    Private oVariousOptions As New VariousOptions()
#Region " Fields "

    Private defaultItemsList As New List(Of String)
    Private defaultItemCategoryID As String = String.Empty

    Private currentAllSaved As Boolean = True
    Private currentOrderNo As String = String.Empty

    Private _DrugNo As String = String.Empty
    Private _ConsumableNo As String = String.Empty
    Private _OtherItemsNo As String = String.Empty
    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()

    Private WithEvents docInventoryOrders As New PrintDocument()

    ' The paragraphs.
    Private orderParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 40
    Private padQuantity As Integer = 20

    Private itemCount As Integer = 0
    Private oOrderType As New LookupDataID.InventoryOrderTypeID
    Private oPack As New LookupDataID.PackID
#End Region

    Private Sub frmInventoryOrders_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Me.GetAllPendingOrderDetails(LocationID)
            '''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub frmInventoryOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Me.dtpOrderDate.MaxDate = Today
            Me.dtpOrderDate.Checked = True

            LoadLookupDataCombo(Me.cboToLocationID, LookupObjects.Location, False)
            LoadLookupDataCombo(Me.cboOrderType, LookupObjects.InventoryOrderType, False)
            LoadLookupDataCombo(Me.cboTransferReasonID, LookupObjects.TransferReasonID, True)

            LoadInventoryLocations()
            HideInventoryPacks()
            Me.GetAllPendingOrderDetails(LocationID)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultItemCategoryID) AndAlso defaultItemsList IsNot Nothing AndAlso defaultItemsList.Count > 0 Then

                If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                    For Each item As String In defaultItemsList
                        With Me.dgvDrugs
                            ' Ensure that you add a new row
                            .Rows.Add()
                            .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = item
                            Me.DetailDrug(.NewRowIndex - 1)
                        End With
                    Next

                ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                    For Each item As String In defaultItemsList
                        With Me.dgvConsumables
                            ' Ensure that you add a new row
                            .Rows.Add()
                            .Item(Me.colConsumableNo.Name, .NewRowIndex - 1).Value = item
                            Me.DetailConsumableItem(.NewRowIndex - 1)
                        End With
                    Next

                Else

                    For Each item As String In defaultItemsList
                        With Me.dgvDrugs
                            ' Ensure that you add a new row
                            .Rows.Add()
                            .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = item
                            Me.DetailDrug(.NewRowIndex - 1)
                        End With
                    Next

                End If

                Me.SetDefaultLocation()

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(colDrugPack, LookupObjects.Packs, False)
            LoadLookupDataCombo(colConsumablePack, LookupObjects.Packs, False)
            LoadLookupDataCombo(ColOtherItemsPack, LookupObjects.Packs, False)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    'Private Function ShowToOrderConsumablesPerLocation() As Integer

    '    ' Dim oConsumables As New SyncSoft.SQLDb.Consumables()
    '    Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")

    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        '   Dim records As Integer = oDrugs.CountToOrderDrugsPerLocation(fromLocationID)
    '        Me.lblToOrderDrugs.Text = "To Order Consumables: " + records.ToString()

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Return records
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        ErrorMessage(ex)
    '        Return 0

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try

    'End Function

    Private Sub frmInventoryOrders_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            If Not Me.AllSaved() Then
                If WarningMessage("Just close anyway?") = Windows.Forms.DialogResult.No Then e.Cancel = True
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub frmInventoryOrders_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        If Me.AllSaved() Then Me.Close()
    End Sub

    Private Sub stbOrderNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbOrderNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentOrderNo = StringMayBeEnteredIn(Me.stbOrderNo)
                ProcessTabKey(True)
            Else : currentOrderNo = String.Empty
            End If

        Catch ex As Exception
            currentOrderNo = String.Empty
        End Try

    End Sub

    Private Sub stbOrderNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbOrderNo.TextChanged

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentOrderNo) Then
            Me.stbOrderNo.Text = currentOrderNo
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.CallOnKeyEdit()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub stbOrderNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbOrderNo.Leave

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentOrderNo) Then
            Me.stbOrderNo.Text = currentOrderNo
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInventoryOrders As New frmPeriodicInventoryOrders(Me.stbOrderNo)
            fPeriodicInventoryOrders.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboFromLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.cboFromLocationID.Enabled = False
            Else : Me.cboFromLocationID.Enabled = True
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub HideInventoryPacks()
        Dim packControl As DataGridViewColumn() = {colDrugPack, colDrugPackSize, colDrugTotalUnits, colConsumableTotalUnit,
                                            colConsumablePackSize, colConsumablePack, ColOtherItemsPack, ColOtherItemsPackSize, ColOtherItemsTotalUnits}
        HideGridComponets(packControl, oVariousOptions.UseOfInventoryPackSizes)

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

    Private Sub cboToLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboToLocationID.SelectedIndexChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.DetailDrug()
        Me.DetailConsumableItem()
        Me.DetailOtherItems()
    End Sub

    Private Sub SetNextOrderNo()

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("InventoryOrders", "OrderNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim orderNo As String = yearL2 + oInventoryOrders.GetNextOrderID.ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbOrderNo.Text = FormatText(orderNo, "InventoryOrders", "OrderNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ResetTabControls()

        ResetControlsIn(Me.tpgDrugs)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgOtherItems)
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oInventoryOrders.OrderNo = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))
            DisplayMessage(oInventoryOrders.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))
            Dim dataSource As DataTable = oInventoryOrders.GetInventoryOrders(orderNo).Tables("InventoryOrders")

            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugOrderDetails(orderNo)
            Me.LoadConsumableOrderDetails(orderNo)
            Me.LoadOtherItemsOrderDetails(orderNo)
            Me.btnPrint.Enabled = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function AllSaved() As Boolean

        Try

            Dim message As String = "Please ensure that all items are saved on "
            Dim orderNo As String = StringMayBeEnteredIn(Me.stbOrderNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(orderNo) Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each page As TabPage In Me.tbcInventoryOrders.TabPages

                Select Case page.Name

                    Case Me.tpgDrugs.Name
                        For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colDrugsSaved) Then
                                DisplayMessage(message + Me.tpgDrugs.Text)
                                Me.tbcInventoryOrders.SelectTab(Me.tpgDrugs)
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
                                Me.tbcInventoryOrders.SelectTab(Me.tpgConsumables)
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
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()
            Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()
            Dim lInventoryOrders As New List(Of DBConnect)
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)

            With oInventoryOrders

                .OrderNo = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))
                .OrderDate = DateEnteredIn(Me.dtpOrderDate, "Order Date!")

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
                .StockCost = DecimalEnteredIn(stbTotalcost, False, "Total Cost!")
                .LoginID = CurrentUser.LoginID
                .OrderTypeID = StringValueEnteredIn(Me.cboOrderType, "Order Type!")
                .TransferReasonID = StringValueEnteredIn(Me.cboTransferReasonID, "Transfer Reason!")
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
            lInventoryOrders.Add(oInventoryOrders)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDrugs.RowCount <= 1 AndAlso Me.dgvConsumables.RowCount <= 1 AndAlso Me.dgvOtherItems.RowCount <= 1 Then
                message = "Must register at least one item for drugs or consumables or Other Item!"
                Throw New ArgumentException(message)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.ForceInventoryAcknowledgementBeforeOrdering Then
                Dim records As Integer = oDrugs.GetAllPendingOrderDetails(LocationID)
                If records > 0 Then
                    message = "The system is set not to allow you Make an order with un acknowledged Inventory, Please Acknowledge all your orders first Or Contact your system Administrator ! "
                    Me.btnPendingIventoryAcknowledgements.Focus()
                    Throw New ArgumentException(message)
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyDrugsEntries()
            Me.VerifyConsumablesEntries()
            Me.VerifyOtherItemsEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryOrders, Action.Save))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SaveDrugs()
                    Me.SaveConsumables()
                    Me.SaveOtherItems()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not Me.chkPrintOnSaving.Checked Then
                        message = "You have not checked Print Order On Saving. " + ControlChars.NewLine + "Would you want Order printed?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintInventoryOrders()
                    Else : Me.PrintInventoryOrders()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.ResetTabControls()
                    Me.ClearControls()
                    Me.SetNextOrderNo()
                    Me.SetDefaultLocation()

                    Me.dtpOrderDate.Value = Today
                    Me.dtpOrderDate.Checked = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryOrders, Action.Update, "InventoryOrders"))
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
            If ex.Message.Contains("The Order No:") OrElse ex.Message.EndsWith("already exists") Then
                message = "The Order No: " + Me.stbOrderNo.Text + ", you are trying to enter already exists" +
                    ControlChars.NewLine + "If you are using the system generated number, probably another user has already taken it." +
                    ControlChars.NewLine + "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextOrderNo()
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

            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2

                Try

                    Dim transactions As New List(Of TransactionList(Of DBConnect))
                    Dim lInventoryOrderDetails As New List(Of DBConnect)

                    Dim cells As DataGridViewCellCollection = Me.dgvDrugs.Rows(rowNo).Cells


                    Dim itemCode As String = StringEnteredIn(cells, Me.colDrugNo, "Drug No!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDrugQuantity, "Quantity!")

                    Dim PackID As String = StringMayBeEnteredIn(cells, Me.colDrugPack)
                    If String.IsNullOrEmpty(PackID) Then
                        PackID = oPack.NA
                    End If
                    Dim packSize As Integer = IntegerEnteredIn(cells, Me.colDrugPackSize, "PackSize!")
                    Dim unitCost As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitCost, False, "UnitCost!")

                    Using oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
                        With oInventoryOrderDetails
                            .OrderNo = orderNo

                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .PackID = PackID
                            .PackSize = packSize
                            .UnitCost = unitCost
                            .ItemStatusID = oItemStatusID.Pending
                            .LoginID = CurrentUser.LoginID
                        End With
                        lInventoryOrderDetails.Add(oInventoryOrderDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryOrderDetails, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDrugs.Item(Me.colDrugsSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcInventoryOrders.SelectTab(Me.tpgDrugs.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryOrders.SelectTab(Me.tpgDrugs.Name)
            SaveDrugs = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyDrugsEntries() As Boolean

        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "From Location!")

            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For

                Dim itemCode As String = StringEnteredIn(row.Cells, Me.colDrugNo, "Drug No!")
                Dim itemName As String = StringEnteredIn(row.Cells, Me.colDrugName, "Drug Name!")
                Dim totalUnits As Integer = IntegerEnteredIn(row.Cells, Me.colDrugTotalUnits, "Quantity!")

                If totalUnits < 0 Then Throw New ArgumentException("Quantity must be higher than zero!")

                Dim locationBalance As Integer = GetInventoryBalance(fromLocationID, oItemCategoryID.Drug, itemCode)
                If locationBalance < totalUnits Then
                    Dim message As String = "No sufficient balance at " + Me.cboToLocationID.Text + ", to order for " + itemName + ". " + ControlChars.NewLine +
                        "Selected to location has " + locationBalance.ToString() + ", and you what to order for " + totalUnits.ToString() + "!"
                    Throw New ArgumentException(message)
                End If

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryOrders.SelectTab(Me.tpgDrugs.Name)
            VerifyDrugsEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveConsumables() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Try

                    Dim transactions As New List(Of TransactionList(Of DBConnect))
                    Dim lInventoryOrderDetails As New List(Of DBConnect)

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colConsumableNo, "Consumable No!"))
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity, "Quantity!")
                    Dim PackID As String = StringMayBeEnteredIn(cells, Me.colConsumablePack)

                    If String.IsNullOrEmpty(PackID) Then
                        PackID = oPack.NA
                    End If

                    Dim packSize As Integer = IntegerEnteredIn(cells, Me.colConsumablePackSize, "PackSize!")
                    Dim unitCost As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitCost, False, "UnitCost!")
                    Using oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
                        With oInventoryOrderDetails
                            .OrderNo = orderNo
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemCode = itemCode
                            .PackID = PackID
                            .PackSize = packSize
                            .UnitCost = unitCost
                            .Quantity = quantity
                            .ItemStatusID = oItemStatusID.Pending
                            .LoginID = CurrentUser.LoginID
                        End With
                        lInventoryOrderDetails.Add(oInventoryOrderDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryOrderDetails, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcInventoryOrders.SelectTab(Me.tpgConsumables.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryOrders.SelectTab(Me.tpgConsumables.Name)
            SaveConsumables = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyConsumablesEntries() As Boolean

        Try

            Dim toLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "From Location!")

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                Dim itemCode As String = StringEnteredIn(row.Cells, Me.colConsumableNo, "Consumable No!")
                Dim itemName As String = StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Name!")
                Dim totalUnits As Integer = IntegerEnteredIn(row.Cells, Me.colConsumableTotalUnit, "Total Units!")



                If totalUnits < 0 Then Throw New ArgumentException("Quantity must be higher than zero!")

                Dim locationBalance As Integer = GetInventoryBalance(toLocationID, oItemCategoryID.Consumable, itemCode)
                If locationBalance < totalUnits Then
                    Dim message As String = "No sufficient balance at " + Me.cboToLocationID.Text + ", to order for " + itemName + ". " + ControlChars.NewLine +
                        "Selected to location has " + locationBalance.ToString() + ", and you what to transfer " + totalUnits.ToString() + "!"
                    Throw New ArgumentException(message)
                End If

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryOrders.SelectTab(Me.tpgConsumables.Name)
            VerifyConsumablesEntries = False
            Throw ex

        End Try

    End Function


    Private Function SaveOtherItems() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2

                Try

                    Dim transactions As New List(Of TransactionList(Of DBConnect))
                    Dim lInventoryOrderDetails As New List(Of DBConnect)

                    Dim cells As DataGridViewCellCollection = Me.dgvOtherItems.Rows(rowNo).Cells


                    Dim itemCode As String = StringEnteredIn(cells, Me.ColOtherItemsItemCode, "Item Code!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.ColOtherItemsQuantity, "Quantity!")

                    Dim PackID As String = StringMayBeEnteredIn(cells, Me.ColOtherItemsPack)
                    If String.IsNullOrEmpty(PackID) Then
                        PackID = oPack.NA
                    End If
                    Dim packSize As Integer = IntegerEnteredIn(cells, Me.ColOtherItemsPackSize, "PackSize!")
                    Dim unitCost As Decimal = DecimalEnteredIn(cells, Me.ColOtherItemsUnitCost, False, "UnitCost!")

                    Using oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
                        With oInventoryOrderDetails
                            .OrderNo = orderNo

                            .ItemCategoryID = oItemCategoryID.NonMedical
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .PackID = PackID
                            .PackSize = packSize
                            .UnitCost = unitCost
                            .ItemStatusID = oItemStatusID.Pending
                            .LoginID = CurrentUser.LoginID
                        End With
                        lInventoryOrderDetails.Add(oInventoryOrderDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryOrderDetails, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcInventoryOrders.SelectTab(Me.tpgOtherItems.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryOrders.SelectTab(Me.tpgOtherItems.Name)
            SaveOtherItems = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyOtherItemsEntries() As Boolean

        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "From Location!")

            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For

                Dim itemCode As String = StringEnteredIn(row.Cells, Me.ColOtherItemsItemCode, "Item Code!")
                Dim itemName As String = StringEnteredIn(row.Cells, Me.ColOtherItemsName, "Item Name!")
                Dim totalUnits As Integer = IntegerEnteredIn(row.Cells, Me.ColOtherItemsTotalUnits, "Quantity!")

                If totalUnits < 0 Then Throw New ArgumentException("Quantity must be higher than zero!")

                Dim locationBalance As Integer = GetInventoryBalance(fromLocationID, oItemCategoryID.NonMedical, itemCode)
                If locationBalance < totalUnits Then
                    Dim message As String = "No sufficient balance at " + Me.cboToLocationID.Text + ", to order for " + itemName + ". " + ControlChars.NewLine +
                        "Selected to location has " + locationBalance.ToString() + ", and you what to order for " + totalUnits.ToString() + "!"
                    Throw New ArgumentException(message)
                End If

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryOrders.SelectTab(Me.tpgOtherItems.Name)
            VerifyOtherItemsEntries = False
            Throw ex

        End Try

    End Function

#End Region

#Region " Drugs - Grid "

    Private Sub dgvDrugs_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDrugs.CellClick

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Drugs", "Drug No", "Drug Name", Me.GetDrugs(), "DrugFullName",
                                                                     "DrugNo", "DrugName", Me.dgvDrugs, Me.colDrugNo, e.RowIndex)

            Me._DrugNo = StringMayBeEnteredIn(Me.dgvDrugs.Rows(e.RowIndex).Cells, Me.colDrugNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colDrugSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvDrugs.Rows(e.RowIndex).IsNewRow Then

                Me.dgvDrugs.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)

                Me._DrugNo = StringMayBeEnteredIn(Me.dgvDrugs.Rows(e.RowIndex).Cells, Me.colDrugNo)
                If String.IsNullOrEmpty(Me._DrugNo) Then Me.dgvDrugs.Rows.RemoveAt(e.RowIndex)

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

    Private Sub dgvDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colDrugNo.Index OrElse Me.dgvDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDrugs.CurrentCell.RowIndex
        Me._DrugNo = StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugNo)

    End Sub

    Private Sub dgvDrugs_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDrugs.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvDrugs.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then If Me.dgvDrugs.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)


            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then
                If Me.dgvDrugs.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
                Me.CalculateDrugCost(selectedRow)
             
            ElseIf e.ColumnIndex.Equals(Me.colDrugUnitCost.Index) Then
                Me.CalculateDrugCost(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colDrugPack.Index) Then
                Dim pack As String = StringMayBeEnteredIn(dgvDrugs.Rows(selectedRow).Cells, Me.colDrugPack)

                If (String.IsNullOrEmpty(pack) OrElse pack.Equals(oPack.NA)) Then
                    Me.dgvDrugs.Item(Me.colDrugPackSize.Name, selectedRow).Value = 1
                    colDrugPackSize.ReadOnly = True
                Else
                    Me.dgvDrugs.Item(Me.colDrugPackSize.Name, selectedRow).Value = 1
                    Me.dgvDrugs.Item(Me.colDrugQuantity.Name, selectedRow).Value = 1
                    colDrugPackSize.ReadOnly = False
                End If

                Me.CalculateDrugCost(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colDrugPackSize.Index) Then
                Me.CalculateDrugCost(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colDrugUnitCost.Index) Then
                Me.CalculateTotalDrugCost()

            End If
            Me.CalculateTotalDrugCost()
        Catch ex As Exception
            ErrorMessage(ex)

        End Try



    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugNo)

            Me.SetDrugsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            If CBool(Me.dgvDrugs.Item(Me.colDrugsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug No (" + Me._DrugNo + ") can't be edited!")
                Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDrugs.Rows(rowNo).Cells, Me.colDrugNo)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Drug No (" + enteredItem + ") already selected!")
                        Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                        Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True

                    End If
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailDrug(selectedRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDrugs.Item(Me.colDrugsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))
            Dim itemCode As String = Me.dgvDrugs.Item(Me.colDrugNo.Name, toDeleteRowNo).Value.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oInventoryOrderDetails
                .OrderNo = orderNo
                .ItemCategoryID = oItemCategoryID.Drug
                .ItemCode = itemCode
            End With

            DisplayMessage(oInventoryOrderDetails.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub DetailDrug(ByVal selectedRow As Integer)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "From Location!")

            If selectedRow >= 0 Then

                Try

                    Dim drugNo As String = String.Empty
                    If Me.dgvDrugs.Rows.Count > 1 Then drugNo = SubstringRight(StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugNo))

                    If String.IsNullOrEmpty(drugNo) Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
                    Dim drugRow As DataRow = drugs.Rows(0)

                    Dim hidden As Boolean = BooleanMayBeEnteredIn(drugRow, "Hidden")
                    Dim drugName As String = StringEnteredIn(drugRow, "DrugName", "Drug Name!")
                    Dim unitCost As Decimal = DecimalEnteredIn(drugRow, "UnitCost", False)
                    If hidden Then Throw New ArgumentException("The Drug No: " + drugNo + ", is not enabled for selection. Contact administrator!")

                    With Me.dgvDrugs
                        .Item(Me.colDrugNo.Name, selectedRow).Value = drugNo.ToUpper()
                        .Item(Me.colDrugName.Name, selectedRow).Value = drugName
                        .Item(Me.colDrugItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colDrugPackSize.Name, selectedRow).Value = 1
                        .Item(Me.colDrugQuantity.Name, selectedRow).Value = 1
                        .Item(Me.colDrugTotalUnits.Name, selectedRow).Value = 1
                        .Item(Me.colDrugUnitCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                        .Item(Me.colDrugTotalCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(fromLocationID) Then Return
                    Me.ClearDrugGridColumns(selectedRow)

                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Drug, drugNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Return
                    Dim row As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDrugs.Item(Me.colDrugLocationBalance.Name, selectedRow).Value = locationBalance
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Drug, drugNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                    Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDrugs.Item(Me.colDrugLocationBalance.Name, row.Index).Value = locationBalance
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Next

            End If
            CalculateTotalDrugCost()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub DetailDrug()

        Try

            Me.DetailDrug(-1)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailConsumable(ByVal selectedRow As Integer)

        Dim oConsumables As New SyncSoft.SQLDb.ConsumableItems()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "From Location!")

            If selectedRow >= 0 Then

                Try

                    Dim ConsumableNo As String = String.Empty
                    If Me.dgvConsumables.Rows.Count > 1 Then ConsumableNo = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableNo))

                    If String.IsNullOrEmpty(ConsumableNo) Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Consumables As DataTable = oConsumables.GetConsumableItems(ConsumableNo).Tables("Consumables")
                    Dim ConsumableRow As DataRow = Consumables.Rows(0)

                    Dim hidden As Boolean = BooleanMayBeEnteredIn(ConsumableRow, "Hidden")
                    Dim ConsumableName As String = StringEnteredIn(ConsumableRow, "ConsumableName", "Consumable Name!")
                    Dim unitCost As String = FormatNumber(DecimalEnteredIn(ConsumableRow, "UnitCost", False))
                    If hidden Then Throw New ArgumentException("The Consumable No: " + ConsumableNo + ", is not enabled for selection. Contact administrator!")

                    With Me.dgvConsumables
                        .Item(Me.colConsumableNo.Name, selectedRow).Value = ConsumableNo.ToUpper()
                        .Item(Me.colConsumableName.Name, selectedRow).Value = ConsumableName
                        .Item(Me.colConsumableItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colConsumablePackSize.Name, selectedRow).Value = 1
                        .Item(Me.colConsumableQuantity.Name, selectedRow).Value = 1
                        .Item(Me.colConsumableName.Name, selectedRow).Value = unitCost
                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(fromLocationID) Then Return
                    Me.ClearConsumableGridColumns(selectedRow)

                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Consumable, ConsumableNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Return
                    Dim row As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, selectedRow).Value = locationBalance
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.dgvConsumables.Item(Me.colConsumableNo.Name, selectedRow).Value = Me._ConsumableNo.ToUpper()
                    Throw ex
                End Try

            Else

                If String.IsNullOrEmpty(fromLocationID) Then Return
                Me.ClearConsumableGridColumns(selectedRow)

                For Each row As DataGridViewRow In Me.dgvConsumables.Rows

                    If row.IsNewRow Then Exit For

                    Dim ConsumableNo As String = StringMayBeEnteredIn(row.Cells, Me.colConsumableNo)
                    If String.IsNullOrEmpty(ConsumableNo) Then Continue For

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Consumable, ConsumableNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                    Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = locationBalance
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Next

            End If
            Me.CalculateTotalConsumableCost()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub DetailConsumable()

        Try

            Me.DetailConsumable(-1)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearDrugGridColumns(ByVal selectedRow As Integer)

        If selectedRow < 0 Then
            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDrugs.Item(Me.colDrugLocationBalance.Name, row.Index).Value = String.Empty
            Next
        Else : Me.dgvDrugs.Item(Me.colDrugLocationBalance.Name, selectedRow).Value = String.Empty
        End If

    End Sub

    Private Sub ClearDrugGridColumns()
        Me.ClearDrugGridColumns(-1)
    End Sub

    Private Sub LoadDrugOrderDetails(ByVal orderNo As String)

        Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()

        Try

            Me.dgvDrugs.Rows.Clear()

            ' Load InventoryOrderDetails

            Dim orderDetails As DataTable = oInventoryOrderDetails.GetInventoryOrderDetails(orderNo, oItemCategoryID.Drug).Tables("InventoryOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(dgvDrugs, orderDetails)

            For pos As Integer = 0 To orderDetails.Rows.Count - 1

                Dim dataRow As DataRow = orderDetails.Rows(pos)

                With Me.dgvDrugs

                    .Item(Me.colDrugPack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")

                End With


            Next

            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDrugs.Item(Me.colDrugsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CalculateTotalDrugCost()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "

    Private Sub dgvConsumables_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellClick

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Consumable Items", "Consumable Item No", "Consumable Item Name", Me.GetConsumableItems(),
                                                                     "ConsumableFullName", "ConsumableNo", "ConsumableName", Me.dgvConsumables, Me.colConsumableNo, e.RowIndex)

            Me._ConsumableNo = StringMayBeEnteredIn(Me.dgvConsumables.Rows(e.RowIndex).Cells, Me.colConsumableNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colConsumableSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvConsumables.Rows(e.RowIndex).IsNewRow Then

                Me.dgvConsumables.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)

                Me._ConsumableNo = StringMayBeEnteredIn(Me.dgvConsumables.Rows(e.RowIndex).Cells, Me.colConsumableNo)
                If String.IsNullOrEmpty(Me._ConsumableNo) Then Me.dgvConsumables.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.colConsumableSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.colConsumableNo.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        Me._ConsumableNo = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableNo)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colConsumableNo.Index) Then If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)


            If e.ColumnIndex.Equals(Me.colConsumableNo.Index) Then
                If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colConsumableQuantity.Index) Then
                Me.CalculateConsumableAmount(selectedRow)




            ElseIf e.ColumnIndex.Equals(Me.colConsumablePack.Index) Then
                Dim pack As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumablePack)
                If (String.IsNullOrEmpty(pack) OrElse pack.Equals(oPack.NA)) Then
                    Me.dgvConsumables.Item(Me.colConsumablePackSize.Name, selectedRow).Value = 1
                    colConsumablePackSize.ReadOnly = True
                    Me.CalculateTotalConsumableCost()
                Else

                    Me.dgvConsumables.Item(Me.colConsumablePackSize.Name, selectedRow).Value = 1
                    Me.dgvConsumables.Item(Me.colConsumableQuantity.Name, selectedRow).Value = 1
                    colConsumablePackSize.ReadOnly = False
                End If
                Me.CalculateConsumableAmount(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colConsumablePackSize.Index) Then
                Me.CalculateConsumableAmount(selectedRow)



            End If
            Me.CalculateTotalConsumableCost()
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateTotalConsumableCost()

        Dim totalBill As Decimal = CalculateGridAmount(Me.dgvConsumables, Me.colConsumableTotalCost)
        Me.stbConsumableCost.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.CalculateTotalCost()

    End Sub

    Private Sub CalculateTotalCost()
        Dim drugCost As Decimal = DecimalMayBeEnteredIn(stbDrugCost)
        Dim consumableCost As Decimal = DecimalMayBeEnteredIn(stbConsumableCost)
        Dim otheritemsCost As Decimal = DecimalMayBeEnteredIn(stbOtherItemsCost)
        stbTotalcost.Text = FormatNumber((drugCost + consumableCost + otheritemsCost), AppData.DecimalPlaces)
    End Sub

    Private Sub CalculateConsumableAmount(ByVal selectedRow As Integer)

        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableQuantity)
        Dim unitCost As Decimal = DecimalMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableUnitCost)

        Dim pack As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumablePack)
        Dim packSize As Integer = IntegerMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumablePackSize)
        Dim totalUnits As Integer = quantity * packSize

        Dim amount As Decimal = CDec(totalUnits * unitCost)
        Me.dgvConsumables.Item(Me.colConsumableTotalUnit.Name, selectedRow).Value = totalUnits
        Me.dgvConsumables.Item(Me.colConsumableTotalCost.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)
        Dim totalConsumable As Decimal = CalculateGridAmount(dgvConsumables, Me.colConsumableTotalCost)
        Me.stbConsumableCost.Text = FormatNumber(totalConsumable, AppData.DecimalPlaces)

    End Sub


    Private Sub SetConsumableEntries(ByVal selectedRow As Integer)

        Try
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableNo)

            Me.SetConsumableEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetConsumableEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            ' Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableNo)

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Consumable No (" + Me._ConsumableNo + ") can't be edited!")
                Me.dgvConsumables.Item(Me.colConsumableNo.Name, selectedRow).Value = Me._ConsumableNo
                Me.dgvConsumables.Item(Me.colConsumableNo.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.colConsumableNo)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Consumable No (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Item(Me.colConsumableNo.Name, selectedRow).Value = Me._ConsumableNo
                        Me.dgvConsumables.Item(Me.colConsumableNo.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailConsumableItem(selectedRow)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))
            Dim itemCode As String = Me.dgvConsumables.Item(Me.colConsumableNo.Name, toDeleteRowNo).Value.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oInventoryOrderDetails
                .OrderNo = orderNo
                .ItemCategoryID = oItemCategoryID.Consumable
                .ItemCode = itemCode
            End With

            DisplayMessage(oInventoryOrderDetails.Delete())
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

    Private Sub DetailConsumableItem(ByVal selectedRow As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim toLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "To Location!")

            If selectedRow >= 0 Then

                Try

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim consumableNo As String = String.Empty
                    If Me.dgvConsumables.Rows.Count > 1 Then consumableNo = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableNo))
                    If String.IsNullOrEmpty(consumableNo) Then Return

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
                    Dim consumableRow As DataRow = consumableItems.Rows(0)

                    Dim hidden As Boolean = BooleanMayBeEnteredIn(consumableRow, "Hidden")
                    If hidden Then Throw New ArgumentException("The Consumable No: " + consumableNo + ", is not enabled for selection. Contact administrator!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim consumableName As String = StringEnteredIn(consumableRow, "ConsumableName", "Consumable Item Name!")
                    Dim unitCost As String = FormatNumber(DecimalEnteredIn(consumableRow, "UnitCost", False))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With Me.dgvConsumables

                        .Item(Me.colConsumableNo.Name, selectedRow).Value = consumableNo.ToUpper()
                        .Item(Me.colConsumableName.Name, selectedRow).Value = consumableName
                        .Item(Me.colConsumableItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colConsumableUnitCost.Name, selectedRow).Value = unitCost
                        .Item(Me.colConsumableQuantity.Name, selectedRow).Value = 1
                        .Item(Me.colConsumablePackSize.Name, selectedRow).Value = 1
                        .Item(Me.colConsumableTotalUnit.Name, selectedRow).Value = 1
                        .Item(Me.colConsumableTotalCost.Name, selectedRow).Value = unitCost

                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(toLocationID) Then Return
                    Me.ClearConsumableGridColumns(selectedRow)

                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(toLocationID, oItemCategoryID.Consumable, consumableNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Return
                    Dim row As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, selectedRow).Value = locationBalance
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    CalculateTotalConsumableCost()
                Catch ex As Exception
                    Me.dgvConsumables.Item(Me.colConsumableNo.Name, selectedRow).Value = Me._ConsumableNo.ToUpper()
                    Throw ex

                End Try
            Else

                If String.IsNullOrEmpty(toLocationID) Then Return
                Me.ClearConsumableGridColumns(selectedRow)

                For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                    If row.IsNewRow Then Exit For

                    Dim consumableNo As String = StringMayBeEnteredIn(row.Cells, Me.colConsumableNo)
                    If String.IsNullOrEmpty(consumableNo) Then Continue For

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(toLocationID, oItemCategoryID.Consumable, consumableNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                    Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = locationBalance
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Next

            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub DetailConsumableItem()

        Try
            Me.DetailConsumableItem(-1)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearConsumableGridColumns(ByVal selectedRow As Integer)

        If selectedRow < 0 Then
            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = String.Empty
            Next
        Else : Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, selectedRow).Value = String.Empty
        End If

    End Sub

    Private Sub ClearConsumableGridColumns()
        Me.ClearConsumableGridColumns(-1)
    End Sub

    Private Sub LoadConsumableOrderDetails(ByVal orderNo As String)

        Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load InventoryOrderDetails

            Dim orderDetails As DataTable = oInventoryOrderDetails.GetInventoryOrderDetails(orderNo, oItemCategoryID.Consumable).Tables("InventoryOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, orderDetails)

            For pos As Integer = 0 To orderDetails.Rows.Count - 1

                Dim dataRow As DataRow = orderDetails.Rows(pos)

                With Me.dgvConsumables

                    .Item(Me.colConsumablePack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")

                End With


            Next

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CalculateTotalConsumableCost()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " OtherItems - Grid "


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


    Private Sub dgvOtherItems_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherItems.CellClick

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Other Items", "Item No", "Item Name", Me.GetOtherItems(), "ItemFullName",
                                                                 "ItemCode", "ItemName", Me.dgvOtherItems, Me.ColOtherItemsItemCode, e.RowIndex)

            Me._OtherItemsNo = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(e.RowIndex).Cells, Me.ColOtherItemsItemCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColOtherItemsSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvOtherItems.Rows(e.RowIndex).IsNewRow Then

                Me.dgvOtherItems.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetOtherItemsEntries(e.RowIndex)

                Me._OtherItemsNo = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(e.RowIndex).Cells, Me.ColOtherItemsItemCode)
                If String.IsNullOrEmpty(Me._OtherItemsNo) Then Me.dgvOtherItems.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.ColOtherItemsSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetOtherItemsEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOtherItems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvOtherItems.CellBeginEdit

        If e.ColumnIndex <> Me.ColOtherItemsItemCode.Index OrElse Me.dgvOtherItems.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvOtherItems.CurrentCell.RowIndex
        Me._OtherItemsNo = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsItemCode)

    End Sub

    Private Sub dgvOtherItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherItems.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvOtherItems.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.ColOtherItemsItemCode.Index) Then If Me.dgvOtherItems.Rows.Count > 1 Then Me.SetOtherItemsEntries(selectedRow)


            If e.ColumnIndex.Equals(Me.ColOtherItemsItemCode.Index) Then
                If Me.dgvOtherItems.Rows.Count > 1 Then Me.SetOtherItemsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsQuantity.Index) Then
                Me.CalculateOtherItemsCost(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsUnitCost.Index) Then
                Me.CalculateOtherItemsCost(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsPack.Index) Then
                Dim pack As String = StringMayBeEnteredIn(dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsPack)

                If (String.IsNullOrEmpty(pack) OrElse pack.Equals(oPack.NA)) Then
                    Me.dgvOtherItems.Item(Me.ColOtherItemsPackSize.Name, selectedRow).Value = 1
                    ColOtherItemsPackSize.ReadOnly = True
                Else
                    Me.dgvOtherItems.Item(Me.ColOtherItemsPackSize.Name, selectedRow).Value = 1
                    Me.dgvOtherItems.Item(Me.ColOtherItemsQuantity.Name, selectedRow).Value = 1
                    ColOtherItemsPackSize.ReadOnly = False
                End If

                Me.CalculateOtherItemsCost(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsPackSize.Index) Then
                Me.CalculateOtherItemsCost(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsUnitCost.Index) Then
                Me.CalculateTotalOtherItemsCost()

            End If
            Me.CalculateTotalOtherItemsCost()
        Catch ex As Exception
            ErrorMessage(ex)

        End Try



    End Sub

    Private Sub SetOtherItemsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsItemCode)

            Me.SetOtherItemsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetOtherItemsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            If CBool(Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("OtherItems No (" + Me._OtherItemsNo + ") can't be edited!")
                Me.dgvOtherItems.Item(Me.ColOtherItemsItemCode.Name, selectedRow).Value = Me._OtherItemsNo
                Me.dgvOtherItems.Item(Me.ColOtherItemsItemCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(rowNo).Cells, Me.ColOtherItemsItemCode)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("OtherItems No (" + enteredItem + ") already selected!")
                        Me.dgvOtherItems.Item(Me.ColOtherItemsItemCode.Name, selectedRow).Value = Me._OtherItemsNo
                        Me.dgvOtherItems.Item(Me.ColOtherItemsItemCode.Name, selectedRow).Selected = True

                    End If
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailOtherItems(selectedRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvOtherItems_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvOtherItems.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))
            Dim itemCode As String = Me.dgvOtherItems.Item(Me.ColOtherItemsItemCode.Name, toDeleteRowNo).Value.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oInventoryOrderDetails
                .OrderNo = orderNo
                .ItemCategoryID = oItemCategoryID.NonMedical
                .ItemCode = itemCode
            End With

            DisplayMessage(oInventoryOrderDetails.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub DetailOtherItems(ByVal selectedRow As Integer)

        Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "From Location!")

            If selectedRow >= 0 Then

                Try

                    Dim OtherItemsNo As String = String.Empty
                    If Me.dgvOtherItems.Rows.Count > 1 Then OtherItemsNo = SubstringRight(StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsItemCode))

                    If String.IsNullOrEmpty(OtherItemsNo) Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim OtherItems As DataTable = oOtherItems.GetOtherItems(OtherItemsNo).Tables("OtherItems")
                    Dim OtherItemsRow As DataRow = OtherItems.Rows(0)

                    Dim hidden As Boolean = BooleanMayBeEnteredIn(OtherItemsRow, "Hidden")
                    Dim OtherItemsName As String = StringEnteredIn(OtherItemsRow, "ItemName", "Items Name!")
                    Dim unitCost As Decimal = DecimalEnteredIn(OtherItemsRow, "UnitCost", False)
                    If hidden Then Throw New ArgumentException("The OtherItems No: " + OtherItemsNo + ", is not enabled for selection. Contact administrator!")

                    With Me.dgvOtherItems
                        .Item(Me.ColOtherItemsItemCode.Name, selectedRow).Value = OtherItemsNo.ToUpper()
                        .Item(Me.ColOtherItemsName.Name, selectedRow).Value = OtherItemsName
                        .Item(Me.ColOtherItemsItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.ColOtherItemsPackSize.Name, selectedRow).Value = 1
                        .Item(Me.ColOtherItemsQuantity.Name, selectedRow).Value = 1
                        .Item(Me.ColOtherItemsTotalUnits.Name, selectedRow).Value = 1
                        .Item(Me.ColOtherItemsUnitCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                        .Item(Me.ColOtherItemsTotalCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(fromLocationID) Then Return
                    Me.ClearOtherItemsGridColumns(selectedRow)

                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.NonMedical, OtherItemsNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Return
                    Dim row As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOtherItems.Item(Me.ColOtherItemsLocationBalance.Name, selectedRow).Value = locationBalance
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.dgvOtherItems.Item(Me.ColOtherItemsItemCode.Name, selectedRow).Value = Me._OtherItemsNo.ToUpper()
                    Throw ex
                End Try

            Else

                If String.IsNullOrEmpty(fromLocationID) Then Return
                Me.ClearOtherItemsGridColumns(selectedRow)

                For Each row As DataGridViewRow In Me.dgvOtherItems.Rows

                    If row.IsNewRow Then Exit For

                    Dim OtherItemsNo As String = StringMayBeEnteredIn(row.Cells, Me.ColOtherItemsItemCode)
                    If String.IsNullOrEmpty(OtherItemsNo) Then Continue For

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.NonMedical, OtherItemsNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                    Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                    Dim locationBalance As Integer = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOtherItems.Item(Me.ColOtherItemsLocationBalance.Name, row.Index).Value = locationBalance
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Next

            End If
            CalculateTotalOtherItemsCost()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

   
    Private Sub ClearOtherItemsGridColumns(ByVal selectedRow As Integer)

        If selectedRow < 0 Then
            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOtherItems.Item(Me.ColOtherItemsLocationBalance.Name, row.Index).Value = String.Empty
            Next
        Else : Me.dgvOtherItems.Item(Me.ColOtherItemsLocationBalance.Name, selectedRow).Value = String.Empty
        End If

    End Sub

    Private Sub ClearOtherItemsGridColumns()
        Me.ClearOtherItemsGridColumns(-1)
    End Sub

    Private Sub LoadOtherItemsOrderDetails(ByVal orderNo As String)

        Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()

        Try

            Me.dgvOtherItems.Rows.Clear()

            ' Load InventoryOrderDetails

            Dim orderDetails As DataTable = oInventoryOrderDetails.GetInventoryOrderDetails(orderNo, oItemCategoryID.NonMedical).Tables("InventoryOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(dgvOtherItems, orderDetails)

            For pos As Integer = 0 To orderDetails.Rows.Count - 1

                Dim dataRow As DataRow = orderDetails.Rows(pos)

                With Me.dgvOtherItems

                    .Item(Me.ColOtherItemsPack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")

                End With


            Next

            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CalculateTotalOtherItemsCost()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub DetailOtherItems()

        Try
            Me.DetailOtherItems(-1)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region


#Region "Grid Methods"

    Private Sub CalculateDrugCost(ByVal selectedRow As Integer)
        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim rate As Decimal = DecimalMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugUnitCost)
        Dim pack As String = StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugPack)
        Dim packSize As Single = SingleMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugPackSize)
        Dim totalUnits As Single = quantity * packSize

        Dim amount As Decimal = CDec(totalUnits * rate)

        Me.dgvDrugs.Item(Me.colDrugTotalCost.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)
        Me.dgvDrugs.Item(Me.colDrugTotalUnits.Name, selectedRow).Value = totalUnits

    End Sub


    Private Sub CalculateTotalDrugCost()


        Dim totalBill As Decimal = CalculateGridAmount(Me.dgvDrugs, Me.colDrugTotalCost)

        Me.stbDrugCost.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        CalculateTotalCost()
    End Sub

    Private Sub CalculateTotalOtherItemsCost()


        Dim totalBill As Decimal = CalculateGridAmount(Me.dgvOtherItems, Me.ColOtherItemsTotalCost)

        Me.stbOtherItemsCost.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        CalculateTotalCost()
    End Sub

    Private Sub CalculateOtherItemsCost(ByVal selectedRow As Integer)
        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsQuantity)
        Dim rate As Decimal = DecimalMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsUnitCost)
        Dim pack As String = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsPack)
        Dim packSize As Single = SingleMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsPackSize)
        Dim totalUnits As Single = quantity * packSize

        Dim amount As Decimal = CDec(totalUnits * rate)

        Me.dgvOtherItems.Item(Me.ColOtherItemsTotalCost.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)
        Me.dgvOtherItems.Item(Me.ColOtherItemsTotalUnits.Name, selectedRow).Value = totalUnits

    End Sub

#End Region

#Region " InventoryOrders Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintInventoryOrders()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintInventoryOrders()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDrugs.RowCount < 1 OrElse Me.dgvConsumables.RowCount < 1 OrElse Me.dgvOtherItems.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry on Order details!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetInventoryOrdersPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docInventoryOrders
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInventoryOrders.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docInventoryOrders_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docInventoryOrders.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Internal Inventory Order".ToUpper()

            Dim orderNo As String = StringMayBeEnteredIn(Me.stbOrderNo)
            Dim orderDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpOrderDate))
            Dim orderType As String = StringEnteredIn(Me.cboOrderType)
            Dim fromLocation As String = StringMayBeEnteredIn(Me.cboFromLocationID)
            Dim toLocation As String = StringMayBeEnteredIn(Me.cboToLocationID)

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

                    .DrawString("Order No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(orderNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Order Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(orderDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Order Type: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(orderType, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("From Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("To Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(toLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If orderParagraphs Is Nothing Then Return

                Do While orderParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(orderParagraphs(1), PrintParagraps)
                    orderParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos,
                                                                          e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

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
                        orderParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (orderParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetInventoryOrdersPrintData()

        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        pageNo = 0
        orderParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Total Units: ".PadLeft(padQuantity))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DrugsData().ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ConsumablesData().ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OtherItemsData().ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Ordered By:         " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Received By:        " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

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
                Dim totalUnits As String = cells.Item(Me.colDrugTotalUnits.Name).Value.ToString()

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 40 Then
                    tableData.Append(itemName.Substring(0, 40).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(totalUnits.PadLeft(padQuantity))

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
                Dim itemName As String = cells.Item(Me.colConsumableName.Name).Value.ToString()
                Dim totalUnits As String = cells.Item(Me.colConsumableTotalUnit.Name).Value.ToString()

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 40 Then
                    tableData.Append(itemName.Substring(0, 40).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(totalUnits.PadLeft(padQuantity))

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
                Dim itemName As String = cells.Item(Me.ColOtherItemsName.Name).Value.ToString()
                Dim totalUnits As String = cells.Item(Me.ColOtherItemsTotalUnits.Name).Value.ToString()

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 40 Then
                    tableData.Append(itemName.Substring(0, 40).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(totalUnits.PadLeft(padQuantity))

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Popup Menu "

    Private Sub cmsInventoryOrders_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsInventoryOrders.Opening

        Select Case Me.tbcInventoryOrders.SelectedTab.Name

            Case Me.tpgDrugs.Name
                Me.cmsInventoryOrdersQuickSearch.Visible = True

            Case Me.tpgConsumables.Name
                Me.cmsInventoryOrdersQuickSearch.Visible = True

            Case Else
                Me.cmsInventoryOrdersQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsInventoryOrdersQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInventoryOrdersQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcInventoryOrders.SelectedTab.Name

                Case Me.tpgDrugs.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvDrugs, Me.colDrugNo)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDrugs.NewRowIndex
                    If rowIndex > 0 Then Me.SetDrugsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgConsumables.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ConsumableItems", Me.dgvConsumables, Me.colConsumableNo)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvConsumables.NewRowIndex
                    If rowIndex > 0 Then Me.SetConsumableEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        Me.stbOrderNo.ReadOnly = False
        Me.btnLoad.Enabled = True
        Me.pnlPrintOnSaving.Visible = False
        Me.btnPrint.Visible = True

        ResetControlsIn(Me)
        Me.ResetTabControls()
        Me.cboFromLocationID.Enabled = False

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbOrderNo.ReadOnly = InitOptions.OrderNoLocked
        Me.btnLoad.Enabled = False
        Me.pnlPrintOnSaving.Visible = True
        Me.btnPrint.Visible = False

        'ResetControlsIn(Me)
        Me.ResetTabControls()
        Me.cboFromLocationID.Enabled = True
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.SetNextOrderNo()
        Me.SetDefaultLocation()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.dtpOrderDate.Value = Today
        Me.dtpOrderDate.Checked = True
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

#End Region



    Private Function CountToOrderInventoryLocation(ItemCategoryID As String, fromLocationID As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        ' Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToOrderInventoryLocation(ItemCategoryID, fromLocationID)

            Select Case Me.tbcInventoryOrders.SelectedTab.Name
                Case Me.tpgDrugs.Name
                    Me.lblToOrderDrugs.Text = "To Order Drugs: " + records.ToString()
                Case Me.tpgConsumables.Name
                    Me.lblToOrderDrugs.Text = "To Order Consumables: " + records.ToString()
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function CountToExpireInventoryLocation(ItemCategoryID As String, fromLocationID As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oVariousOptions As New VariousOptions()
        ' Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToExpireInventoryLocation(ItemCategoryID, fromLocationID, oVariousOptions.ExpiryWarningDays)

            Select Case Me.tbcInventoryOrders.SelectedTab.Name
                Case Me.tpgDrugs.Name
                    Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: " + records.ToString()
                Case Me.tpgConsumables.Name
                    Me.lblToExpireDrugs.Text = "To Expire/Expired Consumables: " + records.ToString()
            End Select
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewToExpireDrugsList_Click(sender As Object, e As EventArgs) Handles btnViewToExpireDrugsList.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try

            InventoryOrders.Values.Clear()
            Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.tbcInventoryOrders.SelectedTab.Name
                Case Me.tpgDrugs.Name
                    Dim GetToCountToOrderInventoryLocation As New frmGetToCountInventoryLocation(fromLocationID, oItemCategoryID.Drug, ItemsTo.Expire)
                    GetToCountToOrderInventoryLocation.ShowDialog(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DrugPair As KeyValuePair(Of String, String)
                    For Each DrugPair In InventoryOrders.Values

                        With Me.dgvDrugs
                            .Rows.Add()
                            .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = DrugPair.Key
                            '.Item(Me.colDrugName.Name, .NewRowIndex - 1).Value = pair.Value
                            Me.SetDrugsEntries(.NewRowIndex - 1, DrugPair.Key)
                        End With
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgConsumables.Name
                    Dim GetToCountToOrderInventoryLocation As New frmGetToCountInventoryLocation(fromLocationID, oItemCategoryID.Consumable, ItemsTo.Expire)
                    GetToCountToOrderInventoryLocation.ShowDialog(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim ConsumablePair As KeyValuePair(Of String, String)
                    For Each ConsumablePair In InventoryOrders.Values

                        With Me.dgvConsumables
                            .Rows.Add()
                            .Item(Me.colConsumableNo.Name, .NewRowIndex - 1).Value = ConsumablePair.Key
                            '.Item(Me.colDrugName.Name, .NewRowIndex - 1).Value = pair.Value
                            'Me.SetDrugsEntries(.NewRowIndex - 1, ConsumablePair.Key)
                            Me.SetConsumableEntries(.NewRowIndex - 1, ConsumablePair.Key)
                        End With
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cboFromLocationID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFromLocationID.SelectedIndexChanged

        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            SetLocationType()
            If String.IsNullOrEmpty(fromLocationID) Then Return

            Select Case Me.tbcInventoryOrders.SelectedTab.Name

                Case Me.tpgDrugs.Name
                  If (Not (fromLocationID = "")) Then

                        Me.CountToOrderInventoryLocation(oItemCategoryID.Drug, fromLocationID)
                        Me.CountToExpireInventoryLocation(oItemCategoryID.Drug, fromLocationID)
                    End If
                Case Me.tpgConsumables.Name
                    If (Not (fromLocationID = "")) Then
                        Me.CountToOrderInventoryLocation(oItemCategoryID.Consumable, fromLocationID)
                        Me.CountToExpireInventoryLocation(oItemCategoryID.Consumable, fromLocationID)
                        End If
            End Select
           
            If (Not (fromLocationID = "")) Then
                   Me.GetAllPendingOrderDetails(fromLocationID)
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub


    Private Sub tbcInventoryOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcInventoryOrders.SelectedIndexChanged
        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If String.IsNullOrEmpty(fromLocationID) Then Return

            Select Case Me.tbcInventoryOrders.SelectedTab.Name

                Case Me.tpgDrugs.Name
                    
                    Me.CountToOrderInventoryLocation(oItemCategoryID.Drug, fromLocationID)
                    Me.CountToExpireInventoryLocation(oItemCategoryID.Drug, fromLocationID)

                Case Me.tpgConsumables.Name
                    
                    Me.CountToOrderInventoryLocation(oItemCategoryID.Consumable, fromLocationID)
                    Me.CountToExpireInventoryLocation(oItemCategoryID.Consumable, fromLocationID)

            End Select


        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnViewToOrderDrugsList_Click(sender As Object, e As EventArgs) Handles btnViewToOrderDrugsList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try


            InventoryOrders.Values.Clear()
            Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            ' Dim frmToOrderItemsPerLocation As New frmToOrderItemsPerLocation(fromLocationID)
            ' Dim frmToOrderItemsPerLocation As New frmToOrderItemsPerLocation(ItemsTo.Order, oItemCategoryID.Drug, fromLocationID)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.tbcInventoryOrders.SelectedTab.Name
                Case Me.tpgDrugs.Name
                    Dim GetToCountInventoryLocation As New frmGetToCountInventoryLocation(fromLocationID, oItemCategoryID.Drug, ItemsTo.Order)
                    GetToCountInventoryLocation.ShowDialog(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim DrugPair As KeyValuePair(Of String, String)
                    For Each DrugPair In InventoryOrders.Values

                        With Me.dgvDrugs
                            .Rows.Add()
                            .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = DrugPair.Key
                            '.Item(Me.colDrugName.Name, .NewRowIndex - 1).Value = pair.Value
                            Me.SetDrugsEntries(.NewRowIndex - 1, DrugPair.Key)
                        End With
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgConsumables.Name
                    Dim GetToCountInventoryLocation As New frmGetToCountInventoryLocation(fromLocationID, oItemCategoryID.Consumable, ItemsTo.Order)
                    GetToCountInventoryLocation.ShowDialog(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim ConsumablePair As KeyValuePair(Of String, String)
                    For Each ConsumablePair In InventoryOrders.Values

                        With Me.dgvConsumables
                            .Rows.Add()
                            .Item(Me.colConsumableNo.Name, .NewRowIndex - 1).Value = ConsumablePair.Key
                            '.Item(Me.colDrugName.Name, .NewRowIndex - 1).Value = pair.Value
                            ' Me.SetDrugsEntries(.NewRowIndex - 1, ConsumablePair.Key)
                            Me.SetConsumableEntries(.NewRowIndex - 1, ConsumablePair.Key)
                        End With
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

           
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

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

        'LoadLookupDataCombo(Me.cboFromLocationID, objectID, False)
    End Sub


    Private Sub LoadInventoryLocations()
        Dim oLookupData As New LookupData()
        cboFromLocationID.DataSource = Nothing

        Dim oInventoryLocation As New InventoryLocation()
        Dim allInventoryLocation As DataTable = oInventoryLocation.GetAllInventionLocations().Tables("AllLocations")

        
        If allInventoryLocation.Rows.Count() < 1 Then Return
        Me.cboFromLocationID.DataSource = allInventoryLocation
        cboFromLocationID.DisplayMember = "DataDes"
        cboFromLocationID.ValueMember = "DataID"
        Me.cboFromLocationID.SelectedIndex = -1

    End Sub

    Private Sub SetLocationType()
        Try
            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)

            If String.IsNullOrEmpty(locationID) Then Return

            Dim oInventoryLocation As New InventoryLocation()
            Dim allInventoryLocation As DataTable = oInventoryLocation.GetInvectionLocationByDataID(locationID).Tables("AllLocations")


            If allInventoryLocation.Rows.Count() < 1 Then Return
            
            Dim row As DataRow = allInventoryLocation.Rows(0)
            Dim objectID As Integer = IntegerEnteredIn(row, "ObjectID")
           
            If objectID = LookupObjects.Location Then
                Me.cboOrderType.SelectedValue = oOrderType.Internal()
            Else
                Me.cboOrderType.SelectedValue = oOrderType.External()
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Function GetAllPendingOrderDetails(locationCode As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.GetAllPendingOrderDetails(locationCode)

            Me.lblPendingIventoryAcknowledgements.Text = "Pending Ack: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnPendingIventoryAcknowledgements_Click(sender As System.Object, e As System.EventArgs) Handles btnPendingIventoryAcknowledgements.Click
        Try
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Dim fInventoryAcknowledges As New frmInventoryAcknowledges()
            fInventoryAcknowledges.ShowDialog(Me)
            Me.GetAllPendingOrderDetails(LocationID)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


    Private Sub ClearControls()

        Me.cboFromLocationID.SelectedIndex = -1
        Me.cboFromLocationID.SelectedIndex = -1
        Me.cboToLocationID.SelectedIndex = -1
        Me.cboToLocationID.SelectedIndex = -1

        Me.dgvDrugs.Rows.Clear()
        Me.dgvConsumables.Rows.Clear()
        Me.dgvOtherItems.Rows.Clear()
        Me.stbDrugCost.Clear()
        Me.stbConsumableCost.Clear()
        Me.stbOtherItemsCost.Clear()
        Me.stbTotalcost.Clear()

        Me.SetDefaultLocation()

    End Sub
End Class