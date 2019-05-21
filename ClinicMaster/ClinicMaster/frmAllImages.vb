Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmAllImages

#Region " Fields "
    Private defaultVisitNo As String = String.Empty

#End Region

    Private Sub frmAllImages_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Cursor = Cursors.WaitCursor()



            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.LoadAllPhotos(defaultVisitNo)
                Me.ProcessTabKey(True)
            Else : Me.stbVisitNo.ReadOnly = False
                Me.ResetControls()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim visitNo As String
        Dim patientNo As String
        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then


                visitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                patientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navExtraBills.DataSource = visits
                Me.navExtraBills.Navigate(startPosition)

            Else : Me.navExtraBills.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateImages.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateImages_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateImages.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateImages.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navExtraBills.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.LoadAllPhotos(visitNo)


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub ResetControls()

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlNavigateAllImages)

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPeriodicVisits.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadAllPhotos(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub btnFindVisitNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindVisitNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadAllPhotos(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


    Private Sub LoadAllPhotos(ByVal visitNo As String)


        Dim oVisits As New SyncSoft.SQLDb.AllImages()

        Try


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visits As DataTable = oVisits.GetAllImages(visitNo).Tables("AllImages")
            Dim row As DataRow = visits.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = StringMayBeEnteredIn(row, "PatientNo")

            Me.stbProvisionalDiagnosis.Text = StringMayBeEnteredIn(row, "Description")

            Me.spImage.Image = ImageMayBeEnteredIn(row, "Image")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbVisitNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadAllPhotos(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbVisitNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.Leave
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadAllPhotos(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnZoomOut_Click(sender As System.Object, e As System.EventArgs) Handles btnZoomOut.Click
        Try
            Me.spImage.Width += 20%
            Me.spImage.Height += 20%
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnZoomIn_Click(sender As System.Object, e As System.EventArgs) Handles btnZoomIn.Click
        Try
            Me.spImage.Width -= 20%
            Me.spImage.Height -= 20%
        Catch ex As Exception

        End Try
    End Sub
End Class