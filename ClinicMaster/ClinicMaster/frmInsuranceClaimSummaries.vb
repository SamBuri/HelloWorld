
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing

Public Class frmInsuranceClaimSummaries

#Region " Fields "
    Private insuranceCompanies As DataTable

    ' The paragraphs.
    
    Private WithEvents docMemberConsumptionSummaries As New PrintDocument()
    Private ConsumptionSummariesParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 11, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 11)
#End Region

    Private Sub frmInsuranceClaimSummaries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.dtpStartDate.MaxDate = Today()
            Me.dtpEndDate.MaxDate = Today()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadHealthUnits()
            Me.LoadInsurances()
            Me.LoadSchemeMembers()
            Me.LoadMemberConsumption()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub frmInsuranceClaimSummaries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub cboInsuranceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboInsuranceNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadHealthUnits()

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            Dim healthUnits As DataTable = oHealthUnits.GetHealthUnits().Tables("HealthUnits")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboHealthUnitCode.Items.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboHealthUnitCode, healthUnits, "HealthUnitFullName")
            Me.cboHealthUnitCode.Items.Insert(0, String.Empty)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInsurances()

        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oCompanies As New SyncSoft.SQLDb.Companies()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from Insurances

            Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")
            LoadComboData(Me.cboInsuranceNo, insurances, "InsuranceFullName")
            LoadComboData(Me.cboGeneralInsuranceNo, insurances, "InsuranceFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            insuranceCompanies = oCompanies.GetCompanies().Tables("Companies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCompanyNo, insuranceCompanies, "CompanyFullName")
            Me.cboCompanyNo.Items.Insert(0, String.Empty)

            LoadComboData(Me.cboGeneralCompanyNo, insuranceCompanies, "CompanyFullName")
            Me.cboGeneralCompanyNo.Items.Insert(0, String.Empty)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadSchemeMembers()

        Dim oSchemeMember As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim schemeMember As DataTable = oSchemeMember.GetSchemeMembers().Tables("SchemeMembers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboMedicalCardNo, schemeMember, "MemberFullName")
            Me.cboMedicalCardNo.Items.Insert(0, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadMemberConsumption()

        Dim oSchemeMember As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim schemeMember As DataTable = oSchemeMember.GetSchemeMembersMainMemberDetails().Tables("SchemeMembers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboMainMemberNo, schemeMember, "MemberFullName")
            Me.cboMainMemberNo.Items.Insert(0, String.Empty)

            LoadComboData(Me.cbofullMainMemberNo, schemeMember, "MemberFullName")
            Me.cbofullMainMemberNo.Items.Insert(0, String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()
        Me.stbFullName.Clear()
        Me.stbMainMemberName.Clear()
        Me.stbMemberCompanyName.Clear()



    End Sub
    Private Sub clearConsumptioncontrols()
        Me.stbfullCompanyName.Clear()
        Me.stbfullMainMemberName.Clear()

    End Sub




    Private Sub ClearMainMemberControls()
        ' Me.stbMainMemberNo.Clear()
        Me.StbMainMemberNameDetails.Clear()
        Me.stbMainMemberCompanyName.Clear()
    End Sub


    Private Sub cboMedicalCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMedicalCardNo.Leave
        Me.ShowSchemeMembersDetails()
    End Sub

    Private Sub ShowSchemeMembersDetails()

        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ClearControls()

            Dim medicalCardNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboMedicalCardNo)))
            If String.IsNullOrEmpty(medicalCardNo) Then Return



            Dim row As DataRow = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers").Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboMedicalCardNo.Text = FormatText(medicalCardNo, "SchemeMembers", "MedicalCardNo").ToUpper()
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbMemberCompanyName.Text = StringEnteredIn(row, "CompanyName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    End Sub

    Private Sub ShowMainMemberSchemeMembersDetails()

        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ClearMainMemberControls()
            Dim mainMemberNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboMainMemberNo)))
            If String.IsNullOrEmpty(mainMemberNo) Then Return



            Dim row As DataRow = oSchemeMembers.GetSchemeMembersMainMemberDetails(mainMemberNo).Tables("SchemeMembers").Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboMainMemberNo.Text = FormatText(mainMemberNo, "SchemeMembers", "MainMemberNo").ToUpper()

            Me.StbMainMemberNameDetails.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbMainMemberCompanyName.Text = StringEnteredIn(row, "CompanyName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearMainMemberControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowMainMemberSchemeMembersComsumption()

        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim mainMemberNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cbofullMainMemberNo)))
            If String.IsNullOrEmpty(mainMemberNo) Then Return

            Me.clearConsumptioncontrols()

            Dim row As DataRow = oSchemeMembers.GetSchemeMembersMainMemberDetails(mainMemberNo).Tables("SchemeMembers").Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.cbofullMainMemberNo.Text = FormatText(mainMemberNo, "SchemeMembers", "MainMemberNo").ToUpper()
            Me.stbfullMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbfullCompanyName.Text = StringEnteredIn(row, "CompanyName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.clearConsumptioncontrols()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Grid Bills Claim per Service Point "

    Private Sub cboInsuranceNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboInsuranceNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbInsuranceName.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboInsuranceNo)))

            If String.IsNullOrEmpty(billNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadBillDetails(billNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillDetails(ByVal insuranceNo As String)


        Dim billCustomerName As String = String.Empty
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbInsuranceName.Clear()
            If String.IsNullOrEmpty(insuranceNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim row As DataRow = oInsurances.GetInsurances(insuranceNo).Tables("Insurances").Rows(0)

            Me.cboInsuranceNo.Text = FormatText(insuranceNo, "Insurances", "InsuranceNo").ToUpper()
            billCustomerName = StringMayBeEnteredIn(row, "InsuranceName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbInsuranceName.Text = billCustomerName
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

        Try

            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))

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

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oReports As New SyncSoft.SQLDb.Reports()
            Dim oInsuranceClaimSummaries As New SyncSoft.SQLDb.SchemeMembers()
            Dim flagStatusStyle As New DataGridViewCellStyle()
            Dim reports As DataTable
            Dim consumptionreports As DataTable
            Dim insuranceClaimSummaries As DataTable
            Dim fullConsumptionDetails As DataTable
            Dim styleTotal As New DataGridViewCellStyle()
            Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgClaimServicePoint.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim healthUnitCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboHealthUnitCode))

                    If Not String.IsNullOrEmpty(healthUnitCode) Then
                        reports = oReports.GetClaimSummaries(startDate, endDate, healthUnitCode).Tables("Reports")
                    Else : reports = oReports.GetClaimSummaries(startDate, endDate).Tables("Reports")
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvClaimServicePoint.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvClaimServicePoint

                            .Rows.Add()

                            .Item(Me.colBenefitName.Name, rowNo).Value = StringMayBeEnteredIn(row, "BenefitName")
                            .Item(Me.colTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvClaimServicePoint, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgCompanyClaimServicePoint.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim insuranceNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboInsuranceNo, "To-Bill Number!")))
                    Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then
                        reports = oReports.GetClaimSummariesByCompany(startDate, endDate, insuranceNo, companyNo).Tables("Reports")
                    Else : reports = oReports.GetClaimSummariesByCompany(startDate, endDate, insuranceNo).Tables("Reports")
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvCompanyClaimServicePoint.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvCompanyClaimServicePoint

                            .Rows.Add()

                            .Item(Me.colCompanyClaimCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "BenefitName")
                            .Item(Me.colCompanyTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvCompanyClaimServicePoint, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgMemberClaimServicePoint.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim medicalCardNo As String = SubstringRight(RevertText(StringMayBeEnteredIn(Me.cboMedicalCardNo)))

                    If Not String.IsNullOrEmpty(medicalCardNo) Then
                        reports = oReports.GetClaimSummariesByMedicalCardNo(startDate, endDate, medicalCardNo).Tables("Reports")
                    Else : reports = oReports.GetClaimSummariesByMedicalCardNo(startDate, endDate).Tables("Reports")
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvMemberClaimServicePoint.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvMemberClaimServicePoint

                            .Rows.Add()

                            Dim benefitCode As String = StringMayBeEnteredIn(row, "BenefitCode")
                            .Item(Me.colMemberItemCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "BenefitName")
                            Dim totalAmount As Decimal = DecimalMayBeEnteredIn(row, "TotalAmount")
                            .Item(Me.colMemberTotalAmount.Name, rowNo).Value = FormatNumber(totalAmount)

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                            If Not String.IsNullOrEmpty(medicalCardNo) AndAlso Not String.IsNullOrEmpty(benefitCode) Then
                                Me.DetailPolicyLimits(rowNo, medicalCardNo, benefitCode, totalAmount)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvMemberClaimServicePoint, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgMemberConsumptionDetails.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim mainMemberNo As String = SubstringRight(RevertText(StringMayBeEnteredIn(Me.cboMainMemberNo)))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    insuranceClaimSummaries = oInsuranceClaimSummaries.GetSchemeMembersMainMember(startDate, endDate, mainMemberNo).Tables("SchemeMembers")

                    LoadGridData(Me.dgvMemberConsumptionDetails, insuranceClaimSummaries)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If insuranceClaimSummaries IsNot Nothing AndAlso insuranceClaimSummaries.Rows.Count > 0 Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim miniCashPayments As EnumerableRowCollection(Of DataRow) = insuranceClaimSummaries.AsEnumerable()
                        Dim totalBill As Decimal = (From data In miniCashPayments Select data.Field(Of Decimal)("ClaimAmount")).Sum()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.stbGrandTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                        Me.stbAmountWords.Text = NumberToWords(totalBill)

                    Else
                        Me.stbGrandTotalAmount.Clear()
                        Me.stbAmountWords.Clear()

                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgfullMemberConsumptionDetails.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fmainMemberNo As String = SubstringRight(RevertText(StringMayBeEnteredIn(Me.cbofullMainMemberNo)))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    fullConsumptionDetails = oInsuranceClaimSummaries.GetSchemeMembersMainMemberConsumptionDetails(startDate, endDate, fmainMemberNo).Tables("SchemeMembers")

                    LoadGridData(Me.dgvMemberfullConsumptionDetails, fullConsumptionDetails)


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If fullConsumptionDetails IsNot Nothing AndAlso fullConsumptionDetails.Rows.Count > 0 Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim miniCashPayments As EnumerableRowCollection(Of DataRow) = fullConsumptionDetails.AsEnumerable()
                        Dim totalBill As Decimal = (From data In miniCashPayments Select data.Field(Of Decimal)("Amount")).Sum()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.stbMemberConsumptions.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                        Me.stbmemberConsumptionWords.Text = NumberToWords(totalBill)

                    Else
                        Me.stbMemberConsumptions.Clear()
                        Me.stbmemberConsumptionWords.Clear()

                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgGeneralConsumption.Name
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim oMemberTypeID As New LookupDataID.MemberTypeID
                    Dim insuranceNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboGeneralInsuranceNo, "To-Bill Number!")))
                    Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboGeneralCompanyNo)))
                    flagStatusStyle.BackColor = Color.MistyRose
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then
                        consumptionreports = oReports.GetClaimsGeneralConsumption(startDate, endDate, insuranceNo, companyNo).Tables("Reports")
                    Else : consumptionreports = oReports.GetClaimsGeneralConsumption(startDate, endDate, insuranceNo).Tables("Reports")
                    End If
                    LoadGridData(Me.dgvGeneralConsumption, consumptionreports)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For Each row As DataGridViewRow In Me.dgvGeneralConsumption.Rows
                        If row.IsNewRow Then Exit For

                        Dim membertype As String = StringMayBeEnteredIn(row.Cells, Me.ColGeneralMemberType)

                        If membertype = GetLookupDataDes(oMemberTypeID.Dependant) Then Me.dgvGeneralConsumption.Rows(row.Index).DefaultCellStyle.ApplyStyle(flagStatusStyle)

                    Next
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub DetailPolicyLimits(ByVal rowNo As Integer, ByVal medicalCardNo As String, ByVal benefitCode As String, totalAmount As Decimal)

        Dim limitBalance As Decimal
        Dim styleLimit As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        styleLimit.BackColor = Color.MistyRose
        styleLimit.Font = font

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim limitAmount As Decimal = GetPolicyLimit(medicalCardNo, benefitCode)
        If limitAmount > 0 Then
            limitBalance = limitAmount - totalAmount
        Else : limitBalance = 0
        End If

        Me.dgvMemberClaimServicePoint.Item(Me.colLimitAmount.Name, rowNo).Value = FormatNumber(limitAmount, AppData.DecimalPlaces)
        Me.dgvMemberClaimServicePoint.Item(Me.colLimitBalance.Name, rowNo).Value = FormatNumber(limitBalance, AppData.DecimalPlaces)

        If limitBalance < 0 Then Me.dgvMemberClaimServicePoint.Rows(rowNo).Cells(Me.colLimitBalance.Name).Style.ApplyStyle(styleLimit)

    End Sub

    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim _objectCaption As String = Me.tbcPeriodicReport.SelectedTab.Text

            Dim documentTitle As String = _objectCaption + " for the period between " _
                       + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgClaimServicePoint.Name
                    ExportToExcel(Me.dgvClaimServicePoint, _objectCaption, documentTitle)

                Case Me.tpgCompanyClaimServicePoint.Name
                    ExportToExcel(Me.dgvCompanyClaimServicePoint, _objectCaption, documentTitle)

                Case Me.tpgMemberClaimServicePoint.Name
                    ExportToExcel(Me.dgvMemberClaimServicePoint, _objectCaption, documentTitle)
                Case Me.tpgMemberConsumptionDetails.Name
                    ExportToExcel(Me.dgvMemberConsumptionDetails, _objectCaption, documentTitle)
                Case Me.tpgfullMemberConsumptionDetails.Name
                    ExportToExcel(Me.dgvMemberfullConsumptionDetails, _objectCaption, documentTitle)

                Case Me.tpgGeneralConsumption.Name
                    ExportToExcel(Me.dgvGeneralConsumption, _objectCaption, documentTitle)

            End Select

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Popup Menu "

    Private Sub cmsClaimSummaries_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsClaimSummaries.Opening

        Select Case Me.tbcPeriodicReport.SelectedTab.Name

            Case Me.tpgClaimServicePoint.Name

                If Me.dgvClaimServicePoint.ColumnCount < 1 OrElse Me.dgvClaimServicePoint.RowCount < 1 Then
                    Me.cmsClaimSummariesCopy.Enabled = False
                    Me.cmsClaimSummariesSelectAll.Enabled = False
                Else
                    Me.cmsClaimSummariesCopy.Enabled = True
                    Me.cmsClaimSummariesSelectAll.Enabled = True
                End If

            Case Me.tpgCompanyClaimServicePoint.Name

                If Me.dgvCompanyClaimServicePoint.ColumnCount < 1 OrElse Me.dgvCompanyClaimServicePoint.RowCount < 1 Then
                    Me.cmsClaimSummariesCopy.Enabled = False
                    Me.cmsClaimSummariesSelectAll.Enabled = False
                Else
                    Me.cmsClaimSummariesCopy.Enabled = True
                    Me.cmsClaimSummariesSelectAll.Enabled = True
                End If

            Case Me.tpgMemberClaimServicePoint.Name

                If Me.dgvMemberClaimServicePoint.ColumnCount < 1 OrElse Me.dgvMemberClaimServicePoint.RowCount < 1 Then
                    Me.cmsClaimSummariesCopy.Enabled = False
                    Me.cmsClaimSummariesSelectAll.Enabled = False
                Else
                    Me.cmsClaimSummariesCopy.Enabled = True
                    Me.cmsClaimSummariesSelectAll.Enabled = True
                End If

            Case Else
                Me.cmsClaimSummariesCopy.Enabled = False
                Me.cmsClaimSummariesSelectAll.Enabled = False

        End Select

    End Sub

    Private Sub cmsClaimSummariesCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsClaimSummariesCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgClaimServicePoint.Name

                    If Me.dgvClaimServicePoint.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvClaimServicePoint))

                Case Me.tpgCompanyClaimServicePoint.Name

                    If Me.dgvCompanyClaimServicePoint.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvCompanyClaimServicePoint))

                Case Me.tpgMemberClaimServicePoint.Name

                    If Me.dgvMemberClaimServicePoint.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvMemberClaimServicePoint))

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsClaimSummariesSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsClaimSummariesSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgClaimServicePoint.Name
                    Me.dgvClaimServicePoint.SelectAll()

                Case Me.tpgCompanyClaimServicePoint.Name
                    Me.dgvCompanyClaimServicePoint.SelectAll()

                Case Me.tpgMemberClaimServicePoint.Name
                    Me.dgvMemberClaimServicePoint.SelectAll()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub cboMainMemberNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboMainMemberNo.TextChanged
        Me.ClearMainMemberControls()
    End Sub

    Private Sub cboMainMemberNo_Leave(sender As System.Object, e As System.EventArgs) Handles cboMainMemberNo.Leave

        Try
            Me.ShowMainMemberSchemeMembersDetails()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cbofullMainMemberNo_Leave(sender As System.Object, e As System.EventArgs) Handles cbofullMainMemberNo.Leave
        Try
            Me.ShowMainMemberSchemeMembersComsumption()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cbofullMainMemberNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles cbofullMainMemberNo.TextChanged
        Me.clearConsumptioncontrols()
    End Sub


