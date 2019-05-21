
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.Win.Controls

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class frmImportBillCustomerMembers

#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
#End Region

    Private Sub frmImportBillCustomerMembers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Dim where As String = "where [Medical Card No] is not null and [Account No] is not null"

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
                    .Item(Me.colMedicalCardNo.Name, pos).Value = StringMayBeEnteredIn(row, "Medical Card No")
                    .Item(Me.colAccountNo.Name, pos).Value = StringMayBeEnteredIn(row, "Account No")
                    .Item(Me.colSurname.Name, pos).Value = StringMayBeEnteredIn(row, "Surname")
                    .Item(Me.colFirstName.Name, pos).Value = StringMayBeEnteredIn(row, "First Name")
                    .Item(Me.colMiddleName.Name, pos).Value = StringMayBeEnteredIn(row, "Other Name")
                    If IsDBNull(importedData.Rows(pos).Item("Policy Start Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Policy Start Date")) Then
                        .Item(Me.colPolicyStartDate.Name, pos).Value = AppData.NullDateValue
                    Else : .Item(Me.colPolicyStartDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Policy Start Date")))
                    End If
                    If IsDBNull(importedData.Rows(pos).Item("Policy End Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Policy End Date")) Then
                        .Item(Me.colPolicyEndDate.Name, pos).Value = AppData.NullDateValue
                    Else : .Item(Me.colPolicyEndDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Policy End Date")))
                    End If
                    .Item(Me.colCreditLimit.Name, pos).Value = DecimalMayBeEnteredIn(row, "Credit Limit")
                    .Item(Me.colMemberStatus.Name, pos).Value = StringMayBeEnteredIn(row, "Member Status")

                End With
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for To-Bill Customer Members!"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSaveAll.Click

        Dim savedRows As New List(Of Integer)

        Try
            Me.Cursor = Cursors.WaitCursor

            Me._ErrorLog.Remove(0, Me._ErrorLog.Length)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvImportedData.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for To-Bill Customer Members!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 1

                Dim id As Integer

                Try

                    Me.Cursor = Cursors.WaitCursor

                    Using oBillCustomerMembers As New SyncSoft.SQLDb.BillCustomerMembers()

                        Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

                        id = IntegerEnteredIn(cells, Me.colID)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim memberStatus As String = StringEnteredIn(cells, Me.colMemberStatus, "Member Status!")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        With oBillCustomerMembers

                            .MedicalCardNo = StringEnteredIn(cells, Me.colMedicalCardNo)
                            .AccountNo = RevertText(StringEnteredIn(cells, Me.colAccountNo))
                            .Surname = StringEnteredIn(cells, Me.colSurname, "Surname!")
                            .FirstName = StringEnteredIn(cells, Me.colFirstName, "First Name!")
                            .MiddleName = StringMayBeEnteredIn(cells, Me.colMiddleName)
                            .PolicyStartDate = DateEnteredIn(cells, Me.colPolicyStartDate, "Policy Start Date!")
                            .PolicyEndDate = DateEnteredIn(cells, Me.colPolicyEndDate, "Policy End Date!")
                            .CreditLimit = DecimalMayBeEnteredIn(cells, Me.colCreditLimit)
                            If String.IsNullOrEmpty(GetLookupDataID(LookupCommObjects.Status, memberStatus)) Then
                                Throw New ArgumentException("Member Status has wrong value!")
                            Else : .MemberStatusID = GetLookupDataID(LookupCommObjects.Status, memberStatus)
                            End If

                            .LoginID = CurrentUser.LoginID

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            .Save()
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With

                    End Using

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

            Dim saveMSG As String = "{" + savedRows.Count.ToString() + "} Records saved successfully and {" + (Me.dgvImportedData.RowCount - savedRows.Count).ToString() + "} failed."
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

    Private Sub fbnErrorLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnErrorLog.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim importLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\To-Bill Customer Members Import Log.txt"

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