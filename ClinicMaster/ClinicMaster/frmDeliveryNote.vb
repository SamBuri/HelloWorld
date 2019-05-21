
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic
Imports SyncSoft.SQLDb
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.Common.SQL.Enumerations

Public Class frmDeliveryNote
    Private oVariousOptions As New VariousOptions()
#Region " Fields "
    Private oPackID As New LookupDataID.PackID()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private fromLocation As String
    Private toLocation As String
#End Region

    Private Sub frmDeliveryNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            HideInventoryPacks()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub HideInventoryPacks()
        Dim packControl As DataGridViewColumn() = {colPack, colPackSize, colTotalUnits}
        HideGridComponets(packControl, oVariousOptions.UseOfInventoryPackSizes)

    End Sub

    Private Sub frmDeliveryNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click



        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click



    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click


        Dim lDeliveryNote As New List(Of DBConnect)
        Dim lDeliveryNoteDetails As New List(Of DBConnect)
        Dim lInventoryIssued As New List(Of DBConnect)


        Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim oStockTypeID As New LookupDataID.StockTypeID()
            Dim oEntryModeID As New LookupDataID.EntryModeID()
            Me.Cursor = Cursors.WaitCursor

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim deliverDate As Date = DateEnteredIn(dtpDeliveryDate, "Delivery Date!")
            For rowNo As Integer = 0 To Me.dgvDeliveryNote.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvDeliveryNote.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                Dim itemCategory As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Category!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "Quantity!")
                Dim batchNo As String = StringEnteredIn(cells, Me.colBatchNo, "Batch No!")
                Dim expiryDate As Date = DateEnteredIn(cells, Me.colExpiryDate, "Expiry Date!")
                Dim packID As String = GetLookupDataID(LookupObjects.Packs, StringEnteredIn(cells, Me.colPack, "Pack!"))
                Dim packSize As Integer = IntegerEnteredIn(cells, Me.colPackSize, "Pack Size!")
                Dim totalUnits As Integer = IntegerEnteredIn(cells, Me.colTotalUnits, "Total Units!")
                Dim unitCost As Decimal = DecimalEnteredIn(cells, Me.colUnitCost, False, "UnitCost!")



                If String.IsNullOrEmpty(packID) Then
                    packID = oPackID.NA
                End If

                Using oDeliveryNoteDetails As New SyncSoft.SQLDb.DeliveryNoteDetails()
                    With oDeliveryNoteDetails
                        .TransferNo = StringEnteredIn(Me.stbTransferNo, "Transfer No!")
                        .DeliveryDate = deliverDate
                        .ItemCategoryID = itemCategory
                        .ItemCode = itemCode
                        .PackID = packID
                        .PackSize = packSize
                        .UnitCost = unitCost
                        .Quantity = quantity
                        .LoginID = CurrentUser.LoginID
                        .RecordDateTime = Now()
                    End With
                    lDeliveryNoteDetails.Add(oDeliveryNoteDetails)
                End Using


                ''''''''''''''''Issued'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oInventoryIssued As New SyncSoft.SQLDb.Inventory()

                    With oInventoryIssued

                        .LocationID = fromLocation
                        .ItemCategoryID = itemCategory
                        .ItemCode = itemCode
                        .TranDate = Today()
                        .StockTypeID = oStockTypeID.Issued
                        .Quantity = totalUnits

                        If itemCategory.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then
                            .Details = "Drug(s) Issued to " + toLocation + " from " + fromLocation
                        ElseIf itemCategory.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then
                            .Details = "Consumable(s) Issued to " + toLocation + " from " + fromLocation
                        Else : .Details = String.Empty
                        End If

                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        .BatchNo = batchNo
                        .ExpiryDate = expiryDate

                    End With

                    lInventoryIssued.Add(oInventoryIssued)

                End Using



                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            Next

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDeliveryNoteDetails, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryIssued, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDeliveryNoteDetails, Action.Update))
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryIssued, Action.Update))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)

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
        End If
    End Sub



    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fIssuedInventoryTransferDetails As New frmIssuedInventoryTransferDetails(Me.stbTransferNo, AlertItemCategory.External)
            fIssuedInventoryTransferDetails.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowInventoryTransfers()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub ShowInventoryTransfers()

        Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()

        Try
            Me.Cursor = Cursors.WaitCursor



            Dim transferNo As String = RevertText(StringMayBeEnteredIn(Me.stbTransferNo))
            If String.IsNullOrEmpty(transferNo) Then Return

            Dim inventoryTransfers As DataTable = oInventoryTransfers.GetInventoryTransfers(transferNo).Tables("InventoryTransfers")
            Dim row As DataRow = inventoryTransfers.Rows(0)

            Dim transferDate As Date = DateEnteredIn(row, "TransferDate")

            Me.stbDeliveryLocation.Text = StringEnteredIn(row, "ToLocation")
            Me.fromLocation = StringEnteredIn(row, "FromLocationID")
            Me.toLocation = StringEnteredIn(row, "ToLocationID")

            stbTransferNo.Text = StringEnteredIn(row, "TransferNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadInventoryTransferDetails(transferNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInventoryTransferDetails(ByVal transferNo As String)

        Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()

        Try

            Me.dgvDeliveryNote.Rows.Clear()

            ' Load InventoryTransferDetails

            Dim transferDetails As DataTable = oInventoryTransferDetails.GetInventoryTransferDetails(transferNo).Tables("InventoryTransferDetails")
            If transferDetails Is Nothing OrElse transferDetails.Rows.Count < 1 Then
                DisplayMessage("No issued inventory stock waiting to be received!")
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDeliveryNote, transferDetails)

            For Each row As DataGridViewRow In Me.dgvDeliveryNote.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDeliveryNote.Item(Me.colInclude.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub ClearControls()

        Me.stbDeliveryLocation.Clear()
        Me.stbTransferNo.Clear()
        Me.dgvDeliveryNote.Rows.Clear()

    End Sub


    Private Sub stbTransferNo_Leave(sender As Object, e As EventArgs) Handles stbTransferNo.Leave
        ShowInventoryTransfers()
    End Sub

#End Region

End Class