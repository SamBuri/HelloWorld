Option Strict On

Imports System.Text

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmDrfrequentlyprescribeddrugs
#Region " Fields "
    Private templateTypeID As String
#End Region


    Private Sub frmDrfrequentlyprescribeddrugs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frequentlyPrescribedDrugs.Values.Clear()
        LoadLookupDataCombo(Me.fcbCategoryNo, LookupObjects.Groups, False)
        Me.Showprescribeddrugstemplates()
    End Sub



    Private Sub Showprescribeddrugstemplates()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTemplates As New SyncSoft.SQLDb.Templates()

            ' Load from Items

            Dim prescribeddrugstemplates As DataTable = oTemplates.GetDrfrequentlyprescribeddrugs(CurrentUser.LoginID).Tables("Items")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If prescribeddrugstemplates Is Nothing OrElse prescribeddrugstemplates.Rows.Count < 1 Then
                DisplayMessage("No Drugs prescribed for " + (CurrentUser.LoginID))
            End If
            LoadGridData(Me.dgvfrequentlyPrescribedDrugs, prescribeddrugstemplates)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowCategorydrugstoprescribe()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTemplates As New SyncSoft.SQLDb.Drugs

            ' Load from drugs
            Dim drugCategory As String = StringValueEnteredIn(fcbCategoryNo)

            Dim prescribeddrugstemplates As DataTable = oTemplates.GetDrugsToPrescribebyCategory(drugCategory).Tables("Drugs")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
          
            LoadGridData(Me.dgvfrequentlyPrescribedDrugs, prescribeddrugstemplates)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
 

    Private Sub fcbCategoryNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles fcbCategoryNo.SelectedIndexChanged
        If Not String.IsNullOrEmpty(fcbCategoryNo.Text) Then
            Me.ShowCategorydrugstoprescribe()
        End If
    End Sub

    Private Sub fbnOK_Click(sender As System.Object, e As System.EventArgs) Handles fbnOK.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvfrequentlyPrescribedDrugs.Rows
                If CBool(Me.dgvfrequentlyPrescribedDrugs.Item(Me.colInclude.Name, row.Index).Value) = True Then

                    With frequentlyPrescribedDrugs.Values

                        frequentlyPrescribedDrugs.Values.Add(Me.dgvfrequentlyPrescribedDrugs.Item(Me.ColItemCode.Name, row.Index).Value.ToString(), Me.dgvfrequentlyPrescribedDrugs.Item(Me.colDrugName.Name, row.Index).Value.ToString())
                        
                    End With
                ElseIf CBool(Me.dgvfrequentlyPrescribedDrugs.Item(Me.colInclude.Name, row.Index).Value) = False Then

                End If
            Next



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
            Me.Close()
        End Try
    End Sub

    Private Sub dgvfrequentlyPrescribedDrugs_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvfrequentlyPrescribedDrugs.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor


            If CBool(Me.dgvfrequentlyPrescribedDrugs.Item(Me.colInclude.Name, dgvfrequentlyPrescribedDrugs.CurrentRow.Index).Value) = True Then

                Me.dgvfrequentlyPrescribedDrugs.Item(Me.colInclude.Name, dgvfrequentlyPrescribedDrugs.CurrentRow.Index).Value = False

            ElseIf CBool(Me.dgvfrequentlyPrescribedDrugs.Item(Me.colInclude.Name, dgvfrequentlyPrescribedDrugs.CurrentRow.Index).Value) = False Then

                Me.dgvfrequentlyPrescribedDrugs.Item(Me.colInclude.Name, dgvfrequentlyPrescribedDrugs.CurrentRow.Index).Value = True

            End If



        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    'Private Sub loadselecteddrugs()

    '    Dim DrugPair As KeyValuePair(Of String, String)
    '    For Each DrugPair In frequentlyPrescribedDrugs.Values

    '        With Me.dgvPrescription
    '            .Rows.Add()
    '            .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = DrugPair.Key
    '            .Item(Me.colDrug.Name, .NewRowIndex - 1).Value = DrugPair.Value
    '            Me.SetDrugsEntries(.NewRowIndex - 1, DrugPair.Key)
    '        End With
    '    Next
    'End Sub

   
End Class