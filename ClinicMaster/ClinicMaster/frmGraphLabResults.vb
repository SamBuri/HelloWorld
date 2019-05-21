

Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Drawing2D

Public Class frmGraphLabResults

#Region " Fields "

    Private period() As String = {"Jan 10", "Feb 10", "Mar 10", "Apr 10", "May 10", "Jun 10", "Jul 10", "Aug 10", "Sep 10", "Oct 10", "Nov 10", "Dec 10"}
    Private results() As Integer = {835, 314, 672, 429, 715, 642, 153, 699, 622, 901, 345, 655}

    '  ~~  Variables for margins and outlines, etc ~~
    '  # of pixels Y-Axis is inset from PicBox Left
    Private leftMargin As Integer = 35
    '  # of Pixels left unused at right side of PicBox
    Private rightMargin As Integer = 15
    '  # of pixels above base of picturebox the X-Axis is placed
    Private baseMargin As Integer = 35
    '  Margin at Top
    Private topMargin As Integer = 10

    '  Variable to hold length of vertical axis
    Private vertLineLength As Integer
    '  Variable to hold length of horizontal axis
    Private baseLineLength As Integer
    '  Variable to store length of each line segment
    Private lineWidth As Double

    '  ~~  Bitmap and Graphics Objects  ~~
    '  A variable to hold a Graphics object
    Private g As Graphics
    '    Next, create a Bitmap object which is
    '    the same size and resolution as the PictureBox
    Private lineChart As Bitmap

    'Vertical Intervals
    Private vertInterval As Integer = 20

    'Vertical start value
    Private vertStartValue As Integer = 50

