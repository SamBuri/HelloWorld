
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.SQLDb
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmQuotations

#Region " Fields "


    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty

    Private radiologyExaminations As DataTable
    Private drugs As DataTable
    Private labTests As DataTable
    Private procedures As DataTable
    Private dentalServices As DataTable
    Private theatreServices As DataTable
    Private opticalServices As DataTable
    Private maternityServices As DataTable
    Private iCUServices As DataTable
    Private consumableItems As DataTable
    Private extraChargeItems As DataTable

    Private _ExamNameValue As String = String.Empty
    Private _TestValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _DentalNameValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty
    Private _OpticalNameValue As String = String.Empty
    Private _MaternityNameValue As String = String.Empty
    Private _ICUNameValue As String = String.Empty
    Private _ConsumableItemValue As String = String.Empty
    Private _ExtraItemValue As String = String.Empty
    Private oBillModesID As New LookupDataID.BillModesID()

#End Region

    Private Sub frmQuotations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.dtpQuotationDate.MaxDate = Today

            Me.LoadLabTests()
            Me.LoadDrugs()
            Me.LoadRadiologyExaminations()
            Me.LoadProcedures()
            Me.LoadDentalServices()
            Me.LoadTheatreServices()
            Me.LoadOpticalServices()
            Me.LoadMaternityServices()
            Me.LoadICUServices()
            Me.LoadConsumableItems()
            Me.LoadExtraChargeItems()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmQuotations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oQuotations As New SyncSoft.SQLDb.Quotations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oQuotations.QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
            DisplayMessage(oQuotations.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            'ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oQuotations As New SyncSoft.SQLDb.Quotations()
        Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim quotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
            Dim dataSource As DataTable = oQuotations.GetQuotations(quotationNo).Tables("Quotations")

            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oQuotations As New SyncSoft.SQLDb.Quotations()
        Dim totalQuotationBill As Decimal = 0
        totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            With oQuotations

                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .QuotationDate = DateEnteredIn(Me.dtpQuotationDate, "Quotation Date!")
                '.AmountWords = StringEnteredIn(Me.stbAmountWords, "Amount Words!")
                .AmountWords = NumberToWords(totalQuotationBill)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                ''''''''''''''''''''''''''''''''''' SAVING THE RECORDS ''''''''''''''''''''''''''''
                Case ButtonCaption.Save

                    If IsBlankDataGrids() Then
                        Throw New ArgumentException("Must register atleast one item")
                    End If

                    If Not IsAllDatagridsVerified() Then
                        Throw New ArgumentException("Must enter numeric for Quantity")
                    End If

                    If oQuotations.Save() Then

                        Me.SaveLaboratory()
                        Me.SaveRadiology()
                        Me.SavePrescriptions()
                        Me.SaveProcedures()
                        Me.SaveTheatre()
                        Me.SaveDental()
                        Me.SaveOptical()
                        Me.SaveMaternity()
                        Me.SaveICU()
                        Me.SaveConsumables()
                        Me.SaveExtraCharge()

                        If Me.chkPrintQuotationOnSaving.Checked Then
                             Me.btnPrint.PerformClick()
                        End If


                        '  ResetControlsIn(Me)
                        ClearControls()
                        Me.SetNextQuotationNo()

                        '  MessageBox.Show("Quotation Saved successfully")
                    Else
                        MessageBox.Show("Quotation Not Saved")
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''' UPDATING THE RECORDS ''''''''''''''''''''''''''''
                Case ButtonCaption.Update
                    'Check if no grid contains a selected item
                    If IsBlankDataGrids() Then
                        Throw New ArgumentException("Must register atleast one item")
                    End If

                    If Not IsAllDatagridsVerified() Then
                        Throw New ArgumentException("Must enter numeric for Quantity")
                    End If

                    DisplayMessage(oQuotations.Update())

                    Me.UpdateLaboratory()
                    Me.UpdateRadiology()
                    Me.UpdatePrescriptions()
                    Me.UpdateProcedures()
                    Me.UpdateTheatre()
                    Me.UpdateDental()
                    Me.UpdateOptical()
                    Me.UpdateMaternity()
                    Me.UpdateICU()
                    Me.UpdateConsumables()
                    Me.UpdateExtraCharge()

                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True
        Me.btnPrint.Visible = True

        Me.stbVisitNo.Enabled = False
        Me.btnFindVisitNo.Enabled = False
        Me.btnLoadPeriodicVisits.Enabled = False
        Me.chkPrintQuotationOnSaving.Enabled = False

        'ResetControlsIn(Me)
        Me.ClearControls()

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.btnPrint.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.btnPrint.Visible = True

        Me.stbVisitNo.Enabled = True
        Me.btnFindVisitNo.Enabled = True
        Me.btnLoadPeriodicVisits.Enabled = True
        Me.chkPrintQuotationOnSaving.Enabled = True

        'ResetControlsIn(Me)
        Me.ClearControls()
        Me.SetNextQuotationNo()

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

            '----------------- POPULATING THE DATAGRIDS WITH SAVED VALUES
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            Me.LoadExtraChargeData(visitNo)
            Me.LoadConsumablesData(visitNo)
            Me.LoadICUData(visitNo)
            Me.LoadMaternityData(visitNo)
            Me.LoadOpticalData(visitNo)
            Me.LoadTheatreData(visitNo)
            Me.LoadDentalData(visitNo)
            Me.LoadProceduresData(visitNo)
            Me.LoadPrescriptionsData(visitNo)
            Me.LoadRadiologyData(visitNo)
            Me.LoadLaboratoryData(visitNo)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub

#End Region

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbVisitDate.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbQuotationNo.Clear()
        Me.stbVisitNo.Clear()
        Me.stbAmountWords.Clear()

        ResetControlsIn(Me.tpgLaboratory)
        ResetControlsIn(Me.tpgRadiology)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgDental)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgOptical)
        ResetControlsIn(Me.tpgMaternity)
        ResetControlsIn(Me.tpgICU)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgExtraCharge)

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            'Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextQuotationNo()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        Me.ShowPatientDetails(visitNo)

    End Sub

