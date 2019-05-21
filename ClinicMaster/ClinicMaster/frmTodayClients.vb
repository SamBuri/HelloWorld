Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID


Public Class frmTodayClients

#Region " Fields "
    Private _AlertNoControl As Control
    Private _OnlyCurrentUser As Boolean = False
#End Region

    Private Sub frmTodayClients_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Todays Clients"

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPeriodicVisits(Today.AddDays(-1), Today)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub


    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPeriodicVisits(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPeriodicVisits(ByVal startDate As Date, ByVal endDate As Date)

        Dim oClients As New SyncSoft.SQLDb.Clients()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Clients
            Dim clients As DataTable = oClients.GetClientsByDate(startDate, endDate).Tables("Clients")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTodayClients, clients)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " _
                                    + FormatDate(startDate) + " and " + FormatDate(endDate) + "!"

            If clients.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + clients.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub dgvTodayClients_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTodayClients.CellContentClick
        Try

            If Me._OnlyCurrentUser Then Return

            Dim patientNo As String = Me.dgvTodayClients.Item(Me.colReferenceNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me._AlertNoControl Is TextBox Then
                CType(Me._AlertNoControl, TextBox).Text = patientNo
                CType(Me._AlertNoControl, TextBox).Focus()

            ElseIf TypeOf Me._AlertNoControl Is SmartTextBox Then
                CType(Me._AlertNoControl, SmartTextBox).Text = patientNo
                CType(Me._AlertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me._AlertNoControl Is ComboBox Then
                CType(Me._AlertNoControl, ComboBox).Text = patientNo
                CType(Me._AlertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try
    End Sub
End Class