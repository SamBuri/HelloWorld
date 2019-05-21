
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects


Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Public Class frmINTAgents

#Region " Fields "

#End Region

Private Sub frmINTAgents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.cboConnectionModeID, LookupCommObjects.ConnectionMode, False)
            LoadLookupDataCombo(Me.cboDatabaseTypeID, LookupCommObjects.DatabaseType, False)
            LoadAllAgents()
	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmINTAgents_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oINTAgents As New SyncSoft.SQLDb.INTAgents()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oINTAgents.AgentNo = StringValueEnteredIn(Me.cboAgentNo, "Agent No!")

		DisplayMessage(oINTAgents.Delete())
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		ResetControlsIn(Me)
		Me.CallOnKeyEdit()

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

Dim agentNo As String

Dim oINTAgents As New SyncSoft.SQLDb.INTAgents()

	Try
		Me.Cursor = Cursors.WaitCursor()

            agentNo = StringValueEnteredIn(Me.cboAgentNo, "Agent No!")

		Dim dataSource As DataTable = oINTAgents.GetINTAgents(agentNo).Tables("INTAgents")
            Me.DisplayData(dataSource)
            Dim row As DataRow = dataSource.Rows(0)
            stbPassword.Text = Decrypt(StringMayBeEnteredIn(row, "Password"))

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oINTAgents As New SyncSoft.SQLDb.INTAgents()

	Try
		Me.Cursor = Cursors.WaitCursor()

		With oINTAgents

                .AgentNo = StringValueEnteredIn(Me.cboAgentNo, "Agent No!")
                .AgentName = StringEnteredIn(Me.stbAgentName, "Agent Name!")
                .ConnectionModeID = StringValueMayBeEnteredIn(Me.cboConnectionModeID)
                .DatabaseTypeID = StringValueMayBeEnteredIn(Me.cboDatabaseTypeID)
                .DataSource = StringMayBeEnteredIn(Me.stbDataSource)
                .DBName = StringMayBeEnteredIn(Me.stbDBName)
                .Port = IntegerMayBeEnteredIn(Me.nbxPort)
                .UserName = StringEnteredIn(Me.stbUsername, "Username!")
                .Password = Encrypt(StringEnteredIn(Me.stbPassword, "Password!"))
                .LoginID = CurrentUser.LoginID
		

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ValidateEntriesIn(Me)
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oINTAgents.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ResetControlsIn(Me)
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oINTAgents.Update())
		Me.CallOnKeyEdit()

	End Select

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub

    Private Sub LoadAllAgents()

        Dim oINTAgents As New SyncSoft.SQLDb.INTAgents()


        Try
            Me.Cursor = Cursors.WaitCursor



            Dim _IntAgents As DataTable = oINTAgents.GetINTAgents().Tables("INTAgents")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With cboAgentNo
                .DataSource = _IntAgents
                .DisplayMember = "AgentName"
                .ValueMember = "AgentNo"
                If _IntAgents.Rows.Count() > 0 Then .SelectedIndex = 0
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

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

End Class