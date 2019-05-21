Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.SQLDb.Lookup
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



Public Class frmIPDIncomeSummaries

#Region " Fields "
    Private Const splitCHAR As Char = ","c
    Private items As DataTable
    Private extraBillItems As DataTable
    Private billCustomers As DataTable
    Private insuranceCompanies As DataTable
    Private billCompanies As DataTable
#End Region

    Private Sub frmIPDIncomeSummaries_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.dtpStartDate.MaxDate = Today()
        Me.dtpEndDate.MaxDate = Today()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboExtraBillModesID, LookupObjects.BillModes, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oReports As New SyncSoft.SQLDb.Reports()
            Dim oAccountActionID As New LookupDataID.AccountActionID()
            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim reports As DataTable
            Dim styleTotal As New DataGridViewCellStyle()
            Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgIncomeServicePoint.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    reports = oReports.GetIPDIncomeSummaries(startDate, endDate).Tables("Reports")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIncomeServicePoint.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvIncomeServicePoint

                            .Rows.Add()

                            .Item(Me.colIncomeCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "IncomeCategory")
                            .Item(Me.colTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colCashAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAmount"))
                            .Item(Me.colCoPayAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayAmount"))
                            .Item(Me.colTotalCash.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalCash"))
                            .Item(Me.colCashPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashPaid"))
                            .Item(Me.colCashDiscount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashDiscount"))
                            .Item(Me.colCashNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashNotPaid"))
                            .Item(Me.colCoPayNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayNotPaid"))
                            .Item(Me.colAccountAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountAmount"))
                            .Item(Me.colAccountNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountNotPaid"))
                            .Item(Me.colInsuranceAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceAmount"))
                            .Item(Me.colInsuranceNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceNotPaid"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvIncomeServicePoint, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgExtraCharges.Name
                    'go47



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    reports = oReports.GetIPDExtraChargeSummaries(startDate, endDate).Tables("Reports")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvExtraChargeSummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvExtraChargeSummaries

                            .Rows.Add()

                            .Item(Me.colExtraChargeCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ExtraChargeCategory")
                            .Item(Me.colExtraTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colExtraCashAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAmount"))
                            .Item(Me.colExtraCoPayAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayAmount"))
                            .Item(Me.colExtraTotalCash.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalCash"))
                            .Item(Me.colExtraCashPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashPaid"))
                            .Item(Me.colExtraCashDiscount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashDiscount"))
                            .Item(Me.colExtraCashNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashNotPaid"))
                            .Item(Me.colExtraCoPayNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayNotPaid"))
                            .Item(Me.colExtraAccountAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountAmount"))
                            .Item(Me.colExtraAccountNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountNotPaid"))
                            .Item(Me.colExtraInsuranceAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceAmount"))
                            .Item(Me.colExtraInsuranceNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceNotPaid"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvExtraChargeSummaries, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDoctorVisits.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    reports = oReports.GetIPDDoctorVisitSummaries(startDate, endDate).Tables("Reports")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDoctorVisitSummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvDoctorVisitSummaries

                            .Rows.Add()

                            .Item(Me.colDoctorSeenDoctor.Name, rowNo).Value = StringMayBeEnteredIn(row, "SeenDoctor")
                            .Item(Me.colDoctorTotalVisits.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "TotalVisits")
                            .Item(Me.colDoctorTotalOnServices.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalOnServices"))
                            .Item(Me.colDoctorTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colDoctorCashAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAmount"))
                            .Item(Me.colDoctorCoPayAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayAmount"))
                            .Item(Me.colDoctorTotalCash.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalCash"))
                            .Item(Me.colDoctorCashPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashPaid"))
                            .Item(Me.colDoctorCashDiscount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashDiscount"))
                            .Item(Me.colDoctorCashNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashNotPaid"))
                            .Item(Me.colDoctorAccountAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountAmount"))
                            .Item(Me.colDoctorAccountNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountNotPaid"))
                            .Item(Me.colDoctorInsuranceAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceAmount"))
                            .Item(Me.colDoctorInsuranceNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceNotPaid"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvDoctorVisitSummaries, Nothing, 3)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDoctorSpecialtyVisits.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    reports = oReports.GetIPDDoctorSpecialtyVisitSummaries(startDate, endDate).Tables("Reports")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDoctorSpecialtyVisitSummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvDoctorSpecialtyVisitSummaries

                            .Rows.Add()

                            .Item(Me.colDoctorSpecialtySeenDoctorSpecialty.Name, rowNo).Value = StringMayBeEnteredIn(row, "SeenDoctorSpecialty")
                            .Item(Me.colDoctorSpecialtyTotalVisits.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "TotalVisits")
                            .Item(Me.colDoctorSpecialtyTotalOnServices.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalOnServices"))
                            .Item(Me.colDoctorSpecialtyTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colDoctorSpecialtyCashAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAmount"))
                            .Item(Me.colDoctorSpecialtyCoPayAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayAmount"))
                            .Item(Me.colDoctorSpecialtyTotalCash.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalCash"))
                            .Item(Me.colDoctorSpecialtyCashPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashPaid"))
                            .Item(Me.colDoctorSpecialtyCashDiscount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashDiscount"))
                            .Item(Me.colDoctorSpecialtyCashNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashNotPaid"))
                            .Item(Me.colDoctorSpecialtyAccountAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountAmount"))
                            .Item(Me.colDoctorSpecialtyAccountNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "AccountNotPaid"))
                            .Item(Me.colDoctorSpecialtyInsuranceAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceAmount"))
                            .Item(Me.colDoctorSpecialtyInsuranceNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InsuranceNotPaid"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvDoctorSpecialtyVisitSummaries, Nothing, 3)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgIncomePaymentDetails.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    reports = oReports.GetIPDIncomePaymentDetailsSummaries(startDate, endDate).Tables("Reports")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIncomePaymentDetails.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvIncomePaymentDetails

                            .Rows.Add()

                            .Item(Me.colPaymentDetailsReceiptNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "ReceiptNo")
                            .Item(Me.colPaymentDetailsVisitDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "VisitDate"), True)
                            .Item(Me.colPaymentDetailsFullName.Name, rowNo).Value = StringMayBeEnteredIn(row, "FullName")
                            .Item(Me.colIncomePaymentDetailsCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "IncomeCategory")
                            .Item(Me.colPaymentDetailsTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colPaymentDetailsPaidAfterDays.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "PaidAfterDays")
                            .Item(Me.colPaymentDetailsRecordDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "RecordDate"), True)
                            .Item(Me.colPaymentDetailsRecordTime.Name, rowNo).Value = StringMayBeEnteredIn(row, "RecordTime")

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvIncomePaymentDetails, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgBillsIncomeServicePoint.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "Account Category!")
                    Dim billNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboBillAccountNo, "To-Bill Number!")))
                    Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then Throw New ArgumentException("Invalid Account Category (CASH)!")
                    If billNo.ToUpper().Equals(cashAccount.ToUpper()) Then Throw New ArgumentException("Invalid entry (CASH) for an account!")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    reports = oReports.GetIPDIncomeSummariesByBills(startDate, endDate, billModesID, billNo, companyNo).Tables("Reports")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvBillsIncomeServicePoint.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvBillsIncomeServicePoint

                            .Rows.Add()

                            .Item(Me.colBillIncomeCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "IncomeCategory")
                            .Item(Me.colBillTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colBillCoPayAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayAmount"))
                            .Item(Me.colBillDiscount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillDiscount"))
                            .Item(Me.colBillPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillPaid"))
                            .Item(Me.colBillAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillAmount"))
                            .Item(Me.colBillNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillNotPaid"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvBillsIncomeServicePoint, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgBillsExtraCharges.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim billModesID As String = StringValueEnteredIn(Me.cboExtraBillModesID, "Account Category!")
                    Dim billNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboExtraAccountNo, "To-Bill Number!")))
                    Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboExtraCompanyNo)))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then Throw New ArgumentException("Invalid Account Category (CASH)!")
                    If billNo.ToUpper().Equals(cashAccount.ToUpper()) Then Throw New ArgumentException("Invalid entry (CASH) for an account!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    reports = oReports.GetIPDExtraChargeSummariesByBills(startDate, endDate, billModesID, billNo, companyNo).Tables("Reports")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvBillsExtraChargeSummaries.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvBillsExtraChargeSummaries

                            .Rows.Add()

                            .Item(Me.colExtraBillChargeCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ExtraChargeCategory")
                            .Item(Me.colExtraBillTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colExtraBillCoPayAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayAmount"))
                            .Item(Me.colExtraBillDiscount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillDiscount"))
                            .Item(Me.colExtraBillPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillPaid"))
                            .Item(Me.colExtraBillAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillAmount"))
                            .Item(Me.colExtraBillNotPaid.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillNotPaid"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvBillsExtraChargeSummaries, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim _objectCaption As String = Me.tbcPeriodicReport.SelectedTab.Text

            Dim documentTitle As String = _objectCaption + " for the period between " +
                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgIncomeServicePoint.Name
                    ExportToExcel(Me.dgvIncomeServicePoint, _objectCaption, documentTitle)

                Case Me.tpgExtraCharges.Name
                    ExportToExcel(Me.dgvExtraChargeSummaries, _objectCaption, documentTitle)

                Case Me.tpgDoctorVisits.Name
                    ExportToExcel(Me.dgvDoctorVisitSummaries, _objectCaption, documentTitle)

                Case Me.tpgDoctorSpecialtyVisits.Name
                    ExportToExcel(Me.dgvDoctorSpecialtyVisitSummaries, _objectCaption, documentTitle)

                Case Me.tpgBillsIncomeServicePoint.Name
                    ExportToExcel(Me.dgvBillsIncomeServicePoint, _objectCaption, documentTitle)

                Case Me.tpgBillsExtraCharges.Name
                    ExportToExcel(Me.dgvBillsExtraChargeSummaries, _objectCaption, documentTitle)

                Case Me.tpgIncomePaymentDetails.Name
                    ExportToExcel(Me.dgvIncomePaymentDetails, _objectCaption, documentTitle)

            End Select

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Grid Bills Income per Service Point "

    Private Sub cboBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "To-Bill Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadBillClients(billModesID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillAccountNoControl()
        Me.cboBillAccountNo.DataSource = Nothing
        Me.cboBillAccountNo.Items.Clear()
        Me.cboBillAccountNo.Text = String.Empty
    End Sub

    Private Sub SetBillInsuranceCompanyCTRLS(ByVal state As Boolean)

        Me.cboCompanyNo.SelectedIndex = -1
        Me.cboCompanyNo.SelectedIndex = -1
        Me.stbCompanyName.Clear()
        Me.cboCompanyNo.Items.Clear()
        Me.cboCompanyNo.Text = String.Empty

        Me.lblCompanyNo.Enabled = state
        Me.lblCompanyName.Enabled = state
        Me.cboCompanyNo.Enabled = state
        Me.stbCompanyName.Enabled = state

    End Sub

    Private Sub LoadBillClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oCompanies As New SyncSoft.SQLDb.Companies()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillAccountNoControl()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBillAccountNo.Text = "To-Bill Patient No"
                    Me.lblBillCustomerName.Text = "To-Bill Patient Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetBillInsuranceCompanyCTRLS(False)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBillAccountNo, billCustomers, "BillCustomerFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBillAccountNo.Text = "To-Bill Account Number"
                    Me.lblBillCustomerName.Text = "To-Bill Customer Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetBillInsuranceCompanyCTRLS(False)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Insurances

                    Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")
                    LoadComboData(Me.cboBillAccountNo, insurances, "InsuranceFullName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBillAccountNo.Text = "To-Bill Insurance No"
                    Me.lblBillCustomerName.Text = "To-Bill Insurance Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetBillInsuranceCompanyCTRLS(True)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    insuranceCompanies = oCompanies.GetCompanies().Tables("Companies")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboCompanyNo, insuranceCompanies, "companyFullName")
                    Me.cboCompanyNo.Items.Insert(0, String.Empty)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBillAccountNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboBillAccountNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBillAccountNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")

            If String.IsNullOrEmpty(billNo) OrElse String.IsNullOrEmpty(billModesID) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadBillDetails(billModesID, billNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillDetails(ByVal billModesID As String, ByVal billNo As String)

        Dim billCustomerName As String = String.Empty

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oBillCustomerTypeID As New LookupDataID.BillCustomerTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Clear()
            If String.IsNullOrEmpty(billNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(billNo).Tables("Patients").Rows(0)

                    Me.cboBillAccountNo.Text = FormatText(billNo, "Patients", "PatientNo")
                    billCustomerName = StringMayBeEnteredIn(row, "FullName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(billNo).Tables("BillCustomers").Rows(0)

                    Me.cboBillAccountNo.Text = FormatText(billNo, "BillCustomers", "AccountNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
                    Dim billCustomerTypeID As String = StringMayBeEnteredIn(row, "BillCustomerTypeID")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If billCustomerTypeID.ToUpper().Equals(oBillCustomerTypeID.Insurance.ToUpper()) Then

                        Me.SetBillInsuranceCompanyCTRLS(True)

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        billCompanies = oBillCustomers.GetBillCustomersByInsuranceNo(billNo).Tables("BillCustomers")

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadComboData(Me.cboCompanyNo, billCompanies, "BillCustomerFullName")
                        Me.cboCompanyNo.Items.Insert(0, String.Empty)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Else : Me.SetBillInsuranceCompanyCTRLS(False)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(billNo).Tables("Insurances").Rows(0)

                    Me.cboBillAccountNo.Text = FormatText(billNo, "Insurances", "InsuranceNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "InsuranceName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Text = billCustomerName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboCompanyNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompanyNo.SelectedIndexChanged
        Me.stbCompanyName.Clear()
    End Sub

    Private Sub cboCompanyNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompanyNo.Leave

        Dim companyName As String
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "To-Bill Account Category!")

            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()

                        For Each row As DataRow In billCompanies.Select("AccountNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("BillCustomerName")) Then
                                companyName = StringEnteredIn(row, "BillCustomerName")
                                companyNo = StringMayBeEnteredIn(row, "AccountNo")
                                Me.cboCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbCompanyName.Text = companyName
                        Next

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()

                        For Each row As DataRow In insuranceCompanies.Select("CompanyNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("CompanyName")) Then
                                companyName = StringEnteredIn(row, "CompanyName")
                                companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                                Me.cboCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbCompanyName.Text = companyName
                        Next

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region

#Region " Grid Bills Extra Charges "

    Private Sub cboExtraBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExtraBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbExtraCustomerName.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboExtraBillModesID, "To-Bill Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadExtraClients(billModesID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearExtraAccountNoControl()
        Me.cboExtraAccountNo.DataSource = Nothing
        Me.cboExtraAccountNo.Items.Clear()
        Me.cboExtraAccountNo.Text = String.Empty
    End Sub

    Private Sub SetExtraInsuranceCompanyCTRLS(ByVal state As Boolean)

        Me.cboExtraCompanyNo.SelectedIndex = -1
        Me.cboExtraCompanyNo.SelectedIndex = -1
        Me.stbExtraCompanyName.Clear()
        Me.cboExtraCompanyNo.Items.Clear()
        Me.cboExtraCompanyNo.Text = String.Empty

        Me.lblExtraCompanyNo.Enabled = state
        Me.lblExtraCompanyName.Enabled = state
        Me.cboExtraCompanyNo.Enabled = state
        Me.stbExtraCompanyName.Enabled = state

    End Sub

    Private Sub LoadExtraClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oCompanies As New SyncSoft.SQLDb.Companies()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearExtraAccountNoControl()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblExtraAccountNo.Text = "To-Bill Patient No"
                    Me.lblExtraCustomerName.Text = "To-Bill Patient Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetExtraInsuranceCompanyCTRLS(False)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboExtraAccountNo, billCustomers, "BillCustomerFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblExtraAccountNo.Text = "To-Bill Account Number"
                    Me.lblExtraCustomerName.Text = "To-Bill Customer Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetExtraInsuranceCompanyCTRLS(False)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Insurances

                    Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")
                    LoadComboData(Me.cboExtraAccountNo, insurances, "InsuranceFullName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblExtraAccountNo.Text = "To-Bill Insurance No"
                    Me.lblExtraCustomerName.Text = "To-Bill Insurance Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetExtraInsuranceCompanyCTRLS(True)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    insuranceCompanies = oCompanies.GetCompanies().Tables("Companies")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboExtraCompanyNo, insuranceCompanies, "companyFullName")
                    Me.cboExtraCompanyNo.Items.Insert(0, String.Empty)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboExtraAccountNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboExtraAccountNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbExtraCustomerName.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboExtraAccountNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboExtraBillModesID, "Account Category!")

            If String.IsNullOrEmpty(billNo) OrElse String.IsNullOrEmpty(billModesID) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadExtraDetails(billModesID, billNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExtraDetails(ByVal billModesID As String, ByVal billNo As String)

        Dim billCustomerName As String = String.Empty

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oBillCustomerTypeID As New LookupDataID.BillCustomerTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbExtraCustomerName.Clear()
            If String.IsNullOrEmpty(billNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(billNo).Tables("Patients").Rows(0)

                    Me.cboExtraAccountNo.Text = FormatText(billNo, "Patients", "PatientNo")
                    billCustomerName = StringMayBeEnteredIn(row, "FullName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(billNo).Tables("BillCustomers").Rows(0)

                    Me.cboExtraAccountNo.Text = FormatText(billNo, "BillCustomers", "AccountNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
                    Dim billCustomerTypeID As String = StringMayBeEnteredIn(row, "BillCustomerTypeID")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If billCustomerTypeID.ToUpper().Equals(oBillCustomerTypeID.Insurance.ToUpper()) Then

                        Me.SetExtraInsuranceCompanyCTRLS(True)

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        billCompanies = oBillCustomers.GetBillCustomersByInsuranceNo(billNo).Tables("BillCustomers")

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadComboData(Me.cboExtraCompanyNo, billCompanies, "BillCustomerFullName")
                        Me.cboExtraCompanyNo.Items.Insert(0, String.Empty)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Else : Me.SetExtraInsuranceCompanyCTRLS(False)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(billNo).Tables("Insurances").Rows(0)

                    Me.cboExtraAccountNo.Text = FormatText(billNo, "Insurances", "InsuranceNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "InsuranceName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbExtraCustomerName.Text = billCustomerName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboExtraCompanyNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExtraCompanyNo.SelectedIndexChanged
        Me.stbExtraCompanyName.Clear()
    End Sub

    Private Sub cboExtraCompanyNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExtraCompanyNo.Leave

        Dim companyName As String
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboExtraCompanyNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboExtraBillModesID, "To-Bill Account Category!")

            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboExtraCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()

                        For Each row As DataRow In billCompanies.Select("AccountNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("BillCustomerName")) Then
                                companyName = StringEnteredIn(row, "BillCustomerName")
                                companyNo = StringMayBeEnteredIn(row, "AccountNo")
                                Me.cboExtraCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbExtraCompanyName.Text = companyName
                        Next

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboExtraCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()

                        For Each row As DataRow In insuranceCompanies.Select("CompanyNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("CompanyName")) Then
                                companyName = StringEnteredIn(row, "CompanyName")
                                companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                                Me.cboExtraCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbExtraCompanyName.Text = companyName
                        Next

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region


    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub
End Class