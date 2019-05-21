
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmPhysioDiseases

#Region " Fields "

#End Region

Private Sub frmPhysioDiseases_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboPhysioDiseaseCategoriesID, LookupObjects.PhysiotherapyDiseaseCategory, False)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmPhysioDiseases_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oPhysioDiseases As New SyncSoft.SQLDb.PhysioDiseases()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oPhysioDiseases.PhysioDiseaseNo = StringEnteredIn(Me.stbPhysioDiseaseNo, "Disease No!")

            DisplayMessage(oPhysioDiseases.Delete())
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

        Dim PhysioDiseaseNo As String

        Dim oPhysioDiseases As New SyncSoft.SQLDb.PhysioDiseases()

        Try
            Me.Cursor = Cursors.WaitCursor()

            PhysioDiseaseNo = StringEnteredIn(Me.stbPhysioDiseaseNo, "Disease No!")

            Dim dataSource As DataTable = oPhysioDiseases.GetPhysioDiseases(PhysioDiseaseNo).Tables("PhysioDiseases")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oPhysioDiseases As New SyncSoft.SQLDb.PhysioDiseases()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oPhysioDiseases


                .PhysioDiseaseNo = RevertText(StringEnteredIn(Me.stbPhysioDiseaseNo, "Disease No!"))
                .DiseaseCode = StringEnteredIn(Me.stbDiseaseCode, "Disease Code!")
                .DiseaseName = StringEnteredIn(Me.stbDiseaseName, "Disease Name!")
                .PhysioDiseaseCategoriesID = StringValueEnteredIn(Me.cboPhysioDiseaseCategoriesID, "Physio Disease Categories!")
                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oPhysioDiseases.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oPhysioDiseases.Update())
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

    Private Sub SetNextDiseaseNo(ByVal PhysioDiseaseNo As String, ByVal diseaseCode As String)

        Try

            Dim oPhysioDiseases As New SyncSoft.SQLDb.PhysioDiseases
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("PhysioDiseases", "PhysioDiseaseNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim diseaseID As String = oPhysioDiseases.GetNextPhysioDiseaseID(diseaseCode).ToString()
            diseaseID = diseaseID.PadLeft(paddingLEN, paddingCHAR)
            Me.stbPhysioDiseaseNo.Text = FormatText(PhysioDiseaseNo + diseaseID.Trim(), "PhysioDiseases", "PhysioDiseaseNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cboPhysioDiseaseCategoriesID_Leave(sender As System.Object, e As System.EventArgs) Handles cboPhysioDiseaseCategoriesID.Leave
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.stbDiseaseCode.Text = CStr(cboPhysioDiseaseCategoriesID.SelectedValue)
            Dim DiseaseCode As String = RevertText(StringMayBeEnteredIn(Me.stbDiseaseCode))
            If String.IsNullOrEmpty(DiseaseCode) Then Return
            ' Me.SetNextDiseaseNo(DiseaseCode)
            Me.SetNextDiseaseNo(DiseaseCode.Substring(CInt(LookupObjects.PhysiotherapyDiseaseCategory).ToString().Length), DiseaseCode)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    
End Class