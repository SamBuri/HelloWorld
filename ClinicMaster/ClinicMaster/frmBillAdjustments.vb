
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Collections.Generic
Imports SyncSoft.SQLDb.Lookup

Public Class frmBillAdjustments

#Region " Fields "

   
    Private _ExtraBillNo As String = String.Empty
    Private _VisitState As Boolean = True

    Private oEntryModeID As New LookupDataID.EntryModeID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private oCoPayTypeID As New LookupDataID.CoPayTypeID()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()

    Private oItemTransferStatusID As New LookupDataID.ItemStatusID()

    Private tipCoPayValueWords As New ToolTip()


    Private toReturnItems As DataTable
    Private toReturnConsumables As DataTable

    Private _toReturnItem As String = String.Empty
    Private _ReturnedConsumableValue As String = String.Empty
    Dim oDocumentTypeID As New LookupDataID.DocumentTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oAdjustmentTypeID As New LookupDataID.AdjustmentTypeID()
    Private visitTypeID As String
    Private oVariousOption As New VariousOptions()
#End Region

    Private Sub frmBillReturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            LoadLookupDataCombo(cboAdjustmentTypeID, LookupObjects.AdjustmentType, True)

            Select Case _VisitState

                Case True
                    Me.Text = "IPD Bill Adjustments"
                    Me.lblExtraBillNo.Text = "Extra Bill No"
                    Me.lblExtraBillDate.Text = "Extra Bill Date"
                    Me.stbVisitNo.Enabled = True
                    Me.stbVisitNo.Visible = True
                    Me.lblVisitNo.Enabled = True
                    Me.lblVisitNo.Visible = True
                    Me.stbRoundNo.Enabled = True
                    Me.stbRoundNo.Visible = True
                    Me.lblRoundNo.Enabled = True
                    Me.lblRoundNo.Visible = True
                    Me.visitTypeID = oVisitTypeID.InPatient()
                    Me.Cursor = Cursors.WaitCursor()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(Me._ExtraBillNo) Then
                        Me.stbExtraBillNo.Text = FormatText(Me._ExtraBillNo, "ExtraBills", "ExtraBillNo")
                        Me.ShowExtraBillDetails(Me._ExtraBillNo)
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case False
                    Me.Text = "OPD Bill Adjustments"
                    Me.lblExtraBillNo.Text = "Visit No"
                    Me.lblExtraBillDate.Text = "Visit Date"
                    Me.stbVisitNo.Enabled = False
                    Me.stbVisitNo.Visible = False
                    Me.lblVisitNo.Enabled = False
                    Me.lblVisitNo.Visible = False
                    Me.stbRoundNo.Enabled = False
                    Me.stbRoundNo.Visible = False
                    Me.lblRoundNo.Enabled = False
                    Me.lblRoundNo.Visible = False

                    Me.colEntryMode.DataPropertyName = Nothing
                    Me.colEntryMode.Visible = False
                    Me.pnlNavigateExtraBills.Visible = False
                    Me.visitTypeID = oVisitTypeID.OutPatient()

            End Select
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            SetIntegrationAdjustment()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SetIntegrationAdjustment()

        Try
            Me.Cursor = Cursors.WaitCursor
            If oVariousOption.EnableIntegrationN001 AndAlso _VisitState.Equals(True) Then
                Me.cboAdjustmentTypeID.SelectedValue = oAdjustmentTypeID.Down()
                Me.cboAdjustmentTypeID.Enabled = False
                Me.rdoModifyQuantity.Checked = True
                Me.rdoModifyPrice.Checked = False
                Me.rdoModifyPrice.Enabled = False
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub frmReturnedExtraBillItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()

        Me.stbExtraBillDate.Clear()
        Me.stbStaffNo.Clear()
        Me.stbVisitNo.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbRoundNo.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbVisitStatus.Clear()
        Me.stbGender.Clear()
        Me.stbBillMode.Clear()
        Me.stbInsuranceName.Clear()
        Me.fbnViewFullInvoice.Enabled = False
        Me.dgvReturnedPrescriptions.Rows.Clear()
        Me.colItemFullName.Items.Clear()
        Me.colItemFullName.DataSource = Nothing

        ''''''''''''''''''''''''''''''''''''''''''''


    End Sub

    Private Sub ResetControls()
        ResetControlsIn(Me.pnlNavigateExtraBills)

        EnableColumns()
    End Sub

    Private Sub LoadToReturnItems(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
        Dim oItems As New SyncSoft.SQLDb.Items()

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case _VisitState

                Case True
                    ' Load from ToReturnExtraBillDrugs
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    toReturnItems = oExtraBillItems.GetExtraBillItemsByExtraBillNo(extraBillNo).Tables("ExtraBillItems")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.colItemFullName, toReturnItems, "ItemFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case False

                    ' Load from ToReturnDrugs
                    Dim VisitNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    toReturnItems = oItems.GetToReturnItems(VisitNo).Tables("Items")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.colItemFullName, toReturnItems, "ItemFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub btnFindExtraBillNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindExtraBillNo.Click
        Select Case _VisitState

            Case True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fFindExtraBillNo As New frmFindAutoNo(Me.stbExtraBillNo, AutoNumber.ExtraBillNo)
                fFindExtraBillNo.ShowDialog(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim extraBillNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                Me.ShowExtraBillDetails(extraBillNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Case False
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fFindVisitNo As New frmFindAutoNo(Me.stbExtraBillNo, AutoNumber.VisitNo)
                fFindVisitNo.ShowDialog(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim VisitNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                Me.ShowExtraBillDetails(VisitNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Select
    End Sub

    Private Sub stbExtraBillNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbExtraBillNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbExtraBillNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbExtraBillNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.ResetControls()

            Select Case _VisitState

                Case True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim extraBillNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                    Me.ShowExtraBillDetails(extraBillNo)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case False

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                    Me.ShowExtraBillDetails(visitNo)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select



        Catch ex As Exception
            Me.ResetControls()
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ShowExtraBillDetails(ByVal extraBillNo As String)

        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor
            Select Case _VisitState
                Case True
                    'Me.Cursor = Cursors.WaitCursor

                    Me.ClearControls()

                    If String.IsNullOrEmpty(extraBillNo) Then Return

                    Dim visits As DataTable = oExtraBills.GetExtraBills(extraBillNo).Tables("ExtraBills")
                    Dim row As DataRow = visits.Rows(0)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbExtraBillNo.Text = FormatText(extraBillNo, "ExtraBills", "ExtraBillNo")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim patientNo As String = StringEnteredIn(row, "PatientNo")
                    Dim visitNo As String = StringEnteredIn(row, "VisitNo")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbExtraBillDate.Text = FormatDate(DateEnteredIn(row, "ExtraBillDate"))
                    Me.stbStaffNo.Text = StringMayBeEnteredIn(row, "StaffName")
                    Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
                    Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
                    Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                    Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                    Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
                    Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
                    Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
                    Me.stbFullName.Text = StringEnteredIn(row, "FullName")
                    Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
                    Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                    Me.stbRoundNo.Text = StringMayBeEnteredIn(row, "RoundNo")
                    Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
                    Me.stbAge.Text = StringEnteredIn(row, "Age")
                    Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
                    Me.stbGender.Text = StringEnteredIn(row, "Gender")
                    Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
                    Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.LoadToReturnItems(extraBillNo)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.fbnViewFullInvoice.Enabled = True
                    Security.Apply(Me.fbnViewFullInvoice, AccessRights.Read)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case False


                    Me.ClearControls()

                    If String.IsNullOrEmpty(extraBillNo) Then Return

                    Dim visits As DataTable = oVisits.GetVisits(extraBillNo).Tables("Visits")
                    Dim row As DataRow = visits.Rows(0)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbExtraBillNo.Text = FormatText(extraBillNo, "ExtraBills", "ExtraBillNo")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim patientNo As String = StringEnteredIn(row, "PatientNo")
                    'Dim visitNo As String = StringEnteredIn(row, "VisitNo")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbExtraBillDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
                    Me.stbStaffNo.Text = StringMayBeEnteredIn(row, "StaffFullName")
                    'Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
                    Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
                    Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                    Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                    Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
                    Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
                    Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
                    Me.stbFullName.Text = StringEnteredIn(row, "FullName")
                    Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
                    Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                    Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
                    Me.stbAge.Text = StringEnteredIn(row, "Age")
                    Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
                    Me.stbGender.Text = StringEnteredIn(row, "Gender")
                    Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
                    Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.LoadToReturnItems(extraBillNo)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.fbnViewFullInvoice.Enabled = True
                    Security.Apply(Me.fbnViewFullInvoice, AccessRights.Read)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Save Methods "

    Private Sub fbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSave.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.SaveItemAdjustments()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveBillAdjustments()
        Dim oBillReturns As New SyncSoft.SQLDb.BillAdjustments()
        Dim visitNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Visit No!"))
        With oBillReturns
            .AdjustmentNo = RevertText(Me.GetNextBillAdjustmentID(visitNo))
            .BillNo = visitNo
            .VisitTypeID = Me.visitTypeID
            .LoginID = CurrentUser.LoginID

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            .Save()
        End With
    End Sub

    Private Sub SaveItemAdjustments()


        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim lExtraBillItemsAdjustments As New List(Of DBConnect)


        Dim lBillAdjustments As New List(Of DBConnect)
        Dim oBillAdjustments As New SyncSoft.SQLDb.BillAdjustments()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim extraBillDate As Date = DateMayBeEnteredIn(Me.stbExtraBillDate)
            Dim adjustmentDate As Date = DateEnteredIn(dtpReturnDate, "Adjustment Date!")
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Visit No!"))
            Dim AdjustmentTypeID As String = StringValueEnteredIn(Me.cboAdjustmentTypeID, "Adjustment Type!")

            With oBillAdjustments
                .AdjustmentNo = RevertText(Me.GetNextBillAdjustmentID(visitNo))
                .BillNo = visitNo
                .AdjustmentDate = adjustmentDate
                .VisitTypeID = Me.visitTypeID
                .AdjustmenTypeID = AdjustmentTypeID
                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lBillAdjustments.Add(oBillAdjustments)

            End With



            If Me.dgvReturnedPrescriptions.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for returned drug!")

            For Each row As DataGridViewRow In Me.dgvReturnedPrescriptions.Rows

                If row.IsNewRow Then Exit For

                StringEnteredIn(row.Cells, Me.colItemFullName, "item!")


                Dim returnedQuantity As Integer = IntegerEnteredIn(row.Cells, Me.colReturnQuantity, "Returned Quantity!")
                Dim returnedAmount As Decimal = DecimalEnteredIn(row.Cells, Me.colAmount, False, "Return Amount!")

                Dim totalReturnedQuantity As Integer = IntegerEnteredIn(row.Cells, Me.colTotalReturnQuantity, "total Returned Quantity!")
                Dim totalReturnedAmount As Decimal = DecimalEnteredIn(row.Cells, Me.colTotalReturnAmount, False, "Total Return Amount!")
                StringEnteredIn(row.Cells, Me.colNotes, "notes")
                Dim billQuantity As Integer = IntegerEnteredIn(row.Cells, Me.colBillQuantity, "Bill Quantity!")
                Dim billAmount As Decimal = DecimalEnteredIn(row.Cells, Me.colBillAmount, False, "Bill Amount!")

                Dim pos As Integer = row.Index + 1
                If adjustmentDate < extraBillDate Then Throw New ArgumentException("Return date can’t be before extra bill date!")
                If adjustmentDate > Today Then Throw New ArgumentException("Return date can’t be ahead of today!")

                If returnedQuantity < 1 AndAlso rdoModifyQuantity.Checked Then Throw New ArgumentException("Returned quantity  can't be less than one at row " + pos.ToString + "!")
                If returnedAmount < 1 AndAlso rdoModifyPrice.Checked Then Throw New ArgumentException("Returned Amount  can't be less than one at row " + pos.ToString + "!")
                If returnedQuantity < 1 AndAlso returnedAmount < 1 Then Throw New ArgumentException("Returned quantity and return Amount can’t be less than one " + pos.ToString + "!")
                If totalReturnedQuantity > billQuantity Then Throw New ArgumentException("total returned quantity can’t be more than bill quantity " + pos.ToString + "!")
                If (returnedAmount > billAmount) And AdjustmentTypeID.Equals(oAdjustmentTypeID.Down) Then Throw New ArgumentException("total returned amount can’t be more than bill amount!" + pos.ToString + "!")

            Next



            Select Case _VisitState

                Case True
                    Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))


                    For rowNo As Integer = 0 To Me.dgvReturnedPrescriptions.RowCount - 2

                        Dim cells As DataGridViewCellCollection = Me.dgvReturnedPrescriptions.Rows(rowNo).Cells
                        Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colItemFullName))
                        Dim itemCategory As String = StringEnteredIn(cells, Me.colItemCategory, "Item Cagory")
                        Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Cagory ID")
                        Dim returnedQuantity As Integer = IntegerEnteredIn(cells, Me.colReturnQuantity)
                        Dim returnedAmount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False)
                        Dim newPrice As Decimal = DecimalEnteredIn(cells, Me.colNewPrice, False)
                        Dim ackwnowledgeable As Boolean = BooleanMayBeEnteredIn(cells, Me.colAcknowledgable)
                        Dim dispensedQuantity As Integer = IntegerEnteredIn(cells, Me.colBillQuantity)
                        Dim notes As String = StringEnteredIn(cells, Me.colNotes)


                        Try

                            Using oExtraBillItemAdjustments As New SyncSoft.SQLDb.ExtraBillItemAdjustments()

                                With oExtraBillItemAdjustments
                                    .ExtraBillNo = extraBillNo
                                    .AdjustmentNo = RevertText(Me.GetNextBillAdjustmentID(extraBillNo))
                                    .ItemCode = itemCode
                                    .ItemCategoryID = itemCategoryID
                                    .Quantity = returnedQuantity
                                    .Amount = returnedAmount
                                    .NewPrice = newPrice
                                    .Acknowledgeable = ackwnowledgeable
                                    .EntryLevelID = oDocumentTypeID.BillFormReturns
                                    .Notes = notes
                                    .LoginID = CurrentUser.LoginID
                                End With

                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                lExtraBillItemsAdjustments.Add(oExtraBillItemAdjustments)
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End Using


                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                        Catch ex As Exception
                            ErrorMessage(ex)
                        End Try

                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBillAdjustments, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsAdjustments, Action.Save))
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case False

                    Dim lReturnedItems As New List(Of DBConnect)
                    Dim lItemsCASH As New List(Of DBConnect)

                    For rowNo As Integer = 0 To Me.dgvReturnedPrescriptions.RowCount - 2



                        Dim cells As DataGridViewCellCollection = Me.dgvReturnedPrescriptions.Rows(rowNo).Cells
                        Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colItemFullName))
                        Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Cagory ID")
                        Dim returnedQuantity As Integer = IntegerEnteredIn(cells, Me.colReturnQuantity)
                        Dim dispensedQuantity As Integer = IntegerEnteredIn(cells, Me.colBillQuantity)
                        Dim returnedAmount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False)
                        Dim ackwnowledgeable As Boolean = BooleanMayBeEnteredIn(cells, Me.colAcknowledgable)
                        Dim notes As String = StringEnteredIn(cells, Me.colNotes)
                        Dim newPrice As Decimal = DecimalEnteredIn(cells, Me.colNewPrice, False)
                        Try

                            Using oItemAdjustments As New SyncSoft.SQLDb.ItemAdjustments()

                                With oItemAdjustments
                                    .VisitNo = visitNo
                                    .AdjustmentNo = RevertText(Me.GetNextBillAdjustmentID(visitNo))
                                    .ItemCode = itemCode
                                    .ItemCategoryID = itemCategoryID
                                    .Quantity = returnedQuantity
                                    .Amount = returnedAmount
                                    .NewPrice = newPrice
                                    .Acknowledgeable = ackwnowledgeable
                                    .EntryLevelID = oDocumentTypeID.OPDReturns
                                    .Notes = notes
                                    .LoginID = CurrentUser.LoginID
                                End With

                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                lReturnedItems.Add(oItemAdjustments)
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End Using

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim quantity As Integer = dispensedQuantity - returnedQuantity
                            Dim unitPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colUnitPrice)
                            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
                            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
                            Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                            If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                                Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                    With oItemsCASH
                                        .VisitNo = visitNo
                                        .ItemCode = itemCode
                                        .ItemCategoryID = itemCategoryID
                                        .CashAmount = cashAmount
                                        .CashPayStatusID = oPayStatusID.NotPaid
                                    End With
                                    lItemsCASH.Add(oItemsCASH)
                                End Using

                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End If


                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Catch ex As Exception
                            ErrorMessage(ex)
                        End Try

                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBillAdjustments, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lReturnedItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            Me.ClearControls()
            ResetControlsIn(Me)
            SetIntegrationAdjustment()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Function GetNextBillAdjustmentID(ByVal billNo As String) As String

        Dim returnNo As String = String.Empty
        Try

            Dim oBillAdjustments As New SyncSoft.SQLDb.BillAdjustments()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BillAdjustments", "AdjustmentNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim NextBillReturnsID As String = oBillAdjustments.GetNextBillAdjustmentID(billNo).ToString()
            NextBillReturnsID = NextBillReturnsID.PadLeft(paddingLEN, paddingCHAR)

            returnNo = FormatText(billNo + NextBillReturnsID.Trim(), "BillAdjustments", "AdjustmentNo")

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

        Return returnNo
    End Function


