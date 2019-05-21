
/***************************************************************
This Script is a property of ClinicMaster INTERNATIONAL
Un authorised use or ammendment is not permitted
-- Last updated 10/02/2016 by Wilson Kutegeka
***************************************************************/

use ClinicMaster
go

------Options---------------------------------------------------------
exec uspEditOptions 'AllowNetworkMultipleLogins', 0, '3BIT', 1, 0
exec uspEditOptions 'NullDateValue', '1 Jan 1900', '3DTE', 18, 1
exec uspEditOptions 'DecimalPlaces', 2, '3NUM', 1, 0
exec uspEditOptions 'SchemeMembersMaxDependants', 2, '3NUM', 2, 0
exec uspEditOptions 'EnableAuditTrail', 1, '3BIT', 1, 1
exec uspEditOptions 'UserIdleDuration', 30, '3NUM', 2, 0
exec uspEditOptions 'Currency', 'UGX', '3STR', 10, 1
exec uspEditOptions 'MedicalCardNoPrefix', '', '3STR', 10, 1
exec uspEditOptions 'PatientNoPrefix', '', '3STR', 10, 1
exec uspEditOptions 'ReceiptNoPrefix', '', '3STR', 10, 1
exec uspEditOptions 'SelfRequestNoPrefix', 'SR', '3STR', 10, 1
exec uspEditOptions 'StaffNoPrefix', 'S', '3STR', 1, 1
exec uspEditOptions 'DrugNoPrefix', 'DRG', '3STR', 20, 1
exec uspEditOptions 'OtherItemsPrefix', 'OTH', '3STR', 20, 1
exec uspEditOptions 'ConsumableNoPrefix', 'CON', '3STR', 20, 1
exec uspEditOptions 'FingerprintDevice', '105DP', '3STR', 5, 1
exec uspEditOptions 'DisableConstraints', 0, '3BIT', 1, 1
exec uspEditOptions 'AllowPrescriptionToNegative', 1, '3BIT', 1, 0
exec uspEditOptions 'AllowPrescriptionExpiredDrugs', 1, '3BIT', 1, 0
exec uspEditOptions 'AllowDispensingToNegative', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowDispensingExpiredDrugs', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowPrescriptionExpiredConsumables', 1, '3BIT', 1, 0
exec uspEditOptions 'AllowDispensingExpiredConsumables', 0, '3BIT', 1, 0
exec uspEditOptions 'IncorporateFingerprintCapture', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowPrintingPatientFaceSheet', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowPrintingAdmissionFaceSheet', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowPrintingPatientBioData', 0, '3BIT', 1, 0
exec uspEditOptions 'FingerprintCaptureAgeLimit', 3, '3NUM', 1, 0
exec uspEditOptions 'AllowPartialCashPayment', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowAccessCashServices', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowAccessCoPayServices', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowAccessCashDischarges', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowCreateMultipleVisits', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowCreateMultipleSpecialityVisits', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceSmartCardProcessing', 0, '3BIT', 1, 0
exec uspEditOptions 'SmartCardConnectionAttemptNo', 10, '3NUM', 3, 0
exec uspEditOptions 'SmartCardServiceProviderNo', '1234567890ABC', '3STR', 20, 0
exec uspEditOptions 'AllowCreateMultipleExtraBills', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowSmartCardApplicableVisit', 1, '3BIT', 1, 0
exec uspEditOptions 'IncludeMonthsForAgesBelow', 3, '3NUM', 2, 0
exec uspEditOptions 'ExpiryWarningDays', 60, '3NUM', 3, 0
exec uspEditOptions 'DisablePatientRegistration', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableVisitsCreation', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableExtras', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableTriagePoint', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableCashier', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableInvoices', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableDoctor', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableLaboratory', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableCaradiology', 0, '3BIT', 1, 0

exec uspEditOptions 'DisableRadiology', 0, '3BIT', 1, 0
exec uspEditOptions 'DisablePharmacy', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableTheatre', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableDental', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableAppointments', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableInPatients', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableManageART', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableDeaths', 0, '3BIT', 1, 0
exec uspEditOptions 'DisablePathology', 0, '3BIT', 1, 0
exec uspEditOptions 'DoctorVisitUpdateDays', 14, '3NUM', 2, 0
exec uspEditOptions 'AllowExtendedVisitEdits', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowProvisionalPrinting', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowDirectDebitBalanceEntry', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowDirectDiscountCashPayment', 0, '3BIT', 1, 0
exec uspEditOptions 'HideCashPaymentReceiptDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'HideBillFormPaymentReceiptDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'HideCreditBillsPaymentReceiptDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'HideCreditBillFormPaymentReceiptDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'HideAccessCashServicesAtVisits', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowProcessingPendingItems', 1, '3BIT', 1, 0
exec uspEditOptions 'HideCashReceiptHeader', 0, '3BIT', 1, 0
exec uspEditOptions 'HideInvoiceHeader', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowCreateMultipleVisitInvoices', 0, '3BIT', 1, 0
exec uspEditOptions 'AutoRenewSchemeMembers', 0, '3BIT', 1, 0
exec uspEditOptions 'HideDoctorBillServiceFee', 0, '3BIT', 1, 0
exec uspEditOptions 'HideBillFormDrugDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'HideBillFormItemsPresentAtIPDDoctor', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceInsuranceFingerprintVerification', 0, '3BIT', 1, 0
exec uspEditOptions 'ActivePatientMonths', 24, '3NUM', 2, 0
exec uspEditOptions 'ForceAccountMainMemberName', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowCreditSelfRequests', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowInsuranceDirectLinkedMember', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceDiagnosisOnPrescription', 0, '3BIT', 1, 0
exec uspEditOptions 'ForcePatientGeographicalLocation', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowPrintingBeforeDispensing', 0, '3BIT', 1, 0
exec uspEditOptions 'OpenIPDDispenseAfterPrescription', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowManualIssuingToNegative', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowLocationIssuingToNegative', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowGenerateSelfRequestsNo', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableAccessCashServices', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSetAssociatedBillCustomer', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSetInventoryLocation', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableInventoryPhysicalStockEntry', 0, '3BIT', 1, 0
exec uspEditOptions 'OpenIssueConsumablesAfterPrescription', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowInventoryManualIssuing', 1, '3BIT', 1, 0
exec uspEditOptions 'DisablePatientSignOnInvoices', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowAccessOPDTheatre', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowManualAccountDebitEntry', 0, '3BIT', 1, 0
exec uspEditOptions 'VisitReviewDays', 0, '3NUM', 2, 0
exec uspEditOptions 'CashPaymentPercentBeforeAdmission', 0, '3NUM', 3, 0
exec uspEditOptions 'LockVisitUponInvoiceCreation', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceDispensingPreviousPrescription', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowPrintingPatientFaceSheet', 0, '3BIT', 1, 0
exec uspEditOptions 'CategorizeVisitPaymentDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'CategorizeVisitInvoiceDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictDoctorLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictDrawnByLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictLabTechnologistLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictPharmacistLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictRadiologistLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictPathologistLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'GroupVisitInvoiceDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowExtraBillInventoryIssuing', 0, '3BIT', 1, 0
exec uspEditOptions 'SendSMSUsingAPI001', 0, '3BIT', 1, 0
exec uspEditOptions 'SendSMSUsingAPI002', 0, '3BIT', 1, 0
exec uspEditOptions 'SendSMSUsingAPI003', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationAtAppointments', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationAtCashPayment', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationAtLab', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationAtPatientReg', 0, '3BIT', 1, 0
exec uspEditOptions 'InventoryAlertDays', 7, '3NUM', 2, 0
exec uspEditOptions 'DisableDosageAndDurationAtSelfRequest', 0, '3BIT', 1, 0
exec uspEditOptions 'CaptureAndUseBarCodes', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationAtCardiology', 0, '3BIT', 1, 0

exec uspEditOptions 'EnableSMSNotificationAtRadiology', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationAtVisits', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationForBirthdays', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationForIncomeSummaries', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceDiagnosisAtDoctor', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceLabResultsVerification', 0, '3BIT', 1, 0
exec uspEditOptions 'OpenIPDTheatreIssueConsumablesAfterPrescription', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowAccessCashConsultation', 0, '3BIT', 1, 0
exec uspEditOptions 'IncomeSummariesSMSTime', '7:31:00 PM', '3STR', 20, 0
exec uspEditOptions 'EnableSMSNotificationAtManageAccounts', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableQueue', 0, '3BIT', 1, 0
exec uspEditOptions 'QueueReadCount', 3, '3NUM', 1, 0
exec uspEditOptions 'IncomeSummariesSMSTime(2)', '8:31:00 AM', '3STR', 20, 0
exec uspEditOptions 'SMSLifeSpanAppointments', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanCashier', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanVisits', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanCardiology', '30', '3NUM', 2, 0

exec uspEditOptions 'SMSLifeSpanRadiology', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanLab', '3', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanPatientReg', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanIncomeSummaries', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanManageACCs', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanBirthDays', '5', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanPharmacy', '3', '3NUM', 2, 0
exec uspEditOptions 'AllowCreateInvoicesAtCashPayments', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowIssueStockOnLabRequest', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableCommentsAtPrintingLabReport', 1, '3BIT', 1, 0
exec uspEditOptions 'ForceFingerPrintOnSelfRequestLabReport', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowCustomAdmissionNoFormat', 0, '3BIT', 1, 1
exec uspEditOptions 'AllowDrugsServiceFee', 0, '3BIT', 1, 1
exec uspEditOptions 'EnableMemberLimitBalanceTracking',0, '3BIT', 1, 0
exec uspEditOptions 'DisableFinance', 0, '3BIT', 1, 0
exec uspEditOptions 'EnablePrintingInvoicesWithCompanyName', 0, '3BIT', 1, 0
exec uspEditOptions 'GenerateInventoryInvoiceOnDispensingOnly', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceInventoryAcknowledgementBeforeOrdering', 0, '3BIT', 1, 0
exec uspEditOptions 'ImmunisationNoPrefix', 'I', '3STR', 1, 1

exec uspEditOptions 'ServiceCodePrefix', 'SER', '3STR', 20, 1
exec uspEditOptions 'DentalCodePrefix', 'DEN', '3STR', 20, 1
exec uspEditOptions 'OpticalCodePrefix', 'OPT', '3STR', 20, 1
exec uspEditOptions 'EyeCodePrefix', 'EYE', '3STR', 20, 1
exec uspEditOptions 'ICUCodePrefix', 'ICU', '3STR', 20, 1
exec uspEditOptions 'TheatreCodePrefix', 'THE', '3STR', 20, 1
exec uspEditOptions 'MaternityCodePrefix', 'MAT', '3STR', 20, 1
exec uspEditOptions 'ExtraItemCodePrefix', 'EXT', '3STR', 20, 1
exec uspEditOptions 'PackageNoPrefix', 'PAC', '3STR', 20, 1
exec uspEditOptions 'ProcedureCodePrefix', 'PRO', '3STR', 20, 1
exec uspEditOptions 'TestCodePrefix', 'LAB', '3STR', 20, 1
exec uspEditOptions 'BedNoPrefix', 'BED', '3STR', 20, 1
exec uspEditOptions 'CardiologyExamCodePrefix', 'CAR', '3STR', 20, 1
exec uspEditOptions 'RadiologyExamCodePrefix', 'RAD', '3STR', 20, 1
exec uspEditOptions 'PathologyExamCodePrefix', 'PAT', '3STR', 20, 1

