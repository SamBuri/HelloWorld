Option Strict On
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Public Class frmSagePastel

    Private Sub frmSagePastel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ShowSagePastelData(ByVal StartDateTime As Date, ByVal endDateTime As Date)

        Dim oItems As New SyncSoft.SQLDb.Items
        Dim items As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from items
            items = oItems.GetSagePastelReport(startDateTime, endDateTime).Tables("Items")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSagePastel, items)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If items IsNot Nothing AndAlso items.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniitems As EnumerableRowCollection(Of DataRow) = items.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniitems Select data.Field(Of Decimal)("Debit")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbOPDSageAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbOPDSageAmountInWords.Text = NumberToWords(totalBill)
            Else
                Me.stbOPDSageAmount.Clear()
                Me.stbOPDSageAmountInWords.Clear()
            End If

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

            If items.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + items.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowIPDSagePastelData(ByVal StartDateTime As Date, ByVal endDateTime As Date)

        Dim oItems As New SyncSoft.SQLDb.ExtraBillItems
        Dim items As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from items
            items = oItems.GetIPDSagePastelReport(StartDateTime, endDateTime).Tables("ExtraBillItems")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvIPDSagePastel, items)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If items IsNot Nothing AndAlso items.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniitems As EnumerableRowCollection(Of DataRow) = items.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniitems Select data.Field(Of Decimal)("Debit")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbTotalAmount.Clear()
                Me.stbAmountWords.Clear()
            End If

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDateTime(StartDateTime) + " and " + FormatDateTime(endDateTime) + "!"

            If items.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + items.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim StartDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date and Time")
            Dim EndDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date and Time")

            If EndDateTime < StartDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")



            Select Case Me.tbcSage.SelectedTab.Name

                Case Me.tpOpdItems.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowSagePastelData(StartDateTime, EndDateTime)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpIPDItems.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowIPDSagePastelData(StartDateTime, EndDateTime)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
   Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcSage.SelectedTab.Name

                Case Me.tpOpdItems.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ExportToExcel(Me.dgvSagePastel, Me.Text)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpIPDItems.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ExportToExcel(Me.dgvIPDSagePastel, Me.Text)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            End Select


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub tbcSage_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbcSage.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcSage.SelectedTab.Name

                Case Me.tpIPDItems.Name
                    Dim rowCount As Integer = Me.dgvIPDSagePastel.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpOpdItems.Name
                    Dim rowCount As Integer = Me.dgvSagePastel.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

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