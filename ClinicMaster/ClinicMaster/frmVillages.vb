
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmVillages

#Region " Fields "

#End Region

    Private Sub frmVillages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmVillages_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbVillageCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oVillages As New SyncSoft.SQLDb.Villages()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oVillages.VillageCode = StringEnteredIn(Me.cboVillageCode, "Village Code!")
            DisplayMessage(oVillages.Delete())
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

        Dim oVillages As New SyncSoft.SQLDb.Villages()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim villageCode As String = StringEnteredIn(Me.cboVillageCode, "Village Code!")
            Dim dataSource As DataTable = oVillages.GetVillages(villageCode).Tables("Villages")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim villages As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim districtsID As String = (From data In villages Select data.Field(Of String)("DistrictsID")).First()
            Dim countyCode As String = (From data In villages Select data.Field(Of String)("CountyCode")).First()
            Dim subCountyCode As String = (From data In villages Select data.Field(Of String)("SubCountyCode")).First()
            Dim parishCode As String = (From data In villages Select data.Field(Of String)("ParishCode")).First()

            If Not String.IsNullOrEmpty(districtsID) Then Me.LoadCounties(districtsID)
            If Not String.IsNullOrEmpty(countyCode) Then Me.LoadSubCounties(countyCode)
            If Not String.IsNullOrEmpty(subCountyCode) Then Me.LoadParishes(subCountyCode)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDistrictsID.SelectedValue = districtsID
            Me.cboCountyCode.SelectedValue = countyCode
            Me.cboSubCountyCode.SelectedValue = subCountyCode
            Me.cboParishCode.SelectedValue = parishCode

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oVillages As New SyncSoft.SQLDb.Villages()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oVillages

                StringValueEnteredIn(Me.cboDistrictsID, "District!")
                StringValueEnteredIn(Me.cboCountyCode, "County!")
                StringValueEnteredIn(Me.cboSubCountyCode, "Sub County!")
                .ParishCode = StringValueEnteredIn(Me.cboParishCode, "Parish!")
                .VillageCode = StringEnteredIn(Me.cboVillageCode, "Village Code!")
                .VillageName = StringEnteredIn(Me.stbVillageName, "Village Name!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oVillages.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oVillages.Update())
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

    Private Sub cboSubCountyCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCountyCode.SelectedIndexChanged

        Try

            Dim subCountyCode As String = StringValueMayBeEnteredIn(Me.cboSubCountyCode, "Sub County!")
            Me.LoadParishes(subCountyCode)

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

    Private Sub LoadParishes(ByVal subCountyCode As String)

        Dim oParishes As New SyncSoft.SQLDb.Parishes()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboParishCode.DataSource = Nothing
            If String.IsNullOrEmpty(subCountyCode) Then Return

            ' Load all from Parishes
            Dim parishes As DataTable = oParishes.GetParishesBySubCountyCode(subCountyCode).Tables("Parishes")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboParishCode.Sorted = False
            Me.cboParishCode.DataSource = parishes
            Me.cboParishCode.DisplayMember = "ParishName"
            Me.cboParishCode.ValueMember = "ParishCode"

            Me.cboParishCode.SelectedIndex = -1
            Me.cboParishCode.SelectedIndex = -1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        LoadVillages()
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

    Private Sub LoadVillages()

        Dim oVillage As New SyncSoft.SQLDb.Villages()
        Dim village As DataTable = Nothing
        cboVillageCode.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim parishCode As String = StringValueMayBeEnteredIn(Me.cboParishCode)

            If String.IsNullOrEmpty(parishCode) Then
                'village = oVillage.GetVillages().Tables("Villages")
            Else
                village = oVillage.GetVillagesByParishCode(parishCode).Tables("Villages")

            End If
            LoadComboData(cboVillageCode, village, "VillageFullName")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboVillageCode_Leave(sender As Object, e As EventArgs) Handles cboVillageCode.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbVillageName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboVillageCode)))
            Me.cboVillageCode.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboVillageCode)))
        End If
    End Sub

    Private Sub cboParishCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboParishCode.SelectedIndexChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            LoadVillages()
        End If
    End Sub

#End Region

End Class