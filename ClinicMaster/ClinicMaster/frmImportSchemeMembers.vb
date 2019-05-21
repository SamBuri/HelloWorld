
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class frmImportSchemeMembers

#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
#End Region

    Private Sub frmImportSchemeMembers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Dim where As String = "where [Medical Card No] is not null"

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
                    .Item(Me.colMemberType.Name, pos).Value = StringMayBeEnteredIn(row, "Member Type")
                    .Item(Me.colMainMemberNo.Name, pos).Value = StringMayBeEnteredIn(row, "Main Member No")
                    .Item(Me.colMedicalCardNo.Name, pos).Value = StringMayBeEnteredIn(row, "Medical Card No")
                    .Item(Me.colCompanyNo.Name, pos).Value = StringMayBeEnteredIn(row, "Company No")
                    .Item(Me.colPolicyNo.Name, pos).Value = StringMayBeEnteredIn(row, "Policy No")
                    .Item(Me.colReferenceNo.Name, pos).Value = StringMayBeEnteredIn(row, "Reference No")
                    .Item(Me.colSurname.Name, pos).Value = StringMayBeEnteredIn(row, "Surname")
                    .Item(Me.colFirstName.Name, pos).Value = StringMayBeEnteredIn(row, "First Name")
                    .Item(Me.colMiddleName.Name, pos).Value = StringMayBeEnteredIn(row, "Other Name")
                    If IsDBNull(importedData.Rows(pos).Item("Birth Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Birth Date")) Then
                        .Item(Me.colBirthDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colBirthDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Birth Date")))
                    End If
                    .Item(Me.colGender.Name, pos).Value = StringMayBeEnteredIn(row, "Gender")
                    .Item(Me.colAddress.Name, pos).Value = StringMayBeEnteredIn(row, "Address")
                    .Item(Me.colPhoneWork.Name, pos).Value = StringMayBeEnteredIn(row, "Phone Work")
                    .Item(Me.colPhoneMobile.Name, pos).Value = StringMayBeEnteredIn(row, "Phone Mobile")
                    .Item(Me.colPhoneHome.Name, pos).Value = StringMayBeEnteredIn(row, "Phone Home")
                    .Item(Me.colEmail.Name, pos).Value = StringMayBeEnteredIn(row, "E-mail")
                    If IsDBNull(importedData.Rows(pos).Item("Join Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Join Date")) Then
                        .Item(Me.colJoinDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colJoinDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Join Date")))
                    End If
                    .Item(Me.colRelationship.Name, pos).Value = StringMayBeEnteredIn(row, "Relationship")
                    If IsDBNull(importedData.Rows(pos).Item("Policy Start Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Policy Start Date")) Then
                        .Item(Me.colPolicyStartDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colPolicyStartDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Policy Start Date")))
                    End If
                    If IsDBNull(importedData.Rows(pos).Item("Policy End Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Policy End Date")) Then
                        .Item(Me.colPolicyEndDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colPolicyEndDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Policy End Date")))
                    End If

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for Scheme Members!"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvImportedData.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for Scheme Members!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 1

                Dim id As Integer
                Dim oStatusID As New LookupCommDataID.StatusID

                Try

                    Me.Cursor = Cursors.WaitCursor

                    Using oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

                        Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

                        id = IntegerEnteredIn(cells, Me.colID)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim gender As String = StringEnteredIn(cells, Me.colGender, "Gender!")
                        Dim memberType As String = StringEnteredIn(cells, Me.colMemberType, "Member Type!")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        With oSchemeMembers

                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.MemberType, memberType)) Then
                                Throw New ArgumentException("Member Type has wrong value!")
                            Else : .MemberTypeID = GetLookupDataID(LookupObjects.MemberType, memberType)
                            End If
                            .MainMemberNo = RevertText(StringMayBeEnteredIn(cells, Me.colMainMemberNo))
                            .MedicalCardNo = RevertText(StringEnteredIn(cells, Me.colMedicalCardNo))
                            .CompanyNo = RevertText(StringEnteredIn(cells, Me.colCompanyNo))
                            .PolicyNo = RevertText(StringEnteredIn(cells, Me.colPolicyNo))
                            .ReferenceNo = StringMayBeEnteredIn(cells, Me.colReferenceNo)
                            .Surname = StringEnteredIn(cells, Me.colSurname, "Surname!")
                            .FirstName = StringEnteredIn(cells, Me.colFirstName, "First Name!")
                            .MiddleName = StringMayBeEnteredIn(cells, Me.colMiddleName)
                            .BirthDate = DateEnteredIn(cells, Me.colBirthDate, "Birth Date!")
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.Gender, gender)) Then
                                Throw New ArgumentException("Gender has wrong value!")
                            Else : .GenderID = GetLookupDataID(LookupObjects.Gender, gender)
                            End If
                            .Address = StringMayBeEnteredIn(cells, Me.colAddress)
                            .PhoneWork = StringMayBeEnteredIn(cells, Me.colPhoneWork)
                            .PhoneMobile = StringMayBeEnteredIn(cells, Me.colPhoneMobile)
                            .PhoneHome = StringMayBeEnteredIn(cells, Me.colPhoneHome)
                            .Email = StringMayBeEnteredIn(cells, Me.colEmail)
                            .Photo = Nothing
                            .Fingerprint = Nothing
                            .JoinDate = DateEnteredIn(cells, Me.colJoinDate, "Join Date!")
                            .Relationship = StringMayBeEnteredIn(cells, Me.colRelationship)
                            .PolicyStartDate = DateEnteredIn(cells, Me.colPolicyStartDate, "Policy Start Date!")
                            .PolicyEndDate = DateEnteredIn(cells, Me.colPolicyEndDate, "Policy End Date!")
                            .MemberStatusID = oStatusID.Active
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

            Dim importLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\Scheme Members Import Log.txt"

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