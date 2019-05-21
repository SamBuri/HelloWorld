
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmOPDDispensedDrugs

#Region " Fields "
    Private alertNoControl As Control
#End Region

Private Sub frmOPDDispensedDrugs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
          
            Me.fbnLoad.PerformClick()


	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmOPDDispensedDrugs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        ExportToExcel(dgvDispensedOPDDrugs)
    End Sub



    Private Sub ShowDispensedOPDDrugs()

        Dim items As DataTable = New DataTable()
        Dim oItems As New SyncSoft.SQLDb.Items()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(dtpStartDate, "End Date")
            Dim endDate As Date = DateEnteredIn(dtpStartDate, "End Date")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim message As String

            Select Case rdoDispensedOPDDrugs.Checked
                Case True
                    Dim warningMessage As String = "You are a bout to load all OPD Drugs ever dispensed . This action may take awhile" +
                                           ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(warningMessage) = Windows.Forms.DialogResult.No Then Return
                    items = oItems.GetOPDDispensedDrugs().Tables("Items")
                    message = "No " + Me.Text + " record(s) found for all period!"
                    
                Case False
                    items = oItems.GetOPDDispensedDrugs(startDate, endDate).Tables("Items")
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select
            LoadGridData(Me.dgvDispensedOPDDrugs, items)
            If items.Rows.Count < 1 Then
                DisplayMessage(message)
                Me.fbnExport.Enabled = False
            Else
                Me.fbnExport.Enabled = True
            End If

            Me.lblRecordsNo.Text = " Returned Record(s): " + items.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            ShowDispensedOPDDrugs()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


    Private Sub dgvDispensedOPDDrugs_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDispensedOPDDrugs.CellDoubleClick
        Try

            Dim visitNo As String = Me.dgvDispensedOPDDrugs.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

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
End Class