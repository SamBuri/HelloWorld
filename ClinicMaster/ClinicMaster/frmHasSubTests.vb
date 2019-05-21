Option Strict On

Imports System.Text

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmHasSubTests

#Region " Fields "

    Private defaultTestCode As String = String.Empty
    Private _sourcegrid As DataGridView
    Private _sourcecolumn As DataGridViewColumn
    Private templateNoControl As DataGridViewColumn
    Private _RowIndex As Integer = -1
    Dim dataGridColumn As DataGridViewTextBoxColumn

    Private selectedRow As Integer
    Dim dataGridView As DataGridView
    Private alertNoControl As Control
#End Region

    Private Sub frmHasSubTests_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Cursor = Cursors.WaitCursor


            If Not String.IsNullOrEmpty(defaultTestCode) Then

                Me.ShowTemplates(defaultTestCode)
                Me.ProcessTabKey(True)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowTemplates(ByVal testCode As String)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTemplates As New SyncSoft.SQLDb.LabTestsEXT()

            ' Load from Templates

            Dim templates As DataTable = oTemplates.GetLabTestsEXTPossibleResults(testCode).Tables("LabTestsEXTPossibleResults")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If templates Is Nothing OrElse templates.Rows.Count < 1 Then
                DisplayMessage("No template registered for " + testCode)
            End If
            LoadGridData(Me.dgvTemplates, templates)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnOK_Click(sender As System.Object, e As System.EventArgs) Handles fbnOK.Click

        Try

            Dim splitChar As Char = ","c
            Dim template As New StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvTemplates.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTemplates.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvTemplates.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one template entry!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvTemplates.RowCount - 1
                If CBool(Me.dgvTemplates.Item(Me.colInclude.Name, rowNo).Value) = True Then
                    Dim cells As DataGridViewCellCollection = Me.dgvTemplates.Rows(rowNo).Cells
                    Dim notes As String = cells.Item(Me.colPossibleResults.Name).Value.ToString()
                    If Not String.IsNullOrEmpty(notes) Then template.Append(notes + splitChar + " ")
                End If
            Next

            If template.Length > 2 Then template.Remove(template.Length - 2, 2)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Me.dataGridView.Item(Me.dataGridColumn.Name, Me.selectedRow).Value = template.ToString
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub dgvTemplates_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemplates.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor


            If CBool(Me.dgvTemplates.Item(Me.colInclude.Name, dgvTemplates.CurrentRow.Index).Value) = True Then

                Me.dgvTemplates.Item(Me.colInclude.Name, dgvTemplates.CurrentRow.Index).Value = False

            ElseIf CBool(Me.dgvTemplates.Item(Me.colInclude.Name, dgvTemplates.CurrentRow.Index).Value) = False Then

                Me.dgvTemplates.Item(Me.colInclude.Name, dgvTemplates.CurrentRow.Index).Value = True

            End If



        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


 
End Class