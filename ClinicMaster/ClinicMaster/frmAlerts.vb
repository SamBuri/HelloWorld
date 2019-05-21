
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmAlerts

#Region " Fields "
    Private alertTypeID As String
    Private alertNoControl As Control
    Dim patientNo As String
    Dim firstName As String
    Dim visitNo As String
    Dim oServicePointID As New LookupDataID.ServicePointID
    Private servicePointID As String
#End Region

    Private Sub frmAlerts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor()

            If alertTypeID.ToUpper().Equals(oAlertTypeID.LabResults.ToUpper()) Then
                Me.Text = "Patients’ list with ready results"
                servicePointID = oServicePointID.Doctor()
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Prescription.ToUpper()) Then
                Me.Text = "Patients’ list with doctor prescription"
                servicePointID = oServicePointID.Doctor()
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Consumable.ToUpper()) Then
                Me.Text = "Patients’ list with sent consumables"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.LabRequests.ToUpper()) Then
                Me.Text = "Patients’ list with doctor lab requests"
                servicePointID = oServicePointID.Pharmacy()
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Pathology.ToUpper()) Then
                Me.Text = "Patients’ list with doctor Pathology requests"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Radiology.ToUpper()) Then
                Me.Text = "Patients’ list with doctor radiology"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.RadiologyReports.ToUpper()) Then
                Me.Text = "Patients’ list with ready radiology reports"
                servicePointID = oServicePointID.Doctor()
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Procedure.ToUpper()) Then
                Me.Text = "Patients’ list with doctor procedure"
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Theatre.ToUpper()) Then
                Me.Text = "Patients’ list with theatre service"
            Else : Me.Text = "Alert List"
            End If
            '
            Me.ShowSentAlerts()
            Me.CheckQueueStatus()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub CheckQueueStatus()
        If IsQueueEnabled() = False Then
            Me.fbnCall.Visible = False

        Else
            Me.fbnCall.Visible = True

        End If
    End Sub


    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowSentAlerts()

        Dim alerts As DataTable
        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from alerts TemplateType

            If alertTypeID.ToUpper().Equals(oAlertTypeID.LabResults.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID, CurrentUser.LoginID).Tables("Alerts")
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Prescription.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Consumable.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.LabRequests.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Radiology.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Pathology.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.RadiologyReports.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID, CurrentUser.LoginID).Tables("Alerts")
             ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Procedure.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            ElseIf alertTypeID.ToUpper().Equals(oAlertTypeID.Theatre.ToUpper()) Then
                alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            Else : alerts = oAlerts.GetAlerts(alertTypeID).Tables("Alerts")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAlerts, alerts)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvAlerts_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAlerts.CellClick
        If e.RowIndex < 0 Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.visitNo = RevertText(StringMayBeEnteredIn(Me.dgvAlerts.Rows(e.RowIndex).Cells, Me.colVisitNoText))
        Me.patientNo = StringMayBeEnteredIn(Me.dgvAlerts.Rows(e.RowIndex).Cells, Me.colPatientNo)
        Me.firstName = StringMayBeEnteredIn(Me.dgvAlerts.Rows(e.RowIndex).Cells, Me.colFirstName)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        fbnCall.Enabled = e.RowIndex >= 0 AndAlso Not String.IsNullOrEmpty(servicePointID)
    End Sub

    Private Sub dgvAlerts_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAlerts.CellDoubleClick

        Try
            Dim oCurrentPatient As New CurrentPatient()

            oCurrentPatient.PatientNo = Me.dgvAlerts.Item(Me.colPatientNo.Name, e.RowIndex).Value.ToString()
            oCurrentPatient.VisitNo = Me.dgvAlerts.Item(Me.colVisitNoText.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = oCurrentPatient.VisitNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = oCurrentPatient.VisitNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = oCurrentPatient.VisitNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvAlerts.ColumnCount < 1 OrElse Me.dgvAlerts.RowCount < 1 Then
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

            If Me.dgvAlerts.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvAlerts))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvAlerts.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub TEST()

    End Sub

    Private Sub dgvAlerts_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAlerts.CellContentClick

    End Sub

    Private Sub fbnCall_Click(sender As System.Object, e As System.EventArgs) Handles fbnCall.Click
        Try

            If (String.IsNullOrEmpty(visitNo) OrElse String.IsNullOrEmpty(servicePointID)) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            SaveQueuedMessage(visitNo, servicePointID, String.Empty, 0)

        Catch ex As Exception
            ErrorMessage(ex)
            Return
        End Try
    End Sub
End Class