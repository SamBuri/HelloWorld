Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
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
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Collections.Generic

Public Class frmDrugAdministration

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
    Private _DrugNo As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
#End Region

   
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


    Private Sub LoadVisitsData(ByVal visitNo As String)

        Try
            Me.ShowPatientDetails(visitNo)
            Me.LoadDrugAdministration(visitNo)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    
    Private Sub btnLoadSeeDrVisits_Click(sender As Object, e As EventArgs) Handles btnLoadSeeDrVisits.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim fOPDDIspensedDrugs As New frmOPDDispensedDrugs(Me.stbVisitNo)
            fOPDDIspensedDrugs.ShowDialog(Me)

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
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVariousOptions As New VariousOptions()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
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
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
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

            If Not String.IsNullOrEmpty(serviceCode) Then
                Try
                    Dim items As DataTable = oItems.GetItem(visitNo, serviceCode, oItemCategoryID.Service).Tables("Items")
                    Dim itemsRow As DataRow = items.Rows(0)
                    visitStandardFee = DecimalMayBeEnteredIn(itemsRow, "UnitPrice")
                    Me.stbBillServiceFee.Text = FormatNumber(visitStandardFee, AppData.DecimalPlaces)

                    If String.IsNullOrEmpty(visitNo) Then Return
                    items = oItems.GetItems(visitNo, oItemCategoryID.Drug, oItemStatusID.Offered).Tables("Items")


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.colDrug.Items.Clear()
                    LoadComboData(Me.colDrug, items, "ItemFullName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                Catch eX As Exception
                    Throw eX

                End Try

            End If

        Catch eX As Exception
            Throw eX

        End Try






    End Sub

    Private Sub LoadDrugAdministration(ByVal visitNo As String)

        Dim oDrugAdministration As New SyncSoft.SQLDb.DrugAdministration
        Try

            Me.dgvGivendrugs.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oDrugAdministration.GetDrugAdministration(visitNo).Tables("DrugAdministration")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                With Me.dgvGivendrugs
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.ColReturnItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.ColReturnQuantityTaken.Name, pos).Value = IntegerEnteredIn(row, "QuantityTaken")
                    .Item(Me.ColReturnGivenDateTime.Name, pos).Value = StringEnteredIn(row, "TakenDateTime")
                    .Item(Me.ColReturnNurseNotes.Name, pos).Value = StringEnteredIn(row, "NurseNotes")
                    .Item(Me.ColReturnGivenBy.Name, pos).Value = StringEnteredIn(row, "StaffName")
                    .Item(Me.ColReturnSaved.Name, pos).Value = True
                End With

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

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


    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Nurse).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.CboAdminStaff, staff, "StaffFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

Private Sub frmDrugAdministration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVariousOptions As New VariousOptions()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadStaff()
            Me.LoadServices()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try

End Sub

Private Sub frmDrugAdministration_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Try

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Using oDrugAdministration As New SyncSoft.SQLDb.DrugAdministration()

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                    Dim givenQuantity As Integer = IntegerEnteredIn(cells, Me.ColQuantitytoGive, "Quantity to give!")
                    Dim remainingQty As Integer = IntegerEnteredIn(cells, Me.ColRemainingQty, "Remaining Quantity!")
                    Dim drugAdminDateTime As Date = DateTimeEnteredIn(Me.dtpDrugAdminDateTime, "Administration Date Time!")


                    If (givenQuantity > remainingQty) Then
                        Throw New ArgumentException("Given Quantity can't be more than Remaining Quantity!")
                    ElseIf (givenQuantity <= 0) Then
                        Throw New ArgumentException("Given Quantity can't be zero or less,Please select another drug")
                    End If

                    With oDrugAdministration

                        .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))
                        .TakenDateTime = drugAdminDateTime
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                        .ItemCategory = oItemCategoryID.Drug
                        .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colDrug))
                        .QuantityTaken = givenQuantity
                        .NurseNotes = StringEnteredIn(cells, Me.ColNurseNotes)
                        .LoginID = CurrentUser.LoginID
                        .StaffNo = SubstringEnteredIn(Me.CboAdminStaff)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ValidateEntriesIn(Me)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End With

                    oDrugAdministration.Save()
                End Using
            Next

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
            '    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
            'Next

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgDrugAdministration)
            ResetControlsIn(Me.tpgGivenDrugs)

            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        End Try




    End Sub

