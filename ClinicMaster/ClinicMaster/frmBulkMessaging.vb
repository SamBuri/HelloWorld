
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Public Class frmBulkMessaging

#Region " Fields "
    Private ArrayText() As String
    Private Str As String
    Private StringCount As Integer
#End Region


    Private Sub frmBulkMessaging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            Me.Cursor = Cursors.WaitCursor()

            '    Me.stbOwner.Text = AppData.ProductOwner + "Via-ClinicMaster"

            Me.SetNextMessageNo()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub frmBulkMessaging_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub


    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub


    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oBulkMessaging.MessageNo = StringEnteredIn(Me.stbMessageNo, "MessageNo!")

            DisplayMessage(oBulkMessaging.Delete())
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

        Dim messageNo As String

        Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()

        Try
            Me.Cursor = Cursors.WaitCursor()

            messageNo = StringEnteredIn(Me.stbMessageNo, "MessageNo!")

            Dim dataSource As DataTable = oBulkMessaging.GetBulkMessaging(messageNo).Tables("BulkMessaging")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub



    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim oVariousOptions As New VariousOptions()
        Dim splitChar As Char = ","c
        Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()
        Dim Message As String
        Try
		Me.Cursor = Cursors.WaitCursor()

            With oBulkMessaging

                .MessageNo = RevertText(StringEnteredIn(Me.stbMessageNo, "MessageNo!"))
                .Phone = StringEnteredIn(Me.stbPhone, "Phone Numbers!")
                .Message = StringEnteredIn(Me.stbMessage, "Message!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With



            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    Str = stbPhone.Text
                    ArrayText = Str.Split(splitChar)
                    StringCount = ArrayText.Count
                   
                    Message = "You are about to send :" + " " + StringCount.ToString + " " + "Message(s)" + " " + "Are you sure you want to send them?"
                    If WarningMessage(Message) = Windows.Forms.DialogResult.No Then Return

                    Dim respondent As String = Trim(stbPhone.Text)
                    Dim txtmessage As String = Trim(stbMessage.Text)

                    Dim footer As String = AppData.ProductOwner + " Via -ClinicMaster"
                    Dim finalmesssage As String = txtmessage + " " + footer
                    SaveTextMessage(finalmesssage, respondent, Now, oVariousOptions.SMSLifeSpanVisits)
                    ' oBulkMessaging.Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.SetNextMessageNo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oBulkMessaging.Update())
                    Me.CallOnKeyEdit()

            End Select

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

        End Try


End Sub


#Region "helper"

    Private Sub SetNextMessageNo()


        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oPurchaseOrders As New SyncSoft.SQLDb.BulkMessaging
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BulkMessaging", "MessageNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim purchaseOrderNo As String = yearL2 + oPurchaseOrders.GetNextMessageID.ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbMessageNo.Text = FormatText(purchaseOrderNo, "BulkMessaging", "MessageNo")

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
        Me.SetNextMessageNo()
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


    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim fTemplates As New frmGetPatientPhoneNos(Me.stbPhone)
            fTemplates.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''
            

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class