exec uspEditOptions 'RequisitionNoPrefix', 'REQ', '3STR', 20, 1
exec uspEditOptions 'RequisitionApprovalNoPrefix', 'APP', '3STR', 20, 1
exec uspEditOptions 'RequisitionPaymentNoPrefix', 'PAY', '3STR', 20, 1

exec uspEditOptions 'ANCNoPrefix', 'ANC', '3STR', 20, 1
exec uspEditOptions 'AdmissionMaxDays', 30, '3NUM', 2, 0
exec uspEditOptions 'DisallowPaymentOfOutStockDrugs', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceTBAssessmentAtTriage', 1, '3BIT', 1, 0
exec uspEditOptions 'EnableSecondPatientForm', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableVisitToSeeDoctorSelection', 1, '3BIT', 1, 0
exec uspEditOptions 'LockItemsUnitPrices', 1, '3BIT', 1, 0
exec uspEditOptions 'ForceBillableMappings', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableVisitDate',0, '3BIT', 1, 0
exec uspEditOptions 'EnableInvoiceDate',0, '3BIT', 1, 0
exec uspEditOptions 'EnablePayDate',0, '3BIT', 1, 0

go
-- select * from Options

------Services--------------------------------------------------------
exec uspInsertServices 'NA', 'NA','16VIS','30DOC', 0, 0,0,0
exec uspInsertServices '10C', 'Consultation','16VIS','30DOC', 0,0,20000,0
exec uspInsertServices 'HOS', 'Hospitalization','16DIS', '30DIS', 0,0,30000,0
exec uspInsertServices 'REV', 'Review','16VIS','30DOC', 0,0,10000,0
exec uspInsertServices 'PHY', 'Physiotherapy','16VIS','30VIS', 0, 0,20000,0
exec uspInsertServices 'MEX', 'Medical Examination','16VIS','30VIS', 0,0,20000,0
go

-- select * from services
-- delete from Services 

-------------- ExtraChargeItems ---------------------------------------------------------------

exec uspInsertExtraChargeItems 'CPV', 'CO-PAY VALUE', '145GEN', 0, 0,0,0
go

-- select * from ExtraChargeItems
-- delete from ExtraChargeItems

-------------- MemberBenefits -----------------------------------------------------------------

exec uspInsertMemberBenefits '7S', 'Service', '7S'
exec uspInsertMemberBenefits '7D', 'Drug', '7D'
exec uspInsertMemberBenefits '7C', 'Consumable', '7C'
exec uspInsertMemberBenefits '7P', 'Procedure', '7P'
exec uspInsertMemberBenefits '7T', 'Test', '7T'
exec uspInsertMemberBenefits '7CA', 'Cardiology', '7CA'

exec uspInsertMemberBenefits '7R', 'Radiology', '7R'
exec uspInsertMemberBenefits '7N', 'Dental', '7N'
exec uspInsertMemberBenefits '7H', 'Theatre', '7H'
exec uspInsertMemberBenefits '7O', 'Optical', '7O'
exec uspInsertMemberBenefits '7M', 'Maternity', '7M'
exec uspInsertMemberBenefits '7I', 'ICU', '7I'
exec uspInsertMemberBenefits '7E', 'Extras', '7E'
exec uspInsertMemberBenefits '7Y', 'Eye', '7Y'
exec uspInsertMemberBenefits '7A', 'Admission', '7A'
exec uspInsertMemberBenefits '7OP', 'Out Patient'
exec uspInsertMemberBenefits '7IP', 'In Patient'
go

--------Bill Customers------------------------------------------------

exec uspInsertBillCustomers 'CASH', 'Cash Customer', '18IND', '', '', '', '', '', '', '', null, '', '', '44NA', 0, 0, 0, 0, 0, 0, 0, 0, 0, '1A'
exec uspInsertBillCustomers 'SUSP', 'SUSPENSE ACCOUNT', '18IND', '', '', '', '', '', '', '', null, '', '', '44NA', 0, 0, 0, 0, 0, 0, 0, 0, 1, '1A'
go

-- select * from BillCustomers where AccountNo = 'SIL'
-- delete from BillCustomers where AccountNo = 'SIL'
-- CDC
-- PEPFA
-- MOH Ministry of Health

--------DrugCategories------------------------------------------------

exec uspInsertDrugCategories '4ARVB','ARV BRAND',0,0,'X','31M',''
exec uspInsertDrugCategories '4ARVG','ARV GENERIC',0,0,'X','31M',''
exec uspInsertDrugCategories '4CRE','CREAMS',1,2,';','31A',''
exec uspInsertDrugCategories '4DRO','DROPS',0,0,'X','31M',''
exec uspInsertDrugCategories '4EYE','EYE OITMENT',0,0,'X','31M',''
exec uspInsertDrugCategories '4GEL','GEL',0,0,'X','31M',''
exec uspInsertDrugCategories '4INJ','INJECTABLES',0,0,'X','31M',''
exec uspInsertDrugCategories '4IV','I.V',0,0,'X','31M',''
exec uspInsertDrugCategories '4LOT','LOTION',0,0,'X','31M',''
exec uspInsertDrugCategories '4OIT','OITMENT',0,0,'X','31M',''
exec uspInsertDrugCategories '4PEN','PENCIL',0,0,'X','31M',''
exec uspInsertDrugCategories '4SHA','SHAMPOO',0,0,'X','31M',''
exec uspInsertDrugCategories '4SYR','SYRUPS',1,1,'X','31M',''
exec uspInsertDrugCategories '4TAB','TABLETS MULTIPLY',0,0,'X','31M',''
exec uspInsertDrugCategories '4TABA','TABLETS ADD',0,0,';','31A',''
go


-- select * from DrugCategories
-- delete from DrugCategories

--------ARV Drugs---------------------------------------------------------------------------------------------------------------

exec uspInsertDrugs 'A001','NEVIMUNE ORAL SOLUTION','','4ARVG','4ARVG','8NA',0,0,0,0,2000,'Jan 22 2010'
exec uspInsertDrugs 'A002','NEVIMUNE TAB 200MG BRAND','','4ARVG','4ARVG','8NA',0,0,0,0,14000,'Jan 22 2010'
exec uspInsertDrugs 'A002B','NEVIMUNE TAB 200MG','','4ARVG','4ARVG','8NA',0,0,0,0,6000,'Jan 22 2010'
exec uspInsertDrugs 'A003','DOUVIR','','4ARVG','4ARVG','8NA',0,0,0,0,20000,'Jan 22 2010'
exec uspInsertDrugs 'A003B','DUOVIR-N','','4ARVG','4ARVG','8NA',0,0,0,0,45000,'Jan 22 2010'
exec uspInsertDrugs 'A004','MAXIVIR TAB','','4ARVG','4ARVG','8NA',0,0,0,0,38000,'Jan 22 2010'
exec uspInsertDrugs 'A004B','TRIOMUNE TAB 40','','4ARVG','4ARVG','8NA',0,0,0,0,40000,'Jan 22 2010'
exec uspInsertDrugs 'A005','TRIOMUNE TAB 30','','4ARVG','4ARVG','8NA',0,0,0,0,42000,'Jan 22 2010'
exec uspInsertDrugs 'A005B','LAMIVUDINE TAB 150MG','','4ARVB','4ARVB','8NA',0,0,0,0,9000,'Jan 22 2010'
exec uspInsertDrugs 'A007','LAMIVIR TAB 150 MG','','4ARVG','4ARVG','8NA',0,0,0,0,15000,'Jan 22 2010'
exec uspInsertDrugs 'A011B','ZIDOVUDINE TAB 300','','4ARVG','4ARVG','8NA',0,0,0,0,22000,'Jan 22 2010'
exec uspInsertDrugs 'A012','STAVIR TAB 40MG','','4ARVG','4ARVG','8NA',0,0,0,0,6000,'Jan 22 2010'
exec uspInsertDrugs 'A013','STAVIR TAB 30MG','','4ARVG','4ARVG','8NA',0,0,0,0,5000,'Jan 22 2010'
exec uspInsertDrugs 'A017','ABACAVIR TAB 300MG','','4ARVB','4ARVB','8NA',0,0,0,0,180000,'Jan 22 2010'
exec uspInsertDrugs 'A018','STOCRIN TAB 600MG','','4ARVB','4ARVB','8NA',0,0,0,0,60000,'Jan 22 2010'
exec uspInsertDrugs 'A019','STOCRIN CAP 200MG','','4ARVB','4ARVB','8NA',0,0,0,0,90000,'Jan 22 2010'
exec uspInsertDrugs 'A020','VIDEX TAB 100MG','','4ARVB','4ARVB','8NA',0,0,0,0,130000,'Jan 22 2010'
exec uspInsertDrugs 'A021','VIDEX TAB 200MG','','4ARVB','4ARVB','8NA',0,0,0,0,70000,'Jan 22 2010'
exec uspInsertDrugs 'A021C','VIDEX TAB 25MG','','4ARVB','4ARVB','8NA',0,0,0,0,12000,'Jan 22 2010'
exec uspInsertDrugs 'A021D','VIDEX TAB 50MG','','4ARVB','4ARVB','8NA',0,0,0,0,32000,'Jan 22 2010'
exec uspInsertDrugs 'A022','EPIVIR ORAL SOLUTION','','4ARVB','4ARVB','8NA',0,0,0,0,18000,'Jan 22 2010'
exec uspInsertDrugs 'A023','EPIVIR TAB 150MG','','4ARVB','4ARVB','8NA',0,0,0,0,15000,'Jan 22 2010'
exec uspInsertDrugs 'A024','TRIZIVIR TAB 300/150/300MG','','4ARVB','4ARVB','8NA',0,0,0,0,230000,'Jan 22 2010'
exec uspInsertDrugs 'A025','ZERIT CAP 20MG','','4ARVB','4ARVB','8NA',0,0,0,0,12000,'Jan 22 2010'
exec uspInsertDrugs 'A026','ZERIT CAP 30MG','','4ARVB','4ARVB','8NA',0,0,0,0,5000,'Jan 22 2010'
exec uspInsertDrugs 'A027','ZERIT CAP 40MG','','4ARVB','4ARVB','8NA',0,0,0,0,10000,'Jan 22 2010'
exec uspInsertDrugs 'A028','ZERIT ORAL SOLUTION','','4ARVB','4ARVB','8NA',0,0,0,0,20000,'Jan 22 2010'
exec uspInsertDrugs 'A029','COMBIVIR TAB 450MG','','4ARVB','4ARVB','8NA',0,0,0,0,60000,'Jan 22 2010'
exec uspInsertDrugs 'A030','KALETRA CAP 133.3/33.3','','4ARVB','4ARVB','8NA',0,0,0,0,120000,'Jan 22 2010'
exec uspInsertDrugs 'A032','CRIXIVAN CAP 400MG','','4ARVB','4ARVB','8NA',0,0,0,0,90000,'Jan 22 2010'
exec uspInsertDrugs 'A036','VIRAMUNE TAB 200MG','','4ARVB','4ARVB','8NA',0,0,0,0,110000,'Jan 22 2010'
exec uspInsertDrugs 'A037','VIRAMUNE SYRUP','','4ARVB','4ARVB','8NA',0,0,0,0,89000,'Jan 22 2010'
exec uspInsertDrugs 'A038','RITONAVIR CAP 100 MG (NORVIR)','','4ARVB','4ARVB','8NA',0,0,0,0,0,'Jan 22 2010'
exec uspInsertDrugs 'A050A','RETROVIR SYRUP 10MG/ ML','','4ARVG','4ARVG','8NA',0,0,0,0,21000,'Jan 22 2010'
exec uspInsertDrugs 'A058','ZERIT CAP 15MG','','4ARVB','4ARVB','8NA',0,0,0,0,11000,'Jan 22 2010'
exec uspInsertDrugs 'A059','KALETRA SYRUP','','4ARVB','4ARVB','8NA',0,0,0,0,19000,'Jan 22 2010'
exec uspInsertDrugs 'A060','ABACAVIR (ZIAGEN) SYR 20MG/ML','','4ARVB','4ARVB','8NA',0,0,0,0,80000,'Jan 22 2010'
exec uspInsertDrugs 'A076','ZIAGEN TAB 300MG','','4ARVB','4ARVB','8NA',0,0,0,0,195000,'Jan 22 2010'
exec uspInsertDrugs 'A107','LAMIVIR SYRUP','','4ARVG','4ARVG','8NA',0,0,0,0,8000,'Jan 22 2010'
exec uspInsertDrugs 'A121','RETROVIR TAB 300MG','','4ARVB','4ARVB','8NA',0,0,0,0,60000,'Jan 22 2010'
exec uspInsertDrugs 'A130','TRUVADA TAB 200/300MG','','4ARVB','4ARVB','8NA',0,0,0,0,75000,'Jan 22 2010'
exec uspInsertDrugs 'A131','RETROVIR CAP 100MG','','4ARVB','4ARVB','8NA',0,0,0,0,20000,'Jan 22 2010'
exec uspInsertDrugs 'A320','ZIDOVIR TAB 300MG','','4ARVG','4ARVG','8NA',0,0,0,0,25000,'Jan 22 2010'
exec uspInsertDrugs 'A321','ZIDOVIR SYRUP 10MG','','4ARVB','4ARVB','8NA',0,0,0,0,6000,'Jan 22 2010'
exec uspInsertDrugs 'A325','DIDANOSINE CAP 400MG','','4ARVB','4ARVB','8NA',0,0,0,0,80000,'Jan 22 2010'
exec uspInsertDrugs 'A326','DIDANOSINE TAB 200MG','','4ARVB','4ARVB','8NA',0,0,0,0,79000,'Jan 22 2010'
exec uspInsertDrugs 'A327','DIDANOSINE CAP 250MG','','4ARVB','4ARVB','8NA',0,0,0,0,89000,'Jan 22 2010'
exec uspInsertDrugs 'A328','DIDANOSINE TAB 100MG','','4ARVB','4ARVB','8NA',0,0,0,0,48000,'Jan 22 2010'
exec uspInsertDrugs 'A329','DIDANOSINE TAB 50MG','','4ARVB','4ARVB','8NA',0,0,0,0,18000,'Jan 22 2010'
exec uspInsertDrugs 'A330','DIDANOSINE TAB 25MG','','4ARVB','4ARVB','8NA',0,0,0,0,86400,'Jan 22 2010'
go

