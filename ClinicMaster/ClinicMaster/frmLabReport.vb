Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmLabReport

    Private Sub frmLabReport_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub frmLabReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            LoadLookupDataCombo(Me.cboSearchAgeByID, LookupObjects.SearchAgeBy, True)
            Me.dtpStartDate.MaxDate = Today()
            Me.dtpEndDate.MaxDate = Today()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbClose_Click(sender As System.Object, e As System.EventArgs) Handles fbClose.Click
        Me.Close()
    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oLabResults As New SyncSoft.SQLDb.LabResults()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsNo.Text = String.Empty
            Me.fbnLoad.Enabled = True


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim searchAgeBy As String = StringValueEnteredIn(cboSearchAgeByID, "Search Age By!")
            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")
            Dim startAge As Short = ShortEnteredIn(Me.nbxStartAge, "Start Age")
            Dim endAge As Short = ShortMayBeEnteredIn(Me.nbxEndAge, -1)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endAge < 0 Then endAge = CShort(GetAge(AppData.NullDateValue))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            If endAge < startAge Then Throw New ArgumentException("End Age can't be less than Start Age!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcLabTestsReport.SelectedTab.Name

                Case Me.tpgTestsDone.Name

                    Dim reports As DataTable = oLabResults.GetLabTestsDone(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTestsDone.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvTestsDone

                            .Rows.Add()

                            .Item(Me.colTestCode.Name, rowNo).Value = StringMayBeEnteredIn(row, "TestCode")
                            .Item(Me.colTestName.Name, rowNo).Value = StringMayBeEnteredIn(row, "TestName")
                            .Item(Me.ColTestsDoneFemale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Female")
                            .Item(Me.ColTestsDoneMale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Male")
                            .Item(Me.colTestsDoneTotal.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Total")
                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvTestsDone, Nothing, 3)
                    Me.fbnExport.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgTestResults.Name

                    Dim reports As DataTable = oLabResults.GetLabTestsResultsDone(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTestResults.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvTestResults

                            .Rows.Add()

                            .Item(Me.colTestResultTestCode.Name, rowNo).Value = StringMayBeEnteredIn(row, "TestCode")
                            .Item(Me.colTestResultTestName.Name, rowNo).Value = StringMayBeEnteredIn(row, "TestName")
                            .Item(Me.ColResult.Name, rowNo).Value = StringMayBeEnteredIn(row, "Result")
                            .Item(Me.ColTestResultsMale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Male")
                            .Item(Me.ColTestResultsFemale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Female")
                            .Item(Me.colTestResultsTotal.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Occurances")
                        End With

                    Next


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvTestResults, Nothing, 3)
                    Me.fbnExport.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgtestsext.Name

                    Dim reports As DataTable = oLabResults.GetLabTestsDoneStatistics(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTestsEXT.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvTestsEXT

                            .Rows.Add()

                            .Item(Me.ColItemName.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemName")
                            .Item(Me.ColNoOfPatients.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "NoOfPatients")
                            .Item(Me.ColDone.Name, rowNo).Value = StringMayBeEnteredIn(row, "Done")
                            .Item(Me.ColPending.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Pending")
                            .Item(Me.ColProcessing.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Processing")

                        End With

                    Next


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvTestsEXT, Nothing, 3)
                    Me.fbnExport.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case tpglabResultsEXt.Name

                    Dim reports As DataTable = oLabResults.GetLabTestsResultsEXTDone(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTestResultsEXT.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvTestResultsEXT

                            .Rows.Add()

                            .Item(Me.ColTestResultsEXTTestCode.Name, rowNo).Value = StringMayBeEnteredIn(row, "TestCode")
                            .Item(Me.ColTestResultsEXTTestName.Name, rowNo).Value = StringMayBeEnteredIn(row, "TestName")
                            .Item(Me.ColTestResultsEXTResult.Name, rowNo).Value = StringMayBeEnteredIn(row, "Result")
                            .Item(Me.ColTestResultsEXTMale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Male")
                            .Item(Me.ColTestResultsEXTFemale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Female")
                            .Item(Me.ColTestResultsOccurances.Name, rowNo).Value = StringMayBeEnteredIn(row, "Occurances")
                        End With

                    Next


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvTestResultsEXT, Nothing, 3)
                    Me.fbnExport.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            Me.lblRecordsNo.Text = String.Empty
            Me.fbnExport.Enabled = False
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcLabTestsReport.SelectedTab.Name

                Case Me.tpgTestsDone.Name
                    ExportToExcel(Me.dgvTestsDone, Me.tpgTestsDone.Text)

                Case Me.tpgTestResults.Name
                    ExportToExcel(Me.dgvTestResults, Me.tpgTestResults.Text)
                Case Me.tpgtestsext.Name
                    ExportToExcel(Me.dgvTestsEXT, Me.tpgtestsext.Text)

                Case Me.tpglabResultsEXt.Name
                    ExportToExcel(Me.dgvTestResultsEXT, Me.tpglabResultsEXt.Text)
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class