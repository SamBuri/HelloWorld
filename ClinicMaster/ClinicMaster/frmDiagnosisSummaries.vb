
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmDiagnosisSummaries

#Region " Fields "
#End Region

    Private Sub frmDiagnosisSummaries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor
            LoadLookupDataCombo(Me.cboSearchAgeByID, LookupObjects.SearchAgeBy, True)
            Me.dtpStartDate.MaxDate = Today()
            Me.dtpEndDate.MaxDate = Today()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub frmDiagnosisSummaries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oReports As New SyncSoft.SQLDb.Reports()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsNo.Text = String.Empty
            Me.fbnExportTo.Enabled = False
            ValidateEntriesIn(Me.grpPeriod)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim searchAgeBy As String = StringValueEnteredIn(cboSearchAgeByID, "Search Age By!")
            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")
            Dim startAge As Short = ShortEnteredIn(Me.nbxStartAge, "Start Age")
            Dim endAge As Short = ShortMayBeEnteredIn(Me.nbxEndAge, -1)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endAge < 0 Then endAge = CShort(GetAge(AppData.NullDateValue))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            If endAge < startAge Then Throw New ArgumentException("End Age can't be less than Start Age!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcDiagnosisSummaries.SelectedTab.Name

                Case Me.tpgDiagnosisSummaries.Name

                    Dim reports As DataTable = oReports.GetDiagnosisSummaries(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDiagnosisSummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvDiagnosisSummaries

                            .Rows.Add()

                            .Item(Me.colDiseaseName.Name, rowNo).Value = StringMayBeEnteredIn(row, "DiseaseName")
                            .Item(Me.colMale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Male")
                            .Item(Me.colFemale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Female")
                            .Item(Me.colTotal.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Total")

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvDiagnosisSummaries, Nothing, 3)
                    Me.fbnExportTo.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgIPDDiagnosisSummaries.Name

                    Dim reports As DataTable = oReports.GetIPDDiagnosisSummaries(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIPDDiagnosisSummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvIPDDiagnosisSummaries

                            .Rows.Add()

                            .Item(Me.colIPDDiseaseName.Name, rowNo).Value = StringMayBeEnteredIn(row, "DiseaseName")
                            .Item(Me.ColIPDMale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Male")
                            .Item(Me.ColIPDFemale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Female")
                            .Item(Me.ColIPDTotal.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Total")

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvIPDDiagnosisSummaries, Nothing, 3)
                    Me.fbnExportTo.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDiseaseCategorySummaries.Name

                    Dim reports As DataTable = oReports.GetDiseaseCategorySummaries(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDiseaseCategorySummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvDiseaseCategorySummaries

                            .Rows.Add()

                            .Item(Me.colDiseaseCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "DiseaseCategory")
                            .Item(Me.colDCMale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Male")
                            .Item(Me.colDCFemale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Female")
                            .Item(Me.colDCTotal.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Total")

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvDiseaseCategorySummaries, Nothing, 3)
                    Me.fbnExportTo.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Case Me.tpgIPDDiseaseCategorySummaries.Name

                    Dim reports As DataTable = oReports.GetIPDDiseaseCategorySummaries(searchAgeBy, startDate, endDate, startAge, endAge).Tables("Reports")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIPDDiseaseCategorySummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvIPDDiseaseCategorySummaries

                            .Rows.Add()

                            .Item(Me.ColIPDDiseaseCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "DiseaseCategory")
                            .Item(Me.ColIPDDiseaseMale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Male")
                            .Item(Me.ColIPDDiseaseFemale.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Female")
                            .Item(Me.ColIPDDiseaseTotal.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Total")

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvIPDDiseaseCategorySummaries, Nothing, 3)
                    Me.fbnExportTo.Enabled = reports.Rows.Count > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + reports.Rows.Count.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            Me.lblRecordsNo.Text = String.Empty
            Me.fbnExportTo.Enabled = False
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcDiagnosisSummaries_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbcDiagnosisSummaries.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDiagnosisSummaries.SelectedTab.Name

                Case Me.tpgDiagnosisSummaries.Name

                    Dim rowCount As Integer = Me.dgvDiagnosisSummaries.RowCount
                    Me.fbnExportTo.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + rowCount.ToString()

                Case Me.tpgDiseaseCategorySummaries.Name

                    Dim rowCount As Integer = Me.dgvDiseaseCategorySummaries.RowCount
                    Me.fbnExportTo.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + rowCount.ToString()

                Case Me.tpgIPDDiagnosisSummaries.Name

                    Dim rowCount As Integer = Me.dgvIPDDiagnosisSummaries.RowCount
                    Me.fbnExportTo.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + rowCount.ToString()

                Case Me.tpgDiseaseCategorySummaries.Name

                    Dim rowCount As Integer = Me.dgvIPDDiseaseCategorySummaries.RowCount
                    Me.fbnExportTo.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Record(s): " + rowCount.ToString()

                Case Else
                    Me.lblRecordsNo.Text = String.Empty
                    Me.fbnExportTo.Enabled = False

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.grpPeriod)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")
            Dim startAge As Short = ShortEnteredIn(Me.nbxStartAge, "Start Age")
            Dim endAge As Short = ShortMayBeEnteredIn(Me.nbxEndAge, -1)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endAge < 0 Then endAge = CShort(GetAge(AppData.NullDateValue))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            If endAge < startAge Then Throw New ArgumentException("End Age can't be less than Start Age!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcDiagnosisSummaries.SelectedTab.Name

                Case Me.tpgDiagnosisSummaries.Name

                    Dim _objectCaption As String = Me.tpgDiagnosisSummaries.Text
                    Dim documentTitle As String = _objectCaption + " for the period between " +
                        FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + ", age between " +
                        startAge.ToString() + " and " + endAge.ToString() + "!"

                    fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                    ExportToExcel(Me.dgvDiagnosisSummaries, _objectCaption, documentTitle)

                Case Me.tpgDiseaseCategorySummaries.Name

                    Dim _objectCaption As String = Me.tpgDiseaseCategorySummaries.Text
                    Dim documentTitle As String = _objectCaption + " for the period between " +
                        FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + ", age between " +
                        startAge.ToString() + " and " + endAge.ToString() + "!"

                    fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                    ExportToExcel(Me.dgvDiseaseCategorySummaries, _objectCaption, documentTitle)

                Case Me.tpgIPDDiseaseCategorySummaries.Name

                    Dim _objectCaption As String = Me.tpgIPDDiseaseCategorySummaries.Text
                    Dim documentTitle As String = _objectCaption + " for the period between " +
                        FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + ", age between " +
                        startAge.ToString() + " and " + endAge.ToString() + "!"

                    fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                    ExportToExcel(Me.dgvDiseaseCategorySummaries, _objectCaption, documentTitle)

                Case Me.tpgIPDDiagnosisSummaries.Name

                    Dim _objectCaption As String = Me.tpgIPDDiagnosisSummaries.Text
                    Dim documentTitle As String = _objectCaption + " for the period between " +
                        FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + ", age between " +
                        startAge.ToString() + " and " + endAge.ToString() + "!"

                    fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

                    ExportToExcel(Me.dgvDiseaseCategorySummaries, _objectCaption, documentTitle)
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Popup Menu "

    Private Sub cmsDiagnosisSummaries_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDiagnosisSummaries.Opening

        Select Case Me.tbcDiagnosisSummaries.SelectedTab.Name

            Case Me.tpgDiagnosisSummaries.Name

                If Me.dgvDiagnosisSummaries.ColumnCount < 1 OrElse Me.dgvDiagnosisSummaries.RowCount < 1 Then
                    Me.cmsCopy.Enabled = False
                    Me.cmsSelectAll.Enabled = False
                Else
                    Me.cmsCopy.Enabled = True
                    Me.cmsSelectAll.Enabled = True
                End If

            Case Me.tpgDiseaseCategorySummaries.Name

                If Me.dgvDiseaseCategorySummaries.ColumnCount < 1 OrElse Me.dgvDiseaseCategorySummaries.RowCount < 1 Then
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

            Select Case Me.tbcDiagnosisSummaries.SelectedTab.Name

                Case Me.tpgDiagnosisSummaries.Name

                    If Me.dgvDiagnosisSummaries.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvDiagnosisSummaries))

                Case Me.tpgDiseaseCategorySummaries.Name

                    If Me.dgvDiseaseCategorySummaries.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvDiseaseCategorySummaries))

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

            Select Case Me.tbcDiagnosisSummaries.SelectedTab.Name

                Case Me.tpgDiagnosisSummaries.Name
                    Me.dgvDiagnosisSummaries.SelectAll()

                Case Me.tpgDiseaseCategorySummaries.Name
                    Me.dgvDiseaseCategorySummaries.SelectAll()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

  
End Class