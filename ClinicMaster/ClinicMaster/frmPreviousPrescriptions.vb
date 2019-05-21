Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing

Public Class frmPreviousPrescriptions

#Region " Fields "
    Private doctorLoginID As String = String.Empty
    Private staffFullName As String = String.Empty
    Private visitServiceCode As String = String.Empty
    Private visitStandardFee As Decimal = 0
    Private visitServiceName As String = String.Empty
    Private accessCashServices As Boolean = False
    Private servicePayStatusID As String = String.Empty
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private tipBillServiceFeeWords As New ToolTip()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCoPayValueWords As New ToolTip()
    Private billCustomerName As String = String.Empty

    Private WithEvents docDoctor As New PrintDocument()

    ' The paragraphs.
    Private padLineNo As Integer = 6
    Private padService As Integer = 44
    Private padNotes As Integer = 20

    Private title As String
    Private doctorParagraphs As Collection
    Private medicalReportParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
#End Region

    Private Sub frmPreviousPrescriptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVariousOptions As New VariousOptions()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadStaff()
            Me.LoadServices()
            Me.LoadDrugs()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadDrugs()

        Dim drugs As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs
            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colDrug, drugs, "DrugFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServices()

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServicePointID As New LookupDataID.ServicePointID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from services
            Dim services As DataTable = oServices.GetServicesAtServicePoint(oServicePointID.Visit).Tables("Services")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboServiceCode.Sorted = False
            Me.cboServiceCode.DataSource = services
            Me.cboServiceCode.DisplayMember = "ServiceName"
            Me.cboServiceCode.ValueMember = "ServiceCode"

            Me.cboServiceCode.SelectedIndex = -1
            Me.cboServiceCode.SelectedIndex = -1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadVisitsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadVisitsData(ByVal visitNo As String)

        Try
            Me.ShowPatientDetails(visitNo)
            Me.LoadPrescriptions(visitNo)
            Me.LoadDoctorVisit(visitNo)
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPrescriptions(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Drug).Tables("Items")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                With Me.dgvPrescription
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                    .Item(Me.colDoctorQuantity.Name, pos).Value = IntegerEnteredIn(row, "DoctorQuantity")
                    .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colBalance.Name, pos).Value = IntegerEnteredIn(row, "Balance")
                    .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDrugPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = True
                End With

            Next
            Me.CalculatePrescriptionTotalBill()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculatePrescriptionTotalBill()

        Dim totalBill As Decimal

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.stbBillForPrescription.Clear()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
            totalBill += amount

        Next

        Me.stbBillForPrescription.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadSeeDrVisits_Click(sender As Object, e As EventArgs) Handles btnLoadSeeDrVisits.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSeeDoctorVisits As New frmSeeDoctorVisits(Me.stbVisitNo)
            fSeeDoctorVisits.ShowDialog(Me)

            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowVisitsHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadVisitsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVariousOptions As New VariousOptions()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"

        Try

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Me.stbVisitDate.Text = FormatDate(visitDate)
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbAge.Text = GetAgeString(birthDate)
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Me.stbCombination.Text = StringMayBeEnteredIn(row, "Combination")
            Dim billMode As String = StringEnteredIn(row, "BillMode")
            Me.stbBillMode.Text = billMode
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            doctorLoginID = StringMayBeEnteredIn(row, "DoctorLoginID")
            visitServiceCode = StringMayBeEnteredIn(row, "ServiceCode")
            visitServiceName = StringMayBeEnteredIn(row, "ServiceName")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            servicePayStatusID = StringMayBeEnteredIn(row, "ServicePayStatusID")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))
            Me.stbCombination.Text = StringMayBeEnteredIn(row, "Combination")
            Me.stbVisitServiceName.Text = visitServiceName
            Me.lblServicePayStatusID.Text = GetLookupDataDes(servicePayStatusID)

            Dim doctorServiceCode As String = StringMayBeEnteredIn(row, "DoctorServiceCode")
            Dim serviceCode As String

            If Not String.IsNullOrEmpty(doctorServiceCode) Then
                Me.cboServiceCode.SelectedValue = doctorServiceCode
                serviceCode = doctorServiceCode
            Else
                Me.cboServiceCode.SelectedValue = visitServiceCode
                serviceCode = visitServiceCode
            End If

            'If Not String.IsNullOrEmpty(serviceCode) Then
            '    Try
            '        'Dim items As DataTable = oItems.GetItem(visitNo, serviceCode, oItemCategoryID.Service).Tables("Items")
            '        'Dim itemsRow As DataRow = items.Rows(0)
            '        'visitStandardFee = DecimalMayBeEnteredIn(itemsRow, "UnitPrice")
            '        'Me.stbBillServiceFee.Text = FormatNumber(visitStandardFee, AppData.DecimalPlaces)

            '    Catch eX As Exception
            '        'Throw eX

            '    End Try

            'End If

        Catch eX As Exception
            Throw eX

        End Try






    End Sub


    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbBillServiceFee.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbTotalVisits.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        Me.stbCombination.Clear()
        Me.stbBillMode.Clear()
        Me.cboServiceCode.SelectedIndex = -1
        Me.cboServiceCode.SelectedIndex = -1
        Me.stbVisitServiceName.Clear()
        Me.lblServicePayStatusID.Text = String.Empty
        Me.spbPhoto.Image = Nothing

    End Sub

    Private Sub ResetControls()
        '''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)
    End Sub

    Private Sub btnFindVisitNo_Click(sender As Object, e As EventArgs) Handles btnFindVisitNo.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowVisitsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDoctorVisit(ByVal visitNo As String)

        Dim oVariousOptions As New VariousOptions()
        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oServiceBillAtID As New LookupDataID.ServiceBillAtID()

        Try

            Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()

            If oDoctorVisits.GetDoctorVisit(visitNo) Then
                Me.cboStaffNo.Text = oDoctorVisits.StaffFullName
                Me.cboStaffNo.Enabled = False

                If Not String.IsNullOrEmpty(oDoctorVisits.ServiceCode) Then
                    Me.cboServiceCode.SelectedValue = oDoctorVisits.ServiceCode
                    Me.cboServiceCode.Enabled = False
                Else : Me.cboServiceCode.Enabled = True
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                Me.cboStaffNo.SelectedIndex = -1
                Me.cboStaffNo.SelectedIndex = -1
                Me.cboStaffNo.Text = staffFullName
                Me.cboStaffNo.Enabled = True

                Me.cboServiceCode.SelectedIndex = -1
                Me.cboServiceCode.SelectedIndex = -1
                Me.cboServiceCode.SelectedValue = visitServiceCode
                Me.cboServiceCode.Enabled = True

            End If


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrRoles.SelectedTab.Name


                Case Me.tpgPrescriptions.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Prescription".ToUpper()
                    Me.PrintPrescription()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub docDoctor_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docDoctor.PrintPage

        Try

            Dim titleFont As New Font("Courier New", 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = SubstringLeft(Me.cboStaffNo.Text)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 6 * widthTopFirst
                Dim widthTopThird As Single = 15 * widthTopFirst
                Dim widthTopFourth As Single = 25 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
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

                If doctorParagraphs Is Nothing Then Return

                Do While doctorParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(doctorParagraphs(1), PrintParagraps)
                    doctorParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont, _
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
                        doctorParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (doctorParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnSelfRequests_Click(sender As Object, e As EventArgs) Handles btnSelfRequests.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oCurrentPatient As New CurrentPatient()
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            PharmacyPrescription.Balance.Clear()
            PharmacyPrescription.Quantity.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim message As String
            'If Me.dgvPaymentDetails.RowCount = 1 Then
            '    message = "Current payment detail is not saved. " + ControlChars.NewLine + "Continue anyway?"
            'Else : message = "Current payment details are not saved. " + ControlChars.NewLine + "Continue anyway?"
            'End If
            'If Not Me.CashRecordSaved(True) Then If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            'Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxOutstandingBalance, True)
            'Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If outstandingBalance > totalBill Then
            '    message = "The system has detected that this patient has outstanding balance." + ControlChars.NewLine +
            '        "It’s recommended that you navigate to previous visits for unpaid for item(s) before creating a self request." +
            '        ControlChars.NewLine + "Just continue anyway?"
            '    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            'End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For count As Integer = 0 To dgvPrescription.Rows.Count - 1
                'PharmacyPrescription.Balance.Add(count, Convert.ToInt32(Me.dgvPrescription.Item(Me.colBalance.Name, count).Value))
                'PharmacyPrescription.Quantity.Add(count, Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, count).Value))
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelfRequests As New frmSelfRequests(True, patientNo, Me.stbVisitNo.Text)
            fSelfRequests.Save()
            fSelfRequests.ShowDialog()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(oCurrentPatient.VisitNo) Then Return
            'Me.ShowCashPatientDetails(oCurrentPatient.VisitNo)
            'Me.LoadCashPaymentData(oCurrentPatient.VisitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oCurrentPatient.PatientNo = String.Empty
            oCurrentPatient.VisitNo = String.Empty
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#Region " Prescription - Printing "

    Private Sub PrintPrescription()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for prescription!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for prescription!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPrescriptionPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetPrescriptionPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 18
        Dim padFullDosage As Integer = 18
        Dim padQuantity As Integer = 5
         Dim padAmount As Integer = 14
        Dim padStatus As Integer = 12
        Dim padTotalAmount As Integer = 58

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Drug : ".PadRight(padItemName))
            tableHeader.Append(" ")
            tableHeader.Append("Dosage: ".PadRight(padFullDosage))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Status: ".PadLeft(padStatus))
            tableHeader.Append("Amount: ".PadLeft(padAmount))

            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = SubstringLeft(cells.Item(Me.colDrug.Name).Value.ToString())
                    Dim dosage As String = cells.Item(Me.colDosage.Name).Value.ToString()
                    Dim duration As String = cells.Item(Me.colDuration.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colDrugQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colDrugUnitPrice.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colAmount.Name).Value.ToString()
                    Dim status As String = cells.Item(Me.colDrugPayStatus.Name).Value.ToString()

                    Dim fullDosage As String
                    If duration.Trim().Equals("1") Then
                        fullDosage = dosage + "," + duration + " day"
                    Else : fullDosage = dosage + "," + duration + " days"
                    End If

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 18 Then
                        tableData.Append(itemName.Substring(0, 18).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(" ")
                    If fullDosage.Length > 18 Then
                        tableData.Append(fullDosage.Substring(0, 18).PadRight(padFullDosage))
                    Else : tableData.Append(fullDosage.PadRight(padFullDosage))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(status.PadLeft(padStatus))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForPrescription.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region



   
 
End Class