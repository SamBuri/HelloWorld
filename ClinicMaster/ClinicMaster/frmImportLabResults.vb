
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class frmImportLabResults

#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
    Private staff As New DataTable()
#End Region

    Private Sub frmImportLabResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try

            ' Load from Staff
            staff = oStaff.GetStaffByStaffTitle(oStaffTitleID.LabTechnologist).Tables("Staff")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbFileName.TextChanged
        Me.ResetCTLS()
    End Sub

    Private Sub stbWorksheetName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbWorksheetName.TextChanged
        Me.ResetCTLS()
    End Sub

    Private Sub ResetCTLS()
        Me.lblRecordsImported.Text = String.Empty
        Me.dgvImportedData.Rows.Clear()
        Me.fbnErrorLog.Enabled = False
        Me.lblSaveReport.Text = String.Empty
        Me.fbnExport.Visible = False
    End Sub

    Private Sub fbnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnBrowse.Click

        Dim openFileDLG As New OpenFileDialog()

        Try
            Me.Cursor = Cursors.WaitCursor

            With openFileDLG

                Try
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                Catch ex As Exception
                    Exit Try
                End Try

                .Filter = "Microsoft Excel Files (*.xlsx)|*.xlsx|Excel Files (*.xls)|*.xls"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then Me.stbFileName.Text = .FileName.ToString()

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnImport.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim path As String = StringEnteredIn(Me.stbFileName, "File Name!")
            Dim workSheetName As String = StringEnteredIn(Me.stbWorksheetName, "Work Sheet Name!")
            Dim range As String = ""
            Dim where As String = "where [Specimen No] is not null and [Test Code] is not null"
            Dim criterion As String = "select * from [" + workSheetName + "$" + range + "] " + where
            Dim importedData As DataTable = ImportFromExcel(path, criterion)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetCTLS()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To importedData.Rows.Count - 1

                Dim row As DataRow = importedData.Rows(pos)

                With Me.dgvImportedData

                    .Rows.Add()
                    .Item(Me.colID.Name, pos).Value = IntegerEnteredIn(row, "ID")
                    .Item(Me.colSpecimenNo.Name, pos).Value = StringMayBeEnteredIn(row, "Specimen No")
                    .Item(Me.colTestCode.Name, pos).Value = StringMayBeEnteredIn(row, "Test Code")
                    If IsDBNull(importedData.Rows(pos).Item("Test Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Test Date")) Then
                        .Item(Me.colTestDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colTestDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Test Date")))
                    End If
                    .Item(Me.colTestTime.Name, pos).Value = StringMayBeEnteredIn(row, "Test Time")
                    .Item(Me.colNormalRange.Name, pos).Value = StringMayBeEnteredIn(row, "Normal Range")
                    .Item(Me.colResult.Name, pos).Value = StringMayBeEnteredIn(row, "Result")
                    .Item(Me.colResultFlag.Name, pos).Value = StringMayBeEnteredIn(row, "Result Flag")
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringMayBeEnteredIn(row, "Unit Measure")
                    .Item(Me.colReport.Name, pos).Value = StringMayBeEnteredIn(row, "Report")
                    .Item(Me.colLabTechnologist.Name, pos).Value = StringMayBeEnteredIn(row, "Technologist")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for lab results!"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSaveAll.Click

        Dim savedRows As New List(Of Integer)
        Dim oDataTypeID As New LookupCommDataID.SearchDataTypeID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me._ErrorLog.Remove(0, Me._ErrorLog.Length)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _Number As String = GetLookupDataDes(oDataTypeID.Number)
            Dim _Decimal As String = GetLookupDataDes(oDataTypeID.Decimal)
            Dim _String As String = GetLookupDataDes(oDataTypeID.String)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvImportedData.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for lab results!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 1

                Dim id As Integer
                Dim records As Integer

                Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
                Dim oItemStatusID As New LookupDataID.ItemStatusID()
                Dim oBillModesID As New LookupDataID.BillModesID()
                Dim oPayModesID As New LookupDataID.PayModesID()
                Dim oAccountActionID As New LookupDataID.AccountActionID()
                Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()
                Dim oEntryModeID As New LookupDataID.EntryModeID()

                Dim oVisits As New SyncSoft.SQLDb.Visits()
                Dim oLabTests As New SyncSoft.SQLDb.LabTests()
                Dim oLabResults As New SyncSoft.SQLDb.LabResults()
                Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()

                Dim lItems As New List(Of DBConnect)
                Dim lLabResults As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Try

                    Me.Cursor = Cursors.WaitCursor

                    Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

                    id = IntegerEnteredIn(cells, Me.colID)

                    Dim specimenNo As String = RevertText(StringEnteredIn(cells, Me.colSpecimenNo, "Specimen No!!"))
                    Dim testCode As String = StringEnteredIn(cells, Me.colTestCode, "Test code!")
                    Dim testDate As Date = DateTimeEnteredIn(cells, Me.colTestDate, "Test Date!")
                    Dim testTime As String = StringMayBeEnteredIn(cells, Me.colTestTime)
                    Dim testDateTime As Date
                    If IsDate(testDate.ToShortDateString() + " " + testTime) Then
                        testDateTime = CDate(testDate.ToShortDateString() + " " + testTime)
                    Else : testDateTime = testDate
                    End If
                    Dim normalRange As String = StringMayBeEnteredIn(cells, Me.colNormalRange)
                    Dim result As String
                    Dim resultFlag As String = StringEnteredIn(cells, Me.colResultFlag, "Result Flag!")
                    Dim unitMeasure As String = StringMayBeEnteredIn(cells, Me.colUnitMeasure)
                    Dim report As String = StringMayBeEnteredIn(cells, Me.colReport)
                    Dim labTechnologist As String = Me.GetStaffNo(StringEnteredIn(cells, Me.colLabTechnologist, "Technologist!"))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim labRequests As DataTable = oLabRequests.GetLabRequests(RevertText(specimenNo)).Tables("LabRequests")
                    Dim visitNo As String = CStr(labRequests.Rows(0).Item("VisitNo"))
                    Dim visits As DataTable = oVisits.GetVisits(RevertText(visitNo)).Tables("Visits")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim labTests As DataTable = oLabTests.GetLabTests(testCode).Tables("LabTests")
                    Dim hasSubTests As Boolean = CBool(labTests.Rows(0).Item("HasSubTests"))
                    Dim resultDataType As String = CStr(labTests.Rows(0).Item("ResultDataType"))

                    If Not hasSubTests Then
                        result = StringEnteredIn(cells, Me.colResult, "Result!")
                        Select Case resultDataType
                            Case _Number, _Decimal
                                If Not IsNumeric(result) Then Throw New ArgumentException("Result should be numeric!")
                        End Select
                    Else : result = StringMayBeEnteredIn(cells, Me.colResult)
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With oLabResults

                        .SpecimenNo = specimenNo
                        .TestCode = testCode
                        .TestDateTime = testDateTime
                        .NormalRange = normalRange
                        .Result = result
                        If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.ResultFlag, resultFlag)) Then
                            Throw New ArgumentException("Result flag has wrong value!")
                        Else : .ResultFlagID = GetLookupDataID(LookupObjects.ResultFlag, resultFlag)
                        End If
                        If unitMeasure.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                            .UnitMeasure = String.Empty
                        Else : .UnitMeasure = unitMeasure
                        End If
                        .Report = report
                        .LabTechnologist = labTechnologist
                        .EntryModeID = oEntryModeID.Imported
                        .LoginID = CurrentUser.LoginID

                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lLabResults.Add(oLabResults)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = testCode
                            .ItemCategoryID = oItemCategoryID.Test
                            .LastUpdate = testDateTime
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Done
                        End With
                        lItems.Add(oItems)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lLabResults, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))

                    records = DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    savedRows.Add(rowNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me._ErrorLog.Append("*** Imported record ID " + id.ToString() + ": " + ex.Message)
                    Me._ErrorLog.AppendLine()
                    Me._ErrorLog.AppendLine()

                Finally
                    Me.Cursor = Cursors.Default

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me._ErrorLog.Length > 0 Then
                Me.fbnErrorLog.Enabled = True
                Me.fbnExport.Visible = True
            Else
                Me.fbnErrorLog.Enabled = False
                Me.fbnExport.Visible = False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim saveMSG As String = "{" + savedRows.Count.ToString() + "} Records saved successfully and {" +
                                    (Me.dgvImportedData.RowCount - savedRows.Count).ToString() + "} failed."
            Me.lblSaveReport.Text = saveMSG

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = savedRows.Count - 1 To 0 Step -1
                Me.dgvImportedData.Rows.RemoveAt(savedRows.Item(pos))
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetStaffNo(ByVal fullName As String) As String

        Dim staffNo As String = String.Empty

        Try

            For Each dr As DataRow In staff.Select("FullName = '" + fullName + "'")
                staffNo = dr.Item("StaffNo").ToString()
            Next

            If String.IsNullOrEmpty(staffNo) Then staffNo = fullName

            Return staffNo

        Catch ex As Exception
            Return fullName

        End Try

    End Function

    Private Sub fbnErrorLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnErrorLog.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim importLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\LabResults Import Log.txt"

            File.WriteAllText(importLogFile, Me._ErrorLog.ToString())

            If File.Exists(importLogFile) Then
                Process.Start(importLogFile)
            Else : DisplayMessage("No Import Error Message Logged!")
            End If

        Catch IOeX As IOException
            ErrorMessage(IOeX)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExport.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ExportToExcel(Me.dgvImportedData, Me.stbWorksheetName.Text)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class