#Region " Prescription - grid "

    Private Sub LoadDrugs()

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

    Private Sub DetailDrug(ByVal selectedRow As Integer)

        'Dim selectedItem As String = String.Empty

        'Try

        '    If Me.dgvPrescription.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

        '    Dim drugNo As String = SubstringRight(selectedItem)
        '    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

        '    If String.IsNullOrEmpty(drugNo) Then Return

        '    Dim quantity As Integer = 1
        '    Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)

        '    With Me.dgvPrescription
        '        .Item(Me.colDrugQuantity.Name, selectedRow).Value = quantity
        '        .Item(Me.colDrugUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
        '    End With

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Catch ex As Exception
        '    Throw ex

        'End Try




        Dim drugSelected As String = String.Empty
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim quantity As Integer = 1

        Try

            If Me.dgvPrescription.Rows.Count > 1 Then drugSelected = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            Dim drugNo As String = SubstringRight(drugSelected)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
 
            With Me.dgvPrescription
                .Item(Me.colDrugQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colPrescriptionUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colDrugUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            End With
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit
        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)
    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug (" + _PrescriptionDrugValue + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrug)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Drug (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailDrug(selectedRow)
            Me.CalculateDrugAmount(selectedRow)
            Me.CalculateBillForPrescriptions()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CalculateBillForPrescriptions()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colDrugAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateDrugAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugUnitPrice)

        Me.dgvPrescription.Item(Me.colDrugAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit
        Try

            If Me.colDrug.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDrug.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDrugUnitPrice.Index) Then
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub dgvPrescription_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPrescription.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvPrescription_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvPrescription.UserDeletedRow
        Me.CalculateBillForPrescriptions()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvPrescription_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvPrescription.Item(Me.colDrug.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            'totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                .ItemCategoryID = oItemCategoryID.Drug
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Radiology Examinations - grid "

    Private Sub CalculateRadiologyAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colRadiologyQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colRadiologyUnitPrice)

        Me.dgvRadiology.Item(Me.colRadiologyAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForRadiology()

        Dim totalBill As Decimal

        ' ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colRadiologyAmount)
            totalBill += amount
        Next

        ' Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadRadiologyExaminations()

        Dim oRadiologyExaminations As New SyncSoft.SQLDb.RadiologyExaminations()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from RadiologyExaminations
            If Not InitOptions.LoadRadiologyExaminationsAtStart Then
                radiologyExaminations = oRadiologyExaminations.GetRadiologyExaminations().Tables("RadiologyExaminations")
                oSetupData.RadiologyExaminations = radiologyExaminations
            Else : radiologyExaminations = oSetupData.RadiologyExaminations
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExamFullName, radiologyExaminations, "ExamFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub DetailRadiology(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvRadiology.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)

            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(examCode) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Radiology, billNo, billModesID, associatedBillNo)

            With Me.dgvRadiology
                .Item(Me.colRadiologyQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colRadiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colRadiologyUnitMeasure.Name, selectedRow).Value = "NA"
                '.Item(Me.colRadiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                '.Item(Me.colRadiologyEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetRadiologyExaminationsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)

            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Examination (" + _ExamNameValue + ") can't be edited!")
                Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Value = _ExamNameValue
                Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(rowNo).Cells, Me.colExamFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Examination (" + enteredItem + ") already selected!")
                        Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Value = _ExamNameValue
                        Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailRadiology(selectedRow)
            Me.CalculateRadiologyAmount(selectedRow)
            Me.CalculateBillForRadiology()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''          

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvRadiology_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRadiology.CellBeginEdit
        If e.ColumnIndex <> Me.colExamFullName.Index OrElse Me.dgvRadiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex
        _ExamNameValue = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)
    End Sub

    Private Sub dgvRadiology_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRadiology.CellEndEdit

        Try

            If Me.colExamFullName.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colExamFullName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvRadiology.Rows.Count > 1 Then Me.SetRadiologyExaminationsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colRadiologyQuantity.Index) Then
                Me.CalculateRadiologyAmount(selectedRow)
                Me.CalculateBillForRadiology()

            ElseIf e.ColumnIndex.Equals(Me.colRadiologyUnitPrice.Index) Then
                Me.CalculateRadiologyAmount(selectedRow)
                Me.CalculateBillForRadiology()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub dgvRadiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRadiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvRadiology_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvRadiology.UserDeletedRow
        Me.CalculateBillForRadiology()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvRadiology_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvRadiology.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvRadiology.Item(Me.colExamFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '  Dim totalQuotationBill As Decimal = 0
            'totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                .ItemCategoryID = oItemCategoryID.Radiology
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

#Region " Laboratory - grid "

    Private Sub LoadLabTests()

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from LabTests
            If Not InitOptions.LoadLabTestsAtStart Then
                labTests = oLabTests.GetLabTests().Tables("LabTests")
                oSetupData.LabTests = labTests
            Else : labTests = oSetupData.LabTests
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colTest, labTests, "TestFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetLabTestsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTest)

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowNo).Cells, Me.colTest)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Test (" + enteredItem + ") already selected!")
                        Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Value = _TestValue
                        Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailLaboratory(selectedRow)
            Me.CalculateLaboratoryAmount(selectedRow)
            Me.CalculateBillForLaboratory()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailLaboratory(ByVal selectedRow As Integer)

        'Dim selectedItem As String = String.Empty

        'Try

        '    If Me.dgvLabTests.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTest)

        '    Dim testCode As String = SubstringRight(selectedItem)
        '    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

        '    If String.IsNullOrEmpty(testCode) Then Return

        '    Dim quantity As Integer = 1
        '    Dim unitPrice As Decimal = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)
        '    Dim unitmeasure As String

        '    With Me.dgvLabTests
        '        .Item(Me.colLTQuantity.Name, selectedRow).Value = quantity
        '        .Item(Me.colLTUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
        '        .Item(Me.colLaboratoryUnitMeasure.Name, selectedRow).Value = unitmeasure
        '        ' .Item(Me.colLaboratoryUnitMeasure.Name, selectedRow).Value = StringEnteredIn(selectedRow, "UnitMeasure")
        '    End With

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Catch ex As Exception
        '    Throw ex

        'End Try

        Dim labTestSelected As String = String.Empty
        Dim oLabTest As New SyncSoft.SQLDb.LabTests()
        Dim quantity As Integer = 1

        Try

            If Me.dgvLabTests.Rows.Count > 1 Then labTestSelected = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTest)

            Dim testNo As String = SubstringRight(labTestSelected)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim tests As DataTable = oLabTest.GetLabTests(testNo).Tables("LabTests")
            If tests Is Nothing OrElse String.IsNullOrEmpty(testNo) Then Return
            Dim row As DataRow = tests.Rows(0)

            Dim unitPrice As Decimal = GetCustomFee(testNo, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)

            With Me.dgvLabTests
                .Item(Me.colLTQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colLaboratoryUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colLTUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            End With
        Catch ex As Exception
            Throw ex

        End Try


    End Sub

    Private Sub CalculateLaboratoryAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colLTQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colLTUnitPrice)

        Me.dgvLabTests.Item(Me.colLTAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForLaboratory()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colLTAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub dgvLabTests_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabTests.CellBeginEdit
        If e.ColumnIndex <> Me.colTest.Index OrElse Me.dgvLabTests.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
        _TestValue = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTest)
    End Sub

    Private Sub dgvLabTests_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellEndEdit
        Try

            If Me.colTest.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colTest.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvLabTests.Rows.Count > 1 Then Me.SetLabTestsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colLTQuantity.Index) Then
                Me.CalculateLaboratoryAmount(selectedRow)
                Me.CalculateBillForLaboratory()

            ElseIf e.ColumnIndex.Equals(Me.colLTUnitPrice.Index) Then
                Me.CalculateLaboratoryAmount(selectedRow)
                Me.CalculateBillForLaboratory()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvLabTests_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvLabTests.UserDeletedRow
        Me.CalculateBillForLaboratory()
        ''Update quotations after deleting an entry from datagrid
        Me.UpdateQuotationAmount()

    End Sub

    Private Sub dgvLabTests_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTests.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvLabTests.Item(Me.colTest.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colTest))
                .ItemCategoryID = oItemCategoryID.Test
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

