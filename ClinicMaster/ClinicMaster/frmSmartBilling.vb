
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb
Imports System.Collections.Generic
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmSmartBilling

#Region " Fields "
    Private oVariousOptions As New VariousOptions()
    Private patientNo As String
    Private copayTypeID As String
    Private genderID As String
    Private copayValue As Decimal
    Private oIntegrationAgent As New IntegrationAgents()
    Private smartAgentNo As String = oIntegrationAgent.SMART()
    Private oCopayTypeID As New CoPayTypeID()
    Private defaultAdmissionNo As String
    Private saveApproved As Boolean
#End Region

    Private Sub frmSmartBilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            If Not String.IsNullOrEmpty(defaultAdmissionNo) Then
                Me.stbAdmissionNo.Text = defaultAdmissionNo
                Me.ShowPatientDetails(RevertText(defaultAdmissionNo))

            End If


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSmartBilling_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindAdmissionNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindAdmissionNo.Click
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub btnLoadAdmissions_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadAdmissions.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
        fInWardAdmissions.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
        If String.IsNullOrEmpty(admissionNo) Then Return
        Me.ShowPatientDetails(admissionNo)

    End Sub


    Private Sub ShowPatientDetails(ByVal admissionNo As String)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()

        Try

            Me.ClearControls()

            Dim admissions As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")
            Dim row As DataRow = admissions.Rows(0)

            patientNo = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")

            Me.stbAdmissionNo.Text = FormatText(admissionNo, "Admissions", "AdmissionNo")
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
            Me.stbAdmissionStatus.Text = StringMayBeEnteredIn(row, "AdmissionStatus")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.genderID = StringEnteredIn(row, "GenderID")
            Me.copayTypeID = StringMayBeEnteredIn(row, "CoPayTypeID")
            Me.copayValue = DecimalMayBeEnteredIn(row, "CoPayValue", False)
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName

            'billModesID = StringMayBeEnteredIn(row, "BillModesID")
            'associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            Dim oINTAdmissions As New INTAdmissions()
            Dim _INTAdmissions As DataTable = oINTAdmissions.GetINTAdmissions(oIntegrationAgent.SMART, admissionNo).Tables("INTAdmissions")
            Dim rowINTAdmissions As DataRow = _INTAdmissions.Rows(0)
            Dim provisionalMemberLimit As Decimal = DecimalEnteredIn(rowINTAdmissions, "MemberLimit", False)
            Me.stbProvisionalLimit.Text = FormatNumber(provisionalMemberLimit, AppData.DecimalPlaces)


            Me.LoadSmartBill(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        End Try

    End Sub


    Private Sub ClearControls()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbVisitNo.Clear()
        Me.stbGender.Clear()
        Me.stbAge.Clear()
        Me.stbAdmissionStatus.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbBillMode.Clear()
        Me.stbProvisionalLimit.Clear()

        'billModesID = String.Empty
        'associatedBillNo = String.Empty


    End Sub

    Private Sub LoadSmartBill(visitNo As String)

        Try
            Dim oINTExtraBillItems As New INTExtraBillItems()
            Dim _INTExtraBillItems As DataTable = oINTExtraBillItems.GetINTExtraBillItemsBySyncStatus(smartAgentNo, visitNo, False).Tables("INTExtraBillItems")

            LoadGridData(dgvSmartBills, _INTExtraBillItems)
            FormatGridRow(dgvSmartBills)
            Me.CalculateTotalBill()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub


    Private Sub CalculateTotalBill()

        Dim totalBill As Decimal
        Dim totalCopayValue As Decimal

        Me.stbBillForItem.Clear()
        Me.stbBillWords.Clear()


        For rowNo As Integer = 0 To Me.dgvSmartBills.RowCount - 1
            If CBool(Me.dgvSmartBills.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvSmartBills.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
                Dim cashAmount As Decimal = DecimalMayBeEnteredIn(cells, Me.colCashAmount)
                totalBill += amount
                totalCopayValue += cashAmount
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        If Me.copayTypeID = oCopayTypeID.Percent Then
            Me.nbxCoPayValue.Value = FormatNumber(totalCopayValue, AppData.DecimalPlaces)
        Else : Me.nbxCoPayValue.Value = FormatNumber(Me.copayValue, AppData.DecimalPlaces)
        End If
        Me.stbBillWords.Text = NumberToWords(totalBill)


    End Sub


    Private Sub dgvSmartBills_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSmartBills.CellContentClick

    End Sub

    Private Sub dgvSmartBills_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSmartBills.CellEndEdit
        If e.ColumnIndex.Equals(Me.colInclude.Index) Then
            Me.CalculateTotalBill()
        End If
    End Sub

    Private Sub ebnSaveUpdate_Click(sender As System.Object, e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim oSmartCardItems As SmartCardItems
        Dim oSmartCardMembers As New SmartCardMembers()
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim lINTExtraBillItems As New List(Of DBConnect)
        Dim lINTExtraBills As New List(Of DBConnect)
        Dim lExtraBillNo As New List(Of String)

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Cursor = Cursors.Default
            Dim lSmartCardItems As New List(Of SmartCardItems)
            oSmartCardMembers = ProcessSmartCardData(patientNo)
            Dim coverAmount As Decimal = oSmartCardMembers.CoverAmount
            Dim expiryDate As Date = oSmartCardMembers.SchemeExpiryDate
            Dim totalBill As Decimal = DecimalMayBeEnteredIn(stbBillForItem)

            If oSmartCardMembers.CoverAmount < totalBill Then
                Throw New ArgumentException("The Cover Amount " + coverAmount.ToString + " can't be less than total bill " + totalBill.ToString)
            End If
            'If expiryDate < Today Then
            '    Throw New ArgumentException("The scheeme expiry date:  " + expiryDate.ToString + " cannot be less than today. Please contact Smart for assistance ")
            'End If
            Dim smardCardNo As String = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
            Dim visitNo As String = RevertText(RevertText(StringMayBeEnteredIn(stbVisitNo)))
            Dim totalCashAmount As Decimal

            For rowNo As Integer = 0 To Me.dgvSmartBills.RowCount - 1

                If CBool(Me.dgvSmartBills.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvSmartBills.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colItemName, "Item Name!")
                    Dim extraBillNo As String = StringEnteredIn(cells, Me.colExtraBillNo, "Extra Bill No!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity)
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False)
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False)
                    Dim cashAmount As Decimal = DecimalEnteredIn(cells, Me.colCashAmount, False)
                    totalCashAmount += cashAmount
                    Using oINTExtraBillItems As New SyncSoft.SQLDb.INTExtraBillItems()
                        With oINTExtraBillItems
                            .AgentNo = smartAgentNo
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .SyncStatus = True
                        End With
                        lINTExtraBillItems.Add(oINTExtraBillItems)
                    End Using

                    If Not lExtraBillNo.Contains(extraBillNo) Then
                        Using oINTExtraBills As New INTExtraBills
                            With oINTExtraBills
                                .AgentNo = smartAgentNo
                                .ExtraBillNo = extraBillNo
                                .SyncStatus = True
                            End With
                            lINTExtraBills.Add(oINTExtraBills)
                        End Using

                    End If

                    With oSmartCardItems

                        .TransactionDate = FormatDate(Today, "yyyy-MM-dd")
                        .TransactionTime = GetTime(Now)
                        .ServiceProviderNr = oVariousOptions.SmartCardServiceProviderNo
                        .DiagnosisCode = (0).ToString()
                        .DiagnosisDescription = "Unknown Disease"
                        .EncounterType = GetEncounterType(itemCategoryID)
                        .CodeType = "Mcode"
                        .Code = itemCode
                        .CodeDescription = itemName
                        .Quantity = quantity.ToString()
                        .Amount = (quantity * unitPrice).ToString()

                    End With

                    lSmartCardItems.Add(oSmartCardItems)


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next


            oSmartCardMembers.InvoiceNo = visitNo
            oSmartCardMembers.TotalBill = totalBill
            oSmartCardMembers.TotalServices = lSmartCardItems.Count()
            oSmartCardMembers.CopayType = copayTypeID
            oSmartCardMembers.CopayAmount = DecimalMayBeEnteredIn(Me.nbxCoPayValue)
            oSmartCardMembers.Gender = genderID

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lINTExtraBillItems, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lINTExtraBills, Action.Save))
            Dim oVisitType As New LookupDataID.VisitTypeID()
            If UpdateSmartExchangeFiles(oSmartCardMembers, lSmartCardItems, visitNo, oVisitType.InPatient) Then
                DoTransactions(transactions)

            Else
                Throw New ArgumentException("Error processing smart card information. Please edit the Patient and try again")
                Return
            End If
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            Me.saveApproved = False
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowPatientDetails(admissionNo)
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub stbAdmissionNo_Leave(sender As Object, e As System.EventArgs) Handles stbAdmissionNo.Leave
        Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
        If String.IsNullOrEmpty(admissionNo) Then Return
        Me.ShowPatientDetails(admissionNo)
    End Sub

    Public Function GetSaveApproved() As Boolean
        Return Me.saveApproved
    End Function

End Class