
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Public Class frmPackages

#Region " Fields "

    Private billCustomers As DataTable
    Private services As DataTable
    Private drugs As DataTable
    Private labTests As DataTable
    Private radiologyExaminations As DataTable
    Private procedures As DataTable
    Private dentalServices As DataTable
    Private pathologyExaminations As DataTable
    Private opticalServices As DataTable
    Private extraChargeItems As DataTable
    Private theatreServices As DataTable

    Private _ServiceNameValue As String = String.Empty
    Private _DrugNameValue As String = String.Empty
    Private _TestNameValue As String = String.Empty
    Private _RadiologyNameValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _OpticalServiceValue As String = String.Empty
    Private _DentalServiceValue As String = String.Empty
    Private _PathologyValue As String = String.Empty
    Private _AccountNoValue As String = String.Empty
    Private _ExtraChargeItemNameValue As String = String.Empty
    Private _DrugNo As String = String.Empty
    Private _TestNo As String = String.Empty
    Private _ServiceCode As String = String.Empty
    Private _ConsumableNo As String = String.Empty
    Private _ConsumableItemValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty
    Private oVariousOptions As New VariousOptions()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID
#End Region

Private Sub frmPackages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()

            Me.LoadProcedures()
            Me.LoadExtraChargeItems()
            Me.LoadRevenueStreams()
            Me.LoadRadiologyExaminations()
            Me.LoadDentalCategoryService()
            Me.LoadOpticalServices()
            Me.LoadPathologyExaminations()
            Me.LoadTheatreServices()
            Me.SetNextPackageID()


	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub

    Private Sub LoadPackages(ByVal populate As Boolean)

        Dim oPackages As New SyncSoft.SQLDb.Packages()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Packages

            Dim packageName As DataTable = oPackages.GetPackageName.Tables("Packages")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.CboPackageNo, packageName, "PackageFullName")
            Else : Me.CboPackageNo.Items.Clear()
            End If



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

