
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

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Public Class frmImportDataInfo

#Region " Fields "
    Private oDatabaseTypeID As New LookupCommDataID.DatabaseTypeID()
    Private oConnectionModeID As New LookupCommDataID.ConnectionModeID()
#End Region

    Private Sub frmImportDataInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboDatabaseTypeID, LookupCommObjects.DatabaseType, False)
            LoadLookupDataCombo(Me.cboConnectionModeID, LookupCommObjects.ConnectionMode, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmImportDataInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbSourceName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbSourceName.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oImportDataInfo As New SyncSoft.SQLDb.ImportDataInfo()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oImportDataInfo.ItemCode = StringEnteredIn(Me.stbItemCode, "Item Code!")
            oImportDataInfo.SourceName = StringEnteredIn(Me.stbSourceName, "Source Name!")
            oImportDataInfo.SourceCaption = StringEnteredIn(Me.stbSourceCaption, "Source Caption!")
            DisplayMessage(oImportDataInfo.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oImportDataInfo As New SyncSoft.SQLDb.ImportDataInfo()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim itemCode As String = StringEnteredIn(Me.stbItemCode, "Item Code!")
            Dim sourceName As String = StringEnteredIn(Me.stbSourceName, "Source Name!")
            Dim sourceCaption As String = StringEnteredIn(Me.stbSourceCaption, "Source Caption!")
            Dim dataSource As DataTable = oImportDataInfo.GetImportDataInfo(itemCode, sourceName, sourceCaption).Tables("ImportDataInfo")
            Dim row As DataRow = dataSource.Rows(0)
            Me.DisplayData(dataSource)

            Me.stbImportPassword.Text = Decrypt(StringMayBeEnteredIn(row, "ImportPassword"))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oImportDataInfo As New SyncSoft.SQLDb.ImportDataInfo()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oImportDataInfo

                .ItemCode = StringEnteredIn(Me.stbItemCode, "Item Code!")
                .SourceName = StringEnteredIn(Me.stbSourceName, "Source Name!")
                .SourceCaption = StringEnteredIn(Me.stbSourceCaption, "Source Caption!")
                .DatabaseTypeID = StringValueEnteredIn(Me.cboDatabaseTypeID, "Database Type!")
                .ConnectionModeID = StringValueEnteredIn(Me.cboConnectionModeID, "Connection Mode!")
                .ImportServer = StringEnteredIn(Me.stbImportServer, "Import Server!")
                .ImportLogin = StringEnteredIn(Me.stbImportLogin, "Import Login!")
                .ImportPassword = StringEnteredIn(Me.stbImportPassword, "Import Password!")
                .SP_Name = StringEnteredIn(Me.stbSP_Name, "SP Name!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oImportDataInfo.Save()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oImportDataInfo.Update())
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub

#End Region

    Private Sub cboConnectionModeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConnectionModeID.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim connectionModeID As String = StringValueMayBeEnteredIn(Me.cboConnectionModeID)
            If String.IsNullOrEmpty(connectionModeID) Then Return

            If connectionModeID.ToUpper().Equals(oConnectionModeID.WindowsAuthentication.ToUpper()) Then
                Me.stbImportLogin.Clear()
                Me.stbImportPassword.Clear()
                Me.stbImportLogin.Enabled = False
                Me.stbImportPassword.Enabled = False
            Else
                Me.stbImportLogin.Enabled = True
                Me.stbImportPassword.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

End Class