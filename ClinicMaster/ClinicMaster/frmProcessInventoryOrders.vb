
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmProcessInventoryOrders

#Region " Fields "
    Private alertCheckPeriod As Integer
    Private alertsStartDateTime As Date = Now

#End Region

    Private Sub frmProcessInventoryOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmProcessInventoryOrders_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoadPendingInventoryOrders_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPendingInventoryOrders.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingInventoryOrderDetails As New frmPendingInventoryOrderDetails(Me.stbOrderNo)
            fPendingInventoryOrderDetails.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowInventoryOrders()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= alertCheckPeriod Then

                If Me.ShowUnProcessedInventoryOrders() > 0 Then If InitOptions.AlertSoundOn Then Beep()


            End If

        Catch eX As Exception
            ErrorMessage(eX)
            Return

        End Try

    End Sub

    Private Sub stbOrderNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbOrderNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbOrderNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbOrderNo.Leave

        Try

            Me.ShowInventoryOrders()

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbOrderDate.Clear()
        Me.stbFromLocation.Clear()
        Me.stbToLocation.Clear()

        Me.dgvInventoryOrderDetails.Rows.Clear()

    End Sub

    Private Sub ShowInventoryOrders()

        Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim orderNo As String = RevertText(StringMayBeEnteredIn(Me.stbOrderNo))
            If String.IsNullOrEmpty(orderNo) Then Return

            If oInventoryOrders.IsOrderTransferred(orderNo) Then Throw New ArgumentException("Order No: " + orderNo + ", is already transferred!")

            Dim inventoryOrders As DataTable = oInventoryOrders.GetInventoryOrders(orderNo).Tables("InventoryOrders")
            Dim row As DataRow = inventoryOrders.Rows(0)

            Me.stbOrderDate.Text = FormatDate(DateEnteredIn(row, "OrderDate"))
            Me.stbFromLocation.Text = StringEnteredIn(row, "FromLocation")
            Me.stbToLocation.Text = StringEnteredIn(row, "ToLocation")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadInventoryOrderDetails(orderNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInventoryOrderDetails(ByVal orderNo As String)

        Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()

        Try

            Me.ShowUnProcessedInventoryOrders()
            Me.dgvInventoryOrderDetails.Rows.Clear()

            ' Load InventoryOrderDetails

            Dim orderDetails As DataTable = oInventoryOrderDetails.GetInventoryOrderDetails(orderNo).Tables("InventoryOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then
                DisplayMessage("No pending inventory order waiting to be processed!")
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInventoryOrderDetails, orderDetails)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub fbnInventoryTransfers_Click(sender As System.Object, e As System.EventArgs) Handles fbnInventoryTransfers.Click

        Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim orderNo As String = RevertText(StringEnteredIn(Me.stbOrderNo, "Order No!"))
            If oInventoryOrders.IsOrderTransferred(orderNo) Then Throw New ArgumentException("Order No: " + orderNo + ", is already transferred!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fInventoryTransfers As New frmInventoryTransfers(orderNo)
            fInventoryTransfers.Save()
            fInventoryTransfers.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowInventoryOrders()

            Me.ShowUnProcessedInventoryOrders()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
#Region "Alerts"

    Private Function ShowUnProcessedInventoryOrders() As Integer

        Dim oVariousOptions As New VariousOptions()
        Dim InventoryAlertDays As Integer = oVariousOptions.InventoryAlertDays
        Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim pendingUnProcessedInventoryOrders As DataTable = oInventoryOrders.GetNotProcessedInventoryAcknowledgement(InventoryAlertDays).Tables("InventoryOrders")
            Dim recordsNo As Integer = pendingUnProcessedInventoryOrders.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblUnProcessedIventoryOrders.Text = "UnProcessed Iventory Orders: " + recordsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return 12 ' recordsNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

#End Region


    Private Sub frmProcessInventoryOrders_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.ShowUnProcessedInventoryOrders()
    End Sub
End Class