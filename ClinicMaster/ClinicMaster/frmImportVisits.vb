
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports System.IO
Imports System.Text

Public Class frmImportVisits

#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
#End Region

    Private Sub frmImportVisits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Dim where As String = "where [Visit No] is not null"

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
                    .Item(Me.colVisitNo.Name, pos).Value = StringMayBeEnteredIn(row, "Visit No")
                    .Item(Me.colPatientNo.Name, pos).Value = StringMayBeEnteredIn(row, "Patient No")
                    If IsDBNull(importedData.Rows(pos).Item("Visit Date")) OrElse _
                    Not IsDate(importedData.Rows(pos).Item("Visit Date")) Then
                        .Item(Me.colVisitDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colVisitDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Visit Date")))
                    End If
                    .Item(Me.colVisitCategory.Name, pos).Value = StringMayBeEnteredIn(row, "Visit Category")
                    .Item(Me.colReferredBy.Name, pos).Value = StringMayBeEnteredIn(row, "Referred By")
                    .Item(Me.colBillModes.Name, pos).Value = StringMayBeEnteredIn(row, "To-Bill Mode")
                    .Item(Me.colAccountNo.Name, pos).Value = StringMayBeEnteredIn(row, "To-Bill Account")
                    .Item(Me.colVisitStatus.Name, pos).Value = StringMayBeEnteredIn(row, "Visit Status")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for Visits!"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    'Private Sub fbnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSaveAll.Click

    '    Dim savedRows As New List(Of Integer)

    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        Me._ErrorLog.Remove(0, Me._ErrorLog.Length)

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        If Me.dgvImportedData.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for Visits!")
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 1

    '            Dim id As Integer

    '            Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
    '            Dim ARTCurrentlyOn As New DataTable()

    '            Dim transactions As New List(Of TransactionList(Of DBConnect))
    '            Dim lVisits As New List(Of DBConnect)
    '            Dim lItems As New List(Of DBConnect)

    '            Dim oPayStatusID As New LookupDataID.PayStatusID()
    '            Dim oARTStatusID As New LookupDataID.ARTStatusID()
    '            Dim oItemStatusID As New LookupDataID.ItemStatusID()
    '            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

    '            Try

    '                Me.Cursor = Cursors.WaitCursor

    '                Using oVisits As New SyncSoft.SQLDb.Visits()

    '                    Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

    '                    id = IntegerEnteredIn(cells, Me.colID)

    '                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                    Dim visitCategory As String = StringEnteredIn(cells, Me.colVisitCategory, "Visit Category!")
    '                    Dim billModes As String = StringEnteredIn(cells, Me.colBillModes, "To-Bill Modes!")
    '                    Dim visitStatus As String = StringEnteredIn(cells, Me.colVisitStatus, "Visit Status!")

    '                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                    With oVisits

    '                        .VisitNo = RevertText(StringEnteredIn(cells, Me.colVisitNo))
    '                        .PatientNo = RevertText(StringEnteredIn(cells, Me.colPatientNo))
    '                        .VisitDate = DateEnteredIn(cells, Me.colVisitDate, "Visit Date!")
    '                        If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.VisitCategory, visitCategory)) Then
    '                            Throw New ArgumentException("Visit Category has wrong value!")
    '                        Else : .VisitCategoryID = GetLookupDataID(LookupObjects.VisitCategory, visitCategory)
    '                        End If
    '                        .ReferredBy = StringMayBeEnteredIn(cells, Me.colReferredBy)
    '                        If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.BillModes, billModes)) Then
    '                            Throw New ArgumentException("To-Bill Modes has wrong value!")
    '                        Else : .BillModesID = GetLookupDataID(LookupObjects.BillModes, billModes)
    '                        End If
    '                        .AccountNo = StringEnteredIn(cells, Me.colAccountNo, "To-Bill Account!")
    '                        If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.VisitStatus, visitStatus)) Then
    '                            Throw New ArgumentException("Visit Status has wrong value!")
    '                        Else : .VisitStatusID = GetLookupDataID(LookupObjects.VisitStatus, visitStatus)
    '                        End If
    '                        .LoginID = CurrentUser.LoginID

    '                    End With

    '                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                    lVisits.Add(oVisits)
    '                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                    'If patient has come for consultation, then payment has to be effected
    '                    If oVisits.VisitCategoryID.ToUpper().Equals(oVisitCategoryID.Consultation.ToUpper()) Then

    '                        Using oItems As New SyncSoft.SQLDb.Items()

    '                            With oItems
    '                                .VisitNo = oVisits.VisitNo
    '                                .ItemCode = oVisitCategoryID.Consultation.ToUpper()
    '                                .Quantity = 1
    '                                .UnitPrice = Me.GetConsultationFee()
    '                                .ItemDetails = "Consultation Service"
    '                                .LastUpdate = oVisits.VisitDate
    '                                .ItemCategoryID = oItemCategoryID.Service
    '                                .ItemStatusID = oItemStatusID.Pending
    '                                .PayStatusID = oPayStatusID.NotPaid
    '                                .LoginID = CurrentUser.LoginID
    '                            End With

    '                            lItems.Add(oItems)

    '                        End Using

    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        transactions.Add(New TransactionList(Of DBConnect)(lVisits, Action.Save))
    '                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

    '                        DoTransactions(transactions)
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                    ElseIf oVisits.VisitCategoryID.ToUpper().Equals(oVisitCategoryID.Refill.ToUpper()) Then

    '                        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
    '                        Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()
    '                        Dim lDoctorVisits As New List(Of DBConnect)

    '                        'We need to get drugs picked from ART Regimen Details table and get to pay for drugs
    '                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        Using oARTRegimenDetails As New SyncSoft.SQLDb.ARTRegimenDetails()
    '                            ARTCurrentlyOn = oARTRegimenDetails.GetARTCurrentlyOn(oVisits.PatientNo, oARTStatusID.On).Tables("ARTCurrentlyOn")
    '                        End Using
    '                        If ARTCurrentlyOn.Rows.Count < 1 Then
    '                            Throw New ArgumentException("The Patient No: " + oVisits.PatientNo + ", has no ART Regimen registered yet or stopped ART. " + _
    '                                                        "You can't import refill category?")
    '                        End If
    '                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        Dim staffNo As String = CStr(ARTCurrentlyOn.Rows(0).Item("StaffNo"))


    '                        With oDoctorVisits
    '                            .VisitNo = oVisits.VisitNo
    '                            .StaffNo = staffNo
    '                            .LoginID = CurrentUser.LoginID
    '                        End With

    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        lDoctorVisits.Add(oDoctorVisits)
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                        For pos As Integer = 0 To ARTCurrentlyOn.Rows.Count - 1
    '                            Dim row As DataRow = ARTCurrentlyOn.Rows(pos)

    '                            Using oItems As New SyncSoft.SQLDb.Items()
    '                                With oItems
    '                                    .VisitNo = oVisits.VisitNo
    '                                    .ItemCode = StringEnteredIn(row, "DrugNo")
    '                                    .Quantity = IntegerEnteredIn(row, "Quantity")
    '                                    .UnitPrice = DecimalEnteredIn(row, "UnitPrice")
    '                                    .ItemDetails = StringEnteredIn(row, "Formula")
    '                                    .LastUpdate = oVisits.VisitDate
    '                                    .ItemCategoryID = oItemCategoryID.Drug
    '                                    .ItemStatusID = oItemStatusID.Pending
    '                                    .PayStatusID = oPayStatusID.NotPaid
    '                                    .LoginID = CurrentUser.LoginID
    '                                End With

    '                                lItems.Add(oItems)
    '                            End Using

    '                        Next

    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        transactions.Add(New TransactionList(Of DBConnect)(lVisits, Action.Save))
    '                        transactions.Add(New TransactionList(Of DBConnect)(lDoctorVisits, Action.Save))
    '                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

    '                        DoTransactions(transactions)
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                    Else : oVisits.Save()
    '                    End If

    '                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                End Using

    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                savedRows.Add(rowNo)
    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            Catch ex As Exception
    '                Me._ErrorLog.Append("*** Imported record ID " + id + ": " + ex.Message)
    '                Me._ErrorLog.AppendLine()
    '                Me._ErrorLog.AppendLine()

    '            Finally
    '                Me.Cursor = Cursors.Default

    '            End Try

    '        Next

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        If Me._ErrorLog.Length > 0 Then
    '            Me.fbnErrorLog.Enabled = True
    '            Me.fbnExport.Visible = True
    '        Else
    '            Me.fbnErrorLog.Enabled = False
    '            Me.fbnExport.Visible = False
    '        End If

    '        Dim saveMSG As String = "{" + savedRows.Count + "} Records saved successfully and {" + Me.dgvImportedData.RowCount - savedRows.Count + "} failed."
    '        Me.lblSaveReport.Text = saveMSG

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        For pos As Integer = savedRows.Count - 1 To 0 Step -1
    '            Me.dgvImportedData.Rows.RemoveAt(savedRows.Item(pos))
    '        Next

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        ErrorMessage(ex)

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try

    'End Sub

    Private Function GetConsultationFee(ByVal serviceCode As String) As Decimal

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oServices As New SyncSoft.SQLDb.Services()

            'We need to get service code picked from Services table and get the price
            Dim services As DataTable = oServices.GetServices(serviceCode).Tables("Services")
            Dim row As DataRow = Services.Rows(0)

            Return DecimalMayBeEnteredIn(row, "StandardFee")

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function GetCommaSeparatedDataID(ByVal source As String, ByVal objectID As Integer) As String

        Dim splitCHAR As Char = ","c
        Dim result As New StringBuilder(String.Empty)

        Try

            If String.IsNullOrEmpty(source.Trim()) Then Return String.Empty

            For Each dataDes As String In source.Replace(", ", ",").Split(splitCHAR)
                result.Append(GetLookupDataID(objectID, dataDes) + splitCHAR)
            Next

            If result.Length > 1 Then result.Remove(result.Length - 1, 1)

            Return result.ToString()

        Catch eX As Exception
            Throw eX

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

    Private Sub fbnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles fbnSaveAll.Click

    End Sub
End Class