
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

Public Class frmLabTestsEXTPossibleResults

#Region " Fields "
    Private labTests As DataTable
    Private labsubTests As DataTable
#End Region

Private Sub frmLabTestsEXTPossibleResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            Me.LoadLabTests()
            Me.LoadLabTests(True)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmLabTestsEXTPossibleResults_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

    Private Sub LoadLabTests()

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from LabTests

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            labTests = oLabTests.GetLabTestsWithSubTests().Tables("LabTests")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadLabTests(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboTestCode, labTests, "TestFullName")
            Else : Me.cboTestCode.Items.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLabSubTests()

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from LabTests
            Dim TestCode As String = StringEnteredIn(Me.cboTestCode, "Test Code!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            labsubTests = oLabTests.GetLabTestsSubTests(TestCode).Tables("LabTests")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvLabTestsEXT.Rows.Clear()

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLabSubTests(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.colsubtestCode, labsubTests, "TestFullName")
            Else : Me.colsubtestCode.Items.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvLabTestsEXT.Rows.Clear()

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboTestCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTestCode.Leave

        Try

            Dim testCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboTestCode)).ToUpper()
            Me.cboTestCode.Text = testCode.ToUpper()

            For Each row As DataRow In labTests.Select("TestCode = '" + testCode + "'")
                Me.stbTestName.Text = StringMayBeEnteredIn(row, "TestName")
            Next

            'If ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

            Me.dgvLabTestsEXT.Rows.Clear()
            Me.LoadLabSubTests()
            Me.LoadLabSubTests(True)
            'End If
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub Clearcontrols()
        ResetControlsIn(Me)
        ResetControlsIn(tpgPossibleLabResults)
    End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oLabTestsEXTPossibleResults As New SyncSoft.SQLDb.LabTestsEXTPossibleResults()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oLabTestsEXTPossibleResults.TestCode = StringEnteredIn(Me.cboTestCode, "TestCode!")
            'oLabTestsEXTPossibleResults.TestCodeEXT = StringEnteredIn(Me.stbTestCodeEXT, "TestCodeEXT!")
            'oLabTestsEXTPossibleResults.PossibleResults = StringEnteredIn(Me.stbPossibleResults, "PossibleResults!")

		DisplayMessage(oLabTestsEXTPossibleResults.Delete())
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

        Dim oLabTestsEXTPossibleResults As New SyncSoft.SQLDb.LabTestsEXTPossibleResults()

	Try
		Me.Cursor = Cursors.WaitCursor()

            Dim testCode As String = StringEnteredIn(Me.cboTestCode, "TestCode!")

            Dim dataSource As DataTable = oLabTestsEXTPossibleResults.GetLabTestsEXTPossibleResults(testCode).Tables("LabTestsEXTPossibleResults")

            Me.DisplayData(dataSource)

            Me.LoadlabTestsEXT(testCode)
	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub

    Private Function SaveLabEXT() As List(Of DBConnect)
        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim iLabTestsEXTPossibleResults As New List(Of DBConnect)

            For rowNo As Integer = 0 To Me.dgvLabTestsEXT.RowCount - 2

                Using oLabTestsEXTPossibleResults As New SyncSoft.SQLDb.LabTestsEXTPossibleResults()

                    Dim cells As DataGridViewCellCollection = Me.dgvLabTestsEXT.Rows(rowNo).Cells
                    Dim testCodeEXT As String = SubstringRight(StringEnteredIn(cells, Me.colsubtestCode))
                    Dim testResults As String = StringEnteredIn(cells, Me.colPossibleResults)


                    With oLabTestsEXTPossibleResults

                        .TestCode = StringEnteredIn(Me.cboTestCode, "TestCode!")
                        .SubTestCode = testCodeEXT
                        .PossibleResults = testResults
                        .LoginID = CurrentUser.LoginID

                    End With

                    iLabTestsEXTPossibleResults.Add(oLabTestsEXTPossibleResults)

                End Using
            Next

            Return iLabTestsEXTPossibleResults

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub LoadlabTestsEXT(ByVal testNo As String)

        Dim olabTestsEXT As New SyncSoft.SQLDb.LabTestsEXTPossibleResults()

        Try

            Me.dgvLabTestsEXT.Rows.Clear()

            ' Load from labTestsEXT

            Dim labTestsEXT As DataTable = olabTestsEXT.GetLabTestsEXTPossibleResults(testNo).Tables("LabTestsEXTPossibleResults")
            If labTestsEXT Is Nothing OrElse labTestsEXT.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabTestsEXT, labTestsEXT)

            For Each row As DataGridViewRow In Me.dgvLabTestsEXT.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabTestsEXT.Item(Me.colLabEXTSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    transactions.Add(New TransactionList(Of DBConnect)(SaveLabEXT, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.Clearcontrols()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(SaveLabEXT, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

#End Region

 
   
    Private Sub dgvLabTestsEXT_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTestsEXT.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabTestsEXTPossibleResults As New SyncSoft.SQLDb.LabTestsEXTPossibleResults
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTestsEXT.Item(Me.colLabEXTSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim testCode As String = RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))
            Dim results As String = Me.dgvLabTestsEXT.Item(Me.colPossibleResults.Name, toDeleteRowNo).Value.ToString()
            Dim subtestCode As String = SubstringRight(Me.dgvLabTestsEXT.Item(Me.colsubtestCode.Name, toDeleteRowNo).Value.ToString())

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
            With oLabTestsEXTPossibleResults
                .TestCode = testCode
                .SubTestCode = subtestCode
                .PossibleResults = results
            End With

            DisplayMessage(oLabTestsEXTPossibleResults.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
End Class