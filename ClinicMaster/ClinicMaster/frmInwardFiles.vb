
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmInwardFiles

#Region " Fields "

#End Region

#Region " Validations "

    Private Sub dtpReturnDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpReturnDateTime.Validating

        Dim errorMSG As String = "Return date time can't be before taken date time!"

        Try

            Dim takenDateTime As Date = DateTimeMayBeEnteredIn(Me.stbTakenDateTime)
            Dim returnDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpReturnDateTime)

            If returnDateTime = AppData.NullDateValue Then Return

            If returnDateTime < takenDateTime Then
                ErrProvider.SetError(Me.dtpReturnDateTime, errorMSG)
                Me.dtpReturnDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpReturnDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmInwardFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpReturnDateTime.MaxDate = Today.AddDays(1)
            Me.dtpReturnDateTime.Value = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataIn(Me.cboReturnedBy, LookupObjects.FileReturnedBy, False, "DataDes")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmInwardFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindOutwardNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindOutwardNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindOutwardNo As New frmFindAutoNo(Me.stbOutwardNo, AutoNumber.OutwardNo)
        fFindOutwardNo.ShowDialog(Me)

        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outwardNo As String = RevertText(StringMayBeEnteredIn(Me.stbOutwardNo))
            If String.IsNullOrEmpty(outwardNo) Then Return
            Me.ShowOutwardFileDetails(outwardNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Else : Me.stbOutwardNo.Focus()
        End If

    End Sub

    Private Sub ClearControls()
        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbLastVisitDate.Clear()
        Me.stbTakenDateTime.Clear()
    End Sub

    Private Sub stbOutwardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbOutwardNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim outwardNo As String = RevertText(StringMayBeEnteredIn(Me.stbOutwardNo))
            If String.IsNullOrEmpty(outwardNo) Then Return
            Me.ShowOutwardFileDetails(outwardNo)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOutwardFileDetails(ByVal outwardNo As String)

        Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(outwardNo) Then Return

            Dim outwardFiles As DataTable = oOutwardFiles.GetOutwardFiles(outwardNo).Tables("OutwardFiles")
            Dim row As DataRow = outwardFiles.Rows(0)

            Me.stbFileNo.Text = FormatText(StringEnteredIn(row, "FileNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbLastVisitDate.Text = FormatDate(DateEnteredIn(row, "LastVisitDate"))
            Me.stbTakenDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "TakenDateTime"))

            Me.stbFileNo.Text = FormatText(outwardNo, "OutwardFiles", "OutwardNo")

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbOutwardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbOutwardNo.TextChanged
        Me.ClearControls()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInwardFiles As New SyncSoft.SQLDb.InwardFiles()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oInwardFiles.OutwardNo = RevertText(StringEnteredIn(Me.stbOutwardNo, "Outward No!"))
            DisplayMessage(oInwardFiles.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oInwardFiles As New SyncSoft.SQLDb.InwardFiles()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim outwardNo As String = RevertText(StringEnteredIn(Me.stbOutwardNo, "Outward No!"))
            Dim dataSource As DataTable = oInwardFiles.GetInwardFiles(outwardNo).Tables("InwardFiles")

            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oInwardFiles As New SyncSoft.SQLDb.InwardFiles()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oInwardFiles

                .OutwardNo = RevertText(StringEnteredIn(Me.stbOutwardNo, "Outward No!"))
                .ReturnDateTime = DateTimeEnteredIn(Me.dtpReturnDateTime, "Return Date Time!")
                .ReturnedBy = StringEnteredIn(Me.cboReturnedBy, "Returned By!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oInwardFiles.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)

                    Me.dtpReturnDateTime.Value = Now
                    Me.dtpReturnDateTime.Checked = False
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oInwardFiles.Update())
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

        Me.dtpReturnDateTime.Value = Now
        Me.dtpReturnDateTime.Checked = False

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