
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects


Public Class frmGetToCountFluidInBalances


#Region " Fields "
    Private alertNoControl As Control
    Private _AutoNumber As AutoNumber
#End Region

    Private Sub frmGetToCountFluidInBalances_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Get To Count Fluid InBalances"

            Me.ShowFluidInBalances()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowFluidInBalances()

        Dim oIPDNurseFluids As New SyncSoft.SQLDb.IPDNurseFluids()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim FluidInBalances As DataTable = oIPDNurseFluids.FluidInBalances().Tables("FluidInBalances")
            LoadGridData(Me.dgvFluidInBalances, FluidInBalances)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub dgvFluidInBalances_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFluidInBalances.CellDoubleClick

        Try

            Dim selectedNo As String

            If Me._AutoNumber = AutoNumber.VisitNo Then
                selectedNo = Me.dgvFluidInBalances.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

            ElseIf Me._AutoNumber = AutoNumber.AdmissionNo Then
                selectedNo = Me.dgvFluidInBalances.Item(Me.colAdmissionNo.Name, e.RowIndex).Value.ToString()

            Else : selectedNo = Me.dgvFluidInBalances.Item(Me.colAdmissionNo.Name, e.RowIndex).Value.ToString()
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

        If Me.dgvFluidInBalances.ColumnCount < 1 OrElse Me.dgvFluidInBalances.RowCount < 1 Then
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

            If Me.dgvFluidInBalances.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvFluidInBalances))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvFluidInBalances.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


End Class