Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Threading.Thread


Public Class frmSendTextMessages
    
    Private Sub frmSendTextMessages_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
    End Sub

    Private Sub frmSendTextMessages_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

                  ShowUnSentMessages()
               
             '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ShowUnSentMessages()

        Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging
        Dim oYesNo As New LookupDataID.YesNoID
        Dim bulkMessaging As DataTable
        Dim oMyDefaultPCID As New LookupDataID.MyDefaultPC()
        Dim defaultpc As String = GetLookupDataDes(oMyDefaultPCID.DefaultPC)
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from bulk Messages

            If defaultpc = My.Computer.Name Then

                bulkMessaging = oBulkMessaging.GetUnSentMessages(oYesNo.No).Tables("BulkMessaging")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                LoadGridData(Me.dgvUnSentTextMessages, bulkMessaging)
                Me.lblRecordsNo.Text = " Returned Text(s): " + bulkMessaging.Rows.Count.ToString()
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Function FormatPhoneNo(ByVal phoneNo As String) As String
        Dim Value As String = phoneNo
        If phoneNo.StartsWith("0") Then
            Value = ("+256" + phoneNo)
        ElseIf phoneNo.StartsWith("+") Then
            Value = phoneNo
        End If

        Return Value


    End Function

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub tmrSendMessages_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSendMessages.Tick
        Try
            If Not String.IsNullOrEmpty(InitOptions.SMSNotificationPoint) Then
                  Me.ShowUnSentMessages()
              
                If dgvUnSentTextMessages.RowCount > 0 Then
                    Me.SendtextMessages()

                End If
            End If
        Catch eX As Exception
            Return

        End Try
    End Sub

    Private Sub SendtextMessages()

        Dim oVariousOptions As New VariousOptions()

        If oVariousOptions.UseSMSAPI001 Then
            For Each row As DataGridViewRow In dgvUnSentTextMessages.Rows
                Dim msisdn As String = StringMayBeEnteredIn(row.Cells, Me.colPhone)
                Dim Message As String = StringMayBeEnteredIn(row.Cells, Me.colMessages)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                TextMessageWithAPI001(Message, msisdn)
                ShowUnSentMessages()

            Next row
        End If



        If oVariousOptions.UseSMSAPI002 Then
            For Each row As DataGridViewRow In dgvUnSentTextMessages.Rows
                Dim msisdn As String = StringMayBeEnteredIn(row.Cells, Me.colPhone)
                Dim Message As String = StringMayBeEnteredIn(row.Cells, Me.colMessages)
                Dim MessageNo As String = StringMayBeEnteredIn(row.Cells, Me.ColMessageNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                TextMessageWithAPI002(MessageNo, Message, msisdn)
                ShowUnSentMessages()

            Next row
        End If

        If oVariousOptions.UseSMSAPI003 Then
            For Each row As DataGridViewRow In dgvUnSentTextMessages.Rows
                Dim msisdn As String = StringMayBeEnteredIn(row.Cells, Me.colPhone)
                Dim Message As String = StringMayBeEnteredIn(row.Cells, Me.colMessages)
                Dim MessageNo As String = StringMayBeEnteredIn(row.Cells, Me.ColMessageNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                TextMessageWithAPI003(MessageNo, Message, msisdn)
                ShowUnSentMessages()

            Next row
        End If

        If oVariousOptions.UseSMSAPI004 Then
            For Each row As DataGridViewRow In dgvUnSentTextMessages.Rows
                Dim msisdn As String = FormatPhoneNo(StringMayBeEnteredIn(row.Cells, Me.colPhone))
                Dim Message As String = StringMayBeEnteredIn(row.Cells, Me.colMessages)
                Dim MessageNo As String = StringMayBeEnteredIn(row.Cells, Me.ColMessageNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                TextMessageWithAPI004(MessageNo, Message, msisdn)
                ShowUnSentMessages()

            Next row
        End If


    End Sub


End Class