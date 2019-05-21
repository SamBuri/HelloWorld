Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects


Public Class frmSMSScheduling

    Private Sub frmSMSScheduling_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.colReason, LookupObjects.ReminderReason, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub dgvSMSReminders_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSMSReminders.CellClick


        If colDateandTime.Index.Equals(e.ColumnIndex) Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim expiryDate As Date = DateMayBeEnteredIn(Me.dgvSMSReminders.Rows(e.RowIndex).Cells, Me.colDateandTime)

            Dim fSelectDateTime As New SyncSoft.SQL.Win.Forms.SelectDateTime(expiryDate, "Schedule Date", Today, AppData.MaximumDate,
                                                             Me.dgvSMSReminders, Me.colDateandTime, e.RowIndex)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colDateandTime.Index.Equals(e.ColumnIndex) AndAlso Me.dgvSMSReminders.Rows(e.RowIndex).IsNewRow Then

                Me.dgvSMSReminders.Rows.Add()
                fSelectDateTime.ShowDialog(Me)

                Dim enteredDate As Date = DateMayBeEnteredIn(Me.dgvSMSReminders.Rows(e.RowIndex).Cells, Me.colDateandTime)
                If enteredDate = AppData.NullDateValue Then Me.dgvSMSReminders.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.colDateandTime.Index.Equals(e.ColumnIndex) Then

                fSelectDateTime.ShowDialog(Me)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If
    End Sub
End Class