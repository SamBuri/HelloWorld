
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmDrugCategories

#Region " Fields "
    Private drugCategories As DataTable
#End Region

    Private Sub frmDrugCategories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboDosageCalculationID, LookupObjects.DosageCalculation, False)

            Me.LoadDrugCategories()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmDrugCategories_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cboCategoryNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategoryNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboCategoryNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategoryNo.Leave

        Try

            Dim categoryNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboCategoryNo)).ToUpper()
            Me.cboCategoryNo.Text = categoryNo.ToUpper()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            For Each row As DataRow In drugCategories.Select("CategoryNo = '" + categoryNo + "'")
                Me.stbCategoryName.Text = StringMayBeEnteredIn(row, "CategoryName")
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadDrugCategories()

        Dim oDrugCategories As New SyncSoft.SQLDb.DrugCategories()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from DrugCategories

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            drugCategories = oDrugCategories.GetDrugCategories().Tables("DrugCategories")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugCategories(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboCategoryNo, drugCategories, "CategoryFullName")
            Else : Me.cboCategoryNo.Items.Clear()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oDrugCategories As New SyncSoft.SQLDb.DrugCategories()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oDrugCategories.CategoryNo = StringEnteredIn(Me.cboCategoryNo, "Category No!")

            DisplayMessage(oDrugCategories.Delete())
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

        Dim oDrugCategories As New SyncSoft.SQLDb.DrugCategories()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim categoryNo As String = StringEnteredIn(Me.cboCategoryNo, "Category No!")
            Dim dataSource As DataTable = oDrugCategories.GetDrugCategories(categoryNo).Tables("DrugCategories")

            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oDrugCategories As New SyncSoft.SQLDb.DrugCategories()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oDrugCategories

                .CategoryNo = StringEnteredIn(Me.cboCategoryNo, "Category No!")
                .CategoryName = StringEnteredIn(Me.stbCategoryName, "Category Name!")
                .VaryPrescribedQty = Me.chkVaryPrescribedQty.Checked
                .DefaultPrescribedQty = Me.nbxDefaultPrescribedQty.GetInteger()
                .DosageSeparator = StringEnteredIn(Me.stbDosageSeparator, "Dosage Separator!")
                .DosageCalculationID = StringValueEnteredIn(Me.cboDosageCalculationID, "Dosage Calculation!")
                .DosageFormat = StringMayBeEnteredIn(Me.stbDosageFormat)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oDrugCategories.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oDrugCategories.Update())
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

        Me.cboCategoryNo.MaxLength = 54
        Me.LoadDrugCategories(True)

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.cboCategoryNo.MaxLength = 10
        Me.LoadDrugCategories(False)

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