Private Sub frmPackages_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oPackages As New SyncSoft.SQLDb.Packages()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oPackages.PackageNo = SubstringRight(RevertText(StringEnteredIn(Me.CboPackageNo, "PackageNo!")))
            'oPackages.ItemCode = StringEnteredIn(Me.stbItemCode, "ItemCode!")
            'oPackages.ItemCategoryID = StringEnteredIn(Me.stbItemCategoryID, "ItemCategoryID!")

            DisplayMessage(oPackages.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oPackages As New SyncSoft.SQLDb.Packages()
        Try

            Dim accountNo As String = SubstringRight(RevertText(StringEnteredIn(Me.CboPackageNo, "Package No")))

            Me.Cursor = Cursors.WaitCursor

            Dim dataSource As DataTable = oPackages.GetPackages(accountNo).Tables("Packages")
            Me.DisplayData(dataSource)

            Me.LoadServices(accountNo)
            Me.LoadDrugs(accountNo)
            Me.LoadConsumables(accountNo)
            Me.LoadLabTests(accountNo)
            Me.LoadProcedures(accountNo)
            Me.LoadExtraChargeItems(accountNo)
            Me.LoadPackageRadiology(accountNo)
            Me.LoadPackageDentalServices(accountNo)
            Me.LoadPackageOpticalServices(accountNo)
            Me.LoadPackageTheatreServices(accountNo)
            Me.LoadPackagePathology(accountNo)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadRevenueStreams()
        Dim oRevenueStream As New SyncSoft.SQLDb.RevenueStreams()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from RevenueStream
            cboRevenueStreamID.DataSource = Nothing
            Dim revenueStream As DataTable = oRevenueStream.GetRevenueStreams().Tables("RevenueStreams")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            cboRevenueStreamID.DataSource = revenueStream
            cboRevenueStreamID.ValueMember = "RevenueStreamCode"
            cboRevenueStreamID.DisplayMember = "Name"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetServices() As DataTable

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Services 

            services = oServices.GetServices().Tables("Services")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return services
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)


        End Try

    End Function

    Private Function GetDrugs() As DataTable

        Dim drugs As DataTable
        Dim oSetupData As New SetupData()
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            ' Load from drugs

            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return drugs
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Function GetLabTests() As DataTable

        Dim labTests As DataTable
        Dim oSetupData As New SetupData()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try

            ' Load from LabTests
            If Not InitOptions.LoadLabTestsAtStart Then
                labTests = oLabTests.GetLabTests().Tables("LabTests")
                oSetupData.LabTests = labTests
            Else : labTests = oSetupData.LabTests
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return labTests
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)
        End Try

    End Function

    Private Sub LoadPathologyExaminations()

        Dim oPathologyExaminations As New SyncSoft.SQLDb.PathologyExaminations()
        Try
            Me.Cursor = Cursors.WaitCursor

            'Load Pathology Examinations
            pathologyExaminations = oPathologyExaminations.GetPathologyExaminations().Tables("PathologyExaminations")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colPathologyExamFullName, pathologyExaminations, "ExamCode", "ExamName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDentalCategoryService()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from DentalServices
            dentalServices = oDentalServices.GetDentalServices.Tables("DentalServices")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalCode.Sorted = False
            LoadComboData(Me.colDentalCode, dentalServices, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadOpticalServices()

        Dim oOpticalServices As New SyncSoft.SQLDb.OpticalServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from OpticalServices

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            opticalServices = oOpticalServices.GetOpticalServices().Tables("OpticalServices")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colOpticalCode.Sorted = False
            LoadComboData(Me.colOpticalCode, opticalServices, "OpticalCode", "OpticalName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Services - Grid "

    Private Sub dgvServices_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvServices.CellBeginEdit

        If e.ColumnIndex <> Me.colServiceCode.Index OrElse Me.dgvServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvServices.CurrentCell.RowIndex
        _ServiceNameValue = StringMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.colServiceCode)

    End Sub


    Private Sub dgvServices_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvServices.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvServices.Item(Me.colServicesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvServices.Item(Me.ColExTServiceCode.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Service
            End With

            DisplayMessage(oPackagesEXT.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvServices_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadServices(ByVal accountNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvServices.Rows.Clear()

            ' Load items not yet paid for

            packagesEXT = oPackagesEXT.GetPackagesEXT(accountNo, oItemCategoryID.Service).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvServices, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvServices.Item(Me.colServicesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvServices_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServices.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Services", "Service Code", "Service", Me.GetServices(), "ServiceFullName",
                                                                     "ServiceCode", "ServiceName", Me.dgvServices, Me.ColExTServiceCode, e.RowIndex)

            Me._ServiceCode = StringMayBeEnteredIn(Me.dgvServices.Rows(e.RowIndex).Cells, Me.ColExTServiceCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColEXTServiceSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvServices.Rows(e.RowIndex).IsNewRow Then

                Me.dgvServices.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetServicesEntries(e.RowIndex)
            ElseIf Me.ColEXTServiceSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetServicesEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetServicesEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.ColExTServiceCode)
            Me.SetServicesEntries(selectedRow, selectedItem)
        
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetServicesEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvServices.Item(Me.colServicesSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Service Code (" + Me._ServiceCode + ") can't be edited!")
                Me.dgvServices.Item(Me.ColExTServiceCode.Name, selectedRow).Value = Me._ServiceCode
                Me.dgvServices.Item(Me.ColExTServiceCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvServices.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvServices.Rows(rowNo).Cells, Me.ColExTServiceCode)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Service Code (" + enteredItem + ") already selected!")
                        Me.dgvServices.Rows.RemoveAt(selectedRow)
                        Me.dgvServices.Item(Me.ColExTServiceCode.Name, selectedRow).Value = Me._ServiceCode
                        Me.dgvServices.Item(Me.ColExTServiceCode.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredService(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredService(ByVal selectedRow As Integer)
        Try

            Dim oService As New SyncSoft.SQLDb.Services()
            Dim serviceCode As String = String.Empty
            Dim quantity As Integer = 1
            If Me.dgvServices.Rows.Count > 1 Then serviceCode = SubstringRight(StringMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.ColExTServiceCode))

            If String.IsNullOrEmpty(serviceCode) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim services As DataTable = oService.GetServices(serviceCode).Tables("Services")
            If services Is Nothing OrElse String.IsNullOrEmpty(serviceCode) Then Return
            Dim row As DataRow = services.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim serviceName As String = StringEnteredIn(row, "ServiceName", "Service Name!")
            Dim unitCost As Decimal = DecimalEnteredIn(row, "UnitCost", False)
            Dim unitPrice As Decimal = DecimalEnteredIn(row, "StandardFee", False)
            'Dim standardFee As Decimal = DecimalEnteredIn(row, "StandardFee", "Standard Fee!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvServices
                .Item(Me.ColExTServiceCode.Name, selectedRow).Value = serviceCode.ToUpper()
                .Item(Me.colServiceCode.Name, selectedRow).Value = serviceName
                .Item(Me.ColServiceQty.Name, selectedRow).Value = quantity
                .Item(Me.ColServiceUnitCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                .Item(Me.ColServiceUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            End With

              '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvServices.Item(Me.ColExTServiceCode.Name, selectedRow).Value = Me._ServiceCode.ToUpper()
            Throw ex

        End Try

    End Sub

    

#End Region

#Region " Drugs - Grid "

    Private Sub dgvDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colDrugName.Index OrElse Me.dgvDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDrugs.CurrentCell.RowIndex
        _DrugNameValue = StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugName)


    End Sub

    Private Sub dgvDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDrugs.Item(Me.colDrugsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvDrugs.Item(Me.colDrugNo.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDrugs_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDrugs.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadDrugs(ByVal accountNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvDrugs.Rows.Clear()


            packagesEXT = oPackagesEXT.GetPackagesEXT(accountNo, oItemCategoryID.Drug).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDrugs, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDrugs.Item(Me.colDrugsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvDrugs_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDrugs.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Drugs", "Drug No", "Drug", Me.GetDrugs(), "DrugFullName",
                                                                     "DrugNo", "DrugName", Me.dgvDrugs, Me.colDrugNo, e.RowIndex)

            Me._DrugNo = StringMayBeEnteredIn(Me.dgvDrugs.Rows(e.RowIndex).Cells, Me.colDrugNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvDrugs.Rows(e.RowIndex).IsNewRow Then

                Me.dgvDrugs.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)
            ElseIf Me.colSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub




    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugNo))
            Me.SetDrugsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvDrugs.Item(Me.colDrugsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug No (" + Me._DrugNo + ") can't be edited!")
                Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDrugs.Rows(rowNo).Cells, Me.colDrugNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Drug No (" + enteredItem + ") already selected!")
                        Me.dgvDrugs.Rows.RemoveAt(selectedRow)
                        Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                        Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredDrug(selectedRow)
          
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredDrug(ByVal selectedRow As Integer)
        Try

            Dim drugSelected As String = String.Empty
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()
            Dim drugNo As String = String.Empty
            Dim quantity As Integer = 1
            If Me.dgvDrugs.Rows.Count > 1 Then drugNo = SubstringRight(StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugNo))

            If String.IsNullOrEmpty(drugNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)
            Dim unitCost As Decimal = DecimalEnteredIn(row, "UnitCost", False)
            Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim drugName As String = StringEnteredIn(row, "DrugName", "Drug Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvDrugs
                .Item(Me.colDrugNo.Name, selectedRow).Value = drugNo.ToUpper()
                .Item(Me.colDrugName.Name, selectedRow).Value = drugName
                .Item(Me.ColDrugsUnitCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                .Item(Me.ColDrugsUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.ColDrugQty.Name, selectedRow).Value = quantity

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Sub dgvDrugs_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDrugs.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvDrugs.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then

                If Me.dgvDrugs.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)
               
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

#End Region

#Region " LabTests - Grid "

    Private Sub dgvLabTests_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabTests.CellBeginEdit

        If e.ColumnIndex <> Me.colTestName.Index OrElse Me.dgvLabTests.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
        _TestNameValue = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTestName)

    End Sub

    Private Sub dgvLabTests_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.ColTestNo.Index) Then

                If Me.dgvLabTests.Rows.Count > 1 Then Me.SetLabTestEntries(selectedRow)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvLabTests_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTests.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvLabTests.Item(Me.ColTestNo.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvLabTests_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

  
    Private Sub LoadBillExcludedLabTests(ByVal accountNo As String)

        Dim billExcludedLabTests As DataTable
        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvLabTests.Rows.Clear()

            ' Load items not yet paid for

            billExcludedLabTests = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Test).Tables("BillExcludedItems")

            If billExcludedLabTests Is Nothing OrElse billExcludedLabTests.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabTests, billExcludedLabTests)

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvLabTests_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("LabTests", "Test Code", "Test", Me.GetLabTests(), "TestFullName",
                                                                     "TestCode", "TestName", Me.dgvLabTests, Me.ColTestNo, e.RowIndex)

            Me._TestNo = StringMayBeEnteredIn(Me.dgvLabTests.Rows(e.RowIndex).Cells, Me.ColTestNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColLabSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvLabTests.Rows(e.RowIndex).IsNewRow Then

                Me.dgvLabTests.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetLabTestEntries(e.RowIndex)
             ElseIf Me.ColLabSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetLabTestEntries(e.RowIndex)
              
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SetLabTestEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColTestNo))
            Me.SetLabTestEntries(selectedRow, selectedItem)
           
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetLabTestEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Test No (" + Me._TestNo + ") can't be edited!")
                Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Value = Me._TestNo
                Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowNo).Cells, Me.ColTestNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Test No (" + enteredItem + ") already selected!")
                        Me.dgvLabTests.Rows.RemoveAt(selectedRow)
                        Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Value = Me._TestNo
                        Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredLabTest(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredLabTest(ByVal selectedRow As Integer)
        Try
            Dim quantity As Integer = 1
            Dim oLabTests As New SyncSoft.SQLDb.LabTests
            Dim labTest As String = String.Empty

            If Me.dgvLabTests.Rows.Count > 1 Then labTest = SubstringRight(StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColTestNo))

            If String.IsNullOrEmpty(labTest) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim labTests As DataTable = oLabTests.GetLabTests(labTest).Tables("LabTests")
            If labTests Is Nothing OrElse String.IsNullOrEmpty(labTest) Then Return
            Dim row As DataRow = labTests.Rows(0)
            Dim unitCost As Decimal = DecimalEnteredIn(row, "UnitCost", False)
            Dim unitPrice As Decimal = DecimalEnteredIn(row, "TestFee", False)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim labTestName As String = StringEnteredIn(row, "TestName", "Test Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvLabTests
                .Item(Me.ColTestNo.Name, selectedRow).Value = labTest.ToUpper()
                .Item(Me.colTestName.Name, selectedRow).Value = labTestName
                .Item(Me.ColLabUnitCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                .Item(Me.ColLabUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.ColLabQty.Name, selectedRow).Value = quantity
              
            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvLabTests.Item(Me.ColTestNo.Name, selectedRow).Value = Me._TestNo.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Sub LoadLabTests(ByVal accountNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvLabTests.Rows.Clear()


            packagesEXT = oPackagesEXT.GetPackagesEXT(accountNo, oItemCategoryID.Test).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabTests, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Procedures - Grid "

    Private Sub dgvProcedures_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvProcedures.CellBeginEdit

        If e.ColumnIndex <> Me.colProcedureCode.Index OrElse Me.dgvProcedures.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex
        _ProcedureNameValue = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

    End Sub

    Private Sub dgvProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcedures.CellEndEdit
        Dim quantity As Integer = 1
        Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex
        Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)
        Try

            If e.ColumnIndex.Equals(Me.colProcedureCode.Index) Then

                ' Ensure unique entry in the combo column


                If Me.dgvProcedures.Rows.Count > 1 Then
                    If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                        Dim procedureDisplay As String = (From data In _Procedures _
                                            Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(_ProcedureNameValue.ToUpper()) _
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
                                Dim enteredDisplay As String = (From data In _Procedures _
                                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ProcedureName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Procedure (" + enteredDisplay + ") already entered!")
                                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                    If procedures Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In procedures.Select("ProcedureCode = '" + selectedItem + "'")
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = selectedItem
                        Me.dgvProcedures.Item(Me.ColProcQty.Name, selectedRow).Value = quantity
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvProcedures.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor


            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oPackagesEXT.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvProcedures_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProcedures.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadProcedures(ByVal packageNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for


            packagesEXT = oPackagesEXT.GetPackagesEXT(packageNo, oItemCategoryID.Procedure).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvProcedures, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                Me.dgvProcedures.Item(Me.colProceduresSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        End Try

    End Sub



#End Region

#Region "Extra Charge - Grid"

    Private Sub LoadExtraChargeItems()

        Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ExtraChargeItems
            extraChargeItems = oExtraChargeItems.GetExtraChargeItems().Tables("ExtraChargeItems")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExtraChargeItems, extraChargeItems, "ExtraItemCode", "ExtraItemName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExtraChargeItems(ByVal packageNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvExtraChargeItems.Rows.Clear()




            packagesEXT = oPackagesEXT.GetPackagesEXT(packageNo, oItemCategoryID.Extras).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExtraChargeItems, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvExtraChargeItems.Rows
                If row.IsNewRow Then Exit For
                Me.dgvExtraChargeItems.Item(Me.colExtraChargeItemsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvExtraChargeItems_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvExtraChargeItems.CellBeginEdit
        If e.ColumnIndex <> Me.colExtraChargeItems.Index OrElse Me.dgvExtraChargeItems.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvExtraChargeItems.CurrentCell.RowIndex
        _ExtraChargeItemNameValue = StringMayBeEnteredIn(Me.dgvExtraChargeItems.Rows(selectedRow).Cells, Me.colExtraChargeItems)
    End Sub

    Private Sub dgvExtraChargeItems_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExtraChargeItems.CellEndEdit
        Dim quantity As Integer = 1
        Dim selectedRow As Integer = Me.dgvExtraChargeItems.CurrentCell.RowIndex
        Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvExtraChargeItems.Rows(selectedRow).Cells, Me.colExtraChargeItems)

        Try
            If e.ColumnIndex.Equals(Me.colExtraChargeItems.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvExtraChargeItems.Rows.Count > 1 Then


                    If CBool(Me.dgvExtraChargeItems.Item(Me.colExtraChargeItemsSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _ExtraChargeItems As EnumerableRowCollection(Of DataRow) = extraChargeItems.AsEnumerable()
                        Dim ExtraChargeItemsDisplay As String = (From data In _ExtraChargeItems _
                                            Where data.Field(Of String)("ExtraItemCode").ToUpper().Equals(_ExtraChargeItemNameValue.ToUpper()) _
                                            Select data.Field(Of String)("ExtraItemFullName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Extra Charge Item (" + ExtraChargeItemsDisplay + ") can't be edited!")
                        Me.dgvExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Value = _ExtraChargeItemNameValue
                        Me.dgvExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvExtraChargeItems.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvExtraChargeItems.Rows(rowNo).Cells, Me.colExtraChargeItems)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _ExtraChargeItems As EnumerableRowCollection(Of DataRow) = extraChargeItems.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _ExtraChargeItems _
                                                    Where data.Field(Of String)("ExtraItemCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ExtraItemFullName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Extra Charge Item (" + enteredDisplay + ") already entered!")
                                Me.dgvExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Value = _ExtraChargeItemNameValue
                                Me.dgvExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                    If extraChargeItems Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In extraChargeItems.Select("ExtraItemCode = '" + selectedItem + "'")
                        Me.dgvExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Value = selectedItem
                        Me.dgvExtraChargeItems.Item(Me.ColExtraChargeQty.Name, selectedRow).Value = quantity

                    Next

                End If


            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvExtraChargeItems_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvExtraChargeItems.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvExtraChargeItems_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvExtraChargeItems.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor


            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvExtraChargeItems.Item(Me.colExtraChargeItemsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvExtraChargeItems.Item(Me.colExtraChargeItems.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Extras
            End With

            DisplayMessage(oPackagesEXT.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


#End Region

#Region " Consumables - Grid "

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.ColConsumableNo.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _ConsumableItemValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableNo)

    End Sub

    Private Function GetConsumables() As DataTable

        Dim consumables As DataTable
        Dim oSetupData As New SetupData()
        Dim oconsumables As New SyncSoft.SQLDb.ConsumableItems

        Try

            ' Load from Consumable Items

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumables = oconsumables.GetConsumableItems.Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumables
            Else : consumables = oSetupData.ConsumableItems
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return consumables
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function
    Private Sub dgvConsumables_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("ConsumableItems", "Consumable No", "Consumable", Me.GetConsumables(), "ConsumableFullName",
                                                                     "ConsumableNo", "ConsumableName", Me.dgvConsumables, Me.ColConsumableNo, e.RowIndex)

            Me._ConsumableNo = StringMayBeEnteredIn(Me.dgvConsumables.Rows(e.RowIndex).Cells, Me.ColConsumableNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColConsSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvConsumables.Rows(e.RowIndex).IsNewRow Then

                Me.dgvConsumables.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)

            ElseIf Me.ColConsSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub



    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.ColConsumableNo.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)


            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub


    Private Sub SetConsumableEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableNo))

            Me.SetConsumableEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetConsumableEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Consumable No (" + Me._ConsumableNo + ") can't be edited!")
                Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Value = Me._ConsumableNo
                Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.ColConsumableNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Consumable No (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Rows.RemoveAt(selectedRow)
                        Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Value = Me._ConsumableNo
                        Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DetailConsumableItem(selectedRow)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

       
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim packageNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.ColConsumableNo.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oPackagesEXT
                .PackageNo = packageNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub dgvConsumables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvConsumables.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailConsumableItem(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then selectedItem = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim consumableNo As String = (selectedItem)
            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
            If consumableItems Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = consumableItems.Rows(0)
            Dim consumableName As String = StringEnteredIn(row, "ConsumableName", "Consumable Name!")
            Dim quantity As Integer = 1
            Dim unitCost As Decimal = DecimalEnteredIn(row, "UnitCost", False)
            Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)


            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvConsumables
                .Item(Me.ColConsumableNo.Name, selectedRow).Value = consumableNo.ToUpper()
                .Item(Me.colConsumableQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colConsumableName.Name, selectedRow).Value = consumableName
                .Item(Me.ColConsumableUnitCost.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                .Item(Me.ColConsumableUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumableItems Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            With Me.dgvConsumables

            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadConsumables(ByVal accountNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()


            packagesEXT = oPackagesEXT.GetPackagesEXT(accountNo, oItemCategoryID.Consumable).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub



#End Region

#Region " Radiology - Grid "

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colExamCode.Sorted = False
            LoadComboData(Me.colExamCode, radiologyExaminations, "ExamCode", "ExamName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvRadiology_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRadiology.CellBeginEdit

        If e.ColumnIndex <> Me.colExamCode.Index OrElse Me.dgvRadiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex
        _RadiologyNameValue = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamCode)

    End Sub

    Private Sub dgvRadiology_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRadiology.CellEndEdit
        Dim quantity As Integer = 1
        Try

            If e.ColumnIndex.Equals(Me.colExamCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvRadiology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamCode)

                    If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Radiology As EnumerableRowCollection(Of DataRow) = radiologyExaminations.AsEnumerable()
                        Dim radiologyDisplay As String = (From data In _Radiology _
                                            Where data.Field(Of String)("ExamCode").ToUpper().Equals(_RadiologyNameValue.ToUpper()) _
                                            Select data.Field(Of String)("ExamName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Radiology (" + radiologyDisplay + ") can't be edited!")
                        Me.dgvRadiology.Item(Me.colExamCode.Name, selectedRow).Value = _RadiologyNameValue
                        Me.dgvRadiology.Item(Me.colExamCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(rowNo).Cells, Me.colExamCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Radiology As EnumerableRowCollection(Of DataRow) = radiologyExaminations.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Radiology _
                                                    Where data.Field(Of String)("ExamCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ExamName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Radiology (" + enteredDisplay + ") already entered!")
                                Me.dgvRadiology.Item(Me.colExamCode.Name, selectedRow).Value = _RadiologyNameValue
                                Me.dgvRadiology.Item(Me.colExamCode.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next



                    If radiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In radiologyExaminations.Select("ExamCode = '" + selectedItem + "'")
                        Me.dgvRadiology.Item(Me.colExamCode.Name, selectedRow).Value = selectedItem
                        Me.dgvRadiology.Item(Me.ColRadiologyQty.Name, selectedRow).Value = quantity
                    Next

                End If
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvRadiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvRadiology.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvRadiology.Item(Me.colExamCode.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvRadiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRadiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadPackageRadiology(ByVal packageNo As String)


        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try

            Me.dgvRadiology.Rows.Clear()


            packagesEXT = oPackagesEXT.GetPackagesEXT(packageNo, oItemCategoryID.Radiology).Tables("PackagesEXT")


            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvRadiology, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                Me.dgvRadiology.Item(Me.colRadiologySaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region "Dental Services -Grid"

    Private Sub dgvDentalServices_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDentalServices.CellBeginEdit
        If e.ColumnIndex <> Me.colDentalCode.Index OrElse Me.dgvDentalServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDentalServices.CurrentCell.RowIndex
        _DentalServiceValue = StringMayBeEnteredIn(Me.dgvDentalServices.Rows(selectedRow).Cells, Me.colDentalCode)

    End Sub

    Private Sub dgvDentalServices_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDentalServices.CellEndEdit

        Dim quantity As Integer = 1
        Try

            If e.ColumnIndex.Equals(Me.colDentalCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvDentalServices.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvDentalServices.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDentalServices.Rows(selectedRow).Cells, Me.colDentalCode)

                    If CBool(Me.dgvDentalServices.Item(Me.colDentalServicesSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _dental As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                        Dim dentalServicesDisplay As String = (From data In _dental _
                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(_DentalServiceValue.ToUpper()) _
                                            Select data.Field(Of String)("DentalName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Dental Services (" + dentalServicesDisplay + ") can't be edited!")
                        Me.dgvDentalServices.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalServiceValue
                        Me.dgvDentalServices.Item(Me.colDentalCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvDentalServices.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDentalServices.Rows(rowNo).Cells, Me.colDentalCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _dental As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _dental _
                                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("DentalName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Dental Services (" + enteredDisplay + ") already entered!")
                                Me.dgvDentalServices.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalServiceValue
                                Me.dgvDentalServices.Item(Me.colDentalCode.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                    If dentalServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In dentalServices.Select("DentalCode = '" + selectedItem + "'")
                        Me.dgvDentalServices.Item(Me.colDentalCode.Name, selectedRow).Value = selectedItem
                        Me.dgvDentalServices.Item(Me.ColDentalQty.Name, selectedRow).Value = quantity
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvDentalServices_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDentalServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvDentalServices_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDentalServices.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDentalServices.Item(Me.colDentalServicesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvDentalServices.Item(Me.colDentalCode.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPackageDentalServices(ByVal packageNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvDentalServices.Rows.Clear()

            packagesEXT = oPackagesEXT.GetPackagesEXT(packageNo, oItemCategoryID.Dental).Tables("PackagesEXT")


            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDentalServices, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvDentalServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDentalServices.Item(Me.colDentalServicesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex



        End Try

    End Sub



#End Region

#Region "Optical Services -Grid"

    Private Sub dgvOpticalServices_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvOpticalServices.CellBeginEdit
        If e.ColumnIndex <> Me.colOpticalCode.Index OrElse Me.dgvOpticalServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvOpticalServices.CurrentCell.RowIndex
        _OpticalServiceValue = StringMayBeEnteredIn(Me.dgvOpticalServices.Rows(selectedRow).Cells, Me.colOpticalCode)

    End Sub

    Private Sub dgvOpticalServices_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpticalServices.CellEndEdit

        Dim quantity As Integer = 1

        Try

            If e.ColumnIndex.Equals(Me.colOpticalCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvOpticalServices.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvOpticalServices.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvOpticalServices.Rows(selectedRow).Cells, Me.colOpticalCode)

                    If CBool(Me.dgvOpticalServices.Item(Me.colOpticalSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                        Dim OpticalServicesDisplay As String = (From data In _OpticalServices _
                                            Where data.Field(Of String)("OpticalCode").ToUpper().Equals(_OpticalServiceValue.ToUpper()) _
                                            Select data.Field(Of String)("OpticalName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Optical Name (" + OpticalServicesDisplay + ") can't be edited!")
                        Me.dgvOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalServiceValue
                        Me.dgvOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvOpticalServices.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvOpticalServices.Rows(rowNo).Cells, Me.colOpticalCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _OpticalServices _
                                                    Where data.Field(Of String)("OpticalCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("OpticalName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Optical Name (" + enteredDisplay + ") already entered!")
                                Me.dgvOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalServiceValue
                                Me.dgvOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                    If opticalServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In opticalServices.Select("OpticalCode = '" + selectedItem + "'")
                        Me.dgvOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Value = selectedItem
                        Me.dgvOpticalServices.Item(Me.ColOpticalQty.Name, selectedRow).Value = quantity
                    Next
                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub dgvOpticalServices_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvOpticalServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvOpticalServices_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvOpticalServices.UserDeletingRow
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvOpticalServices.Item(Me.colOpticalSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvOpticalServices.Item(Me.colOpticalCode.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Optical
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadPackageOpticalServices(ByVal packageNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvOpticalServices.Rows.Clear()

            packagesEXT = oPackagesEXT.GetPackagesEXT(packageNo, oItemCategoryID.Optical).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOpticalServices, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvOpticalServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOpticalServices.Item(Me.colOpticalSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    
#End Region

#Region "Pathology -Grid"

    Private Sub dgvPathology_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPathology.CellBeginEdit
        If e.ColumnIndex <> Me.colPathologyExamFullName.Index OrElse Me.dgvPathology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPathology.CurrentCell.RowIndex
        _PathologyValue = StringMayBeEnteredIn(Me.dgvPathology.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

    End Sub

    Private Sub dgvPathology_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPathology.CellEndEdit
        Dim quantity As Integer = 1
        Try

            If e.ColumnIndex.Equals(Me.colPathologyExamFullName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvPathology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvPathology.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPathology.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

                    If CBool(Me.dgvPathology.Item(Me.colPathologySaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Pathology As EnumerableRowCollection(Of DataRow) = pathologyExaminations.AsEnumerable()
                        Dim pathologyDisplay As String = (From data In _Pathology _
                                            Where data.Field(Of String)("ExamCode").ToUpper().Equals(_PathologyValue.ToUpper()) _
                                            Select data.Field(Of String)("ExamName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Pathology (" + pathologyDisplay + ") can't be edited!")
                        Me.dgvPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _PathologyValue
                        Me.dgvPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvPathology.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPathology.Rows(rowNo).Cells, Me.colPathologyExamFullName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Pathologys As EnumerableRowCollection(Of DataRow) = pathologyExaminations.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Pathologys _
                                                    Where data.Field(Of String)("ExamCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ExamName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Pathology (" + enteredDisplay + ") already entered!")
                                Me.dgvPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _PathologyValue
                                Me.dgvPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                    If pathologyExaminations Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In pathologyExaminations.Select("ExamCode = '" + selectedItem + "'")
                        Me.dgvPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = selectedItem
                        Me.dgvPathology.Item(Me.ColPathologyQuantity.Name, selectedRow).Value = quantity
                    Next
                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvPathology_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPathology.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPathology.Item(Me.colPathologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvPathology.Item(Me.colPathologyExamFullName.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Pathology
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPathology_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPathology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadPackagePathology(ByVal packageNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPathology.Rows.Clear()


            packagesEXT = oPackagesEXT.GetPackagesEXT(packageNo, oItemCategoryID.Pathology).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPathology, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvPathology.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPathology.Item(Me.colPathologySaved.Name, row.Index).Value = True
            Next



        Catch ex As Exception
            Throw ex

        End Try

    End Sub


#End Region

#Region " Theatre - Grid "

    Private Sub dgvTheatre_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTheatre.CellBeginEdit

        If e.ColumnIndex <> Me.colTheatreCode.Index OrElse Me.dgvTheatre.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
        _TheatreNameValue = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

    End Sub

    Private Sub dgvTheatre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellEndEdit

        Try
            Dim quantity As Integer = 1
            Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            If e.ColumnIndex.Equals(Me.colTheatreCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvTheatre.Rows.Count > 1 Then

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

                    If theatreServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In theatreServices.Select("TheatreCode = '" + selectedItem + "'")
                        Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = selectedItem
                        Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, selectedRow).Value = quantity
                    Next
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub dgvTheatre_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTheatre.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadTheatreServices()

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TheatreServices

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTheatreCode.Sorted = False
            LoadComboData(Me.colTheatreCode, theatreServices, "TheatreCode", "TheatreName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
 
    Private Sub dgvTheatre_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))
            Dim itemCode As String = CStr(Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, toDeleteRowNo).Value)

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
            With oPackagesEXT
                .PackageNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With

            DisplayMessage(oPackagesEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPackageTheatreServices(ByVal packageNo As String)

        Dim packagesEXT As DataTable
        Dim oPackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvTheatre.Rows.Clear()

            packagesEXT = oPackagesEXT.GetPackagesEXT(packageNo, oItemCategoryID.Theatre).Tables("PackagesEXT")

            If packagesEXT Is Nothing OrElse packagesEXT.Rows.Count < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTheatre, packagesEXT)

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region


    Private Function PackageServicesList() As List(Of DBConnect)

        Dim lPackageServicesList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvServices.RowCount - 2

                Using oPackageServices As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvServices.Rows(rowNo).Cells

                    With oPackageServices

                        .PackageNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.ColExTServiceCode, "Service Code!")
                        .ItemCategoryID = oItemCategoryID.Service
                        .Quantity = IntegerEnteredIn(cells, Me.ColServiceQty, "Service Quantity")
                        .UnitCost = DecimalEnteredIn(cells, Me.ColServiceUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColServiceUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageServicesList.Add(oPackageServices)

                End Using

            Next

            Return lPackageServicesList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageDrugsList() As List(Of DBConnect)

        Dim lPackageDrugsList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2

                Using oPackageDrugs As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvDrugs.Rows(rowNo).Cells

                    With oPackageDrugs

                        .PackageNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colDrugNo, "Drug Code!")
                        .ItemCategoryID = oItemCategoryID.Drug
                        .Quantity = IntegerEnteredIn(cells, Me.ColDrugQty, "Drug Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, ColDrugsUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColDrugsUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageDrugsList.Add(oPackageDrugs)

                End Using

            Next

            Return lPackageDrugsList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageConsumablesList() As List(Of DBConnect)

        Dim lPackageConsumableList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Using oPackageConsumables As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    With oPackageConsumables

                        .PackageNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.ColConsumableNo, "Consumable Code!")
                        .ItemCategoryID = oItemCategoryID.Consumable
                        .Quantity = IntegerEnteredIn(cells, Me.colConsumableQuantity, "Consumable Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, ColConsumableUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColConsumableUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageConsumableList.Add(oPackageConsumables)

                End Using

            Next

            Return lPackageConsumableList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageLabTestsList() As List(Of DBConnect)

        Dim lPackageLabTestsList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Using oPackageLabTests As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                    With oPackageLabTests

                        .PackageNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.ColTestNo, "Test Code!")
                        .ItemCategoryID = oItemCategoryID.Test
                        .Quantity = IntegerEnteredIn(cells, Me.ColLabQty, "Lab Test Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, ColLabUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColLabUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageLabTestsList.Add(oPackageLabTests)

                End Using

            Next

            Return lPackageLabTestsList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageProceduresList() As List(Of DBConnect)

        Dim lPackageProceduresList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Using olPackageProcedures As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                    With olPackageProcedures

                        .PackageNo = accountNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colProcedureCode))
                        .ItemCategoryID = oItemCategoryID.Procedure
                        .Quantity = IntegerEnteredIn(cells, Me.ColProcQty, "Procedure Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, colProcedureUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, colProcedureUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageProceduresList.Add(olPackageProcedures)

                End Using

            Next

            Return lPackageProceduresList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageExtraChargeList() As List(Of DBConnect)

        Dim lPackageExtraChargeList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvExtraChargeItems.RowCount - 2

                Using oPackageExtraCharge As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvExtraChargeItems.Rows(rowNo).Cells

                    With oPackageExtraCharge

                        .PackageNo = accountNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExtraChargeItems))
                        .ItemCategoryID = oItemCategoryID.Extras
                        .Quantity = IntegerEnteredIn(cells, Me.ColExtraChargeQty, "Extra Charge Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, colExtraChargeUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColExtraChargeUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageExtraChargeList.Add(oPackageExtraCharge)

                End Using

            Next

            Return lPackageExtraChargeList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageRadiologyList() As List(Of DBConnect)

        Dim lPackageRadiologyList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Using olPackageRadiology As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                    With olPackageRadiology

                        .PackageNo = accountNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExamCode))
                        .ItemCategoryID = oItemCategoryID.Radiology
                        .Quantity = IntegerEnteredIn(cells, Me.ColRadiologyQty, "Radiology Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, colExamUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, colExamUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageRadiologyList.Add(olPackageRadiology)

                End Using

            Next

            Return lPackageRadiologyList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageDentalServicesList() As List(Of DBConnect)

        Dim lPackageDentalServicesList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvDentalServices.RowCount - 2

                Using olPackageDentalServices As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvDentalServices.Rows(rowNo).Cells

                    With olPackageDentalServices

                        .PackageNo = accountNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDentalCode))
                        .ItemCategoryID = oItemCategoryID.Dental
                        .Quantity = IntegerEnteredIn(cells, Me.ColDentalQty, "Dental Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, ColDentalUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColDentalUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageDentalServicesList.Add(olPackageDentalServices)

                End Using

            Next

            Return lPackageDentalServicesList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackageOpticalServicesList() As List(Of DBConnect)

        Dim lPackageOpticalServicesList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvOpticalServices.RowCount - 2

                Using olPackageOpticalServices As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvOpticalServices.Rows(rowNo).Cells

                    With olPackageOpticalServices

                        .PackageNo = accountNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colOpticalCode))
                        .ItemCategoryID = oItemCategoryID.Optical
                        .Quantity = IntegerEnteredIn(cells, Me.ColOpticalQty, "Optical Quantity!")
                        .UnitCost = DecimalEnteredIn(cells, ColOpticalUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColOpticalUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackageOpticalServicesList.Add(olPackageOpticalServices)

                End Using

            Next

            Return lPackageOpticalServicesList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function PackagePathologyList() As List(Of DBConnect)

        Dim lPackagePathologyList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvPathology.RowCount - 2

                Using oPackagePathology As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvPathology.Rows(rowNo).Cells

                    With oPackagePathology

                        .PackageNo = accountNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colPathologyExamFullName, "Pathology Code!"))
                        .ItemCategoryID = oItemCategoryID.Pathology
                        .Quantity = IntegerEnteredIn(cells, Me.ColPathologyQuantity, "Pathology Quantity")
                        .UnitCost = DecimalEnteredIn(cells, ColPathologyUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColPathologyUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackagePathologyList.Add(oPackagePathology)

                End Using

            Next

            Return lPackagePathologyList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function TheatreServicesList() As List(Of DBConnect)

        Dim lPackagePathologyList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Using oTheatreServices As New SyncSoft.SQLDb.PackagesEXT

                    Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                    With oTheatreServices

                        .PackageNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colICDTheatreCode, "Theatre Code!")
                        .ItemCategoryID = oItemCategoryID.Theatre
                        .Quantity = IntegerEnteredIn(cells, Me.colTheatreQuantity, "Theatre Quantity")
                        .UnitCost = DecimalEnteredIn(cells, ColTheatreUnitCost, False, "Unit Cost")
                        .UnitPrice = DecimalEnteredIn(cells, ColTheatreUnitPrice, False, "Unit Price")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lPackagePathologyList.Add(oTheatreServices)

                End Using

            Next

            Return lPackagePathologyList

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oPackages As New SyncSoft.SQLDb.Packages()

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim lPackages As New List(Of DBConnect)
        Dim itemCode As String = SubstringRight(RevertText(StringEnteredIn(Me.CboPackageNo, "Package No!"))).ToUpper()
        Dim itemCategoryID As String = oItemCategoryID.Packages
        Try
            Me.Cursor = Cursors.WaitCursor()

            With oPackages

                .PackageNo = itemCode
                .PackageName = StringEnteredIn(Me.stbPackageName, "Package Name!")
                .UnitPrice = Me.nbxUnitPrice.GetDecimal(False)
                .UnitCost = Me.nbxUnitCost.GetDecimal(False)
                .ExpiryDays = Me.nbxExpiryNos.GetInteger
                .RevenueStreamCode = StringValueMayBeEnteredIn(Me.cboRevenueStreamID)
                .Hidden = Me.chkHidden.Checked
                .MonitorQty = Me.chkMonitorQuanties.Checked
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lPackages.Add(oPackages)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            OpenBillableMappings(ebnSaveUpdate.ButtonText, oItemCategoryID.Packages, itemCode)
            Select Case Me.ebnSaveUpdate.ButtonText
                 
                Case ButtonCaption.Save

                    transactions.Add(New TransactionList(Of DBConnect)(lPackages, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageConsumablesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageExtraChargeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageProceduresList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageLabTestsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageRadiologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageDentalServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageOpticalServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackagePathologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(TheatreServicesList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgServices)
                    ResetControlsIn(Me.tpgDrugs)
                    ResetControlsIn(Me.tpgLabTests)
                    ResetControlsIn(Me.tpgProcedures)
                    ResetControlsIn(Me.tpgExtraChargeItems)
                    ResetControlsIn(Me.tpgRadiologyExaminations)
                    ResetControlsIn(Me.tpgConsumables)
                    ResetControlsIn(Me.tpgDentalServices)
                    ResetControlsIn(Me.tpgOpticalServices)
                    ResetControlsIn(Me.tpgPathology)
                    ResetControlsIn(Me.tpgTheatreServices)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetNextPackageID()

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lPackages, Action.Update))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageConsumablesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageExtraChargeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageProceduresList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageLabTestsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageRadiologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageDentalServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackageOpticalServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PackagePathologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(TheatreServicesList, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()


                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgServices)
                    ResetControlsIn(Me.tpgDrugs)
                    ResetControlsIn(Me.tpgLabTests)
                    ResetControlsIn(Me.tpgProcedures)
                    ResetControlsIn(Me.tpgExtraChargeItems)
                    ResetControlsIn(Me.tpgRadiologyExaminations)
                    ResetControlsIn(Me.tpgConsumables)
                    ResetControlsIn(Me.tpgDentalServices)
                    ResetControlsIn(Me.tpgOpticalServices)
                    ResetControlsIn(Me.tpgPathology)
                    ResetControlsIn(Me.tpgTheatreServices)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvServices.RowCount - 2
                Me.dgvServices.Item(Me.colServicesSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2
                Me.dgvDrugs.Item(Me.colDrugsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2
                Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2
                Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvExtraChargeItems.RowCount - 2
                Me.dgvExtraChargeItems.Item(Me.colExtraChargeItemsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2
                Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2
                Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value = True
            Next


            For rowNo As Integer = 0 To Me.dgvDentalServices.RowCount - 2
                Me.dgvDentalServices.Item(Me.colDentalServicesSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvPathology.RowCount - 2
                Me.dgvPathology.Item(Me.colPathologySaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvOpticalServices.RowCount - 2
                Me.dgvOpticalServices.Item(Me.colOpticalSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
            Next
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
        Me.LoadPackages(True)
        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.LoadPackages(False)
        ResetControlsIn(Me)
        Me.SetNextPackageID()
    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0
            Security.Apply(Me.nbxUnitPrice, AccessRights.Update)
            Security.Apply(Me.nbxUnitCost, AccessRights.Update)

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

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

    Private Sub CboPackageNo_Leave(sender As System.Object, e As System.EventArgs) Handles CboPackageNo.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbPackageName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(CboPackageNo)))
            Me.CboPackageNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(CboPackageNo)))
        End If
    End Sub


#Region " SET AUTONUMBERS"

    Private Sub SetNextPackageID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oPackages As New SyncSoft.SQLDb.Packages()
            Dim oVariousOption As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Packages", "PackageNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim PackageNoPrefix As String = oVariousOption.PackageNoPrefix
            Dim nextPackageNo As String = CStr(oPackages.GetNextPackageID).PadLeft(paddingLEN, paddingCHAR)
            Me.CboPackageNo.Text = FormatText((PackageNoPrefix + nextPackageNo).Trim(), "Packages", "PackageNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region
End Class