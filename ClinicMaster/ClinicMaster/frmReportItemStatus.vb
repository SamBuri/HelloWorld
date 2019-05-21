Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmReportItemStatus


    Private Sub frmReportItemStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Now
            Me.dtpEndDateTime.Value = Now
            LoadLookupDataCombo(Me.cboItemCategoryID, LookupObjects.ItemCategory, False)
            LoadLookupDataCombo(Me.cboItemStatusID, LookupObjects.ItemStatus, False)
            LoadLookupDataCombo(Me.cboPayStatusID, LookupObjects.PayStatus, False)
            LoadLookupDataCombo(Me.cboBillModeID, LookupObjects.BillModes, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnReportOperations_Click(sender As System.Object, e As System.EventArgs) Handles fbnReportOperations.Click

        Try
            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date and Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date and Time")
            Dim itemCategoryID As String = RevertText(StringValueMayBeEnteredIn(Me.cboItemCategoryID))
            Dim payStatusID As String = RevertText(StringValueMayBeEnteredIn(Me.cboPayStatusID))
            Dim itemStatusID As String = RevertText(StringValueMayBeEnteredIn(Me.cboItemStatusID))
            Dim billModesID As String = RevertText(StringValueMayBeEnteredIn(Me.cboBillModeID))

            Me.ShowOperationalOPDItemsReport(startDateTime, endDateTime, itemCategoryID, itemStatusID, payStatusID, billModesID)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim rowCount As Integer = Me.dgvOPDItemsStatus.RowCount
            Me.fbnExport.Enabled = rowCount > 0
            Me.lblRecordsNo.Text = Me.tpgOPDItemsStatus.Text + " Returned Record(s): " + rowCount.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ShowOperationalOPDItemsReport(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal itemCategoryID As String, ByVal itemStatusID As String, ByVal payStatusID As String, ByVal billModesID As String)
        Dim oGetOperationalOPDItemsReport As New SyncSoft.SQLDb.Items
        Dim oGetOperationalIPDItemsReport As New SyncSoft.SQLDb.IPDItems
        Dim Message As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Select Case Me.tbcReportOperation.SelectedTab.Name

                Case Me.tpgOPDItemsStatus.Name

                    ' Load from Items
                    Dim operationalOPDItemsReport As DataTable = oGetOperationalOPDItemsReport.GetOperationalOPDItemsReport(startDateTime, endDateTime, itemCategoryID, itemStatusID, payStatusID, billModesID).Tables("Items")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvOPDItemsStatus.RowCount

                    LoadGridData(Me.dgvOPDItemsStatus, operationalOPDItemsReport)
                    FormatGridRow(Me.dgvOPDItemsStatus)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If operationalOPDItemsReport IsNot Nothing AndAlso operationalOPDItemsReport.Rows.Count > 0 Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim miniOPDItemsReport As EnumerableRowCollection(Of DataRow) = operationalOPDItemsReport.AsEnumerable()
                        Dim totalBill As Decimal = (From data In miniOPDItemsReport Select data.Field(Of Decimal)("TotalAmount")).Sum()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.stbTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                        Me.stbAmountWords.Text = NumberToWords(totalBill)
                       
                    Else
                        Me.stbTotalAmount.Clear()
                        Me.stbAmountWords.Clear()
                    End If

                      ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvOPDItemsStatus.RowCount <= 0 Then

                        Message = "No " + Me.tpgOPDItemsStatus.Text + " record(s) found for period between " + FormatDateTime(startDateTime) +
                                " and " + FormatDateTime(endDateTime) + "!"

                        DisplayMessage(Message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case tpgIPDItemStatus.Name

                    ' Load from Items
                    Dim operationalIPDItemsReport As DataTable = oGetOperationalIPDItemsReport.GetOperationalIPDItemsReport(startDateTime, endDateTime, itemCategoryID, itemStatusID, payStatusID, billModesID).Tables("Items")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvIPDItemsStatus.RowCount

                    LoadGridData(Me.dgvIPDItemsStatus, operationalIPDItemsReport)
                    FormatGridRow(Me.dgvIPDItemsStatus)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If operationalIPDItemsReport IsNot Nothing AndAlso operationalIPDItemsReport.Rows.Count > 0 Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim miniIPDItemsReport As EnumerableRowCollection(Of DataRow) = operationalIPDItemsReport.AsEnumerable()
                        Dim totalBill As Decimal = (From data In miniIPDItemsReport Select data.Field(Of Decimal)("TotalAmount")).Sum()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.stbIPDTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                        Me.StbIPDAmountInWords.Text = NumberToWords(totalBill)

                    Else
                        Me.stbIPDTotalAmount.Clear()
                        Me.StbIPDAmountInWords.Clear()
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvIPDItemsStatus.RowCount <= 0 Then

                        Message = "No " + Me.tpgIPDItemStatus.Text + " record(s) found for period between " + FormatDateTime(startDateTime) +
                                " and " + FormatDateTime(endDateTime) + "!"

                        DisplayMessage(Message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDateTime, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDateTime, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim _objectCaption As String = Me.tbcReportOperation.SelectedTab.Text

            Dim documentTitle As String = _objectCaption + " for the period between " _
                       + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

            Select Case Me.tbcReportOperation.SelectedTab.Name

                Case Me.tpgOPDItemsStatus.Name
                    ExportToExcel(Me.dgvOPDItemsStatus, _objectCaption, documentTitle)

            End Select

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub tbcReportOperation_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbcReportOperation.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcReportOperation.SelectedTab.Name


                Case Me.tpgOPDItemsStatus.Name
                    Dim rowCount As Integer = Me.dgvOPDItemsStatus.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + rowCount.ToString()

                Case Else
                    Me.fbnExport.Enabled = False

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class