--------Other Drugs---------------------------------------------------------------------------------------------------------------

exec uspInsertDrugs 'M129', 'ACENAC- TAB100mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M429', 'ACTIFED DRY- SYP', '', '4SYR', '4SYR','8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M329', 'ACTIFED WET- SYP', '', '4SYR', '4SYR','8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M327', 'ACYCLOVIR- CRM15mg', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M130', 'ACYCLOVIR- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0,500, 'Jan 22 2010'
exec uspInsertDrugs 'M317', 'ADRENALIN- INJ', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M219', 'AGOMYCIN- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M343', 'ALBASOL-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M604', 'ALBENDAZOLE - SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0, 0,5000, 'Jan 22 2010'
exec uspInsertDrugs 'M040', 'ALBENDAZOLE-TAB400mg', '', '4TAB','4TAB', '8NA', 0, 0, 0, 0,2000, 'Jan 22 2010'
exec uspInsertDrugs 'M601', 'AMBRODAL- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M099', 'AMILODIPINE- TAB10mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M042', 'AMILODIPINE- TAB5mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M131', 'AMINOPHILINE-TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M002', 'AMINOPHYLINE- @amp', '', '4INJ', '4INJ','8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M133', 'AMITRIPYILINE- TAB25mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M606', 'AMODIAQUINE- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 800, 'Jan 22 2010'
exec uspInsertDrugs 'M043', 'AMOXYl- TAB250mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M172', 'AMOXYL-SYP', '', '4SYR', '4SYR','8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M605', 'AMPICILLIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M029', 'AMPICILLIN-@amp500mg', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M173', 'AMPICLOX Reagel-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M134', 'AMPICLOX- TAB500mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M030', 'AMPICLOX-@amp', '', '4INJ', '4INJ','8NA', 0, 0, 0, 0,3000, 'Jan 22 2010'
exec uspInsertDrugs 'M132', 'ANPICILLIN- TAB250mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M360', 'ANTINAL - SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M335', 'APRINOX- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M304', 'ARGUMENTIN', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 30000, 'Jan 22 2010'
exec uspInsertDrugs 'M509', 'ARTEFAN- TAB', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 800, 'Jan 22 2010'
exec uspInsertDrugs 'M003', 'ARTEMETHER- @amp80mg', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M176', 'ARTEMETHER-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M031', 'ARTEMETHER-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2500, 'Jan 22 2010'
exec uspInsertDrugs 'M600', 'ARTENAM', '', '4TAB','4TAB', '8NA', 0, 0, 0, 0,800, 'Jan 22 2010'
exec uspInsertDrugs 'M810', 'ARTEQUIN 600/750', '', '4TAB', '4TAB','8PK', 10, 10, 0,0, 12400, 'Jan 22 2010'
exec uspInsertDrugs 'M046', 'ASCOBICACID- TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0, 0, 0,50, 'Jan 22 2010'
exec uspInsertDrugs 'M220', 'ASCORIL- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M348', 'ASMOL- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M045', 'ASPIRIN- TAB300mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M047', 'ASPIRIN- TAB75mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M079', 'ATANE- TAB2mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M078', 'ATANE- TAB5mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M049', 'ATENOLOL- TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M048', 'ATENOLOL- TAB50mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M310', 'ATORVASAN- TAB20mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M069', 'ATORVASTATIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M032', 'ATROPINE-@amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M236', 'AUGMENTIN- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 30000, 'Jan 22 2010'
exec uspInsertDrugs 'M312', 'AUROZIL- SYP250mg/5', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 27000, 'Jan 22 2010'
exec uspInsertDrugs 'M221', 'AZIFLAM- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M044', 'AZITHROMYCIN- TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 3500, 'Jan 22 2010'
exec uspInsertDrugs 'M174', 'AZITHROMYCIN-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M609', 'B.B.E. LOTION- LOT', '', '4LOT','4LOT', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M123', 'BASCOPAIN- TAB10mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M175', 'BENYLIN 4 FLU-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M608', 'BENYLIN CODINE- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M005', 'BENZATHINE PEN- @vial', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M322', 'BENZHXOL- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M341', 'BENZOX- GEL', '', '4GEL','4GEL', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M222', 'BENZYL BENZOATE- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 8000, 'Jan 22 2010'
exec uspInsertDrugs 'M006', 'BENZYL PENICILLIN- @vial', '', '4INJ', '4INJ','8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M251', 'BETADERM NEOMYCIN- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M244', 'BETANESE- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M267', 'BETHAMETHASONE-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M292', 'BIOFERON- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M93', 'BIOFREN', '', '4SYR','4SYR', '8NA', 0, 0, 0, 6000,0, 'Jan 22 2010'
exec uspInsertDrugs 'M050', 'BISACODYL- TAB5mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M223', 'BISPANOL- SYP60ml', '', '4SYR', '4SYR','8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M218', 'BONISAN- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0, 0,6000, 'Jan 22 2010'
exec uspInsertDrugs 'M177', 'BRO ZEDEX-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 4000, 'Jan 22 2010'
exec uspInsertDrugs 'M355', 'BROMOCRIPTIN - TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M361', 'BROMOCRIPTINE - TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M178', 'BROZEET-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 4000, 'Jan 22 2010'
exec uspInsertDrugs 'M063', 'BRUSTAN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M245', 'BURN CURE-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M328', 'C-MYCIN- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M301', 'CABAMAZIPINE', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M224', 'CACHFER- SYP200ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M266', 'CAF-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M255', 'CALAMINE-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M308', 'CALCIVITA-TAB50mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M602', 'CALITHROMYCIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M256', 'CANDIDERM-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M051', 'CAPTOPRIL- TAB25mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M281', 'CAUSTIC-PEN', '', '4PEN','4PEN', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M242', 'CEFADROXIL- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M090', 'CEFADROXIL-TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 600, 'Jan 22 2010'
exec uspInsertDrugs 'M701', 'CEFALEXIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M179', 'CEFALEXIN-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M237', 'CEFAMOR- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M072', 'CEFIXINE- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 3500, 'Jan 22 2010'
exec uspInsertDrugs 'M351', 'CEFOTAXIME UK - INJ', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 21000, 'Jan 22 2010'
exec uspInsertDrugs 'M180', 'CEFPODOXIME-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 23000, 'Jan 22 2010'
exec uspInsertDrugs '349', 'CEFTRIAXONE IND- @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M027', 'CEFTRIAXONE UK- @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 21000, 'Jan 22 2010'
exec uspInsertDrugs 'M352', 'CEFUROXIME UK - INJ', '', '4INJ', '4INJ','8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M070', 'CEFUROXIME- TAB250mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M403', 'CEFUROXIME-750 INJ', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M071', 'CEFUROXINE- TAB500', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2500, 'Jan 22 2010'
exec uspInsertDrugs 'M507', 'CENTACID- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5500, 'Jan 22 2010'
exec uspInsertDrugs 'M125', 'CEPHALEXIN- TAB250mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M268', 'CERUMOL-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M054', 'CETRIZINE- TAB10mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M181', 'CETRIZINE-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M135', 'CHARCOAL- TAB50mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M119', 'CHLORAMPHENICAL- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M009', 'CHLORAPEHENICAL- @vial', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M182', 'CHLORAPHENICAL- SYP100ml', '', '4SYR', '4SYR','8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M056', 'CHLOROPHENIRAMINE- TAB4mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M004', 'CHLOROPROMAZINE- @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M055', 'CHLOROQUINE- TAB250mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M183', 'CHLORPHENIRAMINE-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M057', 'CIMETIDINE- TAB200mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M058', 'CIMETIDINE- TAB400mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M300', 'CIPRO- I.V', '', '4IV', '4IV','8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M059', 'CIPROFLAXACIN- TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M170', 'CLARITHROMYCIN UK - TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M184', 'CLAVULIN-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M305', 'CLAVULIN-TAB375mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M306', 'CLAVULIN-TAB625mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M316', 'CLEXAN- INJ80mg', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 30000, 'Jan 22 2010'
exec uspInsertDrugs 'M246', 'CLOBETASOL- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 12000, 'Jan 22 2010'
exec uspInsertDrugs 'M289', 'CLONEM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M138', 'CLOTRIMAZOLE- PESS100mg', '', '4TAB','4TAB', '8NA', 0, 0, 0, 0,1000, 'Jan 22 2010'
exec uspInsertDrugs 'M257', 'CLOTRIMAZOLE-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M139', 'CLOXA- TAB250mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M033', 'CLOXA-@amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M185', 'CLOXACILLIN-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M357', 'CO ARTESIANE - SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M186', 'CO ARTESIANE-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M321', 'COARTEM- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M145', 'CODEINE PHOSPHATE- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M187', 'COLD CAP- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M140', 'COLDCAP-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M188', 'CONTRIMOXAZOLE-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M136', 'COTRIMOXAZOLE- 100mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M700', 'COUSTIC PENCIL- PEN', '', '4PEN','4PEN', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M359', 'DEEP HEAT - CRM', '', '4CRE', '4CRE','8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M247', 'DEEP HEAT-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M189', 'DELEASED DRY-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M225', 'DELEASED WET- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs '285', 'DERMIDEX', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M149', 'DERMOREN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M066', 'DEXA- TAB5mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M349', 'DEXAMETHASONE - vial', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M260', 'DEXAMETHASONE-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0, 0,3000, 'Jan 22 2010'
exec uspInsertDrugs 'M909', 'DEXONA CADILA- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M011', 'DEXONA- @vial', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M034', 'DEXONA-drp', '', '4DRO', '4DRO','8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M036', 'DEXTROSE 5% -IV  1st', '', '4IV','4IV', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M350', 'DEXTROSE 5%- IV  2nd', '', '4IV','4IV', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M037', 'DEXTROSE 50%-IV', '', '4IV','4IV', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M706', 'DIAZEPAM- INJ', '', '4INJ','4IV', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M067', 'DIAZEPERM- TAB5mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M013', 'DICLOFENAC- @amp', '', '4INJ', '4INJ','8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M068', 'DICLOFENAC- TAB50mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M269', 'DICLOFENAC-GEL', '', '4GEL','4GEL',  '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M143', 'DOXY- TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M062', 'DUO-COTECXIN-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1900, 'Jan 22 2010'
exec uspInsertDrugs 'M126', 'DUPHASTON- TAB10mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M041', 'DURAGESIC-TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M226', 'EASCOF- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M217', 'EASCOF- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M282', 'EBASTIN- TAB', '', '4TAB', '4TAB','8MGL', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M259', 'ECODAX G-CRM', '', '4CRE', '4CRE','8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M110', 'ENALAPRIL- TAB10mg', '', '4TAB','4TAB',  '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M109', 'ENALAPRIL- TAB5mg', '', '4TAB','4TAB',  '8NA', 0, 0, 0,0, 400, 'Jan 22 2010'
exec uspInsertDrugs 'M407', 'ENHACIN- 375mgTAB', '', '4TAB','4TAB',  '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M408', 'ENHACIN-625mgTAB', '', '4TAB','4TAB',  '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M028', 'EPHEDRINE- INJ30mg', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M014', 'ERGOMETRINE- @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M345', 'ERYTHRO(REGAL)- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M707', 'ERYTHRO- SYPLocal', '', '4SYR','4SYR', '8NA', 0, 0, 0, 0,5000, 'Jan 22 2010'
exec uspInsertDrugs 'M074', 'ERYTHROMYCIN- TAB250mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M076', 'FANSIDAR- TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M190', 'FANSIDAR-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M353', 'FEFOL- CAP', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M073', 'FEFOL-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M191', 'FERRO B- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M077', 'FERROUS SULPHATE- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M809', 'FLAMOCIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M501', 'FLEMING- 625mgSYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M502', 'FLEMING-SYP375mg', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M147', 'FLUCLOXACILLIN- TAB10mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M080', 'FLUCONAZOLE- TAB150mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1500, 'Jan 22 2010'
exec uspInsertDrugs 'M081', 'FLUCONAZOLE- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M197', 'FLUFED-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M082', 'FLUFED-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M083', 'FOLIC ACID- TAB5mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M084', 'FRUSEMIDE- TAB40mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M035', 'FRUSEMIDE-@amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M286', 'FUNGRIL-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M708', 'G/ BORAX', '', '4GEL','4GEL', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M144', 'GASEX- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M015', 'GENTAMYCIN- @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M261', 'GENTAMYCIN-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M065', 'GESTID-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M157', 'GLIBENCLAMIDE- TAB', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M270', 'GLYCERIN BORAX-DRP', '', '4DRO','4DRO', '8NA', 0, 0,0, 0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M124', 'GRAMOCEF- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 3500, 'Jan 22 2010'
exec uspInsertDrugs 'M709', 'GRAVINATE- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M150', 'GRAVINATE- TAB50mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M086', 'GRISEOFULVIN- TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M151', 'GRISEOFULVIN- TAB50mg', '', '4TAB','4TAB', '8NA', 0,0, 0, 0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M262', 'GROVIT-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M192', 'GROVIT-SYP', '', '4SYR', '4SYR','8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M108', 'GYNAZOL- PESS', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 3500, 'Jan 22 2010'
exec uspInsertDrugs 'M158', 'GYNOSTAT- TAB', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M085', 'HALOPERIDOL- TAB', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M324', 'HALOXEN- TAB5mg', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M193', 'HB FORTE IRON-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M302', 'HERBAL LOOZEGES', '', '4TAB', '4TAB','8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M330', 'HYCORT- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M007', 'HYDRALAZINE - @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M016', 'HYDROCORTISONE- @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M248', 'HYDROCORTISONE-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M263', 'HYDROCORTISONE-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M194', 'HYDRYLLIN-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M103', 'HYOMIDE- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M903', 'HYPER- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M802', 'IBRUFEN- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M088', 'IBRUFEN- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M195', 'IBUMEX-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0, 0,3000, 'Jan 22 2010'
exec uspInsertDrugs 'M805', 'IMODIUM', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M089', 'INDOCID- TAB25mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M271', 'INFLAZONE-OIT', '', '4OIT','4OIT', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M008', 'INSULIN- @vial100iu/ml', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M227', 'INTAMINE- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M249', 'INTAMINE-CRM', '', '4CRE', '4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M804', 'K.Y JELLY- CRM42g', '', '4CRE','4CRE',  '8NA', 0, 0, 0,0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M196', 'KABUTI-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M318', 'KETAMINE- INJ', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M091', 'KETOCONAZOLE- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M280', 'KETOCONAZOLE-SHP', '', '4SHA','4SHA', '8NA', 0, 0, 0,0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M803', 'KETOMAC SHAMPOO- SHP', '', '4SHA','4SHA', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M905', 'KEVLON- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M243', 'KOACT- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M313', 'KOARCT- SYP156/5mls', '', '4SYR','4SYR', '8NA', 0,0, 0, 0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M314', 'KOARCT- SYP314/5mls', '', '4SYR','4SYR', '8NA', 0, 0,0, 0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M060', 'KOARCT- TAB375mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M061', 'KOARCT- TAB625mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2500, 'Jan 22 2010'
exec uspInsertDrugs 'M198', 'KOFAREST-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 2000, 'Jan 22 2010'
exec uspInsertDrugs 'M272', 'KY JELLY-LOT', '', '4LOT','4LOT', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M199', 'LACTULOSE - SYP', '', '4SYR','4SYR', '8NA', 0, 0,0, 0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M323', 'LAGACTIL- INJ', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M806', 'LANPRO- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M155', 'LANZOPRAZOLE-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M337', 'LAXOLAC- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M019', 'LIGNOCAINE- @vial', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M346', 'LONART FORTE- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M288', 'LONART- SYP60ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 15000, 'Jan 22 2010'
exec uspInsertDrugs 'M094', 'LONART-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M095', 'LOPERAMIDE- TAB2mg', '', '4TAB','4TAB', '8NA', 0,0, 0, 0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M096', 'LORATIDINE- TAB10mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M603', 'LORIDIN- TAB', '', '4TAB','4TAB', '8PK', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M344', 'LOSACAR H- TAB50mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M334', 'LOSARTAN- TAB50mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M503', 'LOSARTON H -TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 700, 'Jan 22 2010'
exec uspInsertDrugs 'M800', 'LUCIN- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0,3000, 'Jan 22 2010'
exec uspInsertDrugs 'M807', 'M.C.G- CRM', '', '4CRE','4CRE','8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M097', 'MABENDAZOLE- TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M098', 'MAGNESIUM- TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M201', 'MALAREST-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M038', 'MANNITOL-@amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 7000, 'Jan 22 2010'
exec uspInsertDrugs 'M258', 'MCG-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M228', 'MEDICLO AMP- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M229', 'MEDIFEN', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M250', 'MEDIVEN-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M101', 'MEFENAMIC ACID- TAB500mg', '', '4TAB','4TAB', '8NA', 0,0,0, 0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M156', 'MEFTAL-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M102', 'METFORMIN- TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M020', 'METOCLOPRAMIDE-@amp', '', '4INJ','4INJ', '8NA', 0, 0,0, 0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M104', 'METOCLOPROMIDE- TAB10mg', '', '4TAB','4TAB', '8NA', 0,0, 0, 0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M202', 'METRO- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M230', 'METROGYL- I.V', '', '4IV','4IV', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M347', 'METROGYL- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M105', 'METRONIDAZOLE- TAB200mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M273', 'MICONAZOL-CRM', '', '4CRE','4CRE', '8NA', 0, 0,0, 0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M500', 'MICONAZOLE- GEL', '', '4GEL','4GEL', '8NA', 0,0, 0, 0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M159', 'MISOPROSTOL- TAB200mg', '', '4TAB','4TAB', '8NA',0, 0, 0, 0, 4000, 'Jan 22 2010'
exec uspInsertDrugs 'M315', 'MORPHINE-INJ15mg', '', '4INJ','4INJ', '8NA', 0,0, 0, 0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M203', 'MUCODYL-SYP', '', '4SYR','4SYR', '8NA', 0, 0,0, 0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M206', 'MUCOSOLOVAN-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M204', 'MULTIVITAMIN ESENVIT-SYP', '', '4SYR','4SYR', '8NA', 0,0, 0, 0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M106', 'MULTIVITAMIN-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M276', 'MUPIROCIN  SUPIROCENE-OIT', '', '4OIT','4OIT', '8NA', 0,0, 0, 0, 17000, 'Jan 22 2010'
exec uspInsertDrugs 'M338', 'NELTOLON- GEL15mg', '', '4GEL','4GEL', '8NA', 0, 0, 0,0, 20000, 'Jan 22 2010'
exec uspInsertDrugs 'M354', 'NEURORUBINE - TAB', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 700, 'Jan 22 2010'
exec uspInsertDrugs 'M160', 'NEUROTON- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M001', 'NEUROUBINE- @amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M107', 'NIFEDIPINE- TAB20mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M111', 'NITROFURATOIN- TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M291', 'NORFLOXACIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M297', 'NORMAL SALINE- I.V', '', '4IV','4IV', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M325', 'NORMOSALANE- DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M087', 'NOSPA- TAB40mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M231', 'NYSTAGO- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs '284', 'NYSTATIN- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M162', 'NYSTATIN- PESS', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 700, 'Jan 22 2010'
exec uspInsertDrugs 'M808', 'NYSTATIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M200', 'NYSTSAT SUSPENSION-SYP', '', '4SYR', '4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M163', 'O.R.S- 25mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M252', 'ODOMOS-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M092', 'OFLOXACIN- TAB200mg', '', '4TAB','4TAB', '8NA', 0,0, 0, 0, 200, 'Jan 22 2010'
exec uspInsertDrugs '290', 'OLFEN-GEL', '', '4GEL','4GEL', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M164', 'OMEPRAZOLE- TAB', '', '4TAB', '4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M339', 'OPTIMAL- CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M506', 'ORACUR- GEL', '', '4GEL','4GEL', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M232', 'ORIPHEX- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M400', 'OSTEOCRE-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2500, 'Jan 22 2010'
exec uspInsertDrugs 'M022', 'OXYTOCIN-@amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M331', 'PARACETAMOL SUPP.- SUPP.250mg', '', '4IV','4IV', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M112', 'PARACETAMOL- TAB500mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M205', 'PARACETAMOL-SYP60ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M207', 'PECOF-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M053', 'PEFLOXACIN- TAB400mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M900', 'PELOX- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M342', 'PEN-V- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M021', 'PETHIDINE- @amp100mg', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M113', 'PIOGLITAZONE- TAB30mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 400, 'Jan 22 2010'
exec uspInsertDrugs 'M901', 'PIRICAM CADILA- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0, 0,300, 'Jan 22 2010'
exec uspInsertDrugs 'M137', 'PIRITON- TAB4mg', '', '4TAB','4TAB', '8NA', 0, 0, 0, 0,100, 'Jan 22 2010'
exec uspInsertDrugs 'M165', 'PIROXICAM- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0, 0,100, 'Jan 22 2010'
exec uspInsertDrugs 'M298', 'PLASIL- INJ', '', '4INJ','4TAB', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M902', 'PLASIL- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M114', 'PREDNISOLONE- TAB5mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M121', 'PREGNACARE- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M064', 'PREGNAZONE-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M264', 'PROBETA-N-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M208', 'PROBEX SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M115', 'PROMETHAZINE- TAB25mg ', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M209', 'PROMETHAZINE-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0,3000, 'Jan 22 2010'
exec uspInsertDrugs 'M116', 'PROPRANOLOL- TAB40mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M358', 'PROXIMEXA - SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 30000, 'Jan 22 2010'
exec uspInsertDrugs 'M94', 'PYLAOCAIN', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 6000, 'Jan 22 2010'
exec uspInsertDrugs 'M167', 'PYRIDOXIN- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M023', 'QUININE- @amp(R)', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M210', 'QUININE- SYP100ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M117', 'QUININE- TAB300mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M211', 'R.B. TONE-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M296', 'R.L- I.V', '', '4IV','4IV', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M118', 'RANITIDINE- TAB150mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 200, 'Jan 22 2010'
exec uspInsertDrugs 'M024', 'RANITIDINE-@amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M238', 'RELCER GEL- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 7000, 'Jan 22 2010'
exec uspInsertDrugs 'M233', 'RENECHLOR- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M253', 'RHEUMATIC-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M505', 'ROXITHROMYCIN- TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M234', 'SABULIN- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M152', 'SALBUTAMOL- TAB2mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M212', 'SALBUTAMOL-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M171', 'SECNIDAZOLE-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 4000, 'Jan 22 2010'
exec uspInsertDrugs 'M154', 'SECNIDAZOLE-TAB1mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M287', 'SEPTRIN-SYP60ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M141', 'SEPTRINE- TAB480mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M216', 'SINAREST LINCTUS-SYP', '', '4SYR','4SYR', '8NA', 0, 0,0, 0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M265', 'SINAREST-DRP', '', '4DRO','4DRO', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M254', 'SUPIROCIN-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 17000, 'Jan 22 2010'
exec uspInsertDrugs 'M303', 'TETANUS TOXIDE', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M277', 'TETRA EYE- OINT', '', '4EYE','4EYE', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M906', 'TINIBA- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M153', 'TINIDAZOLE-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M319', 'TOBGUE DEPRES- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M508', 'TOFFPLUS- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M213', 'TORACTIN-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 10000, 'Jan 22 2010'
exec uspInsertDrugs 'M168', 'TRAMADOL- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M039', 'TRAMADOL-@amp', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M704', 'UNISTEN- CREAM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M235', 'UNITRIM- SYP60ml', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M607', 'UNIXIL- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M333', 'VALSATAN- TAB10mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 1000, 'Jan 22 2010'
exec uspInsertDrugs 'M214', 'VIFEX-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M026', 'VIT B COMPLEX-@amp', '', '4INJ','4INJ', '8NA', 0, 0,0, 0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M075', 'VITAMIN A- TAB200000iu', '', '4TAB','4TAB', '8NA', 0,0, 0, 0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M120', 'VITAMIN B - TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 50, 'Jan 22 2010'
exec uspInsertDrugs 'M907', 'VITAMIN C- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 100, 'Jan 22 2010'
exec uspInsertDrugs 'M402', 'WELLMAN', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2500, 'Jan 22 2010'
exec uspInsertDrugs 'M401', 'WELLWOMAN-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 2500, 'Jan 22 2010'
exec uspInsertDrugs 'M278', 'WHITE FIELD-CRM', '', '4CRE','4CRE', '8NA', 0, 0, 0,0, 3000, 'Jan 22 2010'
exec uspInsertDrugs 'M908', 'X-PEN- @AMP', '', '4INJ','4INJ', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M127', 'ZECUF LONZENGES-TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M215', 'ZECUF-SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M409', 'ZEET- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
exec uspInsertDrugs 'M122', 'ZERODOL- TAB100mg', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M128', 'ZINKID- TAB20mg', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M239', 'ZINNAT- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 35000, 'Jan 22 2010'
exec uspInsertDrugs 'M340', 'ZYGLUCONATE- TAB', '', '4TAB','4TAB', '8NA', 0, 0,0, 0, 300, 'Jan 22 2010'
exec uspInsertDrugs 'M703', 'ZYNCET- TAB', '', '4TAB','4TAB', '8NA', 0, 0, 0,0, 500, 'Jan 22 2010'
exec uspInsertDrugs 'M702', 'ZYNNAT- SYP', '', '4SYR','4SYR', '8NA', 0, 0, 0,0, 5000, 'Jan 22 2010'
go
-- select * from drugs 
-- delete from drugs 

