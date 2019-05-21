
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmParishes

#Region " Fields "

#End Region

    Private Sub frmParishes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmParishes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbParishCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oParishes As New SyncSoft.SQLDb.Parishes()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oParishes.ParishCode = StringEnteredIn(Me.cboParishCode, "Parish Code!")
            DisplayMessage(oParishes.Delete())
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

        Dim oParishes As New SyncSoft.SQLDb.Parishes()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim parishCode As String = StringEnteredIn(Me.cboParishCode, "Parish Code!")
            Dim dataSource As DataTable = oParishes.GetParishes(parishCode).Tables("Parishes")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim parishes As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim districtsID As String = (From data In parishes Select data.Field(Of String)("DistrictsID")).First()
            Dim countyCode As String = (From data In parishes Select data.Field(Of String)("CountyCode")).First()
            Dim subCountyCode As String = (From data In parishes Select data.Field(Of String)("SubCountyCode")).First()

            If Not String.IsNullOrEmpty(districtsID) Then Me.LoadCounties(districtsID)
            If Not String.IsNullOrEmpty(countyCode) Then Me.LoadSubCounties(countyCode)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDistrictsID.SelectedValue = districtsID
            Me.cboCountyCode.SelectedValue = countyCode
            Me.cboSubCountyCode.SelectedValue = subCountyCode
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oParishes As New SyncSoft.SQLDb.Parishes()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oParishes

                StringValueEnteredIn(Me.cboDistrictsID, "District!")
                StringValueEnteredIn(Me.cboCountyCode, "County!")
                .SubCountyCode = StringValueEnteredIn(Me.cboSubCountyCode, "Sub County!")
                .ParishCode = StringEnteredIn(Me.cboParishCode, "Parish Code!")
                .ParishName = StringEnteredIn(Me.stbParishName, "Parish Name!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oParishes.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oParishes.Update())
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Location "

    Private Sub cboDistrictsID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDistrictsID.SelectedIndexChanged

        Try

            Dim districtsID As String = StringValueMayBeEnteredIn(Me.cboDistrictsID, "District!")
            Me.LoadCounties(districtsID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboCountyCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountyCode.SelectedIndexChanged

        Try

            Dim countyCode As String = StringValueMayBeEnteredIn(Me.cboCountyCode, "County!")
            Me.LoadSubCounties(countyCode)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadCounties(ByVal districtsID As String)

        Dim oCounties As New SyncSoft.SQLDb.Counties()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboCountyCode.DataSource = Nothing
            If String.IsNullOrEmpty(districtsID) Then Return

            ' Load all from Counties
            Dim counties As DataTable = oCounties.GetCountiesByDistrictsID(districtsID).Tables("Counties")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboCountyCode.Sorted = False
            Me.cboCountyCode.DataSource = counties
            Me.cboCountyCode.DisplayMember = "CountyName"
            Me.cboCountyCode.ValueMember = "CountyCode"

            Me.cboCountyCode.SelectedIndex = -1
            Me.cboCountyCode.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadSubCounties(ByVal countyCode As String)

        Dim oSubCounties As New SyncSoft.SQLDb.SubCounties()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboSubCountyCode.DataSource = Nothing
            If String.IsNullOrEmpty(countyCode) Then Return

            ' Load all from SubCounties
            Dim subCounties As DataTable = oSubCounties.GetSubCountiesByCountyCode(countyCode).Tables("SubCounties")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboSubCountyCode.Sorted = False
            Me.cboSubCountyCode.DataSource = subCounties
            Me.cboSubCountyCode.DisplayMember = "SubCountyName"
            Me.cboSubCountyCode.ValueMember = "SubCountyCode"

            Me.cboSubCountyCode.SelectedIndex = -1
            Me.cboSubCountyCode.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        LoadParishes()
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

#End Region

    Private Sub LoadParishes()

        Dim oParish As New SyncSoft.SQLDb.Parishes()
        Dim parish As DataTable = Nothing
        cboParishCode.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim subcountyCode As String = StringValueMayBeEnteredIn(Me.cboSubCountyCode, "Sub County ID!")

            If String.IsNullOrEmpty(subcountyCode) Then
                parish = oParish.GetParishes().Tables("Parishes")
            Else
                parish = oParish.GetParishesBySubCountyCode(subcountyCode).Tables("Parishes")

            End If
            LoadComboData(cboParishCode, parish, "ParishFullName")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub cboParishCode_Leave(sender As Object, e As EventArgs) Handles cboParishCode.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbParishName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboParishCode)))
            Me.cboParishCode.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboParishCode)))
        End If
    End Sub
End Class