
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class frmImportLabTests

#Region " Fields "
    Private _ErrorLog As New StringBuilder(String.Empty)
#End Region

    Private Sub frmImportLabTests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Dim where As String = "where [Test Code] is not null"
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
                    .Item(Me.colTestCode.Name, pos).Value = StringMayBeEnteredIn(row, "Test Code")
                    .Item(Me.colTestName.Name, pos).Value = StringMayBeEnteredIn(row, "Test Name")
                    .Item(Me.colSpecimenType.Name, pos).Value = StringMayBeEnteredIn(row, "Specimen Type")
                    .Item(Me.colLabs.Name, pos).Value = StringMayBeEnteredIn(row, "Lab")
                    .Item(Me.colNormalRange.Name, pos).Value = StringMayBeEnteredIn(row, "Normal Range")
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringMayBeEnteredIn(row, "Unit Measure")
                    .Item(Me.colTestFee.Name, pos).Value = StringMayBeEnteredIn(row, "Test Fee")
                    .Item(Me.colResultDataType.Name, pos).Value = StringMayBeEnteredIn(row, "Result Type of Data")
                    .Item(Me.ColTubeType.Name, pos).Value = StringMayBeEnteredIn(row, "Tube Type")
                    .Item(Me.ColDesc.Name, pos).Value = StringMayBeEnteredIn(row, "Description")
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsImported.Text = importedData.Rows.Count.ToString() + " record(s) were imported for Lab Tests!"
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
            If Me.dgvImportedData.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for Lab Tests!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvImportedData.RowCount - 1

                Dim id As Integer

                Dim oBillModesID As New LookupDataID.BillModesID()
                Dim oStatusID As New LookupCommDataID.StatusID()

                Try

                    Me.Cursor = Cursors.WaitCursor

                    Using oLabTests As New SyncSoft.SQLDb.LabTests()

                        Dim cells As DataGridViewCellCollection = Me.dgvImportedData.Rows(rowNo).Cells

                        id = IntegerEnteredIn(cells, Me.colID)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim specimenType As String = StringEnteredIn(cells, Me.colSpecimenType, "Specimen Type!")
                        Dim tubeType As String = StringEnteredIn(cells, Me.ColTubeType, "Tube Type!")
                        Dim labs As String = StringEnteredIn(cells, Me.colLabs, "Labs!")
                        Dim unitMeasure As String = StringEnteredIn(cells, Me.colUnitMeasure, "Unit Measure!")
                        Dim resultDataType As String = StringEnteredIn(cells, Me.colResultDataType, "Result Data Type!")
                        
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oLabTests

                            .TestCode = StringEnteredIn(cells, Me.colTestCode)
                            .TestName = StringEnteredIn(cells, Me.colTestName, "Test Name!")
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.SpecimenType, specimenType)) Then
                                Throw New ArgumentException("Specimen Type has wrong value!")
                            Else : .SpecimenTypeID = GetLookupDataID(LookupObjects.SpecimenType, specimenType)
                            End If
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.Labs, labs)) Then
                                Throw New ArgumentException("Labs has wrong value!")
                            Else : .LabsID = GetLookupDataID(LookupObjects.Labs, labs)
                            End If
                            .NormalRange = StringMayBeEnteredIn(cells, Me.colNormalRange)
                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.UnitMeasure, unitMeasure)) Then
                                Throw New ArgumentException("Unit Measure has wrong value!")
                            Else : .UnitMeasureID = GetLookupDataID(LookupObjects.UnitMeasure, unitMeasure)
                            End If
                            .TestFee = DecimalEnteredIn(cells, Me.colTestFee, False, "Test Fee!")
                            If String.IsNullOrEmpty(GetLookupDataID(LookupCommObjects.SearchDataType, resultDataType)) Then
                                Throw New ArgumentException("Result Data Type has wrong value!")
                            Else : .ResultDataTypeID = GetLookupDataID(LookupCommObjects.SearchDataType, resultDataType)
                            End If

                            If String.IsNullOrEmpty(GetLookupDataID(LookupObjects.TubeType, tubeType)) Then
                                Throw New ArgumentException("Tube Type has wrong value!")
                            Else : .TubeType = GetLookupDataID(LookupObjects.TubeType, tubeType)
                            End If
                            .TestDescription = StringMayBeEnteredIn(cells, Me.ColDesc)
                            .Hidden = False
                            .RequiresResultsApproval = False
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

    Private Sub fbnErrorLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnErrorLog.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim importLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\LabTests Import Log.txt"

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