-------- ConsumableItems ---------------------------------------------------------------------------------------------------------------
exec uspInsertConsumableItems 'C001', 'Catheter foley CH 16 2 way', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C002', 'Catheter foley CH 18 2 way', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C003', 'Cotton wool 500g', '', '8PC', 0, 0, 0,0, 15000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C004', 'Derivery kits( mama kit)', '', '8PC', 0, 0, 0,0, 30000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C005', 'Surgical gloves 7.5', '', '8PC', 0, 0, 0,0, 1500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C006', 'Insuline syringes', '', '8PC', 0, 0, 0,0, 500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C007', 'IV cannular G 16 with port', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C008', 'IV cannular G 18 with port', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C009', 'IV cannular G 20 with port', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C010', 'IV cannular G 22 with port', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C011', 'IV cannular G 24 with port', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C012', 'Nasal gastric tube G 10', '', '8PC', 0, 0, 0,0, 1500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C013', 'Nasal gastric tube G 16', '', '8PC', 0, 0, 0,0, 1500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C014', 'Nasal gastric tube G 5', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C015', 'Nasal gastric tube G 6', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C016', 'Nasal gastric tube G 8', '', '8PC', 0, 0, 0,0, 1500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C017', 'sunction catheter size 10', '', '8PC', 0, 0, 0,0, 2500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C018', 'sunction catheter size 14', '', '8PC', 0, 0, 0,0, 2500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C019', 'sunction catheter size 16', '', '8PC', 0, 0, 0,0, 2500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C020', 'sunction catheter size 6', '', '8PC', 0, 0, 0,0, 2500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C021', 'sunction catheter size 8', '', '8PC', 0, 0, 0,0, 2500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C022', 'Syringe feeding/irrigation 50/60ml', '', '8PC', 0, 0, 0,0, 2500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C023', 'Syringe 20ml with needle', '', '8PC', 0, 0, 0,0, 1500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C024', 'Syringe 2ml with needle', '', '8PC', 0, 0, 0,0, 500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C025', 'Syringe 5ml with needle', '', '8PC', 0, 0, 0,0, 500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C026', 'Syringe 10ml with needle', '', '8PC', 0, 0, 0,0, 500, '27 Oct 2020',0,0,'324NA'
exec uspInsertConsumableItems 'C027', 'Urine collecting bag 2ltr', '', '8PC', 0, 0, 0,0, 3000, '27 Oct 2020',0,0,'324NA'
go

