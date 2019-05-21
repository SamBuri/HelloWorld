
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic

Public Class frmDrugCombinations

#Region " Fields "
    Private _DrugValue As String = String.Empty
#End Region

    Private Sub frmDrugCombinations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadARVs()
    End Sub

    Private Sub LoadARVs()

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs

            Dim drugs As DataTable = oDrugs.GetDrugs(String.Empty, True).Tables("Drugs")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colDrug, drugs, "DrugFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmDrugCombinations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbCombination_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oDrugCombinations As New SyncSoft.SQLDb.DrugCombinations()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oDrugCombinations.Combination = StringEnteredIn(Me.cboCombination, "Combination!")
            DisplayMessage(oDrugCombinations.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oDrugCombinations As New SyncSoft.SQLDb.DrugCombinations()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim combination As String = StringEnteredIn(Me.cboCombination, "Combination!")
            Dim dataSource As DataTable = oDrugCombinations.GetDrugCombinations(combination).Tables("DrugCombinations")
            Me.DisplayData(dataSource)

            Me.LoadDrugsInCombination(combination)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim oDrugCombinations As New SyncSoft.SQLDb.DrugCombinations()
            Dim lDrugCombinations As New List(Of DBConnect)

            With oDrugCombinations

                .Combination = StringEnteredIn(Me.cboCombination, "Combination!")
                .CombinationDes = StringEnteredIn(Me.stbCombinationDes, "Combination Description!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lDrugCombinations.Add(oDrugCombinations)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    transactions.Add(New TransactionList(Of DBConnect)(lDrugCombinations, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(DrugCombinationDetailsList, Action.Save))

                    records = DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lDrugCombinations, Action.Update, "DrugCombinations"))
                    transactions.Add(New TransactionList(Of DBConnect)(DrugCombinationDetailsList, Action.Save))

                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2
                Me.dgvDrugs.Item(Me.colSaved.Name, rowNo).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function DrugCombinationDetailsList() As List(Of DBConnect)

        Dim lDrugCombinationDetails As New List(Of DBConnect)

        Try

            Dim combination As String = StringEnteredIn(Me.cboCombination, "Combination!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDrugs.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one drug!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2

                Using oDrugCombinationDetails As New SyncSoft.SQLDb.DrugCombinationDetails()

                    Dim cells As DataGridViewCellCollection = Me.dgvDrugs.Rows(rowNo).Cells

                    With oDrugCombinationDetails

                        .Combination = combination
                        .DrugNo = SubstringRight(StringEnteredIn(cells, Me.colDrug, "drug!"))

                    End With

                    lDrugCombinationDetails.Add(oDrugCombinationDetails)

                End Using

            Next

            Return lDrugCombinationDetails

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#Region " Drugs - Grid "

    Private Sub dgvDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDrugs.CurrentCell.RowIndex
        _DrugValue = StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub dgvDrugs_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDrugs.CellEndEdit

        Try

            If Me.colDrug.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colDrug.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvDrugs.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvDrugs.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrug)

                    If CBool(Me.dgvDrugs.Item(Me.colSaved.Name, selectedRow).Value).Equals(True) Then

                        MessageBox.Show("Drug (" + _DrugValue + ") can't be edited!", AppData.AppTitle)
                        Me.dgvDrugs.Item(Me.colDrug.Name, selectedRow).Value = _DrugValue
                        Me.dgvDrugs.Item(Me.colDrug.Name, selectedRow).Selected = True

                        Return

                    End If

                    For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDrugs.Rows(rowNo).Cells, Me.colDrug)
                            If enteredItem.Equals(selectedItem) Then
                                MessageBox.Show("Drug (" + enteredItem + ") already selected!", AppData.AppTitle)
                                Me.dgvDrugs.Item(Me.colDrug.Name, selectedRow).Value = _DrugValue
                                Me.dgvDrugs.Item(Me.colDrug.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oDrugCombinationDetails As New SyncSoft.SQLDb.DrugCombinationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDrugs.Item(Me.colSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim combination As String = StringEnteredIn(Me.cboCombination, "Combination!")
            Dim drugNo As String = SubstringRight(CStr(Me.dgvDrugs.Item(Me.colDrug.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oDrugCombinationDetails
                .Combination = combination
                .DrugNo = drugNo
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DisplayMessage(oDrugCombinationDetails.Delete())
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

    Private Sub LoadDrugsInCombination(ByVal combination As String)

        Dim drugs As New DataTable()
        Dim oDrugCombinationDetails As New SyncSoft.SQLDb.DrugCombinationDetails()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.dgvDrugs.Rows.Clear()

            ' Load items not yet paid for

            drugs = oDrugCombinationDetails.GetDrugCombinationDetails(combination).Tables("DrugCombinationDetails")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDrugs, drugs)
            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDrugs.Item(Me.colSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        LoadCombinations()
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False

        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.btnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.btnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

    Private Sub cboCombination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCombination.SelectedIndexChanged

    End Sub

    Private Sub cboCombination_Leave(sender As Object, e As EventArgs) Handles cboCombination.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            stbCombinationDes.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboCombination)))
            cboCombination.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboCombination)))

        End If
    End Sub

    Private Sub LoadCombinations()

        Dim oDrugCombination As New SyncSoft.SQLDb.DrugCombinations()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim DrugCombination As DataTable = oDrugCombination.GetDrugCombinations.Tables("DrugCombinations")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCombination, DrugCombination, "CombinationFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            'ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region

End Class