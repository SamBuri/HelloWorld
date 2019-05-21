Imports SyncSoft.Common.Methods

Public Class frmDashboardManualDeposits


    Private Sub ShowManualAccounts(ByVal startDateTime As Nullable(Of DateTime), ByVal endDateTime As Nullable(Of DateTime))

        Dim manualDebits As DataTable
        Dim omanualDebits As New SyncSoft.SQLDb.Accounts()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from billsExceeding

            If (startDateTime IsNot Nothing) And (endDateTime IsNot Nothing) Then
                manualDebits = omanualDebits.GetDashboardManualDebits(startDateTime, endDateTime).Tables("Accounts")
            Else : manualDebits = omanualDebits.GetDashboardManualDebits().Tables("Accounts")
            End If




            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAccounts, manualDebits)

            Dim message As String

            Select Case True
                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDateTime(CDate(startDateTime)) + " and " + FormatDateTime(CDate(endDateTime)) + "!"
                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False
                    message = "No " + Me.Text + " record(s) found for all period!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select

            If manualDebits.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + manualDebits.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        ExportToExcel(Me.dgvAccounts, Me.Text)
    End Sub

    Private Sub frmDashboardManualDeposits_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.ShowManualAccounts(Today.AddDays(-1), Today.AddDays(+1))


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case True

                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    Me.ShowManualAccounts(startDate, endDate)


                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many " + Me.Text + "." _
                                            + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowManualAccounts(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class