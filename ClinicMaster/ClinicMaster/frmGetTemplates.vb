
Option Strict On

Imports System.Text

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmGetTemplates

#Region " Fields "
    Private templateTypeID As String
    Private templateNoControl As Control
    Private _AllowSelectMultiple As Boolean = False
#End Region

    Private Sub frmGetTemplates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()

        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colInclude.Visible = Me._AllowSelectMultiple
            Me.fbnOK.Visible = Me._AllowSelectMultiple
            Me.lblMessage.Visible = Not Me._AllowSelectMultiple
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If templateTypeID.ToUpper().Equals(oTemplateTypeID.LabResults.ToUpper()) Then
                Me.Text = "Lab Results Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.RadiologyReports.ToUpper()) Then
                Me.Text = "Radiology Reports Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.PathologyReports.ToUpper()) Then
                Me.Text = "Pathology Reports Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.PresentingComplaint.ToUpper()) Then
                Me.Text = "Presenting Complaints Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.ClinicalNotes.ToUpper()) Then
                Me.Text = "Clinical Notes Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.ROS.ToUpper()) Then
                Me.Text = "ROS Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.PMH.ToUpper()) Then
                Me.Text = "PMH/PSH Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.POH.ToUpper()) Then
                Me.Text = "POH Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.PGH.ToUpper()) Then
                Me.Text = "PGH Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.FSH.ToUpper()) Then
                Me.Text = "FSH Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.GeneralAppearance.ToUpper()) Then
                Me.Text = "General Appearance Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.Respiratory.ToUpper()) Then
                Me.Text = "Respiratory Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.CVS.ToUpper()) Then
                Me.Text = "CVS Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.ENT.ToUpper()) Then
                Me.Text = "ENT Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.Abdomen.ToUpper()) Then
                Me.Text = "Abdomen And GUT Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.CNS.ToUpper()) Then
                Me.Text = "CNS Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.EYE.ToUpper()) Then
                Me.Text = "EYE Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.MuscularSkeletal.ToUpper()) Then
                Me.Text = "Muscular skeletal Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.Skin.ToUpper()) Then
                Me.Text = "Skin and Others Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.PV.ToUpper()) Then
                Me.Text = "PV/PR Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.PsychologicalStatus.ToUpper()) Then
                Me.Text = "Psychological Status Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.ProvisionalDiagnosis.ToUpper()) Then
                Me.Text = "Provisional Diagnosis Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.TreatmentPlan.ToUpper()) Then
                Me.Text = "Treatment Plan Template"
            ElseIf templateTypeID.ToUpper().Equals(oTemplateTypeID.MedicalConditions.ToUpper()) Then
                Me.Text = "Medical Conditions Template"
            Else : Me.Text = "Get Template"
            End If

            Me.ShowTemplates()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowTemplates()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTemplates As New SyncSoft.SQLDb.Templates()

            ' Load from Templates

            Dim templates As DataTable = oTemplates.GetTemplatesByTemplateType(templateTypeID).Tables("Templates")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If templates Is Nothing OrElse templates.Rows.Count < 1 Then
                DisplayMessage("No template registered for " + GetLookupDataDes(templateTypeID))
            End If
            LoadGridData(Me.dgvTemplates, templates)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTemplates_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemplates.CellClick
        With Me.dgvTemplates
            .Item(Me.colInclude.Name, e.RowIndex).Value = Not CBool(.Item(Me.colInclude.Name, e.RowIndex).Value)
        End With
    End Sub

    Private Sub dgvTemplates_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemplates.CellDoubleClick

        Try

            If Me._AllowSelectMultiple Then Return

            Dim notes As String = Me.dgvTemplates.Item(Me.colNotes.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.templateNoControl Is TextBox Then
                CType(Me.templateNoControl, TextBox).Text = notes
                CType(Me.templateNoControl, TextBox).Focus()

            ElseIf TypeOf Me.templateNoControl Is SmartTextBox Then
                CType(Me.templateNoControl, SmartTextBox).Text = notes
                CType(Me.templateNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.templateNoControl Is ComboBox Then
                CType(Me.templateNoControl, ComboBox).Text = notes
                CType(Me.templateNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub fbnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles fbnAddNew.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim fTemplates As New frmTemplates(templateTypeID)
            fTemplates.ShowDialog()
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowTemplates()
            ''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnOK_Click(sender As System.Object, e As System.EventArgs) Handles fbnOK.Click

        Try

            Dim splitChar As Char = ","c
            Dim template As New StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvTemplates.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTemplates.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvTemplates.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one template entry!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvTemplates.RowCount - 1
                If CBool(Me.dgvTemplates.Item(Me.colInclude.Name, rowNo).Value) = True Then
                    Dim cells As DataGridViewCellCollection = Me.dgvTemplates.Rows(rowNo).Cells
                    Dim notes As String = cells.Item(Me.colNotes.Name).Value.ToString()
                    If Not String.IsNullOrEmpty(notes) Then template.Append(notes + splitChar + " ")
                End If
            Next

            If template.Length > 2 Then template.Remove(template.Length - 2, 2)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If TypeOf Me.templateNoControl Is TextBox Then
                If String.IsNullOrEmpty(CType(Me.templateNoControl, TextBox).Text.Trim()) Then
                    CType(Me.templateNoControl, TextBox).Text = template.ToString()
                Else : CType(Me.templateNoControl, TextBox).Text += ControlChars.NewLine + template.ToString()
                End If
                CType(Me.templateNoControl, TextBox).Focus()

            ElseIf TypeOf Me.templateNoControl Is SmartTextBox Then
                If String.IsNullOrEmpty(CType(Me.templateNoControl, SmartTextBox).Text.Trim()) Then
                    CType(Me.templateNoControl, SmartTextBox).Text = template.ToString()
                Else : CType(Me.templateNoControl, SmartTextBox).Text += ControlChars.NewLine + template.ToString()
                End If
                CType(Me.templateNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.templateNoControl Is ComboBox Then
                If String.IsNullOrEmpty(CType(Me.templateNoControl, ComboBox).Text.Trim()) Then
                    CType(Me.templateNoControl, ComboBox).Text = template.ToString()
                Else : CType(Me.templateNoControl, ComboBox).Text += ControlChars.NewLine + template.ToString()
                End If
                CType(Me.templateNoControl, ComboBox).Focus()

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cmsTemplateList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsTemplateList.Opening

        If Me.dgvTemplates.ColumnCount < 1 OrElse Me.dgvTemplates.RowCount < 1 Then
            Me.cmsTemplateListCopy.Enabled = False
            Me.cmsTemplateListSelectAll.Enabled = False
        Else
            Me.cmsTemplateListCopy.Enabled = True
            Me.cmsTemplateListSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsTemplateListCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsTemplateListCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvTemplates.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvTemplates))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsTemplateListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsTemplateListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvTemplates.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class