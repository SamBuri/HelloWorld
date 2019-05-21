Option Strict On

Imports System.Text

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic

Public Class frmDoctorfrequentlyRequestedTest
#Region " Fields "
    Private templateTypeID As String
#End Region



    Private Sub frmDoctorfrequentlyRequestedTest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            frequentlyRequestedTests.Values.Clear()
            LoadLookupDataCombo(Me.fcbCategoryNo, LookupObjects.Labs, False)
            Me.ShowRequestedLabTesttemplates()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub ShowRequestedLabTesttemplates()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTemplates As New SyncSoft.SQLDb.Templates()

            ' Load from Items

            Dim RequestedLabTesttemplates As DataTable = oTemplates.GetDrfrequentlyRequestedTest(CurrentUser.LoginID).Tables("Items")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If RequestedLabTesttemplates Is Nothing OrElse RequestedLabTesttemplates.Rows.Count < 1 Then
                DisplayMessage("No Lab Tests requested by " + (CurrentUser.LoginID))
            End If
            LoadGridData(Me.dgvFrequentlyRequestedTest, RequestedLabTesttemplates)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowLabTestToRequests()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oLabTests As New SyncSoft.SQLDb.LabTests()

            ' Load from drugs
            Dim labs As String = StringValueEnteredIn(fcbCategoryNo)

            Dim RequestedLabTest As DataTable = oLabTests.GetLabTestsbyLabType(labs).Tables("LabTests")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadGridData(Me.dgvFrequentlyRequestedTest, RequestedLabTest)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub fcbCategoryNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles fcbCategoryNo.SelectedIndexChanged
        If Not String.IsNullOrEmpty(fcbCategoryNo.Text) Then
            Me.ShowLabTestToRequests()
        End If
    End Sub

    Private Sub fbnOK_Click(sender As System.Object, e As System.EventArgs) Handles fbnOK.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvFrequentlyRequestedTest.Rows
                If CBool(Me.dgvFrequentlyRequestedTest.Item(Me.colInclude.Name, row.Index).Value) = True Then

                    With frequentlyRequestedTests.Values

                        frequentlyRequestedTests.Values.Add(Me.dgvFrequentlyRequestedTest.Item(Me.ColItemCode.Name, row.Index).Value.ToString(), Me.dgvFrequentlyRequestedTest.Item(Me.colTestName.Name, row.Index).Value.ToString())

                    End With
                ElseIf CBool(Me.dgvFrequentlyRequestedTest.Item(Me.colInclude.Name, row.Index).Value) = False Then

                End If
            Next

          
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
            Me.Close()
        End Try
    End Sub


#Region "GridView information"

    Private Sub dgvFrequentlyRequestedTest_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFrequentlyRequestedTest.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor


            If CBool(Me.dgvFrequentlyRequestedTest.Item(Me.colInclude.Name, dgvFrequentlyRequestedTest.CurrentRow.Index).Value) = True Then

                Me.dgvFrequentlyRequestedTest.Item(Me.colInclude.Name, dgvFrequentlyRequestedTest.CurrentRow.Index).Value = False

            ElseIf CBool(Me.dgvFrequentlyRequestedTest.Item(Me.colInclude.Name, dgvFrequentlyRequestedTest.CurrentRow.Index).Value) = False Then

                Me.dgvFrequentlyRequestedTest.Item(Me.colInclude.Name, dgvFrequentlyRequestedTest.CurrentRow.Index).Value = True

            End If



        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region




End Class