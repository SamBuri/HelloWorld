
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Lookup
Imports SyncSoft.Common.Classes
Imports SyncSoft.Common.Methods
Imports SyncSoft.Security.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports System.Data.SqlClient

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmGetExternalLabResults

#Region " Fields "

    Private _ItemCode As String
    Private _ImportDataInfo As DataTable
    Private _SpecimenNo As String
    Private oDatabaseTypeID As New LookupCommDataID.DatabaseTypeID()
    Private oConnectionModeID As New LookupCommDataID.ConnectionModeID()

#End Region

    Private Sub frmExternalLabResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "External Lab Results"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Now.AddMinutes(-15)
            Me.dtpEndDateTime.Value = Now

            ExternalLabResults.Results.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboImportSource.DataSource = Me._ImportDataInfo

            Me.cboImportSource.DisplayMember = "SourceCaption"
            Me.cboImportSource.ValueMember = "SourceName"

            Me.cboImportSource.SelectedIndex = -1
            Me.cboImportSource.SelectedIndex = -1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(Me._SpecimenNo) Then Me.stbSpecimenNo.Text = Me._SpecimenNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        Dim oImportDataInfo As New SyncSoft.SQLDb.ImportDataInfo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date and Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date and Time")

            If endDateTime < startDateTime Then Throw New ArgumentException("End Date and Time can't be before Start Date and Time!")

            Dim sourceName As String = StringValueEnteredIn(Me.cboImportSource, "Import Source!")
            Dim sourceCaption As String = StringEnteredIn(Me.cboImportSource, "Source Caption!")
            Dim importDataInfo As DataTable = oImportDataInfo.GetImportDataInfo(Me._ItemCode, sourceName, sourceCaption).Tables("ImportDataInfo")
            Dim row As DataRow = importDataInfo.Rows(0)

            Dim databaseTypeID As String = StringEnteredIn(row, "DatabaseTypeID")
            Dim passWord As String = Decrypt(StringEnteredIn(row, "ImportPassword"))
            Dim queryName As String = StringEnteredIn(row, "SP_Name")

            Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.stbSpecimenNo))
            If String.IsNullOrEmpty(specimenNo) OrElse specimenNo.Equals("*") OrElse specimenNo.Equals("%") Then
                specimenNo = String.Empty
            Else : specimenNo = "%" + specimenNo + "%"
            End If

            If databaseTypeID.ToUpper().Equals(oDatabaseTypeID.MSAccess.ToUpper()) Then
                Me.ShowAccessExternalLabResults(startDateTime, endDateTime, queryName, passWord)

            ElseIf databaseTypeID.ToUpper().Equals(oDatabaseTypeID.MSSQLServer.ToUpper()) Then
                Me.ShowSQLServerExternalLabResults(startDateTime, endDateTime, specimenNo)

            Else : Me.ShowSQLServerExternalLabResults(startDateTime, endDateTime, specimenNo)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Function ExternalConString() As String

        Dim conBuilder As New SqlConnectionStringBuilder()
        Dim oImportDataInfo As New SyncSoft.SQLDb.ImportDataInfo()

        Try

            Dim sourceName As String = StringValueEnteredIn(Me.cboImportSource, "Import Source!")
            Dim sourceCaption As String = StringEnteredIn(Me.cboImportSource, "Source Caption!")
            Dim importDataInfo As DataTable = oImportDataInfo.GetImportDataInfo(Me._ItemCode, sourceName, sourceCaption).Tables("ImportDataInfo")
            Dim row As DataRow = importDataInfo.Rows(0)

            Dim databaseTypeID As String = StringEnteredIn(row, "DatabaseTypeID")
            Dim connectionModeID As String = StringEnteredIn(row, "ConnectionModeID")

            Dim serverName As String = StringEnteredIn(row, "ImportServer")
            Dim userName As String = StringEnteredIn(row, "ImportLogin")
            Dim passWord As String = Decrypt(StringEnteredIn(row, "ImportPassword"))

            If databaseTypeID.ToUpper().Equals(oDatabaseTypeID.MSSQLServer.ToUpper()) Then

                If connectionModeID.ToUpper().Equals(oConnectionModeID.WindowsAuthentication.ToUpper()) Then

                    conBuilder.Clear()
                    conBuilder("Server") = serverName
                    conBuilder.InitialCatalog = sourceName
                    conBuilder("Integrated Security") = "SSPI"
                    conBuilder.PersistSecurityInfo = False
                    'conBuilder.PacketSize = 4096
                    Return conBuilder.ConnectionString()

                ElseIf connectionModeID.ToUpper().Equals(oConnectionModeID.SQLServerAuthentication.ToUpper()) Then

                    With conBuilder
                        .Clear()
                        .DataSource = serverName
                        .InitialCatalog = sourceName
                        .UserID = userName
                        .Password = passWord
                    End With
                    Return conBuilder.ConnectionString

                Else
                    With conBuilder
                        .Clear()
                        .DataSource = serverName
                        .InitialCatalog = sourceName
                        .UserID = userName
                        .Password = passWord
                    End With
                    Return conBuilder.ConnectionString

                End If

            Else
                With conBuilder
                    .Clear()
                    .DataSource = serverName
                    .InitialCatalog = sourceName
                    .UserID = userName
                    .Password = passWord
                End With
                Return conBuilder.ConnectionString

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub ShowSQLServerExternalLabResults(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal specimenNo As String)

        Dim importDataInfo As DataTable
        Dim oImportDataInfo As New SyncSoft.SQLDb.ImportDataInfo()
        Dim oldConString As String = oImportDataInfo.ConString

        Try
            Me.Cursor = Cursors.WaitCursor

            oImportDataInfo.SetConString(SQLConnectionMode.None, Me.ExternalConString())

            ' Load from ImportDataInfo
            Dim sourceCaption As String = StringEnteredIn(Me.cboImportSource, "Source Caption!")

            If Not String.IsNullOrEmpty(specimenNo) Then
                importDataInfo = oImportDataInfo.GetExternalLabResults(sourceCaption, startDateTime, endDateTime, specimenNo).Tables("ImportDataInfo")
            Else : importDataInfo = oImportDataInfo.GetExternalLabResults(sourceCaption, startDateTime, endDateTime).Tables("ImportDataInfo")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExternalLabResults, importDataInfo)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                                     FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

            If importDataInfo.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + importDataInfo.Rows.Count.ToString()

        Catch ex As Exception
            Throw ex

        Finally

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oImportDataInfo.SetConString(SQLConnectionMode.None, oldConString)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowAccessExternalLabResults(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal queryName As String, ByVal password As String)


        Try
            Me.Cursor = Cursors.WaitCursor

            Dim parameters As New ArrayList()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With parameters
                .Add(New Parameter("StartDateTime", startDateTime))
                .Add(New Parameter("EndDateTime", endDateTime))
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sourceName As String = StringValueEnteredIn(Me.cboImportSource, "Import Source!")
            Dim importedData As DataTable = ImportFromAccess(sourceName, queryName, parameters, password)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExternalLabResults, importedData)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                                     FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

            If importedData.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + importedData.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvExternalLabResults_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExternalLabResults.CellDoubleClick

        Try

            Dim splitCHAR As Char = ","c
            Dim search As Char = "="c

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ExternalLabResults.Results.Clear()
            If e.RowIndex < 0 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With ExternalLabResults.Results

                Dim results() As String = Me.dgvExternalLabResults.Item(Me.colResults.Name, e.RowIndex).Value.ToString().Split(splitCHAR)

                For count As Integer = results.GetLowerBound(0) To results.GetUpperBound(0)

                    Dim value As String = results(count)
                    Dim pos As Short = CShort(value.IndexOf(search))
                    If pos < 0 Then
                        .Add(value.Trim(), value.Trim())
                    Else : .Add(value.Substring(0, pos).Trim().ToUpper(), value.Substring(pos + 1).Trim())
                    End If

                Next

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvExternalLabResults.ColumnCount < 1 OrElse Me.dgvExternalLabResults.RowCount < 1 Then
            Me.cmsAlertListCopy.Enabled = False
            Me.cmsAlertListSelectAll.Enabled = False
        Else
            Me.cmsAlertListCopy.Enabled = True
            Me.cmsAlertListSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsAlertListCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvExternalLabResults.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvExternalLabResults))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvExternalLabResults.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class