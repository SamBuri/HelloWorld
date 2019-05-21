Option Strict On

Imports SyncSoft.Common.Methods


Public Class frmDeathDiagnosis
#Region "Fields"
    Private _patientNo As String
#End Region

    Private Sub frmDeathDiagnosis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkShowAll.Checked = True
        Try
            Me.LoadGeneralDiagnosis(_patientNo)
            Me.LoadCancerDiagnosis(_patientNo)
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#Region " Popup Menu "

    Private Sub cmsDeathDiagnosis_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDeathDiagnosis.Opening

        Select Case Me.tbcDeathDiagnosis.SelectedTab.Name

            Case Me.tpgGeneralDiagnosis.Name

                If Me.dgvGeneralDiagnosis.ColumnCount < 1 OrElse Me.dgvGeneralDiagnosis.RowCount < 1 Then
                    Me.cmsCopy.Enabled = False
                    Me.cmsSelectAll.Enabled = False
                Else
                    Me.cmsCopy.Enabled = True
                    Me.cmsSelectAll.Enabled = True
                End If

            Case Me.tpgCancerDiagnosis.Name

                If Me.dgvCancerDiagnosis.ColumnCount < 1 OrElse Me.dgvCancerDiagnosis.RowCount < 1 Then
                    Me.cmsCopy.Enabled = False
                    Me.cmsSelectAll.Enabled = False
                Else
                    Me.cmsCopy.Enabled = True
                    Me.cmsSelectAll.Enabled = True
                End If

            Case Else
                Me.cmsCopy.Enabled = True
                Me.cmsSelectAll.Enabled = True

        End Select

    End Sub

    Private Sub cmsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDeathDiagnosis.SelectedTab.Name

                Case Me.tpgGeneralDiagnosis.Name

                    If Me.dgvGeneralDiagnosis.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvGeneralDiagnosis))

                Case Me.tpgCancerDiagnosis.Name

                    If Me.dgvCancerDiagnosis.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvCancerDiagnosis))

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDeathDiagnosis.SelectedTab.Name

                Case Me.tpgGeneralDiagnosis.Name
                    Me.dgvGeneralDiagnosis.SelectAll()

                Case Me.tpgCancerDiagnosis.Name
                    Me.dgvCancerDiagnosis.SelectAll()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region "General Diagnosis Grid"
    Private Sub LoadGeneralDiagnosis(ByVal PatientNo As String)

        Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()
        me.fbnExportTo.Enabled = False
        Try
            Me.dgvGeneralDiagnosis.Rows.Clear()

            ' Load diagnosis

            Dim diagnosis As DataTable = oDiagnosis.GetGeneralDeathDiagnosis(RevertText(PatientNo)).Tables("Diagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnExportTo.Enabled = True

            For pos As Integer = 0 To diagnosis.Rows.Count - 1

                Dim row As DataRow = diagnosis.Rows(pos)

                With Me.dgvGeneralDiagnosis

                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colFirstName.Name, pos).Value = StringEnteredIn(row, "FirstName")
                    .Item(Me.colLastName.Name, pos).Value = StringEnteredIn(row, "LastName")
                    .Item(Me.colMiddleName.Name, pos).Value = StringMayBeEnteredIn(row, "MiddleName")
                    .Item(Me.colVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                    .Item(Me.colvisitdate.Name, pos).Value = StringEnteredIn(row, "visitdate")
                    .Item(Me.colDiseaseCategoriesID.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategoriesID")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategory")
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCode")
                    .Item(Me.colDiseaseName.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseName")
                    .Item(Me.DoctorSpeciality.Name, pos).Value = StringMayBeEnteredIn(row, "DoctorSpeciality")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPeriodicGeneralDiagnosis(ByVal PatientNo As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime)

        Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()
        Me.fbnExportTo.Enabled = False
        Try

            Me.dgvGeneralDiagnosis.Rows.Clear()

            ' Load diagnosis

            Dim diagnosis As DataTable = oDiagnosis.GetGeneralDeathDiagnosis(RevertText(PatientNo), StartDate, EndDate).Tables("Diagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnExportTo.Enabled = True

            For pos As Integer = 0 To diagnosis.Rows.Count - 1

                Dim row As DataRow = diagnosis.Rows(pos)

                With Me.dgvGeneralDiagnosis

                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colFirstName.Name, pos).Value = StringEnteredIn(row, "FirstName")
                    .Item(Me.colLastName.Name, pos).Value = StringEnteredIn(row, "LastName")
                    .Item(Me.colMiddleName.Name, pos).Value = StringMayBeEnteredIn(row, "MiddleName")
                    .Item(Me.colVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                    .Item(Me.colvisitdate.Name, pos).Value = StringEnteredIn(row, "visitdate")
                    .Item(Me.colDiseaseCategoriesID.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategoriesID")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategory")
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCode")
                    .Item(Me.colDiseaseName.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseName")
                    .Item(Me.DoctorSpeciality.Name, pos).Value = StringMayBeEnteredIn(row, "DoctorSpeciality")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub
#End Region

#Region "Cancer Diagnosis Grid"
    Private Sub LoadCancerDiagnosis(ByVal PatientNo As String)

        Dim oCancerDiagnosis As New SyncSoft.SQLDb.CancerDiagnosis()
        Me.fbnExportTo.Enabled = False
        Try
            Me.dgvCancerDiagnosis.Rows.Clear()

            ' Load diagnosis

            Dim Cancerdiagnosis As DataTable = oCancerDiagnosis.GetDeathCancerDiagnosis(RevertText(PatientNo)).Tables("CancerDiagnosis")
            If Cancerdiagnosis Is Nothing OrElse Cancerdiagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnExportTo.Enabled = True

            For pos As Integer = 0 To Cancerdiagnosis.Rows.Count - 1

                Dim row As DataRow = Cancerdiagnosis.Rows(pos)

                With Me.dgvCancerDiagnosis

                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colCancerFirstName.Name, pos).Value = StringEnteredIn(row, "FirstName")
                    .Item(Me.colCancerLastName.Name, pos).Value = StringEnteredIn(row, "LastName")
                    .Item(Me.colCancerMiddleName.Name, pos).Value = StringMayBeEnteredIn(row, "MiddleName")
                    .Item(Me.colCancerVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                    .Item(Me.colCancervisitdate.Name, pos).Value = StringEnteredIn(row, "VisitDate")
                    .Item(Me.colCancerDiseaseCategoriesID.Name, pos).Value = StringMayBeEnteredIn(row, "CancerDiseaseCategoriesID")
                    .Item(Me.colCancerDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategory")
                    .Item(Me.colCancerDiseaseCode.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCode")
                    .Item(Me.colCancerDiseaseName.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseName")
                    .Item(Me.colCancerDoctorSpecialty.Name, pos).Value = StringMayBeEnteredIn(row, "DoctorSpeciality")
                    .Item(Me.colCancerNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPeriodicCancerDiagnosis(ByVal PatientNo As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime)

        Dim oCancerDiagnosis As New SyncSoft.SQLDb.CancerDiagnosis()
        Me.fbnExportTo.Enabled = False
        Try

            Me.dgvCancerDiagnosis.Rows.Clear()

            ' Load diagnosis

            Dim CancerDiagnosis As DataTable = oCancerDiagnosis.GetDeathCancerDiagnosis(RevertText(PatientNo), StartDate, EndDate).Tables("CancerDiagnosis")
            If CancerDiagnosis Is Nothing OrElse CancerDiagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnExportTo.Enabled = True

            For pos As Integer = 0 To CancerDiagnosis.Rows.Count - 1

                Dim row As DataRow = CancerDiagnosis.Rows(pos)

                With Me.dgvCancerDiagnosis

                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colCancerFirstName.Name, pos).Value = StringEnteredIn(row, "FirstName")
                    .Item(Me.colCancerLastName.Name, pos).Value = StringEnteredIn(row, "LastName")
                    .Item(Me.colCancerMiddleName.Name, pos).Value = StringMayBeEnteredIn(row, "MiddleName")
                    .Item(Me.colCancerVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                    .Item(Me.colCancervisitdate.Name, pos).Value = StringEnteredIn(row, "visitdate")
                    .Item(Me.colCancerDiseaseCategoriesID.Name, pos).Value = StringMayBeEnteredIn(row, "CancerDiseaseCategoriesID")
                    .Item(Me.colCancerDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategory")
                    .Item(Me.colCancerDiseaseCode.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCode")
                    .Item(Me.colCancerDiseaseName.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseName")
                    .Item(Me.colCancerDoctorSpecialty.Name, pos).Value = StringMayBeEnteredIn(row, "DoctorSpeciality")
                    .Item(Me.colCancerNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub
#End Region

#Region "grpPeriod"
    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try
            Me.Cursor = Cursors.WaitCursor()

            If chkShowAll.Checked Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Select Case Me.tbcDeathDiagnosis.SelectedTab.Name

                    Case Me.tpgGeneralDiagnosis.Name

                        Dim _objectCaption As String = Me.tpgGeneralDiagnosis.Text
                        Dim documentTitle As String = "All Patient's " + _objectCaption + "!"

                        fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                        ExportToExcel(Me.dgvGeneralDiagnosis, _objectCaption, documentTitle)

                    Case Me.tpgCancerDiagnosis.Name

                        Dim _objectCaption As String = Me.tpgCancerDiagnosis.Text
                        Dim documentTitle As String = "All Patient's " + _objectCaption + "!"

                        fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                        ExportToExcel(Me.dgvCancerDiagnosis, _objectCaption, documentTitle)

                End Select
            Else

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.grpPeriod)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
                Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Select Case Me.tbcDeathDiagnosis.SelectedTab.Name

                    Case Me.tpgGeneralDiagnosis.Name

                        Dim _objectCaption As String = Me.tpgGeneralDiagnosis.Text
                        Dim documentTitle As String = _objectCaption + " for the period between " +
                            FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

                        fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                        ExportToExcel(Me.dgvGeneralDiagnosis, _objectCaption, documentTitle)

                    Case Me.tpgCancerDiagnosis.Name

                        Dim _objectCaption As String = Me.tpgCancerDiagnosis.Text
                        Dim documentTitle As String = _objectCaption + " for the period between " +
                            FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

                        fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                        ExportToExcel(Me.dgvCancerDiagnosis, _objectCaption, documentTitle)

                End Select

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnLoad_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor()

            If chkShowAll.Checked Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Select Case Me.tbcDeathDiagnosis.SelectedTab.Name

                    Case Me.tpgGeneralDiagnosis.Name
                        Me.LoadGeneralDiagnosis(_patientNo)

                    Case Me.tpgCancerDiagnosis.Name
                        Me.LoadCancerDiagnosis(_patientNo)
                End Select
            Else

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.grpPeriod)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
                Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Select Case Me.tbcDeathDiagnosis.SelectedTab.Name

                    Case Me.tpgGeneralDiagnosis.Name

                        Dim _objectCaption As String = Me.tpgGeneralDiagnosis.Text
                        Dim documentTitle As String = _objectCaption + " for the period between " +
                            FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

                        Me.LoadPeriodicGeneralDiagnosis(_patientNo, startDate, endDate)

                    Case Me.tpgCancerDiagnosis.Name

                        Dim _objectCaption As String = Me.tpgCancerDiagnosis.Text
                        Dim documentTitle As String = _objectCaption + " for the period between " +
                            FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

                        Me.LoadPeriodicCancerDiagnosis(_patientNo, startDate, endDate)

                End Select

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub chkShowAll_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowAll.CheckStateChanged
        If chkShowAll.Checked Then
            dtpStartDate.Enabled = False
            dtpEndDate.Enabled = False
        Else
            dtpStartDate.Enabled = True
            dtpEndDate.Enabled = True
        End If
    End Sub
#End Region

End Class