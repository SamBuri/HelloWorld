
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic

Public Class frmDiseases

#Region " Fields "
    Private _DrugNo As String = String.Empty
    Private _TestNameValue As String = String.Empty
    Private _TestNo As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
#End Region

    Private Sub frmDiseases_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboDiseaseCategoriesID, LookupObjects.DiseaseCategories, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbDiseaseCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oDiseases As New SyncSoft.SQLDb.Diseases()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oDiseases.DiseaseCode = StringEnteredIn(Me.cboDiseaseCode, "Disease Code!")
            DisplayMessage(oDiseases.Delete())
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

        Dim oDiseases As New SyncSoft.SQLDb.Diseases()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim diseaseCode As String = StringEnteredIn(Me.cboDiseaseCode, "Disease Code!")
            Dim dataSource As DataTable = oDiseases.GetDiseases(diseaseCode).Tables("Diseases")


            Me.DisplayData(dataSource)
            Me.LoadAttachedLabTests(diseaseCode)
            Me.LoadAttachedDrugs(diseaseCode)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function PossibleDrugs() As List(Of DBConnect)

        Dim iPossibleAttachedItems As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Using oiPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    With oiPossibleAttachedItems
                        .AttachedItemCode = SubstringLeft(RevertText(StringMayBeEnteredIn(cboDiseaseCode)))
                        .ItemCode = StringEnteredIn(cells, Me.colDrugNo)
                        .ItemCategoryID = oItemCategoryID.Drug
                        .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        .UnitCost = 0
                        .UnitPrice = 0
                        .Dosage = Nothing
                        .Duration = Nothing
                        .Notes = StringEnteredIn(cells, Me.colDrugNotes, "Drug Notes!")
                        .LoginID = CurrentUser.LoginID


                    End With

                    iPossibleAttachedItems.Add(oiPossibleAttachedItems)

                End Using

            Next
            Return iPossibleAttachedItems

        Catch ex As Exception
            Me.tbcPossibleAttachedItems.SelectTab(Me.tpgPrescription.Name)

            Throw ex

        End Try

    End Function

    Private Function PossibleTests() As List(Of DBConnect)

        Dim iPossibleTests As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Using oiPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems

                    Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                    With oiPossibleAttachedItems
                        .AttachedItemCode = SubstringLeft(RevertText(StringMayBeEnteredIn(cboDiseaseCode)))
                        .ItemCode = StringEnteredIn(cells, Me.ColTestNo)
                        .ItemCategoryID = oItemCategoryID.Test
                        .Dosage = Nothing
                        .Duration = Nothing
                        .UnitCost = 0
                        .UnitPrice = 0
                        .Quantity = IntegerEnteredIn(cells, Me.ColLabQuantity)
                        .Notes = StringEnteredIn(cells, Me.ColLabNotes, "Lab Notes!")
                        .LoginID = CurrentUser.LoginID


                    End With

                    iPossibleTests.Add(oiPossibleAttachedItems)

                End Using

            Next
            Return iPossibleTests

        Catch ex As Exception
            Me.tbcPossibleAttachedItems.SelectTab(Me.tpgPossibleLabTests.Name)

            Throw ex

        End Try

    End Function

    Private Sub LoadAttachedLabTests(ByVal diseaseCode As String)
        Dim oLabTestItem As New SyncSoft.SQLDb.PossibleAttachedItems
        Try
            Me.dgvLabTests.Rows.Clear()
            Dim labPossibleTests As DataTable = oLabTestItem.GetPossibleAttachedLabTests(diseaseCode).Tables("PossibleAttachedItems")
            If labPossibleTests Is Nothing OrElse labPossibleTests.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabTests, labPossibleTests)

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub LoadAttachedDrugs(ByVal diseaseCode As String)
        Dim oDrugItem As New SyncSoft.SQLDb.PossibleAttachedItems
        Try
            Me.dgvPrescription.Rows.Clear()
            Dim attachedPossibleDrugs As DataTable = oDrugItem.GetPossibleAttachedDrugItems(diseaseCode).Tables("PossibleAttachedItems")
            If attachedPossibleDrugs Is Nothing OrElse attachedPossibleDrugs.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPrescription, attachedPossibleDrugs)

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim oDiseases As New SyncSoft.SQLDb.Diseases()
        Dim lDiseases As New List(Of DBConnect)
        Try
            Me.Cursor = Cursors.WaitCursor()

            With oDiseases

                .DiseaseCode = StringEnteredIn(Me.cboDiseaseCode, "Disease Code!")
                .DiseaseName = StringEnteredIn(Me.stbDiseaseName, "Disease Name!")
                .DiseaseCategoriesID = StringValueEnteredIn(Me.cboDiseaseCategoriesID, "Disease Category!")
                .Hidden = Me.chkHidden.Checked

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lDiseases.Add(oDiseases)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oDiseases.Hidden.Equals(True) Then
                Dim message As String = "You have chosen to hide this Diseases and won’t be presented for selection. " +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    transactions.Add(New TransactionList(Of DBConnect)(lDiseases, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleDrugs, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleTests, Action.Save))
                    records = DoTransactions(transactions)
                      ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgPossibleLabTests)
                    ResetControlsIn(Me.tpgPrescription)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    transactions.Add(New TransactionList(Of DBConnect)(lDiseases, Action.Update))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleDrugs, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleTests, Action.Save))
                    records = DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgPossibleLabTests)
                    ResetControlsIn(Me.tpgPrescription)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

        ' LoadDisease()

        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.chkHidden.Enabled = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.chkHidden.Enabled = False

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


    Private Sub cboDiseaseCode_Leave(sender As Object, e As EventArgs) Handles cboDiseaseCode.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            stbDiseaseName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboDiseaseCode)))
            cboDiseaseCode.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboDiseaseCode)))

        End If
    End Sub

