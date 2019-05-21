
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmPeriodicResearchRoutingForm

#Region " Fields "
    Private alertNoControl As Control
#End Region

Private Sub frmPeriodicResearchRoutingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            'Me.dtpEndDate.Value = Today
            'Me.dtpEndDate.Value = Today.AddDays(1)

            Me.fbnLoad.PerformClick()

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmPeriodicResearchRoutingForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub


    Private Sub ShowResearchRoutingForm()

        Dim researchRoutingForm As DataTable = New DataTable()
        Dim oResearchRoutingForm As New SyncSoft.SQLDb.ResearchRoutingForm()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(dtpStartDate, "End Date")
            Dim endDate As Date = DateEnteredIn(dtpStartDate, "End Date")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim message As String

            Select Case rdoLoadAll.Checked
                Case True
                    researchRoutingForm = oResearchRoutingForm.GetPeriodicResearchRoutingForm().Tables("ResearchRoutingForm")
                    message = "No " + Me.Text + " record(s) found for all period!"

                    
                Case False
                    researchRoutingForm = oResearchRoutingForm.GetPeriodicResearchRoutingForm(startDate, endDate).Tables("ResearchRoutingForm")
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select
            LoadGridData(Me.dgvPeriodicResearchRouting, researchRoutingForm)
            If researchRoutingForm.Rows.Count < 1 Then DisplayMessage(message)

            Me.lblRecordsNo.Text = " Returned Record(s): " + researchRoutingForm.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

  
    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            ShowResearchRoutingForm()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvPeriodicResearchRouting_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodicResearchRouting.CellContentClick

    End Sub

    Private Sub dgvPeriodicResearchRouting_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodicResearchRouting.CellDoubleClick
        Try

            Dim _UCNo As String = Me.dgvPeriodicResearchRouting.Item(Me.colUCINo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = _UCNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = _UCNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = _UCNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub
End Class