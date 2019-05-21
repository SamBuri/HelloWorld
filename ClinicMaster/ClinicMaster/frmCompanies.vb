
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls


Public Class frmCompanies

#Region " Fields "

#End Region

    Private Sub frmCompanies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmCompanies_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbCompanyNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub SetNextCompanyNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oCompanies As New SyncSoft.SQLDb.Companies()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim yearL2 As String = Today.Year.ToString().Substring(2)
            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Companies", "CompanyNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextCompanyNo As String = CStr(oCompanies.GetNextCompanyID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboCompanyNo.Text = FormatText(("C" + yearL2 + nextCompanyNo).Trim(), "Companies", "CompanyNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oCompanies As New SyncSoft.SQLDb.Companies()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oCompanies.CompanyNo = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            DisplayMessage(oCompanies.Delete())
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

        Dim oCompanies As New SyncSoft.SQLDb.Companies()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim dataSource As DataTable = oCompanies.GetCompanies(companyNo).Tables("Companies")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oCompanies As New SyncSoft.SQLDb.Companies()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oCompanies

                .CompanyNo = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
                .CompanyName = StringEnteredIn(Me.stbCompanyName, "Company Name!")
                .ContactPerson = StringMayBeEnteredIn(Me.stbContactPerson)
                .ContractStartDate = DateEnteredIn(Me.dtpContractStartDate, "Contract Start Date!")
                .ContractEndDate = DateEnteredIn(Me.dtpContractEndDate, "Contract End Date!")
                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .Phone = StringMayBeEnteredIn(Me.stbPhone)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oCompanies.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetNextCompanyNo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oCompanies.Update())
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
        LoadCompanies()
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.cboCompanyNo.Enabled = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.cboCompanyNo.Enabled = InitOptions.CompanyNoLocked

        ResetControlsIn(Me)

        Me.SetNextCompanyNo()

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

    Private Sub LoadCompanies()

        Dim oCompanies As New SyncSoft.SQLDb.Companies()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim companies As DataTable = oCompanies.GetCompanies().Tables("Companies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCompanyNo, companies, "CompanyFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub cboCompanyNo_Leave(sender As Object, e As EventArgs) Handles cboCompanyNo.Leave
        stbCompanyName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(Me.cboCompanyNo)))
        cboCompanyNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(Me.cboCompanyNo)))
    End Sub


#End Region

End Class