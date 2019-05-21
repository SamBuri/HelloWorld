
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmOutwardFiles

#Region " Fields "
    Private defaultFileNo As String
    Private defaultBillAccountName As String
    Private defaultVisitNo As String
#End Region

#Region " Validations "

    Private Sub dtpTakenDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpTakenDateTime.Validating

        Dim errorMSG As String = "Taken date can't be before last visit date!"

        Try

            Dim lastVisitDate As Date = DateMayBeEnteredIn(Me.stbLastVisitDate)
            Dim takenDate As Date = DateMayBeEnteredIn(Me.dtpTakenDateTime)

            If takenDate = AppData.NullDateValue Then Return

            If takenDate < lastVisitDate Then
                ErrProvider.SetError(Me.dtpTakenDateTime, errorMSG)
                Me.dtpTakenDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpTakenDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmOutwardFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpTakenDateTime.MaxDate = Today.AddDays(1)
            Me.dtpTakenDateTime.Value = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataIn(Me.cboTakenBy, LookupObjects.FileTakenBy, False, "DataDes")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not String.IsNullOrEmpty(defaultFileNo) Then

                Me.stbFileNo.Text = FormatText(defaultFileNo, "Patients", "PatientNo")
                Me.stbFileNo.Enabled = False
                Me.stbVisitNo.Enabled = False
                Me.ProcessTabKey(True)
                Me.ShowFileDetails(defaultFileNo)
                Me.stbBillAccountName.Text = defaultBillAccountName
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")

                Me.stbOutwardNo.ReadOnly = InitOptions.OutwardNoLocked
                Me.btnFindOutwardNo.Visible = False

            Else
                Me.stbFileNo.Enabled = True
                Me.stbVisitNo.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmOutwardFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindOutwardNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindOutwardNo.Click
        Dim fFindOutwardNo As New frmFindAutoNo(Me.stbOutwardNo, AutoNumber.OutwardNo)
        fFindOutwardNo.ShowDialog(Me)
        Me.stbOutwardNo.Focus()
    End Sub

    Private Sub ClearControls()
        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbLastVisitDate.Clear()
    End Sub

    Private Sub SetNextOutwardNo(ByVal fileNo As String)

        Try

            Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("OutwardFiles", "OutwardNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim outwardID As String = oOutwardFiles.GetNextOutwardID(fileNo).ToString()
            outwardID = outwardID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbOutwardNo.Text = FormatText(fileNo + outwardID.Trim(), "OutwardFiles", "OutwardNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub stbFileNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbFileNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbFileNo))
            If String.IsNullOrEmpty(patientNo) Then Return
            Me.ShowFileDetails(patientNo)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbFileNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbFileNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbFileNo_Leave(Me, System.EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbFileNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbLastVisitDate.Text = FormatDate(DateMayBeEnteredIn(row, "LastVisitDate"))

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowFileDetails(ByVal fileNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(fileNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patients As DataTable = oPatients.GetPatients(fileNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbLastVisitDate.Text = FormatDate(DateEnteredIn(row, "LastVisitDate"))

            Me.stbFileNo.Text = FormatText(fileNo, "Patients", "PatientNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextOutwardNo(fileNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbFileNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbFileNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub stbOutwardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbOutwardNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oOutwardFiles.OutwardNo = RevertText(StringEnteredIn(Me.stbOutwardNo, "Outward No!"))
            DisplayMessage(oOutwardFiles.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outwardNo As String = RevertText(StringEnteredIn(Me.stbOutwardNo, "Outward No!"))
            Dim dataSource As DataTable = oOutwardFiles.GetOutwardFiles(outwardNo).Tables("OutwardFiles")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DisplayData(dataSource)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oOutwardFiles

                .FileNo = RevertText(StringEnteredIn(Me.stbFileNo, "File No!"))
                .OutwardNo = RevertText(StringEnteredIn(Me.stbOutwardNo, "Outward No!"))
                .TakenDateTime = DateTimeEnteredIn(Me.dtpTakenDateTime, "Taken Date Time!")
                .TakenBy = StringEnteredIn(Me.cboTakenBy, "Taken By!")
                .BillAccountName = StringMayBeEnteredIn(Me.stbBillAccountName)
                .VisitNo = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oOutwardFiles.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)

                    Me.dtpTakenDateTime.Value = Now
                    Me.dtpTakenDateTime.Checked = False
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oOutwardFiles.Update())
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

        Me.stbOutwardNo.ReadOnly = False
        Me.btnFindOutwardNo.Visible = True
        Me.btnLoad.Enabled = False

        ResetControlsIn(Me)
        Me.EnableOutwardFilesCTLS(False)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbOutwardNo.ReadOnly = InitOptions.OutwardNoLocked
        Me.btnFindOutwardNo.Visible = False

        ResetControlsIn(Me)

        Me.dtpTakenDateTime.Value = Now
        Me.dtpTakenDateTime.Checked = False
        Me.btnLoad.Enabled = True

        Me.EnableOutwardFilesCTLS(True)

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

    Private Sub EnableOutwardFilesCTLS(ByVal state As Boolean)

        Me.stbFileNo.Enabled = state

    End Sub

#End Region

End Class