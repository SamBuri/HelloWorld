
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmDoctorItems

#Region " Fields "
    Private alertNoControl As Control
    Private doctorItemCategory As AlertItemCategory
#End Region

    Private Sub frmDoctorItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Select Case True

                Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                    Me.Text = "Lab Requests"
                    Me.rdoGetDoctor.Text = "Get Doctor Lab Requests for Set Period"
                    Me.rdoGetAll.Text = "Get All Doctor Lab Requests"

                Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                    Me.Text = "Prescription"
                    Me.rdoGetDoctor.Text = "Get Doctor Prescription for Set Period"
                    Me.rdoGetAll.Text = "Get All Doctor Prescription"

                Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                    Me.Text = "Radiology Examinations"
                    Me.rdoGetDoctor.Text = "Get Doctor Radiology for Set Period"
                    Me.rdoGetAll.Text = "Get All Doctor Radiology"

                Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                    Me.Text = "Procedures"
                    Me.rdoGetDoctor.Text = "Get Doctor Procedures for Set Period"
                    Me.rdoGetAll.Text = "Get All Doctor Procedures"

                Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.CashPayment)
                    Me.Text = "Cash Payment"
                    Me.rdoGetDoctor.Text = "Get Doctor Cash Payment for Set Period"
                    Me.rdoGetAll.Text = "Get All Doctor Cash Payment"

                Case Else
                    Me.Text = "Doctor Items"
                    Me.rdoGetDoctor.Text = "Get Doctor Items for Set Period"
                    Me.rdoGetAll.Text = "Get All Doctor Items"

            End Select

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.ShowDoctorItems(Today.AddDays(-1), Today)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub rdoGetPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetDoctor.CheckedChanged
        If Me.rdoGetDoctor.Checked Then EnablePeriodCTLS(True)
    End Sub

    Private Sub rdoGetAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetAll.CheckedChanged
        If Me.rdoGetAll.Checked Then EnablePeriodCTLS(False)
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

                Case Me.rdoGetDoctor.Checked
                    Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    Me.ShowDoctorItems(startDate, endDate)

                Case Me.rdoGetAll.Checked

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many doctor " + Me.Text + "." _
                                             + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowDoctorItems(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDoctorItems(ByVal startDate As Nullable(Of Date), ByVal endDate As Nullable(Of Date))

        Dim doctorItems As DataTable
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim showOnlyPending As Boolean = Me.chkShowOnlyPending.Checked

            ' Load from Items
            If (startDate IsNot Nothing) And (endDate IsNot Nothing) Then

                Select Case True

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Test, CurrentUser.LoginID, showOnlyPending, startDate, endDate).Tables("Items")

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Drug, CurrentUser.LoginID, showOnlyPending, startDate, endDate).Tables("Items")

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Radiology, CurrentUser.LoginID, showOnlyPending, startDate, endDate).Tables("Items")

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Procedure, CurrentUser.LoginID, showOnlyPending, startDate, endDate).Tables("Items")

                    Case Else : doctorItems = oItems.GetDoctorItems(String.Empty, CurrentUser.LoginID, showOnlyPending, startDate, endDate).Tables("Items")

                End Select

            Else
                Select Case True

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Test, CurrentUser.LoginID, showOnlyPending).Tables("Items")

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Drug, CurrentUser.LoginID, showOnlyPending).Tables("Items")

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Radiology, CurrentUser.LoginID, showOnlyPending).Tables("Items")

                    Case Me.doctorItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                        doctorItems = oItems.GetDoctorItems(oItemCategoryID.Procedure, CurrentUser.LoginID, showOnlyPending).Tables("Items")

                    Case Else : doctorItems = oItems.GetDoctorItems(String.Empty, CurrentUser.LoginID, showOnlyPending).Tables("Items")

                End Select

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDoctorItems, doctorItems)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()
            Dim oItemStatusID As New LookupDataID.ItemStatusID()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvDoctorItems.Rows
                If row.IsNewRow Then Exit For
                Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colItemStatus)
                If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                    Me.dgvDoctorItems.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim message As String

            Select Case True
                Case Me.rdoGetDoctor.Checked
                    message = "No doctor record(s) found for  " + Me.Text + " for period between " _
                                + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                Case Me.rdoGetAll.Checked
                    message = "No doctor record(s) found for  " + Me.Text + " for all period!"
                Case Else : message = "No doctor record(s) found for  " + Me.Text + "!"
            End Select

            If doctorItems.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + doctorItems.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvdoctorItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDoctorItems.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvDoctorItems.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

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

        If Me.dgvDoctorItems.ColumnCount < 1 OrElse Me.dgvDoctorItems.RowCount < 1 Then
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

            If Me.dgvDoctorItems.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvDoctorItems))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvDoctorItems.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class