#End Region

    Private Sub frmGraphLabResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.spbGraphLabResults.SizeMode = PictureBoxSizeMode.Normal
            Me.LoadNumericLabTests()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmGraphLabResults_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadNumericLabTests()

        Dim labTests As New DataTable()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try

            Me.Cursor = Cursors.WaitCursor

            labTests = oLabTests.GetNumericLabTests().Tables("LabTests")
            If labTests Is Nothing OrElse labTests.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLabTest, labTests, "TestFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ClearControls()
        Me.txtFullName.Clear()
        Me.txtAge.Clear()
        Me.txtGender.Clear()
        Me.txtFirstVisitDate.Clear()
        Me.txtLastVisitDate.Clear()
        Me.txtTotalVisits.Clear()
    End Sub

    Private Sub txtPatientNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPatientNo.Leave

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim patients As New DataTable()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.txtPatientNo))
            If String.IsNullOrEmpty(patientNo) Then Return

            Me.ClearControls()

            patients = oPatients.GetPatients(patientNo).Tables("Patients")

            Dim row As DataRow = patients.Rows(0)

            Me.txtPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")

            Me.txtFullName.Text = StringEnteredIn(row, "FullName")
            Me.txtGender.Text = StringEnteredIn(row, "Gender")
            Me.txtAge.Text = StringEnteredIn(row, "Age")
            Me.txtFirstVisitDate.Text = FormatDate(DateEnteredIn(row, "FirstVisitDate"))
            Me.txtLastVisitDate.Text = FormatDate(DateMayBeEnteredIn(row, "LastVisitDate"))
            Me.txtTotalVisits.Text = StringEnteredIn(row, "TotalVisits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub txtPatientNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPatientNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub btnDrawChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrawChart.Click

        Try

            vertInterval = Me.nbxVerticalInterval.GetInteger()
            vertStartValue = Me.nbxVerticalStartValue.GetInteger()

            Me.DrawOutline()
            Me.DrawHorizontalLines()
            Me.DrawVerticalGridLines()
            Me.DrawTheline()
            Me.ShowMonths()
            Me.FinalDisplay()

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub DrawOutline()

        ' Instantiate bmap and set its width and height to that of the PictureBox.
        ' Also set the bitmap's resolution to that of the PictureBox

        lineChart = New Bitmap(Me.spbGraphLabResults.Width, Me.spbGraphLabResults.Height, Me.spbGraphLabResults.CreateGraphics)
        ' Assign the Bitmap to the Graphics object.  

        g = Graphics.FromImage(lineChart)

        ' Draw a line for the Vertical Axis.
        Dim startPoint As New Point(leftMargin, Me.spbGraphLabResults.Height - baseMargin)
        Dim endPoint As New Point(leftMargin, topMargin)

        ' Basic Pen to draw outline lines
        Dim linePen As New Pen(Color.Black, 2)
        '  Draw the vertical line
        g.DrawLine(linePen, startPoint, endPoint)

        vertLineLength = Me.spbGraphLabResults.Height - (baseMargin + topMargin)
        Dim vertGap As Integer = CInt(vertLineLength / vertInterval)

        Dim tickSP As New Point(leftMargin - 5, startPoint.Y - vertGap)
        Dim tickEP As New Point(leftMargin, startPoint.Y - vertGap)

        Dim valueFont As New Font("Arial", 8, FontStyle.Regular)

        For i As Integer = 1 To vertInterval
            '  Tick mark
            g.DrawLine(New Pen(Color.Black), tickSP, tickEP)
            '  Tick Values as text
            g.DrawString(CStr(i * vertStartValue), valueFont, Brushes.Black, 2, tickSP.Y - 5)
            '  Reset y positions, moving 10% up vertical line
            tickSP.Y -= vertGap
            tickEP.Y -= vertGap
        Next

        g.DrawLine(linePen, leftMargin, Me.spbGraphLabResults.Height - baseMargin, Me.spbGraphLabResults.Width - rightMargin, Me.spbGraphLabResults.Height - baseMargin)

    End Sub

    Private Sub DrawTheline()

        '  Calculate length of baseline drawn by the previous procedure
        baseLineLength = Me.spbGraphLabResults.Width - (leftMargin + rightMargin)
        '  Calculate the width of each line segment
        lineWidth = (baseLineLength / results.Length)

        Dim vertScale As Double = vertLineLength / (vertInterval * vertStartValue)

        Dim x1 As Integer = CInt(leftMargin + 30)
        Dim x2 As Integer = CInt(x1 + lineWidth)

        Dim y1 As Integer = CInt(results(0) * vertScale)
        Dim y2 As Integer = CInt(results(1) * vertScale)

        Dim myPath As New GraphicsPath()

        ' Manually add the first circle to the path
        myPath.AddEllipse(x1 - 2, y1 - 2, 4, 4)
        '  Manually add the first line to the Path
        myPath.AddLine(x1, y1, x2, y2)

        For i As Integer = 1 To UBound(results) - 1
            '  Update the X and Y positions for the next value:
            '  Move start point one line width to the right
            x1 = x2
            '  Move end point one line width to the right
            x2 = CInt(x1 + lineWidth)
            ' Assign YPosStart the 'old' value of Y
            y1 = y2
            ' Assign YPosEnd the next the next scaled Sales figure
            y2 = CInt(results(i + 1) * vertScale)

            '  Add next circle
            myPath.AddEllipse(x1 - 2, y1 - 2, 4, 4)
            '  Add this line segment to the GraphicsPath
            myPath.AddLine(x1, y1, x2, y2)

        Next

        '  Finally, manually add the last circle
        myPath.AddEllipse(x2 - 2, y2 - 2, 4, 4)

        '  We want the line to go in opposite direction, so rotate by 180 degrees
        g.RotateTransform(180)

        '  Because the rotation also moves the line out of view (to the left), so
        '  we need to scale the x so that it is on the (plus) side of the
        '  vertical axis.
        '  The Y value remains unchanged, so a "scale" of 1 is used.
        '  (i.e. no change made)
        g.ScaleTransform(-1, 1)

        ' Move the start point down to the bottom left corner
        ' The X value remains the same
        ' Y is shifted down to the end of the vertical axis, adjusted by
        ' a fudge factor of 10 to compensate for the vertical scaling.
        g.TranslateTransform(0, vertLineLength + 10, MatrixOrder.Append)

        Dim myPen As Pen = New Pen(Color.Blue, 3)
        g.DrawPath(myPen, myPath)

        g.ResetTransform()

    End Sub

    Private Sub ShowMonths()

        '  Set the start point of the first string
        Dim textStartX As Integer = CInt(leftMargin + 18)

        '  Create a Brush to draw the text
        Dim textBrsh As Brush = New SolidBrush(Color.Black)
        '  Create a Font object instance for text display
        Dim textFont As New Font("Arial", 10, FontStyle.Regular)

        For i As Integer = 0 To period.Length - 1
            '  Draw the name of the month
            g.DrawString(period(i), textFont, textBrsh, textStartX, _
                CInt(Me.spbGraphLabResults.Height - (baseMargin - 4)))
            '  Move start point for next name along to the right
            textStartX += CInt(lineWidth)
        Next

        textBrsh.Dispose()
        textFont.Dispose()

    End Sub

    Private Sub DrawHorizontalLines()
        '  Calculate vertically equal gaps
        Dim vertGap As Integer = CInt(vertLineLength / vertInterval)

        '  Set the Start and End points
        '  = Left and right margins on the baseline
        Dim startPoint As New Point(leftMargin + 3, Me.spbGraphLabResults.Height - baseMargin)
        Dim endPoint As New Point(Me.spbGraphLabResults.Width, Me.spbGraphLabResults.Height - baseMargin)

        '  Initial settings
        Dim lineStart As New Point(startPoint.X, startPoint.Y - vertGap)
        Dim lineEnd As New Point(endPoint.X, startPoint.Y - vertGap)

        Dim thinPen As New Pen(Color.LightGray, 1)

        For i As Integer = 1 To vertInterval
            '  Draw a line
            g.DrawLine(thinPen, lineStart, lineEnd)

            '  Reset Start and End Y positions, moving up the vertical line
            lineStart.Y -= vertGap
            lineEnd.Y -= vertGap
        Next

        thinPen.Dispose()

    End Sub

    Private Sub DrawVerticalGridLines()

        Dim thinPen As New Pen(Color.Bisque, 1)

        '  Calculate length of baseline drawn by the code above
        baseLineLength = Me.spbGraphLabResults.Width - (leftMargin + rightMargin)
        '  Calculate the width of each line segment
        lineWidth = (baseLineLength / results.Length)

        '  Set the start point of the first string
        Dim lineStartX As Integer = CInt(leftMargin + 30)

        For i As Integer = 0 To period.Length - 1
            g.DrawLine(thinPen, lineStartX, topMargin, lineStartX, Me.spbGraphLabResults.Height - (baseMargin + 4))

            '  Move start point along to the right
            lineStartX += CInt(lineWidth)
        Next

        thinPen.Dispose()

    End Sub

    Private Sub FinalDisplay()
        Me.spbGraphLabResults.Image = lineChart
        g.Dispose()
    End Sub

End Class