#End Region

    Private Sub fbnViewFullInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnViewFullInvoice.Click

        Try

            Me.Cursor = Cursors.WaitCursor()

            Select Case _VisitState
                Case True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                    If String.IsNullOrEmpty(visitNo) Then Return

                    Dim fPrintExtraBillsInvoice As New frmPrintExtraBillsInvoice(visitNo)
                    fPrintExtraBillsInvoice.ShowDialog()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                    If String.IsNullOrEmpty(visitNo) Then Return

                    Dim fPrintExtraBillsInvoice As New frmPrintExtraBillsInvoice(visitNo)
                    fPrintExtraBillsInvoice.ShowDialog()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Extra Bills Navigate "

    Private Sub EnableNavigateExtraBillsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim extraBills As DataTable = oExtraBills.GetExtraBillsByVisitNo(visitNo).Tables("ExtraBills")

                For pos As Integer = 0 To extraBills.Rows.Count - 1
                    If extraBillNo.ToUpper().Equals(extraBills.Rows(pos).Item("ExtraBillNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navExtraBills.DataSource = extraBills
                Me.navExtraBills.Navigate(startPosition)

            Else : Me.navExtraBills.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateExtraBills.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateExtraBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateExtraBills.Click
        Me.EnableNavigateExtraBillsCTLS(Me.chkNavigateExtraBills.Checked)
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navExtraBills.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = RevertText(currentValue.ToString())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(extraBillNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbExtraBillNo.Text = FormatText(extraBillNo, "ExtraBills", "ExtraBillNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowExtraBillDetails(extraBillNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Returned Prescription - Grid "

    Private Sub dgvReturnedPrescriptions_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvReturnedPrescriptions.CellBeginEdit

        If e.ColumnIndex <> Me.colItemFullName.Index OrElse Me.dgvReturnedPrescriptions.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvReturnedPrescriptions.CurrentCell.RowIndex
        _toReturnItem = StringMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colItemFullName)

    End Sub

    Private Sub dgvReturnedPrescriptions_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnedPrescriptions.CellEndEdit

        Try

            If Me.colItemFullName.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvReturnedPrescriptions.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colItemFullName.Index) Then

                ' Ensure unique entry in the combo column

                Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colItemFullName)


                For rowNo As Integer = 0 To Me.dgvReturnedPrescriptions.RowCount - 2
                    If Not rowNo.Equals(selectedRow) Then
                        Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(rowNo).Cells, Me.colItemFullName)
                        If enteredItem.Equals(selectedItem) Then
                            DisplayMessage("item (" + enteredItem + ") already selected!")
                            Me.dgvReturnedPrescriptions.Item(Me.colItemFullName.Name, selectedRow).Value = _toReturnItem
                            Me.dgvReturnedPrescriptions.Item(Me.colItemFullName.Name, selectedRow).Selected = True
                        End If
                    End If
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.DetailItem()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colAmount.Index) Then

                Me.CalculateReturnNewPrice(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colReturnQuantity.Index) Then
                Me.CalculateReturnAmount(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colNewPrice.Index) Then
                Me.CalculateReturnAmountOnNewPrice(selectedRow)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvReturnedPrescriptions_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvReturnedPrescriptions.UserDeletingRow


    End Sub



    Private Sub dgvReturnedPrescriptions_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvReturnedPrescriptions.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailItem()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvReturnedPrescriptions.Rows.Count > 1 Then
                selectedRow = Me.dgvReturnedPrescriptions.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colItemFullName)
            End If

            Dim itemCode As String = SubstringRight(selectedItem)
            Dim returnDate As String = FormatDate(Today)

            If String.IsNullOrEmpty(itemCode) Then Return

            For Each row As DataRow In toReturnItems.Select("ItemCode = '" + itemCode + "'")

                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim billAmount As Decimal = DecimalMayBeEnteredIn(row, "Amount")
                Dim totalReturnAmount As Decimal = DecimalMayBeEnteredIn(row, "TotalReturnAmount")
                Dim itemCategoryID As String = StringEnteredIn(row, "ItemCategoryID")

                With Me.dgvReturnedPrescriptions
                    .Item(Me.colItemCategoryID.Name, selectedRow).Value = itemCategoryID
                    .Item(Me.colItemCategory.Name, selectedRow).Value = StringEnteredIn(row, "ItemCategory")
                    .Item(Me.colBillQuantity.Name, selectedRow).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colBillAmount.Name, selectedRow).Value = FormatNumber(billAmount, AppData.DecimalPlaces)
                    .Item(Me.colReturnQuantity.Name, selectedRow).Value = 0
                    .Item(Me.colUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colPayStatus.Name, selectedRow).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colTotalReturnQuantity.Name, selectedRow).Value = IntegerEnteredIn(row, "TotalReturnQuantity")
                    .Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber(totalReturnAmount, AppData.DecimalPlaces)
                    .Item(Me.colPreviousReturnedQuantity.Name, selectedRow).Value = IntegerEnteredIn(row, "TotalReturnQuantity")
                    .Item(Me.colPreviousReturnedAmount.Name, selectedRow).Value = FormatNumber(totalReturnAmount, AppData.DecimalPlaces)
                    .Item(Me.colRetutnable.Name, selectedRow).Value = BooleanEnteredIn(row, "Returnable")

                    If itemCategoryID.ToUpper.Equals(oItemCategoryID.Drug.ToUpper()) OrElse itemCategoryID.ToUpper.Equals(oItemCategoryID.Consumable.ToUpper()) OrElse itemCategoryID.ToUpper.Equals(oItemCategoryID.NonMedical.ToUpper) Then
                        Me.dgvReturnedPrescriptions.Item(Me.colAcknowledgable.Name, selectedRow).ReadOnly = False
                        Me.dgvReturnedPrescriptions.Item(Me.colReturnQuantity.Name, selectedRow).ReadOnly = False
                    Else
                        Me.dgvReturnedPrescriptions.Item(Me.colAcknowledgable.Name, selectedRow).ReadOnly = True
                        Me.dgvReturnedPrescriptions.Item(Me.colAcknowledgable.Name, selectedRow).Value = False
                        Me.dgvReturnedPrescriptions.Item(Me.colReturnQuantity.Name, selectedRow).ReadOnly = False
                    End If

                    Select Case _VisitState
                        Case True
                            .Item(Me.colEntryMode.Name, selectedRow).Value = StringEnteredIn(row, "EntryMode")
                        Case False
                    End Select

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region


    Private Sub CalculateReturnAmount(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colUnitPrice, False)
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colAmount, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colBillAmount, False)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colBillQuantity)
            Dim returnQuantity As Integer = IntegerEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colReturnQuantity)
            Dim itemCategoryID As String = StringEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colItemCategoryID, "Item Category ID")

            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colPreviousReturnedAmount, False)
            Dim previousReturnedQuantity As Integer = IntegerEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colPreviousReturnedQuantity)

            Dim toReturnQuantity As Integer = 0


            Dim toReturnAmount As Decimal = returnQuantity * unitPrice
            Dim totalReturnAmount As Decimal = previousReturnedAmount + toReturnAmount
            Dim totalReturnQuantity As Integer = returnQuantity + previousReturnedQuantity

            If returnQuantity > billQuantity Then
                Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = 0
                Me.dgvReturnedPrescriptions.Item(Me.colReturnQuantity.Name, selectedRow).Value = 0
                Throw New ArgumentException("return quantity: " + amount.ToString + " cannot be greater than bill quantity: " + billQuantity.ToString)
            ElseIf toReturnAmount > billAmount Then
                Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = 0
                Me.dgvReturnedPrescriptions.Item(Me.colReturnQuantity.Name, selectedRow).Value = 0
                Throw New ArgumentException("return amount: " + returnQuantity.ToString + " cannot be greater than bill amount: " + billAmount.ToString)

            End If



            Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(toReturnAmount, AppData.DecimalPlaces)
            Me.dgvReturnedPrescriptions.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            Me.dgvReturnedPrescriptions.Item(Me.colTotalReturnQuantity.Name, selectedRow).Value = (returnQuantity + previousReturnedQuantity)
            Me.dgvReturnedPrescriptions.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((totalReturnAmount), AppData.DecimalPlaces)



            If (itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) OrElse
                itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) OrElse
                itemCategoryID.ToUpper().Equals(oItemCategoryID.NonMedical.ToUpper())) AndAlso returnQuantity > 0 Then
                Me.dgvReturnedPrescriptions.Item(Me.colAcknowledgable.Name, selectedRow).ReadOnly = False
                Me.dgvReturnedPrescriptions.Item(Me.colAcknowledgable.Name, selectedRow).Value = True

            Else
                Me.dgvReturnedPrescriptions.Item(Me.colAcknowledgable.Name, selectedRow).ReadOnly = True
                Me.dgvReturnedPrescriptions.Item(Me.colAcknowledgable.Name, selectedRow).Value = False

            End If


        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub CalculateReturnNewPrice(selectedRow As Integer)


        Try
            Dim adjustmentTypeID As String = StringValueEnteredIn(cboAdjustmentTypeID, "Adjustment Type")

            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colUnitPrice, False)
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colAmount, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colBillAmount, False)
            Dim itemCategory As String = StringEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colItemCategory, "ItemCategory")

            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colPreviousReturnedAmount, False)
            Dim previousReturnedQuantity As Integer = IntegerEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colPreviousReturnedQuantity)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colBillQuantity)




            Dim totalReturnAmount As Decimal = previousReturnedAmount
            Dim newPrice As Decimal = 0

            If adjustmentTypeID.ToUpper().Equals(oAdjustmentTypeID.Down().ToUpper()) Then


                If amount > billAmount Then
                    Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = String.Empty
                    Me.dgvReturnedPrescriptions.Item(Me.colNewPrice.Name, selectedRow).Value = 0
                    Throw New ArgumentException("Amount: " + amount.ToString + " cannot be greater than bill amount: " + billAmount.ToString + "Down adjustment")

                End If
                totalReturnAmount += amount
                If billAmount = amount Then
                    newPrice = 0
                Else : newPrice = (billAmount - amount) / (billQuantity)
                End If
            Else : newPrice = (billAmount + amount) / (billQuantity)
            End If

            Me.dgvReturnedPrescriptions.Item(Me.colReturnQuantity.Name, selectedRow).Value = 0
                Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)

                Me.dgvReturnedPrescriptions.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber((newPrice), AppData.DecimalPlaces)

                Me.dgvReturnedPrescriptions.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((totalReturnAmount), AppData.DecimalPlaces)




        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub CalculateReturnAmountOnNewPrice(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colUnitPrice, False)
            Dim newPrice As Decimal = DecimalEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colNewPrice, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colBillAmount, False)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colBillQuantity)
            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvReturnedPrescriptions.Rows(selectedRow).Cells, Me.colPreviousReturnedAmount, False)
            Dim adjustmentTypeID As String = StringValueEnteredIn(cboAdjustmentTypeID, "Adjustment Type")
            Dim adjustedAmount As Decimal
            If adjustmentTypeID.ToUpper.Equals(oAdjustmentTypeID.Down) Then
                If newPrice > unitPrice Then
                    Me.dgvReturnedPrescriptions.Item(Me.colNewPrice.Name, selectedRow).Value = String.Empty
                    Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = 0
                    Throw New ArgumentException("The new price: " + newPrice.ToString + " cannot be greater than unit price: " + unitPrice.ToString)

                End If


                If newPrice = unitPrice Then
                    adjustedAmount = 0
                Else
                    adjustedAmount = billQuantity * (unitPrice - newPrice)
                End If

            Else
                If newPrice < unitPrice Then
                    Me.dgvReturnedPrescriptions.Item(Me.colNewPrice.Name, selectedRow).Value = String.Empty
                    Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = 0
                    Throw New ArgumentException("The new price: " + newPrice.ToString + " cannot be less than unit price: " + unitPrice.ToString + " for Up adjustment")

                End If

                adjustedAmount = billQuantity * (newPrice - unitPrice)

                End If

                Me.dgvReturnedPrescriptions.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(adjustedAmount, AppData.DecimalPlaces)
                Me.dgvReturnedPrescriptions.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber(newPrice, AppData.DecimalPlaces)
                Me.dgvReturnedPrescriptions.Item(Me.colReturnQuantity.Name, selectedRow).Value = 0
                Me.dgvReturnedPrescriptions.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((previousReturnedAmount + adjustedAmount), AppData.DecimalPlaces)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub EnableColumns()

        Me.dgvReturnedPrescriptions.Rows.Clear()
        If Me.rdoModifyQuantity.Checked Then
            Me.colNewPrice.Visible = False
            Me.colAmount.ReadOnly = True
            Me.colReturnQuantity.Visible = True
        Else
            Me.colNewPrice.Visible = True
            Me.colAmount.ReadOnly = False
            Me.colReturnQuantity.Visible = False
        End If
    End Sub

    Private Sub rdoReduceQuantity_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoModifyQuantity.CheckedChanged
        EnableColumns()
    End Sub

    Private Sub rdoReducePrice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoModifyPrice.CheckedChanged
        EnableColumns()
    End Sub

    Private Sub EnableCheckItems()
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dgvReturnedPrescriptions.Rows.Clear()
            Dim adjustmentTypeID As String = StringValueMayBeEnteredIn(cboAdjustmentTypeID)

            If String.IsNullOrEmpty(adjustmentTypeID) Then Return
            If adjustmentTypeID.Equals(oAdjustmentTypeID.Up) Then
                Me.rdoModifyQuantity.Checked = False
                Me.rdoModifyPrice.Checked = True
                Me.rdoModifyQuantity.Enabled = False
            Else

                Me.rdoModifyQuantity.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboAdjustmentTypeID_Leave(sender As Object, e As System.EventArgs) Handles cboAdjustmentTypeID.Leave
        EnableCheckItems()
    End Sub

   
End Class