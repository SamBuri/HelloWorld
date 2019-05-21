Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.SQLDb

Public Class frmQueues

#Region " Fields "
    Private oVariousOptions As New VariousOptions()
    Private MaxReadCount As Integer = (oVariousOptions.QueueReadCount + 1)
    Private readCount As Integer = 0
#End Region

    Private Sub frmSpeak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadQueues()
            tmrQueues.Start()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSpeak_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        tmrQueues.Stop()
    End Sub




    Public Sub LoadQueues()
        Try
            Dim oQueue As New Queues
            Dim queues As DataTable = oQueue.GetQueues(String.Empty, GetServicePointQueue(), GetBranchID).Tables("Queues")
            If queues.Rows.Count() < 1 Then Return

            LoadGridData(dgvQueues, queues)
        Catch Ex As Exception
            ErrorMessage(Ex)
        Finally
        End Try
    End Sub

    Public Sub LoadUnReadQueuedMessages()
        Try
            Dim oQueuedMessages As New QueuedMessages
            Dim queuedMessage As DataTable = oQueuedMessages.GetUnReadQueuedMessages(GetBranchID, GetServicePointQueue(), MaxReadCount).Tables("QueuedMessages")
            Dim oVisits As New Visits()
            If queuedMessage.Rows.Count() < 1 Then Return


            Dim row As DataRow = queuedMessage.Rows(0)
            Dim ReadTimes As Integer = 0

            Dim roomName As String = StringEnteredIn(row, "RoomName")
            Dim servicePointID As String = StringEnteredIn(row, "ServicePointID")
            Dim servicePoint As String = StringEnteredIn(row, "ServicePoint")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")
            Dim tokenNo As String = StringMayBeEnteredIn(row, "TokenNo")
            readCount = IntegerEnteredIn(row, "ReadCount")




            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim patientRow As DataRow = visits.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim patientNo As String = StringEnteredIn(patientRow, "PatientNo")
            Dim firstName As String = StringEnteredIn(patientRow, "FirstName")
            Dim room As String = InitOptions.RoomName

            Dim displayText As String = (firstName + " " + patientNo + " " + roomName).ToUpper
            Dim message As String = firstName + ": Number: " + patientNo + ": go to " + roomName





            If (readCount < 1) Then
                Beep(400, 500)
                stbCurrentPatient.Text = displayText
                Dim statusStyle As New DataGridViewCellStyle()

                statusStyle.BackColor = Color.MistyRose

                For Each rows As DataGridViewRow In Me.dgvQueues.Rows
                    If rows.IsNewRow Then Exit For
                    Dim visitNoToHight As String = StringMayBeEnteredIn(rows.Cells, Me.colVisitNo)
                    Dim servicePointToHight As String = StringMayBeEnteredIn(rows.Cells, Me.colServicePoint)
                    Dim tokenNoPointToHight As String = StringMayBeEnteredIn(rows.Cells, Me.colTokenNo)

                    If visitNoToHight.Equals(visitNo) AndAlso servicePointToHight.Equals(servicePoint) AndAlso
                        tokenNoPointToHight.Equals(tokenNo) Then
                        Me.dgvQueues.Rows(rows.Index).DefaultCellStyle.ApplyStyle(statusStyle)

                    End If

                Next

            Else

                Speak(message)

            End If
            readCount += 1
            SaveQueuedMessage(visitNo, servicePointID, tokenNo, readCount)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If readCount = MaxReadCount Then
                stbCurrentPatient.Clear()
                LoadQueues()
            End If



        Catch Ex As Exception
            ErrorMessage(Ex)
        Finally
        End Try
    End Sub


    Private Function Speak(ByVal text As String) As Boolean
        Try
            Dim oVoice As New SpeechLib.SpVoice
            Dim cpFileStream As New SpeechLib.SpFileStream

            oVoice.Voice = oVoice.GetVoices.Item(InitOptions.Voice)
            oVoice.Volume = 100
            oVoice.Rate = -2
            oVoice.Speak(text,
            SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault)
            oVoice = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub frmQueues_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        tmrQueues.Stop()
    End Sub

    Declare Function Beep Lib "kernel32.dll" (ByVal dwFreq As Integer,
    ByVal dwDuration As Integer) As Boolean

    Private Sub tmrQueues_Tick(sender As Object, e As EventArgs) Handles tmrQueues.Tick
        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Prevent the computer  from sleeping by adjusting the cursor positions
            Dim oldpos As Point = Cursor.Position
            Dim change As Integer = -1
            If oldpos.X = 0 Then change = 1
            Cursor.Position = New Point(oldpos.X + change, oldpos.Y)
            Cursor.Position = oldpos

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadUnReadQueuedMessages()

            If (readCount >= MaxReadCount) Then
                LoadQueues()
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

End Class