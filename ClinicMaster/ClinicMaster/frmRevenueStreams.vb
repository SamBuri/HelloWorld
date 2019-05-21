
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmRevenueStreams

#Region " Fields "

#End Region

Private Sub frmRevenueStreams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()



	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmRevenueStreams_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oRevenueStreams As New SyncSoft.SQLDb.RevenueStreams()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

		oRevenueStreams.RevenueStreamCode = StringEnteredIn(Me.stbRevenueStreamCode, "RevenueStreamCode!")

		DisplayMessage(oRevenueStreams.Delete())
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

Dim revenueStreamCode As String

Dim oRevenueStreams As New SyncSoft.SQLDb.RevenueStreams()

	Try
		Me.Cursor = Cursors.WaitCursor()

		revenueStreamCode = StringEnteredIn(Me.stbRevenueStreamCode, "RevenueStreamCode!")

		Dim dataSource As DataTable = oRevenueStreams.GetRevenueStreams(revenueStreamCode).Tables("RevenueStreams")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oRevenueStreams As New SyncSoft.SQLDb.RevenueStreams()

	Try
		Me.Cursor = Cursors.WaitCursor()

		With oRevenueStreams

		.RevenueStreamCode = StringEnteredIn(Me.stbRevenueStreamCode, "RevenueStreamCode!")
		.Name = StringEnteredIn(Me.stbName, "Name!")
		.Hidden = Me.chkHidden.Checked

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ValidateEntriesIn(Me)
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oRevenueStreams.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ResetControlsIn(Me)
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oRevenueStreams.Update())
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

End Class