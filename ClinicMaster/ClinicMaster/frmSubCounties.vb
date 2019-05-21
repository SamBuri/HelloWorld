
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmSubCounties

#Region " Fields "

#End Region

    Private Sub frmSubCounties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSubCounties_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbSubCountyCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oSubCounties As New SyncSoft.SQLDb.SubCounties()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oSubCounties.SubCountyCode = StringEnteredIn(Me.cboSubCountyCode, "Sub County Code!")
            DisplayMessage(oSubCounties.Delete())
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

        Dim oSubCounties As New SyncSoft.SQLDb.SubCounties()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim subCountyCode As String = StringEnteredIn(Me.cboSubCountyCode, "Sub County Code!")
            Dim dataSource As DataTable = oSubCounties.GetSubCounties(subCountyCode).Tables("SubCounties")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim subCounties As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim districtsID As String = (From data In subCounties Select data.Field(Of String)("DistrictsID")).First()
            Dim countyCode As String = (From data In subCounties Select data.Field(Of String)("CountyCode")).First()

            If Not String.IsNullOrEmpty(districtsID) Then Me.LoadCounties(districtsID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDistrictsID.SelectedValue = districtsID
            Me.cboCountyCode.SelectedValue = countyCode
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oSubCounties As New SyncSoft.SQLDb.SubCounties()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oSubCounties

                StringValueEnteredIn(Me.cboDistrictsID, "District!")
                .CountyCode = StringValueEnteredIn(Me.cboCountyCode, "County!")
                .SubCountyCode = StringEnteredIn(Me.cboSubCountyCode, "Sub County Code!")
                .SubCountyName = StringEnteredIn(Me.stbSubCountyName, "Sub County Name!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oSubCounties.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oSubCounties.Update())
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

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        LoadSubCounties()
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

    Private Sub LoadSubCounties()

        Dim oSubCounty As New SyncSoft.SQLDb.SubCounties()
        Dim subCounties As DataTable = Nothing
        cboCountyCode.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim countyCode As String = StringValueMayBeEnteredIn(Me.cboCountyCode, "County Code!")

            If String.IsNullOrEmpty(countyCode) Then
                subCounties = oSubCounty.GetSubCounties().Tables("SubCounties")
            Else
                subCounties = oSubCounty.GetSubCountiesByCountyCode(countyCode).Tables("SubCounties")

            End If
            LoadComboData(cboSubCountyCode, subCounties, "SubCountyFullName")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboSubCountyCode_Leave(sender As Object, e As EventArgs) Handles cboSubCountyCode.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbSubCountyName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboSubCountyCode)))
            Me.cboSubCountyCode.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboSubCountyCode)))
        End If
    End Sub



#End Region

End Class