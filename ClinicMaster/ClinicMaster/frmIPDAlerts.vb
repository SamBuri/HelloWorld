
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmIPDAlerts

#Region " Fields "
    Private alertTypeID As String
    Private alertNoControl As Control
#End Region

    Private Sub frmIPDAlerts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oAlertTypeID As New LookupDataID.AlertTypeID

        Try
            Me.Cursor = Cursors.WaitCursor()

            If alertTypeID.ToUpper().Equals(oAlertTypeID.LabResults.ToUpper()) Then
                Me.Text = "Patients’ list with ready results"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Prescription.ToUpper()) Then
                Me.Text = "Patients’ list with doctor prescription"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.LabRequests.ToUpper()) Then
                Me.Text = "Patients’ list with doctor lab requests"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Radiology.ToUpper()) Then
                Me.Text = "Patients’ list with doctor radiology"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Pathology.ToUpper()) Then
                Me.Text = "Patients’ list with doctor pathology"
            Else : Me.Text = "Alert List"
            End If

            Me.ShowSentIPDAlerts()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowSentIPDAlerts()

        Dim iPDAlerts As DataTable
        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from IPDAlerts

            If alertTypeID.ToUpper().Equals(oAlertTypeID.LabResults.ToUpper()) Then
                iPDAlerts = oIPDAlerts.GetIPDAlerts(alertTypeID, CurrentUser.LoginID).Tables("IPDAlerts")

            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Prescription.ToUpper()) Then
                iPDAlerts = oIPDAlerts.GetIPDAlerts(alertTypeID).Tables("IPDAlerts")

            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.LabRequests.ToUpper()) Then
                iPDAlerts = oIPDAlerts.GetIPDAlerts(alertTypeID).Tables("IPDAlerts")

            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Radiology.ToUpper()) Then
                iPDAlerts = oIPDAlerts.GetIPDAlerts(alertTypeID).Tables("IPDAlerts")

            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Pathology.ToUpper()) Then
                iPDAlerts = oIPDAlerts.GetIPDAlerts(alertTypeID).Tables("IPDAlerts")

            Else : iPDAlerts = oIPDAlerts.GetIPDAlerts(alertTypeID).Tables("IPDAlerts")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvIPDAlerts, iPDAlerts)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvIPDAlerts_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPDAlerts.CellDoubleClick

        Try
            
            Dim roundNo As String = Me.dgvIPDAlerts.Item(Me.colRoundNoText.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = roundNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = roundNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = roundNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvIPDAlerts.ColumnCount < 1 OrElse Me.dgvIPDAlerts.RowCount < 1 Then
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

            If Me.dgvIPDAlerts.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvIPDAlerts))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvIPDAlerts.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class