#Region " Procedures - Grid "

    Private Sub LoadProcedures()

        Dim oProcedures As New SyncSoft.SQLDb.Procedures()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Procedures
            If Not InitOptions.LoadProceduresAtStart Then
                procedures = oProcedures.GetProcedures().Tables("Procedures")
                oSetupData.Procedures = procedures
            Else : procedures = oSetupData.Procedures
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvProcedures_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvProcedures.CellBeginEdit

        If e.ColumnIndex <> Me.colProcedureCode.Index OrElse Me.dgvProcedures.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex
        _ProcedureNameValue = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

    End Sub

    Private Sub dgvProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcedures.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colProcedureCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvProcedures.Rows.Count > 1 Then Me.SetProceduresEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colProcedureQuantity.Index) Then
                Me.CalculateProceduresAmount(selectedRow)
                Me.CalculateBillForProcedures()

            ElseIf e.ColumnIndex.Equals(Me.colProcedureUnitPrice.Index) Then
                Me.CalculateProceduresAmount(selectedRow)
                Me.CalculateBillForProcedures()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetProceduresEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                Dim procedureDisplay As String = (From data In _Procedures
                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(_ProcedureNameValue.ToUpper())
                                    Select data.Field(Of String)("ProcedureName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Procedure (" + procedureDisplay + ") can't be edited!")
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(rowNo).Cells, Me.colProcedureCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _Procedures
                                            Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("ProcedureName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Procedure (" + enteredDisplay + ") already entered!")
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailProcedures(selectedRow)
            Me.CalculateProceduresAmount(selectedRow)
            Me.CalculateBillForProcedures()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvProcedures.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            'totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colProcedureCode))
                .ItemCategoryID = oItemCategoryID.Procedure
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub dgvProcedures_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvProcedures.UserDeletedRow
        Me.CalculateBillForProcedures()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvProcedures_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProcedures.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailProcedures(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvProcedures.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Procedure, billNo, billModesID, associatedBillNo)

            With Me.dgvProcedures
                .Item(Me.colProcedureQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colProcedureUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colProcedureUnitMeasure.Name, selectedRow).Value = "NA"
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForProcedures()

        Dim totalBill As Decimal

        ' ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colProcedureAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateProceduresAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureUnitPrice)

        Me.dgvProcedures.Item(Me.colProcedureAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadProcedures(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Procedure).Tables("ExtraBillItems")

            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvProcedures, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                Me.dgvProcedures.Item(Me.colProceduresSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Dental - Grid "

    Private Sub LoadDentalServices()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from DentalServices
            If Not InitOptions.LoadDentalServicesAtStart Then
                dentalServices = oDentalServices.GetDentalServices().Tables("DentalServices")
                oSetupData.DentalServices = dentalServices
            Else : dentalServices = oSetupData.DentalServices
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalCode.Sorted = False
            LoadComboData(Me.colDentalCode, dentalServices, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDental_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDental.CellBeginEdit

        If e.ColumnIndex <> Me.colDentalCode.Index OrElse Me.dgvDental.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDental.CurrentCell.RowIndex
        _DentalNameValue = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

    End Sub

    Private Sub dgvDental_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDental.CellEndEdit

        Try

            If Me.colDentalCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvDental.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDentalCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvDental.Rows.Count > 1 Then Me.SetDentalServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDentalQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalAmount(selectedRow)
                Me.CalculateBillForDental()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colDentalUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalAmount(selectedRow)
                Me.CalculateBillForDental()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDentalServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                Dim dentalDisplay As String = (From data In _DentalServices
                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(_DentalNameValue.ToUpper())
                                    Select data.Field(Of String)("DentalName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Dental (" + dentalDisplay + ") can't be edited!")
                Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalNameValue
                Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDental.Rows(rowNo).Cells, Me.colDentalCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _DentalServices
                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DentalName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Dental (" + enteredDisplay + ") already selected!")
                        Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalNameValue
                        Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailDental(selectedRow)
            Me.CalculateDentalAmount(selectedRow)
            Me.CalculateBillForDental()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDental_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDental.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvDental.Item(Me.colDentalCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            '        totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDentalCode))
                .ItemCategoryID = oItemCategoryID.Dental
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************


        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub dgvDental_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvDental.UserDeletedRow
        Me.CalculateBillForDental()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvDental_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDental.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailDental(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvDental.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Dental, billNo, billModesID, associatedBillNo)

            With Me.dgvDental
                .Item(Me.colDentalQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colDentalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colDentalUnitMeasure.Name, selectedRow).Value = "NA"
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForDental()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvDental.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colDentalAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateDentalAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalUnitPrice)

        Me.dgvDental.Item(Me.colDentalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadDental(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvDental.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Dental).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDental, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDental.Item(Me.colDentalSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvLabTests_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

#End Region

#Region " Theatre - Grid "

    Private Sub LoadTheatreServices()

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TheatreServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTheatreCode.Sorted = False
            LoadComboData(Me.colTheatreCode, theatreServices, "TheatreCode", "TheatreName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTheatre_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTheatre.CellBeginEdit

        If e.ColumnIndex <> Me.colTheatreCode.Index OrElse Me.dgvTheatre.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
        _TheatreNameValue = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

    End Sub

    Private Sub dgvTheatre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellEndEdit

        Try

            If Me.colTheatreCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colTheatreCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvTheatre.Rows.Count > 1 Then Me.SetTheatreEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colTheatreQuantity.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colTheatreUnitPrice.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetTheatreEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                Dim TheatreDisplay As String = (From data In _TheatreServices
                                    Where data.Field(Of String)("TheatreCode").ToUpper().Equals(_TheatreNameValue.ToUpper())
                                    Select data.Field(Of String)("TheatreName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre (" + TheatreDisplay + ") can't be edited!")
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colTheatreCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _TheatreServices
                                            Where data.Field(Of String)("TheatreCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("TheatreName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Theatre (" + enteredDisplay + ") already selected!")
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailTheatre(selectedRow)
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvTheatre.Item(Me.colTheatreCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            '        totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colTheatreCode))
                .ItemCategoryID = oItemCategoryID.Theatre
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************


        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserDeletedRow
        Me.CalculateBillForTheatre()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvTheatre_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTheatre.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailTheatre(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvTheatre.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)

            With Me.dgvTheatre
                .Item(Me.colTheatreQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colTheatreUnitMeasure.Name, selectedRow).Value = "NA"
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForTheatre()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colTheatreAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateTheatreAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreUnitPrice)

        Me.dgvTheatre.Item(Me.colTheatreAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadTheatre(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Theatre).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTheatre, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Optical - Grid "

    Private Sub LoadOpticalServices()

        Dim oOpticalServices As New SyncSoft.SQLDb.OpticalServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from OpticalServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            opticalServices = oOpticalServices.GetOpticalServices().Tables("OpticalServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colOpticalCode.Sorted = False
            LoadComboData(Me.colOpticalCode, opticalServices, "OpticalCode", "OpticalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOptical_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvOptical.CellBeginEdit

        If e.ColumnIndex <> Me.colOpticalCode.Index OrElse Me.dgvOptical.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvOptical.CurrentCell.RowIndex
        _OpticalNameValue = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

    End Sub

    Private Sub dgvOptical_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOptical.CellEndEdit

        Try

            If Me.colOpticalCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvOptical.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colOpticalCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvOptical.Rows.Count > 1 Then Me.SetOpticalServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colOpticalQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateOpticalAmount(selectedRow)
                Me.CalculateBillForOptical()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colOpticalUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateOpticalAmount(selectedRow)
                Me.CalculateBillForOptical()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetOpticalServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

            If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                Dim OpticalDisplay As String = (From data In _OpticalServices
                                    Where data.Field(Of String)("OpticalCode").ToUpper().Equals(_OpticalNameValue.ToUpper())
                                    Select data.Field(Of String)("OpticalName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Optical (" + OpticalDisplay + ") can't be edited!")
                Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalNameValue
                Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvOptical.Rows(rowNo).Cells, Me.colOpticalCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _OpticalServices
                                            Where data.Field(Of String)("OpticalCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("OpticalName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Optical (" + enteredDisplay + ") already selected!")
                        Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalNameValue
                        Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailOptical(selectedRow)
            Me.CalculateOpticalAmount(selectedRow)
            Me.CalculateBillForOptical()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvOptical_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvOptical.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvOptical.Item(Me.colOpticalCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colOpticalCode))
                .ItemCategoryID = oItemCategoryID.Optical
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************


        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub dgvOptical_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvOptical.UserDeletedRow
        Me.CalculateBillForOptical()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvOptical_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvOptical.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailOptical(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvOptical.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Optical, billNo, billModesID, associatedBillNo)

            With Me.dgvOptical
                .Item(Me.colOpticalQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colOpticalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colOpticalUnitMeasure.Name, selectedRow).Value = "NA"
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForOptical()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colOpticalAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateOpticalAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalUnitPrice)

        Me.dgvOptical.Item(Me.colOpticalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadOptical(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvOptical.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Optical).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOptical, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvOptical.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOptical.Item(Me.colOpticalSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Maternity - Grid "

    Private Sub LoadMaternityServices()

        Dim oMaternityServices As New SyncSoft.SQLDb.MaternityServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from MaternityServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            maternityServices = oMaternityServices.GetMaternityServices().Tables("MaternityServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colMaternityCode.Sorted = False
            LoadComboData(Me.colMaternityCode, maternityServices, "MaternityCode", "MaternityName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvMaternity_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvMaternity.CellBeginEdit

        If e.ColumnIndex <> Me.colMaternityCode.Index OrElse Me.dgvMaternity.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvMaternity.CurrentCell.RowIndex
        _MaternityNameValue = StringMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityCode)

    End Sub

    Private Sub dgvMaternity_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMaternity.CellEndEdit

        Try

            '  If Me.colMaternityCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvMaternity.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colMaternityCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvMaternity.Rows.Count > 1 Then Me.SetMaternityServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colMaternityQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateMaternityAmount(selectedRow)
                Me.CalculateBillForMaternity()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colMaternityUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateMaternityAmount(selectedRow)
                Me.CalculateBillForMaternity()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetMaternityServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityCode)

            If CBool(Me.dgvMaternity.Item(Me.colMaternitySaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _MaternityServices As EnumerableRowCollection(Of DataRow) = maternityServices.AsEnumerable()
                Dim MaternityDisplay As String = (From data In _MaternityServices
                                    Where data.Field(Of String)("MaternityCode").ToUpper().Equals(_MaternityNameValue.ToUpper())
                                    Select data.Field(Of String)("MaternityName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Maternity (" + MaternityDisplay + ") can't be edited!")
                Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Value = _MaternityNameValue
                Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvMaternity.Rows(rowNo).Cells, Me.colMaternityCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _MaternityServices As EnumerableRowCollection(Of DataRow) = maternityServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _MaternityServices
                                            Where data.Field(Of String)("MaternityCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("MaternityName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Maternity (" + enteredDisplay + ") already selected!")
                        Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Value = _MaternityNameValue
                        Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailMaternity(selectedRow)
            Me.CalculateMaternityAmount(selectedRow)
            Me.CalculateBillForMaternity()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvMaternity_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvMaternity.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvMaternity.Item(Me.colMaternitySaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvMaternity.Item(Me.colMaternityCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            '        totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colTest))
                .ItemCategoryID = oItemCategoryID.Maternity
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub dgvMaternity_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvMaternity.UserDeletedRow
        Me.CalculateBillForMaternity()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvMaternity_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvMaternity.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailMaternity(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvMaternity.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Maternity, billNo, billModesID, associatedBillNo)

            With Me.dgvMaternity
                .Item(Me.colMaternityQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colMaternityUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colMaternityUnitMeasure.Name, selectedRow).Value = "NA"
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForMaternity()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colMaternityAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateMaternityAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityUnitPrice)

        Me.dgvMaternity.Item(Me.colMaternityAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadMaternity(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvMaternity.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Maternity).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvMaternity, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvMaternity.Rows
                If row.IsNewRow Then Exit For
                Me.dgvMaternity.Item(Me.colMaternitySaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " ICU - Grid "

    Private Sub LoadICUServices()

        Dim oICUServices As New SyncSoft.SQLDb.ICUServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ICUServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iCUServices = oICUServices.GetICUServices().Tables("ICUServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colICUCode.Sorted = False
            LoadComboData(Me.colICUCode, iCUServices, "ICUCode", "ICUName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvICU_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvICU.CellBeginEdit

        If e.ColumnIndex <> Me.colICUCode.Index OrElse Me.dgvICU.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvICU.CurrentCell.RowIndex
        _ICUNameValue = StringMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUCode)

    End Sub

    Private Sub dgvICU_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvICU.CellEndEdit

        Try

            If Me.colICUCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvICU.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colICUCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvICU.Rows.Count > 1 Then Me.SetICUServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colICUQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateICUAmount(selectedRow)
                Me.CalculateBillForICU()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colICUUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateICUAmount(selectedRow)
                Me.CalculateBillForICU()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetICUServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUCode)

            If CBool(Me.dgvICU.Item(Me.colICUSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _ICUServices As EnumerableRowCollection(Of DataRow) = iCUServices.AsEnumerable()
                Dim ICUDisplay As String = (From data In _ICUServices
                                    Where data.Field(Of String)("ICUCode").ToUpper().Equals(_ICUNameValue.ToUpper())
                                    Select data.Field(Of String)("ICUName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("ICU (" + ICUDisplay + ") can't be edited!")
                Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Value = _ICUNameValue
                Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvICU.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvICU.Rows(rowNo).Cells, Me.colICUCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _ICUServices As EnumerableRowCollection(Of DataRow) = iCUServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _ICUServices
                                            Where data.Field(Of String)("ICUCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("ICUName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("ICU (" + enteredDisplay + ") already selected!")
                        Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Value = _ICUNameValue
                        Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailICU(selectedRow)
            Me.CalculateICUAmount(selectedRow)
            Me.CalculateBillForICU()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvICU_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvICU.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvICU.Item(Me.colICUSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvICU.Item(Me.colICUCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            '        totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colICUCode))
                .ItemCategoryID = oItemCategoryID.ICU
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************


        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub dgvICU_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvICU.UserDeletedRow
        Me.CalculateBillForICU()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvICU_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvICU.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailICU(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvICU.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.ICU, billNo, billModesID, associatedBillNo)

            With Me.dgvICU
                .Item(Me.colICUQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colICUUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colICUUnitMeasure.Name, selectedRow).Value = "NA"
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForICU()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvICU.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colICUAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateICUAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUUnitPrice)

        Me.dgvICU.Item(Me.colICUAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadICU(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvICU.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.ICU).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvICU, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvICU.Rows
                If row.IsNewRow Then Exit For
                Me.dgvICU.Item(Me.colICUSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "

    Private Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumableItems
            Else : consumableItems = oSetupData.ConsumableItems
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colConsumableName, consumableItems, "ConsumableFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.colConsumableName.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _ConsumableItemValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try

            If Me.colConsumableName.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colConsumableName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colConsumableQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateConsumablesAmount(selectedRow)
                Me.CalculateBillForConsumables()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colConsumableUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateConsumablesAmount(selectedRow)
                Me.CalculateBillForConsumables()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetConsumableEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Consumable Item Name (" + _ConsumableItemValue + ") can't be edited!")
                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _ConsumableItemValue
                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.colConsumableName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Consumable Item Name (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _ConsumableItemValue
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DetailConsumableItem(selectedRow)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesAmount(selectedRow)
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            '        totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                .ItemCategoryID = oItemCategoryID.Consumable
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************


        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvConsumables.UserDeletedRow
        Me.CalculateBillForConsumables()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvConsumables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvConsumables.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailConsumableItem(ByVal selectedRow As Integer)

        'Dim selectedItem As String = String.Empty
        'Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        'Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        'Try

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    If Me.dgvConsumables.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    Dim consumableNo As String = SubstringRight(selectedItem)
        '    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
        '    Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
        '    If consumableItems Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
        '    Dim row As DataRow = consumableItems.Rows(0)

        '    Dim quantity As Integer = 1
        '    Dim unitPrice As Decimal = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    With Me.dgvConsumables
        '        .Item(Me.colConsumableQuantity.Name, selectedRow).Value = quantity
        '        .Item(Me.colConsumableUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)

        '    End With

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Catch ex As Exception
        '    Throw ex

        'End Try


        Dim ConsumableSelected As String = String.Empty
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim quantity As Integer = 1

        Try

            If Me.dgvConsumables.Rows.Count > 1 Then ConsumableSelected = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

            Dim consumableNo As String = SubstringRight(ConsumableSelected)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim consumables As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
            If consumables Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = consumables.Rows(0)

            Dim unitPrice As Decimal = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)

            With Me.dgvConsumables
                .Item(Me.colConsumableQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colConsumableUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colConsumableUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            End With
        Catch ex As Exception
            Throw ex

        End Try



    End Sub

    Private Sub CalculateConsumablesAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableUnitPrice)

        Me.dgvConsumables.Item(Me.colConsumableAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForConsumables()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colConsumableAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadConsumables(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            Dim consumableBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Consumable).Tables("ExtraBillItems")
            If consumableBillItems Is Nothing OrElse consumableBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, consumableBillItems)

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " ExtraCharge - Grid "

    Private Sub LoadExtraChargeItems()

        Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ExtraChargeItems
            extraChargeItems = oExtraChargeItems.GetExtraChargeItems().Tables("ExtraChargeItems")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExtraItemFullName, extraChargeItems, "ExtraItemFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvExtraCharge_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvExtraCharge.CellBeginEdit

        If e.ColumnIndex <> Me.colExtraItemFullName.Index OrElse Me.dgvExtraCharge.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex
        _ExtraItemValue = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraItemFullName)

    End Sub

    Private Sub dgvExtraCharge_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExtraCharge.CellEndEdit

        Try

            If Me.colExtraItemFullName.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colExtraItemFullName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvExtraCharge.Rows.Count > 1 Then Me.SetExtraChargeEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateExtraChargeAmount(selectedRow)
                Me.CalculateBillForExtraCharge()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateExtraChargeAmount(selectedRow)
                Me.CalculateBillForExtraCharge()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetExtraChargeEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraItemFullName)

            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Extra Item Name (" + _ExtraItemValue + ") can't be edited!")
                Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Value = _ExtraItemValue
                Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(rowNo).Cells, Me.colExtraItemFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Extra Item Name (" + enteredItem + ") already selected!")
                        Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Value = _ExtraItemValue
                        Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailExtraCharge(selectedRow)
            Me.CalculateExtraChargeAmount(selectedRow)
            Me.CalculateBillForExtraCharge()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvExtraCharge_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvExtraCharge.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index


            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, toDeleteRowNo).Value) = False Then Return

            'Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalQuotationBill As Decimal = 0
            '        totalQuotationBill = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)

            Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(toDeleteRowNo).Cells
            With oQuotationDetails
                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExtraItemFullName))
                .ItemCategoryID = oItemCategoryID.Extras
            End With
            DisplayMessage(oQuotationDetails.Delete())
            '****************************************


        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub dgvExtraCharge_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvExtraCharge.UserDeletedRow
        Me.CalculateBillForExtraCharge()
        'Update quotations after deleting an entry from datagrid
        UpdateQuotationAmount()
    End Sub

    Private Sub dgvExtraCharge_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvExtraCharge.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailExtraCharge(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvExtraCharge.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraItemFullName)

            Dim extraItemCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(extraItemCode) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(extraItemCode, oItemCategoryID.Extras, billNo, billModesID, associatedBillNo)

            With Me.dgvExtraCharge
                .Item(Me.colExtraChargeQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colExtraChargeUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colExtraUnitMeasure.Name, selectedRow).Value = "NA"
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForExtraCharge()

        Dim totalBill As Decimal

        'ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colExtraChargeAmount)
            totalBill += amount
        Next

        'Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateExtraChargeAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeUnitPrice)

        Me.dgvExtraCharge.Item(Me.colExtraChargeAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadExtraCharge(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvExtraCharge.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Extras).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExtraCharge, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Save methods "

    Private Sub SaveLaboratory()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvLabTests.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Lab Test!")

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTest, "test!")
                DecimalEnteredIn(row.Cells, Me.colLTUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colTest))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colLTUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colTest))
                            .Quantity = IntegerEnteredIn(cells, Me.colLTQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colLTUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colLTAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colTest))
                            .UnitMeasure = StringEnteredIn(cells, Me.colLaboratoryUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Test
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveRadiology()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvRadiology.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Radiology!")

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExamFullName, "Radiology Examination!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                            .Quantity = IntegerEnteredIn(cells, Me.colRadiologyQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colRadiologyAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colExamFullName))
                            .UnitMeasure = StringEnteredIn(cells, Me.colRadiologyUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Radiology
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SavePrescriptions()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvPrescription.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Drugs!")

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDrug, "Drug!")
                DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                            .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colDrugAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colDrug))
                            .UnitMeasure = StringEnteredIn(cells, Me.colPrescriptionUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Drug
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveProcedures()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvProcedures.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Procedures!")

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colProcedureCode, "Procedures!")
                DecimalEnteredIn(row.Cells, Me.colProcedureUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colProcedureCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colProcedureCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colProcedureQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colProcedureAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colProcedureCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colProcedureUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Procedure
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveTheatre()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvTheatre.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Theatre!")

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreCode, "Theatre!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colTheatreCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colTheatreCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colTheatreQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colTheatreAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colTheatreCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colTheatreUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Theatre
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveDental()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvDental.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Dental!")

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalCode, "Dental!")
                DecimalEnteredIn(row.Cells, Me.colDentalUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colDentalCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDentalCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colDentalQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colDentalAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colDentalCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colDentalUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Dental
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveOptical()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvOptical.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Optical!")

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colOpticalCode, "Optical!")
                DecimalEnteredIn(row.Cells, Me.colOpticalUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colOpticalCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colOpticalUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colOpticalCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colOpticalQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colOpticalUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colOpticalAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colOpticalCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colOpticalUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Optical
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.dgvOptical.Item(Me.colOpticalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveMaternity()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvMaternity.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Maternity!")

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colMaternityCode, "Maternity!")
                DecimalEnteredIn(row.Cells, Me.colMaternityUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colMaternityCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colMaternityUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colMaternityCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colMaternityQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colMaternityUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colMaternityAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colMaternityCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colMaternityUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Maternity
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.dgvMaternity.Item(Me.colMaternitySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveICU()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvICU.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for ICU!")

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colICUCode, "ICU!")
                DecimalEnteredIn(row.Cells, Me.colICUUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvICU.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colICUCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colICUUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colICUCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colICUQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colICUUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colICUAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colICUCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colICUUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.ICU
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvICU.Item(Me.colICUSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveConsumables()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvConsumables.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Consumables!")

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Items!")
                DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                            .Quantity = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colConsumableAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colConsumableName))
                            .UnitMeasure = StringEnteredIn(cells, Me.colConsumableUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Consumable
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveExtraCharge()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            '  If Me.dgvExtraCharge.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Other Items!")

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExtraItemFullName, "Other Items!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExtraItemFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExtraItemFullName))
                            .Quantity = IntegerEnteredIn(cells, Me.colExtraChargeQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colExtraChargeAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colExtraItemFullName))
                            .UnitMeasure = StringEnteredIn(cells, Me.colExtraItemFullName)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Extras
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

#Region " Update Methods "

    'procedure below is used to update the quotations table after deleting an entry from the datagrid
    Private Sub UpdateQuotationAmount()
        Try
            Dim oQuotations As New SyncSoft.SQLDb.Quotations()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            Dim totalQuotationBill As Decimal = CalculateGridBill(Me.dgvLabTests, Me.colLTAmount.Name) + CalculateGridBill(Me.dgvRadiology, Me.colRadiologyAmount.Name) + CalculateGridBill(Me.dgvPrescription, Me.colDrugAmount.Name) + CalculateGridBill(Me.dgvProcedures, Me.colProcedureAmount.Name) + CalculateGridBill(Me.dgvDental, Me.colDentalAmount.Name) + CalculateGridBill(Me.dgvTheatre, Me.colTheatreAmount.Name) + CalculateGridBill(Me.dgvOptical, Me.colOpticalAmount.Name) + CalculateGridBill(Me.dgvMaternity, Me.colMaternityAmount.Name) + CalculateGridBill(Me.dgvICU, Me.colICUAmount.Name) + CalculateGridBill(Me.dgvConsumables, Me.colConsumableAmount.Name) + CalculateGridBill(Me.dgvExtraCharge, Me.colExtraChargeAmount.Name)
            Me.Cursor = Cursors.WaitCursor()

            With oQuotations

                .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                .QuotationDate = DateEnteredIn(Me.dtpQuotationDate, "Quotation Date!")
                .AmountWords = NumberToWords(totalQuotationBill)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            'DisplayMessage(oQuotations.Update())
            oQuotations.Update()

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub UpdateLaboratory()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvLabTests.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Lab Test!")

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTest, "test!")
                DecimalEnteredIn(row.Cells, Me.colLTUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colTest))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colLTUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colTest))
                            .Quantity = IntegerEnteredIn(cells, Me.colLTQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colLTUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colLTAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colTest))
                            .UnitMeasure = StringEnteredIn(cells, Me.colLaboratoryUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Test
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateRadiology()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvRadiology.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Radiology!")

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExamFullName, "Radiology Examination!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                            .Quantity = IntegerEnteredIn(cells, Me.colRadiologyQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colRadiologyAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colExamFullName))
                            .UnitMeasure = StringEnteredIn(cells, Me.colRadiologyUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Radiology
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdatePrescriptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvPrescription.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Drugs!")

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDrug, "Drug!")
                DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                            .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colDrugAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colDrug))
                            .UnitMeasure = StringEnteredIn(cells, Me.colPrescriptionUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Drug
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateProcedures()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvProcedures.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Procedure!")

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colProcedureCode, "Procedure!")
                DecimalEnteredIn(row.Cells, Me.colProcedureUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colProcedureCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colProcedureCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colProcedureQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colProcedureAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colProcedureCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colProcedureUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Procedure
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateTheatre()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            '  If Me.dgvTheatre.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Theatre!")

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreCode, "Theatre!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colTheatreCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colTheatreCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colTheatreQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colTheatreAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colTheatreCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colTheatreUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Theatre
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateDental()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            '  If Me.dgvDental.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Dental!")

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalCode, "Dental!")
                DecimalEnteredIn(row.Cells, Me.colDentalUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colDentalCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDentalCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colDentalQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colDentalAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colDentalCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colDentalUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Dental
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateConsumables()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvConsumables.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Consumables!")

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable!")
                DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                            .Quantity = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colConsumableAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colConsumableName))
                            .UnitMeasure = StringEnteredIn(cells, Me.colConsumableUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Consumable
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateOptical()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvOptical.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Optical!")

            For Each row As DataGridViewRow In Me.dgvOptical.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colOpticalCode, "Optical!")
                DecimalEnteredIn(row.Cells, Me.colOpticalUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1


            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colOpticalCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colOpticalUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colOpticalCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colOpticalQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colOpticalUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colOpticalAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colOpticalCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colOpticalUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Optical
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOptical.Item(Me.colOpticalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateICU()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvICU.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for ICU!")

            For Each row As DataGridViewRow In Me.dgvICU.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colICUCode, "ICU!")
                DecimalEnteredIn(row.Cells, Me.colICUUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvICU.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colICUCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colICUUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colICUCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colICUQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colICUUnitPrice, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colICUCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colICUUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .Amount = DecimalEnteredIn(cells, Me.colICUAmount, False)
                            .ItemCategoryID = oItemCategoryID.ICU
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvICU.Item(Me.colICUSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateExtraCharge()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ' If Me.dgvExtraCharge.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Other Items!")

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExtraItemFullName, "Other Items!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExtraItemFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExtraItemFullName))
                            .Quantity = IntegerEnteredIn(cells, Me.colExtraChargeQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colExtraChargeAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colExtraItemFullName))
                            .UnitMeasure = StringEnteredIn(cells, Me.colExtraUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Extras
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateMaternity()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            'If Me.dgvMaternity.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Maternity!")

            For Each row As DataGridViewRow In Me.dgvMaternity.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colMaternityCode, "Maternity!")
                DecimalEnteredIn(row.Cells, Me.colMaternityUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1

            For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                'Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colMaternityCode))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colMaternityUnitPrice, False)
                'Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oQuotationDetails As New SyncSoft.SQLDb.QuotationDetails()
                        With oQuotationDetails
                            .QuotationNo = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colMaternityCode))
                            .Quantity = IntegerEnteredIn(cells, Me.colMaternityQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colMaternityUnitPrice, False)
                            .Amount = DecimalEnteredIn(cells, Me.colMaternityAmount, False)
                            .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colMaternityCode))
                            .UnitMeasure = StringEnteredIn(cells, Me.colMaternityUnitMeasure)
                            .LoginID = CurrentUser.LoginID
                            .ClientMachine = My.Computer.Name
                            .ItemCategoryID = oItemCategoryID.Maternity
                            oQuotationDetails.Save()
                        End With

                        lItems.Add(oQuotationDetails)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvMaternity.Item(Me.dgvMaternity.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



#End Region

#Region " Load Datagrid methods for edit"

    Private Sub LoadLaboratoryData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvLabTests.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Test).Tables("QuotationDetails")
            If tests Is Nothing OrElse tests.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To tests.Rows.Count - 1

                Dim row As DataRow = tests.Rows(pos)
                With Me.dgvLabTests

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName") + " -> " + StringEnteredIn(row, "ItemCode")
                    .Item(Me.colLTQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colLaboratoryUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colLTUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colLTAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colLabTestsSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadRadiologyData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvRadiology.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim radiologyExams As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Radiology).Tables("QuotationDetails")
            If radiologyExams Is Nothing OrElse radiologyExams.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To radiologyExams.Rows.Count - 1

                Dim row As DataRow = radiologyExams.Rows(pos)
                With Me.dgvRadiology

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colExamFullName.Name, pos).Value = StringEnteredIn(row, "ItemName") + " -> " + StringEnteredIn(row, "ItemCode")
                    .Item(Me.colRadiologyQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colRadiologyUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colRadiologyUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colRadiologyAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colRadiologySaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPrescriptionsData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim drugs As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Drug).Tables("QuotationDetails")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                With Me.dgvPrescription

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemName") + " -> " + StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colDrugAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = True
                End With

            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadProceduresData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim procedures As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Procedure).Tables("QuotationDetails")
            If procedures Is Nothing OrElse procedures.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To procedures.Rows.Count - 1

                Dim row As DataRow = procedures.Rows(pos)
                With Me.dgvProcedures

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colProcedureQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colProcedureUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colProcedureUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colProcedureAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colProceduresSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadTheatreData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim theatre As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Theatre).Tables("QuotationDetails")
            If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatre.Rows.Count - 1

                Dim row As DataRow = theatre.Rows(pos)
                With Me.dgvTheatre

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colTheatreUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colTheatreSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadDentalData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvDental.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim dental As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Dental).Tables("QuotationDetails")
            If dental Is Nothing OrElse dental.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To dental.Rows.Count - 1

                Dim row As DataRow = dental.Rows(pos)
                With Me.dgvDental

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colDentalCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDentalQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colDentalUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDentalUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colDentalAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colDentalSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadOpticalData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvOptical.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim optical As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Optical).Tables("QuotationDetails")
            If optical Is Nothing OrElse optical.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To optical.Rows.Count - 1

                Dim row As DataRow = optical.Rows(pos)
                With Me.dgvOptical

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colOpticalCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colOpticalQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colOpticalUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colOpticalUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colOpticalAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colOpticalSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadExtraChargeData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvExtraCharge.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim extras As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Extras).Tables("QuotationDetails")
            If extras Is Nothing OrElse extras.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To extras.Rows.Count - 1

                Dim row As DataRow = extras.Rows(pos)
                With Me.dgvExtraCharge

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colExtraItemFullName.Name, pos).Value = StringEnteredIn(row, "ItemName") + " -> " + StringEnteredIn(row, "ItemCode")
                    .Item(Me.colExtraChargeQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colExtraUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colExtraChargeUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colExtraChargeAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colExtraChargeSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadConsumablesData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim consumables As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Consumable).Tables("QuotationDetails")
            If consumables Is Nothing OrElse consumables.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To consumables.Rows.Count - 1

                Dim row As DataRow = consumables.Rows(pos)
                With Me.dgvConsumables

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "ItemName") + " -> " + StringEnteredIn(row, "ItemCode")
                    .Item(Me.colConsumableQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colConsumableUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colConsumableAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colConsumablesSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadICUData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvICU.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim ICU As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.ICU).Tables("QuotationDetails")
            If ICU Is Nothing OrElse ICU.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To ICU.Rows.Count - 1

                Dim row As DataRow = ICU.Rows(pos)
                With Me.dgvICU

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colICUCode.Name, pos).Value = StringEnteredIn(row, "ItemName") + " -> " + StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICUQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colICUUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colICUUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colICUAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colICUSaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadMaternityData(ByVal visitNo As String)

        'Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oQuotaionDetails As New SyncSoft.SQLDb.QuotationDetails()
        Dim QuotationNo As String = RevertText(StringEnteredIn(Me.stbQuotationNo, "Quotation No!"))

        Try

            Me.dgvMaternity.Rows.Clear()

            ' Load items not yet paid for

            'Dim tests As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo).Tables("QuotationDetails")
            Dim maternity As DataTable = oQuotaionDetails.GetQuotationDetails(QuotationNo, oItemCategoryID.Maternity).Tables("QuotationDetails")
            If maternity Is Nothing OrElse maternity.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To maternity.Rows.Count - 1

                Dim row As DataRow = maternity.Rows(pos)
                With Me.dgvMaternity

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '.Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colMaternityCode.Name, pos).Value = StringEnteredIn(row, "ItemName") + " -> " + StringEnteredIn(row, "ItemCode")
                    .Item(Me.colMaternityQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colMaternityUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colMaternityUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colMaternityAmount.Name, pos).Value = StringEnteredIn(row, "Amount")
                    .Item(Me.colMaternitySaved.Name, pos).Value = True
                End With
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Verify methods "
    'FUNCTION TO CHECK IF NO DATAGRID HAS AN ITEM SELECTED, RETURNS TRUE IF NONE HAS SELECTED ITEMS
    Private Function IsBlankDataGrids() As Boolean
        Dim isBlank As Boolean = False
        If Me.dgvLabTests.RowCount <= 1 AndAlso Me.dgvRadiology.RowCount <= 1 AndAlso Me.dgvPrescription.RowCount <= 1 AndAlso Me.dgvProcedures.RowCount <= 1 AndAlso Me.dgvDental.RowCount <= 1 AndAlso Me.dgvTheatre.RowCount <= 1 AndAlso Me.dgvOptical.RowCount <= 1 AndAlso Me.dgvMaternity.RowCount <= 1 AndAlso Me.dgvICU.RowCount <= 1 AndAlso Me.dgvConsumables.RowCount <= 1 AndAlso Me.dgvExtraCharge.RowCount <= 1 Then
            isBlank = True
        End If
        Return isBlank
    End Function

    'FUNCTION BELOW CHECKS IF ALL DATAGRIDS HAVE THE CORRECT VALUES, RETURNS TRUE IF YES & FALSE IF NOT
    Private Function IsAllDatagridsVerified() As Boolean

        If VerifyLaboratoryEntries() = VerifyRadiologyEntries() And VerifyProceduresEntries() = VerifyPrescriptionsEntries() And VerifyDentalEntries() = VerifyTheatreEntries() And VerifyOpticalEntries() = VerifyMaternityEntries() And VerifyICUEntries() = VerifyConsumablesEntries() And VerifyExtraChargeEntries() = True Then
            Return True
        Else : Return False
        End If
    End Function

    Private Function VerifyLaboratoryEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTest, "Lab Test!")
                SingleEnteredIn(row.Cells, Me.colLTQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colLaboratoryUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colLTUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colLTAmount, False, "Amount!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgLaboratory.Name)
            VerifyLaboratoryEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyProceduresEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colProcedureCode, "Procedure!")
                SingleEnteredIn(row.Cells, Me.colProcedureQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colProcedureUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colProcedureUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colProcedureAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgProcedures.Name)
            VerifyProceduresEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyPrescriptionsEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDrug, "Drug!")
                SingleEnteredIn(row.Cells, Me.colDrugQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colPrescriptionUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colDrugAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgPrescriptions.Name)
            VerifyPrescriptionsEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyRadiologyEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExamFullName, "Radiology Exam!")
                SingleEnteredIn(row.Cells, Me.colRadiologyQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colRadiologyUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgRadiology.Name)
            VerifyRadiologyEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyDentalEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalCode, "Dental!")
                SingleEnteredIn(row.Cells, Me.colDentalQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colDentalUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colDentalUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colDentalAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgDental.Name)
            VerifyDentalEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyOpticalEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvOptical.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colOpticalCode, "Optical!")
                SingleEnteredIn(row.Cells, Me.colOpticalQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colOpticalUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colOpticalUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colOpticalAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgOptical.Name)
            VerifyOpticalEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyTheatreEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreCode, "Theatre!")
                SingleEnteredIn(row.Cells, Me.colTheatreQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colTheatreUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colTheatreAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgTheatre.Name)
            VerifyTheatreEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyMaternityEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvMaternity.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colMaternityCode, "Maternity!")
                SingleEnteredIn(row.Cells, Me.colMaternityQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colMaternityUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colMaternityUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colMaternityAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgMaternity.Name)
            VerifyMaternityEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyICUEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvICU.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colICUCode, "Maternity!")
                SingleEnteredIn(row.Cells, Me.colICUQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colICUUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colICUUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colICUAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgICU.Name)
            VerifyICUEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyConsumablesEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable!")
                SingleEnteredIn(row.Cells, Me.colConsumableQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colConsumableUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colConsumableAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgConsumables.Name)
            VerifyConsumablesEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyExtraChargeEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExtraItemFullName, "Other Item!")
                SingleEnteredIn(row.Cells, Me.colExtraChargeQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colExtraUnitMeasure, "Unit Measure!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeAmount, False, "Amount!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcQuotations.SelectTab(Me.tpgExtraCharge.Name)
            VerifyExtraChargeEntries = False
            Throw ex

        End Try

    End Function

#End Region

    Private Sub tbcQuotations_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tbcQuotations.Selected

        Select Case Me.tbcQuotations.SelectedTab.Name

            Case Me.tpgLaboratory.Name
                Me.CalculateBillForLaboratory()

            Case Me.tpgRadiology.Name
                Me.CalculateBillForRadiology()

            Case Me.tpgPrescriptions.Name
                Me.CalculateBillForPrescriptions()

            Case Me.tpgProcedures.Name
                Me.CalculateBillForProcedures()

            Case Me.tpgTheatre.Name
                Me.CalculateBillForTheatre()

            Case Me.tpgDental.Name
                Me.CalculateBillForDental()

            Case Me.tpgOptical.Name
                Me.CalculateBillForOptical()

            Case Me.tpgExtraCharge.Name
                Me.CalculateBillForExtraCharge()

            Case Me.tpgConsumables.Name
                Me.CalculateBillForConsumables()

        End Select

    End Sub

#Region " Calculate Total Grid Bill "
    ' Calculates total bill amount for a datagrid
    Private Function CalculateGridBill(ByVal dgv As System.Windows.Forms.DataGridView, ByVal colAmount As String) As Decimal

        Dim totalBill As Decimal = 0

        For rowNo As Integer = 0 To dgv.RowCount - 1
            Dim cells As DataGridViewCellCollection = dgv.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, dgv.Columns(colAmount))
            totalBill += amount
        Next

        Return totalBill
    End Function

