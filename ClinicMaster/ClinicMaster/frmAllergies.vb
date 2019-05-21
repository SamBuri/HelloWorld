
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Public Class frmAllergies

#Region " Fields "
    Private drugs As DataTable
    Private _DrugNameValue As String = String.Empty
#End Region

    Private Sub frmAllergies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboAllergyCategoryID, LookupObjects.AllergyCategory, False)
            Me.LoadDrugs()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmAllergies_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbAllergyNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub LoadDrugs()

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs
            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDrugNo.Sorted = False
            LoadComboData(Me.colDrugNo, drugs, "DrugNo", "DrugName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oAllergies As New SyncSoft.SQLDb.Allergies()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oAllergies.AllergyNo = StringEnteredIn(Me.cboAllergyNo, "Allergy No!")
            DisplayMessage(oAllergies.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oAllergies As New SyncSoft.SQLDb.Allergies()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim allergyNo As String = StringEnteredIn(Me.cboAllergyNo, "Allergy No!")
            Dim dataSource As DataTable = oAllergies.GetAllergies(allergyNo).Tables("Allergies")
            Me.DisplayData(dataSource)
            Me.LoadAllergyDrugs(allergyNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oAllergies As New SyncSoft.SQLDb.Allergies()
            Dim lAllergies As New List(Of DBConnect)

            With oAllergies

                .AllergyNo = StringEnteredIn(Me.cboAllergyNo, "Allergy No!")
                .AllergyName = StringEnteredIn(Me.stbAllergyName, "Allergy Name!")
                .AllergyCategoryID = StringValueEnteredIn(Me.cboAllergyCategoryID, "Allergy Category!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lAllergies.Add(oAllergies)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lAllergies, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(AllergyDrugsList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lAllergies, Action.Update, "Allergies"))
                    transactions.Add(New TransactionList(Of DBConnect)(AllergyDrugsList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function AllergyDrugsList() As List(Of DBConnect)

        Dim lAllergyDrugs As New List(Of DBConnect)

        Try

            Dim allergyNo As String = RevertText(StringEnteredIn(Me.cboAllergyNo, "Allergy No!"))

            For rowNo As Integer = 0 To Me.dgvAllergyDrugs.RowCount - 2

                Using oAllergyDrugs As New SyncSoft.SQLDb.AllergyDrugs()

                    Dim cells As DataGridViewCellCollection = Me.dgvAllergyDrugs.Rows(rowNo).Cells

                    With oAllergyDrugs

                        .AllergyNo = allergyNo
                        .DrugNo = StringEnteredIn(cells, Me.colDrugNo, "Drug No!")

                    End With

                    lAllergyDrugs.Add(oAllergyDrugs)

                End Using

            Next

            Return lAllergyDrugs

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#Region " Drugs - Grid "

    Private Sub dgvAllergyDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAllergyDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colDrugNo.Index OrElse Me.dgvAllergyDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvAllergyDrugs.CurrentCell.RowIndex
        _DrugNameValue = StringMayBeEnteredIn(Me.dgvAllergyDrugs.Rows(selectedRow).Cells, Me.colDrugNo)

    End Sub

    Private Sub dgvAllergyDrugs_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllergyDrugs.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvAllergyDrugs.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvAllergyDrugs.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvAllergyDrugs.Rows(selectedRow).Cells, Me.colDrugNo)

                    If CBool(Me.dgvAllergyDrugs.Item(Me.colAllergyDrugsSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Drugs As EnumerableRowCollection(Of DataRow) = drugs.AsEnumerable()
                        Dim drugDisplay As String = (From data In _Drugs
                                            Where data.Field(Of String)("DrugNo").ToUpper().Equals(_DrugNameValue.ToUpper())
                                            Select data.Field(Of String)("DrugName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Drug (" + drugDisplay + ") can't be edited!")
                        Me.dgvAllergyDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = _DrugNameValue
                        Me.dgvAllergyDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvAllergyDrugs.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvAllergyDrugs.Rows(rowNo).Cells, Me.colDrugNo)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Drugs As EnumerableRowCollection(Of DataRow) = drugs.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Drugs
                                                    Where data.Field(Of String)("DrugNo").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("DrugName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Drug (" + enteredDisplay + ") already entered!")
                                Me.dgvAllergyDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = _DrugNameValue
                                Me.dgvAllergyDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvAllergyDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvAllergyDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oAllergyDrugs As New SyncSoft.SQLDb.AllergyDrugs()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvAllergyDrugs.Item(Me.colAllergyDrugsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim allergyNo As String = RevertText(StringEnteredIn(Me.cboAllergyNo, "Allergy No!"))
            Dim drugNo As String = Me.dgvAllergyDrugs.Item(Me.colDrugNo.Name, toDeleteRowNo).Value.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oAllergyDrugs
                .AllergyNo = allergyNo
                .DrugNo = drugNo
            End With

            DisplayMessage(oAllergyDrugs.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvAllergyDrugs_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvAllergyDrugs.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadAllergyDrugs(ByVal allergyNo As String)

        Dim oAllergyDrugs As New SyncSoft.SQLDb.AllergyDrugs()

        Try

            Me.dgvAllergyDrugs.Rows.Clear()

            ' Load from AllergyDrugs

            Dim allergyDrugs As DataTable = oAllergyDrugs.GetAllergyDrugs(allergyNo).Tables("AllergyDrugs")
            If allergyDrugs Is Nothing OrElse allergyDrugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAllergyDrugs, allergyDrugs)

            For Each row As DataGridViewRow In Me.dgvAllergyDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvAllergyDrugs.Item(Me.colAllergyDrugsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        LoadAllergies()
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

#End Region

    Private Sub LoadAllergies()

        Dim oAllergies As New SyncSoft.SQLDb.Allergies

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim Allegies As DataTable = oAllergies.GetAllergies().Tables("Allergies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboAllergyNo, Allegies, "AllergyFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboAllergyNo_Leave(sender As Object, e As EventArgs) Handles cboAllergyNo.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            stbAllergyName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboAllergyNo)))
            cboAllergyNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboAllergyNo)))

        End If
    End Sub
End Class