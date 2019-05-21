
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmCancerDiseases

#Region " Fields "

#End Region

    Private Sub frmCancerDiseases_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboCancerDiseaseCategoriesID, LookupObjects.OncologyMorphologyCancers, False)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmCancerDiseases_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oCancerDiseases As New SyncSoft.SQLDb.CancerDiseases()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oCancerDiseases.DiseaseNo = RevertText(StringEnteredIn(Me.cboDiseaseNo, "Disease No!"))

            DisplayMessage(oCancerDiseases.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oCancerDiseases As New SyncSoft.SQLDb.CancerDiseases()
        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim diseaseNo As String = RevertText(StringEnteredIn(Me.cboDiseaseNo, "Disease No!"))
            Dim dataSource As DataTable = oCancerDiseases.GetCancerDiseases(diseaseNo).Tables("CancerDiseases")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SetNextDiseaseNo(ByVal diseaseNo As String, ByVal diseaseCode As String)

        Try

            Dim oCancerDiseases As New SyncSoft.SQLDb.CancerDiseases
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("CancerDiseases", "DiseaseNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim diseaseID As String = oCancerDiseases.GetNextCancerDiseaseID(diseaseCode).ToString()
            diseaseID = diseaseID.PadLeft(paddingLEN, paddingCHAR)
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Me.cboDiseaseNo.Text = FormatText(diseaseNo + diseaseID.Trim(), "CancerDiseases", "DiseaseNo")
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oCancerDiseases As New SyncSoft.SQLDb.CancerDiseases()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oCancerDiseases
                .DiseaseNo = RevertText(StringEnteredIn(Me.cboDiseaseNo, "Disease No!"))
                .DiseaseCode = StringEnteredIn(Me.stbDiseaseCode, "Disease Code!")
                .DiseaseName = StringEnteredIn(Me.stbDiseaseName, "Disease Name!")
                .CancerDiseaseCategoriesID = StringValueEnteredIn(Me.cboCancerDiseaseCategoriesID, "Cancer Disease Category!")
                .Hidden = Me.chkHidden.Checked
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    oCancerDiseases.Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oCancerDiseases.Update())
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        LoadCancerDiseases()
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

    Private Sub cboCancerDiseaseCategoriesID_Leave(sender As Object, e As System.EventArgs) Handles cboCancerDiseaseCategoriesID.Leave
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.stbDiseaseCode.Text = CStr(cboCancerDiseaseCategoriesID.SelectedValue)
            Dim DiseaseCode As String = RevertText(StringMayBeEnteredIn(Me.stbDiseaseCode))
            If String.IsNullOrEmpty(DiseaseCode) Then Return
            ' Me.SetNextDiseaseNo(DiseaseCode)

            Me.SetNextDiseaseNo(DiseaseCode.Substring(CInt(LookupObjects.OncologyMorphologyCancers).ToString().Length), DiseaseCode)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub LoadCancerDiseases()

        Dim oCancerDiseases As New SyncSoft.SQLDb.CancerDiseases()
        Dim cancerDiseases As DataTable = Nothing
        Me.cboDiseaseNo.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim diseaseID As String = StringMayBeEnteredIn(Me.stbDiseaseName)

            'If String.IsNullOrEmpty(diseaseID) Then
            '    cancerDiseases = oCancerDiseases.GetCancerDiseases().Tables("CancerDiseases")
            'Else
            '    cancerDiseases = oCancerDiseases.GetCancerDiseasesByDiseaseNo(diseaseID).Tables("CancerDiseases")

            'End If
            cancerDiseases = oCancerDiseases.GetCancerDiseases().Tables("CancerDiseases")
            LoadComboData(cboDiseaseNo, cancerDiseases, "DiseaseFullName")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboDiseaseNo_Leave(sender As Object, e As EventArgs) Handles cboDiseaseNo.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbDiseaseName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboDiseaseNo)))
            Me.cboDiseaseNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboDiseaseNo)))
        End If
    End Sub
End Class