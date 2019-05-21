
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmImportInventoryEXT
#Region " Fields "
    Private alertNoControl As Control

#End Region

    Private Sub frmImportInventoryEXT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Me.ShowInventoryEXT(oItemCategoryID.Drug)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ShowInventoryEXT(ByVal ItemCategory As String)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from InventoryEXT
            Dim receiveBillables As DataTable = oDrugs.GetReceiveINTBillables(ItemCategory).Tables("INTBillables")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInventoryEXT, receiveBillables)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInventoryEXT_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryEXT.CellDoubleClick
        Try

            Dim itemcode As String = Me.dgvInventoryEXT.Item(Me.colItemCode.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = itemcode
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = itemcode
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = itemcode
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try
    End Sub
End Class