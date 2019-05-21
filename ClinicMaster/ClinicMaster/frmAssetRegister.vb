
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects


Public Class frmAssetRegister

#Region " Fields "
    Private suppliers As DataTable
#End Region

    Private Sub frmAssetRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboAssetSourceID, LookupObjects.AssetSource, False)
            LoadLookupDataCombo(Me.cboAssetCategoryID, LookupObjects.AssetCategory, False)
            LoadLookupDataCombo(Me.cboDeptID, LookupObjects.Department, False)
            LoadLookupDataCombo(Me.cboDepreciationMethodID, LookupObjects.DepreciationMethod, False)
            Me.LoadSuppliers()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadSuppliers()

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Suppliers

            suppliers = oSuppliers.GetSuppliers().Tables("Suppliers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboSupplierNo, suppliers, "SupplierFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmAssetRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oAssetRegister As New SyncSoft.SQLDb.AssetRegister()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oAssetRegister.SerialNo = StringEnteredIn(Me.stbSerialNo, "SerialNo!")

            DisplayMessage(oAssetRegister.Delete())
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

        Dim serialNo As String

        Dim oAssetRegister As New SyncSoft.SQLDb.AssetRegister()

        Try
            Me.Cursor = Cursors.WaitCursor()

            serialNo = StringEnteredIn(Me.stbSerialNo, "SerialNo!")

            Dim dataSource As DataTable = oAssetRegister.GetAssetRegister(serialNo).Tables("AssetRegister")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oAssetRegister As New SyncSoft.SQLDb.AssetRegister()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oAssetRegister

                .SerialNo = StringEnteredIn(Me.stbSerialNo, "Serial No!")
                .ManufacturerID = StringMayBeEnteredIn(Me.stbManufacturerID)
                .InstitutionalID = StringMayBeEnteredIn(Me.stbInstitutionalID)
                .Photo = BytesMayBeEnteredIn(Me.spbPhoto)
                .AssetSourceID = StringValueEnteredIn(Me.cboAssetSourceID, "Source!")
                .AssetCategoryID = StringValueEnteredIn(Me.cboAssetCategoryID, "Asset Category!")
                .DeptID = StringValueEnteredIn(Me.cboDeptID, "Department!")
                .ItemDescription = StringEnteredIn(Me.stbItemDescription, "Description!")
                .Brand = StringMayBeEnteredIn(Me.stbBrand)
                .Quantity = Me.nbxValue.GetInteger()
                .Value = Me.nbxQuantity.GetInteger()
                .DateOfPurchase = DateMayBeEnteredIn(Me.dtpDateOfPurchase)
                .SupplierNo = SubstringEnteredIn(Me.cboSupplierNo, "Supplier!")
                .InvoiceNo = StringMayBeEnteredIn(Me.stbInvoiceNo)
                .InvoiceDate = DateMayBeEnteredIn(Me.dtpInvoiceDate)
                .DateOfDelivery = DateMayBeEnteredIn(Me.dtpDateOfDelivery)
                .SalvageValue = Me.nbxSalvageValue.GetInteger()
                .DepreciationRate = Me.nbxDepreciationRate.GetInteger()
                .UsefulLife = Me.nbxUsefulLife.GetInteger()
                .DepreciationMethodID = StringValueEnteredIn(Me.cboDepreciationMethodID, "Depreciation Method!")
                .DepreciationStartDate = DateMayBeEnteredIn(Me.dtpDepreciationStartDate)
                .AssignedTo = StringEnteredIn(Me.stbAssignedTo, "AssignedTo!")
                .Location = StringMayBeEnteredIn(Me.stbLocation)
                .ServicingSchedule = Me.nbxServicingSchedule.GetInteger()
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oAssetRegister.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oAssetRegister.Update())
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

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

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

    Private Sub btnLoadPhoto_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPhoto.Click
        Me.spbPhoto.LoadPhoto(Me.spbPhoto.ImageSizeLimit)
    End Sub

    Private Sub btnClearPhoto_Click(sender As System.Object, e As System.EventArgs) Handles btnClearPhoto.Click
        Me.spbPhoto.DeletePhoto()
    End Sub




End Class