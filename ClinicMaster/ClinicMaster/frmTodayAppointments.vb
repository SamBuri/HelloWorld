
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Public Class frmTodayAppointments

#Region " Fields "
    Private _AlertNoControl As Control
    Private _OnlyCurrentUser As Boolean = False
#End Region

    Private Sub frmTodayAppointments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Today's Appointments"
            Me.lblMessage.Visible = Not _OnlyCurrentUser


            Me.ShowTodayAppointments()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowTodayAppointments()

        Dim oAppointments As New SyncSoft.SQLDb.Appointments()
        Dim appointments As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TodayAppointments
            If Me._OnlyCurrentUser Then
                appointments = oAppointments.GetTodayAppointments(CurrentUser.LoginID).Tables("Appointments")
            Else : appointments = oAppointments.GetTodayAppointments().Tables("Appointments")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTodayAppointments, appointments)

            For Each row As DataGridViewRow In Me.dgvTodayAppointments.Rows
                If row.IsNewRow Then Exit For
                Me.dgvTodayAppointments.Item(Me.ColInclude.Name, row.Index).Value = True
            Next

            Me.lblRecordsNo.Text = " Returned Record(s): " + appointments.Rows.Count.ToString()
            Me.fbnExport.Enabled = appointments.Rows.Count > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExport.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ExportToExcel(Me.dgvTodayAppointments, Me.Text)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTodayAppointments_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTodayAppointments.CellDoubleClick

        Try

            If Me._OnlyCurrentUser Then Return

            Dim patientNo As String = Me.dgvTodayAppointments.Item(Me.colPatientNo.Name, e.RowIndex).Value.ToString()

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

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvTodayAppointments.ColumnCount < 1 OrElse Me.dgvTodayAppointments.RowCount < 1 Then
            Me.cmsAlertListCopy.Enabled = False
            Me.cmsAlertListSelectAll.Enabled = False
        Else
            Me.cmsAlertListCopy.Enabled = True
            Me.cmsAlertListSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsAlertListCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListCopy.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvTodayAppointments.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvTodayAppointments))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvTodayAppointments.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTodayAppointments_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTodayAppointments.CellClick
        With Me.dgvTodayAppointments
            .Item(Me.ColInclude.Name, e.RowIndex).Value = Not CBool(.Item(Me.ColInclude.Name, e.RowIndex).Value)
        End With
    End Sub

    Private Sub btnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendSMS.Click

        Dim oVariousOptions As New VariousOptions()
        Dim message As String
        Dim productOwner As String = AppData.ProductOwner

        If oVariousOptions.SMSNotificationAtAppointments Then
            For Each row As DataGridViewRow In dgvTodayAppointments.Rows
                Dim phoneNo As String = StringMayBeEnteredIn(row.Cells, Me.colPhone)
                Dim fullname As String = StringMayBeEnteredIn(row.Cells, Me.colFullName)
                Dim status As String = StringMayBeEnteredIn(row.Cells, Me.colAppointmentPrecision)
                Dim patientNo As String = StringMayBeEnteredIn(row.Cells, Me.colPatientNo)
                Dim startDate As Date = DateMayBeEnteredIn(row.Cells, Me.colStartDate)
                Dim endDate As Date = DateMayBeEnteredIn(row.Cells, Me.colEndDate)
                If Not String.IsNullOrEmpty(phoneNo) AndAlso CBool(Me.dgvTodayAppointments.Item(Me.ColInclude.Name, row.Index).Value) = True Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    message = "Hi" + " " + fullname + " " + "you have an Appointment at" + " " + productOwner + " " + "On" + " " + startDate.ToShortDateString + " " + "- Via ClinicMaster"
                    SaveTextMessage(message, phoneNo, Now, oVariousOptions.SMSLifeSpanAppointments)

                End If


            Next row
        End If

    End Sub
End Class