--------Lab Tests-------------------------------------------------------------------------------------------------------------
exec uspInsertLabTests 'T058', '24HR URINALYSIS', '14BLD', '5B', '', '8NA', 0, 45000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T015', 'ABO AND RH BLOOD GROUP', '14BLD', '5H', '', '8NA', 0, 10000,0,'3STR',0,'','',''
exec uspInsertLabTests 'T059', 'ACTH', '14BLD', '5B', '', '8NA', 0, 65000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T030', 'ALBUMIN', '14BLD', '5B', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T041', 'ALK.PHOSPHATES', '14BLD', '5B', '', '8NA', 0, 5000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T031', 'ALKALINE PHOSPHATES(ALP)', '14BLD', '5B', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T060', 'ALPH FETO PROTEIN(A.F.P)', '14BLD', '5B', '', '8NA', 0, 45000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T084', 'AMYLASE', '14BLD', '5B', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T100', 'ANTI DNA(SLE) LATEX TEST', '14BLD', '5M', '', '8NA', 0, 25000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T117', 'ANTI HCV STRIP TEST', '14BLD', '5M', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T103', 'ANTI HEPATITIS A VIRUS', '14BLD', '5M', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T029', 'BILIRUBIN (TOTAL AND DIRECT)', '14BLD', '5B', '', '8NA', 0, 8000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T005', 'BLEEDING AND CLOTTING TIME', '14BLD', '5H', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T116', 'BLOOD CULTURE', '14BLD', '5M', '', '8NA', 0, 40000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T133', 'BLOOD GROUP', '14BLD', '5H', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T093', 'BRUCELLA', '14BLD', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T036', 'CADIAC ENZYMES', '14BLD', '5B', '', '8NA', 0, 30000,0,'3STR',0,'','',''
exec uspInsertLabTests 'T039', 'CALCIUM', '14BLD', '5B', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T068', 'CALCIUM (Ca+++)', '14BLD', '5B', '', '8NA', 0, 7000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T061', 'CARCINOEMRYOGENIC ANTIGEN', '14BLD', '5B', '', '8NA', 0, 40000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T090', 'CD4/CD8 COUNT', '14BLD', '5H', '', '8NA', 0, 45000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T032', 'CHOLESTEROL', '14BLD', '5B', ' UP TO 220MG/DL', '8NA', 0, 6000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T072', 'CHOLINESTERASE', '14BLD', '5B', '', '8NA', 0, 20000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T038', 'CK-MB', '14BLD', '5B', '', '8NA', 0, 20000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T102', 'CMV (IgG/IgM)', '14BLD', '5M', '', '8NA', 0, 70000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T016', 'COOMBS TEST DIRECT', '14BLD', '5H', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T017', 'COOMBS TEST INDIRECT', '14BLD', '5H', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T056', 'CORTIOL(A.M)', '14BLD', '5B', '', '8NA', 0, 40000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T057', 'CORTIOL(P.M)', '14BLD', '5B', '', '8NA', 0, 40000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T096', 'CRAG', '14BLD', '5M', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T023', 'CREATININE', '14BLD', '5B', ' M 0.6-1.1, F 0.5-0.9', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T074', 'CREATININE CLEARANCE', '14BLD', '5B', '', '8NA', 0, 20000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T094', 'CRP', '14BLD', '5M', '', '8NA', 0, 7000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T111', 'CSF ROUTINE', '14CSF', '5M', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T112', 'CSF ROUTINE AND C/S', '14CSF', '5M', '', '8NA', 0, 35000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T024', 'ELECTROLYTES', '14BLD', '5B', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T018', 'ENZYME COOMBS TEST', '14BLD', '5H', '', '8NA', 0, 16000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T002', 'ESR', '14BLD', '5H', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T051', 'ESTRADIOL/E2', '14BLD', '5B', '', '8NA', 0, 35000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T123', 'FASTING BLOOD SUGAR', '14BLD', '5C', ' 65-115', '8MGDL', 0, 5000,0, '3NUM',0,'','',''
exec uspInsertLabTests 'T064', 'FERRITIN', '14BLD', '5B', '', '8NA', 0, 20000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T010', 'FIBRINOGEN', '14BLD', '5H', '', '8NA', 0, 15000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T004', 'FILM COMMENT', '14BLD', '5H', '', '8NA', 0, 5000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T055', 'FRACTOSE IN BLOOD', '14BLD', '5B', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T106', 'FRACTOSE IN SEMEN', '14SEM', '5M', '', '8NA', 0, 7000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T063', 'FREE PSA', '14BLD', '5B', '', '8NA', 0, 45000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T044', 'FREE T3', '14BLD', '5B', '', '8NA', 0, 25000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T045', 'FREE T4', '14BLD', '5B', '', '8NA', 0, 25000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T047', 'FSH', '14BLD', '5B', '', '8NA', 0, 25000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T001', 'FULL HAEMOGRAM(CBC)', '14BLD', '5H', '', '8NA', 0, 15000,0, '3DEC',0,'','',''
exec uspInsertLabTests 'T075', 'G6PD', '14BLD', '5B', '', '8NA', 0, 35000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T027', 'GAMMA-GT', '14BLD', '5B', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T067', 'GLUCOSE TOLERANCE', '14BLD', '5B', '', '8NA', 0, 50000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T026', 'GOT(AST)', '14BLD', '5B', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T025', 'GPT(ALT)', '14BLD', '5B', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T190', 'GRAM STAIN', '14PUS', '5M', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T124', 'H. PYLORI', '14BLD', '5M', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T003', 'HAEMOGLOBIN', '14BLD', '5H', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T014', 'HB ELECTROPHORESIS', '14BLD', '5H', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T076', 'HbA1c(GLYCATED HAEMOGLOBIN)', '14BLD', '5B', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T095', 'HBsAg', '14BLD', '5M', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T129', 'HCG', '14URN', '5I', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T053', 'HCG QUANTITATIVE', '14BLD', '5B', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T034', 'HDL-CHOLESTEROL', '14BLD', '5B', '', '8NA', 0, 9500,0, '3STR',0,'','',''
exec uspInsertLabTests 'T127', 'HIV', '14BLD', '5I', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T089', 'HIV ELISA', '14BLD', '5M', '', '8NA', 0, 35000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T088', 'HIV-ANTIBODY SCREENING TEST', '14BLD', '5M', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T070', 'INORGANIC PHOSPHOROUS', '14BLD', '5B', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T012', 'L.E CELLS(BUFFY COAT PREP)', '14BLD', '5H', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T073', 'LACTIC ACID(LACTATE)', '14BLD', '5B', '', '8NA', 0, 20000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T035', 'LDL-CHOLESTEROL', '14BLD', '5B', '', '8NA', 0, 9500,0, '3STR',0,'','',''
exec uspInsertLabTests 'T048', 'LH', '14BLD', '5B', '', '8NA', 0, 25000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T083', 'LIPASE', '14BLD', '5B', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T120', 'LIPID PROFILE', '14BLD', '5C', '', '8NA', 0, 30000,0, '3NUM',0,'','',''
exec uspInsertLabTests 'T118', 'LIVER FUNCTION TESTS', '14BLD', '5C', '', '8NA', 0, 35000,0, '3DEC',0,'','',''
exec uspInsertLabTests 'T069', 'MAGNESIUM (Mg++)', '14BLD', '5B', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T019', 'MALARIA PARASITES-B/S', '14BLD', '5H', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T021', 'MICROFILARIA', '14BLD', '5H', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T132', 'MODIFIED ZN 4 CYPTOSPORIDIUM', '14STL', '5M', '', '8NA', 0, 20000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T131', 'OCCULT BLOOD', '14BLD', '5M', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T006', 'PLATELET COUNT', '14BLD', '5H', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T050', 'PROGESTERONE', '14BLD', '5B', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T049', 'PROLACTIN', '14BLD', '5B', '', '8NA', 0, 25000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T077', 'PROTEIN ELECTROPHORESIS', '14BLD', '5B', '', '8NA', 0, 40000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T062', 'PSA(QUANTITATIVE)', '14BLD', '5B', '', '8NA', 0, 45000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T007', 'PTI', '14BLD', '5H', '', '8NA', 0, 15000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T008', 'PTT', '14BLD', '5H', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T097', 'R FACTOR', '14BLD', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T066', 'RANDOM BLOOD SUGAR', '14BLD', '5B', ' 75-120', '8MGDL', 0, 5000,0, '3NUM',0,'','',''
exec uspInsertLabTests 'T119', 'RENAL FUNCTION TESTS', '14BLD', '5C', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T011', 'RETICULOCYTE COUNT', '14BLD', '5H', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T104', 'S.HCG QUANTITATIVE', '14BLD', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T054', 'SEMEN ANALYSIS IN BLOOD', '14BLD', '5B', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T105', 'SEMEN ANALYSIS IN SEMEN', '14SEM', '5M', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T098', 'SERUM TB TEST', '14BLD', '5M', '', '8NA', 0, 15000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T013', 'SICKLE CELL TEST', '14BLD', '5H', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T115', 'SPUTUM C/S', '14SPT', '5M', '', '8NA', 0, 40000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T114', 'SPUTUM GRAM', '14SPT', '5M', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T113', 'SPUTUM ZN STAIN', '14SPT', '5M', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T109', 'STOOL MICROSCOPY', '14STL', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T130', 'STOOL MICROSCOPY AND C/S', '14STL', '5C', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T110', 'SWABS FOR C/S', '14PUS', '5M', '', '8NA', 0, 30000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T052', 'TESTERONE', '14BLD', '5B', '', '8NA', 0, 35000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T009', 'THROMBIN TEST', '14BLD', '5H', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T043', 'THYROID FUNC.TEST', '14BLD', '5B', '', '8NA', 0, 70000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T121', 'THYROID FUNCTION TESTS', '14BLD', '5C', '', '8NA', 0, 70000,0, '3DEC',0,'','',''
exec uspInsertLabTests 'T046', 'THYROID STIMULATION HORMONES', '14BLD', '5B', '', '8NA', 0, 20000,0,'3STR',0,'','',''
exec uspInsertLabTests 'T028', 'TOTAL PROTEIN', '14BLD', '5B', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T099', 'TOXOPLASMOSIS', '14BLD', '5M', '', '8NA', 0, 55000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T033', 'TRIGLYCERIDES', '14BLD', '5B', '', '8NA', 0, 6000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T037', 'TROPONIN', '14BLD', '5B', '', '8NA', 0, 38000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T020', 'TRYPANASOME PARASITES', '14BLD', '5H', '', '8NA', 0, 5000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T022', 'UREA', '14BLD', '5B', '', '8NA', 0, 5000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T071', 'URIC ACID', '14BLD', '5B', '', '8NA', 0, 7000, 0,'3STR',0,'','',''
exec uspInsertLabTests 'T086', 'URINE ALBUMIN CREATININERATIC', '14BLD', '5B', '', '8NA', 0, 18000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T107', 'URINE ANALYSIS + MICROSCOPY', '14URN', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T087', 'URINE BENCE JONES PROTEIN', '14BLD', '5B', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T108', 'URINE C/S', '14URN', '5M', '', '8NA', 0, 15000,0,'3STR',0,'','',''
exec uspInsertLabTests 'T080', 'URINE Ca++(24hrs)', '14BLD', '5B', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T078', 'URINE ELECTROLYTES(24HRS)', '14BLD', '5B', '', '8NA', 0, 15000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T101', 'URINE HCG', '14URN', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T079', 'URINE Mg++(24hrs)', '14BLD', '5B', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T085', 'URINE PO4(24HRS)', '14BLD', '5B', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T082', 'URINE PROTEIN(24HRS)', '14BLD', '5B', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T081', 'URINE URIC ACID', '14BLD', '5B', '', '8NA', 0, 10000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T091', 'VDRL/TPHA', '14BLD', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T065', 'VMA (QUANTITATIVE)', '14BLD', '5B', '', '8NA', 0, 60000,0, '3STR',0,'','',''
exec uspInsertLabTests 'T092', 'WIDAL', '14BLD', '5M', '', '8NA', 0, 7000,0, '3STR',0,'','',''
go