#End Region

#Region " Quotation Printing "

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padNotes As Integer = 16
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 13
    Private padAmount As Integer = 14

    Private itemCount As Integer
    Private totalBillQuotation As Decimal

    Private WithEvents docQuotation As New PrintDocument()

    ' The paragraphs.
    Private quotationParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)



    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintQuotation()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub PrintQuotation()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetQuotationPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docQuotation
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docQuotation.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docQuotation_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docQuotation.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Quotation".ToUpper()
            Dim patientName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim quotationNo As String = StringMayBeEnteredIn(Me.stbQuotationNo)
            Dim quotationDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpQuotationDate))
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)

            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)


            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Patient's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Quotation No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(quotationNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Quotation Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(quotationDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    '.DrawString("Attending Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    ' .DrawString(attendingDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
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

                If quotationParagraphs Is Nothing Then Return

                Do While quotationParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(quotationParagraphs(1), PrintParagraps)
                    quotationParagraphs.Remove(1)

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
                        quotationParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (quotationParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetQuotationPrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        totalBillQuotation = 0
        pageNo = 0
        quotationParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            'tableHeader.Append("Notes: ".PadRight(padNotes))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            quotationParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            'quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.AdmissionData()))
            'quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ServicesData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.LaboratoryData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.RadiologyData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrescriptionsData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ProceduresData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DentalData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.TheatreData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OpticalData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.MaternityData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ICUData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ConsumablesData()))
            quotationParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ExtraChargeData()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Quotation Amount: " + GetSpaces(3))
            totalAmount.Append(FormatNumber(totalBillQuotation).PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            quotationParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = NumberToWords(totalBillQuotation)
            amountWordsData.Append("(" + amountWords.Trim() + " ONLY)")
            amountWordsData.Append(ControlChars.NewLine)
            quotationParagraphs.Add(New PrintParagraps(footerFont, amountWordsData.ToString()))

            'Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
            Dim cashAccountBalanceData As New System.Text.StringBuilder(String.Empty)
            cashAccountBalanceData.Append(ControlChars.NewLine)
            'If cashAccountBalance < 0 Then
            '    cashAccountBalanceData.Append("Cash Account Balance (DR): ")
            'Else : cashAccountBalanceData.Append("Cash Account Balance (CR): ")
            'End If
            'cashAccountBalanceData.Append(FormatNumber(cashAccountBalance, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            'cashAccountBalanceData.Append(ControlChars.NewLine)

            'Dim balanceDue As Decimal = totalBillQuotation - cashAccountBalance
            'cashAccountBalanceData.Append("Balance Due: " + GetSpaces(14))
            'cashAccountBalanceData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            'cashAccountBalanceData.Append(ControlChars.NewLine)

            'If Not cashAccountBalance = 0 Then quotationParagraphs.Add(New PrintParagraps(bodyBoldFont, cashAccountBalanceData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:  " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            quotationParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            quotationParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            quotationParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function LaboratoryData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyLaboratoryEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colTest))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colLTQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colLTUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colLTAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colLTEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colLTNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RadiologyData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyRadiologyEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colExamFullName))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colRadiologyQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colRadiologyUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colRadiologyAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colRadiologyEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colRadiologyNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function PrescriptionsData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim oVariousOptions As New VariousOptions()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyPrescriptionsEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.HideBillFormDrugDetails AndAlso Me.dgvPrescription.RowCount > 1 Then

                Dim totalDrugAmount As Decimal = CalculateGridAmount(Me.dgvPrescription, Me.colDrugAmount)

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = "Drug(s) "
                Dim quantity As String = (1).ToString()
                Dim unitPrice As String = FormatNumber(totalDrugAmount, AppData.DecimalPlaces)
                Dim amount As String = FormatNumber(totalDrugAmount, AppData.DecimalPlaces)
                Dim notes As String = String.Empty

                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(itemName.PadRight(padItemName))
                tableData.Append(notes.PadRight(padNotes))
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                totalBillQuotation += totalDrugAmount
            Else

                For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    itemCount += 1

                    Dim itemNo As String = (itemCount).ToString()

                    Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colDrug))
                    Dim quantity As String = StringMayBeEnteredIn(cells, Me.colDrugQuantity)
                    Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colDrugUnitPrice)
                    Dim amount As String = StringMayBeEnteredIn(cells, Me.colDrugAmount)
                    'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colDrugEntryMode)
                    'Dim notes As String = StringMayBeEnteredIn(cells, Me.colDrugNotes)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 19 Then
                        tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    '    If notes.Length > 16 Then
                    '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    '    Else : tableData.Append(notes.PadRight(padNotes))
                    '    End If
                    'Else : tableData.Append(String.Empty.PadRight(padNotes))
                    'End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                    If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

                Next

            End If

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ProceduresData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyProceduresEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colProcedureCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                Dim itemName As String = (From data In _Procedures _
                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("ProcedureName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colProcedureQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colProcedureUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colProcedureAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colProcedureEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colProcedureNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DentalData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyDentalEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colDentalCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                Dim itemName As String = (From data In _DentalServices _
                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("DentalName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colDentalQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colDentalUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colDentalAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colDentalEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colDentalNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TheatreData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyTheatreEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colTheatreCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                Dim itemName As String = (From data In _TheatreServices _
                                    Where data.Field(Of String)("TheatreCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("TheatreName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colTheatreQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colTheatreUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colTheatreAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colTheatreEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colTheatreNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function OpticalData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyOpticalEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colOpticalCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                Dim itemName As String = (From data In _OpticalServices _
                                    Where data.Field(Of String)("OpticalCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("OpticalName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colOpticalQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colOpticalUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colOpticalAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colOpticalEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colOpticalNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function MaternityData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyMaternityEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colMaternityCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _MaternityServices As EnumerableRowCollection(Of DataRow) = maternityServices.AsEnumerable()
                Dim itemName As String = (From data In _MaternityServices _
                                    Where data.Field(Of String)("MaternityCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("MaternityName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colMaternityQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colMaternityUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colMaternityAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colMaternityEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colMaternityNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ICUData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyICUEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvICU.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colICUCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _ICUServices As EnumerableRowCollection(Of DataRow) = iCUServices.AsEnumerable()
                Dim itemName As String = (From data In _ICUServices _
                                    Where data.Field(Of String)("ICUCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("ICUName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colICUQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colICUUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colICUAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colICUEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colICUNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsumablesData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyConsumablesEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colConsumableName))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colConsumableQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colConsumableUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colConsumableAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colConsumableEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ExtraChargeData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyExtraChargeEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colExtraItemFullName))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colExtraChargeQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colExtraChargeUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colExtraChargeAmount)
                'Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colExtraChargeEntryMode)
                'Dim notes As String = StringMayBeEnteredIn(cells, Me.colExtraChargeNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                'If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                '    If notes.Length > 16 Then
                '        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                '    Else : tableData.Append(notes.PadRight(padNotes))
                '    End If
                'Else : tableData.Append(String.Empty.PadRight(padNotes))
                'End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillQuotation += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Set Next Quotation No "
    Private Sub SetNextQuotationNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oQuotations As New SyncSoft.SQLDb.Quotations()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim yearL2 As String = Today.Year.ToString().Substring(2)
            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Quotations", "QuotationNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextQuotationNo As String = CStr(oQuotations.GetNextQuotationID).PadLeft(paddingLEN, paddingCHAR)
            Me.stbQuotationNo.Text = FormatText((yearL2 + nextQuotationNo).Trim(), "Quotations", "QuotationNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
#End Region

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            Me.stbVisitNo_Leave(Me, System.EventArgs.Empty)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

End Class
