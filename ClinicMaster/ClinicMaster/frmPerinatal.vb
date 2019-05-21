
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmPerinatal

#Region " Fields "

#End Region

Private Sub frmPerinatal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.cboCauseOfDeath, LookupObjects.IfDeceased, False)
            LoadLookupDataCombo(Me.cboDeliveryComplications, LookupObjects.DeliveryComplications, False)
            LoadLookupDataCombo(Me.cboModeOfDelivery, LookupObjects.TypeOfDelivery, False)
            LoadLookupDataCombo(Me.cboMothersCondition, LookupObjects.MothersCondition, False)
            LoadLookupDataCombo(Me.cboBabyAlive, LookupObjects.YesNo, False)



	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmPerinatal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oPerinatal As New SyncSoft.SQLDb.Perinatal()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return



		DisplayMessage(oPerinatal.Delete())
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



        'Dim oPerinatal As New SyncSoft.SQLDb.Perinatal()

        '	Try
        '		Me.Cursor = Cursors.WaitCursor()

        '            Dim PatientNo As String

        '            Dim dataSource As DataTable = oPerinatal.GetPerinatal(patientNo).Tables("Perinatal")
        '		Me.DisplayData(dataSource)

        '	Catch ex As Exception
        '		ErrorMessage(ex)

        '	Finally
        '		Me.Cursor = Cursors.Default()

        '	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oPerinatal As New SyncSoft.SQLDb.Perinatal()

	Try
		Me.Cursor = Cursors.WaitCursor()

		With oPerinatal

                .VisitNo = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                .ModeOfDelivery = StringValueMayBeEnteredIn(Me.cboModeOfDelivery, "Mode Of Delivery!")
                .DurationOfLabour = CSng(StringMayBeEnteredIn(Me.stbDurationOfLabour))
                .DeliveryComplications = StringValueMayBeEnteredIn(Me.cboDeliveryComplications, "Delivery Complications!")
		.AmountOfBloodLoss = Me.nbxAmountOfBloodLoss.GetSingle()
                .MothersCondition = StringValueMayBeEnteredIn(Me.cboMothersCondition, "Mothers Condition!")
                .DetailsOfCondition = StringMayBeEnteredIn(Me.stbDetailsOfCondition)
                .BabyAlive = StringValueMayBeEnteredIn(Me.cboBabyAlive, "Baby Alive!")
                .CauseOfDeath = StringValueMayBeEnteredIn(Me.cboCauseOfDeath, "CauseOfDeath!")
		.LoginID = CurrentUser.LoginID
		

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ValidateEntriesIn(Me)
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oPerinatal.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ResetControlsIn(Me)
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oPerinatal.Update())
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

    Private Sub btnLoadPatients_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPatients.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbVisitNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            'If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.stbPatientNo_Leave(Me, System.EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class