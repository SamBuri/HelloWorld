
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Public Class frmPeriodicClaims

#Region " Fields "
    Private alertNoControl As Control
    Private _showPeriodPanel As Boolean = True
    Private _showIncludeColumn As Boolean = False
#End Region

    Private Sub frmPeriodicClaims_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

        Try
            'DisplayMessage(_showPeriodPanel.ToString)
            Me.Cursor = Cursors.WaitCursor()

            Select Case _showPeriodPanel
                Case True
                    Me.Text = "Periodic Claims"

                    Me.dtpStartDate.MaxDate = Today
                    Me.dtpEndDate.MaxDate = Today
                    Select Case _showIncludeColumn
                        Case True
                            Me.colInclude.Visible = True
                        Case False
                            Me.colInclude.Visible = False
                    End Select

                    Me.cmsItemsIncludeAll.Visible = False
                    Me.cmsItemsIncludeNone.Visible = False
                    If Me.dgvPeriodicClaims.ColumnCount < 1 OrElse Me.dgvPeriodicClaims.RowCount < 1 Then
                        Me.cmsItemsCopy.Enabled = False
                        Me.cmsItemsSelectAll.Enabled = False
                        Me.cmsItemsIncludeAll.Enabled = False
                        Me.cmsItemsIncludeNone.Enabled = False
                    Else
                        Me.cmsItemsCopy.Enabled = True
                        Me.cmsItemsSelectAll.Enabled = True
                        Me.cmsItemsIncludeAll.Enabled = False
                        Me.cmsItemsIncludeNone.Enabled = False

                    End If

                    Me.ShowPeriodicClaims(Today, Today)
                Case False
                    Me.Text = "Waiting Periodic Claims"
                    Me.grpSetParameters.Visible = False
                    Me.fbnLoad.Visible = False
                    Me.dtpStartDate.Enabled = False
                    Me.dtpEndDate.Enabled = False
                    Me.dtpStartDate.Visible = False
                    Me.dtpEndDate.Visible = False
                    Select Case _showIncludeColumn
                        Case True
                            Me.colInclude.Visible = True
                        Case False
                            Me.colInclude.Visible = False
                    End Select
                    Me.dgvPeriodicClaims.Location = New System.Drawing.Point(8, 20)
                    Me.dgvPeriodicClaims.Size = New System.Drawing.Size(881, 302)
                    Me.cmsItemsIncludeAll.Visible = True
                    Me.cmsItemsIncludeNone.Visible = True
                    If Me.dgvPeriodicClaims.ColumnCount < 1 OrElse Me.dgvPeriodicClaims.RowCount < 1 Then
                        Me.cmsItemsCopy.Enabled = False
                        Me.cmsItemsSelectAll.Enabled = False
                        Me.cmsItemsIncludeAll.Enabled = False
                        Me.cmsItemsIncludeNone.Enabled = False
                    Else
                        Me.cmsItemsCopy.Enabled = True
                        Me.cmsItemsSelectAll.Enabled = True
                        Me.cmsItemsIncludeAll.Enabled = True
                        Me.cmsItemsIncludeNone.Enabled = True
                    End If

                    Me.ShowWaitingPeriodicClaims()
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
            Me.ShowPeriodicClaims(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowWaitingPeriodicClaims()

        Dim oClaims As New SyncSoft.SQLDb.Claims()
        Dim oVariousOptions As New VariousOptions()

        Dim ClaimPaymentsAlertDays As Integer = oVariousOptions.ClaimPaymentsAlertDays

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim WaitingPeriodicClaims As DataTable = oClaims.GetWaitingPeriodicClaims(ClaimPaymentsAlertDays).Tables("WaitingPeriodicClaims")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPeriodicClaims, WaitingPeriodicClaims)

            ' Dim message As String = "No " + Me.Text + " record(s) found for period of " +
            ' (CStr(IPDAlertDays)) + "!"

            ' If UnAttendedInWardAdmissions.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + WaitingPeriodicClaims.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPeriodicClaims(ByVal startDate As Date, ByVal endDate As Date)

        Dim oClaims As New SyncSoft.SQLDb.Claims()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Claims
            Dim claims As DataTable = oClaims.GetPeriodicClaims(startDate, endDate).Tables("Claims")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPeriodicClaims, claims)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " _
                                    + FormatDate(startDate) + " and " + FormatDate(endDate) + "!"

            If claims.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + claims.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPeriodicClaims_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodicClaims.CellDoubleClick

        Try

            Dim claimNo As String = Me.dgvPeriodicClaims.Item(Me.colClaimNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = claimNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = claimNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = claimNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With PeriodicClaims.values

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                PeriodicClaims.values.Add(e.RowIndex, Me.dgvPeriodicClaims.Item(Me.colClaimNo.Name, e.RowIndex).Value.ToString())
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsItems_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsItems.Opening

        Select Case _showPeriodPanel
            Case True
                Me.cmsItemsIncludeAll.Visible = False
                Me.cmsItemsIncludeNone.Visible = False
                If Me.dgvPeriodicClaims.ColumnCount < 1 OrElse Me.dgvPeriodicClaims.RowCount < 1 Then
                    Me.cmsItemsCopy.Enabled = False
                    Me.cmsItemsSelectAll.Enabled = False
                    Me.cmsItemsIncludeAll.Enabled = False
                    Me.cmsItemsIncludeNone.Enabled = False
                Else
                    Me.cmsItemsCopy.Enabled = True
                    Me.cmsItemsSelectAll.Enabled = True
                    Me.cmsItemsIncludeAll.Enabled = False
                    Me.cmsItemsIncludeNone.Enabled = False

                End If
            Case False
                Me.cmsItemsIncludeAll.Visible = True
                Me.cmsItemsIncludeNone.Visible = True
                If Me.dgvPeriodicClaims.ColumnCount < 1 OrElse Me.dgvPeriodicClaims.RowCount < 1 Then
                    Me.cmsItemsCopy.Enabled = False
                    Me.cmsItemsSelectAll.Enabled = False
                    Me.cmsItemsIncludeAll.Enabled = False
                    Me.cmsItemsIncludeNone.Enabled = False
                Else
                    Me.cmsItemsCopy.Enabled = True
                    Me.cmsItemsSelectAll.Enabled = True
                    Me.cmsItemsIncludeAll.Enabled = True
                    Me.cmsItemsIncludeNone.Enabled = True
                End If
        End Select
        

    End Sub


    Private Sub cmsItemsCopy_Click(sender As Object, e As EventArgs) Handles cmsItemsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvPeriodicClaims.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPeriodicClaims))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsItemsSelectAll_Click(sender As Object, e As EventArgs) Handles cmsItemsSelectAll.Click
        Me.dgvPeriodicClaims.SelectAll()
    End Sub

    Private Sub cmsItemsIncludeAll_Click(sender As Object, e As EventArgs) Handles cmsItemsIncludeAll.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In Me.dgvPeriodicClaims.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Me.ColInclude.ThreeState = True
                Me.dgvPeriodicClaims.Item(Me.colInclude.Name, Row.Index).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '  Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cmsItemsIncludeNone_Click(sender As Object, e As EventArgs) Handles cmsItemsIncludeNone.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In Me.dgvPeriodicClaims.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvPeriodicClaims.Item(Me.colInclude.Name, Row.Index).Value = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    
    Private Sub fbnOk_Click(sender As Object, e As EventArgs) Handles fbnOk.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvPeriodicClaims.Rows
                If CBool(Me.dgvPeriodicClaims.Item(Me.colInclude.Name, row.Index).Value) = True Then

                    With PeriodicClaims.values

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        PeriodicClaims.values.Add(row.Index, Me.dgvPeriodicClaims.Item(Me.colClaimNo.Name, row.Index).Value.ToString())
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With
                ElseIf CBool(Me.dgvPeriodicClaims.Item(Me.colInclude.Name, row.Index).Value) = False Then

                End If
            Next


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
            Me.Close()
        End Try
    End Sub

    Private Sub dgvPeriodicClaims_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPeriodicClaims.CellClick

        Try
            Me.Cursor = Cursors.WaitCursor

            If CBool(Me.dgvPeriodicClaims.Item(Me.colInclude.Name, dgvPeriodicClaims.CurrentRow.Index).Value) = True Then
                Me.dgvPeriodicClaims.Item(Me.colInclude.Name, dgvPeriodicClaims.CurrentRow.Index).Value = False
            ElseIf CBool(Me.dgvPeriodicClaims.Item(Me.colInclude.Name, dgvPeriodicClaims.CurrentRow.Index).Value) = False Then
                Me.dgvPeriodicClaims.Item(Me.colInclude.Name, dgvPeriodicClaims.CurrentRow.Index).Value = True
            End If

        Catch ex As Exception
            Return
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

   
End Class