Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Public Class frmBirthdays
#Region "Fields"
    Private _PatientNo As Boolean = False
#End Region


    Private Sub frmBirthdays_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.showbirthdays()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub showbirthdays()
        Dim oPatients As New SyncSoft.SQLDb.Patients
        Dim oVariousOptions As New VariousOptions()
        Dim patients As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from patients
            patients = oPatients.GetPatientBirthdays().Tables("Patients")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBirthdays, patients)
          
            For Each row As DataGridViewRow In Me.dgvBirthdays.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBirthdays.Item(Me.ColInclude.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    
End Class