
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb
Imports SyncSoft.Options.SQL

Public Class frmSuppliers

#Region " Fields "
   
#End Region

    Private Sub frmSuppliers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub frmSuppliers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbSupplierNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub SetNextSupplierNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()
            Dim oAutoNumbers As New AutoNumbers()

            Dim yearL2 As String = Today.Year.ToString().Substring(2)
            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Suppliers", "SupplierNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextSupplierNo As String = CStr(oSuppliers.GetNextSupplierID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboSupplierNo.Text = FormatText(("S" + yearL2 + nextSupplierNo).Trim(), "Suppliers", "SupplierNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oSuppliers.SupplierNo = RevertText(StringEnteredIn(Me.cboSupplierNo, "Supplier No!"))
            DisplayMessage(oSuppliers.Delete())
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

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim supplierNo As String = RevertText(StringEnteredIn(Me.cboSupplierNo, "Supplier No!"))
            Dim dataSource As DataTable = oSuppliers.GetSuppliers(supplierNo).Tables("Suppliers")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oSuppliers

                .SupplierNo = RevertText(StringEnteredIn(Me.cboSupplierNo, "Supplier No!"))
                .SupplierName = StringEnteredIn(Me.stbSupplierName, "Supplier Name!")
                .ContactPerson = StringMayBeEnteredIn(Me.stbContactPerson)
                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .Phone = StringMayBeEnteredIn(Me.stbPhone)
                .LoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oSuppliers.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetNextSupplierNo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oSuppliers.Update())
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

        LoadSuppliers()
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.cboSupplierNo.Enabled = True
        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ' Me.cboSupplierNo.Enabled = InitOptions.SupplierNoLocked

        ResetControlsIn(Me)

        Me.SetNextSupplierNo()

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

    Private Sub cboSupplierNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSupplierNo.SelectedIndexChanged

    End Sub

    Private Sub cboSupplierNo_Leave(sender As Object, e As EventArgs) Handles cboSupplierNo.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbSupplierName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboSupplierNo)))
            Me.cboSupplierNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboSupplierNo)))
        End If

    End Sub


    Private Sub LoadSuppliers()

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Suppliers

            Dim suppliers As DataTable = oSuppliers.GetSuppliers().Tables("Suppliers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboSupplierNo, suppliers, "SupplierFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region


   

End Class