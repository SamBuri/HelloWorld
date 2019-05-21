
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

Imports System.Drawing.Printing
Imports System.Collections.Generic
Public Class frmIPDExtraCharge
    Dim keyNo As String = String.Empty

    Private tipCoPayValueWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private admissionNo As String = String.Empty

    Private oEntryModeID As New LookupDataID.EntryModeID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oBenefitCodes As New LookupDataID.BenefitCodes()
    Private oBillModesID As New LookupDataID.BillModesID()
    Private oCoPayTypeID As New LookupDataID.CoPayTypeID()

    Private services As DataTable
    Private labTests As DataTable
    Private drugs As DataTable
    Private radiologyExaminations As DataTable
    Private procedures As DataTable
    Private dentalServices As DataTable
    Private theatreServices As DataTable
    Private opticalServices As DataTable
    Private maternityServices As DataTable
    Private iCUServices As DataTable
    Private consumableItems As DataTable
    Private extraChargeItems As DataTable
    Private hasPackage As Boolean = False
    Private _ServiceNameValue As String = String.Empty
    Private _AdmissionNameValue As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
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

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padNotes As Integer = 16
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 13
    Private padAmount As Integer = 14

    Private itemCount As Integer
    Private totalBillInvoice As Decimal
    Private patientpackageNo As String = String.Empty
    Private WithEvents docBillInvoice As New PrintDocument()

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

    Private Sub frmIPDExtraCharge_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not String.IsNullOrEmpty(keyNo) Then
             Me.ShowPatientDetails(keyNo)
            End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.LockItemsUnitPrices()
        LoadExtraChargeItems()
        Me.LoadStaff()
    End Sub

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


    Private Sub SetNextExtraBillNo(ByVal visitNo As String, ByVal patientNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.stbExtraBillNo.Clear()
            Me.stbExtraBillNo.Text = FormatText(GetNextExtraBillNo(visitNo, patientNo), "ExtraBills", "ExtraBillNo")

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

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
        billModesID = String.Empty
        associatedBillNo = String.Empty
        admissionNo = String.Empty
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.nbxCashAccountBalance.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.tipCashAccountBalanceWords.RemoveAll()
        ResetControlsIn(Me.pnlBill)
        hasPackage = False
        patientpackageNo = String.Empty
    End Sub



    Private Sub ResetControls()

        ResetControlsIn(Me.pnlBill)
      

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        Me.ShowPatientDetails(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbVisitNo, AutoNumber.VisitNo)
            fInWardAdmissions.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.ShowPatientDetails(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnFindExtraBillNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindExtraBillNo.Click
        Dim fFindExtraBillNo As New frmFindAutoNo(Me.stbExtraBillNo, AutoNumber.ExtraBillNo)
        fFindExtraBillNo.ShowDialog(Me)
        Me.stbExtraBillNo.Focus()
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

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return

            Dim visits As DataTable = oVisits.GetAdmissionsDetails(visitNo).Tables("Visits")
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
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            admissionNo = StringMayBeEnteredIn(row, "AdmissionNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.nbxCashAccountBalance.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAccountBalance"), AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(DecimalMayBeEnteredIn(row, "CashAccountBalance")))
            hasPackage = BooleanMayBeEnteredIn(row, "IPDHasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextExtraBillNo(visitNo, patientNo)


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oExtraBills.ExtraBillNo = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            DisplayMessage(oExtraBills.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


#Region " ExtraCharge - Grid "

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

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Extras
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvExtraCharge_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvExtraCharge.UserDeletedRow
        Me.CalculateBillForExtraCharge()
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
                .Item(Me.colExtraChargePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                .Item(Me.colExtraChargeEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForExtraCharge()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colExtraChargeAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

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

 
    Private Sub ebnSaveUpdate_Click(sender As System.Object, e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim message As String
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()
            Dim lExtraBills As New List(Of DBConnect)
            Dim oVariousOptions As New VariousOptions()

            With oExtraBills

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ExtraBillNo = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
                .ExtraBillDate = DateEnteredIn(Me.dtpExtraBillDate, "Extra Bill Date!")
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Attending Doctor!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lExtraBills.Add(oExtraBills)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvExtraCharge.RowCount <= 1 Then
                message = "Must register at least one item for admission or services or laboratory or radiology or prescription " +
                          "or procedure or dental or theatre or optical or maternity or ICU or consumables or extra charge!"
                Throw New ArgumentException(message)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
         
            Me.VerifyExtraChargeEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oExtraBills.IsBillsExtraBillDateSaved(oExtraBills.VisitNo, oExtraBills.ExtraBillDate) Then

                        If oVariousOptions.AllowCreateMultipleExtraBills Then
                            message = "You already have an extra bill on " + FormatDate(oExtraBills.ExtraBillDate) + ". " +
                                      "If you want to add services to previous bill, it can be done via in patients edit sub menu. " +
                                       ControlChars.NewLine + "Are you sure you want to save?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                        Else
                            message = "You already have an extra bill on " + FormatDate(oExtraBills.ExtraBillDate) + ". " +
                                      "If you want to add services to previous bill, it can be done via in patients edit sub menu. " +
                                      "The system is set not to allow multiple extra bills on the same date. " +
                                      "Please contact the administrator if you still need to create this bill."
                            Throw New ArgumentException(message)
                        End If

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.SaveExtraCharge()

                    ResetControlsIn(Me)
                    ResetControlsIn(Me.pnlBill)
                    

                 
                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Update, "ExtraBills"))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                   
                    Me.SaveExtraCharge()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DisplayMessage("record(s) updated successfully!")


            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function VerifyExtraChargeEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExtraItemFullName, "Extra Charge!")
                SingleEnteredIn(row.Cells, Me.colExtraChargeQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colExtraChargePayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception

            VerifyExtraChargeEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveExtraCharge() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyExtraChargeEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells

                    Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExtraItemFullName, "Extra Charge!"))
                    Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colExtraItemFullName, "Extra Charge!"))
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colExtraChargeQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colExtraChargeNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Extras
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Test).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Extras
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Test).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Extras)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Extras)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Extras
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception

                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception

            SaveExtraCharge = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub LockItemsUnitPrices()
        Dim oVariousOptions As New VariousOptions()
        Dim unitPrice As DataGridViewColumn() = {colExtraChargeUnitPrice}
        DisableGridComponets(unitPrice, oVariousOptions.LockItemsUnitPrices)

    End Sub


End Class