#Region " Grid General Consumption "

    Private Sub cboGeneralInsuranceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboGeneralInsuranceNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub cboGeneralInsuranceNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboGeneralInsuranceNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbGeneralInsuranceName.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboGeneralInsuranceNo)))

            If String.IsNullOrEmpty(billNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadGeneralBillDetails(billNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadGeneralBillDetails(ByVal insuranceNo As String)


        Dim billCustomerName As String = String.Empty
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbGeneralInsuranceName.Clear()
            If String.IsNullOrEmpty(insuranceNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim row As DataRow = oInsurances.GetInsurances(insuranceNo).Tables("Insurances").Rows(0)

            Me.cboGeneralInsuranceNo.Text = FormatText(insuranceNo, "Insurances", "InsuranceNo").ToUpper()
            billCustomerName = StringMayBeEnteredIn(row, "InsuranceName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbGeneralInsuranceName.Text = billCustomerName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboGeneralCompanyNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGeneralCompanyNo.SelectedIndexChanged
        Me.stbGeneralCompanyName.Clear()
    End Sub

    Private Sub cboGeneralCompanyNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGeneralCompanyNo.Leave

        Dim companyName As String

        Try

            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboGeneralCompanyNo)))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(companyNo) Then

                Me.cboGeneralCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()

                For Each row As DataRow In insuranceCompanies.Select("CompanyNo = '" + companyNo + "'")

                    If Not IsDBNull(row.Item("CompanyName")) Then
                        companyName = StringEnteredIn(row, "CompanyName")
                        companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                        Me.cboGeneralCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()
                    Else
                        companyName = String.Empty
                        companyNo = String.Empty
                    End If

                    Me.stbGeneralCompanyName.Text = companyName
                Next

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region



    Private Sub cboMedicalCardNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedicalCardNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

#Region " MemberConsumptionDetails Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintMemberConsumptionDetails()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub PrintMemberConsumptionDetails()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvMemberConsumptionDetails.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry of Member Consumption Details!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetMemberConsumptionDetailsPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docMemberConsumptionSummaries
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docMemberConsumptionSummaries.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docMemberConsumptionSummaries_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docMemberConsumptionSummaries.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Member Consumption Summary".ToUpper()

            Dim mainMemberNo As String = StringMayBeEnteredIn(Me.cboMainMemberNo)
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDate))
            Dim memberNameDetails As String = StringMayBeEnteredIn(Me.StbMainMemberNameDetails)
            Dim mainmemberCompanyName As String = StringMayBeEnteredIn(Me.stbMainMemberCompanyName)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 18 * widthTopFirst
                Dim widthTopFourth As Single = 26 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Main MemberNo No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(mainMemberNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Member Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(memberNameDetails, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Company Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(mainmemberCompanyName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += 2 * lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If ConsumptionSummariesParagraphs Is Nothing Then Return

                Do While ConsumptionSummariesParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(ConsumptionSummariesParagraphs(1), PrintParagraps)
                    ConsumptionSummariesParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        ConsumptionSummariesParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (ConsumptionSummariesParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetMemberConsumptionDetailsPrintData()
        Dim padTotalAmount As Integer = 1
        Dim padItemNo As Integer = 4
        Dim padFullName As Integer = 20
        Dim padMemberType As Integer = 11
        Dim padPatientNo As Integer = 15
        Dim padAmount As Integer = 12

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        ConsumptionSummariesParagraphs = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Full Name: ".PadRight(padFullName))
            tableHeader.Append("Member Type: ".PadLeft(padMemberType))
            tableHeader.Append(GetSpaces(1) + "Patient No: ".PadRight(padPatientNo))
            tableHeader.Append("Amount: ".PadRight(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            ConsumptionSummariesParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvMemberConsumptionDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvMemberConsumptionDetails.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim FullName As String = StringMayBeEnteredIn(cells, Me.ColFullName)
                Dim MemberType As String = StringMayBeEnteredIn(cells, Me.ColMembertype)
                Dim PatientNo As String = StringMayBeEnteredIn(cells, Me.ColPatientNo)
                Dim Amount As String = StringMayBeEnteredIn(cells, Me.ColClaimAmount)


                tableData.Append(itemNo.PadRight(padItemNo))
                If FullName.Length > 25 Then
                    tableData.Append(FullName.Substring(0, 25).PadRight(padFullName))
                Else : tableData.Append(FullName.PadRight(padFullName))
                End If
                tableData.Append(MemberType.PadLeft(padMemberType))
                tableData.Append(GetSpaces(1) + PatientNo.PadRight(padPatientNo))
                tableData.Append(Amount.PadRight(padAmount))

                tableData.Append(ControlChars.NewLine)

            Next

            ConsumptionSummariesParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
            Dim accountusage As New System.Text.StringBuilder(String.Empty)
            Dim grandTotals As Decimal = DecimalMayBeEnteredIn(stbGrandTotalAmount, True)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            accountusage.Append(ControlChars.NewLine)
            accountusage.Append("Current Total Consumption: ")
            accountusage.Append(FormatNumber(grandTotals, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            accountusage.Append(ControlChars.NewLine)
            ConsumptionSummariesParagraphs.Add(New PrintParagraps(bodyBoldFont, accountusage.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            accountusage.Append(ControlChars.NewLine)
            accountusage.Append(ControlChars.NewLine)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Prepared By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            ConsumptionSummariesParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            'checkedSignData.Append(ControlChars.NewLine)

            'checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            'checkedSignData.Append(GetSpaces(4))
            'checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            'checkedSignData.Append(ControlChars.NewLine)
            'ConsumptionSummariesParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            ConsumptionSummariesParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

    Private Sub tbcPeriodicReport_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbcPeriodicReport.SelectedIndexChanged
        Select Case Me.tbcPeriodicReport.SelectedTab.Name

            Case tpgMemberConsumptionDetails.Name
                Me.fbnPrint.Visible = True
            Case Else

                Me.fbnPrint.Visible = False
        End Select
    End Sub
End Class