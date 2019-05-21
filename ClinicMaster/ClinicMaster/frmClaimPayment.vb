
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Collections.Generic


Public Class frmClaimPayment

    Private Sub frmClaimPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Cursor = Cursors.WaitCursor()
            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.GetWaitingPeriodicClaims()
            Me.LoadHealthUnits()
            Me.LoadInsurances()
            Me.LoadCompanies()
            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Sub GetWaitingPeriodicClaims()

        Dim oClaims As New SyncSoft.SQLDb.Claims()
        Dim oVariousOptions As New VariousOptions()

        Dim ClaimPaymentsAlertDays As Integer = oVariousOptions.ClaimPaymentsAlertDays
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim WaitingPeriodicClaims As DataTable = oClaims.GetWaitingPeriodicClaims(ClaimPaymentsAlertDays).Tables("WaitingPeriodicClaims")

            Dim AlertsNo As Integer = WaitingPeriodicClaims.Rows.Count
            'DisplayMessage(iPDAlertsNo.ToString)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblWaitingToPayForClaims.Text = "Waiting To Pay For Claims: " + AlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadHealthUnits()

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            Dim healthUnits As DataTable = oHealthUnits.GetHealthUnits().Tables("HealthUnits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Me.cboHealthUnitCode.Sorted = False
            Me.cboHealthUnit.Sorted = False
            'LoadComboData(Me.cboHealthUnit, healthUnits, "HealthUnitCode", "HealthUnitName")
            LoadComboData(Me.cboHealthUnit, healthUnits, "HealthUnitFullName")
            Me.cboHealthUnit.Items.Insert(0, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInsurances()

        Dim oInsurances As New SyncSoft.SQLDb.Insurances

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboInsurance.Sorted = False
            LoadComboData(Me.cboInsurance, insurances, "InsuranceFullName")
            Me.cboInsurance.Items.Insert(0, String.Empty)
            'LoadComboData(Me.cboInsurance, insurances, "InsuranceNo", "InsuranceName")
            'Me.cboInsurance.Items.Insert(0, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCompanies()

        Dim oCompanies As New SyncSoft.SQLDb.Companies

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            Dim companies As DataTable = oCompanies.GetCompanies().Tables("Companies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           
            Me.cboCompany.Sorted = False
            LoadComboData(Me.cboCompany, companies, "CompanyFullName")
            Me.cboCompany.Items.Insert(0, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadClaims_Click(sender As Object, e As EventArgs) Handles btnLoadClaims.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")
            Dim insuranceNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboInsurance)).ToUpper()

            Dim healthUnitCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboHealthUnit)).ToUpper()
            Dim companyNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboCompany)).ToUpper()
            Dim medicalCardNo As String = StringMayBeEnteredIn(Me.cboMedicalCardNo)

            'DisplayMessage(companyNo)
            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPeriodicClaims(startDate, endDate, insuranceNo, healthUnitCode, companyNo, medicalCardNo)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPeriodicClaims(ByVal startDate As Date, ByVal endDate As Date, ByVal InsuranceNo As String, ByVal HealthUnitCode As String, ByVal CompanyNo As String, ByVal medicalCardNo As String)

        Dim oClaimPayments As New SyncSoft.SQLDb.ClaimPayments()

        Try
            Me.Cursor = Cursors.WaitCursor

            'Me.cboMedicalCardNo.Items.Clear()

            Dim claimPayments As DataTable = oClaimPayments.GetPeriodicClaimsPerInsurancePerHealthUnitPerCompanyPerMedicalCardNo(startDate, endDate, InsuranceNo, HealthUnitCode, CompanyNo, medicalCardNo).Tables("PeriodicClaimsPerInsurancePerHealthUnitPerCompanyPerMedicalCardNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvClaimPayment, claimPayments)

            If Not (String.IsNullOrEmpty(Me.cboCompany.Text)) Then
                Dim medicalCardNoData As DataTable = oClaimPayments.GetMedicalCardNoPerInsurancePerHealthUnitPerCompany(startDate, endDate, InsuranceNo, HealthUnitCode, CompanyNo).Tables("MedicalCardNoPerInsurancePerHealthUnitPerCompany")
                LoadComboData(Me.cboMedicalCardNo, medicalCardNoData, "MedicalCardNo")
                Me.cboMedicalCardNo.Items.Insert(0, String.Empty)
            Else
                Me.cboMedicalCardNo.DataSource = Nothing
            End If
            'If claimPayments.Rows.Count > 0 Then
            Me.lblRecordsNo.Text = " Returned Record(s): " + claimPayments.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'End If
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub cboCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCompany.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.cboMedicalCardNo.DataSource = Nothing
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub cboCompany_TextChanged(sender As Object, e As EventArgs) Handles cboCompany.TextChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.cboMedicalCardNo.DataSource = Nothing
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function ClaimPaymentList() As List(Of DBConnect)

        Dim lClaimPayments As New List(Of DBConnect)
        'Dim oClaimPayments As New SyncSoft.SQLDb.ClaimPayments()
        Dim oPayStatus As New LookupDataID.PayStatusID

        Try

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvClaimPayment.RowCount - 1
                If CBool(Me.dgvClaimPayment.Item(Me.colInclude.Name, rowNo).Value) = True Then
                    Dim cells As DataGridViewCellCollection = Me.dgvClaimPayment.Rows(rowNo).Cells
                    Dim claimNo As String = RevertText(StringEnteredIn(cells, Me.colClaimNo, "Visit No!"))
                    Dim PaymentDateTime As DateTime = DateTimeEnteredIn(cells, Me.colPaymentDate, "Return Date!")

                    Using oClaimPayments As New SyncSoft.SQLDb.ClaimPayments()
                        With oClaimPayments

                            .ClaimNo = claimNo
                            .PayStatusID = oPayStatus.PaidFor
                            .PaymentDateTime = PaymentDateTime
                            .LoginID = CurrentUser.LoginID

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(Me)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With
                        lClaimPayments.Add(oClaimPayments)

                    End Using
                End If
            Next

            Return lClaimPayments

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Private Sub ebnSaveUpdate_Click(sender As Object, e As EventArgs) Handles ebnSaveUpdate.Click
        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(Me.ClaimPaymentList, Action.Save))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            records = DoTransactions(transactions)
            DisplayMessage(records.ToString() + " record(s) Saved!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.grpClaimPeriod)
            Me.lblRecordsNo.Text = String.Empty
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub dgvClaimPayment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClaimPayment.CellClick

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim paymentDateTime As Date = DateTimeMayBeEnteredIn(Me.dgvClaimPayment.Rows(e.RowIndex).Cells, Me.colPaymentDate)

            Dim fSelectDateTime As New SyncSoft.SQL.Win.Forms.SelectDateTime(paymentDateTime, "Payment Date Time", AppData.MinimumDate, AppData.MaximumDate,
                                                                             Me.dgvClaimPayment, Me.colPaymentDate, e.RowIndex)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colPaymentDate.Index.Equals(e.ColumnIndex) AndAlso Not Me.dgvClaimPayment.Rows(e.RowIndex).IsNewRow Then

                Me.dgvClaimPayment.Rows.Add()
                fSelectDateTime.ShowDialog(Me)

                Dim enteredDate As Date = DateTimeMayBeEnteredIn(Me.dgvClaimPayment.Rows(e.RowIndex).Cells, Me.colPaymentDate)
                If enteredDate = AppData.NullDateValue Then Me.dgvClaimPayment.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.colPaymentDate.Index.Equals(e.ColumnIndex) Then

                fSelectDateTime.ShowDialog(Me)
            ElseIf Me.colInclude.Index.Equals(e.ColumnIndex) Then

                If CBool(Me.dgvClaimPayment.Item(Me.colInclude.Name, dgvClaimPayment.CurrentRow.Index).Value) = True Then
                    Me.dgvClaimPayment.Item(Me.colInclude.Name, dgvClaimPayment.CurrentRow.Index).Value = False
                ElseIf CBool(Me.dgvClaimPayment.Item(Me.colInclude.Name, dgvClaimPayment.CurrentRow.Index).Value) = False Then
                    Me.dgvClaimPayment.Item(Me.colInclude.Name, dgvClaimPayment.CurrentRow.Index).Value = True
                End If

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

   
    Private Sub cmsItems_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsItems.Opening
       
        If Me.dgvClaimPayment.ColumnCount < 1 OrElse Me.dgvClaimPayment.RowCount < 1 Then
            Me.cmsItemsCopy.Enabled = False
            Me.cmsItemsSelectAll.Enabled = False
            Me.cmsItemsIncludeAll.Enabled = False
            Me.cmsItemsIncludeNone.Enabled = False
        End If
    End Sub

    Private Sub cmsItemsCopy_Click(sender As Object, e As EventArgs) Handles cmsItemsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvClaimPayment.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvClaimPayment))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsItemsSelectAll_Click(sender As Object, e As EventArgs) Handles cmsItemsSelectAll.Click
        Me.dgvClaimPayment.SelectAll()
    End Sub

    Private Sub cmsItemsIncludeAll_Click(sender As Object, e As EventArgs) Handles cmsItemsIncludeAll.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In Me.dgvClaimPayment.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' Me.ColInclude.ThreeState = True
                Me.dgvClaimPayment.Item(Me.colInclude.Name, Row.Index).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '  Me.Close()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cmsItemsIncludeNone_Click(sender As Object, e As EventArgs) Handles cmsItemsIncludeNone.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each Row As DataGridViewRow In Me.dgvClaimPayment.Rows
                If Row.Index < 0 Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvClaimPayment.Item(Me.colInclude.Name, Row.Index).Value = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub dgvClaimPayment_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClaimPayment.CellDoubleClick

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim claimNo As String = StringEnteredIn(Me.dgvClaimPayment.Rows(e.RowIndex).Cells, Me.colClaimNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fClaimPaymentDetails As New FrmClaimPaymentDetails(claimNo)
            fClaimPaymentDetails.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            'Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")
            'Dim insuranceNo As String = StringValueEnteredIn(Me.cboInsurance)
            'Dim healthUnitCode As String = StringValueEnteredIn(Me.cboHealthUnit)
            'Dim companyNo As String = StringValueMayBeEnteredIn(Me.cboCompany)
            'Dim medicalCardNo As String = StringMayBeEnteredIn(Me.cboMedicalCardNo)

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")
            Dim insuranceNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboInsurance)).ToUpper()
            Dim healthUnitCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboHealthUnit)).ToUpper()
            Dim companyNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboCompany)).ToUpper()
            Dim medicalCardNo As String = StringMayBeEnteredIn(Me.cboMedicalCardNo)

            'DisplayMessage(companyNo)
            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPeriodicClaims(startDate, endDate, insuranceNo, healthUnitCode, companyNo, medicalCardNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub btnLoadList_Click(sender As Object, e As EventArgs) Handles btnLoadList.Click
        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            PeriodicClaims.values.Clear()
            Dim fPeriodicClaims As New frmPeriodicClaims(Nothing, False, True)
            fPeriodicClaims.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim PeriodicClaimsPair As KeyValuePair(Of Integer, String)
            For Each PeriodicClaimsPair In PeriodicClaims.values

                With Me.dgvClaimPayment
                    .Rows.Add()
                    .Item(Me.colClaimNo.Name, .NewRowIndex - 1).Value = PeriodicClaimsPair.Value
                    Me.claimDetails(.NewRowIndex - 1)
                End With
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub


    Private Sub claimDetails(ByVal selectedRow As Integer)

        Try

            Dim oClaimPayments As New SyncSoft.SQLDb.ClaimPayments()
            Dim claimNo As String = String.Empty

            If Me.dgvClaimPayment.Rows.Count > 1 Then claimNo = StringMayBeEnteredIn(Me.dgvClaimPayment.Rows(selectedRow).Cells, Me.colClaimNo)

            If String.IsNullOrEmpty(claimNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim periodicClaimDetails As DataTable = oClaimPayments.GetPeriodicClaimsPerClaimNo(claimNo).Tables("PeriodicClaimsPerClaimNo")
            Dim row As DataRow = periodicClaimDetails.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim MedicalCardNo As String = StringMayBeEnteredIn(row, "MedicalCardNo")
            Dim VisitDate As Date = DateMayBeEnteredIn(row, "VisitDate")
            Dim FullName As String = StringMayBeEnteredIn(row, "FullName")
            Dim Gender As String = StringMayBeEnteredIn(row, "Gender")
            Dim Age As Integer = IntegerMayBeEnteredIn(row, "Age")
            Dim CompanyName As String = StringMayBeEnteredIn(row, "CompanyName")
            Dim HealthUnitName As String = StringMayBeEnteredIn(row, "HealthUnitName")
            Dim TotalConsumedAmount As Decimal = DecimalMayBeEnteredIn(row, "TotalConsumedAmount", True)
            Dim MainMemberName As String = StringMayBeEnteredIn(row, "MainMemberName")
            Dim PrimaryDoctor As String = StringMayBeEnteredIn(row, "PrimaryDoctor")
            Dim RecordDate As Date = DateMayBeEnteredIn(row, "RecordDate")
            Dim RecordTime As String = StringMayBeEnteredIn(row, "RecordTime")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvClaimPayment
                .Item(Me.colMedicalCardNo.Name, selectedRow).Value = MedicalCardNo.ToUpper()
                .Item(Me.colVisitDate.Name, selectedRow).Value = VisitDate
                .Item(Me.colFullName.Name, selectedRow).Value = FullName
                .Item(Me.colGender.Name, selectedRow).Value = Gender
                .Item(Me.colAge.Name, selectedRow).Value = Age
                .Item(Me.colCompanyName.Name, selectedRow).Value = CompanyName
                .Item(Me.colHealthUnitName.Name, selectedRow).Value = HealthUnitName
                .Item(Me.colTotalConsumedAmount.Name, selectedRow).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalConsumedAmount"), AppData.DecimalPlaces)
                'TotalConsumedAmount()
                .Item(Me.colMainMemberName.Name, selectedRow).Value = MainMemberName
                .Item(Me.colPrimaryDoctor.Name, selectedRow).Value = PrimaryDoctor
                .Item(Me.colRecordDate.Name, selectedRow).Value = RecordDate
                .Item(Me.colRecordTime.Name, selectedRow).Value = RecordTime
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub frmClaimPayment_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Me.GetWaitingPeriodicClaims()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub
End Class