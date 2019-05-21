Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing
Imports System.Collections.Generic

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona


Public Class frmLabResultsApproval

    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now

    Private iPDAlerts As DataTable
    Private iPDAlertsStartDateTime As Date = Now

    Private attendingDoctorNo As String = String.Empty
    Private labRequestsCount As Integer = 0
    Private totalLabRequests As Integer = 0
    Private doctorStaffNo As String = String.Empty
    Private oAlertTypeID As New LookupDataID.AlertTypeID()
    Private m_PagesPrinted As Integer


    Private Sub frmLabResultsApproval_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        ''''''''''''''''''''
        Me.ShowSentAlerts()
        Me.ShowSentIPDAlerts()
        Me.GetCountUnApprovedLabResults()
        ''''''''''''''''''''
    End Sub


    Private Sub frmLabResultsApproval_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.LoadStaff()
            Me.ShowSentAlerts()
            Me.ShowSentIPDAlerts()
            Me.GetCountUnApprovedLabResults()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub frmLabResultsApproval_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindSpecimenNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSpecimenNo.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindSpecimenNo As New frmFindAutoNo(Me.stbSpecimenNo, AutoNumber.SpecimenNo)
        fFindSpecimenNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowLabResultsData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnLoadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadList.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fDoneLabResults As New frmLabResultsNotApproved(Me.stbSpecimenNo)
        fDoneLabResults.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowLabResultsData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Function GetCountUnApprovedLabResults() As Integer

        Dim olabTests As New SyncSoft.SQLDb.LabResults()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = olabTests.GetCountUnApprovedLabResults()

            Me.lblLabResultsAlerts.Text = "Unapproved Ready Results: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub ClearControls()

        Me.stbDrawnBy.Clear()
        Me.stbDrawnDateTime.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbAge.Clear()
        Me.lblAgeString.Text = String.Empty
        Me.stbBillCustomerName.Clear()
        Me.stbBillMode.Clear()
        Me.stbAdmissionLocation.Clear()
        Me.dgvLabResults.Rows.Clear()
        'Me.dgvPendingResults.Rows.Clear()
        Me.clbRunby.Items.Clear()
        Me.stbVisitCategory.Clear()
        attendingDoctorNo = String.Empty
        doctorStaffNo = String.Empty
        Me.chkIsAdmitted.Checked = False
    End Sub

    Private Sub stbSpecimenNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbSpecimenNo.Leave
        Me.ShowLabResultsData()
    End Sub

    Private Sub stbSpecimenNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbSpecimenNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.LabTechnologist).Tables("Staff")


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowLabResultsData()

        Try
            Dim specimenNo As String = RevertText(StringMayBeEnteredIn(stbSpecimenNo))
            If Not String.IsNullOrEmpty(specimenNo) Then Me.ShowLabPendingLabRequests(specimenNo)
            If Not String.IsNullOrEmpty(specimenNo) Then Me.LoadLabResults(specimenNo)
            'End If

            ResetControlsIn(Me.pnlNavigateLabResults)

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateLabResults)
        End Try

    End Sub

    Private Sub LoadLabResults(ByVal specimenNo As String)

        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Try
            Me.Cursor = Cursors.WaitCursor


            Dim labResults As DataTable = oLabResults.GetUnApprovedLabResults(specimenNo).Tables("LabResults")
            If labResults Is Nothing OrElse labResults.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowResultsDetails(specimenNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabResults, labResults)

            Dim message As String = "No " + Me.Text + " Un Approved Lab Result(s) found for the Specimen No " _
                      + stbSpecimenNo.Text + "!"

            If labResults.Rows.Count < 1 Then DisplayMessage(message)

            For Each row As DataGridViewRow In Me.dgvLabResults.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabResults.Item(Me.colInclude.Name, row.Index).Value = True
                If CBool(Me.dgvLabResults.Item(Me.colHasSubResults.Name, row.Index).Value).Equals(True) AndAlso
                    Not String.IsNullOrEmpty(Me.dgvLabResults.Item(Me.colResult.Name, row.Index).Value.ToString()) Then
                    Me.dgvLabResults.Item(Me.colExcludeSubResults.Name, row.Index).Value = True
                Else : Me.dgvLabResults.Item(Me.colExcludeSubResults.Name, row.Index).Value = False
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim labStaff As EnumerableRowCollection(Of DataRow) = labResults.AsEnumerable()
            Dim runby As String = (From data In labStaff Select data.Field(Of String)("LabTechnologistName")).Distinct.First()
            Dim labTechnologists As IEnumerable(Of String) = (From data In labStaff Select
                                                              data.Field(Of String)("LabTechnologistName")).Distinct

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.clbRunby.Items.Clear()
            For Each labTechnologistName As String In labTechnologists
                Me.clbRunby.Items.Add(labTechnologistName, True)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub




    Private Sub ShowLabPendingLabRequests(ByVal specimenNo As String)

        Dim oLabResults As New SyncSoft.SQLDb.LabResults()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientResultsMsg As String = " This Patient has Tests(s) without Results" + ControlChars.NewLine + "Please take note"

            Dim pendingLab As DataTable = oLabResults.GetPendingLabRequestsDetails(specimenNo).Tables("LabRequestDetails")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If pendingLab Is Nothing OrElse pendingLab.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowResultsDetails(specimenNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadGridData(Me.dgvPendingResults, pendingLab)



            If pendingLab.Rows.Count > 0 Then

                ErrProvider.SetError(Me.tpgUnapprovedTests, patientResultsMsg)
                ErrProvider.SetIconAlignment(Me.tpgUnapprovedTests, ErrorIconAlignment.TopLeft)
                ErrProvider.SetIconPadding(Me.tpgUnapprovedTests, -8)

            Else
                ErrProvider.SetError(Me.tpgUnapprovedTests, String.Empty)

            End If


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowResultsDetails(ByVal specimenNo As String)

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim iPDItems As New DataTable()
            Dim items As New DataTable()
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItemStatusID As New LookupDataID.ItemStatusID()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbSpecimenNo.Text = FormatText(specimenNo, "LabRequests", "SpecimenNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
          


            Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Dim requestRow As DataRow = labRequests.Rows(0)
            Dim visitNo As String = RevertText(StringEnteredIn(requestRow, "VisitNo"))

            Me.stbDrawnBy.Text = StringEnteredIn(requestRow, "DrawnByName")
            Me.stbDrawnDateTime.Text = FormatDateTime(DateTimeEnteredIn(requestRow, "DrawnDateTime"))
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(requestRow, "PrimaryDoctor")
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(requestRow, "RoundNo"))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim visitRow As DataRow = visits.Rows(0)
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(visitRow, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(visitRow, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(visitRow, "FullName")
            Me.stbGender.Text = StringEnteredIn(visitRow, "Gender")
            Me.stbAge.Text = StringEnteredIn(visitRow, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(visitRow, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
            Me.stbBillCustomerName.Text = StringEnteredIn(visitRow, "BillCustomerName")
            Me.stbBillMode.Text = StringEnteredIn(visitRow, "BillMode")
            Me.stbAdmissionLocation.Text = StringMayBeEnteredIn(visitRow, "AdmissionLocation")
            Me.stbVisitCategory.Text = StringEnteredIn(visitRow, "VisitCategory")
            doctorStaffNo = StringMayBeEnteredIn(requestRow, "DoctorStaffNo")
            totalLabRequests = IntegerMayBeEnteredIn(requestRow, "TotalLabRequests")
            Me.chkIsAdmitted.Checked = BooleanMayBeEnteredIn(requestRow, "IsAdmitted")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If chkIsAdmitted.Checked = True Then
                iPDItems = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Test, oItemStatusID.Processing).Tables("IPDItems")
                labRequestsCount = iPDItems.Rows.Count
            Else
                items = oItems.GetItems(visitNo, oItemCategoryID.Test, oItemStatusID.Processing).Tables("Items")
                labRequestsCount = items.Rows.Count
            End If


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub BtnViewIPDLabRequests_Click(sender As System.Object, e As System.EventArgs) Handles BtnViewIPDLabRequests.Click
        Me.ShowSentIPDAlerts()
        frmIPDLabRequests.ShowDialog()
    End Sub

    Private Sub btnViewList_Click(sender As System.Object, e As System.EventArgs) Handles btnViewList.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentAlerts()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        frmLabRequests.ShowDialog()

    End Sub

    Private Function ShowSentAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            alerts = oAlerts.GetAlerts(oAlertTypeID.LabRequests).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Doctor Lab Requests: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowSentIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.LabRequests).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "IPD Doctor Lab Requests: " + iPDAlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return iPDAlertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

#Region " Lab Results Navigate "

    Private Sub EnableNavigateLabResultsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim labResults As DataTable
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                labResults = oLabResults.GetLabResultsByPatientNo(patientNo).Tables("LabResults")

                For pos As Integer = 0 To labResults.Rows.Count - 1
                    If specimenNo.ToUpper().Equals(labResults.Rows(pos).Item("SpecimenNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navLabResults.DataSource = labResults
                Me.navLabResults.Navigate(startPosition)

            Else : Me.navLabResults.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateLabResults.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateLabResults_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateLabResults.Click
        Me.EnableNavigateLabResultsCTLS(Me.chkNavigateLabResults.Checked)
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navLabResults.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim specimenNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(specimenNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbSpecimenNo.Text = FormatText(specimenNo, "LabRequests", "SpecimenNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLabResults(specimenNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub btnViewLabResultsList_Click(sender As System.Object, e As System.EventArgs) Handles btnViewLabResultsList.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fLabResultsAllUnApproved As New frmLabResultsAllUnApproved(Me.stbSpecimenNo)
        fLabResultsAllUnApproved.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowLabResultsData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnApprove_Click(sender As System.Object, e As System.EventArgs) Handles btnApprove.Click

        Dim oApprovedLabResults As New SyncSoft.SQLDb.ApprovedLabResults()
        Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Select Case Me.tpgUnapprovedTests.SelectedTab.Name

            Case tpgReadyResults.Name

                Try
                    Me.Cursor = Cursors.WaitCursor()
                    Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "SpecimenNo!"))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim nonSelected As Boolean = False

                    For Each row As DataGridViewRow In Me.dgvLabResults.Rows
                        If row.IsNewRow Then Exit For
                        If CBool(Me.dgvLabResults.Item(Me.colInclude.Name, row.Index).Value) = True Then
                            nonSelected = False
                            Exit For
                        End If
                        nonSelected = True
                    Next

                    If Me.dgvLabResults.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on Lab Results Approval!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To Me.dgvLabResults.RowCount - 1

                        If CBool(Me.dgvLabResults.Item(Me.colInclude.Name, rowNo).Value) = True Then

                            Dim cells As DataGridViewCellCollection = Me.dgvLabResults.Rows(rowNo).Cells
                            Dim testCode As String = StringEnteredIn(cells, Me.colTestCode, "Test Code!")
                            Dim testName As String = StringEnteredIn(cells, Me.colTestName, "Test Name")

                            With oApprovedLabResults

                                .SpecimenNo = specimenNo
                                .TestCode = testCode
                                .TestName = testName
                                .LoginID = CurrentUser.LoginID

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                ValidateEntriesIn(Me)
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                .Save()

                            End With


                        End If
                    Next

                    If chkIsAdmitted.Checked = False AndAlso Not String.IsNullOrEmpty(doctorStaffNo) Then

                        Dim labRequests As DataTable = oLabRequests.GetLabRequests(RevertText(specimenNo)).Tables("LabRequests")
                        Dim visitNo As String = labRequests.Rows(0).Item("VisitNo").ToString()

                        Using oAlerts As New SyncSoft.SQLDb.Alerts()
                            With oAlerts

                                .AlertTypeID = oAlertTypeID.LabResults
                                .VisitNo = visitNo
                                .StaffNo = doctorStaffNo
                                .Notes = (totalLabRequests - labRequestsCount).ToString() + " of " + totalLabRequests.ToString() + " Done"
                                .LoginID = CurrentUser.LoginID

                                .Save()

                            End With
                        End Using


                    ElseIf chkIsAdmitted.Checked = True AndAlso Not String.IsNullOrEmpty(doctorStaffNo) Then

                        Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
                        Dim roundNo As String = CStr(labRequests.Rows(0).Item("RoundNo"))
                        Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(RevertText(roundNo)).Tables("IPDDoctor")

                        Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                            With oIPDAlerts

                                .AlertTypeID = oAlertTypeID.LabResults
                                .RoundNo = roundNo
                                .StaffNo = attendingDoctorNo
                                .Notes = (totalLabRequests - labRequestsCount).ToString() + " of " + totalLabRequests.ToString() + " Done"
                                .LoginID = CurrentUser.LoginID

                                .Save()

                            End With
                        End Using
                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ClearControls()
                    Me.ShowSentAlerts()
                    Me.ShowSentIPDAlerts()
                    Me.GetCountUnApprovedLabResults()
                    Me.ShowLabResultsData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Catch ex As Exception
                    ErrorMessage(ex)

                Finally
                    Me.Cursor = Cursors.Default()

                End Try

                'Case tpgProcessingResults.Name

        End Select



    End Sub
End Class