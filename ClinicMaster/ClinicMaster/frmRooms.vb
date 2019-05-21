
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmRooms

#Region " Fields "

#End Region

    Private Sub frmRooms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboWardsID, LookupObjects.Wards, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmRooms_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbRoomNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oRooms As New SyncSoft.SQLDb.Rooms()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oRooms.RoomNo = StringEnteredIn(Me.cboRoomNo, "Room No!")

            DisplayMessage(oRooms.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.grpLocation)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oRooms As New SyncSoft.SQLDb.Rooms()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim roomNo As String = StringEnteredIn(Me.cboRoomNo, "Room No!")
            Dim dataSource As DataTable = oRooms.GetRooms(roomNo).Tables("Rooms")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oRooms As New SyncSoft.SQLDb.Rooms()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oRooms

                .WardsID = StringValueEnteredIn(Me.cboWardsID, "Ward!")
                .RoomNo = StringEnteredIn(Me.cboRoomNo, "Room No!")
                .RoomName = StringEnteredIn(Me.stbRoomName, "Room Name!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oRooms.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oRooms.Update())
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

        LoadRooms()
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLocation)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLocation)

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

    Private Sub cboRoomNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRoomNo.SelectedIndexChanged

    End Sub

    Private Sub cboRoomNo_Leave(sender As Object, e As EventArgs) Handles cboRoomNo.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            stbRoomName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboRoomNo)))
            cboRoomNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboRoomNo)))

        End If
    End Sub

    Private Sub LoadRooms()

        Dim oRooms As New SyncSoft.SQLDb.Rooms()
        Dim rooms As DataTable = Nothing
        cboRoomNo.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim wardID As String = StringValueMayBeEnteredIn(Me.cboWardsID, "Ward ID!")

            If String.IsNullOrEmpty(wardID) Then
                rooms = oRooms.GetRooms().Tables("Rooms")
            Else
                rooms = oRooms.GetRoomsBywardsID(wardID).Tables("Rooms")

            End If
            LoadComboData(cboRoomNo, rooms, "RoomFullName")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboWardsID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboWardsID.SelectedIndexChanged
        If (Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update) Then
            LoadRooms()
        End If
    End Sub

#End Region

End Class