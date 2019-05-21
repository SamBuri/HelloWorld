
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb

Public Class frmPhysicalStockCount

#Region " Fields "

#End Region

    Private Sub frmPhysicalStockCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            CloseExpiredPhysicalStockCount()
           
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub CloseExpiredPhysicalStockCount()
        Try
            Dim oPhysicalStockCount As New PhysicalStockCount()
            oPhysicalStockCount.CloseExpiredPhysicalStockCount(Now)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


    Private Sub frmPhysicalStockCount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oPhysicalStockCount.PSCNo = StringEnteredIn(Me.stbPSCNo, "PSCNo!")

            DisplayMessage(oPhysicalStockCount.Delete())
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

        Dim pSCNo As String

        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

        Try
            Me.Cursor = Cursors.WaitCursor()

            pSCNo = RevertText(StringEnteredIn(Me.stbPSCNo, "PSCNo!"))

            Dim dataSource As DataTable = oPhysicalStockCount.GetPhysicalStockCount(pSCNo).Tables("PhysicalStockCount")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oPhysicalStockCount

                .PSCNo = RevertText(StringEnteredIn(Me.stbPSCNo, "PSCNo!"))
                .GeneralNotes = StringEnteredIn(Me.stbGeneralNotes, "General Notes!")
                .StartDate = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Date!")
                .EndDate = DateTimeEnteredIn(Me.dtpEndDateTime, "End Date!")
                If .StartDate > .EndDate Then Throw New ArgumentException("Start Date Can't be greater than End Date")
                .Closed = Me.chkClosed.Checked
                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oPhysicalStockCount.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    SetNextPSCNo()
                Case ButtonCaption.Update

                    DisplayMessage(oPhysicalStockCount.Update())
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SetNextPSCNo()
        Dim yearL2 As String = Today.Year.ToString().Substring(2)
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPhyscialStockCount As New PhysicalStockCount()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("PhysicalStockCount", "PSCNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextPSCID As String = oPhyscialStockCount.GetNextPSCID().ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbPSCNo.Text = FormatText(yearL2 + nextPSCID.Trim(), "PhysicalStockCount", "PSCNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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
        SetNextPSCNo()

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