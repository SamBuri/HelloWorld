
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmHealthUnits

#Region " Fields "

#End Region

    Private Sub frmHealthUnits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmHealthUnits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oHealthUnits.HealthUnitCode = StringEnteredIn(Me.cboHealthUnitCode, "Health Unit Code!")

            DisplayMessage(oHealthUnits.Delete())
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

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim healthUnitCode As String = StringEnteredIn(Me.cboHealthUnitCode, "Health Unit Code!")
            Dim dataSource As DataTable = oHealthUnits.GetHealthUnits(healthUnitCode).Tables("HealthUnits")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oHealthUnits

                .HealthUnitCode = StringEnteredIn(Me.cboHealthUnitCode, "Health Unit Code!")
                .HealthUnitName = StringEnteredIn(Me.stbHealthUnitName, "Health Unit Name!")
                .DistrictsID = StringValueEnteredIn(Me.cboDistrictsID, "District!")
                .ContactPerson = StringMayBeEnteredIn(Me.stbContactPerson)
                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .Phone = StringMayBeEnteredIn(Me.stbPhone)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oHealthUnits.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oHealthUnits.Update())
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
        LoadHealthUnits()
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


    Private Sub cboHealthUnitCode_Leave(sender As Object, e As EventArgs) Handles cboHealthUnitCode.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbHealthUnitName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboHealthUnitCode)))
            Me.cboHealthUnitCode.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboHealthUnitCode)))
        End If
    End Sub


    Private Sub LoadHealthUnits()

        Dim oHealthUnit As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim healthUnit As DataTable = oHealthUnit.GetHealthUnits().Tables("HealthUnits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboHealthUnitCode, healthUnit, "HealthUnitFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region

End Class