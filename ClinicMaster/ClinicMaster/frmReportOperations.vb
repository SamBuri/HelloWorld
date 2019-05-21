Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Public Class frmReportOperations

    Private Sub frmReportOperations_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.cboItemCategoryID, LookupObjects.ItemCategory, True)
            LoadLookupDataCombo(Me.cboItemStatusID, LookupObjects.ItemStatus, True)
            LoadLookupDataCombo(Me.CboPayStatusID, LookupObjects.PayStatus, True)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Sub ShowDoctorVisits(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal itemCategoryID As String)

        Dim ovisitStatusSummaries As New SyncSoft.SQLDb.Visits

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Items
            Dim visitStatusSummaries As DataTable = ovisitStatusSummaries.GetOPDDoctorVisits(startDateTime, endDateTime, itemCategoryID).Tables("Visits")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDoctorVisits, visitStatusSummaries)
            FormatGridRow(Me.dgvDoctorVisits)



        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowItemStatusSummaries(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal itemCategoryID As String)

        Dim oItemStatusSummaries As New SyncSoft.SQLDb.Items

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Items
            Dim itemStatusSummaries As DataTable = oItemStatusSummaries.GetItemStatusSummaries(startDateTime, endDateTime, itemCategoryID).Tables("Items")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvItems, itemStatusSummaries)
            FormatGridRow(Me.dgvItems)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvItems.Rows
                If row.IsNewRow Then Exit For
                Dim pendinngItems As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.ColPending)
                If pendinngItems > 0 Then Me.dgvItems.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOperationalOPDItemsReport(ByVal payStatusID As String, ByVal itemStatusID As String, ByVal startDateTime As Date, ByVal endDateTime As Date)
        Dim oGetOperationalOPDItemsReport As New SyncSoft.SQLDb.Items

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Items
            Dim operationalOPDItemsReport As DataTable = oGetOperationalOPDItemsReport.GetOperationalOPDItemsReport(startDateTime, endDateTime, payStatusID, itemStatusID, Nothing, Nothing).Tables("Items")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOPDItemsStatus, operationalOPDItemsReport)
            FormatGridRow(Me.dgvOPDItemsStatus)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If operationalOPDItemsReport IsNot Nothing AndAlso operationalOPDItemsReport.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniOPDItemsReport As EnumerableRowCollection(Of DataRow) = operationalOPDItemsReport.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniOPDItemsReport Select data.Field(Of Decimal)("TotalAmount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbTotalAmount.Clear()
                Me.stbAmountWords.Clear()
            End If


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

      Private Sub ShowPatientRegistrationDetails(ByVal startDateTime As Date, ByVal endDateTime As Date)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oPatientRegistrationsDetails As New SyncSoft.SQLDb.Patients
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load from Items
            Dim PatientRegistrationsDetails As DataTable = oPatientRegistrationsDetails.GetPatientRegistrationDetails(startDateTime, endDateTime).Tables("Patients")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPatientRegistration, PatientRegistrationsDetails)
            FormatGridRow(Me.dgvPatientRegistration)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowVisitRegistrationDetails(ByVal startDateTime As Date, ByVal endDateTime As Date)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oVisitRegistrationDetails As New SyncSoft.SQLDb.Visits
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load from Items
            Dim VisitRegistrationDetails As DataTable = oVisitRegistrationDetails.GetVisitRegistrationDetails(startDateTime, endDateTime).Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvVisitRegistration, VisitRegistrationDetails)
            FormatGridRow(Me.dgvVisitRegistration)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowOutWardFilesSummary(ByVal startDateTime As Date, ByVal endDateTime As Date)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim OutWardFilesSummary As DataTable = oOutwardFiles.GetOutWardFilesSummary(startDateTime, endDateTime).Tables("OutwardFiles")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvFileStatus, OutWardFilesSummary)
            FormatGridRow(Me.dgvFileStatus)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowNotSeenOutWardFiles(ByVal startDateTime As Date, ByVal endDateTime As Date)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim OutWardFilesSummary As DataTable = oOutwardFiles.GetNotSeenOutWardFiles(startDateTime, endDateTime).Tables("OutwardFiles")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvFilesNotSeenByDoctor, OutWardFilesSummary)
            FormatGridRow(Me.dgvFilesNotSeenByDoctor)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDoctorSeenOutWardFiles(ByVal startDateTime As Date, ByVal endDateTime As Date)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim OutWardFilesSummary As DataTable = oOutwardFiles.GetDoctorSeenOutWardFiles(startDateTime, endDateTime).Tables("OutwardFiles")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvFilesSeenByDoctor, OutWardFilesSummary)
            FormatGridRow(Me.dgvFilesSeenByDoctor)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowOverStayedAdmissions(ByVal startDateTime As Date, ByVal endDateTime As Date)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oGetOverStayedAdmissions As DataTable = oAdmissions.GetOverStayedAdmissions(startDateTime, endDateTime).Tables("Admissions")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvUnclosedVisits, oGetOverStayedAdmissions)
            FormatGridRow(Me.dgvUnclosedVisits)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub fbnReportOperations_Click(sender As System.Object, e As System.EventArgs) Handles fbnReportOperations.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date and Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date and Time")
            Dim itemCategoryID As String = RevertText(StringValueMayBeEnteredIn(Me.cboItemCategoryID))
            Dim payStatusID As String = RevertText(StringValueMayBeEnteredIn(Me.CboPayStatusID))
            Dim itemStatusID As String = RevertText(StringValueMayBeEnteredIn(Me.cboItemStatusID))

            If endDateTime < startDateTime Then Throw New ArgumentException("End Date and Time can't be before Start Date and Time!")



            Select Case Me.tbcItemOperations.SelectedTab.Name

                Case Me.tpgServices.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowItemStatusSummaries(startDateTime, endDateTime, itemCategoryID)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDoctorVisits.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowDoctorVisits(startDateTime, endDateTime, itemCategoryID)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgOPDItemsStatus.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowOperationalOPDItemsReport(payStatusID, itemStatusID, startDateTime, endDateTime)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgPatientRegistration.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowPatientRegistrationDetails(startDateTime, endDateTime)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgVisitRegistration.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowVisitRegistrationDetails(startDateTime, endDateTime)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgFileStatus.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowOutWardFilesSummary(startDateTime, endDateTime)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgFilesNotSeenByDoctor.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowNotSeenOutWardFiles(startDateTime, endDateTime)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgFilesSeenByDoctor.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowDoctorSeenOutWardFiles(startDateTime, endDateTime)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgOverStayedAdmissions.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowOverStayedAdmissions(startDateTime, endDateTime)
                    Me.tbcReportOperation_SelectedIndexChanged(tbcItemOperations, New EventArgs())

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbClose_Click(sender As System.Object, e As System.EventArgs) Handles fbClose.Click
        Me.Close()
    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcItemOperations.SelectedTab.Name

                Case Me.tpgServices.Name
                    ExportToExcel(Me.dgvItems, Me.tpgServices.Text)

                Case Me.tpgDoctorVisits.Name
                    ExportToExcel(Me.dgvDoctorVisits, Me.tpgDoctorVisits.Text)
                Case Me.tpgOPDItemsStatus.Name
                    ExportToExcel(Me.dgvOPDItemsStatus, Me.tpgOPDItemsStatus.Text)

                Case Me.tpgPatientRegistration.Name
                    ExportToExcel(Me.dgvPatientRegistration, Me.tpgPatientRegistration.Text)

                Case Me.tpgVisitRegistration.Name
                    ExportToExcel(Me.dgvVisitRegistration, Me.tpgVisitRegistration.Text)

                Case Me.tpgFileStatus.Name
                    ExportToExcel(Me.dgvFileStatus, Me.tpgFileStatus.Text)

                Case Me.tpgFilesNotSeenByDoctor.Name
                    ExportToExcel(Me.dgvFilesNotSeenByDoctor, Me.tpgFilesNotSeenByDoctor.Text)

                Case Me.tpgFilesSeenByDoctor.Name
                    ExportToExcel(Me.dgvFilesSeenByDoctor, Me.tpgFilesSeenByDoctor.Text)

                Case Me.tpgOverStayedAdmissions.Name
                    ExportToExcel(Me.dgvUnclosedVisits, Me.tpgOverStayedAdmissions.Text)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcReportOperation_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbcItemOperations.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcItemOperations.SelectedTab.Name

                Case Me.tpgServices.Name
                    Me.cboItemCategoryID.Visible = True
                    Me.lblItemCategory.Visible = True
                    Dim rowCount As Integer = Me.dgvItems.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpgDoctorVisits.Name
                    Me.cboItemCategoryID.Visible = True
                    Me.lblItemCategory.Visible = True
                    Dim rowCount As Integer = Me.dgvDoctorVisits.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpgOPDItemsStatus.Name
                    Me.cboItemCategoryID.Visible = False
                    Me.lblItemCategory.Visible = False
                    Dim rowCount As Integer = Me.dgvOPDItemsStatus.RowCount
                    Me.fbnExport.Enabled = rowCount > 0


                Case Me.tpgPatientRegistration.Name
                    Me.cboItemCategoryID.Visible = False
                    Me.lblItemCategory.Visible = False
                    Dim rowCount As Integer = Me.dgvPatientRegistration.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpgVisitRegistration.Name
                    Me.cboItemCategoryID.Visible = False
                    Me.lblItemCategory.Visible = False
                    Dim rowCount As Integer = Me.dgvVisitRegistration.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpgFileStatus.Name
                    Me.cboItemCategoryID.Visible = False
                    Me.lblItemCategory.Visible = False
                    Dim rowCount As Integer = Me.dgvFileStatus.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpgFilesNotSeenByDoctor.Name
                    Me.cboItemCategoryID.Visible = False
                    Me.lblItemCategory.Visible = False
                    Dim rowCount As Integer = Me.dgvFilesNotSeenByDoctor.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpgFilesSeenByDoctor.Name
                    Me.cboItemCategoryID.Visible = False
                    Me.lblItemCategory.Visible = False
                    Dim rowCount As Integer = Me.dgvFilesSeenByDoctor.RowCount
                    Me.fbnExport.Enabled = rowCount > 0


                Case Me.tpgOverStayedAdmissions.Name
                    Me.cboItemCategoryID.Visible = False
                    Me.lblItemCategory.Visible = False
                    Dim rowCount As Integer = Me.dgvUnclosedVisits.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Else
                    Me.fbnExport.Enabled = False

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class