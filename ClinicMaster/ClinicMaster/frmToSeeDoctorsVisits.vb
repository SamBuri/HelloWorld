Option Strict On

Imports SyncSoft.Common.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmToSeeDoctorsVisits

#Region " Fields "
    Private visitStatusID As New LookupDataID.VisitStatusID()
#End Region

    Private Sub DoctorVisits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Doctor visits"

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today


            Me.LoadStaff()
            Me.ShowSeeDoctorVisits(Today.AddDays(-1), Today)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            Me.cboStaffNo.Items.Add(" ")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click


        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case True

                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    Me.ShowSeeDoctorVisits(startDate, endDate)


                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many " + Me.Text + "." _
                                            + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowSeeDoctorVisits(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub


    Private Sub ShowSeeDoctorVisits(ByVal startDateTime As Nullable(Of DateTime), ByVal endDateTime As Nullable(Of DateTime))

        Dim visits As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Visits
            If Not String.IsNullOrEmpty(Me.cboStaffNo.Text) Then
                Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                If (startDateTime IsNot Nothing) And (endDateTime IsNot Nothing) Then
                    visits = oVisits.GetToSeeDoctorVisits(staffNo, startDateTime, endDateTime).Tables("Visits")
                Else : visits = oVisits.GetToSeeDoctorVisits(staffNo).Tables("Visits")
                End If
            Else
                If (startDateTime IsNot Nothing) And (endDateTime IsNot Nothing) Then
                    visits = oVisits.GetToSeeDoctorVisits(Nothing, startDateTime, endDateTime).Tables("Visits")
                Else : visits = oVisits.GetToSeeDoctorVisits(Nothing).Tables("Visits")
                End If
            End If

            

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSeeDoctorVisits, visits)

            Dim message As String

            Select Case True
                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDateTime(CDate(startDateTime)) + " and " + FormatDateTime(CDate(endDateTime)) + "!"
                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False
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

    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click
        Me.Close()
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


    Private Sub dgvSeeDoctorVisits_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeeDoctorVisits.CellDoubleClick

        Try

            Dim staffNo As String = Me.dgvSeeDoctorVisits.Item(Me.colStaffNo.Name, e.RowIndex).Value.ToString()
            Dim startDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpStartDate)
            Dim endDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpEndDate)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           

            Select Case True
                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    Dim fToseeVisitsPerDoctor As New frmToSeeVisitsPerDoctor(staffNo, startDateTime, endDateTime)
                    fToseeVisitsPerDoctor.ShowDialog()

                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False
                    Dim fToseeVisitsPerDoctor As New frmToSeeVisitsPerDoctor(staffNo, Nothing, Nothing)
                    fToseeVisitsPerDoctor.ShowDialog()


            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Return
        End Try

    End Sub

End Class