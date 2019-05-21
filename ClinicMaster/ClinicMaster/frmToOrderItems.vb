
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Collections.Generic

Public Class frmToOrderItems

#Region " Fields "
    Private drugItemsTo As ItemsTo
    Private defaultItemCategoryID As String = String.Empty
    Private alertNoControl As Control = Nothing
    Private inlcudeState As Boolean
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
#End Region

    Private Sub frmToOrderItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            
            Me.Cursor = Cursors.WaitCursor()

            Select Case True

                Case Me.drugItemsTo.Equals(ItemsTo.Order) AndAlso
                    defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper())
                    Me.Text = "To Order Drug's list"
                    Me.fbnOrders.Visible = True
                    Me.ShowToOrderItems()

                Case Me.drugItemsTo.Equals(ItemsTo.Order) AndAlso
                    defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper())
                    Me.Text = "To Order Consumable's list"
                    Me.fbnOrders.Visible = True
                    Me.ShowToOrderItems()

                Case Me.drugItemsTo.Equals(ItemsTo.Expire) AndAlso
                    defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper())
                    Me.Text = "To Expire/Expired Drug's list"
                    Me.fbnOrders.Visible = False
                    Me.ShowToExpireItems()

                Case Me.drugItemsTo.Equals(ItemsTo.Expire) AndAlso
                    defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper())
                    Me.Text = "To Expire/Expired Consumable's list"
                    Me.fbnOrders.Visible = False
                    Me.ShowToExpireItems()

                Case Else
                    Me.Text = "To Order Drug's list"
                    Me.fbnOrders.Visible = True
                    Me.ShowToOrderItems()

            End Select
            If (inlcudeState = False) Then
                Me.colInclude.Visible = False
                IncludeNoneToolStripMenuItem.Enabled = False
                IncludeAllToolStripMenuItem.Enabled = False
                fbnOk.Visible = False
                fbnOrders.Visible = True

            ElseIf (inlcudeState = True) Then
                Me.colInclude.Visible = True
                IncludeNoneToolStripMenuItem.Enabled = True
                IncludeAllToolStripMenuItem.Enabled = True
                fbnOk.Visible = True
                fbnOrders.Visible = False
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowToOrderItems()

        Dim inventoryItems As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then
                inventoryItems = oDrugs.GetToOrderDrugs().Tables("Drugs")

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then
                inventoryItems = oConsumableItems.GetToOrderConsumableItems().Tables("ConsumableItems")

            Else : inventoryItems = oDrugs.GetToOrderDrugs().Tables("Drugs")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvItems, inventoryItems)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If inventoryItems.Rows.Count > 0 Then
                Security.Apply(Me.fbnOrders, AccessRights.Write)
            Else : Me.fbnOrders.Enabled = False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowToExpireItems()

        Dim inventoryItems As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then
                inventoryItems = oDrugs.GetToExpireDrugs(oVariousOptions.ExpiryWarningDays).Tables("Drugs")

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then
                inventoryItems = oConsumableItems.GetToExpireConsumableItems(oVariousOptions.ExpiryWarningDays).Tables("ConsumableItems")

            Else : inventoryItems = oDrugs.GetToExpireDrugs(oVariousOptions.ExpiryWarningDays).Tables("Drugs")
            End If

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

    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

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

    Private Sub fbnOrders_Click(sender As System.Object, e As System.EventArgs) Handles fbnOrders.Click

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim itemsList As New List(Of String)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvItems.Rows
                If row.IsNewRow Then Continue For
                itemsList.Add(StringEnteredIn(row.Cells, Me.colItemCode))
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fInventoryOrders As New frmInventoryOrders(defaultItemCategoryID, itemsList)
            fInventoryOrders.Save()
            fInventoryOrders.ShowDialog()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItems.CellDoubleClick

        Try

            Dim itemCode As String = Me.dgvItems.Item(Me.colItemCode.Name, e.RowIndex).Value.ToString()

            If Me.alertNoControl IsNot Nothing Then

                If TypeOf Me.alertNoControl Is TextBox Then
                    CType(Me.alertNoControl, TextBox).Text = itemCode
                    CType(Me.alertNoControl, TextBox).Focus()

                ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                    CType(Me.alertNoControl, SmartTextBox).Text = itemCode
                    CType(Me.alertNoControl, SmartTextBox).Focus()

                ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                    CType(Me.alertNoControl, ComboBox).Text = itemCode
                    CType(Me.alertNoControl, ComboBox).Focus()
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                Try
                    Me.Cursor = Cursors.WaitCursor

                    Dim fInventory As New frmInventory(defaultItemCategoryID, itemCode)
                    fInventory.ShowDialog()

                Catch ex As Exception
                    ErrorMessage(ex)

                Finally
                    Me.Cursor = Cursors.Default

                End Try
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvItems.ColumnCount < 1 OrElse Me.dgvItems.RowCount < 1 Then
            Me.cmsAlertListCopy.Enabled = False
            Me.cmsAlertListSelectAll.Enabled = False
            Me.cmsAlertListInventory.Enabled = False
        Else
            Me.cmsAlertListCopy.Enabled = True
            Me.cmsAlertListSelectAll.Enabled = True
            Me.cmsAlertListInventory.Enabled = True
            Security.Apply(Me.cmsAlertList, AccessRights.Write)
        End If

    End Sub

    Private Sub cmsAlertListCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListCopy.Click

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

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvItems.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListInventory.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim rowIndex As Integer = Me.dgvItems.CurrentCell.RowIndex
            Dim itemCode As String = StringMayBeEnteredIn(Me.dgvItems.Rows(rowIndex).Cells, Me.colItemCode)
            Dim fInventory As New frmInventory(defaultItemCategoryID, itemCode)
            fInventory.ShowDialog()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub IncludeAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncludeAllToolStripMenuItem.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In dgvItems.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Me.ColInclude.ThreeState = True
                Me.dgvItems.Item(Me.colInclude.Name, Row.Index).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '  Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub IncludeNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncludeNoneToolStripMenuItem.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In dgvItems.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Me.ColInclude.ThreeState = False
                Me.dgvItems.Item(Me.colInclude.Name, Row.Index).Value = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '  Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub fbnOk_Click(sender As Object, e As EventArgs) Handles fbnOk.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvItems.Rows
                If CBool(Me.dgvItems.Item(Me.colInclude.Name, row.Index).Value) = True Then

                    With PurchaseOrders.Values

                        PurchaseOrders.Values.Add(Me.dgvItems.Item(Me.colItemCode.Name, row.Index).Value.ToString(), Me.dgvItems.Item(Me.colItemName.Name, row.Index).Value.ToString())

                    End With
                ElseIf CBool(Me.dgvItems.Item(Me.colInclude.Name, row.Index).Value) = False Then

                End If
            Next


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
            Me.Close()
        End Try
    End Sub

    Private Sub dgvItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor


            If CBool(Me.dgvItems.Item(Me.colInclude.Name, dgvItems.CurrentRow.Index).Value) = True Then

                Me.dgvItems.Item(Me.colInclude.Name, dgvItems.CurrentRow.Index).Value = False

            ElseIf CBool(Me.dgvItems.Item(Me.colInclude.Name, dgvItems.CurrentRow.Index).Value) = False Then

                Me.dgvItems.Item(Me.colInclude.Name, dgvItems.CurrentRow.Index).Value = True

            End If



        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class