--
---- select * from labTests
---- delete from labTests
--

-----------------------------------------------------------------------------------------------------------------------------------------------------
-----------LabPossibleResults------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------

exec uspEditLabPossibleResults 'T019','MPS +'
exec uspEditLabPossibleResults 'T019','MPS ++'
exec uspEditLabPossibleResults 'T019','MPS +++'
exec uspEditLabPossibleResults 'T019','MPS ++++'
exec uspEditLabPossibleResults 'T019','NO MPS SEEN'
exec uspEditLabPossibleResults 'T190','Gram Positive Cocci (GPC)'
exec uspEditLabPossibleResults 'T190','Gram Positive Rods (GPR)'
exec uspEditLabPossibleResults 'T190','Gram Negative Cocci (GNC)'
exec uspEditLabPossibleResults 'T190','Gram Negative Rods (GNR)'
go

-----------------------------------------------------------------------------------------------------------------------------------------------------
-----------LabTestsEXT-------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------
exec uspEditLabTestsEXT 'T001', 'GR%', 'GR%', '50-75', '8PCT', '3DEC'
exec uspEditLabTestsEXT 'T001', 'GRA', 'GRA', '2.5-7.5', '8103UL', '3DEC'
exec uspEditLabTestsEXT 'T001', 'HB', 'HB', '12-17.5', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T001', 'HCT', 'HCT', '36-52', '8PCT', '3DEC'
exec uspEditLabTestsEXT 'T001', 'LY%', 'LY%', '25-40', '8PCT', '3DEC'
exec uspEditLabTestsEXT 'T001', 'LYM', 'LYM', '1.3-4.0', '8103UL', '3DEC'
exec uspEditLabTestsEXT 'T001', 'MCH', 'MCH', '27-32', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T001', 'MCHC', 'MCHC', '30-35', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T001', 'MCV', 'MCV', '76-96', '8NA', '3NUM'
exec uspEditLabTestsEXT 'T001', 'MON', 'MON', '0.15-0.70', '8103UL', '3DEC'
exec uspEditLabTestsEXT 'T001', 'MON%', 'MON%', '3.0-7.0', '8PCT', '3DEC'
exec uspEditLabTestsEXT 'T001', 'MPV', 'MPV', '8-15', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T001', 'PCT', 'PCT', '', '8PCT', '3DEC'
exec uspEditLabTestsEXT 'T001', 'PDWC', 'PDWC', '', '8PCT', '3DEC'
exec uspEditLabTestsEXT 'T001', 'PLT', 'PLT', '150-400', '8103UL', '3NUM'
exec uspEditLabTestsEXT 'T001', 'RBC', 'RBC', '4.0-5.5', '8106UL', '3DEC'
exec uspEditLabTestsEXT 'T001', 'RDWC', 'RDWC', '', '8PCT', '3DEC'
exec uspEditLabTestsEXT 'T001', 'WBC', 'WBC', '05-10', '8103UL', '3DEC'
exec uspEditLabTestsEXT 'T002', '20YRS', '0-20', 'M 0-10, F 0-15', '8NA', '3STR'
exec uspEditLabTestsEXT 'T002', '55YRS', '20-55YEARS', 'M 0-27.5, F 0-32.5', '8NA', '3STR'
exec uspEditLabTestsEXT 'T002', '90YRS', '55-90', 'M 0-45, F 0-50', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'APPEARANCE', 'APPEARANCE', 'pale yellow and clear', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'B', 'BILIRUBIN', 'NEGATIVE', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'GLUCOSE', 'GLUCOSE', 'NEGATIVE', '8MGDL', '3STR'
exec uspEditLabTestsEXT 'T107', 'KETONES', 'KETONES', 'NEGATIVE', '8MGDL', '3STR'
exec uspEditLabTestsEXT 'T107', 'LE', 'LEUCOCYTE ESTERASE', 'NEGATIVE', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'Microscopy', 'Microscopy', '', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'NITRITES', 'NITRITES', 'NEGATIVE', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'PH', 'PH', '5.0-8.0', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'PROTEIN', 'PROTEIN', 'NEGATIVE', '8MGDL', '3STR'
exec uspEditLabTestsEXT 'T107', 'RBCs', 'RED BLOOD CELLS', '0-2HPF', '8NA', '3NUM'
exec uspEditLabTestsEXT 'T107', 'SG', 'SPECIFIC GRAVITY', '1.015-1.025', '8NA', '3STR'
exec uspEditLabTestsEXT 'T107', 'WBCs', 'PUS CELLS', '0-5HPF', '8NA', '3NUM'
exec uspEditLabTestsEXT 'T118', 'ALB', 'ALBUMIN', 'M 38-51, F 38-51', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T118', 'ALP', 'ALP', 'M 80-306, F 64-306', '8UL', '3DEC'
exec uspEditLabTestsEXT 'T118', 'DBIL', 'DIRECT BILIRUBIN', 'M 0.25, F 0.25', '8MGDL', '3DEC'
exec uspEditLabTestsEXT 'T118', 'GGT', 'GGT', 'M 11-61, F 9-39', '8UL', '3DEC'
exec uspEditLabTestsEXT 'T118', 'GOT', 'GOT', 'M 0-37, F 0-31', '8UL', '3DEC'
exec uspEditLabTestsEXT 'T118', 'GPT', 'GPT', 'M 0-42, F 0-32', '8UL', '3DEC'
exec uspEditLabTestsEXT 'T118', 'TBIL', 'TOTAL BILIRUBIN', 'M 1.1, F 1.1', '8MGDL', '3DEC'
exec uspEditLabTestsEXT 'T118', 'TPROT', 'TOTAL PROTEIN', 'M 66-87, F 66-87', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T119', 'cl', 'CHLORIDE', '95-108', '8MMOLL', '3STR'
exec uspEditLabTestsEXT 'T119', 'CREAT', 'CREATININE', 'M 0.6-1.1, F 0.5-0.9', '8MGDL', '3STR'
exec uspEditLabTestsEXT 'T119', 'k', 'POTASSIUM', '3.6-5.5', '8MMOLL', '3STR'
exec uspEditLabTestsEXT 'T119', 'Na', 'SODIUM', '135-155', '8MMOLL', '3STR'
exec uspEditLabTestsEXT 'T119', 'UREA', 'UREA', '10-50', '8MGDL', '3STR'
exec uspEditLabTestsEXT 'T120', 'CHOL', 'CHOLESTEROL', '0-220', '8MGDL', '3NUM'
exec uspEditLabTestsEXT 'T120', 'HDL', 'HIGH DENSITY LIPID', '0.90-1.45', '8MMOLL', '3DEC'
exec uspEditLabTestsEXT 'T120', 'LDL', 'LOW DENSITY LIPID', '0.00-3.37', '8MMOLL', '3DEC'
exec uspEditLabTestsEXT 'T120', 'TRIG', 'TRIGLYCERIDES', '0.00-2.30', '8MMOLL', '3DEC'
exec uspEditLabTestsEXT 'T121', 'T3', 'T3', '0.8-2.2', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T121', 'T4', 'T4', '4.8-11.6', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T121', 'TST', 'THYROID STIMULATING HORMONE', '0.3-6.2', '8NA', '3DEC'
exec uspEditLabTestsEXT 'T127', 'DETERMINE', 'DETERMINE', 'NEGATIVE', '8NA', '3STR'
exec uspEditLabTestsEXT 'T127', 'SP', 'STAT PACK', 'NEGATIVE', '8NA', '3STR'
exec uspEditLabTestsEXT 'T127', 'UNIGOLD', 'UNIGOLD', 'NEGATIVE', '8NA', '3STR'
go

