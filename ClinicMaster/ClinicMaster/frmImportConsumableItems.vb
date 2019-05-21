
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

Public Class frmImportConsumableItems

#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
#End Region

  

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

            Dim path As String = StringEnteredIn(Me.stbFileName, "File Name!")
            Dim workSheetName As String = StringEnteredIn(Me.stbWorksheetName, "Work Sheet Name!")
            Dim range As String = ""
            Dim where As String = "where [Consumable No] is not null"

            Dim criterion As String = "select * from [" + workSheetName + "$" + range + "] " + where
            Dim importedData As DataTable = ImportFromExcel(path, criterion)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetCTLS()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To importedData.Rows.Count - 1

                Dim row As DataRow = importedData.Rows(pos)

                With Me.dgvImportedData

                    .Rows.Add()

                    .Item(Me.colID.Name, pos).Value = IntegerEnteredIn(row, "ID")
                    .Item(Me.colConsumableNo.Name, pos).Value = StringMayBeEnteredIn(row, "Consumable No")
                    .Item(Me.colConsumableName.Name, pos).Value = StringMayBeEnteredIn(row, "Consumable Name")
                    .Item(Me.colAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "Alternate Name")
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringMayBeEnteredIn(row, "Unit Measure")
                    .Item(Me.colOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "Order Level")
                    .Item(Me.colKeepingUnit.Name, pos).Value = IntegerMayBeEnteredIn(row, "Keeping Unit")
                    .Item(Me.colUnitCost.Name, pos).Value = DecimalMayBeEnteredIn(row, "Unit Cost")
                    .Item(Me.colUnitPrice.Name, pos).Value = DecimalMayBeEnteredIn(row, "Unit Price")
                    .Item(Me.colUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "Units In Stock")
                    .Item(Me.colLocation.Name, pos).Value = StringMayBeEnteredIn(row, "Location")
                    .Item(Me.colBatchNo.Name, pos).Value = StringMayBeEnteredIn(row, "Batch No")
                    .Item(Me.ColConsumableCategoryID.Name, pos).Value = StringMayBeEnteredIn(row, "Consumable Category")
                    If IsDBNull(importedData.Rows(pos).Item("Expiry Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Expiry Date")) Then
                        .Item(Me.colExpiryDate.Name, pos).Value = AppData.NullDateValue
                    Else : .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Expiry Date")))
                    End If

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for ConsumableI tems!"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvImportedData.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for Consumable Items!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 1

                Dim id As Integer

                Dim oBillModesID As New LookupDataID.BillModesID()
                Dim oStatusID As New LookupCommDataID.StatusID()
                Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
                Dim oStockTypeID As New LookupDataID.StockTypeID()
                Dim oEntryModeID As New LookupDataID.EntryModeID()
                Dim oConsumableCategoryID As New LookupDataID.ConditionOfUmblicalCordID()
                Dim lConsumableItems As New List(Of DBConnect)
                Dim lInventory As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Try

                    Me.Cursor = Cursors.WaitCursor

                    Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

                    id = CInt(Me.dgvImportedData.Item(Me.colID.Name, rowNo).Value)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim consumableNo As String = StringEnteredIn(cells, Me.colConsumableNo)
                    Dim consumableName As String = StringEnteredIn(cells, Me.colConsumableName, "Consumable Name!")
                    Dim unitMeasure As String = StringEnteredIn(cells, Me.colUnitMeasure, "Unit Measure!")
                    Dim consumableCategory As String = StringEnteredIn(cells, Me.ColConsumableCategoryID, "Consumable Category!")
                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colUnitsInStock)
                    Dim location As String = StringEnteredIn(cells, Me.colLocation, "Location!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

                        With oConsumableItems
                            .ConsumableNo = consumableNo
                            .ConsumableName = consumableName
                            .AlternateName = StringMayBeEnteredIn(cells, Me.colAlternateName)
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.UnitMeasure, unitMeasure)) Then
                                Throw New ArgumentException("Unit Measure has wrong value!")
                            Else : .UnitMeasureID = GetLookupDataID(LookupObjects.UnitMeasure, unitMeasure)
                            End If
                            .OrderLevel = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)
                            .KeepingUnit = IntegerMayBeEnteredIn(cells, Me.colKeepingUnit)
                            .UnitCost = DecimalMayBeEnteredIn(cells, Me.colUnitCost, False)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "Unit Price!")
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.ConsumableCategoryID, consumableCategory)) Then
                                Throw New ArgumentException("Consumable Category has wrong value!")
                            Else : .ConsumableCategoryID = GetLookupDataID(LookupObjects.ConsumableCategoryID, consumableCategory)
                            End If
                            .LastUpdate = Now()
                            .Halted = False
                            .Hidden = False
                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lConsumableItems.Add(oConsumableItems)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    Using oInventory As New SyncSoft.SQLDb.Inventory()

                        With oInventory

                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.Location, location)) Then
                                Throw New ArgumentException("Location has wrong value!")
                            Else : .LocationID = GetLookupDataID(LookupObjects.Location, location)
                            End If
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemCode = consumableNo
                            .TranDate = Today
                            .StockTypeID = oStockTypeID.Received
                            .Quantity = unitsInStock
                            .Details = "New Consumable (" + consumableName + ") Received"
                            .EntryModeID = oEntryModeID.Imported
                            .LoginID = CurrentUser.LoginID

                            If unitsInStock > 0 Then
                                .BatchNo = StringEnteredIn(cells, Me.colBatchNo, "Batch No!")
                                .ExpiryDate = DateEnteredIn(cells, Me.colExpiryDate, "Expiry Date!")
                            Else
                                .BatchNo = StringMayBeEnteredIn(cells, Me.colBatchNo)
                                .ExpiryDate = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                            End If

                        End With

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lInventory.Add(oInventory)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lConsumableItems, Action.Save))
                    If unitsInStock > 0 Then transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me._ErrorLog.Length > 0 Then
                Me.fbnErrorLog.Enabled = True
                Me.fbnExport.Visible = True
            Else
                Me.fbnErrorLog.Enabled = False
                Me.fbnExport.Visible = False
            End If

            Dim saveMSG As String = "{" + savedRows.Count.ToString() + "} Records saved successfully and {" +
                                    (Me.dgvImportedData.RowCount - savedRows.Count).ToString() + "} failed."
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

    Private Sub fbnErrorLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnErrorLog.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim importLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\Consumable Items Import Log.txt"

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

End Class