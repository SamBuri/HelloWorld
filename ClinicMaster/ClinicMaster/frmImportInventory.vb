
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class frmImportInventory
    Dim oImportType As New LookupDataID.InventoryImportType
    Dim oStockTypeID As New LookupDataID.StockTypeID()
    Private locationID As String = String.Empty
    Private itemCategoryID As String = String.Empty
    Private notes As String = String.Empty
    Private _itemNo As String = String.Empty
    Private oItemCateoryID As New LookupDataID.ItemCategoryID()
    Private itemFullName As String = String.Empty
    Private itemCode As String = String.Empty
    Private oVariousOptions As New VariousOptions()
#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
    Private itemName As String
#End Region

    Private Sub frmImportInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.CloseExpiredPhysicalStockCount()
            LoadLookupDataCombo(Me.cbImportTypeID, LookupObjects.InventoryImportType, False)
            If Not oVariousOptions.UseCentralisedPhysicalStockCount Then SetNextPSCNo()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CloseExpiredPhysicalStockCount()
        Try
            Dim oPhysicalStockCount As New PhysicalStockCount()
            oPhysicalStockCount.CloseExpiredPhysicalStockCount(Now)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbFileName.TextChanged
        Me.ResetCTLS()
    End Sub

    Private Sub stbWorksheetName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbWorksheetName.TextChanged
        Me.ResetCTLS()
    End Sub

    Private Sub ResetCTLS()
        Me.lblRecordsImported.Text = String.Empty
        Me.dgvImportedData.Rows.Clear()
        Me.fbnErrorLog.Enabled = False
        Me.lblSaveReport.Text = String.Empty
        Me.fbnExport.Visible = False
        Me.chkIncludeAll.Checked = False

    End Sub

    Private Sub fbnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnBrowse.Click

        Dim openFileDLG As New OpenFileDialog()

        Try
            Me.Cursor = Cursors.WaitCursor

            With openFileDLG

                Try
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                Catch ex As Exception
                    Exit Try
                End Try

                .Filter = "Microsoft Excel Files (*.xlsx)|*.xlsx|Excel Files (*.xls)|*.xls"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then Me.stbFileName.Text = .FileName.ToString()

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnImport.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            GetImportedData()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub fbnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSaveAll.Click

        Dim savedRows As New List(Of Integer)

        Try
            Me.Cursor = Cursors.WaitCursor


            Me._ErrorLog.Remove(0, Me._ErrorLog.Length)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvImportedData.RowCount < 2 Then Throw New ArgumentException("Must have at least one entry for Inventory!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim importType As String = StringValueEnteredIn(cbImportTypeID, "Import Type")

            Dim oStockTypeID As New LookupDataID.StockTypeID()
            Dim oEntryModeID As New LookupDataID.EntryModeID()

          
            Dim lPhysicalStockCount As New List(Of DBConnect)
            Dim _PSCNo As String = RevertText(StringEnteredIn(stbPSCNo, "Physical Stock Count No!"))

            If Not oVariousOptions.UseCentralisedPhysicalStockCount AndAlso (importType.Equals(oImportType.PhysicalStockCount) OrElse importType.Equals(oImportType.OneByOne)) Then
                Try

                    Using oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

                        With oPhysicalStockCount

                            .PSCNo = _PSCNo
                            .GeneralNotes = StringEnteredIn(stbGeneralNotes, "General Notes!")
                            .LoginID = CurrentUser.LoginID
                            .StartDate = Now
                            .EndDate = Today.AddDays(1)
                            .Closed = False
                            .Save()
                        End With


                    End Using
                Catch ex As Exception
                    If ex.Message.Contains("The record with PSC No:") OrElse ex.Message.EndsWith("already exists") Then
                        Dim Message As String = "The PSC No: " + Me.stbPSCNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine _
                                + "If you are using the system generated number, probably another user has already taken it." + ControlChars.NewLine _
                                + "Would you like the system to generate another one?."
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.SetNextPSCNo()

                    Else : ErrorMessage(ex)
                    End If
                    ErrorMessage(ex)
                    Return
                End Try
            End If

            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 2

                Dim id As Integer
                Dim lInventory As New List(Of DBConnect)
                Dim lPhysicalStockCountDetailsList As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Try

                    Me.Cursor = Cursors.WaitCursor

                    Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

                    id = CInt(Me.dgvImportedData.Item(Me.colID.Name, rowNo).Value)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim batchNo As String = String.Empty
                    Dim expiryDate As Date
                    Dim location As String = StringEnteredIn(cells, Me.colLocation, "Location!")
                    Dim itemCode As String = RevertText(StringEnteredIn(cells, Me.colItemCode, "Item Code!"))
                    Dim itemName As String = StringEnteredIn(cells, Me.colItemName, "Item Name!")
                    Dim itemCategory As String = StringEnteredIn(cells, Me.colItemCategory, "Item Category!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity)
                    Dim variance As Integer = IntegerMayBeEnteredIn(cells, Me.colVariance)
                    Dim stockType As String = StringEnteredIn(cells, Me.colStockType, "StockType")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)
                    Dim stockTypeID As String = GetLookupDataID(LookupObjects.StockType, stockType)
                    Dim locationID As String = GetLookupDataID(LookupObjects.Location, location)
                    Dim itemCategoryID As String = GetLookupDataID(LookupObjects.ItemCategory, itemCategory)
                   
                    If String.IsNullOrEmpty(locationID) Then
                        Throw New ArgumentException("Location has wrong value!")

                    End If

                    If String.IsNullOrEmpty(itemCategoryID) Then
                        Throw New ArgumentException("Item Category has wrong value!")

                    End If

                    If stockTypeID.Equals(oStockTypeID.Received) Then
                        batchNo = StringEnteredIn(cells, Me.colBatchNo, "Batch No!")
                        expiryDate = DateEnteredIn(cells, Me.colExpiryDate, "Expiry Date!")
                    ElseIf stockTypeID.Equals(oStockTypeID.Issued) Then
                        batchNo = StringMayBeEnteredIn(cells, Me.colBatchNo)
                        expiryDate = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                    End If


                    Using oInventory As New SyncSoft.SQLDb.Inventory()

                        With oInventory

                            .LocationID = locationID
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .TranDate = Today
                            .StockTypeID = stockTypeID
                            If importType.Equals(oImportType.PhysicalStockCount) OrElse importType.Equals(oImportType.OneByOne) Then

                                .Quantity = variance
                            Else
                                .Quantity = quantity
                            End If
                            .Details = "New Stock (" + itemName + ")" + stockType
                            .EntryModeID = oEntryModeID.Imported
                            .LoginID = CurrentUser.LoginID
                            .BatchNo = batchNo
                            .ExpiryDate = expiryDate
                            .Details = notes

                        End With

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lInventory.Add(oInventory)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If (importType.Equals(oImportType.PhysicalStockCount) OrElse importType.Equals(oImportType.OneByOne)) Then
                        Using oPhysicalStockCountDetails As New SyncSoft.SQLDb.PhysicalStockCountDetails()

                         
                            With oPhysicalStockCountDetails

                                .PSCNo = _PSCNo
                                .LocationID = locationID
                                .ItemCategoryID = itemCategoryID
                                .ItemCode = itemCode
                                .SystemQuantity = IntegerEnteredIn(cells, Me.colSystemQuantity)
                                .LoginID = CurrentUser.LoginID
                                .PhysicalCountQuantity = quantity
                                .Notes = StringMayBeEnteredIn(cells, Me.colNotes)

                            End With

                            lPhysicalStockCountDetailsList.Add(oPhysicalStockCountDetails)

                        End Using


                    End If

                    transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lPhysicalStockCountDetailsList, Action.Save))


                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    savedRows.Add(rowNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me._ErrorLog.Append("*** Imported record ID " + id.ToString() + ": " + ex.Message)
                    Me._ErrorLog.AppendLine()
                    Me._ErrorLog.AppendLine()

                Finally
                    Me.Cursor = Cursors.Default

                End Try

            Next
            

            If Not oVariousOptions.UseCentralisedPhysicalStockCount Then
                Me.ClearControls()
                Me.SetNextPSCNo()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me._ErrorLog.Length > 0 Then
                Me.fbnErrorLog.Enabled = True
                Me.fbnExport.Visible = True
            Else
                Me.fbnErrorLog.Enabled = False
                Me.fbnExport.Visible = False
            End If

            Dim saveMSG As String = "{" + savedRows.Count.ToString() + "} Records saved successfully and {" +
                                    (Me.dgvImportedData.RowCount - 1 - savedRows.Count).ToString() + "} failed."
            Me.lblSaveReport.Text = saveMSG
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = savedRows.Count - 1 To 0 Step -1
                Me.dgvImportedData.Rows.RemoveAt(savedRows.Item(pos))
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

            
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetPhysicalStockCount()
        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()
        Try
            Me.stbGeneralNotes.Clear()
            Dim pSCNo As String = RevertText(StringMayBeEnteredIn(Me.stbPSCNo))

            If String.IsNullOrEmpty(pSCNo) Then Return

            Dim dataSource As DataTable = oPhysicalStockCount.GetPhysicalStockCount(pSCNo).Tables("PhysicalStockCount")
            Dim row As DataRow = dataSource.Rows(0)
            Me.stbGeneralNotes.Text = StringEnteredIn(row, "GeneralNotes")
            Dim Closed As Boolean = BooleanEnteredIn(row, "Closed")

            If Closed = True Then
                Throw New ArgumentException("The PSCNo: " + Me.stbPSCNo.Text + " is closed and can't be used")

            End If
        Catch ex As Exception
            ErrorMessage(ex)
            Me.ClearControls()
        End Try
    End Sub

    Private Sub ClearControls()
        Me.stbGeneralNotes.Clear()
        Me.stbPSCNo.Clear()

    End Sub

    Private Sub GetImportedData()

        Dim importType As String = StringValueEnteredIn(cbImportTypeID, "Import Type!")


        Dim path As String = StringEnteredIn(Me.stbFileName, "File Name!")
        Dim workSheetName As String = StringEnteredIn(Me.stbWorksheetName, "Work Sheet Name!")
        Dim range As String = ""
        Dim where As String = "where [Item Code] is not null"

        Dim criterion As String = "select * from [" + workSheetName + "$" + range + "] " + where
        Dim importedData As DataTable = ImportFromExcel(path, criterion)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oInventory As New Inventory()

        Dim stockType As String = String.Empty


        Me.ResetCTLS()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim rowID As Integer = 0
        For pos As Integer = 0 To importedData.Rows.Count - 1

            Dim row As DataRow = importedData.Rows(pos)
            Dim location As String = StringMayBeEnteredIn(row, "Location")
            Dim itemNo As String = StringMayBeEnteredIn(row, "Item Code")
            Dim itemCategory As String = StringMayBeEnteredIn(row, "Item Category")
            Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")

            Dim balance As Integer = 0
            Dim variance As Integer = 0

            rowID += 1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If (importType.Equals(oImportType.PhysicalStockCount) OrElse importType.Equals(oImportType.OneByOne)) Then

                If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.Location, location)) Then
                    Throw New ArgumentException("Location has wrong value!")
                Else : locationID = GetLookupDataID(LookupObjects.Location, location)
                End If

                If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.ItemCategory, itemCategory)) Then
                    Throw New ArgumentException("Item Category has wrong value!")
                Else : itemCategoryID = GetLookupDataID(LookupObjects.ItemCategory, itemCategory)
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                balance = oInventory.GetInventoryBalance(locationID, itemCategoryID, itemNo)

                variance = quantity - balance


                If (variance > 0) Then

                    stockType = GetLookupDataDes(oStockTypeID.Received)

                Else : stockType = GetLookupDataDes(oStockTypeID.Issued)
                End If
            Else stockType = GetLookupDataDes(oStockTypeID.Received)
            End If

            notes = "To tally system And physical stock at " + location + ", " + Math.Abs(variance).ToString() + " unit(s) were " + stockType

            If variance = 0 Then
                notes = "The system And physical stock at " + location + ",  were equal"
            End If


            With Me.dgvImportedData

                .Rows.Add()

                .Item(Me.colID.Name, pos).Value = rowID
                .Item(Me.colLocation.Name, pos).Value = StringMayBeEnteredIn(row, "Location")
                .Item(Me.colItemCode.Name, pos).Value = StringMayBeEnteredIn(row, "Item Code")
                .Item(Me.colItemName.Name, pos).Value = StringMayBeEnteredIn(row, "Item Name")
                .Item(Me.colItemCategory.Name, pos).Value = StringMayBeEnteredIn(row, "Item Category")
                .Item(Me.colQuantity.Name, pos).Value = quantity
                If (importType.Equals(oImportType.PhysicalStockCount) OrElse importType.Equals(oImportType.OneByOne)) Then
                    .Item(Me.colSystemQuantity.Name, pos).Value = balance
                    .Item(Me.colVariance.Name, pos).Value = Math.Abs(variance)
                    .Item(Me.colNotes.Name, pos).Value = notes
                End If
                .Item(Me.colStockType.Name, pos).Value = stockType

                .Item(Me.colBatchNo.Name, pos).Value = StringMayBeEnteredIn(row, "Batch No")

                If IsDBNull(importedData.Rows(pos).Item("Expiry Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Expiry Date")) Then
                    .Item(Me.colExpiryDate.Name, pos).Value = AppData.NullDateValue
                Else : .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Expiry Date")))
                End If

            End With

        Next
        If (importType.Equals(oImportType.PhysicalStockCount) OrElse importType.Equals(oImportType.OneByOne)) Then
            If Not oVariousOptions.UseCentralisedPhysicalStockCount Then SetNextPSCNo()
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for Inventory!"


    End Sub

    Private Sub LoadItems()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim itemCategoryID As String = StringValueMayBeEnteredIn(cboItemCategoryID)
            Dim locationID As String = StringValueMayBeEnteredIn(cboImportLocation)
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Me.dgvImportedData.Rows.Clear()

            If String.IsNullOrEmpty(itemCategoryID) Then Return

            Dim dataSource As New DataTable
            Dim itemCode As String = String.Empty
            Dim itemName As String = String.Empty

            Dim itemCodeColumn As String = String.Empty
            Dim itemNameColumn As String = String.Empty


            Select Case itemCategoryID


                Case oItemCategoryID.Drug
                    Dim oDrugs As New SyncSoft.SQLDb.Drugs()
                    dataSource = oDrugs.GetDrugs().Tables("Drugs")

                    itemCodeColumn = "DrugNo"
                    itemNameColumn = "DrugName"


                Case oItemCateoryID.Consumable
                    Dim oConsumableItem As New SyncSoft.SQLDb.ConsumableItems()
                    dataSource = oConsumableItem.GetConsumableItems().Tables("ConsumableItems")

                    itemCodeColumn = "ConsumableNo"
                    itemNameColumn = "ConsumableName"



                Case oItemCategoryID.NonMedical
                    Dim oOtherItem As New SyncSoft.SQLDb.OtherItems()
                    dataSource = oOtherItem.GetOtherItems().Tables("OtherItems")

                    itemCodeColumn = "ItemCode"
                    itemNameColumn = "ItemName"

            End Select

            Dim rowCount As Integer = dataSource.Rows.Count()

            For row As Integer = 0 To rowCount - 1
                Me.dgvImportedData.Rows.Add()
                Dim rowIndex As DataRow = dataSource.Rows(row)
                itemCode = StringEnteredIn(rowIndex, itemCodeColumn)
                itemName = StringEnteredIn(rowIndex, itemNameColumn)

                Dim ExpiryDate As String = StringMayBeEnteredIn(rowIndex, "ExpiryDate")
                Dim batchNo As String = StringMayBeEnteredIn(rowIndex, "BatchNo")
                Dim stockType As String = GetLookupDataDes(oStockTypeID.Issued)
                
                Dim unitsAtHand As Integer = GetInventoryBalance(locationID, itemCategoryID, itemCode)

                'notes = "To tally system And physical stock at " + GetLookupDataDes(locationID) + ", " + Math.Abs(variance).ToString() + " unit(s) were " + stockType

                'If variance = 0 Then
                notes = "The system And physical stock at " + GetLookupDataDes(locationID) + ",  were equal"

                'End If
                With Me.dgvImportedData
                    .Item(Me.colItemCode.Name, row).Value = itemCode
                    .Item(Me.colItemName.Name, row).Value = itemName
                    .Item(Me.colID.Name, row).Value = (row + 1)
                    .Item(Me.colItemCategory.Name, row).Value = GetLookupDataDes(itemCategoryID)
                    .Item(Me.colBatchNo.Name, row).Value = batchNo
                    .Item(Me.colExpiryDate.Name, row).Value = ExpiryDate
                    .Item(Me.colLocation.Name, row).Value = StringEnteredIn(cboImportLocation, "LocationID!").Trim
                    .Item(Me.colSystemQuantity.Name, row).Value = unitsAtHand
                    .Item(Me.colVariance.Name, row).Value = 0
                    .Item(Me.colQuantity.Name, row).Value = unitsAtHand
                    .Item(Me.colNotes.Name, row).Value = notes
                    .Item(Me.colStockType.Name, row).Value = stockType
                End With
                ' Me.DetailInventoryItem(row)
            Next
            Me.fbnExport.Visible = rowCount > 0
            lblRecordsImported.Text = rowCount.ToString() + " row(s) returned"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub SetNextPSCNo()
        Dim yearL2 As String = Today.Year.ToString().Substring(2)
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPhyscialStockCount As New PhysicalStockCount()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("PhysicalStockCount", "PSCNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextPSCID As String = oPhyscialStockCount.GetNextPSCID().ToString().PadLeft(paddingLEN, paddingCHAR)

            If Not oVariousOptions.UseCentralisedPhysicalStockCount Then Me.stbPSCNo.Text = FormatText(yearL2 + nextPSCID.Trim(), "PhysicalStockCount", "PSCNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnErrorLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnErrorLog.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim importLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\Inventory Import Log.txt"

            File.WriteAllText(importLogFile, Me._ErrorLog.ToString())

            If File.Exists(importLogFile) Then
                Process.Start(importLogFile)
            Else : DisplayMessage("No Import Error Message Logged!")
            End If

        Catch IOeX As IOException
            ErrorMessage(IOeX)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExport.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ExportToExcel(Me.dgvImportedData, Me.stbWorksheetName.Text)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub cbImportTypeID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImportTypeID.SelectedIndexChanged
        Dim importTypeID As String = StringValueMayBeEnteredIn(cbImportTypeID)
        If (String.IsNullOrEmpty(importTypeID)) Then Return

        colSystemQuantity.Visible = importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne)
        colNotes.Visible = importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne)
        colVariance.Visible = importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne)
        stbPSCNo.Visible = importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne)
        stbGeneralNotes.Visible = importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne)
        lblPSCNo.Visible = importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne)
        lblGeneralComment.Visible = importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne)

        lblLocation.Visible = importTypeID.Equals(oImportType.OneByOne)
        cboImportLocation.Visible = importTypeID.Equals(oImportType.OneByOne)
        lblItemCategoryID.Visible = importTypeID.Equals(oImportType.OneByOne)
        cboItemCategoryID.Visible = importTypeID.Equals(oImportType.OneByOne)

        Me.showSelectColumn()


        LoadItemCategories(importTypeID.Equals(oImportType.OneByOne))
        LoadLocations(importTypeID.Equals(oImportType.OneByOne))


        If importTypeID.Equals(oImportType.PhysicalStockCount) Or importTypeID.Equals(oImportType.OneByOne) Then

            If Not oVariousOptions.UseCentralisedPhysicalStockCount Then
                SetNextPSCNo()
            Else
                Me.SetLatestStockTakeNo()
            End If


        End If
        ResetCTLS()
       
    End Sub


    Private Sub dgvImportedData_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImportedData.CellEndEdit
        Try

            Dim selectedRow As Integer = Me.dgvImportedData.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colQuantity.Index) Then

                Dim importType As String = StringValueMayBeEnteredIn(cbImportTypeID)
                Dim stockType As String = String.Empty
                Dim variance As Integer = 0
                Dim location As String = String.Empty
                If importType.Equals(oImportType.PhysicalStockCount) OrElse importType.Equals(oImportType.OneByOne) Then

                    Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(selectedRow).Cells
                    Dim importedQuantity As Integer = IntegerMayBeEnteredIn(cells, colQuantity)
                    Dim balance As Integer = IntegerMayBeEnteredIn(cells, colSystemQuantity)
                    Location = StringMayBeEnteredIn(cells, colLocation)
                    variance = importedQuantity - balance

                    Me.dgvImportedData.Item(Me.colVariance.Name, selectedRow).Value = Math.Abs(variance)


                    If (variance > 0) Then
                        stockType = GetLookupDataDes(oStockTypeID.Received)
                    Else
                        stockType = GetLookupDataDes(oStockTypeID.Issued)
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else
                    stockType = GetLookupDataDes(oStockTypeID.Received)

                End If
                notes = "To tally system And physical stock at " + location + ", " + Math.Abs(variance).ToString() + " unit(s) were " + stockType

                If variance = 0 Then
                    notes = "The system And physical stock at " + location + ",  were equal"

                End If
                Me.dgvImportedData.Item(Me.colStockType.Name, selectedRow).Value = stockType
                    Me.dgvImportedData.Item(Me.colNotes.Name, selectedRow).Value = notes
                End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub SetInventoryLocationItems(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvImportedData.Rows(selectedRow).Cells, Me.colItemCode))
            Me.SetInventoryLocationItems(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub SetInventoryLocationItems(ByVal selectedRow As Integer, selectedItem As String)

        Try


            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvImportedData.Rows(rowNo).Cells, Me.colItemCode)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Item No (" + enteredItem + ") already selected!")
                        Me.dgvImportedData.Rows.RemoveAt(selectedRow)
                        Me.dgvImportedData.Item(Me.colItemCode.Name, selectedRow).Value = _itemNo
                        Me.dgvImportedData.Item(Me.colItemCode.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailInventoryItem(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailInventoryItem(ByVal selectedRow As Integer)

        Try

            Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()
            Dim itemNo As String = String.Empty
            Dim itemLocationID As String = StringValueEnteredIn(cboImportLocation, "Location!")
            Dim ItemCategoryID As String = StringValueEnteredIn(cboItemCategoryID, "Item Category ID!")

            Dim variance As Integer = 0
            Dim unitsAtHand As Integer
            Dim id As Integer = 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(itemLocationID) OrElse String.IsNullOrEmpty(ItemCategoryID) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvImportedData.Rows.Count > 1 Then
                itemNo = RevertText(SubstringRight(StringMayBeEnteredIn(Me.dgvImportedData.Rows(selectedRow).Cells, Me.colItemCode)))
                Dim previousRow As Integer = selectedRow - 1
                If previousRow < 0 Then previousRow = 0

                id = IntegerMayBeEnteredIn(Me.dgvImportedData.Rows(previousRow).Cells, Me.colID)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            id += 1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oConsumables As New ConsumableItems()
            Dim oDrug As New Drugs()
            Dim oOtherItems As New OtherItems()
            Dim inventoryItems As DataTable = New DataTable()

            If ItemCategoryID.Equals(oItemCateoryID.Drug) Then
                inventoryItems = oDrug.GetDrugs(itemNo).Tables("Drugs")

            ElseIf ItemCategoryID.Equals(oItemCateoryID.Consumable)
                inventoryItems = oConsumables.GetConsumableItems(itemNo).Tables("ConsumableItems")


            ElseIf ItemCategoryID.Equals(oItemCateoryID.NonMedical) Then
                inventoryItems = oOtherItems.GetOtherItems(itemNo).Tables("OtherItems")

            End If

            If inventoryItems.Rows.Count <= 0 Then Return
            Dim row As DataRow = inventoryItems.Rows(0)

            Dim itemNames As String = StringEnteredIn(row, Me.itemName, "Item Name!")
            Dim ExpiryDate As String = StringMayBeEnteredIn(row, "ExpiryDate")
            Dim batchNo As String = StringMayBeEnteredIn(row, "BatchNo")
            Dim stockType As String = GetLookupDataDes(oStockTypeID.Issued)

            unitsAtHand = GetInventoryBalance(itemLocationID, ItemCategoryID, itemNo)

            notes = "To tally system And physical stock at " + GetLookupDataDes(itemLocationID) + ", " + Math.Abs(variance).ToString() + " unit(s) were " + stockType

            If variance = 0 Then
                notes = "The system And physical stock at " + GetLookupDataDes(itemLocationID) + ",  were equal"

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvImportedData
                .Item(Me.colID.Name, selectedRow).Value = id
                .Item(Me.colItemCode.Name, selectedRow).Value = itemNo.ToUpper()
                .Item(Me.colItemName.Name, selectedRow).Value = itemNames
                .Item(Me.colItemCategory.Name, selectedRow).Value = GetLookupDataDes(ItemCategoryID)
                .Item(Me.colBatchNo.Name, selectedRow).Value = batchNo
                .Item(Me.colExpiryDate.Name, selectedRow).Value = ExpiryDate
                .Item(Me.colLocation.Name, selectedRow).Value = StringEnteredIn(cboImportLocation, "LocationID!")
                .Item(Me.colSystemQuantity.Name, selectedRow).Value = unitsAtHand
                .Item(Me.colVariance.Name, selectedRow).Value = 0
                .Item(Me.colQuantity.Name, selectedRow).Value = unitsAtHand
                .Item(Me.colNotes.Name, selectedRow).Value = notes
                .Item(Me.colStockType.Name, selectedRow).Value = stockType


            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvImportedData.Item(Me.colItemCode.Name, selectedRow).Value = Me._itemNo.ToUpper()
            ErrorMessage(ex)
            Throw ex

        End Try

    End Sub

    Private Sub LoadItemCategories(ByVal importedType As Boolean)


        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try
            If (importedType) Then
                Me.Cursor = Cursors.WaitCursor

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.cboItemCategoryID.DataSource = Nothing
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim inventoryLocation As DataTable = oInventoryLocation.GetDistintInventoryLocationItemCategory().Tables("InventoryLocation")

                If inventoryLocation.Rows.Count() < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cboItemCategoryID.DisplayMember = "ItemCategory"
                cboItemCategoryID.ValueMember = "ItemCategoryID"
                cboItemCategoryID.DataSource = inventoryLocation
                cboItemCategoryID.SelectedIndex = -1

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            DisplayMessage(ex.ToString)
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadLocations(ByVal importedType As Boolean)


        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()
        Try

            If (importedType) Then
                Me.Cursor = Cursors.WaitCursor


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.cboImportLocation.DataSource = Nothing
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim inventoryLocation As DataTable = oInventoryLocation.GetDistintInventoryLocations().Tables("InventoryLocation")

                If inventoryLocation.Rows.Count() < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cboImportLocation.DisplayMember = "Location"
                cboImportLocation.ValueMember = "LocationID"
                cboImportLocation.DataSource = inventoryLocation
                cboImportLocation.SelectedIndex = -1

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            DisplayMessage(ex.ToString)
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvImportedData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImportedData.CellClick

        Try
            If e.RowIndex < 0 Then Return

            If Me.colSelect.Index.Equals(e.ColumnIndex) Then


                If (String.IsNullOrEmpty(StringValueMayBeEnteredIn(cboItemCategoryID)) OrElse
                String.IsNullOrEmpty(StringValueMayBeEnteredIn(cboImportLocation))) Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Inventory Items", "Item Code", "Item Name", Me.GetItems(),
                                                                             Me.itemFullName, Me.itemCode, Me.itemName, Me.dgvImportedData,
                                                                         Me.colItemCode, e.RowIndex)

                _itemNo = StringMayBeEnteredIn(Me.dgvImportedData.Rows(e.RowIndex).Cells, Me.colItemCode)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.colSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvImportedData.Rows(e.RowIndex).IsNewRow Then

                    Me.dgvImportedData.Rows.Add()

                    fSelectItem.ShowDialog(Me)
                    Me.SetInventoryLocationItems(e.RowIndex)

                ElseIf Me.colSelect.Index.Equals(e.ColumnIndex) Then

                    fSelectItem.ShowDialog(Me)
                    Me.SetInventoryLocationItems(e.RowIndex)

                End If
            End If

            ''''''''''''''''''''''''''set expiry date picker''''''''''''''''''''''''''''''''''''''''

            If colExpiryDate.Index.Equals(e.ColumnIndex) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim expiryDate As Date = DateMayBeEnteredIn(Me.dgvImportedData.Rows(e.RowIndex).Cells, Me.colExpiryDate)

                Dim fSelectDateTime As New SyncSoft.SQL.Win.Forms.SelectDateTime(expiryDate, "Expiry Date", Today, AppData.MaximumDate,
                                                                 Me.dgvImportedData, Me.colExpiryDate, e.RowIndex)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.colExpiryDate.Index.Equals(e.ColumnIndex) AndAlso Me.dgvImportedData.Rows(e.RowIndex).IsNewRow Then

                    Me.dgvImportedData.Rows.Add()
                    fSelectDateTime.ShowDialog(Me)

                    Dim enteredDate As Date = DateMayBeEnteredIn(Me.dgvImportedData.Rows(e.RowIndex).Cells, Me.colExpiryDate)
                    If enteredDate = AppData.NullDateValue Then Me.dgvImportedData.Rows.RemoveAt(e.RowIndex)

                ElseIf Me.colExpiryDate.Index.Equals(e.ColumnIndex) Then

                    fSelectDateTime.ShowDialog(Me)

                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Function GetItems() As DataTable

        Dim oSetupData As New SetupData()
        Dim LocationID As String = StringValueEnteredIn(cboImportLocation, "Location!")
        Dim ItemCategory As String = StringValueEnteredIn(cboItemCategoryID, "Item Category!")




        Try

            Dim oConsumables As New ConsumableItems()
            Dim oDrug As New Drugs()
            Dim oOtherItems As New OtherItems()
            Dim inventoryItems As DataTable = New DataTable()

            If ItemCategory.Equals(oItemCateoryID.Drug) Then
                inventoryItems = oDrug.GetDrugs().Tables("Drugs")

            ElseIf ItemCategory.Equals(oItemCateoryID.Consumable)
                inventoryItems = oConsumables.GetConsumableItems().Tables("ConsumableItems")

            ElseIf ItemCategory.Equals(oItemCateoryID.NonMedical) Then
                inventoryItems = oOtherItems.GetOtherItems().Tables("OtherItems")

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return inventoryItems
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Sub cboImportLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboImportLocation.SelectedIndexChanged
        showSelectColumn()
        If chkIncludeAll.Checked Then
            LoadItems()
        Else
            ResetCTLS()
        End If
    End Sub

    Private Sub showSelectColumn()
        Dim locationID As String = StringValueMayBeEnteredIn(cboImportLocation)
        Dim itemCategoryID As String = StringValueMayBeEnteredIn(cboItemCategoryID)
        Dim importTypeID As String = StringValueMayBeEnteredIn(cbImportTypeID)
        colSelect.Visible = importTypeID.Equals(oImportType.OneByOne) AndAlso Not String.IsNullOrEmpty(locationID) AndAlso Not String.IsNullOrEmpty(itemCategoryID)
        chkIncludeAll.Visible = importTypeID.Equals(oImportType.OneByOne) AndAlso Not String.IsNullOrEmpty(locationID) AndAlso Not String.IsNullOrEmpty(itemCategoryID)
    End Sub

    Private Sub cboItemCategoryID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemCategoryID.SelectedIndexChanged
        showSelectColumn()
        Dim itemCategory As String = StringValueMayBeEnteredIn(cboItemCategoryID)

        If String.IsNullOrEmpty(itemCategory) Then Return
        

        If itemCategory.Equals(oItemCateoryID.Drug) Then
            Me.itemFullName = "DrugFullName"
            Me.itemCode = "DrugNo"
            Me.itemName = "DrugName"
        ElseIf itemCategory.Equals(oItemCateoryID.Consumable) Then
            Me.itemFullName = "ConsumableFullName"
            Me.itemCode = "ConsumableNo"
            Me.itemName = "ConsumableName"

        ElseIf itemCategory.Equals(oItemCateoryID.NonMedical) Then
            Me.itemFullName = "ItemFullName"
            Me.itemCode = "itemCode"
            Me.itemName = "itemName"

        End If

        If chkIncludeAll.Checked Then
            LoadItems()
        Else
            ResetCTLS()
        End If


    End Sub

    Private Sub chkApplyAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIncludeAll.CheckedChanged
        If chkIncludeAll.Checked Then
            LoadItems()
        Else
            ResetCTLS()
        End If
    End Sub

    Private Sub stbPSCNo_Leave(sender As Object, e As System.EventArgs) Handles stbPSCNo.Leave
        Me.SetPhysicalStockCount()
    End Sub



    Private Sub SetLatestStockTakeNo()
        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()
        Try
            Me.ClearControls()
           
            Dim dataSource As DataTable = oPhysicalStockCount.GetOpenPhysicalStockCount(Now).Tables("PhysicalStockCount")

            If dataSource.Rows.Count < 1 Then Return
            Dim row As DataRow = dataSource.Rows(0)
            Me.stbGeneralNotes.Text = StringEnteredIn(row, "GeneralNotes")
            Me.stbPSCNo.Text = FormatText(StringEnteredIn(row, "PSCNo"), "PhysicalStockCount", "PSCNo")
           
        Catch ex As Exception
            ErrorMessage(ex)
            Me.ClearControls()
        End Try
    End Sub


End Class