---- select * from LabTestsEXT
---- delete from LabTestsEXT 

---------------------------------------------------------------------------------------------------------------------------------------------------
---------staff-------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------

exec uspInsertStaff	100, 'Private', 'Doctor', '15F', '20DR', '', '', '', '05 Jan 2013',  '', '', '39GEN', ''
exec uspInsertStaff	101, 'Private', 'Technologist', '15M', '20TEC', '', '', '', '05 Jan 2013',  '', ''
exec uspInsertStaff	102, 'Private', 'Pharmacist', '15F', '20PHA', '', '', '', '05 Jan 2013',  '', ''
exec uspInsertStaff	103, 'Private', 'Radiologist', '15M', '20RAD', '', '', '', '05 Jan 2013',  '', ''
exec uspInsertStaff	104, 'Private', 'Anaesthetist', '15M', '20ANA', '', '', '', '05 Jan 2013',  '', ''
exec uspInsertStaff	105, 'Private', 'Nurse', '15F', '20NUR', '', '', '', '05 Jan 2013',  '', ''
go

-- delete from staff

---------------------------------------------------------------------------------------------------------------------------------------------------
---------DrugCombinations--------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------

exec uspInsertDrugCombinations 'D4T+3TC+NVP', 'Stavudine, Lamivudine (Epivir), Nevirapine (Viramune)'
exec uspInsertDrugCombinations 'D4T+3TC+EFV', 'Stavudine, Lamivudine (Epivir), Efavirenz'
exec uspInsertDrugCombinations 'ZDV+3TC+NVP', 'Zidovudine (AZT), Lamivudine (Epivir), Nevirapine (Viramune)'
exec uspInsertDrugCombinations 'ZDV+3TC+EFV', 'Zidovudine (AZT), Lamivudine (Epivir), Efavirenz'
exec uspInsertDrugCombinations 'ZDV+DDI+NVP', 'Zidovudine (AZT), Didanosine, Nevirapine (Viramune)'
exec uspInsertDrugCombinations 'ZDV+DDI+EFV', 'Zidovudine (AZT), Didanosine, Efavirenz'
exec uspInsertDrugCombinations 'ABC+DDI+KLT', 'Abacavir, Didanosine, Kaletra (LPV/r, Lopinavir/Ritonavir)'
exec uspInsertDrugCombinations 'D4T+DDI+EFV', 'Stavudine, Didanosine, Efavirenz'
exec uspInsertDrugCombinations 'ZDV+DDI+KLT', 'Zidovudine (AZT), Didanosine, Kaletra (LPV/r, Lopinavir/Ritonavir)'
exec uspInsertDrugCombinations 'D4T+DDI+KLT', 'Stavudine, Didanosine, Kaletra (LPV/r, Lopinavir/Ritonovir)'
exec uspInsertDrugCombinations 'CDV+CXV+RTV', 'Combivir (Lamivudin, Zidovudine), Indinavir, Kaletra (LPV/r, Lopinavir/Ritonavir)'
exec uspInsertDrugCombinations 'D4T+DDI+NVP', 'Stavudine, Didanosine, Nevirapine (Viramune)'
exec uspInsertDrugCombinations 'LPV/r+CBV', 'Kaletra (LPV/r, Lopinavir/Ritonavir), '
go
-- select * from DrugCombinations
-- delete from DrugCombinations

---------------------------------------------------------------------------------------------------------------------------------------------------
---------DrugCombinationDetails--------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A325'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A326'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A327'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A328'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A329'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A330'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A017'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A030'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A038'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A059'
exec uspEditDrugCombinationDetails 'ABC+DDI+KLT', 'A060'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A005B'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A007'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A029'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A030'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A038'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A059'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A107'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A320'
exec uspEditDrugCombinationDetails 'CDV+CXV+RTV', 'A321'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A005B'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A007'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A012'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A013'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A018'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A019'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A107'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A022'
exec uspEditDrugCombinationDetails 'D4T+3TC+EFV', 'A023'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A001'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A002'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A002B'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A005B'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A007'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A012'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A013'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A036'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A037'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A107'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A022'
exec uspEditDrugCombinationDetails 'D4T+3TC+NVP', 'A023'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A325'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A326'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A327'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A328'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A329'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A330'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A012'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A013'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A018'
exec uspEditDrugCombinationDetails 'D4T+DDI+EFV', 'A019'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A325'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A326'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A327'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A328'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A329'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A330'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A012'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A013'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A030'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A038'
exec uspEditDrugCombinationDetails 'D4T+DDI+KLT', 'A059'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A325'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A326'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A327'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A328'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A329'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A330'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A001'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A002'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A002B'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A012'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A013'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A036'
exec uspEditDrugCombinationDetails 'D4T+DDI+NVP', 'A037'
exec uspEditDrugCombinationDetails 'LPV/R+CBV', 'A005B'
exec uspEditDrugCombinationDetails 'LPV/R+CBV', 'A007'
exec uspEditDrugCombinationDetails 'LPV/R+CBV', 'A011B'
exec uspEditDrugCombinationDetails 'LPV/R+CBV', 'A030'
exec uspEditDrugCombinationDetails 'LPV/R+CBV', 'A050A'
exec uspEditDrugCombinationDetails 'LPV/R+CBV', 'A059'
exec uspEditDrugCombinationDetails 'LPV/R+CBV', 'A107'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A005B'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A007'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A011B'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A018'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A019'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A107'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A022'
exec uspEditDrugCombinationDetails 'ZDV+3TC+EFV', 'A023'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A001'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A002'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A002B'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A005B'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A007'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A011B'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A036'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A037'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A107'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A320'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A321'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A022'
exec uspEditDrugCombinationDetails 'ZDV+3TC+NVP', 'A023'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A325'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A326'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A327'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A328'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A329'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A330'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A011B'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A018'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A019'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A320'
exec uspEditDrugCombinationDetails 'ZDV+DDI+EFV', 'A321'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A325'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A326'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A327'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A328'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A329'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A330'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A011B'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A030'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A059'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A131'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A320'
exec uspEditDrugCombinationDetails 'ZDV+DDI+KLT', 'A321'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A325'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A326'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A327'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A328'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A329'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A330'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A001'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A002'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A002B'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A011B'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A036'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A037'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A320'
exec uspEditDrugCombinationDetails 'ZDV+DDI+NVP', 'A321'
go