#End Region


    'Private Sub LoadDisease()

    '    Dim oDisease As New SyncSoft.SQLDb.Diseases()

    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        Dim disease As DataTable = oDisease.GetDiseases().Tables("Diseases")

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        LoadComboData(Me.cboDiseaseCode, disease, "DiseaseFullName")
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        ErrorMessage(ex)

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try

    'End Sub


#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))

            Me.SetDrugsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug No (" + Me._DrugNo + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrugNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Drug No (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Rows.RemoveAt(selectedRow)
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredDrug(selectedRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredDrug(ByVal selectedRow As Integer)
        Try

            Dim drugSelected As String = String.Empty
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()
            Dim drugNo As String = String.Empty

            If Me.dgvPrescription.Rows.Count > 1 Then drugNo = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))

            If String.IsNullOrEmpty(drugNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim drugName As String = StringEnteredIn(row, "DrugName", "Drug Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvPrescription
                .Item(Me.colDrugNo.Name, selectedRow).Value = drugNo.ToUpper()
                .Item(Me.colDrug.Name, selectedRow).Value = drugName

            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Sub dgvPrescription_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPrescription.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
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


    Private Sub dgvPrescription_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Drugs", "Drug No", "Drug", Me.GetDrugs(), "DrugFullName",
                                                                     "DrugNo", "DrugName", Me.dgvPrescription, Me.colDrugNo, e.RowIndex)

            Me._DrugNo = StringMayBeEnteredIn(Me.dgvPrescription.Rows(e.RowIndex).Cells, Me.colDrugNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColDrugselect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvPrescription.Rows(e.RowIndex).IsNewRow Then

                Me.dgvPrescription.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)
            ElseIf Me.ColDrugselect.Index.Equals(e.ColumnIndex) Then

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

    Private Sub dgvPrescription_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit
        Try
            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then

                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)


            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub dgvPrescription_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oDrugNo As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboDiseaseCode)))
            Dim drugNo As String = CStr(Me.dgvPrescription.Item(Me.colDrugNo.Name, toDeleteRowNo).Value)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oDrugNo
                .AttachedItemCode = itemCode
                .ItemCode = drugNo
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oDrugNo.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region


#Region " Laboratory - Grid "

    Private Sub dgvLabTests_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("LabTests", "Test Code", "Test", Me.GetLabTests(), "TestFullName",
                                                                     "TestCode", "TestName", Me.dgvLabTests, Me.ColTestNo, e.RowIndex)

            Me._TestNo = StringMayBeEnteredIn(Me.dgvLabTests.Rows(e.RowIndex).Cells, Me.ColTestNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColLabSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvLabTests.Rows(e.RowIndex).IsNewRow Then

                Me.dgvLabTests.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetLabTestEntries(e.RowIndex)
            ElseIf Me.ColLabSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetLabTestEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function GetLabTests() As DataTable

        Dim labTests As DataTable
        Dim oSetupData As New SetupData()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try

            ' Load from LabTests
            If Not InitOptions.LoadLabTestsAtStart Then
                labTests = oLabTests.GetLabTests().Tables("LabTests")
                oSetupData.LabTests = labTests
            Else : labTests = oSetupData.LabTests
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return labTests
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)
        End Try

    End Function

    Private Sub dgvLabTests_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabTests.CellBeginEdit
        If e.ColumnIndex <> Me.ColTestName.Index OrElse Me.dgvLabTests.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
        _TestNameValue = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColTestName)
    End Sub


    Private Sub dgvLabTests_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellEndEdit
        Try
            Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.ColTestNo.Index) Then

                If Me.dgvLabTests.Rows.Count > 1 Then Me.SetLabTestEntries(selectedRow)


            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub dgvLabTests_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub


    Private Sub SetLabTestEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColTestNo))
            Me.SetLabTestEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetLabTestEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Test No (" + Me._TestNo + ") can't be edited!")
                Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Value = Me._TestNo
                Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowNo).Cells, Me.ColTestNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Test No (" + enteredItem + ") already selected!")
                        Me.dgvLabTests.Rows.RemoveAt(selectedRow)
                        Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Value = Me._TestNo
                        Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredLabTest(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredLabTest(ByVal selectedRow As Integer)
        Try

            Dim oLabTests As New SyncSoft.SQLDb.LabTests
            Dim labTest As String = String.Empty

            If Me.dgvLabTests.Rows.Count > 1 Then labTest = SubstringRight(StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColTestNo))

            If String.IsNullOrEmpty(labTest) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim labTests As DataTable = oLabTests.GetLabTests(labTest).Tables("LabTests")
            If labTests Is Nothing OrElse String.IsNullOrEmpty(labTest) Then Return
            Dim row As DataRow = labTests.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim labTestName As String = StringEnteredIn(row, "TestName", "Test Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvLabTests
                .Item(Me.ColTestNo.Name, selectedRow).Value = labTest.ToUpper()
                .Item(Me.ColTestName.Name, selectedRow).Value = labTestName

            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Value = Me._TestNo.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Sub dgvLabTests_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTests.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabtests As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboDiseaseCode)))
            Dim testNo As String = CStr(Me.dgvLabTests.Item(Me.ColTestNo.Name, toDeleteRowNo).Value)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oLabtests
                .AttachedItemCode = itemCode
                .ItemCode = testNo
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oLabtests.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

End Class