#Region " Edit Methods "

Public Sub Edit()

	Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
	Me.ebnSaveUpdate.Enabled = False
	ResetControlsIn(Me)

End Sub

Public Sub Save()

	Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
	Me.ebnSaveUpdate.Enabled = True
	ResetControlsIn(Me)

End Sub

Private Sub DisplayData(ByVal dataSource As DataTable)

Try

	Me.ebnSaveUpdate.DataSource = dataSource
	Me.ebnSaveUpdate.LoadData(Me)

	Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
		Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
	
Catch ex As Exception
	Throw ex
End Try

End Sub

Private Sub CallOnKeyEdit()
If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
	Me.ebnSaveUpdate.Enabled = False
	End If
End Sub

#End Region


    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    
    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrug.Index) Then

                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)
            ElseIf e.ColumnIndex.Equals(Me.ColQuantitytoGive.Index) Then
                Me.CalculateRemainingQty(selectedRow)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateRemainingQty(selectedRow As Integer)

        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim issuedQty As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.ColGivenQty)
        Me.dgvPrescription.Item(Me.ColRemainingQty.Name, selectedRow).Value = (quantity - issuedQty)
        Dim remainingbal As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.ColRemainingQty)

        If (remainingbal <= 0) Then
            Throw New ArgumentException("This patient has received all Prescribed Quanity for this drug ." +
                                                   ControlChars.NewLine + "Please issue another drug")
            Me.dgvPrescription.Rows.RemoveAt(selectedRow)
            Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = Me._DrugNo
            Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True

        End If


    End Sub

    Private Sub DrugQuantityTaken(ByVal selectedRow As Integer)
        Dim oDrugAdministration As New SyncSoft.SQLDb.DrugAdministration
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try

            If Me.dgvPrescription.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            Dim itemCode As String = SubstringRight(selectedItem)

            Dim visitNo As String = RevertText(StringEnteredIn(stbVisitNo))
            Dim items As DataTable = oDrugAdministration.GetDrugAdministeredQuantity(visitNo, itemCode, oItemCategoryID.Drug).Tables("DrugAdministration")
           Dim row As DataRow = items.Rows(0)
            With Me.dgvPrescription
                .Item(Me.ColGivenQty.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "TotalGivenAmount")
                Me.CalculateRemainingQty(selectedRow)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

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
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailDrug(selectedRow)
            Me.DrugQuantityTaken(selectedRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailDrug(ByVal selectedRow As Integer)
        Dim oitems As New SyncSoft.SQLDb.Items
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Try

            If Me.dgvPrescription.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            Dim drugNo As String = SubstringRight(selectedItem)

            Dim visitNo As String = RevertText(StringEnteredIn(stbVisitNo))
          
            If String.IsNullOrEmpty(drugNo) Then Return
            Dim items As DataTable = oitems.GetDrugAdministrationPerVisit(visitNo, oItemCategoryID.Drug, drugNo).Tables("Items")
            If items Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = items.Rows(0)

            With Me.dgvPrescription
                .Item(Me.colDrugQuantity.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Quantity")
                .Item(Me.colDuration.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Duration")
                .Item(Me.colDosage.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Dosage")
                .Item(Me.colNotes.Name, selectedRow).Value = StringMayBeEnteredIn(row, "ItemDetails")
               .Item(Me.colPrescriptionUnitMeasure.Name, selectedRow).Value = StringMayBeEnteredIn(row, "UnitMeasure")


            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

  
End Class