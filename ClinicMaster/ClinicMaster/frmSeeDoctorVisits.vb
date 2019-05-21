
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmSeeDoctorVisits

#Region " Fields "
    Private alertNoControl As Control
    Private visitStatusID As New LookupDataID.VisitStatusID()
    Private visitNo As String
    Private tokenNo As String
    Private patientNo As String
    Private firstName As String
#End Region

    Private Sub frmSeeDoctorVisits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Doctor visits"

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnCall.Visible = IsQueueEnabled()
            Me.colTokenNo.Visible = IsQueueEnabled()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSeeDoctorVisits(visitStatusID.Doctor, Today.AddDays(-1), Today)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub rdoGetPeriodSeeDoctor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetPeriodSeeDoctor.CheckedChanged
        If Me.rdoGetPeriodSeeDoctor.Checked Then EnablePeriodCTLS(True)
    End Sub

    Private Sub rdoGetPeriodCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetPeriodCompleted.CheckedChanged
        If Me.rdoGetPeriodCompleted.Checked Then EnablePeriodCTLS(True)
    End Sub

    Private Sub rdoGetAllSeeDoctor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetAllSeeDoctor.CheckedChanged
        If Me.rdoGetAllSeeDoctor.Checked Then EnablePeriodCTLS(False)
    End Sub

    Private Sub EnablePeriodCTLS(ByVal state As Boolean)

        Me.pnlPeriod.Enabled = state
        If state Then
            Me.dtpStartDate.Value = Today.AddDays(-1)
            Me.dtpEndDate.Value = Today
            Me.dtpStartDate.Checked = True
            Me.dtpEndDate.Checked = True
        Else : ResetControlsIn(Me.pnlPeriod)
        End If

    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case True

                Case Me.rdoGetPeriodSeeDoctor.Checked
                    Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    Me.ShowSeeDoctorVisits(visitStatusID.Doctor, startDate, endDate)

                Case Me.rdoGetPeriodCompleted.Checked
                    Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    Me.ShowSeeDoctorVisits(visitStatusID.Completed, startDate, endDate)

                Case Me.rdoGetAllSeeDoctor.Checked
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many " + Me.Text + "." _
                                            + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowSeeDoctorVisits(visitStatusID.Doctor, Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowSeeDoctorVisits(ByVal visitStatusID As String, ByVal startDate As Nullable(Of Date), ByVal endDate As Nullable(Of Date))

        Dim visits As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Visits
            If (startDate IsNot Nothing) And (endDate IsNot Nothing) Then
                visits = oVisits.GetDoctorVisits(visitStatusID, startDate, endDate).Tables("Visits")
            Else : visits = oVisits.GetDoctorVisits(visitStatusID).Tables("Visits")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSeeDoctorVisits, visits)

            Dim message As String

            Select Case True
                Case Me.rdoGetPeriodSeeDoctor.Checked
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                Case Me.rdoGetAllSeeDoctor.Checked
                    message = "No " + Me.Text + " record(s) found for all period!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select

            If visits.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + visits.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvSeeDoctorVisits_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeeDoctorVisits.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvSeeDoctorVisits.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = visitNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = visitNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = visitNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvSeeDoctorVisits.ColumnCount < 1 OrElse Me.dgvSeeDoctorVisits.RowCount < 1 Then
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

            If Me.dgvSeeDoctorVisits.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvSeeDoctorVisits))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvSeeDoctorVisits.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub dgvSeeDoctorVisits_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeeDoctorVisits.CellClick
        Try

            If e.RowIndex < 0 Then Return
            Me.visitNo = RevertText(StringMayBeEnteredIn(Me.dgvSeeDoctorVisits.Rows(e.RowIndex).Cells, Me.colVisitNo))
            Me.patientNo = StringMayBeEnteredIn(Me.dgvSeeDoctorVisits.Rows(e.RowIndex).Cells, Me.colPatientNo)
            Me.tokenNo = StringMayBeEnteredIn(Me.dgvSeeDoctorVisits.Rows(e.RowIndex).Cells, Me.colTokenNo)
            Me.firstName = StringMayBeEnteredIn(Me.dgvSeeDoctorVisits.Rows(e.RowIndex).Cells, Me.colFirstName)
            fbnCall.Enabled = e.RowIndex >= 0 AndAlso Not String.IsNullOrEmpty(tokenNo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fbnCall_Click(sender As Object, e As EventArgs) Handles fbnCall.Click
        Try

            If (String.IsNullOrEmpty(visitNo) OrElse String.IsNullOrEmpty(tokenNo)) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oServicePointID As New LookupDataID.ServicePointID()

            SaveQueuedMessage(visitNo, oServicePointID.Doctor(), tokenNo, 0)

        Catch ex As Exception
            Return
        End Try
    End Sub

End Class