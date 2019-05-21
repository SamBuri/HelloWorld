
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmInWardAdmissions

#Region " Fields "
    Private alertNoControl As Control
    Private _AutoNumber As AutoNumber
    Private _IPDNurseState As Boolean = False
#End Region

    Private Sub frmInWardAdmissions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Select Case _IPDNurseState
                Case False
                    Me.Cursor = Cursors.WaitCursor()

                    Me.Text = "In Ward Admissions"
                    Me.grpPeriod.Visible = True
                    Me.dtpStartDate.MaxDate = Today
                    Me.dtpStartDate.Value = Today.AddDays(-1)

                    Me.dtpEndDate.MaxDate = Today
                    Me.dtpEndDate.Value = Today

                    Me.ShowInWardAdmissions(Today.AddDays(-1), Today)

                Case True
                    Me.Cursor = Cursors.WaitCursor()

                    Me.Text = "UnAttended InWard Admissions"
                    Me.grpPeriod.Visible = False

                    Me.ShowUnAttendedInWardAdmissions()
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowInWardAdmissions(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowUnAttendedInWardAdmissions()

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
        Dim oVariousOptions As New VariousOptions()

        Dim IPDAlertDays As Integer = oVariousOptions.IPDNurseAlertDays

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim UnAttendedInWardAdmissions As DataTable = oIPDNurse.GetUnAttendedInWardAdmissions(IPDAlertDays).Tables("GetUnAttendedInWardAdmissions")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInWardAdmissions, UnAttendedInWardAdmissions)

            ' Dim message As String = "No " + Me.Text + " record(s) found for period of " +
            ' (CStr(IPDAlertDays)) + "!"

            ' If UnAttendedInWardAdmissions.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + UnAttendedInWardAdmissions.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowInWardAdmissions(ByVal startDate As Date, ByVal endDate As Date)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Admissions
            Dim admissions As DataTable = oAdmissions.GetInWardAdmissions(startDate, endDate).Tables("Admissions")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInWardAdmissions, admissions)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                                    FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            If admissions.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + admissions.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInWardAdmissions_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInWardAdmissions.CellDoubleClick

        Try

            Dim selectedNo As String

            If Me._AutoNumber = AutoNumber.VisitNo Then
                selectedNo = Me.dgvInWardAdmissions.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

            ElseIf Me._AutoNumber = AutoNumber.AdmissionNo Then
                selectedNo = Me.dgvInWardAdmissions.Item(Me.colAdmissionNo.Name, e.RowIndex).Value.ToString()

            Else : selectedNo = Me.dgvInWardAdmissions.Item(Me.colAdmissionNo.Name, e.RowIndex).Value.ToString()
            End If

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = selectedNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = selectedNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = selectedNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvInWardAdmissions.ColumnCount < 1 OrElse Me.dgvInWardAdmissions.RowCount < 1 Then
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

            If Me.dgvInWardAdmissions.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvInWardAdmissions))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvInWardAdmissions.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class