-- select * from DrugCombinationDetails
-- delete from DrugCombinationDetails


---------------------------------------------------------------------------------------------------------------------------------------------------
---------CardiologyExaminations---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
--exec uspInsertCardiologyExaminations 'CE001', 'Transmyocardial Laser Revascularization', '23701', '23801', '250000',  0, 0, '', '', ''
--exec uspInsertCardiologyExaminations 'CE002','Heart Valve Repair or Replacement', '23702', '23801', '200000', 0, 0, '', '', ''
--exec uspInsertCardiologyExaminations 'CE003', 'Arrhythmia Treatment', '23703', '23802', '350000', 0, 0, '', '', ''
--exec uspInsertCardiologyExaminations 'CE004','Aneurysm Repair', '23704', '23801', '150000', 0, 0, '', '', ''
--exec uspInsertCardiologyExaminations 'CE005', 'Heart Transplant','23705', '23802', '1550000', 0, 0, '', '', ''
--go

-- select * from CardiologyExaminations
-- delete from CardiologyExaminations



---------------------------------------------------------------------------------------------------------------------------------------------------
---------RadiologyExaminations---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
exec uspInsertRadiologyExaminations 'R006', '3D/4D scanning', '37US','19209',100000,0,0
exec uspInsertRadiologyExaminations 'R042', 'Abdominal SCAN', '37US','19209', 40000,0,0
exec uspInsertRadiologyExaminations 'R023', 'Ankle', '37XR','19209', 20000,0,0
exec uspInsertRadiologyExaminations 'R035', 'Barium enema', '37SI','19209', 100000,0,0
exec uspInsertRadiologyExaminations 'R034', 'Barium meal', '37SI','19209', 70000,0,0
exec uspInsertRadiologyExaminations 'R033', 'Barium swallow', '37SI','19209', 60000,0,0
exec uspInsertRadiologyExaminations 'R002', 'Biophysical profile SCAN', '37US','19209', 60000,0,0
exec uspInsertRadiologyExaminations 'R019', 'Both hips', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R004', 'Breast SCAN', '37US','19209', 50000,0,0
exec uspInsertRadiologyExaminations 'R014', 'Cervical spine', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R015', 'Chest', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R031', 'Cysto-urethrogram(CUG)', '37SI','19209', 80000,0,0
exec uspInsertRadiologyExaminations 'R005', 'Doppler ultrasound', '37US','19209', 100000,0,0
exec uspInsertRadiologyExaminations 'R039', 'ECG', '37OT','19209', 60000,0,0
exec uspInsertRadiologyExaminations 'R007', 'Echocardiography SCAN', '37US','19209', 100000,0,0
exec uspInsertRadiologyExaminations 'R027', 'Elbow', '37XR','19209', 20000,0,0
exec uspInsertRadiologyExaminations 'R020', 'Femur', '37XR','19209', 30000,0,0
exec uspInsertRadiologyExaminations 'R041', 'Film reporting  ( routine view (s ) for', '37OT','19209', 5000,0,0
exec uspInsertRadiologyExaminations 'R024', 'Foot /toe', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R003', 'Gender determination (fetal sex) SCAN', '37US','19209', 50000,0,0
exec uspInsertRadiologyExaminations 'R040', 'Gyn', '37US','19209', 40000,0,0
exec uspInsertRadiologyExaminations 'R029', 'Hand /fingers', '37XR','19209', 20000,0,0
exec uspInsertRadiologyExaminations 'R032', 'Hysterosalphingogram(HSG)', '37SI','19209', 60000,0,0
exec uspInsertRadiologyExaminations 'R030', 'Intra-venous program(IVP)', '37SI','19209', 100000,0,0
exec uspInsertRadiologyExaminations 'R021', 'Knee', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R017', 'Lumbar spine', '37XR','19209', 30000,0,0
exec uspInsertRadiologyExaminations 'R001', 'OBSETRICObstetric', '37US','19209', 40000,0,0
exec uspInsertRadiologyExaminations 'R013', 'Para nasal sinuses', '37XR','19209', 30000,0,0
exec uspInsertRadiologyExaminations 'R018', 'Pelvis', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R010', 'Plain Abdomen  XRAY', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R011', 'Post Nasal space  XRAY', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R026', 'Radius /ulna', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R038', 'Reduction under fluoroscopy', '37SI','19209', 50000,0,0
exec uspInsertRadiologyExaminations 'R044', 'Scrotal SCAN', '37US','19209', 50000,0,0
exec uspInsertRadiologyExaminations 'R012', 'Sella Turcica  XRAY', '37XR','19209', 20000,0,0
exec uspInsertRadiologyExaminations 'R025', 'Shoulder', '37XR','19209', 20000,0,0
exec uspInsertRadiologyExaminations 'R008', 'Skull -XRAY', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R016', 'Thoracic spine', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R043', 'Thyroid SCAN', '37US','19209', 50000,0,0
exec uspInsertRadiologyExaminations 'R022', 'Tibia /fibula', '37XR','19209', 25000,0,0
exec uspInsertRadiologyExaminations 'R009', 'TMJ/Jaws/Mastoids XRAY', '37XR','19209', 35000,0,0
exec uspInsertRadiologyExaminations 'R036', 'Venogram', '37SI','19209', 100000,0,0
exec uspInsertRadiologyExaminations 'R037', 'Venogram2', '37SI','19209', 100000,0,0
exec uspInsertRadiologyExaminations 'R028', 'Wrist', '37XR','19209', 20000,0,0
go

-- select * from RadiologyExaminations
-- delete from RadiologyExaminations

---------------------------------------------------------------------------------------------------------------------------------------------------
---------DentalServices----------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------

exec uspInsertDentalServices 'D001', 'Acrylic', '102S', 400000,0
exec uspInsertDentalServices 'D002', 'Amalgam Filling', '102S', 50000,0
exec uspInsertDentalServices 'D003', 'Biopsy', '102S', 35000,0
exec uspInsertDentalServices 'D004', 'Bridge/Unit - Porcelein', '102S', 350000,0
exec uspInsertDentalServices 'D005', 'Composite - Splinting', '102S', 55000,0
exec uspInsertDentalServices 'D006', 'Composite Bonding', '102S', 80000,0
exec uspInsertDentalServices 'D007', 'Crowns Composite', '102S', 80000,0
exec uspInsertDentalServices 'D008', 'Denture - Full', '102S', 650000,0
exec uspInsertDentalServices 'D009', 'Denture 1 Unit - Partial', '102S', 150000,0
exec uspInsertDentalServices 'D010', 'Denture 1Tooth Extra Tooth - Partial', '102S', 30000,0
exec uspInsertDentalServices 'D011', 'Denture Upper/Lower - Full', '102S', 350000,0
exec uspInsertDentalServices 'D012', 'Disimpaction', '102S', 200000,0
exec uspInsertDentalServices 'D013', 'Extraction', '102S', 40000,0
exec uspInsertDentalServices 'D014', 'Extraction - Complicated', '102S', 200000,0
exec uspInsertDentalServices 'D015', 'Extraction - Simple', '102S', 40000,0
exec uspInsertDentalServices 'D016', 'Filling - Temporary', '102S', 40000,0
exec uspInsertDentalServices 'D017', 'Fixed Appliance', '102S', 950000,0
exec uspInsertDentalServices 'D018', 'Glass Ionomer Filling', '102S', 50000,0
exec uspInsertDentalServices 'D019', 'Grinding', '102S', 30000,0
exec uspInsertDentalServices 'D020', 'Incision & Drainage (STS)', '102S', 40000,0
exec uspInsertDentalServices 'D021', 'Intermaxilliary Fixation (IMF)', '102S', 400000,0
exec uspInsertDentalServices 'D022', 'Operculectomy', '102S', 50000,0
exec uspInsertDentalServices 'D023', 'Porclein', '102S', 400000,0
exec uspInsertDentalServices 'D024', 'Pulpotomy (Paediatric)', '102S', 50000,0
exec uspInsertDentalServices 'D025', 'Removable Orthodental Appliance', '102S', 1000000,0
exec uspInsertDentalServices 'D026', 'Review', '102S', 10000,0
exec uspInsertDentalServices 'D027', 'Root Canal Therapy RCT- Anterior', '102S', 200000,0
exec uspInsertDentalServices 'D028', 'Root Canal Treatment RCT- Posterior', '102S', 200000,0
exec uspInsertDentalServices 'D029', 'Root Planning & Gingivectomy', '102S', 70000,0
exec uspInsertDentalServices 'D030', 'Scaling & Polishing', '102S', 70000,0
exec uspInsertDentalServices 'D031', 'Splinting - Wires', '102S', 150000,0
exec uspInsertDentalServices 'D032', 'Xray - Dental', '102S', 20000,0
go
-- select * from DentalServices
-- delete from DentalServices

-----------------------------------------------------------------------------------------------
-------------- Rooms --------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------

exec uspInsertRooms 'R0101', 'Private', '4001'
exec uspInsertRooms 'R0201', 'Private', '4002'
exec uspInsertRooms 'R0301', 'Private', '4003'
go
-----------------------------------------------------------------------------------------------
-------------- Beds ---------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------

exec uspInsertBeds 'B010101', 'Bed: 1', 'R0101', 0,0, 25000
exec uspInsertBeds 'B010102', 'Bed: 2', 'R0101', 0,0, 26000

exec uspInsertBeds 'B020101', 'Bed: 1', 'R0201', 0,0, 35000
exec uspInsertBeds 'B020102', 'Bed: 2', 'R0201', 0,0, 36000
exec uspInsertBeds 'B020103', 'Bed: 3', 'R0201', 0,0, 68000

exec uspInsertBeds 'B030101', 'Bed: 1', 'R0301', 0,0, 45000
exec uspInsertBeds 'B030102', 'Bed: 2', 'R0301', 0,0, 46000
exec uspInsertBeds 'B030103', 'Bed: 3', 'R0301', 0,0, 88000
exec uspInsertBeds 'B030104', 'Bed: 4', 'R0301', 0,0, 68000
go