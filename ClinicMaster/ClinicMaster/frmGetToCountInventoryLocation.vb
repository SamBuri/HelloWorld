Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic


Public Class frmGetToCountInventoryLocation



#Region " Fields "
    Private drugItemsTo As ItemsTo
    Private defaultItemCategoryID As String = String.Empty
    Private alertNoControl As Control = Nothing
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private LocationID As String = String.Empty
    Private ItemCategoryID As String = String.Empty
    Private HideOptions As Boolean = False

#End Region

    Private Sub frmGetToCountInventoryLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Select Case HideOptions
                Case True
                    Me.ColInclude.Visible = False
                    Me.lblMessage.Visible = False
                    Me.cmsItems.Enabled = False
                Case False
                    Me.ColInclude.Visible = True
                    Me.lblMessage.Visible = True
                    Me.cmsItems.Enabled = True

            End Select


            Select Case True

                Case Me.ItemCategoryID.Equals(oItemCategoryID.Drug) AndAlso Me.drugItemsTo.Equals(ItemsTo.Order)
                    Me.Text = "To Order Drug's list"
                    ' Me.fbnOrders.Visible = True
                    ' Me.fbnOrders.Enabled = True
                    Me.ShowToOrderItems(LocationID, ItemCategoryID)

                Case Me.ItemCategoryID.Equals(oItemCategoryID.Consumable) AndAlso Me.drugItemsTo.Equals(ItemsTo.Order)
                    Me.Text = "To Order Consumales's list"
                    ' Me.fbnOrders.Visible = True
                    ' Me.fbnOrders.Enabled = True
                    Me.ShowToOrderItems(LocationID, ItemCategoryID)


                Case Me.ItemCategoryID.Equals(oItemCategoryID.Drug) AndAlso Me.drugItemsTo.Equals(ItemsTo.Expire)
                    Me.Text = "To Expire/Expired Drug's list"
                    ' Me.fbnOrders.Visible = False
                    Me.ShowToExpireItems(LocationID, ItemCategoryID)

                Case Me.ItemCategoryID.Equals(oItemCategoryID.Consumable) AndAlso Me.drugItemsTo.Equals(ItemsTo.Expire)
                    Me.Text = "To Expire/Expired Consumales's list"
                    ' Me.fbnOrders.Visible = False
                    Me.ShowToExpireItems(LocationID, ItemCategoryID)


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ShowToOrderItems(ByVal LocationID As String, ByVal ItemCategoryID As String)


        Dim inventoryLocationItems As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            ' MessageBox.Show(LocationID.ToString() + " " + ItemCategoryID.ToString())

            Me.Cursor = Cursors.WaitCursor
            inventoryLocationItems = oDrugs.GetToCountToOrderInventoryLocation(LocationID, ItemCategoryID).Tables("Drugs")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvItems, inventoryLocationItems)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If inventoryLocationItems.Rows.Count > 0 Then
                ' Security.Apply(Me.fbnOrders, AccessRights.Write)
            Else 'Me.fbnOrders.Enabled = False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowToExpireItems(ByVal LocationID As String, ByVal ItemCategoryID As String)

        Dim inventoryItems As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            inventoryItems = oDrugs.GetToCountToExpireInventoryLocation(LocationID, ItemCategoryID, oVariousOptions.ExpiryWarningDays).Tables("Drugs")



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvItems, inventoryItems)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvItems.Rows
                If row.IsNewRow Then Exit For
                Dim expiryRemainingDays As Integer = IntegerMayBeEnteredIn(row.Cells, Me.colExpiryRemainingDays)
                If expiryRemainingDays < 0 Then Me.dgvItems.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           
            If e.RowIndex < 0 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With InventoryOrders.DrugNo
                'InventoryOrders.DrugNo.Add(Me.dgvItems.Item(Me.colItemCode.Name, e.RowIndex).Value.ToString())
                'InventoryOrders.DrugName.Add(Me.dgvItems.Item(Me.colItemName.Name, e.RowIndex).Value.ToString())
                InventoryOrders.Values.Add(Me.dgvItems.Item(Me.colItemCode.Name, e.RowIndex).Value.ToString(), Me.dgvItems.Item(Me.colItemName.Name, e.RowIndex).Value.ToString())
              

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '  Me.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

   

    Private Sub fbnExportTo_Click(sender As Object, e As EventArgs) Handles fbnExportTo.Click
        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim documentTitle As String = Me.Text + " as at " + FormatDateTime(Now)
            fStatus.Show("Exporting " + Me.Text + " to Excel...", FormStartPosition.CenterScreen)
            ExportToExcel(Me.dgvItems, Replace(Me.Text, "/", " or "), documentTitle)

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

       
    End Sub

   
   

    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click

    End Sub

   
 

    Private Sub dgvItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor


            If CBool(Me.dgvItems.Item(Me.ColInclude.Name, dgvItems.CurrentRow.Index).Value) = True Then

                Me.dgvItems.Item(Me.ColInclude.Name, dgvItems.CurrentRow.Index).Value = False

            ElseIf CBool(Me.dgvItems.Item(Me.ColInclude.Name, dgvItems.CurrentRow.Index).Value) = False Then

                Me.dgvItems.Item(Me.ColInclude.Name, dgvItems.CurrentRow.Index).Value = True

            End If

           

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnOk_Click(sender As Object, e As EventArgs) Handles fbnOk.Click

        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvItems.Rows
                If CBool(Me.dgvItems.Item(Me.ColInclude.Name, row.Index).Value) = True Then

                    With InventoryOrders.DrugNo

                        InventoryOrders.Values.Add(Me.dgvItems.Item(Me.colItemCode.Name, row.Index).Value.ToString(), Me.dgvItems.Item(Me.colItemName.Name, row.Index).Value.ToString())

                    End With
                ElseIf CBool(Me.dgvItems.Item(Me.ColInclude.Name, row.Index).Value) = False Then

                End If
            Next


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
            Me.Close()
        End Try

    End Sub

   
    
    
    
   
   
    Private Sub cmsItemsCopy_Click(sender As Object, e As EventArgs) Handles cmsItemsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvItems.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvItems))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsItemsSelectAll_Click(sender As Object, e As EventArgs) Handles cmsItemsSelectAll.Click
        Me.dgvItems.SelectAll()
    End Sub

    Private Sub cmsItemsIncludeAll_Click(sender As Object, e As EventArgs) Handles cmsItemsIncludeAll.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In dgvItems.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Me.ColInclude.ThreeState = True
                Me.dgvItems.Item(Me.ColInclude.Name, Row.Index).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '  Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cmsItemsIncludeNone_Click(sender As Object, e As EventArgs) Handles cmsItemsIncludeNone.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In dgvItems.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Me.ColInclude.ThreeState = False
                Me.dgvItems.Item(Me.ColInclude.Name, Row.Index).Value = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '  Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

 
End Class