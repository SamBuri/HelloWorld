
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

Public Class frmImportPatients

#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
#End Region

    Private Sub frmImportPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Dim where As String = "where [Patient No] is not null"

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
                    .Item(Me.colPatientNo.Name, pos).Value = StringMayBeEnteredIn(row, "Patient No")
                    .Item(Me.colReferenceNo.Name, pos).Value = StringMayBeEnteredIn(row, "Reference No")
                    .Item(Me.colSurname.Name, pos).Value = StringMayBeEnteredIn(row, "Surname")
                    .Item(Me.colFirstName.Name, pos).Value = StringMayBeEnteredIn(row, "First Name")
                    .Item(Me.colMiddleName.Name, pos).Value = StringMayBeEnteredIn(row, "Other Name")
                    If IsDBNull(importedData.Rows(pos).Item("Birth Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Birth Date")) Then
                        .Item(Me.colBirthDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colBirthDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Birth Date")))
                    End If
                    .Item(Me.colGender.Name, pos).Value = StringMayBeEnteredIn(row, "Gender")
                    .Item(Me.colBirthPlace.Name, pos).Value = StringMayBeEnteredIn(row, "Birth Place")
                    .Item(Me.colAddress.Name, pos).Value = StringMayBeEnteredIn(row, "Address")
                    .Item(Me.colOccupation.Name, pos).Value = StringMayBeEnteredIn(row, "Occupation")
                    .Item(Me.colPhone.Name, pos).Value = StringMayBeEnteredIn(row, "Phone No")
                    .Item(Me.colEmail.Name, pos).Value = StringMayBeEnteredIn(row, "E-Mail")
                    If IsDBNull(importedData.Rows(pos).Item("Join Date")) OrElse Not IsDate(importedData.Rows(pos).Item("Join Date")) Then
                        .Item(Me.colJoinDate.Name, pos).Value = String.Empty
                    Else : .Item(Me.colJoinDate.Name, pos).Value = FormatDate(CDate(importedData.Rows(pos).Item("Join Date")))
                    End If
                    .Item(Me.colLocation.Name, pos).Value = StringMayBeEnteredIn(row, "Location")
                    .Item(Me.colNOKName.Name, pos).Value = StringMayBeEnteredIn(row, "NOK Name")
                    .Item(Me.colNOKRelationship.Name, pos).Value = StringMayBeEnteredIn(row, "NOK Relationship")
                    .Item(Me.colNOKPhoneNo.Name, pos).Value = StringMayBeEnteredIn(row, "NOK Phone No")
                    .Item(Me.colDefaultBillMode.Name, pos).Value = StringMayBeEnteredIn(row, "Default Bill Mode")
                    .Item(Me.colDefaultBillNo.Name, pos).Value = StringMayBeEnteredIn(row, "Default Bill No")
                    .Item(Me.colDefaultMemberCardNo.Name, pos).Value = StringMayBeEnteredIn(row, "Default Member Card No")
                    .Item(Me.colDefaultMainMemberName.Name, pos).Value = StringMayBeEnteredIn(row, "Default Main Member Name")
                    .Item(Me.colEnforceDefaultBillNo.Name, pos).Value = BooleanMayBeEnteredIn(row, "Enforce Default Bill")
                    .Item(Me.colHideDetails.Name, pos).Value = BooleanMayBeEnteredIn(row, "Hide Details")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for Patients!"
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
            If Me.dgvImportedData.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for Patients!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 1

                Dim id As Integer

                Dim oBillModesID As New LookupDataID.BillModesID()
                Dim oStatusID As New LookupCommDataID.StatusID()

                Try

                    Me.Cursor = Cursors.WaitCursor

                    Using oPatients As New SyncSoft.SQLDb.Patients()

                        Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

                        id = IntegerEnteredIn(cells, Me.colID)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim gender As String = StringEnteredIn(cells, Me.colGender, "Gender!")
                        Dim defaultBillMode As String = StringEnteredIn(cells, Me.colDefaultBillMode, "Default Bill Mode!")
                        Dim defaultBillNo As String = StringMayBeEnteredIn(cells, Me.colDefaultBillNo)
                        If String.IsNullOrEmpty(defaultBillNo) Then defaultBillNo = GetLookupDataDes(oBillModesID.Cash).ToUpper()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        With oPatients

                            .PatientNo = RevertText(StringEnteredIn(cells, Me.colPatientNo))
                            .ReferenceNo = StringMayBeEnteredIn(cells, Me.colReferenceNo)
                            .LastName = StringEnteredIn(cells, Me.colSurname, "Surname!")
                            .FirstName = StringEnteredIn(cells, Me.colFirstName, "First Name!")
                            .MiddleName = StringMayBeEnteredIn(cells, Me.colMiddleName)
                            .BirthDate = DateEnteredIn(cells, Me.colBirthDate, "Birth Date!")
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.Gender, gender)) Then
                                Throw New ArgumentException("Gender has wrong value!")
                            Else : .GenderID = GetLookupDataID(LookupObjects.Gender, gender)
                            End If
                            .Photo = Nothing
                            .FingerPrint = Nothing
                            .JoinDate = DateEnteredIn(cells, Me.colJoinDate, "Join Date!")
                            .Address = StringMayBeEnteredIn(cells, Me.colAddress)
                            .Phone = StringMayBeEnteredIn(cells, Me.colPhone)
                            .BirthPlace = StringMayBeEnteredIn(cells, Me.colBirthPlace)
                            .Occupation = StringMayBeEnteredIn(cells, Me.colOccupation)
                            .Email = StringMayBeEnteredIn(cells, Me.colEmail)
                            .Location = StringMayBeEnteredIn(cells, Me.colLocation)
                            .NOKName = StringMayBeEnteredIn(cells, Me.colNOKName)
                            .NOKRelationship = StringMayBeEnteredIn(cells, Me.colNOKRelationship)
                            .NOKPhone = StringMayBeEnteredIn(cells, Me.colNOKPhoneNo)
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.BillModes, defaultBillMode)) Then
                                Throw New ArgumentException("Default Bill Mode has wrong value!")
                            Else : .DefaultBillModesID = GetLookupDataID(LookupObjects.BillModes, defaultBillMode)
                            End If
                            .DefaultBillNo = RevertText(defaultBillNo)
                            .DefaultMemberCardNo = StringMayBeEnteredIn(cells, Me.colDefaultMemberCardNo)
                            .DefaultMainMemberName = StringMayBeEnteredIn(cells, Me.colDefaultMainMemberName)
                            .EnforceDefaultBillNo = BooleanMayBeEnteredIn(cells, Me.colEnforceDefaultBillNo)
                            .HideDetails = BooleanMayBeEnteredIn(cells, Me.colHideDetails)
                            .StatusID = oStatusID.Active
                            .LoginID = CurrentUser.LoginID

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            .Save()
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    savedRows.Add(rowNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me._ErrorLog.Append("*** Imported record ID " + id.ToString() + ": " + ex.Message)
                    Me._ErrorLog.AppendLine()
                    Me._ErrorLog.AppendLine()

                Finally
                    Me.Cursor = Cursors.Default

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me._ErrorLog.Length > 0 Then
                Me.fbnErrorLog.Enabled = True
                Me.fbnExport.Visible = True
            Else
                Me.fbnErrorLog.Enabled = False
                Me.fbnExport.Visible = False
            End If

            Dim saveMSG As String = "{" + savedRows.Count.ToString() + "} Records saved successfully and {" + (Me.dgvImportedData.RowCount - savedRows.Count).ToString() + "} failed."
            Me.lblSaveReport.Text = saveMSG

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = savedRows.Count - 1 To 0 Step -1
                Me.dgvImportedData.Rows.RemoveAt(savedRows.Item(pos))
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnErrorLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnErrorLog.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim importLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\Patients Import Log.txt"

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