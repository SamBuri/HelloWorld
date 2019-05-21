
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHCTClientCard : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
End Sub

'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHCTClientCard))
        Me.cboDistrictsID = New System.Windows.Forms.ComboBox()
        Me.clbNoConsentReason = New System.Windows.Forms.CheckedListBox()
        Me.cboHealthUnitCode = New System.Windows.Forms.ComboBox()
        Me.stbHSD = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCenterTypeID = New System.Windows.Forms.ComboBox()
        Me.cboTestingPointID = New System.Windows.Forms.ComboBox()
        Me.cboAccompaniedByID = New System.Windows.Forms.ComboBox()
        Me.cboConsentID = New System.Windows.Forms.ComboBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblDistrictsID = New System.Windows.Forms.Label()
        Me.lblHealthUnitCode = New System.Windows.Forms.Label()
        Me.lblHSD = New System.Windows.Forms.Label()
        Me.lblCenterTypeID = New System.Windows.Forms.Label()
        Me.lblTestingPointID = New System.Windows.Forms.Label()
        Me.lblAccompaniedByID = New System.Windows.Forms.Label()
        Me.lblConsentID = New System.Windows.Forms.Label()
        Me.lblNoConsentReasonID = New System.Windows.Forms.Label()
        Me.tbcHCTClientCard = New System.Windows.Forms.TabControl()
        Me.tpgSectionAB = New System.Windows.Forms.TabPage()
        Me.clbKnowAboutServiceID = New System.Windows.Forms.CheckedListBox()
        Me.cboPatnerTypeID = New System.Windows.Forms.ComboBox()
        Me.lblPatnerTypeID = New System.Windows.Forms.Label()
        Me.cboPatnerResultID = New System.Windows.Forms.ComboBox()
        Me.lblPatnerResultID = New System.Windows.Forms.Label()
        Me.lblKnowAboutServiceID = New System.Windows.Forms.Label()
        Me.lblPatnerTestedHIVID = New System.Windows.Forms.Label()
        Me.cboPatnerTestedHIVID = New System.Windows.Forms.ComboBox()
        Me.cboResultThreeMonthsID = New System.Windows.Forms.ComboBox()
        Me.lblNoTestsInTwelveMonthsID = New System.Windows.Forms.Label()
        Me.lblResultThreeMonthsID = New System.Windows.Forms.Label()
        Me.cboNoTestsInTwelveMonthsID = New System.Windows.Forms.ComboBox()
        Me.cboResultSixMonthsID = New System.Windows.Forms.ComboBox()
        Me.lblResultTwelveMonthsID = New System.Windows.Forms.Label()
        Me.lblResultSixMonthsID = New System.Windows.Forms.Label()
        Me.cboResultTwelveMonthsID = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPreTestCounselingID = New System.Windows.Forms.Label()
        Me.lblHIVTestSixMonthsID = New System.Windows.Forms.Label()
        Me.cboHIVTestSixMonthsID = New System.Windows.Forms.ComboBox()
        Me.lblHIVTestThreeMonthsID = New System.Windows.Forms.Label()
        Me.cboHIVTestThreeMonthsID = New System.Windows.Forms.ComboBox()
        Me.lblTestedHIVBeforeID = New System.Windows.Forms.Label()
        Me.cboTestedHIVBeforeID = New System.Windows.Forms.ComboBox()
        Me.lblSexualPatnerNo = New System.Windows.Forms.Label()
        Me.nbxSexualPatnerNo = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblMaritalStatusID = New System.Windows.Forms.Label()
        Me.cboMaritalStatusID = New System.Windows.Forms.ComboBox()
        Me.lblHCTEntryPoint = New System.Windows.Forms.Label()
        Me.cboHCTEntryPoint = New System.Windows.Forms.ComboBox()
        Me.lblCounseledAsID = New System.Windows.Forms.Label()
        Me.cboCounseledAsID = New System.Windows.Forms.ComboBox()
        Me.cboPreTestCounselingID = New System.Windows.Forms.ComboBox()
        Me.lblHIVTestTwelveMonthsID = New System.Windows.Forms.Label()
        Me.cboHIVTestTwelveMonthsID = New System.Windows.Forms.ComboBox()
        Me.tpgConsentResults = New System.Windows.Forms.TabPage()
        Me.lblWhereLinkedToCareID = New System.Windows.Forms.Label()
        Me.cboWhereLinkedToCareID = New System.Windows.Forms.ComboBox()
        Me.lblLinkedToCareID = New System.Windows.Forms.Label()
        Me.cboLinkedToCareID = New System.Windows.Forms.ComboBox()
        Me.stbCounselorName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStartedCotrimoxazoleID = New System.Windows.Forms.Label()
        Me.lblCounselorName = New System.Windows.Forms.Label()
        Me.cboStartedCotrimoxazoleID = New System.Windows.Forms.ComboBox()
        Me.dtpCounselDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCounselDate = New System.Windows.Forms.Label()
        Me.stbReferralReason = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferralReason = New System.Windows.Forms.Label()
        Me.lblHIVResultID = New System.Windows.Forms.Label()
        Me.lblSTIID = New System.Windows.Forms.Label()
        Me.cboSTIID = New System.Windows.Forms.ComboBox()
        Me.lblTBSuspicionID = New System.Windows.Forms.Label()
        Me.cboTBSuspicionID = New System.Windows.Forms.ComboBox()
        Me.lblCoupleResultsID = New System.Windows.Forms.Label()
        Me.cboCoupleResultsID = New System.Windows.Forms.ComboBox()
        Me.cboHIVResultID = New System.Windows.Forms.ComboBox()
        Me.lblResultReceivedAsCoupleID = New System.Windows.Forms.Label()
        Me.cboResultReceivedAsCoupleID = New System.Windows.Forms.ComboBox()
        Me.stbTestDoneBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblResultReceivedID = New System.Windows.Forms.Label()
        Me.lblTestDoneBy = New System.Windows.Forms.Label()
        Me.cboResultReceivedID = New System.Windows.Forms.ComboBox()
        Me.stbDesignation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTestDate = New System.Windows.Forms.Label()
        Me.lblDesignation = New System.Windows.Forms.Label()
        Me.dtpTestDate = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbOccupation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stbVillage = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stbSubCounty = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.stbParish = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.stbDistrict = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnPrintConsent = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.chkPrintTestResults = New System.Windows.Forms.CheckBox()
        Me.chkPrintConsent = New System.Windows.Forms.CheckBox()
        Me.tbcHCTClientCard.SuspendLayout()
        Me.tpgSectionAB.SuspendLayout()
        Me.tpgConsentResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboDistrictsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDistrictsID, "District")
        Me.cboDistrictsID.DataSource = Me.clbNoConsentReason.CustomTabOffsets
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDistrictsID.Location = New System.Drawing.Point(257, 5)
        Me.cboDistrictsID.Name = "cboDistrictsID"
        Me.cboDistrictsID.Size = New System.Drawing.Size(170, 21)
        Me.cboDistrictsID.TabIndex = 1
        '
        'clbNoConsentReason
        '
        Me.clbNoConsentReason.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbNoConsentReason, "NoConsentReason")
        Me.clbNoConsentReason.FormattingEnabled = True
        Me.clbNoConsentReason.Location = New System.Drawing.Point(211, 28)
        Me.clbNoConsentReason.Name = "clbNoConsentReason"
        Me.clbNoConsentReason.Size = New System.Drawing.Size(170, 60)
        Me.clbNoConsentReason.TabIndex = 3
        '
        'cboHealthUnitCode
        '
        Me.cboHealthUnitCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHealthUnitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHealthUnitCode.Location = New System.Drawing.Point(257, 27)
        Me.cboHealthUnitCode.Name = "cboHealthUnitCode"
        Me.cboHealthUnitCode.Size = New System.Drawing.Size(170, 21)
        Me.cboHealthUnitCode.TabIndex = 3
        '
        'stbHSD
        '
        Me.stbHSD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbHSD.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbHSD, "HSD")
        Me.stbHSD.EntryErrorMSG = ""
        Me.stbHSD.Location = New System.Drawing.Point(257, 50)
        Me.stbHSD.Name = "stbHSD"
        Me.stbHSD.RegularExpression = ""
        Me.stbHSD.Size = New System.Drawing.Size(170, 20)
        Me.stbHSD.TabIndex = 5
        '
        'cboCenterTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCenterTypeID, "CenterType")
        Me.cboCenterTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCenterTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCenterTypeID.Location = New System.Drawing.Point(257, 72)
        Me.cboCenterTypeID.Name = "cboCenterTypeID"
        Me.cboCenterTypeID.Size = New System.Drawing.Size(170, 21)
        Me.cboCenterTypeID.TabIndex = 7
        '
        'cboTestingPointID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTestingPointID, "TestingPoint")
        Me.cboTestingPointID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTestingPointID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTestingPointID.Location = New System.Drawing.Point(257, 94)
        Me.cboTestingPointID.Name = "cboTestingPointID"
        Me.cboTestingPointID.Size = New System.Drawing.Size(170, 21)
        Me.cboTestingPointID.TabIndex = 9
        '
        'cboAccompaniedByID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAccompaniedByID, "AccompaniedBy")
        Me.cboAccompaniedByID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccompaniedByID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccompaniedByID.Location = New System.Drawing.Point(257, 116)
        Me.cboAccompaniedByID.Name = "cboAccompaniedByID"
        Me.cboAccompaniedByID.Size = New System.Drawing.Size(170, 21)
        Me.cboAccompaniedByID.TabIndex = 11
        '
        'cboConsentID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboConsentID, "Consent")
        Me.cboConsentID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsentID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboConsentID.Location = New System.Drawing.Point(212, 6)
        Me.cboConsentID.Name = "cboConsentID"
        Me.cboConsentID.Size = New System.Drawing.Size(170, 21)
        Me.cboConsentID.TabIndex = 1
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(93, 6)
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(121, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(11, 9)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(77, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblDistrictsID
        '
        Me.lblDistrictsID.Location = New System.Drawing.Point(19, 6)
        Me.lblDistrictsID.Name = "lblDistrictsID"
        Me.lblDistrictsID.Size = New System.Drawing.Size(229, 20)
        Me.lblDistrictsID.TabIndex = 0
        Me.lblDistrictsID.Text = "District"
        '
        'lblHealthUnitCode
        '
        Me.lblHealthUnitCode.Location = New System.Drawing.Point(19, 29)
        Me.lblHealthUnitCode.Name = "lblHealthUnitCode"
        Me.lblHealthUnitCode.Size = New System.Drawing.Size(229, 20)
        Me.lblHealthUnitCode.TabIndex = 2
        Me.lblHealthUnitCode.Text = "Name of Health Unit"
        '
        'lblHSD
        '
        Me.lblHSD.Location = New System.Drawing.Point(19, 50)
        Me.lblHSD.Name = "lblHSD"
        Me.lblHSD.Size = New System.Drawing.Size(229, 20)
        Me.lblHSD.TabIndex = 4
        Me.lblHSD.Text = "HSD"
        '
        'lblCenterTypeID
        '
        Me.lblCenterTypeID.Location = New System.Drawing.Point(19, 72)
        Me.lblCenterTypeID.Name = "lblCenterTypeID"
        Me.lblCenterTypeID.Size = New System.Drawing.Size(229, 20)
        Me.lblCenterTypeID.TabIndex = 6
        Me.lblCenterTypeID.Text = "Is the Centre static or Outreach"
        '
        'lblTestingPointID
        '
        Me.lblTestingPointID.Location = New System.Drawing.Point(19, 94)
        Me.lblTestingPointID.Name = "lblTestingPointID"
        Me.lblTestingPointID.Size = New System.Drawing.Size(229, 20)
        Me.lblTestingPointID.TabIndex = 8
        Me.lblTestingPointID.Text = "Point of testing: e.g. Ward, OPD, Clinic"
        '
        'lblAccompaniedByID
        '
        Me.lblAccompaniedByID.Location = New System.Drawing.Point(19, 116)
        Me.lblAccompaniedByID.Name = "lblAccompaniedByID"
        Me.lblAccompaniedByID.Size = New System.Drawing.Size(229, 20)
        Me.lblAccompaniedByID.TabIndex = 10
        Me.lblAccompaniedByID.Text = "If Child (Below 12 years), accompanied by:"
        '
        'lblConsentID
        '
        Me.lblConsentID.Location = New System.Drawing.Point(15, 6)
        Me.lblConsentID.Name = "lblConsentID"
        Me.lblConsentID.Size = New System.Drawing.Size(191, 20)
        Me.lblConsentID.TabIndex = 0
        Me.lblConsentID.Text = "Do you consent for an HIV test?"
        '
        'lblNoConsentReasonID
        '
        Me.lblNoConsentReasonID.Location = New System.Drawing.Point(15, 24)
        Me.lblNoConsentReasonID.Name = "lblNoConsentReasonID"
        Me.lblNoConsentReasonID.Size = New System.Drawing.Size(191, 20)
        Me.lblNoConsentReasonID.TabIndex = 2
        Me.lblNoConsentReasonID.Text = "If no consent, what are the reasons?"
        '
        'tbcHCTClientCard
        '
        Me.tbcHCTClientCard.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbcHCTClientCard.Controls.Add(Me.tpgSectionAB)
        Me.tbcHCTClientCard.Controls.Add(Me.tpgConsentResults)
        Me.tbcHCTClientCard.HotTrack = True
        Me.tbcHCTClientCard.Location = New System.Drawing.Point(10, 95)
        Me.tbcHCTClientCard.Name = "tbcHCTClientCard"
        Me.tbcHCTClientCard.SelectedIndex = 0
        Me.tbcHCTClientCard.Size = New System.Drawing.Size(856, 338)
        Me.tbcHCTClientCard.TabIndex = 0
        '
        'tpgSectionAB
        '
        Me.tpgSectionAB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpgSectionAB.Controls.Add(Me.clbKnowAboutServiceID)
        Me.tpgSectionAB.Controls.Add(Me.cboPatnerTypeID)
        Me.tpgSectionAB.Controls.Add(Me.lblPatnerTypeID)
        Me.tpgSectionAB.Controls.Add(Me.cboPatnerResultID)
        Me.tpgSectionAB.Controls.Add(Me.lblPatnerResultID)
        Me.tpgSectionAB.Controls.Add(Me.lblKnowAboutServiceID)
        Me.tpgSectionAB.Controls.Add(Me.lblPatnerTestedHIVID)
        Me.tpgSectionAB.Controls.Add(Me.cboPatnerTestedHIVID)
        Me.tpgSectionAB.Controls.Add(Me.cboResultThreeMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.lblNoTestsInTwelveMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.lblResultThreeMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.cboNoTestsInTwelveMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.cboResultSixMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.lblResultTwelveMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.lblResultSixMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.cboResultTwelveMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.Label11)
        Me.tpgSectionAB.Controls.Add(Me.lblPreTestCounselingID)
        Me.tpgSectionAB.Controls.Add(Me.lblHIVTestSixMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.cboHIVTestSixMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.lblHIVTestThreeMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.cboHIVTestThreeMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.lblTestedHIVBeforeID)
        Me.tpgSectionAB.Controls.Add(Me.cboTestedHIVBeforeID)
        Me.tpgSectionAB.Controls.Add(Me.lblSexualPatnerNo)
        Me.tpgSectionAB.Controls.Add(Me.nbxSexualPatnerNo)
        Me.tpgSectionAB.Controls.Add(Me.lblMaritalStatusID)
        Me.tpgSectionAB.Controls.Add(Me.cboMaritalStatusID)
        Me.tpgSectionAB.Controls.Add(Me.lblHCTEntryPoint)
        Me.tpgSectionAB.Controls.Add(Me.cboHCTEntryPoint)
        Me.tpgSectionAB.Controls.Add(Me.lblCounseledAsID)
        Me.tpgSectionAB.Controls.Add(Me.cboCounseledAsID)
        Me.tpgSectionAB.Controls.Add(Me.cboPreTestCounselingID)
        Me.tpgSectionAB.Controls.Add(Me.lblHIVTestTwelveMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.cboHIVTestTwelveMonthsID)
        Me.tpgSectionAB.Controls.Add(Me.lblDistrictsID)
        Me.tpgSectionAB.Controls.Add(Me.lblCenterTypeID)
        Me.tpgSectionAB.Controls.Add(Me.cboCenterTypeID)
        Me.tpgSectionAB.Controls.Add(Me.lblHSD)
        Me.tpgSectionAB.Controls.Add(Me.stbHSD)
        Me.tpgSectionAB.Controls.Add(Me.lblHealthUnitCode)
        Me.tpgSectionAB.Controls.Add(Me.cboHealthUnitCode)
        Me.tpgSectionAB.Controls.Add(Me.cboDistrictsID)
        Me.tpgSectionAB.Controls.Add(Me.cboTestingPointID)
        Me.tpgSectionAB.Controls.Add(Me.lblAccompaniedByID)
        Me.tpgSectionAB.Controls.Add(Me.cboAccompaniedByID)
        Me.tpgSectionAB.Controls.Add(Me.lblTestingPointID)
        Me.tpgSectionAB.Location = New System.Drawing.Point(4, 22)
        Me.tpgSectionAB.Name = "tpgSectionAB"
        Me.tpgSectionAB.Size = New System.Drawing.Size(848, 312)
        Me.tpgSectionAB.TabIndex = 2
        Me.tpgSectionAB.Tag = ""
        Me.tpgSectionAB.Text = "Section A - B"
        '
        'clbKnowAboutServiceID
        '
        Me.clbKnowAboutServiceID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbKnowAboutServiceID, "KnowAboutService")
        Me.clbKnowAboutServiceID.FormattingEnabled = True
        Me.clbKnowAboutServiceID.Location = New System.Drawing.Point(671, 225)
        Me.clbKnowAboutServiceID.Name = "clbKnowAboutServiceID"
        Me.clbKnowAboutServiceID.Size = New System.Drawing.Size(170, 75)
        Me.clbKnowAboutServiceID.TabIndex = 46
        '
        'cboPatnerTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPatnerTypeID, "PatnerType")
        Me.cboPatnerTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatnerTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPatnerTypeID.Location = New System.Drawing.Point(672, 181)
        Me.cboPatnerTypeID.Name = "cboPatnerTypeID"
        Me.cboPatnerTypeID.Size = New System.Drawing.Size(170, 21)
        Me.cboPatnerTypeID.TabIndex = 42
        '
        'lblPatnerTypeID
        '
        Me.lblPatnerTypeID.Location = New System.Drawing.Point(448, 181)
        Me.lblPatnerTypeID.Name = "lblPatnerTypeID"
        Me.lblPatnerTypeID.Size = New System.Drawing.Size(218, 20)
        Me.lblPatnerTypeID.TabIndex = 41
        Me.lblPatnerTypeID.Text = "Patner type"
        '
        'cboPatnerResultID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPatnerResultID, "PatnerResult")
        Me.cboPatnerResultID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatnerResultID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPatnerResultID.Location = New System.Drawing.Point(672, 203)
        Me.cboPatnerResultID.Name = "cboPatnerResultID"
        Me.cboPatnerResultID.Size = New System.Drawing.Size(170, 21)
        Me.cboPatnerResultID.TabIndex = 44
        '
        'lblPatnerResultID
        '
        Me.lblPatnerResultID.Location = New System.Drawing.Point(448, 202)
        Me.lblPatnerResultID.Name = "lblPatnerResultID"
        Me.lblPatnerResultID.Size = New System.Drawing.Size(218, 20)
        Me.lblPatnerResultID.TabIndex = 43
        Me.lblPatnerResultID.Text = "Patner HIV result"
        '
        'lblKnowAboutServiceID
        '
        Me.lblKnowAboutServiceID.Location = New System.Drawing.Point(448, 224)
        Me.lblKnowAboutServiceID.Name = "lblKnowAboutServiceID"
        Me.lblKnowAboutServiceID.Size = New System.Drawing.Size(218, 20)
        Me.lblKnowAboutServiceID.TabIndex = 45
        Me.lblKnowAboutServiceID.Text = "How did you know about the service"
        '
        'lblPatnerTestedHIVID
        '
        Me.lblPatnerTestedHIVID.Location = New System.Drawing.Point(448, 159)
        Me.lblPatnerTestedHIVID.Name = "lblPatnerTestedHIVID"
        Me.lblPatnerTestedHIVID.Size = New System.Drawing.Size(218, 20)
        Me.lblPatnerTestedHIVID.TabIndex = 39
        Me.lblPatnerTestedHIVID.Text = "Spouse/partner tested for HIV before?"
        '
        'cboPatnerTestedHIVID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPatnerTestedHIVID, "PatnerTestedHIV")
        Me.cboPatnerTestedHIVID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatnerTestedHIVID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPatnerTestedHIVID.Location = New System.Drawing.Point(672, 159)
        Me.cboPatnerTestedHIVID.Name = "cboPatnerTestedHIVID"
        Me.cboPatnerTestedHIVID.Size = New System.Drawing.Size(170, 21)
        Me.cboPatnerTestedHIVID.TabIndex = 40
        '
        'cboResultThreeMonthsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboResultThreeMonthsID, "ResultThreeMonths")
        Me.cboResultThreeMonthsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResultThreeMonthsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboResultThreeMonthsID.Location = New System.Drawing.Point(672, 71)
        Me.cboResultThreeMonthsID.Name = "cboResultThreeMonthsID"
        Me.cboResultThreeMonthsID.Size = New System.Drawing.Size(170, 21)
        Me.cboResultThreeMonthsID.TabIndex = 32
        '
        'lblNoTestsInTwelveMonthsID
        '
        Me.lblNoTestsInTwelveMonthsID.Location = New System.Drawing.Point(448, 137)
        Me.lblNoTestsInTwelveMonthsID.Name = "lblNoTestsInTwelveMonthsID"
        Me.lblNoTestsInTwelveMonthsID.Size = New System.Drawing.Size(225, 20)
        Me.lblNoTestsInTwelveMonthsID.TabIndex = 37
        Me.lblNoTestsInTwelveMonthsID.Text = "No of times tested for HIV in last 12 Months"
        '
        'lblResultThreeMonthsID
        '
        Me.lblResultThreeMonthsID.Location = New System.Drawing.Point(447, 71)
        Me.lblResultThreeMonthsID.Name = "lblResultThreeMonthsID"
        Me.lblResultThreeMonthsID.Size = New System.Drawing.Size(218, 20)
        Me.lblResultThreeMonthsID.TabIndex = 31
        Me.lblResultThreeMonthsID.Text = "Result in 3 Months:"
        '
        'cboNoTestsInTwelveMonthsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboNoTestsInTwelveMonthsID, "NoTestsInTwelveMonths")
        Me.cboNoTestsInTwelveMonthsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoTestsInTwelveMonthsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboNoTestsInTwelveMonthsID.Location = New System.Drawing.Point(672, 137)
        Me.cboNoTestsInTwelveMonthsID.Name = "cboNoTestsInTwelveMonthsID"
        Me.cboNoTestsInTwelveMonthsID.Size = New System.Drawing.Size(170, 21)
        Me.cboNoTestsInTwelveMonthsID.TabIndex = 38
        '
        'cboResultSixMonthsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboResultSixMonthsID, "ResultSixMonths")
        Me.cboResultSixMonthsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResultSixMonthsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboResultSixMonthsID.Location = New System.Drawing.Point(672, 93)
        Me.cboResultSixMonthsID.Name = "cboResultSixMonthsID"
        Me.cboResultSixMonthsID.Size = New System.Drawing.Size(170, 21)
        Me.cboResultSixMonthsID.TabIndex = 34
        '
        'lblResultTwelveMonthsID
        '
        Me.lblResultTwelveMonthsID.Location = New System.Drawing.Point(447, 115)
        Me.lblResultTwelveMonthsID.Name = "lblResultTwelveMonthsID"
        Me.lblResultTwelveMonthsID.Size = New System.Drawing.Size(218, 20)
        Me.lblResultTwelveMonthsID.TabIndex = 35
        Me.lblResultTwelveMonthsID.Text = "Result in 12 Months:"
        '
        'lblResultSixMonthsID
        '
        Me.lblResultSixMonthsID.Location = New System.Drawing.Point(447, 93)
        Me.lblResultSixMonthsID.Name = "lblResultSixMonthsID"
        Me.lblResultSixMonthsID.Size = New System.Drawing.Size(218, 20)
        Me.lblResultSixMonthsID.TabIndex = 33
        Me.lblResultSixMonthsID.Text = "Result in 6 Months:"
        '
        'cboResultTwelveMonthsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboResultTwelveMonthsID, "ResultTwelveMonths")
        Me.cboResultTwelveMonthsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResultTwelveMonthsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboResultTwelveMonthsID.Location = New System.Drawing.Point(672, 115)
        Me.cboResultTwelveMonthsID.Name = "cboResultTwelveMonthsID"
        Me.cboResultTwelveMonthsID.Size = New System.Drawing.Size(170, 21)
        Me.cboResultTwelveMonthsID.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(19, 148)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(255, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "SECTION B: PRE-TEST COUNSELLING"
        '
        'lblPreTestCounselingID
        '
        Me.lblPreTestCounselingID.Location = New System.Drawing.Point(19, 175)
        Me.lblPreTestCounselingID.Name = "lblPreTestCounselingID"
        Me.lblPreTestCounselingID.Size = New System.Drawing.Size(229, 20)
        Me.lblPreTestCounselingID.TabIndex = 13
        Me.lblPreTestCounselingID.Text = "Pre-test counselling done/Information given:"
        '
        'lblHIVTestSixMonthsID
        '
        Me.lblHIVTestSixMonthsID.Location = New System.Drawing.Point(447, 29)
        Me.lblHIVTestSixMonthsID.Name = "lblHIVTestSixMonthsID"
        Me.lblHIVTestSixMonthsID.Size = New System.Drawing.Size(218, 20)
        Me.lblHIVTestSixMonthsID.TabIndex = 27
        Me.lblHIVTestSixMonthsID.Text = "Tested for HIV in last 6 Months:"
        '
        'cboHIVTestSixMonthsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHIVTestSixMonthsID, "HIVTestSixMonths")
        Me.cboHIVTestSixMonthsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIVTestSixMonthsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHIVTestSixMonthsID.Location = New System.Drawing.Point(672, 27)
        Me.cboHIVTestSixMonthsID.Name = "cboHIVTestSixMonthsID"
        Me.cboHIVTestSixMonthsID.Size = New System.Drawing.Size(170, 21)
        Me.cboHIVTestSixMonthsID.TabIndex = 28
        '
        'lblHIVTestThreeMonthsID
        '
        Me.lblHIVTestThreeMonthsID.Location = New System.Drawing.Point(447, 7)
        Me.lblHIVTestThreeMonthsID.Name = "lblHIVTestThreeMonthsID"
        Me.lblHIVTestThreeMonthsID.Size = New System.Drawing.Size(218, 20)
        Me.lblHIVTestThreeMonthsID.TabIndex = 25
        Me.lblHIVTestThreeMonthsID.Text = "Tested for HIV in last 3 Months:"
        '
        'cboHIVTestThreeMonthsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHIVTestThreeMonthsID, "HIVTestThreeMonths")
        Me.cboHIVTestThreeMonthsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIVTestThreeMonthsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHIVTestThreeMonthsID.Location = New System.Drawing.Point(672, 5)
        Me.cboHIVTestThreeMonthsID.Name = "cboHIVTestThreeMonthsID"
        Me.cboHIVTestThreeMonthsID.Size = New System.Drawing.Size(170, 21)
        Me.cboHIVTestThreeMonthsID.TabIndex = 26
        '
        'lblTestedHIVBeforeID
        '
        Me.lblTestedHIVBeforeID.Location = New System.Drawing.Point(19, 290)
        Me.lblTestedHIVBeforeID.Name = "lblTestedHIVBeforeID"
        Me.lblTestedHIVBeforeID.Size = New System.Drawing.Size(229, 20)
        Me.lblTestedHIVBeforeID.TabIndex = 23
        Me.lblTestedHIVBeforeID.Text = "Have you ever tested for HIV before?"
        '
        'cboTestedHIVBeforeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTestedHIVBeforeID, "TestedHIVBefore")
        Me.cboTestedHIVBeforeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTestedHIVBeforeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTestedHIVBeforeID.Location = New System.Drawing.Point(254, 285)
        Me.cboTestedHIVBeforeID.Name = "cboTestedHIVBeforeID"
        Me.cboTestedHIVBeforeID.Size = New System.Drawing.Size(170, 21)
        Me.cboTestedHIVBeforeID.TabIndex = 24
        '
        'lblSexualPatnerNo
        '
        Me.lblSexualPatnerNo.Location = New System.Drawing.Point(19, 264)
        Me.lblSexualPatnerNo.Name = "lblSexualPatnerNo"
        Me.lblSexualPatnerNo.Size = New System.Drawing.Size(229, 20)
        Me.lblSexualPatnerNo.TabIndex = 21
        Me.lblSexualPatnerNo.Text = "No of Sexual partners in last 12 Months"
        '
        'nbxSexualPatnerNo
        '
        Me.nbxSexualPatnerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSexualPatnerNo.ControlCaption = "Sexual Patner No"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxSexualPatnerNo, "SexualPatnerNo")
        Me.nbxSexualPatnerNo.DecimalPlaces = -1
        Me.nbxSexualPatnerNo.Location = New System.Drawing.Point(256, 263)
        Me.nbxSexualPatnerNo.MaxValue = 0.0R
        Me.nbxSexualPatnerNo.MinValue = 0.0R
        Me.nbxSexualPatnerNo.MustEnterNumeric = True
        Me.nbxSexualPatnerNo.Name = "nbxSexualPatnerNo"
        Me.nbxSexualPatnerNo.Size = New System.Drawing.Size(170, 20)
        Me.nbxSexualPatnerNo.TabIndex = 22
        Me.nbxSexualPatnerNo.Value = ""
        '
        'lblMaritalStatusID
        '
        Me.lblMaritalStatusID.Location = New System.Drawing.Point(19, 243)
        Me.lblMaritalStatusID.Name = "lblMaritalStatusID"
        Me.lblMaritalStatusID.Size = New System.Drawing.Size(229, 20)
        Me.lblMaritalStatusID.TabIndex = 19
        Me.lblMaritalStatusID.Text = "Marital Status:"
        '
        'cboMaritalStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboMaritalStatusID, "MaritalStatus")
        Me.cboMaritalStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaritalStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMaritalStatusID.Location = New System.Drawing.Point(257, 240)
        Me.cboMaritalStatusID.Name = "cboMaritalStatusID"
        Me.cboMaritalStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboMaritalStatusID.TabIndex = 20
        '
        'lblHCTEntryPoint
        '
        Me.lblHCTEntryPoint.Location = New System.Drawing.Point(19, 218)
        Me.lblHCTEntryPoint.Name = "lblHCTEntryPoint"
        Me.lblHCTEntryPoint.Size = New System.Drawing.Size(229, 20)
        Me.lblHCTEntryPoint.TabIndex = 17
        Me.lblHCTEntryPoint.Text = "HCT - Entry Point"
        '
        'cboHCTEntryPoint
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHCTEntryPoint, "HCTEntryPoint")
        Me.cboHCTEntryPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHCTEntryPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHCTEntryPoint.Location = New System.Drawing.Point(257, 217)
        Me.cboHCTEntryPoint.Name = "cboHCTEntryPoint"
        Me.cboHCTEntryPoint.Size = New System.Drawing.Size(170, 21)
        Me.cboHCTEntryPoint.TabIndex = 18
        '
        'lblCounseledAsID
        '
        Me.lblCounseledAsID.Location = New System.Drawing.Point(19, 197)
        Me.lblCounseledAsID.Name = "lblCounseledAsID"
        Me.lblCounseledAsID.Size = New System.Drawing.Size(229, 20)
        Me.lblCounseledAsID.TabIndex = 15
        Me.lblCounseledAsID.Text = "Counseled as:"
        '
        'cboCounseledAsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCounseledAsID, "CounseledAs")
        Me.cboCounseledAsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCounseledAsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCounseledAsID.Location = New System.Drawing.Point(257, 194)
        Me.cboCounseledAsID.Name = "cboCounseledAsID"
        Me.cboCounseledAsID.Size = New System.Drawing.Size(170, 21)
        Me.cboCounseledAsID.TabIndex = 16
        '
        'cboPreTestCounselingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPreTestCounselingID, "PreTestCounseling")
        Me.cboPreTestCounselingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPreTestCounselingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPreTestCounselingID.Location = New System.Drawing.Point(257, 171)
        Me.cboPreTestCounselingID.Name = "cboPreTestCounselingID"
        Me.cboPreTestCounselingID.Size = New System.Drawing.Size(170, 21)
        Me.cboPreTestCounselingID.TabIndex = 14
        '
        'lblHIVTestTwelveMonthsID
        '
        Me.lblHIVTestTwelveMonthsID.Location = New System.Drawing.Point(447, 51)
        Me.lblHIVTestTwelveMonthsID.Name = "lblHIVTestTwelveMonthsID"
        Me.lblHIVTestTwelveMonthsID.Size = New System.Drawing.Size(218, 20)
        Me.lblHIVTestTwelveMonthsID.TabIndex = 29
        Me.lblHIVTestTwelveMonthsID.Text = "Tested for HIV in last 12 Months:"
        '
        'cboHIVTestTwelveMonthsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHIVTestTwelveMonthsID, "HIVTestTwelveMonths")
        Me.cboHIVTestTwelveMonthsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIVTestTwelveMonthsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHIVTestTwelveMonthsID.Location = New System.Drawing.Point(672, 49)
        Me.cboHIVTestTwelveMonthsID.Name = "cboHIVTestTwelveMonthsID"
        Me.cboHIVTestTwelveMonthsID.Size = New System.Drawing.Size(170, 21)
        Me.cboHIVTestTwelveMonthsID.TabIndex = 30
        '
        'tpgConsentResults
        '
        Me.tpgConsentResults.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpgConsentResults.Controls.Add(Me.clbNoConsentReason)
        Me.tpgConsentResults.Controls.Add(Me.lblWhereLinkedToCareID)
        Me.tpgConsentResults.Controls.Add(Me.cboWhereLinkedToCareID)
        Me.tpgConsentResults.Controls.Add(Me.lblLinkedToCareID)
        Me.tpgConsentResults.Controls.Add(Me.cboLinkedToCareID)
        Me.tpgConsentResults.Controls.Add(Me.stbCounselorName)
        Me.tpgConsentResults.Controls.Add(Me.lblStartedCotrimoxazoleID)
        Me.tpgConsentResults.Controls.Add(Me.lblCounselorName)
        Me.tpgConsentResults.Controls.Add(Me.cboStartedCotrimoxazoleID)
        Me.tpgConsentResults.Controls.Add(Me.dtpCounselDate)
        Me.tpgConsentResults.Controls.Add(Me.lblCounselDate)
        Me.tpgConsentResults.Controls.Add(Me.stbReferralReason)
        Me.tpgConsentResults.Controls.Add(Me.lblReferralReason)
        Me.tpgConsentResults.Controls.Add(Me.lblHIVResultID)
        Me.tpgConsentResults.Controls.Add(Me.lblSTIID)
        Me.tpgConsentResults.Controls.Add(Me.cboSTIID)
        Me.tpgConsentResults.Controls.Add(Me.lblTBSuspicionID)
        Me.tpgConsentResults.Controls.Add(Me.cboTBSuspicionID)
        Me.tpgConsentResults.Controls.Add(Me.lblCoupleResultsID)
        Me.tpgConsentResults.Controls.Add(Me.cboCoupleResultsID)
        Me.tpgConsentResults.Controls.Add(Me.cboHIVResultID)
        Me.tpgConsentResults.Controls.Add(Me.lblResultReceivedAsCoupleID)
        Me.tpgConsentResults.Controls.Add(Me.cboResultReceivedAsCoupleID)
        Me.tpgConsentResults.Controls.Add(Me.stbTestDoneBy)
        Me.tpgConsentResults.Controls.Add(Me.lblResultReceivedID)
        Me.tpgConsentResults.Controls.Add(Me.lblTestDoneBy)
        Me.tpgConsentResults.Controls.Add(Me.cboResultReceivedID)
        Me.tpgConsentResults.Controls.Add(Me.stbDesignation)
        Me.tpgConsentResults.Controls.Add(Me.lblTestDate)
        Me.tpgConsentResults.Controls.Add(Me.lblDesignation)
        Me.tpgConsentResults.Controls.Add(Me.dtpTestDate)
        Me.tpgConsentResults.Controls.Add(Me.Label12)
        Me.tpgConsentResults.Controls.Add(Me.lblConsentID)
        Me.tpgConsentResults.Controls.Add(Me.lblNoConsentReasonID)
        Me.tpgConsentResults.Controls.Add(Me.cboConsentID)
        Me.tpgConsentResults.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsentResults.Name = "tpgConsentResults"
        Me.tpgConsentResults.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgConsentResults.Size = New System.Drawing.Size(848, 312)
        Me.tpgConsentResults.TabIndex = 3
        Me.tpgConsentResults.Text = "Consent - Test Results"
        '
        'lblWhereLinkedToCareID
        '
        Me.lblWhereLinkedToCareID.Location = New System.Drawing.Point(463, 51)
        Me.lblWhereLinkedToCareID.Name = "lblWhereLinkedToCareID"
        Me.lblWhereLinkedToCareID.Size = New System.Drawing.Size(191, 20)
        Me.lblWhereLinkedToCareID.TabIndex = 27
        Me.lblWhereLinkedToCareID.Text = "Where?"
        '
        'cboWhereLinkedToCareID
        '
        Me.cboWhereLinkedToCareID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWhereLinkedToCareID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWhereLinkedToCareID.Location = New System.Drawing.Point(660, 53)
        Me.cboWhereLinkedToCareID.Name = "cboWhereLinkedToCareID"
        Me.cboWhereLinkedToCareID.Size = New System.Drawing.Size(170, 21)
        Me.cboWhereLinkedToCareID.TabIndex = 28
        '
        'lblLinkedToCareID
        '
        Me.lblLinkedToCareID.Location = New System.Drawing.Point(462, 31)
        Me.lblLinkedToCareID.Name = "lblLinkedToCareID"
        Me.lblLinkedToCareID.Size = New System.Drawing.Size(191, 20)
        Me.lblLinkedToCareID.TabIndex = 25
        Me.lblLinkedToCareID.Text = "Linked to care or any other service?"
        '
        'cboLinkedToCareID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboLinkedToCareID, "LinkedToCare")
        Me.cboLinkedToCareID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinkedToCareID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLinkedToCareID.Location = New System.Drawing.Point(659, 30)
        Me.cboLinkedToCareID.Name = "cboLinkedToCareID"
        Me.cboLinkedToCareID.Size = New System.Drawing.Size(170, 21)
        Me.cboLinkedToCareID.TabIndex = 26
        '
        'stbCounselorName
        '
        Me.stbCounselorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCounselorName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCounselorName, "CounselorName")
        Me.stbCounselorName.EntryErrorMSG = ""
        Me.stbCounselorName.Location = New System.Drawing.Point(659, 97)
        Me.stbCounselorName.Name = "stbCounselorName"
        Me.stbCounselorName.RegularExpression = ""
        Me.stbCounselorName.Size = New System.Drawing.Size(170, 20)
        Me.stbCounselorName.TabIndex = 32
        '
        'lblStartedCotrimoxazoleID
        '
        Me.lblStartedCotrimoxazoleID.Location = New System.Drawing.Point(462, 10)
        Me.lblStartedCotrimoxazoleID.Name = "lblStartedCotrimoxazoleID"
        Me.lblStartedCotrimoxazoleID.Size = New System.Drawing.Size(191, 20)
        Me.lblStartedCotrimoxazoleID.TabIndex = 23
        Me.lblStartedCotrimoxazoleID.Text = "Started Cotrimoxazole prophylaxis?"
        '
        'lblCounselorName
        '
        Me.lblCounselorName.Location = New System.Drawing.Point(462, 95)
        Me.lblCounselorName.Name = "lblCounselorName"
        Me.lblCounselorName.Size = New System.Drawing.Size(191, 20)
        Me.lblCounselorName.TabIndex = 31
        Me.lblCounselorName.Text = "Counselor' Name"
        '
        'cboStartedCotrimoxazoleID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboStartedCotrimoxazoleID, "StartedCotrimoxazole")
        Me.cboStartedCotrimoxazoleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStartedCotrimoxazoleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStartedCotrimoxazoleID.Location = New System.Drawing.Point(659, 7)
        Me.cboStartedCotrimoxazoleID.Name = "cboStartedCotrimoxazoleID"
        Me.cboStartedCotrimoxazoleID.Size = New System.Drawing.Size(170, 21)
        Me.cboStartedCotrimoxazoleID.TabIndex = 24
        '
        'dtpCounselDate
        '
        Me.dtpCounselDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpCounselDate, "CounselDate")
        Me.dtpCounselDate.Location = New System.Drawing.Point(659, 119)
        Me.dtpCounselDate.Name = "dtpCounselDate"
        Me.dtpCounselDate.ShowCheckBox = True
        Me.dtpCounselDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpCounselDate.TabIndex = 34
        '
        'lblCounselDate
        '
        Me.lblCounselDate.Location = New System.Drawing.Point(462, 117)
        Me.lblCounselDate.Name = "lblCounselDate"
        Me.lblCounselDate.Size = New System.Drawing.Size(191, 20)
        Me.lblCounselDate.TabIndex = 33
        Me.lblCounselDate.Text = "Date"
        '
        'stbReferralReason
        '
        Me.stbReferralReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferralReason.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferralReason, "ReferralReason")
        Me.stbReferralReason.EntryErrorMSG = ""
        Me.stbReferralReason.Location = New System.Drawing.Point(659, 76)
        Me.stbReferralReason.Name = "stbReferralReason"
        Me.stbReferralReason.RegularExpression = ""
        Me.stbReferralReason.Size = New System.Drawing.Size(170, 20)
        Me.stbReferralReason.TabIndex = 30
        '
        'lblReferralReason
        '
        Me.lblReferralReason.Location = New System.Drawing.Point(462, 74)
        Me.lblReferralReason.Name = "lblReferralReason"
        Me.lblReferralReason.Size = New System.Drawing.Size(191, 20)
        Me.lblReferralReason.TabIndex = 29
        Me.lblReferralReason.Text = "Reason for referral"
        '
        'lblHIVResultID
        '
        Me.lblHIVResultID.Location = New System.Drawing.Point(15, 92)
        Me.lblHIVResultID.Name = "lblHIVResultID"
        Me.lblHIVResultID.Size = New System.Drawing.Size(191, 20)
        Me.lblHIVResultID.TabIndex = 5
        Me.lblHIVResultID.Text = "HIV Results"
        '
        'lblSTIID
        '
        Me.lblSTIID.Location = New System.Drawing.Point(15, 268)
        Me.lblSTIID.Name = "lblSTIID"
        Me.lblSTIID.Size = New System.Drawing.Size(191, 20)
        Me.lblSTIID.TabIndex = 21
        Me.lblSTIID.Text = "STI?"
        '
        'cboSTIID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSTIID, "STI")
        Me.cboSTIID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSTIID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSTIID.Location = New System.Drawing.Point(212, 269)
        Me.cboSTIID.Name = "cboSTIID"
        Me.cboSTIID.Size = New System.Drawing.Size(170, 21)
        Me.cboSTIID.TabIndex = 22
        '
        'lblTBSuspicionID
        '
        Me.lblTBSuspicionID.Location = New System.Drawing.Point(15, 247)
        Me.lblTBSuspicionID.Name = "lblTBSuspicionID"
        Me.lblTBSuspicionID.Size = New System.Drawing.Size(191, 20)
        Me.lblTBSuspicionID.TabIndex = 19
        Me.lblTBSuspicionID.Text = "Is there suspicion of TB?"
        '
        'cboTBSuspicionID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTBSuspicionID, "TBSuspicion")
        Me.cboTBSuspicionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTBSuspicionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTBSuspicionID.Location = New System.Drawing.Point(212, 246)
        Me.cboTBSuspicionID.Name = "cboTBSuspicionID"
        Me.cboTBSuspicionID.Size = New System.Drawing.Size(170, 21)
        Me.cboTBSuspicionID.TabIndex = 20
        '
        'lblCoupleResultsID
        '
        Me.lblCoupleResultsID.Location = New System.Drawing.Point(15, 223)
        Me.lblCoupleResultsID.Name = "lblCoupleResultsID"
        Me.lblCoupleResultsID.Size = New System.Drawing.Size(191, 20)
        Me.lblCoupleResultsID.TabIndex = 17
        Me.lblCoupleResultsID.Text = "Couple results:"
        '
        'cboCoupleResultsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoupleResultsID, "CoupleResults")
        Me.cboCoupleResultsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoupleResultsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoupleResultsID.Location = New System.Drawing.Point(212, 223)
        Me.cboCoupleResultsID.Name = "cboCoupleResultsID"
        Me.cboCoupleResultsID.Size = New System.Drawing.Size(170, 21)
        Me.cboCoupleResultsID.TabIndex = 18
        '
        'cboHIVResultID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHIVResultID, "HIVResult")
        Me.cboHIVResultID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIVResultID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHIVResultID.Location = New System.Drawing.Point(212, 91)
        Me.cboHIVResultID.Name = "cboHIVResultID"
        Me.cboHIVResultID.Size = New System.Drawing.Size(170, 21)
        Me.cboHIVResultID.TabIndex = 6
        '
        'lblResultReceivedAsCoupleID
        '
        Me.lblResultReceivedAsCoupleID.Location = New System.Drawing.Point(15, 201)
        Me.lblResultReceivedAsCoupleID.Name = "lblResultReceivedAsCoupleID"
        Me.lblResultReceivedAsCoupleID.Size = New System.Drawing.Size(191, 20)
        Me.lblResultReceivedAsCoupleID.TabIndex = 15
        Me.lblResultReceivedAsCoupleID.Text = "Result received as couple:"
        '
        'cboResultReceivedAsCoupleID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboResultReceivedAsCoupleID, "ResultReceivedAsCouple")
        Me.cboResultReceivedAsCoupleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResultReceivedAsCoupleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboResultReceivedAsCoupleID.Location = New System.Drawing.Point(212, 200)
        Me.cboResultReceivedAsCoupleID.Name = "cboResultReceivedAsCoupleID"
        Me.cboResultReceivedAsCoupleID.Size = New System.Drawing.Size(170, 21)
        Me.cboResultReceivedAsCoupleID.TabIndex = 16
        '
        'stbTestDoneBy
        '
        Me.stbTestDoneBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTestDoneBy.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTestDoneBy, "TestDoneBy")
        Me.stbTestDoneBy.EntryErrorMSG = ""
        Me.stbTestDoneBy.Location = New System.Drawing.Point(212, 114)
        Me.stbTestDoneBy.Name = "stbTestDoneBy"
        Me.stbTestDoneBy.RegularExpression = ""
        Me.stbTestDoneBy.Size = New System.Drawing.Size(170, 20)
        Me.stbTestDoneBy.TabIndex = 8
        '
        'lblResultReceivedID
        '
        Me.lblResultReceivedID.Location = New System.Drawing.Point(15, 177)
        Me.lblResultReceivedID.Name = "lblResultReceivedID"
        Me.lblResultReceivedID.Size = New System.Drawing.Size(191, 20)
        Me.lblResultReceivedID.TabIndex = 13
        Me.lblResultReceivedID.Text = "Result received:"
        '
        'lblTestDoneBy
        '
        Me.lblTestDoneBy.Location = New System.Drawing.Point(15, 116)
        Me.lblTestDoneBy.Name = "lblTestDoneBy"
        Me.lblTestDoneBy.Size = New System.Drawing.Size(191, 20)
        Me.lblTestDoneBy.TabIndex = 7
        Me.lblTestDoneBy.Text = "Test done by (Names)"
        '
        'cboResultReceivedID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboResultReceivedID, "ResultReceived")
        Me.cboResultReceivedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResultReceivedID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboResultReceivedID.Location = New System.Drawing.Point(212, 177)
        Me.cboResultReceivedID.Name = "cboResultReceivedID"
        Me.cboResultReceivedID.Size = New System.Drawing.Size(170, 21)
        Me.cboResultReceivedID.TabIndex = 14
        '
        'stbDesignation
        '
        Me.stbDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDesignation.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDesignation, "Designation")
        Me.stbDesignation.EntryErrorMSG = ""
        Me.stbDesignation.Location = New System.Drawing.Point(212, 135)
        Me.stbDesignation.Name = "stbDesignation"
        Me.stbDesignation.RegularExpression = ""
        Me.stbDesignation.Size = New System.Drawing.Size(170, 20)
        Me.stbDesignation.TabIndex = 10
        '
        'lblTestDate
        '
        Me.lblTestDate.Location = New System.Drawing.Point(15, 157)
        Me.lblTestDate.Name = "lblTestDate"
        Me.lblTestDate.Size = New System.Drawing.Size(191, 20)
        Me.lblTestDate.TabIndex = 11
        Me.lblTestDate.Text = "Test Date"
        '
        'lblDesignation
        '
        Me.lblDesignation.Location = New System.Drawing.Point(15, 137)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(191, 20)
        Me.lblDesignation.TabIndex = 9
        Me.lblDesignation.Text = "Designation"
        '
        'dtpTestDate
        '
        Me.dtpTestDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpTestDate, "TestDate")
        Me.dtpTestDate.Location = New System.Drawing.Point(212, 156)
        Me.dtpTestDate.Name = "dtpTestDate"
        Me.dtpTestDate.ShowCheckBox = True
        Me.dtpTestDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpTestDate.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 15)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "TEST RESULTS"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(398, 27)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.ReadOnly = True
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(151, 20)
        Me.stbAge.TabIndex = 11
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(398, 5)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.ReadOnly = True
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(151, 20)
        Me.stbGender.TabIndex = 9
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(94, 72)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(169, 20)
        Me.stbFullName.TabIndex = 7
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(94, 50)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(169, 20)
        Me.stbPatientNo.TabIndex = 5
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(712, 47)
        Me.stbPhone.MaxLength = 30
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.ReadOnly = True
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(151, 20)
        Me.stbPhone.TabIndex = 21
        '
        'stbOccupation
        '
        Me.stbOccupation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOccupation.CapitalizeFirstLetter = True
        Me.stbOccupation.Enabled = False
        Me.stbOccupation.EntryErrorMSG = ""
        Me.stbOccupation.Location = New System.Drawing.Point(713, 70)
        Me.stbOccupation.MaxLength = 40
        Me.stbOccupation.Name = "stbOccupation"
        Me.stbOccupation.ReadOnly = True
        Me.stbOccupation.RegularExpression = ""
        Me.stbOccupation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbOccupation.Size = New System.Drawing.Size(150, 20)
        Me.stbOccupation.TabIndex = 23
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(93, 28)
        Me.stbVisitDate.MaxLength = 7
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.ReadOnly = True
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.Size = New System.Drawing.Size(169, 20)
        Me.stbVisitDate.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reg. No"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Client's Name"
        '
        'stbVillage
        '
        Me.stbVillage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVillage.CapitalizeFirstLetter = False
        Me.stbVillage.Enabled = False
        Me.stbVillage.EntryErrorMSG = ""
        Me.stbVillage.Location = New System.Drawing.Point(712, 25)
        Me.stbVillage.Name = "stbVillage"
        Me.stbVillage.ReadOnly = True
        Me.stbVillage.RegularExpression = ""
        Me.stbVillage.Size = New System.Drawing.Size(151, 20)
        Me.stbVillage.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(631, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Village"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(330, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Age"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(330, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Sex"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(631, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Telephone"
        '
        'stbSubCounty
        '
        Me.stbSubCounty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSubCounty.CapitalizeFirstLetter = False
        Me.stbSubCounty.Enabled = False
        Me.stbSubCounty.EntryErrorMSG = ""
        Me.stbSubCounty.Location = New System.Drawing.Point(398, 71)
        Me.stbSubCounty.Name = "stbSubCounty"
        Me.stbSubCounty.ReadOnly = True
        Me.stbSubCounty.RegularExpression = ""
        Me.stbSubCounty.Size = New System.Drawing.Size(151, 20)
        Me.stbSubCounty.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(330, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Sub County"
        '
        'stbParish
        '
        Me.stbParish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbParish.CapitalizeFirstLetter = False
        Me.stbParish.Enabled = False
        Me.stbParish.EntryErrorMSG = ""
        Me.stbParish.Location = New System.Drawing.Point(712, 3)
        Me.stbParish.Name = "stbParish"
        Me.stbParish.ReadOnly = True
        Me.stbParish.RegularExpression = ""
        Me.stbParish.Size = New System.Drawing.Size(151, 20)
        Me.stbParish.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(631, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Parish"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(634, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 20)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Occupation"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(11, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 20)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Visit Date"
        '
        'stbDistrict
        '
        Me.stbDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDistrict.CapitalizeFirstLetter = False
        Me.stbDistrict.Enabled = False
        Me.stbDistrict.EntryErrorMSG = ""
        Me.stbDistrict.Location = New System.Drawing.Point(398, 49)
        Me.stbDistrict.Name = "stbDistrict"
        Me.stbDistrict.ReadOnly = True
        Me.stbDistrict.RegularExpression = ""
        Me.stbDistrict.Size = New System.Drawing.Size(151, 20)
        Me.stbDistrict.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(330, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 20)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "District"
        '
        'btnPrintConsent
        '
        Me.btnPrintConsent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintConsent.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintConsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintConsent.Location = New System.Drawing.Point(686, 436)
        Me.btnPrintConsent.Name = "btnPrintConsent"
        Me.btnPrintConsent.Size = New System.Drawing.Size(101, 24)
        Me.btnPrintConsent.TabIndex = 7
        Me.btnPrintConsent.Text = "Print Consent"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(686, 463)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(101, 24)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "&Print Test Results"
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(11, 437)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(791, 436)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 10
        Me.fbnDelete.Tag = "HCTClientCard"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(11, 463)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 9
        Me.ebnSaveUpdate.Tag = "HCTClientCard"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(791, 463)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 11
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(62, 5)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(218, 1)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'chkPrintTestResults
        '
        Me.chkPrintTestResults.AutoSize = True
        Me.chkPrintTestResults.Location = New System.Drawing.Point(99, 470)
        Me.chkPrintTestResults.Name = "chkPrintTestResults"
        Me.chkPrintTestResults.Size = New System.Drawing.Size(158, 17)
        Me.chkPrintTestResults.TabIndex = 6
        Me.chkPrintTestResults.Text = "Print Test Results on saving"
        Me.chkPrintTestResults.UseVisualStyleBackColor = True
        '
        'chkPrintConsent
        '
        Me.chkPrintConsent.AutoSize = True
        Me.chkPrintConsent.Location = New System.Drawing.Point(99, 443)
        Me.chkPrintConsent.Name = "chkPrintConsent"
        Me.chkPrintConsent.Size = New System.Drawing.Size(164, 17)
        Me.chkPrintConsent.TabIndex = 5
        Me.chkPrintConsent.Text = "Print Consent Form on saving"
        Me.chkPrintConsent.UseVisualStyleBackColor = True
        '
        'frmHCTClientCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 492)
        Me.Controls.Add(Me.chkPrintConsent)
        Me.Controls.Add(Me.chkPrintTestResults)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.btnPrintConsent)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbDistrict)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.stbOccupation)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.stbSubCounty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.stbParish)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.stbVillage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbcHCTClientCard)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmHCTClientCard"
        Me.Text = "HCT Client Card"
        Me.tbcHCTClientCard.ResumeLayout(False)
        Me.tpgSectionAB.ResumeLayout(False)
        Me.tpgSectionAB.PerformLayout()
        Me.tpgConsentResults.ResumeLayout(False)
        Me.tpgConsentResults.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboDistrictsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistrictsID As System.Windows.Forms.Label
    Friend WithEvents cboHealthUnitCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblHealthUnitCode As System.Windows.Forms.Label
    Friend WithEvents stbHSD As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHSD As System.Windows.Forms.Label
    Friend WithEvents cboCenterTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCenterTypeID As System.Windows.Forms.Label
    Friend WithEvents cboTestingPointID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTestingPointID As System.Windows.Forms.Label
    Friend WithEvents cboAccompaniedByID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccompaniedByID As System.Windows.Forms.Label
    Friend WithEvents cboConsentID As System.Windows.Forms.ComboBox
    Friend WithEvents lblConsentID As System.Windows.Forms.Label
    Friend WithEvents lblNoConsentReasonID As System.Windows.Forms.Label
    Friend WithEvents tbcHCTClientCard As System.Windows.Forms.TabControl
    Friend WithEvents tpgSectionAB As System.Windows.Forms.TabPage
    Friend WithEvents tpgConsentResults As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stbVillage As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents stbSubCounty As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents stbParish As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbOccupation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboPatnerTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPatnerTypeID As System.Windows.Forms.Label
    Friend WithEvents cboPatnerResultID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPatnerResultID As System.Windows.Forms.Label
    Friend WithEvents lblKnowAboutServiceID As System.Windows.Forms.Label
    Friend WithEvents lblPatnerTestedHIVID As System.Windows.Forms.Label
    Friend WithEvents cboPatnerTestedHIVID As System.Windows.Forms.ComboBox
    Friend WithEvents cboResultThreeMonthsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblNoTestsInTwelveMonthsID As System.Windows.Forms.Label
    Friend WithEvents lblResultThreeMonthsID As System.Windows.Forms.Label
    Friend WithEvents cboNoTestsInTwelveMonthsID As System.Windows.Forms.ComboBox
    Friend WithEvents cboResultSixMonthsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblResultTwelveMonthsID As System.Windows.Forms.Label
    Friend WithEvents lblResultSixMonthsID As System.Windows.Forms.Label
    Friend WithEvents cboResultTwelveMonthsID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPreTestCounselingID As System.Windows.Forms.Label
    Friend WithEvents lblHIVTestSixMonthsID As System.Windows.Forms.Label
    Friend WithEvents cboHIVTestSixMonthsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblHIVTestThreeMonthsID As System.Windows.Forms.Label
    Friend WithEvents cboHIVTestThreeMonthsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTestedHIVBeforeID As System.Windows.Forms.Label
    Friend WithEvents cboTestedHIVBeforeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSexualPatnerNo As System.Windows.Forms.Label
    Friend WithEvents nbxSexualPatnerNo As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblMaritalStatusID As System.Windows.Forms.Label
    Friend WithEvents cboMaritalStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblHCTEntryPoint As System.Windows.Forms.Label
    Friend WithEvents cboHCTEntryPoint As System.Windows.Forms.ComboBox
    Friend WithEvents lblCounseledAsID As System.Windows.Forms.Label
    Friend WithEvents cboCounseledAsID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPreTestCounselingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblHIVTestTwelveMonthsID As System.Windows.Forms.Label
    Friend WithEvents cboHIVTestTwelveMonthsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWhereLinkedToCareID As System.Windows.Forms.Label
    Friend WithEvents cboWhereLinkedToCareID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLinkedToCareID As System.Windows.Forms.Label
    Friend WithEvents cboLinkedToCareID As System.Windows.Forms.ComboBox
    Friend WithEvents stbCounselorName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStartedCotrimoxazoleID As System.Windows.Forms.Label
    Friend WithEvents lblCounselorName As System.Windows.Forms.Label
    Friend WithEvents cboStartedCotrimoxazoleID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpCounselDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCounselDate As System.Windows.Forms.Label
    Friend WithEvents stbReferralReason As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferralReason As System.Windows.Forms.Label
    Friend WithEvents lblHIVResultID As System.Windows.Forms.Label
    Friend WithEvents lblSTIID As System.Windows.Forms.Label
    Friend WithEvents cboSTIID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTBSuspicionID As System.Windows.Forms.Label
    Friend WithEvents cboTBSuspicionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoupleResultsID As System.Windows.Forms.Label
    Friend WithEvents cboCoupleResultsID As System.Windows.Forms.ComboBox
    Friend WithEvents cboHIVResultID As System.Windows.Forms.ComboBox
    Friend WithEvents lblResultReceivedAsCoupleID As System.Windows.Forms.Label
    Friend WithEvents cboResultReceivedAsCoupleID As System.Windows.Forms.ComboBox
    Friend WithEvents stbTestDoneBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblResultReceivedID As System.Windows.Forms.Label
    Friend WithEvents lblTestDoneBy As System.Windows.Forms.Label
    Friend WithEvents cboResultReceivedID As System.Windows.Forms.ComboBox
    Friend WithEvents stbDesignation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTestDate As System.Windows.Forms.Label
    Friend WithEvents lblDesignation As System.Windows.Forms.Label
    Friend WithEvents dtpTestDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents stbDistrict As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents clbNoConsentReason As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbKnowAboutServiceID As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnPrintConsent As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents chkPrintTestResults As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintConsent As System.Windows.Forms.CheckBox

End Class