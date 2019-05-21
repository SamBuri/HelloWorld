
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID


Public Class frmMessenger

#Region " Fields "
    Private Staff As DataTable
#End Region

Private Sub frmMessenger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            Me.LoadStaff()
            Me.LoadmessageDetails()
	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmMessenger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
    End Sub


    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetMessengerUsers().Tables("Logins")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Me.cboStaffNo.Sorted = False
            Me.cboStaffNo.DataSource = staff
            Me.cboStaffNo.DisplayMember = "FullName"
            Me.cboStaffNo.ValueMember = "LoginID"
            Me.cboStaffNo.SelectedIndex = -1
            Me.cboStaffNo.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOutboxMessages()

        Dim outBox As DataTable
        Dim oOutBox As New SyncSoft.SQLDb.Messenger()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            outBox = oOutBox.GetOutboxMessages(CurrentUser.LoginID).Tables("Messenger")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOutbox, outBox)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowInboxMessages()

        Dim inBox As DataTable
        Dim oOutBox As New SyncSoft.SQLDb.Messenger()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            inBox = oOutBox.GetInboxMessages(CurrentUser.LoginID).Tables("Messenger")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInbox, inBox)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function ShowUnreadMessageAlerts() As Integer
        Dim unread As DataTable
        Dim oMessenger As New SyncSoft.SQLDb.Messenger

        Try
            Me.Cursor = Cursors.WaitCursor

            unread = oMessenger.GetUnreadMessages(CurrentUser.LoginID).Tables("Messenger")

            Dim alertsNo As Integer = unread.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblUnreadMessageAlerts.Text = "Unread Messages : " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub ClearReadMessageAlerts()
        Dim unread As DataTable
        Dim oMessenger As New SyncSoft.SQLDb.Messenger

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            unread = oMessenger.GetClearReadMessages(CurrentUser.LoginID).Tables("Messenger")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(sender As System.Object, e As System.EventArgs) Handles tmrAlerts.Tick
        Try

            Me.LoadmessageDetails()
        Catch eX As Exception
            Return

        End Try
    End Sub

    Private Sub LoadmessageDetails()
        Try

            Me.ShowOutboxMessages()
            Me.ShowInboxMessages()
            Me.ShowUnreadMessageAlerts()
        Catch eX As Exception
            Return

        End Try
    End Sub

    Private Sub tbcMessenger_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbcMessenger.MouseClick
        Try

            Me.ClearReadMessageAlerts()
            Me.LoadmessageDetails()
        Catch eX As Exception
            Return

        End Try
    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oMessenger As New SyncSoft.SQLDb.Messenger()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oMessenger

                .ReceiverStaffNo = Me.cboStaffNo.SelectedValue.ToString()
                .MessageInfo = StringEnteredIn(Me.stbMessage, "Message!")
                .LoginID = CurrentUser.LoginID
                .Status = False

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oMessenger.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' ResetControlsIn(tpgCompose)
                    stbMessage.Clear()
                    Me.LoadmessageDetails()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oMessenger.Update())
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
        Me.ebnSaveUpdate.Text = "Send"

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

    

 
End Class