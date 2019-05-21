Option Strict On

Imports System.Text

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmGetPatientPhoneNos
    Private templateNoControl As Control
   

    Private Sub ShowPhoneNos(ByVal startDate As Date, ByVal endDate As Date)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oPatients As New SyncSoft.SQLDb.Patients()

            ' Load from Patients

            Dim patients As DataTable = oPatients.GetPatientPhoneNos(startDate, endDate).Tables("Patients")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If patients Is Nothing OrElse patients.Rows.Count < 1 Then
                DisplayMessage("No " + Me.Text + "Patient number(s) found for the period between " _
                                    + FormatDate(startDate) + " and " + FormatDate(endDate) + "!")
            End If
            LoadGridData(Me.dgvPhoneNumbers, patients)

            Me.lblRecordsNo.Text = " Returned Patients(s): " + patients.Rows.Count.ToString
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In dgvPhoneNumbers.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Me.ColInclude.ThreeState = True
                Me.dgvPhoneNumbers.Item(Me.colInclude.Name, Row.Index).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '  Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPhoneNos(startDate, endDate)

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

            For Each row As DataGridViewRow In Me.dgvPhoneNumbers.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPhoneNumbers.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvPhoneNumbers.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one Contact!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPhoneNumbers.RowCount - 1
                If CBool(Me.dgvPhoneNumbers.Item(Me.colInclude.Name, rowNo).Value) = True Then
                    Dim cells As DataGridViewCellCollection = Me.dgvPhoneNumbers.Rows(rowNo).Cells
                    Dim phone As String = cells.Item(Me.colPhoneNumber.Name).Value.ToString()
                    If Not String.IsNullOrEmpty(phone) Then template.Append(phone + splitChar + " ")
                End If
            Next

            If template.Length > 2 Then template.Remove(template.Length - 2, 2)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If TypeOf Me.templateNoControl Is TextBox Then
                If String.IsNullOrEmpty(CType(Me.templateNoControl, TextBox).Text.Trim()) Then
                    CType(Me.templateNoControl, TextBox).Text = template.ToString()
                Else : CType(Me.templateNoControl, TextBox).Text += ControlChars.NewLine + template.ToString()
                End If
                CType(Me.templateNoControl, TextBox).Focus()

           End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub
End Class