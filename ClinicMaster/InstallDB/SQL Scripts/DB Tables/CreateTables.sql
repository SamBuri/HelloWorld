
/***************************************************************
This Script is a property of ClinicMaster INTERNATIONAL
Un authorised use or ammendment is not permitted
-- Last updated 10/02/2016 by Wilson Kutegeka
***************************************************************/

use ClinicMaster

go

if exists (select * from sysobjects where name = 'Dimensions')
	drop table Dimensions
go

if exists (select * from sysobjects where name = 'BillableMappings')
	drop table BillableMappings
go

if exists (select * from sysobjects where name = 'LookupDataMappings')
	drop table LookupDataMappings
go

if exists (select * from sysobjects where name = 'INTAgents')
	drop table INTAgents
go

if exists (select * from sysobjects where name = 'PatientConsent')
	drop table PatientConsent
go

if exists (select * from sysobjects where name = 'LookupDataMappings')
	drop table LookupDataMappings
go



if exists (select * from sysobjects where name = 'PelvicExamination')
	drop table PelvicExamination
go

if exists (select * from sysobjects where name = 'AntenatalVisits')
	drop table AntenatalVisits
go

if exists (select * from sysobjects where name = 'ContraceptivesHistory')
	drop table ContraceptivesHistory
go

if exists (select * from sysobjects where name = 'Obstetric')
	drop table Obstetric
go

if exists (select * from sysobjects where name = 'OTIntervention')
	drop table OTIntervention
go

if exists (select * from sysobjects where name = 'OccupationalTherapy')
	drop table OccupationalTherapy
go

if exists (select * from sysobjects where name = 'MappedCodes')
	drop table MappedCodes
go

if exists (select * from sysobjects where name = 'MappedCodesFinance')
	drop table MappedCodesFinance
go

if exists (select * from sysobjects where name = 'ServiceInvoiceDetails')
	drop table ServiceInvoiceDetails
go

if exists (select * from sysobjects where name = 'ServiceInvoices')
	drop table ServiceInvoices
go

------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'IPDAlerts')
	drop table IPDAlerts
go
------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'Alerts')
	drop table Alerts
go

if exists (select * from sysobjects where name = 'SuspiciousLogins')
	drop table SuspiciousLogins
go

if exists (select * from sysobjects where name = 'PrintDetails')
	drop table PrintDetails
go

if exists (select * from sysobjects where name = 'SmartCardAuthorisations')
	drop table SmartCardAuthorisations
go

if exists (select * from sysobjects where name = 'InwardFiles')
	drop table InwardFiles
go

if exists (select * from sysobjects where name = 'OutwardFiles')
	drop table OutwardFiles
go

if exists (select * from sysobjects where name = 'ImportDataInfo')
	drop table ImportDataInfo
go

if exists (select * from sysobjects where name = 'Templates')
	drop table Templates
go

if exists (select * from sysobjects where name = 'updateHistory')
	drop table updateHistory
go

if exists (select * from sysobjects where name = 'OtherIncome')
	drop table OtherIncome
go

if exists (select * from sysobjects where name = 'Expenditure')
	drop table Expenditure
go

if exists (select * from sysobjects where name = 'Deaths')
	drop table Deaths
go

if exists (select * from sysobjects where name = 'ARTStopped')
	drop table ARTStopped
go

if exists (select * from sysobjects where name = 'ARTRegimenDetails')
	drop table ARTRegimenDetails
go

if exists (select * from sysobjects where name = 'ARTRegimen')
	drop table ARTRegimen
go

if exists (select * from sysobjects where name = 'DrugCombinationDetails')
	drop table DrugCombinationDetails
go


if exists (select * from sysobjects where name = 'BarCodeDetails')
	drop table BarCodeDetails
go

if exists (select * from sysobjects where name = 'DeliveryNoteDetails')
	drop table DeliveryNoteDetails
go

if exists (select * from sysobjects where name = 'InventoryEXT')
	drop table InventoryEXT
go

if exists (select * from sysobjects where name = 'InventoryAcknowledges')
	drop table InventoryAcknowledges
go

if exists (select * from sysobjects where name = 'InventoryTransferDetails')
	drop table InventoryTransferDetails
go

if exists (select * from sysobjects where name = 'InventoryTransfers')
	drop table InventoryTransfers
go

if exists (select * from sysobjects where name = 'InventoryOrderDetails')
	drop table InventoryOrderDetails
go

if exists (select * from sysobjects where name = 'InventoryOrders')
	drop table InventoryOrders
go

if exists (select * from sysobjects where name = 'InventoryLocation')
	drop table InventoryLocation
go

if exists (select * from sysobjects where name = 'InventoryReceiving')
	drop table InventoryReceiving
go

if exists (select * from sysobjects where name = 'Inventory')
	drop table Inventory
go

if exists (select * from sysobjects where name = 'GoodsReturnedNoteDetails')
	drop table GoodsReturnedNoteDetails
go

if exists (select * from sysobjects where name = 'GoodsReturnedNote')
	drop table GoodsReturnedNote
go

if exists (select * from sysobjects where name = 'GoodsReceivedNoteDetails')
	drop table GoodsReceivedNoteDetails
go

if exists (select * from sysobjects where name = 'GoodsReceivedNote')
	drop table GoodsReceivedNote
go

if exists (select * from sysobjects where name = 'PurchaseOrderDetails')
	drop table PurchaseOrderDetails
go

if exists (select * from sysobjects where name = 'PurchaseOrders')
	drop table PurchaseOrders
go

if exists (select * from sysobjects where name = 'PatientAllergies')
	drop table PatientAllergies
go

if exists (select * from sysobjects where name = 'PriorARTDetails')
	drop table PriorARTDetails
go

if exists (select * from sysobjects where name = 'ExposedInfants')
	drop table ExposedInfants
go

if exists (select * from sysobjects where name = 'FamilyMembers')
	drop table FamilyMembers
go

if exists (select * from sysobjects where name = 'AllergyDrugs')
	drop table AllergyDrugs
go

if exists (select * from sysobjects where name = 'Allergies')
	drop table Allergies
go

if exists (select * from sysobjects where name = 'ClaimDetails')
	drop table ClaimDetails
go

if exists (select * from sysobjects where name = 'ClaimDiagnosis')
	drop table ClaimDiagnosis
go

if exists (select * from sysobjects where name = 'ClaimsEXT')
	drop table ClaimsEXT
go

if exists (select * from sysobjects where name = 'ClaimPayments')
	drop table ClaimPayments
go

if exists (select * from sysobjects where name = 'Claims')
	drop table Claims
go


if exists (select * from sysobjects where name = 'Appointments')
	drop table Appointments
go

if exists (select * from sysobjects where name = 'InvoiceExtraBillItemAdjustments')
	drop table InvoiceExtraBillItemAdjustments
go

if exists (select * from sysobjects where name = 'InvoiceDetailAdjustments')
	drop table InvoiceDetailAdjustments
go

if exists (select * from sysobjects where name = 'InvoiceAdjustments')
	drop table InvoiceAdjustments
go

if exists (select * from sysobjects where name = 'InvoiceExtraBillItems')
	drop table InvoiceExtraBillItems
go

if exists (select * from sysobjects where name = 'RefundExtraBillItems')
	drop table RefundExtraBillItems
go

if exists (select * from sysobjects where name = 'RefundRequestExtraBillItems')
	drop table RefundRequestExtraBillItems
go

if exists (select * from sysobjects where name = 'PaymentVoucherDetails')
	drop table PaymentVoucherDetails
go

if exists (select * from sysobjects where name = 'PaymentVouchers')
	drop table PaymentVouchers
go

if exists (select * from sysobjects where name = 'PaymentExtraBillItems')
	drop table PaymentExtraBillItems
go

if exists (select * from sysobjects where name = 'ItemAdjustments')
	drop table ItemAdjustments
go

if exists (select * from sysobjects where name = 'ExtraBillItemAdjustments')
	drop table ExtraBillItemAdjustments
go

if exists (select * from sysobjects where name = 'BillAdjustments')
	drop table BillAdjustments
go

if exists (select * from sysobjects where name = 'ExtraBillsINT')
	drop table ExtraBillsINT
go

if exists (select * from sysobjects where name = 'ExtraBillItemsINT')
	drop table ExtraBillItemsINT
go


if exists (select * from sysobjects where name = 'ExtraBillItemsCASH')
	drop table ExtraBillItemsCASH
go

if exists (select * from sysobjects where name = 'ExtraBillsEXT')
	drop table ExtraBillsEXT
go

if exists (select * from sysobjects where name = 'ExtraChargeItems')
	drop table ExtraChargeItems
go

if exists (select * from sysobjects where name = 'PossibleAttachedItems')
	drop table PossibleAttachedItems
go

if exists (select * from sysobjects where name = 'IPDTheatreOperations')
	drop table IPDTheatreOperations
go

if exists (select * from sysobjects where name = 'TheatreOperations')
	drop table TheatreOperations
go

if exists (select * from sysobjects where name = 'IPDDentalReports')
	drop table IPDDentalReports
go

if exists (select * from sysobjects where name = 'DentalReports')
	drop table DentalReports
go


if exists (select * from sysobjects where name = 'IPDCardiologyReports')
	drop table IPDCardiologyReports
go

if exists (select * from sysobjects where name = 'CardiologyReports')
	drop table CardiologyReports
go

if exists (select * from sysobjects where name = 'CardiologyExaminations')
	drop table CardiologyExaminations
go


if exists (select * from sysobjects where name = 'IPDRadiologyReports')
	drop table IPDRadiologyReports
go

if exists (select * from sysobjects where name = 'RadiologyReports')
	drop table RadiologyReports
go

if exists (select * from sysobjects where name = 'RadiologyExaminations')
	drop table RadiologyExaminations
go

if exists (select * from sysobjects where name = 'Examinations')
	drop table Examinations
go

if exists (select * from sysobjects where name = 'HCTClientCard')
	drop table HCTClientCard
go

if exists (select * from sysobjects where name = 'IPDPathologyReports')
	drop table IPDPathologyReports
go

if exists (select * from sysobjects where name = 'PathologyReports')
	drop table PathologyReports
go
if exists (select * from sysobjects where name = 'PathologyImages')
	drop table PathologyImages
go
if exists (select * from sysobjects where name = 'PathologyExaminations')
	drop table PathologyExaminations
go

if exists (select * from sysobjects where name = 'ApprovedLabResults')
	drop table ApprovedLabResults
go

if exists (select * from sysobjects where name = 'LabResultsEXT')
	drop table LabResultsEXT
go

if exists (select * from sysobjects where name = 'LabResults')
	drop table LabResults
go

if exists (select * from sysobjects where name = 'LabRequestDetails')
	drop table LabRequestDetails
go

------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'LabRequestsIPD')
	drop table LabRequestsIPD
go

------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'LabRequests')
	drop table LabRequests
go

if exists (select * from sysobjects where name = 'LabTestsEXT')
	drop table LabTestsEXT
go

if exists (select * from sysobjects where name = 'LabPossibleResults')
	drop table LabPossibleResults
go

if exists (select * from sysobjects where name = 'LabTestsEXTPossibleResults')
	drop table LabTestsEXTPossibleResults
go

if exists (select * from sysobjects where name = 'LabTests')
	drop table LabTests
go

------------------------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'Discharges')
	drop table Discharges
go

if exists (select * from sysobjects where name = 'IPDCancerDiagnosis')
	drop table IPDCancerDiagnosis
go

if exists (select * from sysobjects where name = 'IPDDiagnosis')
	drop table IPDDiagnosis
go

if exists (select * from sysobjects where name = 'IPDItemsEXT')
	drop table IPDItemsEXT
go

if exists (select * from sysobjects where name = 'IPDOrthoptics')
	drop table IPDOrthoptics
go

if exists (select * from sysobjects where name = 'IPDEyeAssessment')
	drop table IPDEyeAssessment
go

if exists (select * from sysobjects where name = 'IPDVisionAssessment')
	drop table IPDVisionAssessment
go

if exists (select * from sysobjects where name = 'IPDNurseAssessment')
	drop table IPDNurseAssessment
go

if exists (select * from sysobjects where name = 'IPDNursingPlan')
	drop table IPDNursingPlan
go

if exists (select * from sysobjects where name = 'IPDNurseEvaluation')
	drop table IPDNurseEvaluation
go

if exists (select * from sysobjects where name = 'IPDItems')
	drop table IPDItems
go

if exists (select * from sysobjects where name = 'IPDClinicalFindings')
	drop table IPDClinicalFindings
go

if exists (select * from sysobjects where name = 'IPDDrugAdministration')
	drop table IPDDrugAdministration
go

if exists (select * from sysobjects where name = 'IPDNurseFluids')
	drop table IPDNurseFluids
go

if exists (select * from sysobjects where name = 'IPDNurse')
	drop table IPDNurse
go

if exists (select * from sysobjects where name = 'IPDDoctor')
	drop table IPDDoctor
go

if exists (select * from sysobjects where name = 'Admissions')
	drop table Admissions
go

if exists (select * from sysobjects where name = 'Beds')
	drop table Beds
go

if exists (select * from sysobjects where name = 'Rooms')
	drop table Rooms
go

-------------------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'SymptomsHistory')
	drop table SymptomsHistory
go

if exists (select * from sysobjects where name = 'ExternalReferrals')
	drop table ExternalReferrals
go

if exists (select * from sysobjects where name = 'Referrals')
	drop table Referrals
go

if exists (select * from sysobjects where name = 'CancerDiagnosis')
	drop table CancerDiagnosis
go

if exists (select * from sysobjects where name = 'CancerDiseases')
	drop table CancerDiseases
go

if exists (select * from sysobjects where name = 'TopologySites')
	drop table TopologySites
go

if exists (select * from sysobjects where name = 'Diagnosis')
	drop table Diagnosis
go

if exists (select * from sysobjects where name = 'PhysioDiagnosis')
	drop table PhysioDiagnosis
go

if exists (select * from sysobjects where name = 'Physiotherapy')
	drop table Physiotherapy
go

if exists (select * from sysobjects where name = 'PhysioDiseases')
	drop table PhysioDiseases
go

if exists (select * from sysobjects where name = 'Diseases')
	drop table Diseases
go

if exists (select * from sysobjects where name = 'ICUServices')
	drop table ICUServices
go

if exists (select * from sysobjects where name = 'MaternityServices')
	drop table MaternityServices
go

if exists (select * from sysobjects where name = 'OpticalServices')
	drop table OpticalServices 
go

if exists (select * from sysobjects where name = 'Refraction')
	drop table Refraction
go

if exists (select * from sysobjects where name = 'EyeServices')
	drop table EyeServices
go

if exists (select * from sysobjects where name = 'TheatreServices')
	drop table TheatreServices
go

if exists (select * from sysobjects where name = 'DentalServices')
	drop table DentalServices
go

if exists (select * from sysobjects where name = 'Orthoptics')
	drop table Orthoptics
go

if exists (select * from sysobjects where name = 'EyeAssessment')
	drop table EyeAssessment
go

if exists (select * from sysobjects where name = 'LowVision')
	drop table LowVision
go

if exists (select * from sysobjects where name = 'Optical')
	drop table Optical
go

if exists (select * from sysobjects where name = 'Procedures')
	drop table Procedures
go

if exists (select * from sysobjects where name = 'ClinicalFindings')
	drop table ClinicalFindings
go

if exists (select * from sysobjects where name = 'DoctorVisits')
	drop table DoctorVisits
go

if exists (select * from sysobjects where name = 'ImmunisationVaccines')
	drop table ImmunisationVaccines
go

if exists (select * from sysobjects where name = 'ChildNutrition')
	drop table ChildNutrition
go

if exists (select * from sysobjects where name = 'PostNatal')
	drop table PostNatal
go

if exists (select * from sysobjects where name = 'Antenatal')
	drop table Antenatal
go

if exists (select * from sysobjects where name = 'ChildGrowth')
	drop table ChildGrowth
go

if exists (select * from sysobjects where name = 'ChildDevelopment')
	drop table ChildDevelopment
go

if exists (select * from sysobjects where name = 'Perinatal')
	drop table Perinatal
go

if exists (select * from sysobjects where name = 'Neonatal')
	drop table Neonatal
go

if exists (select * from sysobjects where name = 'ObstetricHistory')
	drop table ObstetricHistory
go

if exists (select * from sysobjects where name = 'DepositsINT')
	drop table DepositsINT
go

if exists (select * from sysobjects where name = 'AccountTransferDetails')
	drop table AccountTransferDetails
go

if exists (select * from sysobjects where name = 'AccountsEXT')
	drop table AccountsEXT
go

if exists (select * from sysobjects where name = 'Accounts')
	drop table Accounts
go


if exists (select * from sysobjects where name = 'ItemLocationOrderLevels')
	drop table ItemLocationOrderLevels
go

if exists (select * from sysobjects where name = 'ItemsEXT')
	drop table ItemsEXT
go

if exists (select * from sysobjects where name = 'ItemsCASH')
	drop table ItemsCASH
go


if exists (select * from sysobjects where name = 'ReceiptInvoiceDetails')
	drop table ReceiptInvoiceDetails
go

if exists (select * from sysobjects where name = 'InvoiceheadersINT')
	drop table InvoiceheadersINT
go

if exists (select * from sysobjects where name = 'InvoicesDetailsINT')
	drop table InvoicesDetailsINT
go

if exists (select * from sysobjects where name = 'InvoiceDetails')
	drop table InvoiceDetails
go

if exists (select * from sysobjects where name = 'Invoices')
	drop table Invoices
go



if exists (select * from sysobjects where name = 'QuotationDetails')
	drop table QuotationDetails
go

if exists (select * from sysobjects where name = 'Quotations')
	drop table Quotations
go

if exists (select * from sysobjects where name = 'ItemsIncome')
	drop table ItemsIncome
go

if exists (select * from sysobjects where name = 'ReceiptReversals')
	drop table ReceiptReversals
go

if exists (select * from sysobjects where name = 'RefundRejects')
	drop table RefundRejects
go

if exists (select * from sysobjects where name = 'RefundApprovals')
	drop table RefundApprovals
go


if exists (select * from sysobjects where name = 'RefundRequestDetails')
	drop table RefundRequestDetails
go


if exists (select * from sysobjects where name = 'BankPaymentDetails')
	drop table BankPaymentDetails
go

if exists (select * from sysobjects where name = 'PaymentDetails')
	drop table PaymentDetails
go

if exists (select * from sysobjects where name = 'INTRefunds')
	drop table INTRefunds
go

if exists (select * from sysobjects where name = 'RefundDetails')
	drop table RefundDetails
go

if exists (select * from sysobjects where name = 'Refunds')
	drop table Refunds
go

if exists (select * from sysobjects where name = 'RefundRequests')
	drop table RefundRequests
go

if exists (select * from sysobjects where name = 'PackageConsumption')
	drop table PackageConsumption
go

if exists (select * from sysobjects where name = 'IPDPackageConsumption')
	drop table IPDPackageConsumption
go

if exists (select * from sysobjects where name = 'Payments')
	drop table Payments
go

if exists (select * from sysobjects where name = 'ItemsBalanceDetails')
	drop table ItemsBalanceDetails
go

if exists (select * from sysobjects where name = 'ExchangeRates')
	drop table ExchangeRates
go

if exists (select * from sysobjects where name = 'ConsumableItems')
	drop table ConsumableItems
go

if exists (select * from sysobjects where name = 'AlternateDrugs')
	drop table AlternateDrugs
go

if exists (select * from sysobjects where name = 'Drugs')
	drop table Drugs
go

if exists (select * from sysobjects where name = 'OtherItems')
	drop table OtherItems
go

if exists (select * from sysobjects where name = 'DrugCategories')
	drop table DrugCategories
go

if exists (select * from sysobjects where name = 'VisionAssessment')
	drop table VisionAssessment
go

if exists (select * from sysobjects where name = 'DrugAdministration')
	drop table DrugAdministration
go

if exists (select * from sysobjects where name = 'Triage')
	drop table Triage
go

if exists (select * from sysobjects where name = 'TBIntensifiedCaseFinding')
	drop table TBIntensifiedCaseFinding
go

if exists (select * from sysobjects where name = 'VisitFiles')
	drop table VisitFiles
go

if exists (select * from sysobjects where name = 'AccessedCashServices')
	drop table AccessedCashServices
go

if exists (select * from sysobjects where name = 'PackageVisits')
	drop table PackageVisits
go

if exists (select * from sysobjects where name = 'AttachPackage')
	drop table AttachPackage
go


if exists (select * from sysobjects where name = 'QueuedMessages')
	drop table QueuedMessages
go

if exists (select * from sysobjects where name = 'Queues')
    drop table Queues
go


if exists (select * from sysobjects where name = 'PackagesEXT')
	drop table PackagesEXT
go

if exists (select * from sysobjects where name = 'Packages')
	drop table Packages
go

if exists (select * from sysobjects where name = 'HIVCARE')
	drop table HIVCARE
go

if exists (select * from sysobjects where name = 'PatientsINT')
	drop table PatientsINT
go

if exists (select * from sysobjects where name = 'MaternalEnrollment')
	drop table MaternalEnrollment
go

if exists (select * from sysobjects where name = 'PatientsEXT')
	drop table PatientsEXT
go

if exists (select * from sysobjects where name = 'DrugCombinations')
	drop table DrugCombinations
go

if exists (select * from sysobjects where name = 'StaffPaymentsEXT')
	drop table StaffPaymentsEXT
go

if exists (select * from sysobjects where name = 'IPDStaffPaymentDetails')
	drop table IPDStaffPaymentDetails
go

if exists (select * from sysobjects where name = 'OPDStaffPaymentDetails')
	drop table OPDStaffPaymentDetails
go

if exists (select * from sysobjects where name = 'StaffPayments')
	drop table StaffPayments
go

if exists (select * from sysobjects where name = 'ExtraBillItems')
	drop table ExtraBillItems
go

if exists (select * from sysobjects where name = 'ExtraBills')
	drop table ExtraBills
go

if exists (select * from sysobjects where name = 'Items')
	drop table Items
go

if exists (select * from sysobjects where name = 'Visits')
	drop table Visits
go

if exists (select * from sysobjects where name = 'Patients')
	drop table Patients
go

if exists (select * from sysobjects where name = 'ServicesSpecialtyCustomCode')
	drop table ServicesSpecialtyCustomCode
go

if exists (select * from sysobjects where name = 'ServicesStaffBillCustomFee')
	drop table ServicesStaffBillCustomFee
go

if exists (select * from sysobjects where name = 'ServicesSpecialtyBillCustomFee')
	drop table ServicesSpecialtyBillCustomFee
go

if exists (select * from sysobjects where name = 'ServicesStaffFee')
	drop table ServicesStaffFee
go

if exists (select * from sysobjects where name = 'ServicesDrSpecialtyFee')
	drop table ServicesDrSpecialtyFee
go

if exists (select * from sysobjects where name = 'Services')
	drop table Services
go

if exists (select * from sysobjects where name = 'AssetMaintainanceLog')
	drop table AssetMaintainanceLog
go

if exists (select * from sysobjects where name = 'AssetRegister')
	drop table AssetRegister
go


if exists (select * from sysobjects where name = 'Suppliers')
	drop table Suppliers
go

if exists (select * from sysobjects where name = 'EnrollmentInformation')
	drop table EnrollmentInformation
go

if exists (select * from sysobjects where name = 'ResearchRoutingForm')
	drop table ResearchRoutingForm
go


----------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'Villages')
	drop table Villages
go

if exists (select * from sysobjects where name = 'Parishes')
	drop table Parishes
go

if exists (select * from sysobjects where name = 'SubCounties')
	drop table SubCounties
go

if exists (select * from sysobjects where name = 'Counties')
	drop table Counties
go

if exists (select * from sysobjects where name = 'HealthUnits')
	drop table HealthUnits
go

if exists (select * from sysobjects where name = 'SchemeMembers')
	drop table SchemeMembers
go

if exists (select * from sysobjects where name = 'InsuranceExcludedItems')
	drop table InsuranceExcludedItems
go

if exists (select * from sysobjects where name = 'InsuranceCustomFee')
	drop table InsuranceCustomFee
go

if exists (select * from sysobjects where name = 'PolicyLimits')
	drop table PolicyLimits
go

if exists (select * from sysobjects where name = 'InsuranceSchemes')
	drop table InsuranceSchemes
go

if exists (select * from sysobjects where name = 'Companies')
	drop table Companies
go

if exists (select * from sysobjects where name = 'InsurancePolicies')
	drop table InsurancePolicies
go

if exists (select * from sysobjects where name = 'InsuranceExclusions')
	drop table InsuranceExclusions
go

if exists (select * from sysobjects where name = 'Insurances')
	drop table Insurances
go

---------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'MemberLimits')
	drop table MemberLimits
go

if exists (select * from sysobjects where name = 'MemberBenefits')
	drop table MemberBenefits
go

if exists (select * from sysobjects where name = 'BillCustomerMembers')
	drop table BillCustomerMembers
go

if exists (select * from sysobjects where name = 'BillExcludedItems')
	drop table BillExcludedItems
go

if exists (select * from sysobjects where name = 'BillCustomFee')
	drop table BillCustomFee
go

if exists (select * from sysobjects where name = 'AssociatedBillCustomers')
	drop table AssociatedBillCustomers
go

if exists (select * from sysobjects where name = 'BillCustomers')
	drop table BillCustomers
go

if exists (select * from sysobjects where name = 'Clients')
	drop table Clients
go

if exists (select * from sysobjects where name = 'Messenger')
	drop table Messenger
go

if exists (select * from sysobjects where name = 'StaffLocations')
	drop table StaffLocations
go

if exists (select * from sysobjects where name = 'BulkMessaging')
	drop table BulkMessaging
go

if exists (select * from sysobjects where name = 'INTStockTake')
	drop table INTStockTake
go


If exists (select * from sysobjects where name = 'PhysicalStockCountDetails')
	drop table PhysicalStockCountDetails
go


if exists (select * from sysobjects where name = 'PhysicalStockCount')
	drop table PhysicalStockCount
go


if exists (select * from sysobjects where name = 'BankingRegisterDetails')
	drop table BankingRegisterDetails
go

if exists (select * from sysobjects where name = 'BankingRegister')
	drop table BankingRegister
go

if exists (select * from sysobjects where name = 'BankAccounts')
	drop table BankAccounts
go


if exists (select * from sysobjects where name = 'InventoryINT')
	drop table InventoryINT
go

if exists (select * from sysobjects where name = 'ResourcesINT')
	drop table ResourcesINT
go

if exists (select * from sysobjects where name = 'RevenueStreams')
	drop table RevenueStreams
go

if exists (select * from sysobjects where name = 'RejectedSpecimens')
	drop table RejectedSpecimens
go





if exists (select * from sysobjects where name = 'Staff')
	drop table Staff
go

-------------------------------------------------------------------------



--------------------------------------------------------------------------------------
create table Dimensions
(DimensionCode varchar(20) not null,
DimensionTypeID varchar(10) not null
constraint fkDimensionTypeIDDimensions references LookupData (DataID),
constraint pkDimensionCodeDimensionTypeID primary key(DimensionCode, DimensionTypeID),
DimensionName varchar(100),
Blocked bit,
LoginID varchar(20)
constraint fkLoginIDDimensions references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineDimensions default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeDimensions default getdate()
)
go


create table Staff
(StaffID int not null constraint dfStaffIDStaff default 1,
StaffNo varchar(10) not null constraint pkStaffNo primary key,
FirstName varchar(20),
LastName varchar(20),
GenderID varchar(10) constraint fkGenderIDStaff references LookupData (DataID),
StaffTitleID varchar(10) constraint fkStaffTitleIDStaff references LookupData (DataID),
Speciality varchar(20),
Qualifications varchar(40),
Email varchar(40),
JoinDate smalldatetime,
Phone varchar(30),
Location varchar(40),
DoctorSpecialtyID varchar(10) null constraint fkDoctorSpecialtyIDStaff references LookupData (DataID),
Fingerprint image,
Signature image,
CreatorClientMachine varchar(40) constraint dfCreatorClientMachineStaff default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginIDStaff references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeStaff default getdate(),
ClientMachine varchar(41) constraint dfClientMachineStaff default host_name(),
LoginID varchar(20) null constraint fkLoginIDStaff references Logins (LoginID),
Hidden bit constraint dfHiddenStaff default 0
)
go

create table BillCustomers
(AccountID int not null constraint dfAccountID default 1,
AccountNo varchar(20) not null constraint pkAccountNo primary key,
BillCustomerName varchar(40) constraint uqBillCustomerName unique,
BillCustomerTypeID varchar(10) constraint fkBillCustomerTypeIDBillCustomers references LookupData (DataID),
InsuranceNo varchar(20) null constraint fkInsuranceNoBillCustomers references BillCustomers (AccountNo),
ContactPerson varchar(40) ,
Address varchar(100) ,
Phone varchar(30),
Fax varchar(100),
Email varchar(100),
Website varchar(100),
LogoPhoto image,
MemberDeclaration varchar(800),
DoctorDeclaration varchar(800),
CoPayTypeID varchar(10) constraint fkCoPayTypeIDBillCustomers references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentBillCustomers check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money,
CreditLimit money constraint dfCreditLimitBillCustomers default 0,
AllowOnlyListedMember bit constraint dfAllowOnlyListedMemberBillCustomers default 0,
UseCustomFee bit constraint dfUseCustomFeeBillCustomers default 0,
SmartCardApplicable bit constraint dfSmartCardApplicableBillCustomers default 0,
CaptureMemberCardNo bit constraint dfCaptureMemberCardNoBillCustomers default 1,
CaptureClaimReferenceNo bit constraint dfCaptureClaimReferenceNoBillCustomers default 1,
Hidden bit constraint dfHiddenBillCustomers default 0,
AccountStatusID varchar(10) constraint fkAccountStatusIDBillCustomers references LookupData (DataID),
AccountBalance money constraint dfAccountBalanceBillCustomers default 0 -- Calculated
)
go

create table Clients
(ReferenceID int constraint dfReferenceIDClients default 1,
ReferenceNo varchar(20) constraint pkReferenceNo primary key,
FirstName varchar(20),
LastName varchar(20),
MiddleName varchar(20),
GenderID varchar(10) constraint fkGenderIDClients references LookupData (DataID),
PhoneNo varchar(30),
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDClients references LookupData (DataID),
StaffNo varchar(10) constraint fkStaffNoClients references Staff (StaffNo),
Description varchar(200),
LoginID varchar(20) constraint fkLoginIDClients references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineClients default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeClients default GetDate()
)
go

create table AssociatedBillCustomers
(AccountNo varchar(20) not null constraint fkAccountNoAssociatedBillCustomers 
references BillCustomers (AccountNo) on delete cascade on update cascade,
AssociatedBillNo varchar(20) not null constraint fkAssociatedBillNoAssociatedBillCustomers 
references BillCustomers (AccountNo),
constraint pkAccountNoAssociatedBillNo primary key(AccountNo, AssociatedBillNo)
)
go

create table BillCustomFee
(AccountNo varchar(20) not null 
constraint fkAccountNoBillCustomFee references BillCustomers (AccountNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDBillCustomFee references LookupData (DataID),
constraint pkAccountNoItemCodeItemCategoryIDBillCustomFee primary key(AccountNo, ItemCode, ItemCategoryID),
CustomFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDBillCustomFee references LookupData (DataID)
)
go

create table BillExcludedItems
(AccountNo varchar(20) not null
constraint fkAccountNoBillExcludedItems references BillCustomers (AccountNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDBillExcludedItems references LookupData (DataID),
constraint pkAccountNoItemCodeItemCategoryIDBillExcludedItems primary key(AccountNo, ItemCode, ItemCategoryID)
)
go

create table BillCustomerMembers
(MedicalCardNo varchar(20) not null,
AccountNo varchar(20) not null constraint fkAccountNoBillCustomerMembers 
references BillCustomers (AccountNo) on delete cascade on update cascade,
constraint pkMedicalCardNoAccountNo primary key(MedicalCardNo, AccountNo),
Surname varchar(20),
FirstName varchar(20),
MiddleName varchar(20),
PolicyStartDate smalldatetime,
PolicyEndDate smalldatetime,
CreditLimit money constraint dfCreditLimitBillCustomerMembers default 0,
MemberStatusID varchar(10) constraint fkMemberStatusIDBillCustomerMembers references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDBillCustomerMembers references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeBillCustomerMembers default getdate()
)
go

create table MemberBenefits
(BenefitCode varchar(20) not null constraint pkBenefitCodeMemberBenefits primary key,
BenefitName varchar(100) constraint uqBenefitNameMemberBenefits unique,
ItemCategoryID varchar(10) null constraint fkItemCategoryIDMemberBenefits references LookupData (DataID)
)
go

create table MemberLimits
(MedicalCardNo varchar(20) not null,
AccountNo varchar(20) not null,
constraint fkMedicalCardNoAccountNoMemberLimits foreign key (MedicalCardNo, AccountNo)
references BillCustomerMembers (MedicalCardNo, AccountNo)on delete cascade on update cascade,
BenefitCode varchar(20) not null constraint fkBenefitCodeMemberLimits references MemberBenefits (BenefitCode),
constraint pkMedicalCardNoAccountNoBenefitCode primary key(MedicalCardNo, AccountNo, BenefitCode),
MemberLimit money
)
go

----------------------------------------------------------------------------------------------------------------
create table Insurances
(InsuranceID int not null constraint dfInsuranceIDInsurances default 1,
InsuranceNo varchar(20) not null constraint pkInsuranceNo primary key,
InsuranceName varchar(60) constraint uqInsuranceName unique,
ContactPerson varchar(40),
Address varchar(100),
Phone varchar(100),
Fax varchar(100),
Email varchar(100),
Website varchar(100),
LogoPhoto image,
MemberDeclaration varchar(800),
DoctorDeclaration varchar(800),
UseCustomFee bit constraint dfUseCustomFeeInsurances default 0,
Hidden bit constraint dfHiddenInsurances default 0
)
go

create table InsuranceExclusions
(InsuranceNo varchar(20) not null constraint fkInsuranceNoInsuranceExclusions 
references Insurances (InsuranceNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null
constraint fkItemCategoryIDInsuranceExclusions references LookupData (DataID),
constraint pkInsuranceNoItemCodeItemCategoryIDInsuranceExclusions primary key(InsuranceNo, ItemCode, ItemCategoryID)
)
go

create table InsurancePolicies
(PolicyID int not null constraint dfPolicyIDInsurancePolicies default 1,
PolicyNo varchar(20) not null constraint pkPolicyNo primary key,
InsuranceNo varchar(20) constraint fkInsuranceNoInsurancePolicies references Insurances (InsuranceNo),
PolicyName varchar(40) constraint uqPolicyName unique,
LoginID varchar(20) constraint fkLoginIDInsurancePolicies references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeInsurancePolicies default getdate()
)
go

create table Companies
(CompanyID int not null constraint dfCompanyIDCompanies default 1,
CompanyNo varchar(20) not null constraint pkCompanyNo primary key,
CompanyName varchar(60) constraint uqCompanyName unique,
ContactPerson varchar(100),
ContractStartDate smalldatetime,
ContractEndDate smalldatetime,
Address varchar(200),
Phone varchar(30)
)
go

create table InsuranceSchemes
(CompanyNo varchar(20) not null constraint fkCompanyNoInsuranceSchemes references Companies (CompanyNo),
PolicyNo varchar(20) not null constraint fkPolicyNoInsuranceSchemes references InsurancePolicies (PolicyNo),
constraint pkCompanyNoPolicyNo primary key(CompanyNo, PolicyNo),
SchemeJoinDate smalldatetime,
SchemeStartDate smalldatetime,
SchemeEndDate smalldatetime,
CoPayTypeID varchar(10) constraint fkCoPayTypeIDInsuranceSchemes references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentInsuranceSchemes check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money,
AnnualPremium money,
MemberPremium money,
SmartCardApplicable bit constraint dfSmartCardApplicableInsuranceSchemes default 0,
SchemeStatusID varchar(10) constraint fkSchemeStatusIDInsuranceSchemes references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDInsuranceSchemes references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeInsuranceSchemes default getdate()
)
go

create table PolicyLimits
(CompanyNo varchar(20) not null,
PolicyNo varchar(20) not null,
constraint fkCompanyNoPolicyNoPolicyLimits foreign key (CompanyNo, PolicyNo)
references InsuranceSchemes (CompanyNo, PolicyNo)on delete cascade on update cascade,
BenefitCode varchar(20) not null constraint fkBenefitCodePolicyLimits references MemberBenefits (BenefitCode),
constraint pkCompanyNoPolicyNoBenefitCode primary key(CompanyNo, PolicyNo, BenefitCode),
PolicyLimit money
)
go

create table InsuranceCustomFee
(InsuranceNo varchar(20) not null constraint fkInsuranceNoInsuranceCustomFee 
references Insurances (InsuranceNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInsuranceCustomFee references LookupData (DataID),
constraint pkInsuranceNoItemCodeItemCategoryID primary key(InsuranceNo, ItemCode, ItemCategoryID),
CustomFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDInsuranceCustomFee references LookupData (DataID)
)
go

create table InsuranceExcludedItems
(CompanyNo varchar(20) not null,
PolicyNo varchar(20) not null,
constraint fkCompanyNoPolicyNoInsuranceExcludedItems foreign key (CompanyNo, PolicyNo)
references InsuranceSchemes (CompanyNo, PolicyNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInsuranceExcludedItems references LookupData (DataID),
constraint pkCompanyNoPolicyNoItemCodeItemCategoryIDInsuranceExcludedItems 
primary key(CompanyNo, PolicyNo, ItemCode, ItemCategoryID)
)
go

create table SchemeMembers
(MedicalCardID int not null constraint dfMedicalCardIDSchemeMembers default 1,
MainMemberID int not null constraint dfMainMemberIDSchemeMembers default 0,
MemberTypeID varchar(10) constraint fkMemberTypeIDSchemeMembers references LookupData (DataID),
MedicalCardNo varchar(20) not null constraint pkMedicalCardNo primary key,
MainMemberNo varchar(20) null constraint fkMainMemberNoSchemeMembers references SchemeMembers (MedicalCardNo),
CompanyNo varchar(20),
PolicyNo varchar(20),
constraint fkCompanyNoPolicyNoSchemeMembers foreign key (CompanyNo, PolicyNo)
references InsuranceSchemes (CompanyNo, PolicyNo),
ReferenceNo varchar(20),
Surname varchar(20),
FirstName varchar(20),
MiddleName varchar(20),
BirthDate smalldatetime,
GenderID varchar(10) constraint fkGenderIDSchemeMembers references LookupData (DataID),
Address varchar(100),
Email varchar(40),
PhoneWork varchar(30),
PhoneMobile varchar(30),
PhoneHome varchar(30),
Photo image,
Fingerprint image,
JoinDate smalldatetime,
Relationship varchar(41),
PolicyStartDate smalldatetime,
PolicyEndDate smalldatetime,
MemberStatusID varchar(10) constraint fkMemberStatusIDSchemeMembers references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDSchemeMembers references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineSchemeMembers default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSchemeMembers default getdate()
)
go

create table HealthUnits
(HealthUnitCode varchar(10) not null constraint pkHealthUnitCode primary key,
HealthUnitName varchar(41) constraint uqHealthUnitName unique,
DistrictsID varchar(10) constraint fkDistrictsIDHealthUnits references LookupData (DataID),
ContactPerson varchar(100),
Address varchar(200),
Phone varchar(100)
)
go

create table Counties
(CountyCode varchar(20) not null constraint pkCountyCode primary key,
CountyName varchar(41),
DistrictsID varchar(10) constraint fkDistrictsIDCounties references LookupData (DataID)
constraint uqCountyNameDistrictsID unique(CountyName, DistrictsID)
)
go

create table SubCounties
(SubCountyCode varchar(20) not null constraint pkSubCountyCode primary key,
SubCountyName varchar(41),
CountyCode varchar(20) constraint fkCountyCodeSubCounties references Counties (CountyCode)
constraint uqSubCountyNameCountyCode unique(SubCountyName, CountyCode)
)
go

create table Parishes
(ParishCode varchar(20) not null constraint pkParishCode primary key,
ParishName varchar(41),
SubCountyCode varchar(20) constraint fkSubCountyCodeParishes references SubCounties (SubCountyCode)
constraint uqParishNameSubCountyCode unique(ParishName, SubCountyCode)
)
go

create table Villages
(VillageCode varchar(20) not null constraint pkVillageCode primary key,
VillageName varchar(41),
ParishCode varchar(20) constraint fkParishCodeVillages references Parishes (ParishCode)
constraint uqVillageNameParishCode unique(VillageName, ParishCode)
)
go

----------------------------------------------------------------------------------------------------------------

create table ResearchRoutingForm
(UCINo int constraint dfUCINoResearchRoutingForm default 1,
UCIID varchar(20) not null constraint pkUCIID primary key,
PatientNo varchar(20),
FirstName varchar(20),
LastName varchar(20),
OtherName varchar(20),
ReferalInitials varchar(10),
GenderID varchar(10) constraint fkGenderIDResearchRoutingForm references LookupData (DataID),
BirthDate smalldatetime,
VillageCode varchar(20) constraint fkVillageCodeResearchRoutingForm references Villages (VillageCode),
ReferralDate smalldatetime,
ReferralStudyCodeID varchar(10)constraint fkReferralStudyCodeIDResearchRoutingForm references LookupData (DataID),
ReferralStudyName varchar(100),
Diagnosis varchar(1000),
HealthUnitCode varchar(10)constraint fkHealthUnitCodeResearchRoutingForm references HealthUnits (HealthUnitCode),
ReferredBy varchar(100),
PatientScreenedBy varchar(200),
ReferralInitials varchar(10),
EligibleForScreeningID varchar(10) constraint fkEligibleForScreeningIDResearchRoutingForm references LookupData (DataID),
ExclusionReason varchar(1000),
PatientReferedTo varchar(200),
ReferredDate smalldatetime,
SCRNo varchar(20),
PID varchar(20),
SID varchar(20),
LoginID varchar(20) constraint fkLoginIDResearchRoutingForm references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineResearchRoutingForm default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeResearchRoutingForm default getdate()
)
go

create table EnrollmentInformation
(UCIID varchar(20) not null constraint fkUCIIDEnrollmentInformation references ResearchRoutingForm (UCIID)
on delete cascade on update cascade,
ReferralStudyCodeID varchar(10) not null constraint fkReferralStudyCodeIDEnrollmentInformation references LookupData (DataID),
constraint pkUCIIDReferralStudyCodeID primary key(UCIID, ReferralStudyCodeID),
EnrolledID varchar(10) constraint fkEnrolledIDEnrollmentInformation references LookupData (DataID),
CoEnrolledID varchar(10) constraint fkCoEnrolledIDEnrollmentInformation references LookupData (DataID),
CoEnrolledStudyCodeID varchar(10) constraint fkCoEnrolledStudyCodeIDEnrollmentInformation references LookupData (DataID),
CCInitials varchar(20),
ExclusionReason Varchar(1000),
EnrollmentDate Smalldatetime,
PatientReferred varchar(1000),
ReferredDate Smalldatetime,
LoginID varchar(20) constraint fkLoginIDEnrollmentInformation references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineEnrollmentInformation default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeEnrollmentInformation default getdate()
)
go

create table Suppliers
(SupplierID int not null constraint dfSupplierIDSuppliers default 1,
SupplierNo varchar(20) not null constraint pkSupplierNo primary key,
SupplierName varchar(60) constraint uqSupplierName unique,
ContactPerson varchar(100),
Address varchar(200),
Phone varchar(30),
LoginID varchar(20) constraint fkLoginIDSuppliers references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeSuppliers default getdate(),
ClientMachine varchar(41) constraint dfClientMachineSuppliers default host_name()
)
go

create table AssetRegister
(SerialNo Varchar(20)constraint pkSerialNo primary key,
ManufacturerID Varchar(20),
InstitutionalID Varchar(20),
Photo Image,
AssetSourceID Varchar(10) constraint fkAssetSourceIDAssetRegister references LookupData (DataID),
AssetCategoryID varchar(10) constraint fkAssetCategoryIDAssetRegister references LookupData (DataID),
DeptID Varchar(10) constraint fkDeptIDAssetRegister references LookupData (DataID),
ItemDescription Varchar(200),
Brand Varchar(200),
Quantity Int,
Value Int,
DateOfPurchase SmallDateTime,
SupplierNo Varchar(20) constraint fkSupplierNoAssetRegister references Suppliers (SupplierNo),
InvoiceNo Varchar(20),
InvoiceDate SmallDateTime,
DateOfDelivery SmallDateTime,
SalvageValue Int,
DepreciationRate Int,
UsefulLife Int,
DepreciationMethodID Varchar(10) constraint fkDepreciationMethodIDAssetRegister references LookupData (DataID),
DepreciationStartDate SmallDateTime,
AssignedTo Varchar(200),
Location Varchar(200),
ServicingSchedule int,
LoginID varchar(20) constraint fkLoginIDAssetRegister references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAssetRegister default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeAssetRegister default getdate()
)
go

create table AssetMaintainanceLog
(SerialNo Varchar(20) constraint fkSerialNoAssetMaintainanceLog references AssetRegister (SerialNo),
ActionTaken Varchar(200),
MaintainanceDate SmallDateTime,constraint pkSerialNoMaintainanceDate primary key(SerialNo, MaintainanceDate),
MaintainedBy Varchar(200),
MaintainaceCost Money,
NextDue SmallDateTime,
LoginID varchar(20) constraint fkLoginIDAssetMaintainanceLog references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAssetMaintainanceLog default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeAssetMaintainanceLog default getdate()
)
go

create table Services
(ServiceID int not null constraint dfserviceidservices default 1,
ServiceCode varchar(10) not null constraint pkServiceCode primary key,
ServiceName varchar(100) constraint uqServiceName unique,
ServicePointID varchar(10) constraint fkServicePointIDServices references LookupData (DataID),
ServiceBillAtID varchar(10) constraint fkServiceBillAtIDServices references LookupData (DataID),
RevenueStreamCode varchar(20),
UnitCost money constraint dfUnitCostServices default 0,
StandardFee money,
VATPercentage decimal constraint dfVATPercentageServices default 0,
Hidden bit constraint dfHiddenServices default 0
)
go

create table ServicesDrSpecialtyFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesDrSpecialtyFee 
references Services (ServiceCode) on delete cascade on update cascade,
DoctorSpecialtyID varchar(10) not null constraint fkDoctorSpecialtyIDServicesDrSpecialtyFee references LookupData (DataID),
constraint pkServiceCodeDoctorSpecialtyID primary key(ServiceCode, DoctorSpecialtyID),
SpecialtyFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesDrSpecialtyFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesDrSpecialtyFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesDrSpecialtyFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesDrSpecialtyFee default getdate()
)
go

create table ServicesStaffFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesStaffFee 
references Services (ServiceCode) on delete cascade on update cascade,
StaffNo varchar(10) not null constraint fkStaffNoServicesStaffFee references Staff (StaffNo),
constraint pkServiceCodeStaffNo primary key(ServiceCode, StaffNo),
StaffFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesStaffFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesStaffFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesStaffFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesStaffFee default getdate()
)
go


create table ServicesSpecialtyBillCustomFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesSpecialtyBillCustomFee 
references Services (ServiceCode) on delete cascade on update cascade,
DoctorSpecialtyID varchar(10) not null constraint fkDoctorSpecialtyIDServicesSpecialtyBillCustomFee references LookupData (DataID),
AccountNo varchar(20) not null constraint fkAccountNoServicesSpecialtyBillCustomFee 
references BillCustomers (AccountNo) on delete cascade on update cascade,
constraint pkServiceCodeDoctorSpecialtyIDAccountNo primary key(ServiceCode, DoctorSpecialtyID, AccountNo),
CustomFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesSpecialtyBillCustomFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesSpecialtyBillCustomFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesSpecialtyBillCustomFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesSpecialtyBillCustomFee default getdate()
)
go

create table ServicesStaffBillCustomFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesStaffBillCustomFee 
references Services (ServiceCode) on delete cascade on update cascade,
StaffNo varchar(10) not null constraint fkStaffNoServicesStaffBillCustomFee 
references Staff (StaffNo) on delete cascade on update cascade,
AccountNo varchar(20) not null constraint fkAccountNoServicesStaffBillCustomFee
references BillCustomers (AccountNo) on delete cascade on update cascade,
constraint pkServiceCodeStaffNoAccountNo primary key(ServiceCode, StaffNo, AccountNo),
CustomFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesStaffBillCustomFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesStaffBillCustomFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesStaffBillCustomFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesStaffBillCustomFee default getdate()
)
go

create table ServicesSpecialtyCustomCode
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesSpecialtyCustomCode 
references Services (ServiceCode) on delete cascade on update cascade,
DoctorSpecialtyID varchar(10) not null constraint fkDoctorSpecialtyIDServicesSpecialtyCustomCode references LookupData (DataID),
constraint pkServiceCodeDoctorSpecialtyIDServicesSpecialtyCustomCode primary key(ServiceCode, DoctorSpecialtyID),
CustomCode varchar(20),
LoginID varchar(20) constraint fkLoginIDServicesSpecialtyCustomCode references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesSpecialtyCustomCode default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesSpecialtyCustomCode default getdate()
)
go

create table DrugCombinations
(Combination varchar(30) not null constraint pkCombination primary key,
CombinationDes varchar(100)
)
go

create table Patients
(PatientID int not null constraint dfPatientID default 1,
PatientNo varchar(20)not null constraint pkPatientNo primary key,
NationalIDNo varchar(14),
ReferenceNo varchar(20),
FirstName varchar(20),
LastName varchar(20),
MiddleName varchar(20),
BirthDate smalldatetime,
GenderID varchar(10) constraint fkGenderIDPatients references LookupData (DataID),
Photo image,
Fingerprint image,
BirthPlace varchar(40), 
Address varchar(100),
Occupation varchar(100),
Phone varchar(30),
Email varchar(40),
JoinDate smalldatetime,
Location varchar(40),
NOKName varchar(41),
NOKRelationship varchar(20),
NOKPhone varchar(30),
DefaultBillModesID varchar(10) constraint fkDefaultBillModesIDPatients references LookupData (DataID),
DefaultBillNo varchar(20), -- Reference BillCustomers and SchemeMembers
DefaultMemberCardNo varchar(30),
DefaultMainMemberName varchar(41),
EnforceDefaultBillNo bit not null constraint dfEnforceDefaultBillNoPatients default 0,
HideDetails bit constraint dfHideDetailsPatients default 0,
StatusID varchar(10) constraint fkStatusIDPatients references LookupData (DataID),
BloodGroupID varchar(10) constraint fkBloodGroupIDPatients references LookupData (DataID),
VillageCode varchar(20) null constraint fkVillageCodePatients references Villages (VillageCode),
TribeID varchar(10) constraint fkTribeIDPatients references LookupData (DataID),
CountryID varchar(10) constraint fkCountryIDPatients references LookupData (DataID),
EducationLevelID varchar(10) constraint fkEducationLevelIDPatients references LookupData (DataID),
MaritalStatusID varchar(10) constraint fkMaritalStatusIDPatients references LookupData (DataID),
CareEntryPointID varchar(10) constraint fkCareEntryPointIDPatients references LookupData (DataID),
BranchID varchar(10) constraint fkBranchIDPatients references LookupData (DataID),
ReligionID varchar(10) constraint fkReligionIDPatients references LookupData (DataID),
Employer varchar(41) constraint dfEmployerPatients default '',
EmployerAddress varchar(100) constraint dfEmployerAddressPatients default '',
ReferringMedicalOfficer varchar(41) constraint dfReferringMedicalOfficerPatients default '',
NearestDispensary varchar(30) constraint dfNearestDispensaryPatients default '',
PreviousAdmissions varchar(30) constraint dfPreviousAdmissionsPatients default '',
ChronicDiseases varchar(200) constraint dfChronicDiseasesPatients default '',
FirstVisitDate smalldatetime, -- Calculated
LastVisitDate smalldatetime, -- Calculated
CombinationOn varchar(30), -- Calculated
TotalVisits int, -- Calculated
AccountBalance money constraint dfAccountBalancePatients default 0, -- Calculated
XrayNumbers  Decimal(6,2),
PoliceNotified bit not null constraint dfPoliceNotified default 0,
InfectiousDiseasesNotified bit not null constraint dfInfectiousDiseasesNotified default 0,
ReferringFacility varchar(41),
MedicalConditions varchar(2000),ProvisionalDiagnosis varchar(2000),
CommunityID varchar(10) constraint fkComnunityIDPatients references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPatients references Logins (LoginID), 
ClientMachine varchar(40) constraint dfClientMachinePatients default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePatients default getdate()
)
go

create table PatientsEXT
(PatientNo varchar(20) not null constraint fkPatientNoPatientsEXT 
references Patients (PatientNo) on delete cascade on update cascade,
AlternateNo varchar(20) not null,
constraint pkPatientNoAlternateNo primary key(PatientNo, AlternateNo),
Notes varchar(200)
)
go

create table PatientsINT
(PatientNo varchar(20)
constraint fkPatientNoPatientsINT references Patients (PatientNo),
SyncStatus bit,
AgentID varchar(20),
constraint pkPatientNoAgentID primary key(PatientNo, AgentID),
RecordDateTime smalldatetime constraint dfRecordDateTimePatientsINT default getdate()
)
go

create table HIVCARE
( PatientNo Varchar(20) not null constraint pkPatientNoHIVCARE primary key constraint 
 fkPatientNo references Patients (PatientNo) on delete cascade on update cascade,
HealthUnitCode varchar(10) constraint fkHealthUnit references HealthUnits (HealthUnitCode),
TeamLeader varchar(10) constraint fkTeamLeader references Staff (StaffNo),
PtClinic varchar(20),
LC1 Varchar(200),
ConfirmedTestDate smalldatetime,
HIVEnrolledDate smalldatetime,
EligibleARTDate smalldatetime,
EligibleReadyDate smalldatetime,
Ab bit,
PCR bit,
HIVCareWhere varchar(41),
HIVCareTransferIn bit,
TransferInFrom varchar(41),
WHOStageID varchar(10) constraint fkWHOStageIDPatients references LookupData (DataID),
CD4 decimal(10,2),
PresumptiveHIV bit,
PCRInfant bit,
MedicalConditions varchar(2000),
COHORTMonth tinyint,
COHORTYear smallint,
ARTTransferInDate smalldatetime,
ARTTransferInFrom varchar(40),
TransferInRegimen varchar(30) constraint fkTransferInRegimenPatients references DrugCombinations (Combination),
StartARTDate smalldatetime,
StartARTRegimen varchar(30) constraint fkStartARTRegimenPatients references DrugCombinations (Combination),
StartARTWeight decimal(10,2),
StartARTWHOStageID varchar(10) constraint fkStartARTWHOStageIDPatients references LookupData (DataID),
StartARTCD4 decimal(10,2),
PregnancyStatusID varchar(10) constraint fkPregnancyStatusIDPatients references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDHIVCARE references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeHIVCARE default getdate(),
ComputerName varchar(40) constraint dfComputerNameHIVCARE  default host_name()

)
go

create table RevenueStreams
(RevenueStreamCode varchar(20) not null constraint pkRevenueStreamCode primary key,
Name varchar(40),
Hidden bit constraint dfHiddenRevenueStreams default 0,
RecordDateTime smalldatetime constraint dfRecordDateTimeRevenueStreams default getdate()
)
go

create table Packages
(PackageID int not null constraint dfpackageidpackages default 1,
PackageNo varchar(20) not null constraint pkPackageNo primary key,
PackageName varchar(200),
UnitCost money,
UnitPrice money,
ExpiryDays int,
RevenueStreamCode varchar(20) constraint fkRevenueStreamCodePackages references RevenueStreams (RevenueStreamCode),
Hidden bit constraint dfHiddenPackages default 0,
MonitorQty bit constraint dfMonitorQtyPackages default 0,
LoginID varchar(20) constraint fkLoginIDPackages references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePackages default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePackages default getdate()
)
go

create table PackagesEXT
(PackageNo varchar(20) not null constraint fkPackageNoPackagesEXT references Packages (PackageNo),
ItemCode varchar(20),
ItemCategoryID varchar(10)constraint fkItemCategoryIDPackagesEXT references LookupData (DataID),
constraint pkPackageNoItemCodeItemCategoryID primary key(PackageNo, ItemCode, ItemCategoryID),
Quantity int,
UnitCost money,
UnitPrice money,
LoginID varchar(20) constraint fkLoginIDPackagesEXT references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachinePackagesEXT default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePackagesEXT default getdate()
)
go

create table Visits
(VisitID int not null constraint dfVisitID default 1,
VisitNo varchar(20) not null constraint pkVisitNo primary key,
PatientNo varchar(20) constraint fkPatientNoVisits references Patients(PatientNo),
VisitDate smalldatetime,
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDVisits references LookupData (DataID),
StaffNo varchar(10) null constraint fkStaffNoVisits references Staff (StaffNo),
VisitCategoryID varchar(10) constraint fkVisitCategoryIDVisits references LookupData (DataID),
ReferredBy varchar(40),
ServiceCode varchar(10) constraint fkServiceCodeVisits references Services(ServiceCode),
BillModesID varchar(10) constraint fkBillModesIDVisits references LookupData (DataID),
BillNo varchar(20), -- Reference BillCustomers and SchemeMembers
InsuranceNo varchar(20), -- Reference BillCustomers and Insurances
AssociatedBillNo varchar(20) null constraint fkAssociatedBillNoVisits references BillCustomers (AccountNo),
MemberCardNo varchar(30),
MainMemberName varchar(41),
ClaimReferenceNo varchar(30),
VisitStatusID varchar(10) constraint fkVisitStatusIDVisits references LookupData (DataID),
BranchID varchar(10) constraint fkBranchIDVisits references LookupData (DataID),
AccessCashServices bit constraint dfAccessCashServicesVisits default 0,
Locked bit constraint dfLockedVisits default 0,
FingerprintVerified bit constraint dfFingerprintVerifiedVisits default 0,
CoPayTypeID varchar(10) constraint fkCoPayTypeIDVisits references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentVisits check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money,
SmartCardApplicable bit constraint dfSmartCardApplicableVisits default 0,
VisitsPriorityID varchar(10) null constraint dfVisitsPriorityIDVisits references LookupData (DataID),
CommunityID varchar(10) constraint fkComnunityIDVisits references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDVisits references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineVisits default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeVisits default getdate()
)
go

create table AccessedCashServices
(VisitNo Varchar(20) not null constraint fkVisitNoAccessedCashServices references Visits (VisitNo) on delete cascade on update cascade,
ToVisitDate Smalldatetime not null, constraint pkVisitNoToVisitDate primary key(VisitNo, ToVisitDate),
AuthorisedBy varchar(41),
AuthorisationReason varchar(10) constraint fkAuthorisationReasonAccessedCashServices references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDAccessedCashServices references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineAccessedCashServices default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeAccessedCashServices default getdate()
)
go

create table PackageVisits
(VisitNo varchar(20) constraint fkVisitNoPackageVisits references Visits (VisitNo)
on delete cascade on update cascade,
PatientNo varchar(20) constraint fkPatientNoPackageVisits references Patients (PatientNo),
PackageNo varchar(20) constraint fkPackageNoPackageVisits references Packages (PackageNo),
constraint pkVisitNoPackageNoPackageVisits primary key(VisitNo, PackageNo),
PackageVisitNo varchar(20)
)
go

create table AttachPackage
(AttachPackageID int not null identity(1,1),
VisitNo varchar(20) constraint fkVisitNoAttachPackage references Visits (VisitNo)
on delete cascade on update cascade,
PatientNo varchar(20) constraint fkPatientNoAttachPackage references Patients (PatientNo),
PackageNo varchar(20) constraint fkPackageNoAttachPackage references Packages (PackageNo),
constraint pkVisitNoPackageNo primary key(VisitNo, PackageNo),
Details varchar(200),
PackageVisitNo varchar(20),
PackageStartDate smallDateTime constraint dfPackageStartDateAttachPackage default getdate(),
PackageEndDate smallDateTime,
LoginID varchar(20) constraint fkLoginIDAttachPackage references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineAttachPackage default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeAttachPackage default getdate()
)
go


create table PackageConsumption
(VisitNo varchar(20) constraint fkVisitNoPackageConsumption references Visits (VisitNo)
on delete cascade on update cascade,
PackageNo varchar(20) constraint fkPackageNoPackageConsumption references Packages (PackageNo),
ItemCode varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDPackageConsumption references LookupData (DataID),
constraint pkVisitNoPackageNoItemCodeItemCategoryID primary key(VisitNo, PackageNo, ItemCode, ItemCategoryID),
PackageVisitNo varchar(20),
ItemStatusID varchar(10) constraint fkItemStatusIDPackageConsumption references LookupData (DataID),
Quantity int,
LoginID varchar(20),
ClientMachine varchar(41) constraint dfClientMachinePackageConsumption default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePackageConsumption default getdate()
)
go

create table IPDPackageConsumption
(ExtraBillNo varchar(20),
VisitNo varchar(20) constraint fkVisitNoIPDPackageConsumption references Visits (VisitNo)
on delete cascade on update cascade,
PackageNo varchar(20) constraint fkPackageNoIPDPackageConsumption references Packages (PackageNo),
ItemCode varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDIPDPackageConsumption references LookupData (DataID),
constraint pkExtraBillNoPackageNoItemCodeItemCategoryID primary key(ExtraBillNo, PackageNo, ItemCode, ItemCategoryID),
PackageVisitNo varchar(20),
ItemStatusID varchar(10) constraint fkItemStatusIDIPDPackageConsumption references LookupData (DataID),
Quantity int,
LoginID varchar(20),
ClientMachine varchar(41) constraint dfClientMachineIPDPackageConsumption default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDPackageConsumption default getdate()
)
go

create table VisitFiles
(VisitNo varchar(20) not null constraint fkVisitNoVisitFiles references Visits (VisitNo)  
on delete cascade on update cascade constraint pkVisitNoVisitFiles primary key,
FileStatusID varchar(10) constraint fkFileStatusIDVisitFiles references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDVisitFiles references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeVisitFiles default getdate()
)
go

create table Triage
(VisitNo varchar(20) not null constraint fkVisitNoTriage references Visits (VisitNo) 
constraint pkVisitNoTriage primary key,
Weight decimal(5,2) constraint ckWeight check (Weight > 0 and Weight <= 200),
Temperature decimal(5,2) constraint ckTemperature check (Temperature > 30 and Temperature < 50),
Height decimal(5,2) constraint ckHeight check (Height > 20 and Height < 300),
Pulse tinyint constraint ckPulse check (Pulse > 10 and Pulse <= 300),
BloodPressure varchar(10),
HeadCircum decimal(5,2) constraint ckHeadCircum check (HeadCircum > 20 and HeadCircum < 150),
BodySurfaceArea decimal(10,2),
RespirationRate tinyint constraint ckRespirationRate check (RespirationRate > 10 and RespirationRate < 150),
OxygenSaturation decimal(5,2) constraint ckOxygenSaturation check (OxygenSaturation > 0 and OxygenSaturation <= 100),
HeartRate tinyint constraint ckHeartRate check (HeartRate > 0 and HeartRate <= 250),
TriagePriorityID varchar(10) null constraint dfTriagePriorityIDTriage references LookupData (DataID),
Notes varchar(2000),
MUAC decimal(5,2) constraint ckMUACTriage check (MUAC > 0 and MUAC < 150),
BMIStatusID varchar(10) constraint fkBMIStatusIDTriage references LookupData (DataID),
MUACStatusID varchar(10) constraint fkMUACStatusIDTriage references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDTriage references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineTriage default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeTriage default getdate()
)
go

create table VisionAssessment
(VisitNo varchar(20) not null constraint fkVisitNoVisionAssessment 
references Visits (VisitNo) on delete cascade on update cascade,
EntryOrder int not null constraint dfVisionAssessment default 1,
EyeTestID varchar(10) not null constraint fkEyeTestIDVisionAssessment references LookupData (DataID),
constraint pkVisitNoEyeTestID primary key(VisitNo, EyeTestID),
VisualAcuityRightID varchar(10)constraint fkVisualAcuityRightIDVisionAssessment references LookupData (DataID),
VisualAcuityRightExtID varchar(10)constraint fkVisualAcuityRightExtIDVisionAssessment references LookupData (DataID),
VisualAcuityLeftID varchar(10)constraint fkVisualAcuityLeftIDVisionAssessment references LookupData (DataID),
VisualAcuityLeftExtID varchar(10)constraint fkVisualAcuityLeftExtIDVisionAssessment references LookupData (DataID),
PreferentialLookingRightID varchar(10)constraint fkPreferentialLookingRightIDVisionAssessment references LookupData (DataID),
PreferentialLookingLeftID varchar(10)constraint fkPreferentialLookingLeftIDVisionAssessment references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20)constraint fkLoginIDVisionAssessment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineVisionAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeVisionAssessment default getdate()
)
go

create table DrugAdministration
(VisitNo varchar(20) constraint fkVisitNoDrugAdministration references Visits (VisitNo) On delete cascade on update cascade,
TakenDateTime smalldatetime,
ItemCode varchar(20) not null
constraint pkVisitNoTakenDateTimeItemCode primary key(VisitNo, TakenDateTime,ItemCode),
ItemCategory varchar(10) constraint fkItemCategoryDrugAdministration references LookupData (DataID),
ItemName varchar(800) not null,
constraint uqVisitNoTakenDateTimeItemName unique(VisitNo, TakenDateTime, ItemName),
QuantityTaken int,
NurseNotes varchar(200),
StaffNo varchar(10) constraint fkStaffNoDrugAdministration references Staff (StaffNo),
LoginID varchar(20) constraint fkLoginIDDrugAdministration references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineDrugAdministration default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeDrugAdministration default getdate()
)
go


create table TBIntensifiedCaseFinding
(VisitNo varchar(20) not null constraint fkVisitNoTBIntensifiedCaseFinding references Visits (VisitNo) constraint pkVisitNoTBIntensifiedCaseFinding
 primary key,
CoughingTwoWeeksMoreID varchar(10) constraint fkCoughingTwoWeeksMoreIDTBIntensifiedCaseFinding references LookupData (DataID),
PersistantFeversID varchar(10) constraint fkPersistantFeversIDTBIntensifiedCaseFinding references LookupData (DataID),
NoticableWeightLossID varchar(10) constraint fkNoticableWeightLossIDTBIntensifiedCaseFinding references LookupData (DataID),
ExcessiveNightSweatsID varchar(10) constraint fkExcessiveNightSweatsIDTBIntensifiedCaseFinding references LookupData (DataID),
PoorWeightGainID varchar(10) constraint fkPoorWeightGainIDTBIntensifiedCaseFinding references LookupData (DataID),
PulmonaryTBChronicCoughContactID varchar(10) constraint fkPulmonaryTBChronicCoughContactIDTBIntensifiedCaseFinding references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDTBIntensifiedCaseFinding references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineTBIntensifiedCaseFinding default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeTBIntensifiedCaseFinding default getdate()
) 
go

create table DrugCategories
(CategoryNo varchar(10) not null constraint pkCategoryNo primary key,
CategoryName varchar(40) constraint uqCategoryName unique,
VaryPrescribedQty bit constraint dfVaryPrescribedQtyDrugCategories default 0,
DefaultPrescribedQty smallint constraint dfDefaultPrescribedQtyDrugCategories default 0,
DosageSeparator char(1) constraint dfDosageSeparatorDrugCategories default 'X',
DosageCalculationID varchar(10) constraint fkDosageCalculationIDDrugCategories references LookupData (DataID),
DosageFormat varchar(40)
)
go


create table Drugs
(DrugID int not null constraint dfDrugIDDrugs default 1,
DrugNo varchar(20) not null constraint pkDrugNo primary key,
DrugName varchar(100) constraint uqDrugName unique,
AlternateName varchar(100),
CategoryNo varchar(10) constraint fkCategoryNoDrugs references DrugCategories (CategoryNo),
GroupsID varchar(10) constraint fkGroupsIDDrugs references LookupData (DataID),
UnitMeasureID varchar(10) constraint fkUnitMeasureIDDrugs references LookupData (DataID),
OrderLevel int constraint dfOrderLevelDrugs default 0,
KeepingUnit int constraint dfKeepingUnitDrugs default 0,
UnitCost money,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageDrugs default 0,
LastUpdate smalldatetime,
Halted bit constraint dfHaltedDrugs default 0,
Hidden bit constraint dfHiddenDrugs default 0,
UnitsInStock int constraint dfUnitsInStockDrugs default 0,
BatchNo varchar(20) constraint dfBatchNoDrugs default '',
ExpiryDate smalldatetime constraint dfExpiryDateDrugs default '1 Jan 1900',
LoginID Varchar(20) constraint fkLoginIDDrugs references Logins (LoginID),
RecordDateTime SmallDateTime constraint dfRecordDateTimeDrugs default getdate(),
ClientMachine Varchar(41) constraint dfClientMachineDrugs default host_name()
)
go

create table AlternateDrugs
(DrugNo varchar(20) not null constraint fkDrugNoAlternateDrugs 
references Drugs (DrugNo) on delete cascade on update cascade,
AlternateDrugNo varchar(20) not null 
constraint fkAlternateDrugNoAlternateDrugs references Drugs (DrugNo),
constraint pkDrugNoAlternateDrugNo primary key(DrugNo, AlternateDrugNo)
)
go

create table ConsumableItems
(ConsumableID int not null constraint dfConsumableIDConsumableItems default 1,
ConsumableNo varchar(20) not null constraint pkConsumableNo primary key,
ConsumableName varchar(100) constraint uqConsumableName unique,
AlternateName varchar(100),
UnitMeasureID varchar(10) constraint fkUnitMeasureIDConsumableItems references LookupData (DataID),
ConsumableCategoryID varchar(10), -- constraint fkConsumableCategoryIDConsumableItems references LookupData(DataID),
OrderLevel int constraint dfOrderLevelConsumableItems default 0,
KeepingUnit int constraint dfKeepingUnitConsumableItems default 0,
UnitCost money,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageConsumableItems default 0,
LastUpdate smalldatetime,
Halted bit constraint dfHaltedConsumableItems default 0,
Hidden bit constraint dfHiddenConsumableItems default 0,
UnitsInStock int constraint dfUnitsInStockConsumableItems default 0,
BatchNo varchar(20) constraint dfBatchNoConsumableItems default '',
ExpiryDate smalldatetime constraint dfExpiryDateConsumableItems default '1 Jan 1900',
LoginID Varchar(20) constraint fkLoginIDConsumableItems references Logins (LoginID),
RecordDateTime SmallDateTime constraint dfRecordDateTimeConsumableItems default getdate(),
ClientMachine Varchar(41) constraint dfClientMachineConsumableItems default host_name()
)
go

create table OtherItems
(ItemID int not null constraint dfItemIDOtherItems default 1,
ItemCode Varchar(20) constraint pkItemCode primary key,
ItemName varchar(200),
ItemCategoryID varchar(10) constraint fkItemCategoryIDOtherItems references LookupData (DataID),
UnitCost Money,
Quantity int constraint dfQuantityOtherItems default 0,
Details Varchar(1000),
GroupsID varchar(10) constraint fkGroupsIDOtherItems references LookupData (DataID),
UnitMeasureID varchar(10) constraint fkUnitMeasureIDOtherItems references LookupData (DataID),
VATPercentage decimal constraint dfVATPercentageOtherItems default 0,
LocationID Varchar(10) constraint fkLocationIDOtherItems references LookupData (DataID),
Hidden bit constraint dfHiddenOtherItems default 0,
BatchNo varchar(20) constraint dfBatchNoOtherItems default '',
ExpiryDate smalldatetime constraint dfExpiryDateOtherItems default '1 Jan 1900',
LoginID Varchar(20) constraint fkLoginIDOtherItems references Logins (LoginID),
RecordDateTime SmallDateTime constraint dfRecordDateTimeOtherItems default getdate(),
ClientMachine Varchar(41) constraint dfClientMachineOtherItems default host_name()
)
go

create table ItemLocationOrderLevels
(LocationID varchar(10) not null constraint fkLocationIDItemLocationOrderLevels references LookupData (DataID),
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDItemLocationOrderLevels references LookupData (DataID),
ItemCode varchar(20) not null, constraint pkLocationIDItemCategoryIDItemCodeItemLocationOrderLevels primary key(LocationID, ItemCategoryID, ItemCode),
LocationOrderLevel int,
LoginID varchar(20) constraint fkLoginIDItemLocationOrderLevels references Logins (LoginID),
ClientMachine varchar(40),
RecordDateTime smallDateTime constraint dfRecordDateTimeItemLocationOrderLevels default getdate()
)
go


create table ExchangeRates
(CurrenciesID varchar(10) not null constraint fkCurrenciesIDExchangeRates 
references LookupData (DataID) constraint pkCurrenciesID primary key,
Buying money constraint ckBuyingExchangeRates check (Buying > 0),
Selling money constraint ckSellingExchangeRates check (Selling > 0),
LoginID varchar(20) constraint fkLoginIDExchangeRates references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeExchangeRates default getdate()
)
go

create table Payments
(ReceiptID int not null constraint dfReceiptID default 1,
ReceiptNo varchar(20) not null constraint pkReceiptNo primary key,
PayTypeID varchar(10) constraint fkPayTypeIDPayments references LookupData (DataID),
PayNo varchar(20), -- References Visits, Bills (Bill Customers/Insurances), IPD Rounds
ClientFullName varchar(100),
PayDate smalldatetime,
PayModesID varchar(10) constraint fkPayModesIDPayments references LookupData (DataID),
DocumentNo varchar(20),
AmountWords varchar(200),
Notes varchar(100),
CurrenciesID varchar(10) constraint fkCurrenciesIDPayments references LookupData (DataID),
WithholdingTax money constraint dfWithholdingTaxPayments default 0,
GrandDiscount money constraint dfGrandDiscountPayments default 0,
AmountTendered money,
ExchangeRate money,
Change money,
SendBalanceToAccount bit constraint dfSendBalanceToAccountPayments default 0,
UseAccountBalance bit constraint dfUseAccountBalancePayments default 0,
VisitTypeID varchar(10) constraint fkVisitTypeIDPayments references LookupData (DataID),
FilterNo varchar(20) null constraint fkFilterNoPayments references Visits (VisitNo),
BranchID varchar(10) constraint fkBranchIDPayments references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPayments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePayments default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePayments default getdate()
)
go

create table RefundRequests
(RefundRequestID int not null constraint dfRefundRequestIDRefundRequests default 1,
RefundRequestNo varchar(20) not null
constraint pkRefundRequestNo primary key,
ReceiptNo varchar(20)
constraint fkReceiptNoRefundRequests references Payments (ReceiptNo),
RequestStatusID varchar(10)
constraint fkRequestStatusIDRefundRequests references LookupData (DataID),
ApprovalStatusID varchar(10)
constraint fkApprovalStatusIDRefundRequests references LookupData (DataID),
VisitTypeID varchar(10)
constraint fkVisitTypeIDRefundRequests references LookupData (DataID),
Requestedby varchar(41),
LoginID varchar(20)
constraint fkLoginIDRefundRequests references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundRequests default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundRequests default getdate()
)
go


create table RefundRequestDetails
(RefundRequestNo varchar(20) not null
constraint fkRefundRequestNoRefundRequestDetails references RefundRequests (RefundRequestNo),
VisitNo varchar(20) not null,
ReceiptNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10)
constraint fkItemCategoryIDRefundRequestDetails references LookupData (DataID),
constraint pkRefundRequestNoVisitNoReceiptNoItemCodeItemCategoryID primary key(RefundRequestNo, VisitNo, ReceiptNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundRequestDetails references LookupData (DataID),
Quantity int,
Amount money,
NewPrice money,
LoginID varchar(20)
constraint fkLoginIDRefundRequestDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundRequestDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundRequestDetails default getdate()
)
go


create table RefundApprovals
(RefundRequestNo varchar(20)
constraint fkRefundRequestNoRefundApprovals references RefundRequests (RefundRequestNo)
constraint pkRefundRequestNoRefundApprovals primary key,
Notes varchar(800),
AttendingPersonel varchar(41),
ApprovalStatusID varchar(10) constraint fkApprovalStatusIDRefundApprovals references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDRefundApprovals references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundApprovals default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundApprovals default getdate()
)
go

create table RefundRejects
(RefundRequestNo varchar(20)
constraint fkRefundRequestNoRefundRejects references RefundRequests (RefundRequestNo)
constraint pkRefundRequestNoRefundRejects primary key,
ReceiptNo varchar(20)
constraint fkReceiptNoRefundRejects references Payments (ReceiptNo),
RejectedAt varchar(10)
constraint fkRejectedAtRefundRejects references LookupData (DataID),
RejectionDate smallDateTime,
Notes varchar(200),
LoginID varchar(20)
constraint fkLoginIDRefundRejects references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineRefundRejects default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeRefundRejects default getdate()
)
go

create table Refunds
(RefundID int not null constraint dfRefundIDRefunds default 1,
RefundNo varchar(20) not null constraint pkRefundNo primary key,
ReceiptNo varchar(20) constraint fkReceiptNoRefunds references Payments (ReceiptNo)
on delete cascade on update cascade,
RefundRequestNo varchar(20) constraint fkRefundRequestNoRefunds references RefundRequests(RefundRequestNo),
RefundDate smalldatetime,
Amount money,
AmountWords varchar(200),
Notes varchar(200),
VisitTypeID varchar(10) constraint fkVisitTypeIDRefunds references LookupData (DataID),
BranchID varchar(10) constraint fkBranchIDRefunds references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDRefunds references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefunds default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefunds default getdate()
)
go

create table RefundDetails
(RefundNo varchar(20) not null
constraint fkRefundNoRefundDetails references Refunds (RefundNo),
VisitNo varchar(20) not null,
ReceiptNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10)
constraint fkItemCategoryIDRefundDetails references LookupData (DataID),
constraint pkRefundNoVisitNoReceiptNoItemCodeItemCategoryID primary key(RefundNo, VisitNo, ReceiptNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundDetails references LookupData (DataID),
Quantity int,
Amount money,
LoginID varchar(20)
constraint fkLoginIDRefundDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundDetails default getdate()
)
go

create table INTRefunds
(ReceiptNo varchar(20) constraint pkReceiptNoINTRefunds primary key,
SyncStatus varchar(20),
AgentID varchar(20),
RecordDateTime smalldatetime constraint dfRecordDateTimeINTRefunds default getdate()
)
go

create table ReceiptReversals
(ReceiptNo varchar(20) constraint fkReceiptNoReceiptReversals references Payments (ReceiptNo),
RefundNo varchar(20) constraint fkRefundNoReceiptReversals references Refunds (RefundNo) constraint pkRefundNoReceiptReversals primary key,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDReceiptReversals references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineReceiptReversals default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeReceiptReversals default getdate()
)
go

create table ItemsIncome
(VisitNo varchar(20) constraint fkVisitNoItemsIncome references Visits (VisitNo),
ItemCode Varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDItemsIncome references LookupData (DataID),
constraint pkVisitNoItemCodeItemCategoryIDItemsIncome primary key(VisitNo, ItemCode, ItemCategoryID),
ItemName Varchar(500),
UnitPrice money,
CopayAmount money,
Quantity int,
VATValue money constraint dfVATValueItemsIncome default 0,
LoginID varchar(20) constraint fkLoginIDItemsIncome references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineItemsIncome default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeItemsIncome default getdate()
)
go

create table Items
(VisitNo varchar(20) not null constraint fkVisitNoItems references Visits(VisitNo),
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDItems references LookupData (DataID)
constraint pkVisitNoItemCodeItemCategoryID primary key (VisitNo, ItemCode, ItemCategoryID),
ItemName varchar(800) not null, constraint uqVisitNoItemCategoryIDItemCodeItems unique(VisitNo, ItemCategoryID, ItemCode),
InvoiceNo varchar(20),
UnitMeasure varchar(100),
Quantity int,
UnitCost money constraint dfUnitCostItems default 0,
UnitPrice money ,
VATValue money constraint dfVATValueItems default 0,
ItemDetails varchar(800),
LastUpdate smalldatetime,
ItemStatusID varchar(10) constraint fkItemStatusIDItems references LookupData (DataID),
PayStatusID varchar(10) constraint fkPayStatusIDItems references LookupData (DataID),
OriginalQuantity int,
OriginalPrice money,
ConclusionDate smallDateTime,
PayDate smallDateTime,
LoginID varchar(20) constraint fkLoginIDItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeItems default getdate(),
CreatorClientMachine varchar(40) constraint dfCreatorClientMachine default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginID references Logins (LoginID)
)
go

create table PaymentDetails
(ReceiptNo varchar(20) not null constraint fkReceiptNoPaymentDetails references Payments(ReceiptNo)
on delete cascade on update cascade,
VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDPaymentDetails references LookupData (DataID),
constraint fkVisitNoItemCodeItemCategoryIDPaymentDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkReceiptNoVisitNoItemCodeItemCategoryID primary key (ReceiptNo, VisitNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money ,
Discount money ,
Amount money,
SyncStatus bit constraint dfSyncStatusPaymentDetails default 0

)
go

create table Invoices
(InvoiceID int not null constraint dfInvoiceIDInvoices default 1,
InvoiceNo varchar(20) not null constraint pkInvoiceNo primary key,
PayTypeID varchar(10) constraint fkPayTypeIDInvoices references LookupData (DataID),
PayNo varchar(20), --References Visits, Bills (Bill Customers/Insurances), IPD Rounds
InvoiceDate smalldatetime,
StartDate smalldatetime,
EndDate smalldatetime,
AmountWords varchar(200),
VisitTypeID varchar(10) constraint fkVisitTypeIDInvoices references LookupData (DataID),
Locked bit constraint dfLockedInvoices default 0,
Cancelled  bit constraint dfCancelledInvoices default 0,
EntryModeID varchar(10)
constraint fkEntryModeIDInvoices references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDInvoices references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeInvoices default getdate()
)
go

create table InvoiceDetails
(InvoiceNo varchar(20) not null constraint fkInvoiceNoInvoiceDetails references Invoices (InvoiceNo)
on delete cascade on update cascade,
VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInvoiceDetails references LookupData (DataID),
constraint fkVisitNoItemCodeItemCategoryIDInvoiceDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkInvoiceNoVisitNoItemCodeItemCategoryID primary key(InvoiceNo, VisitNo, ItemCode, ItemCategoryID),
ObjectName varchar(40) constraint fkObjectNameInvoiceDetails references AccessObjects (ObjectName)
constraint ckObjectNameInvoiceDetails check (ObjectName in ('Items', 'ItemsCASH', 'ExtraBillItems', 'ExtraBillItemsCASH')),
Quantity int,
UnitPrice Money,
Discount Money,
Amount Money
)
go

create table InvoicesDetailsINT
(InvoiceNo varchar(20),
SyncStatus bit constraint dfSyncStatusInvoicesDetailsINT default 0,
AgentID varchar(20),
constraint pkInvoiceNoAgentIDInvoicesDetailsINT primary key(InvoiceNo, AgentID),
RecordDateTime smalldatetime constraint dfRecordDateTimeInvoicesDetailsINT default getdate()
)
go

create table ReceiptInvoiceDetails
(InvoiceNo varchar(20),
ReceiptNo varchar(20),
constraint pkInvoiceNoReceiptNo primary key(InvoiceNo, ReceiptNo)
)
go


create table ItemsCASH
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDItemsCASH foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDItemsCASH primary key (VisitNo, ItemCode, ItemCategoryID),
InvoiceNo varchar(20) constraint dfInvoiceNoItemsCASH default  '',
CashAmount money constraint dfCashAmountItemsCASH default 0,
CashPayStatusID varchar(10) constraint fkCashPayStatusIDItemsCASH references LookupData (DataID)
)
go

create table ItemsEXT
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDItemsEXT  foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDItemsEXT primary key (VisitNo, ItemCode, ItemCategoryID),
Dosage varchar(100),
Duration int,
DrQuantity int,
IssueDateTime smalldatetime null,
Pharmacist varchar(10) null constraint fkPharmacistItemsEXT references Staff (StaffNo),
LocationID varchar(10) null constraint fkLocationIDItemsEXT references LookupData (DataID),
LoginID varchar(20) null constraint fkLoginIDItemsEXT references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineItemsEXT default host_name()
)
go



create table Quotations
(QuotationID int not null constraint dfQuotationIDQuotations default 1,
QuotationNo varchar(20) not null constraint pkQuotationNo primary key,
QuotationDate smalldatetime,
AmountWords varchar(200),
LoginID varchar(20) constraint fkLoginIDQuotations references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineQuotations default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeQuotations default getdate()
)
go

create table QuotationDetails
(QuotationNo varchar(20) not null constraint fkQuotationNoQuotationDetails 
references Quotations (QuotationNo) on delete cascade on update cascade,
VisitNo varchar(20) not null constraint fkVisitNoQuotationDetails 
references Visits (VisitNo) on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDQuotationDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkQuotationNoVisitNoItemCategoryIDItemCode primary key(QuotationNo, VisitNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqQuotationNoVisitNoItemCategoryIDItemName unique(QuotationNo, VisitNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
Quantity int,
UnitPrice money,
Discount money,
Amount money,
LoginID varchar(20) constraint fkLoginIDQuotationDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineQuotationDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeQuotationDetails default getdate()
)
go

create table Accounts
(AccountID int not null identity (1,1),
TranID int not null constraint dfTranID default 1,
TranNo varchar(20) not null constraint pkTranNo primary key,
ClientFullName varchar(100),
AccountBillModesID varchar(10) constraint fkAccountBillModesIDAccounts references LookupData (DataID),
AccountBillNo varchar(20),
TranDate smalldatetime,
PayModesID varchar(10) constraint fkPayModesIDAccounts references LookupData (DataID),
AccountActionID varchar(10) constraint fkAccountActionIDAccounts references LookupData (DataID),
Amount money,
Balance money,
DocumentNo varchar(20),
ReferenceNo varchar(20),
AmountWords varchar(200),
CurrenciesID varchar(10) constraint fkCurrenciesIDAccounts references LookupData (DataID),
AmountTendered money,
ExchangeRate money,
Change money,
AccountGroupID varchar(10) constraint fkAccountGroupIDAccounts references LookupData (DataID),
Notes varchar(100),
EntryModeID varchar(10) constraint fkEntryModeIDAccounts references LookupData (DataID),
BranchID varchar(10) constraint fkBranchIDAccounts references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDAccounts references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineAccounts default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeAccounts default getdate()
)
go

create table AccountsEXT
(TranNo varchar(20) constraint fkTranNoAccountsEXT references Accounts (TranNo)
on delete cascade on update cascade,
ReferenceNo varchar(20) constraint fkReferenceNoAccountsEXT references Accounts (TranNo),
constraint pkTranNoReferenceNo primary key(TranNo, ReferenceNo)
)
go

create table DepositsINT
(TransNo varchar(20),
SyncStatus bit constraint dfSyncStatusDepositsINT default 0,
AgentID varchar(20), constraint pkTransNoAgentID primary key(TransNo, AgentID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDepositsINT default getdate()
)
go

create table AccountTransferDetails
(TranNo varchar(20) constraint fkTranNoAccountTransferDetails references Accounts (TranNo) constraint pkTranNoAccountTransferDetails primary key,
FromAccount varchar(20),
ToAccount varchar(20) constraint fkToAccountAccountTransferDetails references BillCustomers (AccountNo),
Amount money,
AmountInWords varchar(500),
Reason varchar(10) constraint fkReasonAccountTransferDetails references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDAccountTransferDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineAccountTransferDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeAccountTransferDetails default getdate()
)
go

create table DoctorVisits
(VisitNo varchar(20) not null constraint pkVisitNoDoctorVisits primary key
constraint fkVisitNoDoctorVisits references Visits(VisitNo),
StaffNo varchar(10) constraint fkStaffNoDoctorVisits references Staff (StaffNo),
ServiceCode varchar(10) constraint fkServiceCodeDoctorVisits references Services(ServiceCode),
Closed bit constraint dfClosedDoctorVisits default 0,
LoginID varchar(20) constraint fkLoginIDDoctorVisits references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineDoctorVisits default host_name(), 
RecordDateTime smalldatetime constraint dfRecordDateTimeDoctorVisits default getdate()
)
go

create table ClinicalFindings
(VisitNo varchar(20) not null constraint pkVisitNoClinicalFindings primary key
constraint fkVisitNoClinicalFindings references Visits (VisitNo)
on delete cascade on update cascade,
PresentingComplaint varchar(1000),
ClinicalNotes varchar(4000),
ROS varchar(1000),
PMH varchar(1000),
POH varchar(1000),
PGH varchar(1000),
FSH varchar(1000),
GeneralAppearance varchar(1000),
Respiratory varchar(1000),
CVS varchar(1000),
ENT varchar(1000),
Abdomen varchar(1000),
CNS varchar(1000),
EYE varchar(1000),
MuscularSkeletal varchar(1000),
Skin varchar(1000),
PV varchar(1000),
PsychologicalStatus varchar(1000),
ProvisionalDiagnosis varchar(1000),
TreatmentPlan varchar(1000),
ClinicalImage image,
LoginID varchar(20) constraint fkLoginIDClinicalFindings references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeClinicalFindings default getdate()
)
go

create table Procedures
(ProcedureID int not null constraint dfprocedureidprocedures default 1,
ProcedureCode varchar(10) not null constraint pkProcedureCode primary key,
ProcedureName varchar(800) constraint uqProcedureName unique,
ShortName varchar(200),
ProcedureCategoryID varchar(10) constraint fkProcedureCategoryID references LookupData (DataID),
UnitCost money,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageProcedures default 0,
Hidden bit constraint dfHiddenProcedures default 0,
RevenueStream varchar(20), 
LoginID varchar(20) constraint fkLoginIDProcedures references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeProcedures default getdate(),
ClientMachine varchar(41) constraint dfClientMachineProcedures default host_name()
)
go

create table Orthoptics
(VisitNo varchar(20) constraint pkVisitNoOrthoptics primary key 
constraint fkVisitNoOrthoptics references Visits (VisitNo) on delete cascade on update cascade,
HeadPosture varchar(200),
Fixation varchar(200),
LeftHirschberg varchar(200),
RightHirschberg varchar(200),
RightEOM varchar(200),
LeftEOM varchar(200),
CoverTestID varchar(10)
constraint fkCoverTestIDOrthoptics references LookupData (DataID),
LeftAPCTGlasses varchar(200),
RightAPCTGlasses varchar(200),
LeftAPCTWithOutGlasses varchar(200),
RightAPCTWithOutGlasses varchar(200),
Correspondence varchar(200),
PrismAdaptation varchar(200),
FusionConvergence varchar(200),
FusionDivergence varchar(200),
FusionRange varchar(200),
NearPointOfAccommodation varchar(200),
NearPointOfConvergence varchar(200),
OrthopticsNotes varchar(400),
LoginID varchar(20)
constraint fkLoginIDOrthoptics references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOrthoptics default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeOrthoptics default getdate()
)
go

create table EyeAssessment
(VisitNo varchar(20) not null constraint pkVisitNoEyeAssessment primary key 
constraint fkVisitNoEyeAssessment references Visits (VisitNo)
on delete cascade on update cascade,
LeftPupil varchar(200),
RightPupil varchar(200),
LeftLidMargin varchar(200),
RightLidMargin varchar(200),
LeftConjuctiva varchar(200),
RightConjuctiva varchar(200),
LeftBulbarConjuctiva varchar(200),
RightBulbarConjuctiva varchar(200),
LeftCentralCornea varchar(200),
RightCentralCornea varchar(200),
LeftVerticalCornea varchar(200),
RightVerticalCornea varchar(200),
LeftAnteriorChamber varchar(200),
RightAnteriorChamber varchar(200),
LeftIrish varchar(200),
RightIrish varchar(200),
LeftAnteriorChamberAngle varchar(200),
RightAnteriorChamberAngle varchar(200),
LeftRetina varchar(200),
RightRetina varchar(200),
LeftMacular varchar(200),
RightMacular varchar(200),
LeftOpticDisc varchar(200),
RightOpticDisc varchar(200),
LeftIOP varchar(10),
RightIOP varchar(10),
LeftVitreous varchar(200),
RightVitreous varchar(200),
LeftLense varchar(200),
RightLense varchar(200),
EyeNotes varchar(200),
LeftEyeBall varchar(200),
RightEyeBall varchar(200),
LeftOrbit varchar(200),
RightOrbit varchar(200),
LoginID varchar(20) constraint fkLoginIDEyeAssessment references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineEyeAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeEyeAssessment default getdate()
)
go

create table LowVision
(VisitNo varchar(20) constraint pkVisitNoLowVision primary key  constraint fkVisitNoLowVision references Visits (VisitNo) on delete cascade on update cascade,
BriefHistory varchar(200),
Profession varchar(200),
MajorOcularDiagnosisRE varchar(200),
MajorOcularDiagnosisLE varchar(200),
OtherOcularDiagnosisRE varchar(200),
OtherOcularDiagnosisLE varchar(200),
OphthalmologistSeenID varchar(10) constraint fkOphthalmologistSeenIDLowVision references LookupData (DataID),
OtherImpairmentsID varchar(10) constraint fkOtherImpairmentsIDLowVision references LookupData (DataID),
OtherImpairments varchar(200),
ExistingTreatmentFarRE varchar(200),
ExistingTreatmentFarLE varchar(200),
ExistingTreatmentNearRE varchar(200),
ExistingTreatmentNearLE varchar(200),
NewTreatmentFarRE varchar(200),
NewTreatmentFarLE varchar(200),
NewTreatmentNearRE varchar(200),
NewTreatmentNearLE varchar(200),
ExistingVisualAcuityFarLEID varchar(200),
ExistingVisualAcuityFarREID varchar(200),
ExistingVisualAcuityNearLEID varchar(200),
ExistingVisualAcuityNearREID varchar(200),
NewVisualAcuityFarLEID varchar(200),
NewVisualAcuityFarREID varchar(200),
NewVisualAcuityNearLEID varchar(200),
NewVisualAcuityNearREID varchar(200),
ExistingLVDsNear varchar(200),
ExistingLVDsFar varchar(200),
ProblemEncounteredLVDsNear varchar(200),
ProblemEncounteredLVDsFar varchar(200),
ColourVisionDefectID varchar(10) constraint fkColourVisionDefectIDLowVision references LookupData (DataID),
ColourVisionTestUsed varchar(200),
ContrastSensitivityID varchar(10) constraint fkContrastSensitivityIDLowVision references LookupData (DataID),
ContrastSensitivityTestUsed varchar(200),
VisualFieldDefectID varchar(10) constraint fkVisualFieldDefectIDLowVision references LookupData (DataID),
VisualFieldDefectTestUsed varchar(200),
LowVisionDevicesFar varchar(200),
LowVisionDevicesNear varchar(200),
NonOpticalAids varchar(200),
Advice varchar(200),
LoginID varchar(20) constraint fkLoginIDLowVision references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineLowVision default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeLowVision default getdate()
)
go

create table Optical
(VisitNo varchar(20) not null constraint pkVisitNoOptical primary key
constraint fkVisitNoOptical references Visits (VisitNo)
on delete cascade on update cascade,
RightSPH varchar(200),
RightCYL varchar(200),
RightAXIS varchar(200),
RightPRISM varchar(200),
RightADD varchar(200),
LeftSPH varchar(200),
LeftCYL varchar(200),
LeftAXIS varchar(200),
LeftPRISM varchar(200),
LeftADD varchar(200),
LenseTypeID varchar(10) constraint fkLenseTypeIDOptical references LookupData (DataID),
Pd smallint,
Sg smallint,
LoginID varchar(20) constraint fkLoginIDOptical references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeOptical default getdate()
)
go

create table DentalServices
(DentalID int not null constraint dfdentaliddentalservices default 1,
DentalCode varchar(10) not null constraint pkDentalCode primary key,
DentalName varchar(200) constraint uqDentalName unique,
DentalCategoryID varchar(10) constraint fkDentalCategoryIDDentalServices references LookupData (DataID),
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageDentalServices default 0,
Hidden bit constraint dfHiddenDentalServices default 0
)
go

create table TheatreServices
(TheatreID int not null constraint dftheatreidtheatreservices default 1,
TheatreCode varchar(20) not null constraint pkTheatreCode primary key,
TheatreName varchar(200) constraint uqTheatreName unique,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageTheatreServices default 0,
Hidden bit constraint dfHiddenTheatreServices default 0
)
go

create table EyeServices
(EyeID int not null constraint dfeyeideyeservices default 1,
EyeCode varchar(20) not null constraint pkEyeCode primary key,
EyeName varchar(200) constraint uqEyeName unique,
UnitCost money,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageEyeServices default 0,
Hidden bit constraint dfHiddenEyeServices default 0
)
go

create table Refraction
(VisitNo varchar(20) not null constraint pkVisitNoRefraction primary key  constraint fkVisitNoRefraction
references Visits (VisitNo) on delete cascade on update cascade,
RightMRSPH varchar(200),
LeftMRSPH varchar(200),
RightMRCYL varchar(200),
LeftMRCYL varchar(200),
RightMRAXIS varchar(200),
LeftMRAXIS varchar(200),
RightCRSPH varchar(200),
LeftCRSPH varchar(200),
RightCRCYL varchar(200),
LeftCRCYL varchar(200),
RightCRAXIS varchar(200),
LeftCRAXIS varchar(200),
RightPCRSPH varchar(200),
LeftPCRSPH varchar(200),
RightPCRCYL varchar(200),
LeftPCRCYL varchar(200),
RightPCRAXIS varchar(200),
LeftPCRRAXIS varchar(200),
PD varchar(200),
SegmentHeights varchar(200),
LoginID varchar(20)
constraint fkLoginIDRefraction references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefraction default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefraction default getdate()
)
go

create table OpticalServices
(OpticalID int not null constraint dfopticalidopticalservices default 1,
OpticalCode varchar(20) not null constraint pkOpticalCode primary key,
OpticalName varchar(200) constraint uqOpticalName unique,
OpticalCategoryID varchar(10) constraint fkOpticalCategoryIDOpticalServices references LookupData (DataID),
UnitCost money,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageOpticalServices default 0,
Hidden bit constraint dfHiddenOpticalServices default 0
)
go

create table MaternityServices
(MaternityID int not null constraint dfmaternityidmaternityservices default 1,
MaternityCode varchar(20) not null constraint pkMaternityCode primary key,
MaternityName varchar(200) constraint uqMaternityName unique,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageMaternityServices default 0,
Hidden bit constraint dfHiddenMaternityServices default 0
)
go

create table ICUServices
(ICUID int not null constraint dficuidicuservices default 1,
ICUCode varchar(20) not null constraint pkICUCode primary key,
ICUName varchar(200) constraint uqICUName unique,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageICUServices default 0,
Hidden bit constraint dfHiddenICUServices default 0
)
go

create table TopologySites
(TopographicalNo varchar(20) not null constraint pkTopographicalNo primary key,
TopologySiteCodeID varchar(10)constraint fkTopologySiteCodeIDTopologySites references LookupData (DataID),
TopologySiteName varchar(800),
Hidden bit,
LoginID varchar(20) constraint fkLoginIDTopologySites references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineTopologySites default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeTopologySites default getdate()
)
go

create table CancerDiseases
(DiseaseID int not null constraint dfDiseaseIDCancerDiseases default 1,
DiseaseNo varchar(20) not null constraint pkDiseaseNo primary key,
DiseaseCode varchar(10),
DiseaseName varchar(800),
CancerDiseaseCategoriesID varchar(10) constraint fkCancerDiseaseCategoriesIDCancerDiseases references LookupData (DataID),
Hidden bit,
LoginID varchar(20) constraint fkLoginIDCancerDiseases references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineCancerDiseases default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeCancerDiseases default getdate()
)
go

create table CancerDiagnosis
(VisitNo varchar(20) constraint fkVisitNoCancerDiagnosis references Visits (VisitNo),
DiseaseNo varchar(20) constraint fkDiseaseNoCancerDiagnosis references CancerDiseases (DiseaseNo),
constraint pkVisitNoDiseaseNo primary key(VisitNo, DiseaseNo),
TopographicalNo varchar(20) constraint fkTopographicalNoCancerDiagnosis references TopologySites (TopographicalNo),
BasisOfDiagnosisID varchar(10) constraint fkBasisOfDiagnosisIDCancerDiagnosis references LookupData (DataID),
CancerStageID varchar(10) constraint fkCancerStageIDCancerDiagnosis references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20)constraint fkLoginIDCancerDiagnosis references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineCancerDiagnosis default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCancerDiagnosis default getdate()
)
go

create table Diseases
(DiseaseCode varchar(10) not null constraint pkDiseaseCode primary key,
DiseaseName varchar(800) constraint uqDiseaseName unique,
DiseaseCategoriesID varchar(10) constraint fkDiseaseCategoriesIDDiseases references LookupData (DataID),
Hidden bit constraint dfHiddenDiseases default 0
)
go

create table PhysioDiseases
(DiseaseID int constraint dfDiseaseIDPhysioDiseases default 0,
PhysioDiseaseNo varchar(20) constraint pkPhysioDiseaseNo primary key,
DiseaseCode varchar(10),
DiseaseName varchar(200),
PhysioDiseaseCategoriesID varchar(10) constraint fkPhysioDiseaseCategoriesIDPhysioDiseases references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPhysioDiseases references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePhysioDiseases default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePhysioDiseases default getdate()
)
go

create table PhysioDiagnosis
(VisitNo Varchar(20) constraint fkVisitNoPhysioDiagnosis references Visits (VisitNo),
PhysioDiseaseNo varchar(20) constraint fkPhysioDiseaseNoPhysioDiseases references PhysioDiseases (PhysioDiseaseNo),
constraint pkVisitNoPhysioDiseaseNo primary key(VisitNo, PhysioDiseaseNo),
Notes Varchar(200),
LoginID varchar(20) constraint fkLoginIDPhysioDiagnosis references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePhysioDiagnosis default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePhysioDiagnosis default getdate()
)
go

create table Physiotherapy
(VisitNo Varchar(20) constraint fkVisitNoPhysiotherapy references Visits (VisitNo),
OnMedication Varchar(10) constraint fkOnMedicationPhysiotherapy references LookupData (DataID),
Medication Varchar(100),
Pain24hoursOrVAS Varchar(10) constraint fkPain24hoursOrVASPhysiotherapy references LookupData (DataID),
LevelOfDependenceOrADLS Varchar(10) constraint fkLevelOfDependenceOrADLSPhysiotherapy references LookupData (DataID),
MuscleStatus varchar(100),
StatusOfJoints Varchar(50),
Sensitivity varchar(100),
WalkingAnalysis varchar(100),
ShortTermTreatmentTargets varchar(100),
LongTermTreatmentTargets varchar(100),
ProvisionalDiagnosis varchar(100),
LoginID Varchar(20) constraint fkLoginIDPhysiotherapy references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePhysiotherapy default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePhysiotherapy default getdate()
)
go

create table Diagnosis
(VisitNo varchar(20) constraint fkVisitNoDiagnosis references Visits(VisitNo),
DiseaseCode varchar(10) constraint fkDiseaseCodeDiagnosis references Diseases (DiseaseCode),
constraint pkVisitNoDiseaseCode primary key(VisitNo, DiseaseCode),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDDiagnosis references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeDiagnosis default getdate()
)
go

create table Referrals
(VisitNo varchar(20) not null constraint pkVisitNoReferrals primary key
constraint fkVisitNoReferrals references Visits (VisitNo)
on delete cascade on update cascade,
ReferralDate smalldatetime,
ReferredBy varchar(10) constraint fkReferredByReferrals references Staff (StaffNo),
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDReferrals references LookupData (DataID),
ReferredTo varchar(10) constraint fkReferredToReferrals references Staff (StaffNo),
ReferralNotes varchar(4000),
LoginID varchar(20) constraint fkLoginIDReferrals references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeReferrals default getdate()
)
go

create table ExternalReferrals
(VisitNo varchar(20)
constraint fkVisitNoExternalReferrals references Visits (VisitNo)
constraint pkVisitNoExternalReferrals primary key,
ProcedurePaidBy varchar(200),
EmployeeName varchar(200),
ReferredTo varchar(200),
DepartureTime varchar(8),
DateOfReferral smalldatetime,
HistoryAndSymptoms varchar(2000),
Diagnosis varchar (2000),
TreatmentGiven varchar(2000),
ReasonForReferral varchar(2000),
LabInvestigations varchar(2000),
StaffNo varchar(10)
constraint fkStaffNoExternalReferrals references Staff (StaffNo),
AuthorisedBy varchar(200),
TreatmentLimit money,
LoginID varchar(20)
constraint fkLoginIDExternalReferrals references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineExternalReferrals default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeExternalReferrals default getdate()
)
go


create table SymptomsHistory
(VisitNo varchar(20) not null constraint fkVisitNoSymptomsHistory references Visits (VisitNo)
constraint pkVisitNoSymptomsHistory primary key,
Fever varchar(10) constraint fkFeverSymptomsHistory references LookupData (DataID),
Cough varchar(10) constraint fkCoughSymptomsHistory references LookupData (DataID),
CoughMoreThanTwoWeeks varchar(10) constraint fkCoughMoreThanTwoWeeksSymptomsHistory references LookupData (DataID),
DifficultyInBreathing varchar(10) constraint fkDifficultyInBreathingSymptomsHistory references LookupData (DataID),
ImmunizationDetails varchar(10) constraint fkImmunizationDetailsSymptomsHistory references LookupData (DataID),
OtherHistory varchar(2000),
Convulsions varchar(10) constraint fkConvulsionsSymptomsHistory references LookupData (DataID),
AlteredConsciousness varchar(10) constraint fkAlteredConsciousnessSymptomsHistory references LookupData (DataID),
Vomiting varchar(10) constraint fkVomitingSymptomsHistory references LookupData (DataID),
UnableToDrinkBreastfeed varchar(10) constraint fkUnableToDrinkBreastfeedSymptomsHistory references LookupData (DataID),
PastMedicalHistory varchar(2000),
Diarrhoea varchar(10) constraint fkDiarrhoeaSymptomsHistory references LookupData (DataID),
DiarrhoeaLongerThanTwoWeeks varchar(10) constraint fkDiarrhoeaLongerThanTwoWeeksSymptomsHistory references LookupData (DataID),
BloodDiarrhoea varchar(10) constraint fkBloodDiarrhoeaSymptomsHistory references LookupData (DataID),
PassingTeaColouredUrine varchar(10) constraint fkPassingTeaColouredUrineSymptomsHistory references LookupData (DataID),
FeedingHistory varchar(2000),
Pallor varchar(10) constraint fkPallorSymptomsHistory references LookupData (DataID),
SkinPinchReturn varchar(10) constraint fkSkinPinchReturnSymptomsHistory references LookupData (DataID),
SevereWasting varchar(10) constraint fkSevereWastingSymptomsHistory references LookupData (DataID),
Edema varchar(10) constraint fkEdemaSymptomsHistory references LookupData (DataID),
SunkenEyes varchar(10) constraint fkSunkenEyesSymptomsHistory references LookupData (DataID),
Jaundice varchar(10) constraint fkJaundiceSymptomsHistory references LookupData (DataID),
MUAC int ,
Height int,
DeepBreathing varchar(10) constraint fkDeepBreathingSymptomsHistory references LookupData (DataID),
FlaringOfNostrils varchar(10) constraint fkFlaringOfNostrilsSymptomsHistory references LookupData (DataID),
IntercostalRecession  varchar(10) constraint fkIntercostalRecessionSymptomsHistory references LookupData (DataID),
subCostalRecession  varchar(10) constraint fksubCostalRecessionSymptomsHistory references LookupData (DataID),
Pulse varchar(10) constraint fkPulseSymptomsHistory references LookupData (DataID),
CapRefill varchar(10) constraint fkCapRefillSymptomsHistory references LookupData (DataID),
Airway varchar(10) constraint fkAirwaySymptomsHistory references LookupData (DataID),
Wheezing varchar(10) constraint fkWheezingSymptomsHistory references LookupData (DataID),
PleuralRub varchar(10) constraint fkPleuralRubSymptomsHistory references LookupData (DataID),
Crackles varchar(10) constraint fkCracklesSymptomsHistory references LookupData (DataID),
Unconscious varchar(10) constraint fkUnconsciousSymptomsHistory references LookupData (DataID),
Lethargic varchar(10) constraint fkLethargicSymptomsHistory references LookupData (DataID),
UnableToSitStand varchar(10) constraint fkUnableToSitStandSymptomsHistory references LookupData (DataID),
BulgingFontanelle varchar(10) constraint fkBulgingFontanelleSymptomsHistory references LookupData (DataID),
StiffNeck varchar(10) constraint fkStiffNeckSymptomsHistory references LookupData (DataID),
KerningsSign varchar(10) constraint fkKerningsSignSymptomsHistory references LookupData (DataID),
IsBloodTransfusionDesired varchar(10) constraint fkIsBloodTransfusionDesiredSymptomsHistory references LookupData (DataID),
BloodTransfusionStateReasons varchar(200),
IfDesiredWasBloodGiven varchar(10) constraint fkIfDesiredWasBloodGivenSymptomsHistory references LookupData (DataID),
IfYesVolume int,
TransfusionDate smallDateTime,
BloodUnits int,
BloodTransfusionNotGivenStateReasons varchar(200),
OtherFormsOfSupportiveCare varchar(200),
ReasonsForDiagnosisOfSevereComplicatedMalaria varchar(200),
ReasonsForAdmissionWithPositiveMalariaTest varchar(200),
LoginID varchar(20) constraint fkLoginIDSymptomsHistory references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineSymptomsHistory default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSymptomsHistory default getdate()

)
go

------------------------------------------------------------------------------------------
create table Rooms
(RoomNo varchar(20) not null constraint pkRoomNo primary key,
RoomName varchar(41),
WardsID varchar(10) constraint fkWardsIDRooms references LookupData (DataID)
constraint uqRoomNameWardsID unique(RoomName, WardsID)
)
go

create table Beds
(BedID int not null constraint dfbedidbeds default 1,
BedNo varchar(20) not null constraint pkBedNo primary key,
BedName varchar(41),
RoomNo varchar(20) constraint fkRoomNoBeds references Rooms (RoomNo)
constraint uqBedNameRoomNo unique(BedName, RoomNo),
UnitCost money,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageBeds default 0,
Hidden bit constraint dfHiddenBeds default 0
)
go

create table Admissions
(AdmissionID int not null constraint dfAdmissionID default 1,
AdmissionNo varchar(20) not null constraint pkAdmissionNo primary key,
VisitNo varchar(20) constraint fkVisitNoAdmissions references Visits (VisitNo)
constraint uqVisitNoAdmissions unique,
StaffNo varchar(10) constraint fkStaffNoAdmissions references Staff (StaffNo),
BedNo varchar(20) constraint fkBedNoAdmissions references Beds (BedNo),
PatientNo varchar(20) constraint fkPatientNoAdmissions references Patients (PatientNo),
ChartNumber Varchar(20),
AdmissionDateTime smalldatetime,
BillModesID varchar(10) constraint fkBillModesIDAdmissions references LookupData (DataID),
BillNo varchar(20), -- Reference BillCustomers and SchemeMembers
InsuranceNo varchar(20), -- Reference BillCustomers and Insurances
AssociatedBillNo varchar(20) null constraint fkAssociatedBillNoAdmissions references BillCustomers (AccountNo),
MemberCardNo varchar(30),
MainMemberName varchar(41),
ClaimReferenceNo varchar(30),
CoPayTypeID varchar(10) constraint fkCoPayTypeIDAdmissions references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentAdmissions check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money,
AccessCashServices bit constraint dfAccessCashServicesAdmissions default 0,
SmartCardApplicable bit constraint dfSmartCardApplicableAdmissions default 0,
AdmissionNotes varchar(2000),
AdmissionStatusID varchar(10) constraint fkAdmissionStatusIDAdmissions references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDAdmissions references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineAdmissions default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeAdmissions default getdate()
)
go

create table IPDDoctor
(RoundID int not null constraint dfRoundIDIPDDoctor default 1,
RoundNo varchar(20) not null constraint pkRoundNo primary key,
AdmissionNo varchar(20) constraint fkAdmissionNoIPDDoctor references Admissions (AdmissionNo),
StaffNo varchar(10) constraint fkStaffNoIPDDoctor references Staff (StaffNo),
RoundDateTime smalldatetime,
LoginID varchar(20) constraint fkLoginIDIPDDoctor references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDDoctor default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDoctor default getdate()
)
go

create table IPDClinicalFindings
(RoundNo varchar(20) not null constraint pkRoundNoIPDClinicalFindings primary key
constraint fkRoundNoIPDClinicalFindings references IPDDoctor (RoundNo)
on delete cascade on update cascade,
Weight decimal(5,2) constraint ckWeightIPDClinicalFindings check (Weight > 0 and Weight <= 200),
Temperature decimal(5,2) constraint ckTemperatureIPDClinicalFindings check (Temperature > 30 and Temperature < 50),
Height decimal(5,2) constraint ckHeightIPDClinicalFindings check (Height > 40 and Height < 300),
Pulse tinyint constraint ckPulseIPDClinicalFindings check (Pulse > 10 and Pulse <= 300),
BloodPressure varchar(10),
HeadCircum decimal(5,2) constraint ckHeadCircumIPDClinicalFindings check (HeadCircum > 20 and HeadCircum < 150),
BodySurfaceArea decimal(10,2),
History varchar(100),
ClinicalNotes varchar(4000),
Respiratory varchar(100),
GeneralAppearance varchar(100),
CVS varchar(100),
Abdomen varchar(100),
CNS varchar(100),
MuscularSkeletal varchar(100),
PsychologicalStatus varchar(100),
ClinicalDiagnosis varchar(100),
ClinicalImage image,
LoginID varchar(20) constraint fkLoginIDIPDClinicalFindings references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDClinicalFindings default getdate()
)
go

create table IPDVisionAssessment
(VARoundID int constraint dfVARoundIDIPDVisionAssessment default 1,
AdmissionNo varchar(20) constraint fkAdmissionNoIPDVisionAssessment references Admissions (AdmissionNo),
RoundDateTime smalldatetime constraint dfRoundDateTimeIPDVisionAssessment default getdate(),
VARoundNo Varchar(20) not null,
EyeTestID varchar(10) not null constraint fkEyeTestIDIPDVisionAssessment references LookupData (DataID),
constraint pkVARoundNoEyeTestID primary key(VARoundNo, EyeTestID),
VisualAcuityRightID varchar(10)constraint fkVisualAcuityRightIDIPDVisionAssessment references LookupData (DataID),
VisualAcuityRightExtID varchar(10)constraint fkVisualAcuityRightExtIDIPDVisionAssessment references LookupData (DataID),
VisualAcuityLeftID Varchar(10)constraint fkVisualAcuityLeftIDIPDVisionAssessment references LookupData (DataID),
VisualAcuityLeftExtID Varchar(10)constraint fkVisualAcuityLeftExtIDIPDVisionAssessment references LookupData (DataID),
PreferentialLookingRightID Varchar(10)constraint fkPreferentialLookingRightIDIPDVisionAssessment references LookupData (DataID),
PreferentialLookingLeftID Varchar(10)constraint fkPreferentialLookingLeftIDIPDVisionAssessment references LookupData (DataID),
Notes Varchar(200),
LoginID varchar(20)
constraint fkLoginIDIPDVisionAssessment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDVisionAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDVisionAssessment default getdate()
)
go

create table IPDEyeAssessment(
RoundNo varchar(20) not null constraint pkRoundNoIPDEyeAssessment primary key
constraint fkRoundNoIPDEyeAssessment references IPDDoctor (RoundNo)
on delete cascade on update cascade,
LeftPupil varchar(200),
RightPupil varchar(200),
LeftLidMargin varchar(200),
RightLidMargin varchar(200),
LeftConjuctiva varchar(200),
RightConjuctiva varchar(200),
LeftBulbarConjuctiva varchar(200),
RightBulbarConjuctiva varchar(200),
LeftCentralCornea varchar(200),
RightCentralCornea varchar(200),
LeftVerticalCornea varchar(200),
RightVerticalCornea varchar(200),
LeftAnteriorChamber varchar(200),
RightAnteriorChamber varchar(200),
LeftIrish varchar(200),
RightIrish varchar(200),
LeftAnteriorChamberAngle varchar(200),
RightAnteriorChamberAngle varchar(200),
LeftRetina varchar(200),
RightRetina varchar(200),
LeftMacular varchar(200),
RightMacular varchar(200),
LeftOpticDisc varchar(200),
RightOpticDisc varchar(200),
LeftIOP varchar(10),
RightIOP varchar(10),
LeftVitreous varchar(200),
RightVitreous varchar(200),
LeftLense varchar(200),
RightLense varchar(200),
EyeNotes varchar(200),
LeftEyeBall varchar(200),
RightEyeBall varchar(200),
LeftOrbit varchar(200),
RightOrbit varchar(200),
LoginID varchar(20)
constraint fkLoginIDIPDEyeAssessment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDEyeAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDEyeAssessment default getdate()
)
go

create table IPDOrthoptics
(RoundNo varchar(20) not null constraint pkRoundNoIPDOrthoptics primary key
constraint fkRoundNoIPDOrthoptics references IPDDoctor (RoundNo)
on delete cascade on update cascade,
HeadPosture varchar(200),
Fixation varchar(200),
LeftHirschberg varchar(200),
RightHirschberg varchar(200),
RightEOM varchar(200),
LeftEOM varchar(200),
CoverTestID varchar(10) constraint fkCoverTestIDIPDOrthoptics references LookupData (DataID),
LeftAPCTGlasses varchar(200),
RightAPCTGlasses varchar(200),
LeftAPCTWithOutGlasses varchar(200),
RightAPCTWithOutGlasses varchar(200),
Correspondence varchar(200),
PrismAdaptation varchar(200),
FusionConvergence varchar(200),
FusionDivergence varchar(200),
FusionRange varchar(200),
NearPointOfAccommodation varchar(200),
NearPointOfConvergence varchar(200),
OrthopticsNotes varchar(400),
LoginID varchar(20) constraint fkLoginIDIPDOrthoptics references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDOrthoptics default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDOrthoptics default getdate()
)
go

create table IPDItems
(RoundNo varchar(20) not null constraint fkRoundNoIPDItems references IPDDoctor(RoundNo),
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDIPDItems references LookupData (DataID)
constraint pkRoundNoItemCodeItemCategoryID primary key (RoundNo, ItemCode, ItemCategoryID),
ItemName varchar(800) not null, constraint uqRoundNoItemCategoryIDItemCodeItems unique(RoundNo, ItemCategoryID, ItemCode),
UnitMeasure varchar(100),
Quantity int,
UnitCost money constraint dfUnitCostIPDItems default 0,
UnitPrice money ,
ItemDetails varchar(800) ,
LastUpdate smalldatetime ,
ItemStatusID varchar(10) constraint fkItemStatusIDIPDItems references LookupData (DataID),
PayStatusID varchar(10) constraint fkPayStatusIDIPDItems references LookupData (DataID),
OriginalQuantity int,
OriginalPrice money,
LoginID varchar(20) constraint fkLoginIDIPDItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDItems default getdate(),
CreatorClientMachine varchar(40) constraint dfCreatorClientMachineIPDItems default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginIDIPDItems references Logins (LoginID)

)
go

create table IPDItemsEXT
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDItemsEXT  foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDItemsEXT primary key (RoundNo, ItemCode, ItemCategoryID),
Dosage varchar(100),
Duration int,
DrQuantity int,
IssueDateTime smalldatetime null,
Pharmacist varchar(10) null constraint fkPharmacistIPDItemsEXT references Staff (StaffNo),
LocationID varchar(10) null constraint fkLocationIDIPDItemsEXT references LookupData (DataID),
LoginID varchar(20) null constraint fkLoginIDIPDItemsEXT references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDItemsEXT default host_name()
)
go

create table IPDDiagnosis
(RoundNo varchar(20) constraint fkRoundNoIPDDiagnosis references IPDDoctor(RoundNo),
DiseaseCode varchar(10) constraint fkDiseaseCodeIPDDiagnosis references Diseases (DiseaseCode),
constraint pkRoundNoDiseaseCode primary key(RoundNo, DiseaseCode),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDDiagnosis references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDiagnosis default getdate()
)
go

create table IPDCancerDiagnosis
(RoundNo varchar(20) constraint fkRoundNoIPDCancerDiagnosis references IPDDoctor (RoundNo),
DiseaseNo varchar(20) constraint fkDiseaseNoIPDCancerDiagnosis references CancerDiseases (DiseaseNo),
constraint pkRoundNoDiseaseNoIPDCancerDiagnosis primary key(RoundNo, DiseaseNo),
TopographicalNo varchar(20) constraint fkTopographicalNoIPDCancerDiagnosis references TopologySites (TopographicalNo),
BasisOfDiagnosisID varchar(10) constraint fkBasisOfDiagnosisIDIPDCancerDiagnosis references LookupData (DataID),
CancerStageID varchar(10) constraint fkCancerStageIDIPDCancerDiagnosis references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDCancerDiagnosis references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineIPDCancerDiagnosis default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeIPDCancerDiagnosis default getdate()
)
go

create table Discharges
(AdmissionNo varchar(20) not null constraint fkAdmissionNoDischarges 
references Admissions (AdmissionNo) constraint pkAdmissionNoDischarges primary key,
StaffNo varchar(10) constraint fkStaffNoDischarges references Staff (StaffNo),
RoundNo varchar(20) constraint fkRoundNoDischarges references IPDDoctor (RoundNo),
DischargeDateTime smalldatetime,
DischargeNotes varchar(2000),
DischargeStatusID varchar(10) constraint fkDischargeStatusIDDischarges references LookupData (DataID),
ReviewDate smalldatetime,
History varchar(400),
Examination varchar(400),
KeyFindingsInvestigation varchar(400),
TreatmentOnWard varchar(400),
OutcomeOfTreatment varchar(400),
KeyRecommendations varchar(400),
LoginID varchar(20) constraint fkLoginIDDischarges references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDischarges default getdate()
)
go


------------------------------------------------------------------------------------------

create table LabTests
(TestID int not null constraint dftestidlabtests default 1,
TestCode varchar(20) not null constraint pkTestCodeID primary key,
TestName varchar(100) not null constraint uqTestName unique,
SpecimenTypeID varchar(10) constraint fkSpecimenTypeIDLabTests references LookupData (DataID) ,
LabsID varchar(10) constraint fkLabsIDLabTests references LookupData (DataID),
NormalRange varchar(800) ,
UnitMeasureID varchar(10) constraint fkUnitMeasureIDLabTests references LookupData (DataID),
UnitCost money,
TestFee money,
VATPercentage decimal constraint dfVATPercentageLabTests default 0,
ResultDataTypeID varchar(10) constraint fkResultDataTypeIDLabTests references LookupData (DataID),
Hidden bit constraint dfHiddenLabTests default 0,
RequiresResultsApproval bit constraint dfRequiresResultsApprovalLabTests default 0,
TubeType varchar(200) null,
TestDescription varchar(500) null,
LoginID varchar(20) null constraint fkLoginIDLabTests references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineLabTests default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateLabTests default getdate()

)
go

create table LabPossibleResults
(TestCode varchar(20) not null constraint fkTestCodeLabPossibleResults 
references LabTests (TestCode) on delete cascade,
PossibleResult varchar(200) not null,
constraint pkTestCodePossibleResult primary key(TestCode, PossibleResult)
)
go

create table LabTestsEXTPossibleResults
(TestCode varchar(20) constraint fkTestCodeLabTestsEXTPossibleResults references LabTests (TestCode),
SubTestCode varchar(20),
PossibleResults varchar(200), constraint pkTestCodeSubTestCodePossibleResults primary key(TestCode, SubTestCode, PossibleResults),
LoginID varchar(20) constraint fkLoginIDLabTestsEXTPossibleResults references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineLabTestsEXTPossibleResults default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeLabTestsEXTPossibleResults default getdate()
)
go

create table LabTestsEXT
(SortOrder tinyint constraint dfSortOrderLabTestsEXT default 0,
TestCode varchar(20) constraint fkTestCodeLabTestsEXT references LabTests(TestCode)
on delete cascade on update cascade,
SubTestCode varchar(20),
constraint pkTestCodeSubTestCode primary key (TestCode, SubTestCode),
SubTestName varchar(100) constraint uqTestCodeSubTestName unique(TestCode, SubTestName),
NormalRange varchar(800),
UnitMeasureID varchar(10) constraint fkUnitMeasureIDLabTestsEXT references LookupData (DataID),
ResultDataTypeID varchar(10) constraint fkResultDataTypeIDLabTestsEXT references LookupData (DataID),
Hidden bit constraint dfHiddenLabTestsEXT default 0
)
go

create table LabRequests
(SpecimenID int not null constraint dfSpecimenID default 1,
SpecimenNo varchar(20) constraint pkSpecimenNo primary key,
SpecimenDes varchar(40),
DrawnBy varchar(10) constraint fkDrawnByLabRequests references Staff (StaffNo),
VisitNo varchar(20) not null constraint fkVisitNoSpecimen references Visits(VisitNo),
DrawnDateTime smalldatetime,
LoginID varchar(20) constraint fkLoginIDLabRequests references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeLabRequests default getdate()
)
go

------------------------------------------------------------------------------------------
create table LabRequestsIPD
(SpecimenNo varchar(20) not null
constraint fkSpecimenNoLabRequestsIPD references LabRequests (SpecimenNo)
on delete cascade on update cascade constraint pkSpecimenNoLabRequestsIPD primary key,
RoundNo varchar(20) not null constraint fkRoundNoLabRequestsIPD references IPDDoctor (RoundNo)
)
go
------------------------------------------------------------------------------------------

create table LabRequestDetails
(SpecimenNo varchar(20) constraint fkSpecimenNoLabRequestDetails 
references LabRequests(SpecimenNo)on delete cascade,
TestCode varchar(20) constraint fkTestCodeLabRequestDetails references LabTests (TestCode),
constraint pkSpecimenNoTestCode primary key (SpecimenNo, TestCode),
Notes varchar(200),
LoginID varchar(20)constraint fkLoginIDLabRequestDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineLabRequestDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeLabRequestDetails default getdate()
)
go

create table LabResults
(SpecimenNo varchar(20),
TestCode varchar(20),
constraint fkSpecimenNoTestCodeLabResults foreign key (SpecimenNo, TestCode)
references LabRequestDetails (SpecimenNo, TestCode),
constraint pkSpecimenNoTestCodeLabResults primary key (SpecimenNo, TestCode),
TestDateTime smalldatetime,
Result varchar(200),
UnitMeasure varchar(100),
NormalRange varchar(800),
ResultFlagID varchar(10)constraint fkResultFlagIDLabResults references LookupData (DataID),
Report varchar(2000),
LabTechnologist varchar(10) constraint fkLabTechnologistLabResults references Staff (StaffNo),
EntryModeID varchar(10)constraint fkEntryModeIDLabResults references LookupData (DataID),
ApprovedStatusID varchar(10) constraint fkApprovedStatusIDLabResults references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDLabResults references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeLabResults default getdate()
)
go

create table LabResultsEXT
(SpecimenNo varchar(20),
TestCode varchar(20),
constraint fkSpecimenNoTestCode foreign key (SpecimenNo, TestCode)
references LabResults (SpecimenNo, TestCode) on delete cascade on update cascade,
SubTestCode varchar(20),
constraint fkTestCodeSubTestCode foreign key (TestCode, SubTestCode) references LabTestsEXT (TestCode, SubTestCode),
constraint pkSpecimenNoTestCodeSubTestCode primary key (SpecimenNo, TestCode, SubTestCode),
Result varchar(200),
UnitMeasure varchar(100),
NormalRange varchar(800),
ResultFlagID varchar(10)constraint fkResultFlagIDLabResultsEXT references LookupData (DataID),
Report varchar(2000)	
)
go

create table ApprovedLabResults
(SpecimenNo varchar(20) constraint fkSpecimenNoApprovedLabResults references LabRequests (SpecimenNo),
TestCode varchar(20),
constraint pkSpecimenNoTestCodeApprovedLabResults foreign key (SpecimenNo, TestCode)
references LabResults (SpecimenNo, TestCode) on delete cascade on update cascade,
TestName varchar(200),
LoginID varchar(20) constraint fkLoginIDApprovedLabResults references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineApprovedLabResults default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeApprovedLabResults default GetDate()
)
go

create table PathologyExaminations
(ExamID int not null constraint dfexamidPathologyexaminations default 1,
ExamCode varchar(20)constraint pkExamCodePathologyExaminations primary key,
ExamName varchar(40),
PathologyCategoriesID varchar(10)constraint fkPathologyCategoriesIDPathologyExaminations references LookupData (DataID),
UnitPrice money,
VATPercentage decimal constraint dfVATPercentagePathologyExaminations default 0,
Hidden bit constraint dfHiddenPathologyExaminations default 0,
LoginID Varchar(20)constraint fkLoginIDPathologyExaminations references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePathologyExaminations default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePathologyExaminations default getdate()
)
go

create table PathologyImages
(VisitNo varchar(20) not null references visits  on delete cascade on update cascade,
ImageName varchar(20) not null,
constraint pkVisitNoImageName primary key(VisitNo,ImageName),
PathologyImage image,
LoginID varchar(20) constraint fkLoginIDPathologyImages references Logins (LoginID)
)
go

create table PathologyReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDPathologyReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDPathologyReports primary key(VisitNo, ItemCode, ItemCategoryID),
ReportTypeID varchar(10) constraint fkReportTypeIDPathologyReports references LookupData (DataID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Diagnosis varchar(4000),
Macroscopic varchar(4000),
Microscopic  varchar(4000),
Pathologist varchar(10) constraint fkPathologistPathologyReports references Staff (staffno),
PathologyTitleID varchar(10) constraint fkPathologyTitleIDPathologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPathologyReports references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePathologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePathologyReports default getdate()
)
go

create table IPDPathologyReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDPathologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDPathologyReports primary key(RoundNo, ItemCode, ItemCategoryID),
ReportTypeID varchar(10) constraint fkReportTypeIDIPDPathologyReports references LookupData (DataID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Diagnosis varchar(4000),
Macroscopic varchar(4000),
Microscopic  varchar(4000),
Pathologist varchar(10) constraint fkPathologistIPDPathologyReports references Staff (staffNo),
PathologyTitleID varchar(10) constraint fkPathologyTitleIDIPDPathologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDIPDPathologyReports references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDPathologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDPathologyReports default getdate()
)
go

create table Examinations
(VisitNo varchar(20) not null constraint fkVisitNoExaminations references Visits (VisitNo) 
constraint pkVisitNoExaminations primary key,
ExamVisitTypeID varchar(10) constraint fkExamVisitTypeIDExaminations references LookupData (DataID),
FollowupDate smalldatetime,
DurationStartART int,
DurationCurrentART int,
OedemaID varchar(10) constraint fkOedemaIDExaminations references LookupData (DataID),
PregnancyStatusID varchar(10) constraint fkPregnancyStatusIDExaminations references LookupData (DataID),
ExpectedDeliveryDate smalldatetime,
PMTCT bit,
GestationalAge smallint,
MUACStatusID varchar(10) constraint fkMUACStatusIDExaminations references LookupData (DataID),
FPMethods varchar(200),
TBStatusID varchar(10) constraint fkTBStatusIDExaminations references LookupData (DataID),
TBRxStartDate smalldatetime,
TBRxStopDate smalldatetime,
TBRegNo varchar(20),
SideEffects varchar(200),
NewOI varchar(200),
FunctionalStatusID varchar(10) constraint fkFunctionalStatusIDExaminations references LookupData (DataID),
WHOStageID varchar(10) constraint fkWHOStageIDExaminations references LookupData (DataID),
CPTAdhereID varchar(10) constraint fkCPTAdhereIDExaminations references LookupData (DataID),
CPTDosage smallint,
CPTDuration smallint,
OtherMeds varchar(200),
NutritionalSupID varchar(10) constraint fkNutritionalSupIDExaminations references LookupData (DataID),
ARVAdhereID varchar(10) constraint fkARVAdhereIDExaminations references LookupData (DataID),
ARVAdhereWhy varchar(200),
Combination varchar(30) constraint fkCombinationExaminations references DrugCombinations (Combination),
ARVDosage smallint,
ARVDuration smallint,
CD4ABS decimal(10,2),
CD4PCT decimal(10,2),
Investigations varchar(200),
Refer varchar(40),
DaysHOSP smallint,
LoginID varchar(20) constraint fkLoginIDExaminations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeExaminations default getdate()
)
go

create table HCTClientCard
(VisitNo Varchar(20) not null constraint pkVisitNoHCTClientCard primary key 
references Visits (VisitNo)on delete cascade on update cascade,
DistrictsID varchar(10) constraint fkDistrictsIDHCTClientCard references LookupData (DataID),
HealthUnitCode varchar(10) not null constraint fkHealthUnitCodeHCTClientCard references HealthUnits (HealthUnitCode),
HSD Varchar(100),
CenterTypeID varchar(10) not null constraint fkCenterTypeIDHCTClientCard references LookupData (DataID),
TestingPointID varchar(10) not null constraint fkTestingPointIDHCTClientCard references LookupData (DataID),
AccompaniedByID Varchar(10) constraint fkAccompaniedByIDHCTClientCard references LookupData (DataID),
PreTestCounselingID Varchar(10) not null constraint fkPreTestCounselingIDHCTClientCard references LookupData (DataID),
CounseledAsID Varchar(10) constraint fkCounseledAsIDHCTClientCard references LookupData (DataID),
HCTEntryPoint Varchar(10) not null constraint fkHCTEntryPointHCTClientCard references LookupData (DataID),
MaritalStatusID Varchar(10) not null constraint fkMaritalStatusIDHCTClientCard references LookupData (DataID),
SexualPatnerNo smallint,
TestedHIVBeforeID varchar(10) not null constraint fkTestedHIVBeforeIDHCTClientCard references LookupData (DataID),
HIVTestThreeMonthsID Varchar(10) constraint fkHIVTestThreeMonthsIDHCTClientCard references LookupData (DataID),
HIVTestSixMonthsID Varchar(10) constraint fkHIVTestSixMonthsIDHCTClientCard references LookupData (DataID),
HIVTestTwelveMonthsID Varchar(10) constraint fkHIVTestTwelveMonthsIDHCTClientCard references LookupData (DataID),
ResultThreeMonthsID Varchar(10) constraint fkResultThreeMonthsIDHCTClientCard references LookupData (DataID),
ResultSixMonthsID Varchar(10) constraint fkResultSixMonthsIDHCTClientCard references LookupData (DataID),
ResultTwelveMonthsID Varchar(10) constraint fkResultTwelveMonthsIDHCTClientCard references LookupData (DataID),
NoTestsInTwelveMonthsID Varchar(10) constraint fkNoTestsInTwelveMonthsIDHCTClientCard references LookupData (DataID),
PatnerTestedHIVID Varchar(10) constraint fkPatnerTestedHIVIDHCTClientCard references LookupData (DataID),
PatnerTypeID Varchar(10) constraint fkPatnerTypeIDHCTClientCard references LookupData (DataID),
PatnerResultID Varchar(10) constraint fkPatnerResultIDHCTClientCard references LookupData (DataID),
KnowAboutServiceID Varchar(200) not null,
ConsentID Varchar(10) not null constraint fkConsentIDHCTClientCard references LookupData (DataID),
NoConsentReasonID Varchar(200),
HIVResultID Varchar(10) constraint fkHIVResultIDHCTClientCard references LookupData (DataID),
TestDoneBy Varchar(41),
Designation Varchar(20),
TestDate smalldatetime,
ResultReceivedID Varchar(10) constraint fkResultReceivedIDHCTClientCard references LookupData (DataID),
ResultReceivedAsCoupleID Varchar(10) constraint fkResultReceivedAsCoupleIDHCTClientCard references LookupData (DataID),
CoupleResultsID Varchar(10) constraint fkCoupleResultsIDHCTClientCard references LookupData (DataID),
TBSuspicionID Varchar(10) constraint fkTBSuspicionIDHCTClientCard references LookupData (DataID),
STIID Varchar(10) constraint fkSTIIDHCTClientCard references LookupData (DataID),
StartedCotrimoxazoleID Varchar(10) constraint fkStartedCotrimoxazoleIDHCTClientCard references LookupData (DataID),
LinkedToCareID Varchar(10) constraint fkLinkedToCareIDHCTClientCard references LookupData (DataID),
WhereLinkedToCareID Varchar(10) constraint fkWhereLinkedToCareIDHCTClientCard references HealthUnits (HealthUnitCode),
ReferralReason Varchar(200),
CounselorName Varchar(41),
CounselDate smalldatetime,
LoginID varchar(20) constraint fkLoginIDHCTClientCard references Logins (LoginID),
ClientMachine varchar(40),
RecordDateTime smalldatetime constraint dfRecordDateTimeHCTClientCard default getdate()
)
go

create table CardiologyExaminations
(ExamId int not null constraint dfexamidcardiologyexaminations default 1,
ExamCode varchar(20) not null constraint pkCardiologyExamCode primary key,
ExamName varchar(200) constraint uqCardiologyExamName unique,
CardiologyCategoriesID varchar(10) constraint fkCardiologyCategoriesIDCardiologyExaminations references LookupData (DataID),
CardiologySiteID varchar(10) constraint fkCardiologySiteIDCardiologyExaminations references LookupData (DataID),
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageCardiologyExaminations default 0,
Hidden bit constraint dfHiddenCardiologyExaminations default 0,

LoginID Varchar(20) constraint fkLoginIDCardiologyExaminations references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineCardiologyExaminations default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeCardiologyExaminations default getdate()

)
go

create table CardiologyReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDCardiologyReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDCardiologyReports primary key(VisitNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Report varchar(4000),
Conclusion varchar(4000),
Cardiologist varchar(10) constraint fkCardiologistCardiologyReports references Staff (StaffNo),
CardiologyTitleID varchar(10) constraint fkCardiologyTitleIDCardiologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDCardiologyReports references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineCardiologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCardiologyReports default getdate()
)
go

create table IPDCardiologyReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDCardiologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDCardiologyReports primary key(RoundNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Report varchar(4000),
Conclusion varchar(4000),
Cardiologist varchar(10) constraint fkCardiologistIPDCardiologyReports references Staff (StaffNo),
CardiologyTitleID varchar(10) constraint fkCardiologyTitleIDIPDCardiologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDIPDCardiologyReports references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDCardiologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDCardiologyReports default getdate()
)
go

create table RadiologyExaminations
(ExamID int not null constraint dfexamidradiologyexaminations default 1,
ExamCode varchar(20) not null constraint pkExamCode primary key,
ExamName varchar(40) constraint uqExamName unique,
RadiologyCategoriesID varchar(10) constraint fkRadiologyCategoriesIDRadiologyExaminations references LookupData (DataID),
RadiologySiteID varchar(10) constraint fkRadiologySiteIDRadiologyExaminations references LookupData (DataID),
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageRadiologyExaminations default 0,
Hidden bit constraint dfHiddenRadiologyExaminations default 0
)
go

create table RadiologyReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDRadiologyReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDRadiologyReports primary key(VisitNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Report varchar(4000),
Conclusion varchar(4000),
Radiologist varchar(10) constraint fkRadiologistRadiologyReports references Staff (StaffNo),
RadiologyTitleID varchar(10) constraint fkRadiologyTitleIDRadiologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDRadiologyReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeRadiologyReports default getdate()
)
go

create table IPDRadiologyReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDRadiologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDRadiologyReports primary key(RoundNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Report varchar(4000),
Conclusion varchar(4000),
Radiologist varchar(10) constraint fkRadiologistIPDRadiologyReports references Staff (StaffNo),
RadiologyTitleID varchar(10) constraint fkRadiologyTitleIDIPDRadiologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDIPDRadiologyReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDRadiologyReports default getdate()
)
go

create table DentalReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDDentalReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDDentalReports primary key(VisitNo, ItemCode, ItemCategoryID),
ReportDate smalldatetime,
Report varchar(2000),
LoginID varchar(20) constraint fkLoginIDDentalReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDentalReports default getdate()
)
go

create table IPDDentalReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDDentalReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDDentalReports primary key(RoundNo, ItemCode, ItemCategoryID),
ReportDate smalldatetime,
Report varchar(2000),
LoginID varchar(20) constraint fkLoginIDIPDDentalReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDentalReports default getdate()
)
go

create table PossibleAttachedItems
(AttachedItemCode varchar(20),
ItemCode varchar(20),
ItemCategoryID varchar(10)
constraint fkItemCategoryIDPossibleAttachedItems references LookupData (DataID), constraint pkAttachedItemCodeItemCodeItemCategoryID primary key(AttachedItemCode, ItemCode, ItemCategoryID),
Quantity int,
Notes varchar(200),
Dosage varchar(20),
Duration int,
UnitCost money,
UnitPrice money,
LoginID varchar(20) constraint fkLoginIDPossibleAttachedItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePossibleAttachedItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePossibleAttachedItems default getdate()
)
go

create table TheatreOperations
(VisitNo varchar(20) not null constraint fkVisitNoTheatreOperations 
references Visits (VisitNo) on delete cascade on update cascade
constraint pkVisitNoTheatreOperations primary key,
OperationDateTime smalldatetime,
LeadSurgeon varchar(10) constraint fkLeadSurgeonTheatreOperations references Staff (StaffNo),
OtherSurgeon varchar(200),
LeadAnaesthetist varchar(10) constraint fkLeadAnaesthetistTheatreOperations references Staff (StaffNo),
OtherAnaesthetist varchar(200),
LeadNurse varchar(10) constraint fkLeadNurseTheatreOperations references Staff (StaffNo),
OtherNurse varchar(200),
AnaesthesiaTypeID varchar(10) constraint fkAnaesthesiaTypeIDTheatreOperations references LookupData (DataID),
OperationClassID varchar(10) constraint fkOperationClassIDTheatreOperations references LookupData (DataID),
PreoperativeDiagnosis varchar(2000),
PlannedProcedures varchar(2000),
Report varchar(2000),
PostoperativeInstructions varchar(2000),
LoginID varchar(20) constraint fkLoginIDTheatreOperations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeTheatreOperations default getdate()
)
go

create table IPDTheatreOperations
(RoundNo varchar(20) not null constraint fkRoundNoIPDTheatreOperations 
references IPDDoctor (RoundNo) on delete cascade on update cascade
constraint pkRoundNoIPDTheatreOperations primary key,
OperationDateTime smalldatetime,
LeadSurgeon varchar(10) constraint fkLeadSurgeonIPDTheatreOperations references Staff (StaffNo),
OtherSurgeon varchar(200),
LeadAnaesthetist varchar(10) constraint fkLeadAnaesthetistIPDTheatreOperations references Staff (StaffNo),
OtherAnaesthetist varchar(200),
LeadNurse varchar(10) constraint fkLeadNurseIPDTheatreOperations references Staff (StaffNo),
OtherNurse varchar(200),
AnaesthesiaTypeID varchar(10) constraint fkAnaesthesiaTypeIDIPDTheatreOperations references LookupData (DataID),
OperationClassID varchar(10) constraint fkOperationClassIDIPDTheatreOperations references LookupData (DataID),
PreoperativeDiagnosis varchar(2000),
PlannedProcedures varchar(2000),
Report varchar(2000),
PostoperativeInstructions varchar(2000),
LoginID varchar(20) constraint fkLoginIDIPDTheatreOperations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDTheatreOperations default getdate()
)
go

create table IPDNurse
(IPDNurseRoundID int not null constraint dfIPDNurseRoundIDIPDNurse default 1,
NurseRoundNo varchar(20) not null constraint pkNurseRoundNoIPDNurse primary key,
RoundNo varchar(20) not null constraint fkRoundNoIPDNurse  references IPDDoctor (RoundNo)on delete cascade on update cascade,
Weight decimal(5,2) constraint ckWeightIPDNurse check (Weight > 0 and Weight <= 200),
Temperature decimal(5,2) constraint ckTemperatureIPDNurse check (Temperature > 30 and Temperature < 50),
Height decimal(5,2) constraint ckHeightIPDNurse check (Height > 40 and Height < 300),
Pulse tinyint constraint ckPulseIPDNurse check (Pulse > 10 and Pulse <= 300),
BloodPressure varchar(10),
HeadCircum decimal(5,2) constraint ckHeadCircumIPDNurse check (HeadCircum > 20 and HeadCircum < 150),
BodySurfaceArea decimal(10,2),
RespirationRate tinyint constraint ckRespirationRateIPDNurse check (RespirationRate > 10 and RespirationRate < 150),
OxygenSaturation decimal(5,2) constraint ckOxygenSaturationIPDNurse check (OxygenSaturation > 0 and OxygenSaturation <= 100),
HeartRate tinyint constraint ckHeartRateIPDNurse check (HeartRate > 0 and HeartRate <= 250),
Notes varchar(4000),
NurseRoundDateTime smalldatetime,
StaffNo varchar(10) constraint fkStaffNoIPDNurse references Staff (StaffNo),
OtherAttendingNurse varchar(100),
LoginID varchar(20) constraint fkLoginIDIPDNurse references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDNurse default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDNurse default getdate()
)
go

create table IPDNursingPlan
(RoundNo Varchar(20)not null constraint pkRoundNoIPDNursingPlan primary key
constraint fkRoundNoIPDNursingPlan references IPDNurse (NurseRoundNo)
on delete cascade on update cascade,
ExpectedOutcome Varchar(1000),
NursingActions Varchar(1000),
Implementation Varchar(1000),
LoginID Varchar(20)
constraint fkLoginIDIPDNursingPlan references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDNursingPlan default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeIPDNursingPlan default getdate()
)
go

create table IPDNurseEvaluation
(RoundNo Varchar(20)not null constraint pkRoundNoIPDNurseEvaluation primary key
constraint fkRoundNoIPDNurseEvaluation references IPDNurse (NurseRoundNo)
on delete cascade on update cascade,
NursingCareEffective Varchar(10) constraint fkNursingCareEffectiveIPDNurseEvaluation references LookupData (DataID),
ProposedModifications Varchar(1000),
EvaluationNotes Varchar(1000),
LoginID Varchar(20) constraint fkLoginIDIPDNurseEvaluation references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDNurseEvaluation default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeIPDNurseEvaluation default getdate()
)
go

create table IPDNurseAssessment
(RoundNo Varchar(20)not null constraint pkRoundNoIPDNurseAssessment primary key constraint fkRoundNoIPDNurseAssessment references IPDNurse (NurseRoundNo)
on delete cascade on update cascade,
Complaint Varchar(1000),
Etiology Varchar(1000),
SignsAndSymptoms Varchar(1000),
ProposedSolution Varchar(1000),
LoginID Varchar(20) constraint fkLoginIDIPDNurseAssessment references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDNurseAssessment  default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeIPDNurseAssessment  default getdate()
)
go

create table IPDDrugAdministration
(NurseRoundNo varchar(20) constraint fkNurseRoundNoIPDDrugAdministration references IPDNurse (NurseRoundNo) On delete cascade on update cascade,
TakenDateTime smalldatetime,
ItemCode varchar(20) not null
constraint pkNurseRoundNoTakenDateTimeItemCodeIPDDrugAdministration primary key(NurseRoundNo, TakenDateTime,ItemCode),
ItemCategoryID varchar(10) constraint fkItemCategoryIPDDrugAdministration references LookupData (DataID),
ItemName varchar(800) not null,constraint uqNurseRoundNoTakenDateTimeItemNameIPDDrugAdministration unique(NurseRoundNo, TakenDateTime, ItemName),
QuantityTaken int,
StaffNo varchar(10) constraint fkStaffNoIPDDrugAdministration references Staff (StaffNo),
NurseNotes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDDrugAdministration references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDDrugAdministration default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDrugAdministration default getdate()
)
go

create table IPDNurseFluids
(NurseRoundNo varchar(20) constraint fkNurseRoundNoIPDNurseFluids references IPDNurse (NurseRoundNo) On delete cascade on update cascade,
TakenDateTime smalldatetime,
FluidTypeID varchar(10) constraint fkFluidTypeIDIPDNurseFluids references LookupData (DataID),constraint pkNurseRoundNoFluidTypeIDFluidCategoryIDIPDNurseFluids primary key(NurseRoundNo, FluidTypeID, FluidCategoryID),
FluidCategoryID varchar(10) constraint fkFluidCategoryIDIPDNurseFluids references LookupData (DataID),
RouteID varchar(10)  constraint fkRouteIDIPDNurseFluids references LookupData (DataID),constraint uqNurseRoundNoFluidTypeIDFluidCategoryIDIPDNurseFluids unique(NurseRoundNo, FluidTypeID,FluidCategoryID),
Quantity int,
NurseNotes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDNurseFluids references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDNurseFluids default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDNurseFluids default getdate()
)
go

create table ExtraChargeItems
(ExtraItemID int not null constraint dfextraitemidextrachargeitems default 1,
ExtraItemCode varchar(20) not null constraint pkExtraItemCode primary key,
ExtraItemName varchar(40) constraint uqExtraItemName unique,
ExtraChargeCategoryID varchar(10) constraint fkExtraChargeCategoryIDExtraChargeItems references LookupData (DataID),
RevenueStreamCode varchar(20),
UnitCost money constraint dfUnitCostExtraChargeItems default 0,
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageExtraChargeItems default 0,
Hidden bit constraint dfHiddenExtraChargeItems default 0
)
go

create table Appointments
(PatientNo varchar(20) constraint fkPatientNoAppointments references Patients(PatientNo),
StartDate smalldatetime 
constraint pkPatientNoStartDate primary key (PatientNo, StartDate),
AppointmentPrecisionID varchar(10) constraint fkAppointmentPrecisionIDAppointments references LookupData (DataID),
StartTime varchar(8),
Duration smallint ,
EndDate smalldatetime ,
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDAppointments references LookupData (DataID),
StaffNo varchar(10) constraint fkStaffNoAppointments references Staff (StaffNo) ,
AppointmentCategoryID varchar(10) constraint fkAppointmentCategoryIDAppointments references LookupData (DataID),
CommunityID varchar(10) constraint fkCommunityAppointments references LookupData (DataID),
AppointmentDes varchar(100) ,
AppointmentStatusID varchar(10) constraint fkAppointmentStatusAppointments references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDAppointments references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeAppointments default getdate()
)
go

create table ExtraBills
(ExtraBillID int not null constraint dfExtraBillIDExtraBills default 1,
ExtraBillNo varchar(20) not null constraint pkExtraBillNo primary key,
VisitNo varchar(20) constraint fkVisitNoExtraBills references Visits (VisitNo),
ExtraBillDate smalldatetime,
StaffNo varchar(10) constraint fkStaffNoExtraBills references Staff (StaffNo),
LoginID varchar(20) constraint fkLoginIDExtraBills references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBills default getdate()
)
go

create table ExtraBillsEXT
(ExtraBillNo varchar(20) not null constraint fkExtraBillNoExtraBillsEXT 
references ExtraBills (ExtraBillNo) constraint pkExtraBillNoExtraBillsEXT primary key,
RoundNo varchar(20) not null constraint uqRoundNo unique
constraint fkRoundNoExtraBillsEXT references IPDDoctor (RoundNo)
on delete cascade on update cascade 
)
go

create table ExtraBillItems
(ExtraBillNo varchar(20) not null constraint fkExtraBillNoExtraBillItems 
references ExtraBills (ExtraBillNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDExtraBillItems references LookupData (DataID),
constraint pkExtraBillNoItemCodeItemCategoryID primary key(ExtraBillNo, ItemCode, ItemCategoryID),
ItemName varchar(800) not null, constraint uqExtraBillNoItemCategoryIDItemCodeItems 
unique(ExtraBillNo, ItemCategoryID, ItemCode),
UnitMeasure varchar(100),
InvoiceNo varchar(20),
Quantity int,
UnitCost money constraint dfUnitCostExtraBillItems default 0,
UnitPrice money,
VATValue money,
Notes varchar(200),
LastUpdate smalldatetime,
PayStatusID varchar(10) constraint fkPayStatusIDExtraBillItems references LookupData (DataID),
EntryModeID varchar(10) constraint fkEntryModeIDExtraBillItems references LookupData (DataID),
OriginalQuantity int,
OriginalPrice money,
ReturnQuantity int,
ReturnAmount money,
LoginID varchar(20) constraint fkLoginIDExtraBillItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineExtraBillItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBillItems default getdate(),
CreatorLoginID varchar(20) constraint fkCreatorLoginIDExtraBillItems references Logins (LoginID),
CreatorClientMachine varchar(40) constraint dfCreatorClientMachineExtraBillItems default host_name()
)
go

create table ExtraBillItemsCASH
(ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkExtraBillNoItemCodeItemCategoryIDExtraBillItemsCASH foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkExtraBillNoItemCodeItemCategoryIDExtraBillItemsCASH primary key(ExtraBillNo, ItemCode, ItemCategoryID),
InvoiceNo varchar(20) not null constraint dfInvoiceNoExtraBillItemsCASH default '',
CashAmount money constraint dfCashAmountExtraBillItemsCASH default 0,
CashPayStatusID varchar(10) constraint fkCashPayStatusIDExtraBillItemsCASH references LookupData (DataID)
)
go


create table BillAdjustments
(AdjustmentID int not null constraint dfAdjustmentIDBillAdjustments default 1,
AdjustmentNo varchar(20) not null
constraint pkAdjustmentNo primary key,
BillNo varchar(20),
AdjustmentDate smalldatetime,
VisitTypeID varchar(10)
constraint fkVisitTypeIDBillAdjustments references LookupData (DataID),
AdjustmentTypeID varchar(10)
constraint fkAdjustmentTypeIDBillAdjustments references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDBillAdjustments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineBillAdjustments default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBillAdjustments default getdate()
)
go

create table ItemAdjustments
(AdjustmentNo varchar(20) not null
constraint fkAdjustmentNoItemAdjustments references BillAdjustments (AdjustmentNo),
VisitNo varchar(20) not null
constraint fkVisitNoItemAdjustments references Visits (VisitNo),
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null
constraint fkItemCategoryIDItemAdjustments references LookupData (DataID),
constraint pkAdjustmentNoVisitNoItemCodeItemCategoryID primary key(AdjustmentNo, VisitNo, ItemCode, ItemCategoryID),
ReturnDate smalldatetime,
Quantity int,
Notes varchar(200),
Amount money,
Acknowledgeable bit constraint dfAcknowledgeableItemAdjustments default 0,
IsAcknowledged bit constraint dfIsAcknowledgedItemAdjustments default 0,
EntryLevelID varchar(10) constraint fkEntryLevelIDItemAdjustments references LookupData(DataID),
TransactionDate smalldatetime  constraint fkTransactionDateItemAdjustments default getdate(),
LoginID varchar(20) constraint fkLoginIDItemAdjustments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineItemAdjustments default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeItemAdjustments default getdate()
)
go

create table ExtraBillItemAdjustments
(AdjustmentNo varchar(20) not null
constraint fkAdjustmentNoExtraBillItemAdjustments references BillAdjustments (AdjustmentNo),
ExtraBillNo varchar(20) not null
constraint fkExtraBillNoExtraBillItemAdjustments references ExtraBills (ExtraBillNo),
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null
constraint fkItemCategoryIDExtraBillItemAdjustments references LookupData (DataID),
constraint fkExtraBillNoItemCodeItemCategoryIDExtraBillItemAdjustments foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkAdjustmentNoExtraBillNoItemCodeItemCategoryID primary key(AdjustmentNo, ExtraBillNo, ItemCode, ItemCategoryID),
Quantity int,
Notes varchar(200),
Amount money constraint dfAmountExtraBillItemAdjustments default 0,
EntryLevelID varchar(10) constraint fkEntryLevelIDExtraBillItemAdjustments references LookupData(DataID),
TransactionDate smalldatetime  constraint fkTransactionDateReturnedExtrabillItems default getdate(),
Acknowledgeable bit constraint dfAcknowledgeableExtraBillItemAdjustments default 0,
IsAcknowledged bit constraint dfIsAcknowledgedExtraBillItemAdjustments default 0,
LoginID varchar(20)
constraint fkLoginIDExtraBillItemAdjustments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineExtraBillItemAdjustments default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBillItemAdjustments default getdate()
)
go

create table PaymentVouchers
(VoucherID int not null constraint dfVoucherID default 1,
VoucherNo varchar(20) constraint pkVoucherNo primary key,
PayTypeID varchar(10) constraint fkPayTypeIDPaymentVouchers references LookupData (DataID),
BillNo varchar(20),
PayDate smallDateTime,
PayModesID varchar(10) constraint fkPayModesIDPaymentVouchers references LookupData (DataID),
DocumentNo varchar(20),
AmountWords varchar(200),
Notes varchar(200),
CurrenciesID varchar(10) constraint fkCurrenciesIDPaymentVouchers references LookupData (DataID),
AmountTendered Money,
ExchangeRate money,
Change Money,
SendBalanceToAccount bit constraint dfSendBalanceToAccountPaymentVouchers default 0,
UseAccountBalance bit constraint dfUseAccountBalancePaymentVouchers default 0,
VoucherTypeID varchar(10) constraint fkVoucherTypeIDPaymentVouchers references LookupData (DataID),
PayNo varchar(20),
FilterNo varchar(20),
Payee varchar(200),
LoginID varchar(20) constraint fkLoginIDPaymentVouchers references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachinePaymentVouchers default Host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePaymentVouchers default GetDate()
)
go

create table PaymentVoucherDetails
(VoucherNo varchar(20) constraint fkVoucherNoPaymentVoucherDetails references PaymentVouchers (VoucherNo),
BillNo varchar(20),
ItemCode varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDPaymentVoucherDetails references LookupData (DataID),
constraint pkVoucherNoBillNoItemCodeItemCategoryID primary key(VoucherNo, BillNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money,
Discount money,
Amount money,
LoginID Varchar(20) constraint fkLoginIDPaymentVoucherDetails references Logins (LoginID),
ClientMachine Varchar(41) constraint dfClientMachinePaymentVoucherDetails default Host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePaymentVoucherDetails default GetDate()
)
go

create table PaymentExtraBillItems
(ReceiptNo varchar(20) not null constraint fkReceiptNoPaymentExtraBillItems references Payments(ReceiptNo)
on delete cascade on update cascade,
ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDPaymentExtraBillItems references LookupData (DataID),
constraint fkExtraBillNoItemCodeItemCategoryIDPaymentExtraBillItems foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkReceiptNoExtraBillNoItemCodeItemCategoryID primary key (ReceiptNo, ExtraBillNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money ,
Discount money ,
Amount money,
SyncStatus bit constraint dfSyncStatusPaymentExtraBillItems default 0
)
go

create table RefundRequestExtraBillItems
(RefundRequestNo varchar(20) not null
constraint fkRefundRequestNoRefundRequestExtraBillItems references RefundRequests (RefundRequestNo),
ExtraBillNo varchar(20) not null,
ReceiptNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10)
constraint fkItemCategoryIDRefundRequestExtraBillItems references LookupData (DataID),
constraint pkRefundRequestNoExtraBillNoReceiptNoItemCodeItemCategoryID primary key(RefundRequestNo, ExtraBillNo, ReceiptNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundRequestExtraBillItems references LookupData (DataID),
Quantity int,
Amount money,
NewPrice money,
LoginID varchar(20)
constraint fkLoginIDRefundRequestExtraBillItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundRequestExtraBillItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundRequestExtraBillItems default getdate()
)


create table RefundExtraBillItems
(RefundNo varchar(20) not null
constraint fkRefundNoRefundExtraBillItems references Refunds (RefundNo),
ExtraBillNo varchar(20) not null,
ReceiptNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10)
constraint fkItemCategoryIDRefundExtraBillItems references LookupData (DataID),
constraint fkReceiptNoExtraBillNoItemCodeItemCategoryIDRefundExtraBillItems foreign key (ReceiptNo, ExtraBillNo, ItemCode, ItemCategoryID)
references PaymentExtraBillItems (ReceiptNo, ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkRefundNoExtraBillNoReceiptNoItemCodeItemCategoryID primary key(RefundNo, ExtraBillNo, ReceiptNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundExtraBillItems references LookupData (DataID),
Quantity int,
Amount money,
LoginID varchar(20)
constraint fkLoginIDRefundExtraBillItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundExtraBillItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundExtraBillItems default getdate()
)
go


create table InvoiceExtraBillItems
(InvoiceNo varchar(20) not null constraint fkInvoiceNoInvoiceExtraBillItems references Invoices(InvoiceNo)
on delete cascade on update cascade,
ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInvoiceExtraBillItems references LookupData (DataID),
constraint fkExtraBillNoItemCodeItemCategoryIDInvoiceExtraBillItems foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkInvoiceNoExtraBillNoItemCodeItemCategoryID primary key (InvoiceNo, ExtraBillNo, ItemCode, ItemCategoryID),
ObjectName varchar(40) constraint fkObjectNameInvoiceExtraBillItems references AccessObjects (ObjectName)
constraint ckObjectNameInvoiceExtraBillItems check (ObjectName in ('Items', 'ItemsCASH', 'ExtraBillItems', 'ExtraBillItemsCASH')),
Quantity int,
UnitPrice money ,
Discount money ,
Amount money
)
go


create table InvoiceAdjustments
(AdjustmentID int not null constraint dfAdjustmentIDInvoiceAdjustments default 1,
AdjustmentNo varchar(20) not null
constraint pkAdjustmentNoInvoiceAdjustments primary key,
InvoiceNo varchar(20)
constraint fkInvoiceNoInvoiceAdjustments references Invoices (InvoiceNo),
VisitTypeID varchar(10)
constraint fkVisitTypeIDInvoiceAdjustments references LookupData (DataID),
EntryLevelID varchar(10)
constraint fkEntryLevelIDInvoiceAdjustments references LookupData (DataID),
AdjustmentTypeID varchar(10)
constraint fkAdjustmentTypeIDInvoiceAdjustments references LookupData (DataID),
ReversalActionID varchar(10) constraint fkReversalActionIDInvoiceAdjustemnts references LookupData(DataID),
Amount money,
AdjustmentDate smalldatetime,
LoginID varchar(20)
constraint fkLoginIDInvoiceAdjustments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInvoiceAdjustments default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInvoiceAdjustments default getdate()
)
go

create table InvoiceDetailAdjustments
(AdjustmentNo varchar(20)
constraint fkAdjustmentNoInvoiceDetailAdjustments references InvoiceAdjustments (AdjustmentNo),
VisitNo varchar(20) not null,
InvoiceNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkIVisitNoInvoiceNoItemCodeItemCategoryIDInvoiceDetailAdjustments foreign key (InvoiceNo, VisitNo, ItemCode, ItemCategoryID) 
references InvoiceDetails (InvoiceNo, VisitNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkAdjustmentNoVisitNoInvoiceNoItemCodeItemCategoryID primary key(AdjustmentNo, VisitNo, InvoiceNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDInvoiceDetailAdjustments references LookupData (DataID),
Quantity int,
Amount money,
LoginID varchar(20)
constraint fkLoginIDInvoiceDetailAdjustments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInvoiceDetailAdjustments default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInvoiceDetailAdjustments default getdate()
)
go

create table InvoiceExtraBillItemAdjustments
(AdjustmentNo varchar(20) not null
constraint fkAdjustmentNoInvoiceExtraBillItemAdjustments references InvoiceAdjustments (AdjustmentNo),
ExtraBillNo varchar(20) not null,
InvoiceNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkExtraBillNoInvoiceNoItemCodeItemCategoryIDExtraBillItemAdjustments foreign key (InvoiceNo, ExtraBillNo, ItemCode, ItemCategoryID)
references InvoiceExtraBillItems (InvoiceNo, ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkAdjustmentNoExtraBillNoInvoiceNoItemCodeItemCategoryID primary key(AdjustmentNo, ExtraBillNo, InvoiceNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDInvoiceExtraBillItemAdjustments references LookupData (DataID),
Quantity int,
Amount money,
LoginID varchar(20)
constraint fkLoginIDInvoiceExtraBillItemAdjustments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInvoiceExtraBillItemAdjustments default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInvoiceExtraBillItemAdjustments default getdate()
)
go


create table ExtraBillItemsINT
(ExtraBillNo varchar(20) constraint fkExtraBillNoExtraBillItemsINT references ExtraBills (ExtraBillNo),
Agent varchar(20),
ItemCategoryID varchar(10) constraint dfItemCategoryIDExtraBillItemsINT default 0,
ItemCode varchar(20), constraint pkExtraBillNoAgentItemCategoryIDItemCode 
primary key(ExtraBillNo, Agent, ItemCategoryID, ItemCode),
SyncStatus bit,
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBillItemsINT default getdate()
)
go

create table ExtraBillsINT
(ExtraBillNo varchar(20) constraint pkExtraBills primary key,
SyncStatus varchar(20),
AgentID varchar(20),
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBillsINT default getdate()
)
go

create table Claims
(ClaimID int not null constraint dfClaimIDClaims default 1,
ClaimNo varchar(20) not null constraint pkClaimNo primary key,
MedicalCardNo varchar(20) constraint fkMedicalCardNoClaims references SchemeMembers (MedicalCardNo),
PatientNo varchar(20),
VisitDate smalldatetime,
VisitTime varchar(8),
HealthUnitCode varchar(10) null constraint fkHealthUnitCodeClaims references HealthUnits (HealthUnitCode),
PrimaryDoctor varchar(41),
ClaimStatusID varchar(10) constraint fkClaimStatusIDClaims references LookupData (DataID),
ClaimEntryID varchar(10) constraint fkClaimEntryIDClaims references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDClaims references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeClaims default getdate()
)
go


create table ClaimPayments
(ClaimNo varchar(20) not null
constraint fkClaimNoClaimPayments references Claims (ClaimNo)
constraint pkClaimNoClaimPayments primary key,
PayStatusID varchar(10)
constraint fkPayStatusIDClaimPayments references LookupData (DataID),
PaymentDateTime smallDatetime, 
constraint uqClaimNoPayStatusIDPaymentDateTime unique(ClaimNo, PayStatusID, PaymentDateTime),
LoginID varchar(20)
constraint fkLoginIDClaimPayments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineClaimPayments default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeClaimPayments default getdate(),
) 
go


create table ClaimsEXT
(ClaimNo varchar(20) not null constraint fkClaimNoClaimsEXT references Claims (ClaimNo)
on delete cascade on update cascade constraint pkClaimNoClaimsEXT primary key,
VisitNo varchar(20) not null constraint uqVisitNo unique
constraint fkVisitNoClaimsEXT references Visits (VisitNo) 
on delete cascade on update cascade 
)
go

create table ClaimDiagnosis
(ClaimNo varchar(20) not null constraint fkClaimNoClaimDiagnosis 
references Claims (ClaimNo) on delete cascade on update cascade,
DiseaseCode varchar(10) not null constraint fkDiseaseCodeClaimDiagnosis references Diseases (DiseaseCode),
constraint pkClaimNoDiseaseCode primary key(ClaimNo, DiseaseCode)
)
go

create table ClaimDetails
(ClaimNo varchar(20) not null constraint fkClaimNoClaimDetails 
references Claims (ClaimNo) on delete cascade on update cascade,
ItemName varchar(100) not null,
constraint pkClaimNoItemName primary key(ClaimNo, ItemName),
BenefitCode varchar(20) constraint fkBenefitCodeClaimDetails references MemberBenefits (BenefitCode),
Quantity int,
UnitPrice money,
Adjustment money,
Amount money,
Notes varchar(400),
LimitAmount money constraint dfLimitAmountClaimDetails default 0,
ConsumedAmount money constraint dfConsumedAmountClaimDetails default 0,
LimitBalance money constraint dfLimitBalanceClaimDetails default 0
)
go

create table Allergies
(AllergyNo varchar(20) not null constraint pkAllergyNo primary key,
AllergyName varchar(60) constraint uqAllergyName unique,
AllergyCategoryID varchar(10) constraint fkAllergyCategoryIDAllergies references LookupData (DataID)
)
go

create table AllergyDrugs
(AllergyNo varchar(20) not null 
constraint fkAllergyNoAllergyDrugs references Allergies (AllergyNo) on delete cascade on update cascade,
DrugNo varchar(20) not null 
constraint fkDrugNoAllergyDrugs references Drugs (DrugNo) on delete cascade on update cascade,
constraint pkAllergyNoDrugNo primary key(AllergyNo, DrugNo)
)
go

create table PatientAllergies
(PatientNo varchar(20) not null
constraint fkPatientNoPatientAllergies references Patients (PatientNo) on delete cascade on update cascade,
AllergyNo varchar(20) not null constraint fkAllergyNoPatientAllergies references Allergies (AllergyNo),
constraint pkPatientNoAllergyNo primary key(PatientNo, AllergyNo),
Reaction varchar(200)
)
go

----------------------------------------------------------------------------------------------------------

create table FamilyMembers
(PatientNo varchar(20) not null constraint fkPatientNoFamilyMembers references Patients (PatientNo)
on delete cascade on update cascade,
MemberName varchar(41) not null,
constraint pkPatientNoMemberName primary key(PatientNo, MemberName),
Age tinyint,
HIVStatusID varchar(10) constraint fkHIVStatusIDFamilyMembers references LookupData (DataID),
HIVCareID varchar(10) constraint fkHIVCareIDFamilyMembers references LookupData (DataID),
UniqueNo varchar(20)
)
go

create table ExposedInfants
(PatientNo varchar(20) not null constraint fkPatientNoExposedInfants references Patients (PatientNo) 
on delete cascade on update cascade,
InfantName varchar(41) not null,
constraint pkPatientNoInfantName primary key(PatientNo, InfantName),
BirthDate smalldatetime,
InfantFeedingID varchar(10) constraint fkInfantFeedingIDExposedInfants references LookupData (DataID),
CTXStarted varchar(41),
HIVTestTypeID varchar(10) constraint fkHIVTestTypeIDExposedInfants references LookupData (DataID),
TestResultsID varchar(10) constraint fkTestResultsIDExposedInfants references LookupData (DataID),
InfantStatusID varchar(10) constraint fkInfantStatusIDExposedInfants references LookupData (DataID),
UniqueNo varchar(20)
)
go

create table PriorARTDetails
(PatientNo varchar(20) not null constraint fkPatientNoPriorARTDetails references Patients (PatientNo)
on delete cascade on update cascade,
PriorARTID varchar(10) constraint fkPriorARTIDPriorARTDetails references LookupData (DataID),
constraint pkPatientNoPriorARTID primary key(PatientNo, PriorARTID),
ARTDate smalldatetime,
ARTWhere varchar(41),
Combination varchar(30) constraint fkCombinationPriorARTDetails references DrugCombinations (Combination)
)
go

----------------------------------------------------------------------------------------------------------
create table PurchaseOrders
(PurchaseOrderID int not null constraint dfPurchaseOrderIDPurchaseOrders default 1,
PurchaseOrderNo varchar(20) not null constraint pkPurchaseOrderNoPurchaseOrders primary key,
OrderDate smalldatetime,
DocumentNo varchar(20),
SupplierNo varchar(20) constraint fkSupplierNoPurchaseOrders references Suppliers (SupplierNo),
ShipAddress varchar(300),
LoginID varchar(20) constraint fkLoginIDPurchaseOrders references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePurchaseOrders default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePurchaseOrders default getdate()
)
go

create table PurchaseOrderDetails
(PurchaseOrderNo varchar(20) not null constraint fkPurchaseOrderNoPurchaseOrderDetails 
references PurchaseOrders (PurchaseOrderNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDPurchaseOrderDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkPurchaseOrderNoItemCategoryIDItemCodePurchaseOrderDetails primary key(PurchaseOrderNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqPurchaseOrderNoItemCategoryIDItemName unique(PurchaseOrderNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
ItemGroup varchar(100),
PackID varchar(10) not null constraint fkPackIDPurchaseOrderDetails references LookupData (DataID),
PackSize int constraint dfPackSizePurchaseOrderDetails default 1,
Quantity int,
Rate money,
Amount money,
VATValue money constraint dfVATValuePurchaseOrderDetails default 0,
Notes varchar(200),
StockStatusID varchar(10) constraint fkStockStatusIDPurchaseOrderDetails references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDPurchaseOrderDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePurchaseOrderDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePurchaseOrderDetails default getdate()
)
go

create table GoodsReceivedNote
(GRNID int not null constraint dfGRNIDGoodsReceivedNote default 1,
GRNNo varchar(20) not null constraint pkGRNNoGoodsReceivedNote primary key,
PurchaseOrderNo varchar(20) constraint fkPurchaseOrderNoGoodsReceivedNote references PurchaseOrders (PurchaseOrderNo),
ReceivedDate smalldatetime,
AdviceNoteNo varchar(20),
DeliveryLocationID varchar(10) constraint fkDeliveryLocationIDGoodsReceivedNote references LookupData (DataID),
DiscountTotal money constraint dfDiscountTotalGoodsReceivedNote default 0, 
TotalVAT money constraint dfTotalVATGoodsReceivedNote default 0,
AmountWords varchar(200),
LoginID varchar(20) constraint fkLoginIDGoodsReceivedNote references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineGoodsReceivedNote default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeGoodsReceivedNote default getdate()
)
go

create table GoodsReceivedNoteDetails
(GRNNo varchar(20) not null constraint fkGRNNoGoodsReceivedNoteDetails 
references GoodsReceivedNote (GRNNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDGoodsReceivedNoteDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkGRNNoItemCategoryIDItemCodeGoodsReceivedNoteDetails primary key(GRNNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqGRNNoItemCategoryIDItemName unique(GRNNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
OrderedQuantity int,
PackID varchar(10) not null constraint fkPackIDGoodsReceivedNoteDetails references LookupData (DataID),
PackSize int constraint dfPackSizeGoodsReceivedNoteDetails default 1,
ReceivedQuantity int,
BonusQuantity int,
Rate money,
Discount money constraint dfDiscountGoodsReceivedNoteDetails default 0,
VATValue money constraint dfVATValueGoodsReceivedNoteDetails default 0,
VATPercentage decimal,
Amount money,
BatchNo varchar(20),
ExpiryDate smalldatetime,
Notes varchar(100),
PayStatusID varchar(10) constraint fkPayStatusIDGoodsReceivedNoteDetails references LookupData (DataID),
SyncStatus bit constraint dfSyncStatusGoodsReceivedNoteDetails default 0,
LoginID varchar(20)constraint fkLoginIDGoodsReceivedNoteDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineGoodsReceivedNoteDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeGoodsReceivedNoteDetails default getdate()
)
go

create table GoodsReturnedNote
(ReturnID int,
ReturnNo varchar(20) constraint pkReturnNoGoodsReturnedNote primary key,
GRNNo varchar(20) constraint fkGRNNoGoodsReturnedNote references GoodsReceivedNote (GRNNo) on delete cascade on update cascade,
ReturnDate smalldatetime,
AmountWords varchar(200),
Notes varchar(100),
LoginID varchar(20) constraint fkLoginIDGoodsReturnedNote references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineGoodsReturnedNote default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateGoodsReturnedNote default getdate()
)
go

create table GoodsReturnedNoteDetails
(ReturnNo varchar(20) not null constraint fkReturnNoGoodsReturnedNoteDetails references GoodsReturnedNote (ReturnNo) on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDGoodsReturnedNoteDetails references LookupData (DataID),
ItemCode varchar(20) not null, constraint pkReturnNoItemCategoryIDItemCode primary key(ReturnNo, ItemCategoryID, ItemCode),
ItemName varchar(800),
ReturnQuantity Int,
GoodsReturnReasonID varchar(10) constraint fkGoodsReturnReasonIDGoodsReturnedNoteDetails references LookupData (DataID),
SysncStatus bit constraint dfSysncStatusGoodsGoodsReturnedNoteDetails default 0,
LoginID varchar(20) constraint fkLoginIDGoodsReturnedNoteDetails references Logins (LoginID),
ClientMachine varchar(20) constraint dfClientMachineGoodsReturnedNoteDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeGoodsReturnedNoteDetails default getdate()
)
go

create table Inventory
(TranID	int not null identity (1,1) constraint pkTranID primary key,
LocationID varchar(10) not null constraint fkLocationIDInventory references LookupData (DataID),
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInventory references LookupData (DataID),
ItemCode varchar(20) not null, ---- DrungNo, ConsumableNo etc ...
TranDate smalldatetime,
StockTypeID varchar(10) constraint fkStockTypeIDInventory references LookupData (DataID),
Quantity int,
LocationUnits int,
Balance	int,
UnitCost money,
WeightedCostAverage money,
BranchID varchar(10) constraint fkBranchIDInventory references LookupData (DataID),
Details	varchar(100),
EntryModeID varchar(10) constraint fkEntryModeIDInventory references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDInventory references Logins (LoginID) on delete cascade,
ClientMachine varchar(40) constraint dfClientMachineInventory default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventory default getdate()
)
go

create table InventoryINT
(TranID int not null,
ShipStatus bit,
Agent varchar(20),
constraint pkTranIDAgent primary key(TranID, Agent),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryINT default getdate()
)
go

create table InventoryReceiving
(TranID int not null constraint fkTranIDInventoryReceiving references Inventory (TranID)
on delete cascade on update cascade constraint pkTranIDInventoryReceiving primary key,
BatchNo varchar(20),
ExpiryDate smalldatetime
)
go

create table InventoryLocation
(LocationID varchar(10) not null constraint fkLocationIDInventoryLocation references LookupData (DataID),
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInventoryLocation references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkLocationIDItemCategoryIDItemCode primary key(LocationID, ItemCategoryID, ItemCode),
UnitsAtHand int,
BatchNo varchar(20),
ExpiryDate smalldatetime
)
go

create table InventoryOrders
(OrderID int not null constraint dfOrderIDInventoryOrders default 1,
OrderNo varchar(20) not null constraint pkOrderNoInventoryOrders primary key,
OrderDate smalldatetime,
OrderTypeID varchar(10),
StockCost money,
FromLocationID varchar(10) constraint fkFromLocationIDInventoryOrders references LookupData (DataID),
ToLocationID varchar(10) constraint fkToLocationIDInventoryOrders references LookupData (DataID),
TransferReasonID varchar(10) constraint fkTransferReasonIDInventoryOrders references Lookupdata (DataID),
LoginID varchar(20)constraint fkLoginIDInventoryOrders references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryOrders default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryOrders default getdate()
)
go

create table InventoryOrderDetails
(OrderNo varchar(20) not null constraint fkOrderNoInventoryOrderDetails 
references InventoryOrders (OrderNo)on delete cascade on update cascade, 
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInventoryOrderDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkOrderNoItemCategoryIDItemCodeInventoryOrderDetails primary key(OrderNo, ItemCategoryID, ItemCode),
PackID varchar(10),
Quantity int,
UnitCost money,
ItemStatusID varchar(10) constraint fkItemStatusIDInventoryOrderDetails references LookupData (DataID),
PackSize int constraint dfPackSizeInventoryOrderDetails default 1,
LoginID varchar(20) constraint fkLoginIDInventoryOrderDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryOrderDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryOrderDetails default getdate()
)
go

create table InventoryTransfers
(TransferID int not null constraint dfTransferIDInventoryTransfers default 1,
TransferNo varchar(20) not null constraint pkTransferNoInventoryTransfers primary key,
TransferDate smalldatetime,
FromLocationID varchar(10) constraint fkFromLocationIDInventoryTransfers references LookupData (DataID),
ToLocationID varchar(10) constraint fkToLocationIDInventoryTransfers references LookupData (DataID),
OrderNo varchar(20) null constraint fkOrderNoInventoryTransfers references InventoryOrders (OrderNo),
StockCost money,
LoginID varchar(20)constraint fkLoginIDInventoryTransfers references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryTransfers default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryTransfers default getdate()
)
go

create table InventoryTransferDetails
(TransferNo varchar(20) not null constraint fkTransferNoInventoryTransferDetails 
references InventoryTransfers (TransferNo)on delete cascade on update cascade, 
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInventoryTransferDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkTransferNoItemCategoryIDItemCodeInventoryTransferDetails primary key(TransferNo, ItemCategoryID, ItemCode),
Quantity int,
UnitCost money,
BatchNo varchar(20),
ExpiryDate smalldatetime,
StockStatusID varchar(10) constraint fkStockStatusIDInventoryTransferDetails references LookupData (DataID),
PackID varchar(10),
PackSize int constraint dfPackSizeInventoryTransferDetails default 1,
LoginID varchar(20) constraint fkLoginIDInventoryTransferDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryTransferDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryTransferDetails default getdate()
)
go


create table InventoryAcknowledges
(TransferNo varchar(20) not null,
ItemCategoryID varchar(10) not null,
ItemCode varchar(20) not null,
constraint fkTransferNoItemCategoryIDItemCodeInventoryAcknowledges foreign key (TransferNo, ItemCategoryID, ItemCode) 
references InventoryTransferDetails (TransferNo, ItemCategoryID, ItemCode),
constraint pkTransferNoItemCategoryIDItemCodeInventoryAcknowledges primary key(TransferNo, ItemCategoryID, ItemCode),
ReceivedDate smalldatetime,
LoginID varchar(20) constraint fkLoginIDInventoryAcknowledges references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryAcknowledges default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryAcknowledges default getdate()
)
go

create table InventoryEXT
(ItemCode varchar(20),
ItemName varchar(100),
ItemCategoryID varchar(10) constraint fkItemCategoryIDInventoryEXT references LookupData (DataID),
constraint pkItemCodeItemCategoryID primary key(ItemCode, ItemCategoryID),
UnitCost decimal,
UnitPrice decimal,
Agent varchar(40),
Saved bit constraint dfSavedInventoryEXT default 0,
ClientMachine varchar(40) constraint dfClientMachineInventoryEXT default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryEXT default getdate()
)
go

create table DeliveryNoteDetails
(TransferNo varchar(20) not null,
ItemCategoryID varchar(10) not null,
ItemCode varchar(20) not null,
constraint pkTransferNoItemCategoryIDItemCode primary key(TransferNo, ItemCategoryID, ItemCode),
PackID varchar(10)
constraint fkPackIDDeliveryNoteDetails references LookupData (DataID),
DeliveryDate smalldatetime,
PackSize int,
Quantity int,
UnitCost money,
LoginID varchar(20)
constraint fkLoginIDDeliveryNoteDetails references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDeliveryNoteDetails default getdate(),
ClientMachine varchar(40) constraint dfClientMachineDeliveryNoteDetails default host_name()

)
go

create table BarCodeDetails
(ItemCode Varchar(20),
ItemCategoryID varchar(10),
BarCode Varchar(2000),
LoginID varchar(20),
ClientMachine Varchar(40),
RecordDateTime SmallDateTime constraint dfRecordDateTimeBarCodeDetails default getdate(),
constraint pkItemCodeItemCategoryIDRecordDateTime primary key(ItemCode, ItemCategoryID, RecordDateTime)
)
go

create table PhysicalStockCount
(PSCID int not null constraint dfPSCIDPhysicalStockCount default 1,
PSCNo varchar(20) not null
constraint pkPSCNo primary key,
GeneralNotes Varchar(200),
StartDate smalldatetime,
EndDate smalldatetime,
Closed bit constraint dfClosedPhysicalStockCount default 1,
LoginID varchar(20)
constraint fkLoginIDPhysicalStockCount references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePhysicalStockCount default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePhysicalStockCount default getdate()
)
go

create table PhysicalStockCountDetails
(PSCNo varchar(20) not null
constraint fkPSCNoPhysicalStockCountDetails references PhysicalStockCount (PSCNo),
LocationID  varchar(10) not null
constraint fkLocationIDPhysicalStockCountDetails references LookupData (DataID),
ItemCategoryID  varchar(10) not null
constraint fkItemCategoryIDPhysicalStockCountDetails references LookupData (DataID),
ItemCode Varchar(20),
constraint pkPSCNoLocationIDItemCategoryIDItemCode primary key(PSCNo, LocationID , ItemCategoryID , ItemCode),
SystemQuantity int,
PhysicalCountQuantity int,
Notes Varchar(200),
LoginID Varchar(20)
constraint fkLoginIDPhysicalStockCountDetails references Logins (LoginID),
ClientMachine Varchar(20) constraint dfClientMachinePhysicalStockCountDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePhysicalStockCountDetails default getdate()
)
go
--- INT_PhysicalStockCountDetails
create table INTStockTake
(PSCNo varchar(20),
ItemCategoryID varchar(10),
ItemCode varchar(20),
constraint pkPSCNoItemCategoryIDItemCode primary key(PSCNo, ItemCategoryID, ItemCode),
Agent varchar(10),
SyncStatus bit constraint dfSyncStatusINTStockTake default 0,
RecordDateTime smalldatetime constraint dfRecordDateTimeINTStockTake default getdate()
)
go

create table DrugCombinationDetails
(Combination varchar(30) not null constraint fkCombinationDrugCombinationDetails 
references DrugCombinations(Combination)on delete cascade,
DrugNo varchar(20) constraint fkDrugNoDrugCombinationDetails references Drugs(DrugNo),
constraint pkCombinationDrugNo primary key (Combination, DrugNo)
)
go

create table ARTRegimen
(VisitNo varchar(20) not null constraint pkVisitNoARTRegimen primary key
constraint fkVisitNoARTRegimen references Visits(VisitNo),
Combination varchar(30) constraint fkCombinationARTRegimen references DrugCombinations(Combination),
StartDate smalldatetime,
WHOStageID varchar(10) constraint fkWHOStageIDARTRegimen references LookupData (DataID),
DrugLinesID varchar(10) constraint fkDrugLinesIDARTRegimen references LookupData (DataID),
StaffNo varchar(10) constraint fkStaffNoARTRegimen references Staff (StaffNo),
ARTCategoryID varchar(10) constraint fkARTCategoryIDARTRegimen references LookupData (DataID),
WhyEligible varchar(200),
ARTSwitchReasons varchar(200),
Notes varchar(200),
ARTStatusID varchar(10) constraint fkARTStatusIDARTRegimen references LookupData (DataID),
RefillDuration smallint,
LoginID varchar(20) constraint fkLoginIDARTRegimen references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeARTRegimen default getdate()
)
go

create table ARTRegimenDetails
(VisitNo varchar(20) not null 
constraint fkVisitNoARTRegimenDetails references ARTRegimen(VisitNo)
on delete cascade,
DrugNo varchar(20) constraint fkDrugNoARTRegimenDetails references Drugs(DrugNo),
constraint pkVisitNoDrugNo primary key (VisitNo, DrugNo),
Dosage varchar(100),
Duration int,
Quantity int,
Formula varchar(40)
)
go

create table ARTStopped
(VisitNo varchar(20) not null constraint pkVisitNoARTStopped primary key
constraint fkVisitNoARTStopped references ARTRegimen(VisitNo),
StopDate smalldatetime,
ARTStopReasons varchar(200),
StaffNo varchar(10) constraint fkStaffNoARTStopped references Staff (StaffNo),
LoginID varchar(20) constraint fkLoginIDARTStopped references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeARTStopped default getdate()
)
go


create table Queues
(TokenID int not null constraint dfTokenIDQueues default 1,
VisitNo Varchar(20) not null constraint fkVisitNoQueues references Visits (VisitNo) on update cascade on delete cascade,
BranchID Varchar(10) not null constraint fkBranchIDQueues references LookupData (DataID),
ServicePointID varchar(10) not null constraint fkServicePointIDQueues references LookupData (DataID),
constraint pkVisitNoBranchIDServicePointID primary key(VisitNo, BranchID, ServicePointID),
TokenNo Varchar(20),
PriorityID Varchar(10) constraint fkPriorityIDQueues references LookupData (DataID),
QueueStatus bit constraint dfQueueStatusQueues default 1,
LoginID Varchar(20) constraint fkLoginIDQueues references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineQueues default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeQueues default getdate()
)
go

create table QueuedMessages
(VisitNo Varchar(20) constraint fkVisitNoQueuedMessages references Visits (VisitNo) on update cascade on delete cascade,
BranchID Varchar(10) constraint fkBranchIDQueuedMessages references LookupData (DataID),
RoomNameID Varchar(200),
ServicePointID varchar(10) constraint fkServicePointIDQueuedMessages references LookupData (DataID),
TokenNo Varchar(20),constraint pkVisitNoBranchIDServicePointIDQueuedMessages primary key(VisitNo, BranchID, ServicePointID),
ReadCount int constraint dfReadCountQueuedMessages default 0,
LoginID Varchar(20) constraint fkLoginIDQueuedMessages references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineQueuedMessages default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeQueuedMessages default getdate()
)
go

create table Deaths
(PatientNo varchar(20) not null constraint pkPatientNoDeaths primary key
constraint fkPatientNoDeaths references Patients(PatientNo), 
DeathDate smalldatetime,
Notes varchar(200),
StaffNo varchar(10),
TimeOfDeath varchar(8),
PrimaryCauseOfDeath varchar(200),
SecondaryCauseOfDeath varchar(200),
OtherCauseOfDeath varchar(200),
LoginID varchar(20) constraint fkLoginIDDeaths references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeDeaths default getdate()
)
go

create table Expenditure
(ExpenditureID int not null constraint dfExpenditureID default 1,
ExpenditureNo varchar(20) not null constraint pkExpenditure primary key,
SpentDate smalldatetime,
ExpenditureCategoryID varchar(10) constraint fkExpenditureCategoryIDExpenditure references LookupData (DataID),
ExpenditureSourceTypeID varchar(10) constraint fkExpenditureSourceTypeIDExpenditure references LookupData (DataID),
AccountNo varchar(20),
GivenTo	varchar(40),
Amount money,
ExchangeRate money,
DocumentNo varchar(20),
Details	varchar(100),
BranchID varchar(10) constraint fkBranchIDExpenditure references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDExpenditure references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineExpenditure default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeExpenditure default getdate()
)
go

create table OtherIncome
(IncomeID int not null constraint dfIncomeIDOtherIncome default 1,
IncomeNo varchar(20) not null constraint pkIncomeNo primary key,
IncomeDate smalldatetime,
IncomeSourcesID varchar(10) constraint fkIncomeSourcesIDOtherIncome references LookupData (DataID),
PayModesID varchar(10) constraint fkPayModesIDOtherIncome references LookupData (DataID),
Amount money,
CurrenciesID varchar(10) constraint fkCurrenciesIDOtherIncome references LookupData (DataID),
AmountTendered money,
ExchangeRate money,
Change money,
DocumentNo varchar(20),
Notes varchar(200),
BranchID varchar(10) constraint fkBranchIDOtherIncome references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDOtherIncome references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOtherIncome default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeOtherIncome default getdate()
)
go

create table Templates
(TemplateName varchar(40) not null constraint pkTemplateName primary key,
TemplateTypeID varchar(10) constraint fkTemplateTypeIDTemplates references LookupData (DataID),
Notes varchar(2000)
)
go

create table updateHistory
(OriginalLogin varchar(500),
SystemUser varchar(500),
ClientMachine varchar(40) constraint dfClientMachineupdateHistory default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeupdateHistory default getdate()
)
go

create table ImportDataInfo
(ItemCode varchar(20) not null constraint fkItemCodeImportDataInfo references LabTests (TestCode),
SourceName varchar(60) not null,
SourceCaption varchar(100) not null,
constraint pkItemCodeSourceNameSourceCaption primary key(ItemCode, SourceName, SourceCaption),
DatabaseTypeID varchar(10) constraint fkDatabaseTypeIDImportDataInfo references LookupData (DataID),
ConnectionModeID varchar(10) constraint fkConnectionModeIDImportDataInfo references LookupData (DataID),
ImportServer varchar(100),
ImportLogin varchar(100),
ImportPassword nvarchar(100),
SP_Name varchar(100)
)
go

create table OutwardFiles
(OutwardID int not null constraint dfOutwardIDOutwardFiles default 1,
OutwardNo varchar(20) not null constraint pkOutwardNoOutwardFiles primary key,
FileNo varchar(20) constraint fkFileNoOutwardFiles references Patients (PatientNo)
on delete cascade on update cascade,
TakenDateTime smalldatetime,
TakenBy varchar(100),
BillAccountName varchar(100),
VisitNo varchar(20) null constraint fkVisitNoOutwardFiles references Visits (VisitNo)
on delete cascade on update cascade,
LoginID varchar(20) constraint fkLoginIDOutwardFiles references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOutwardFiles default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeOutwardFiles default getdate()
)
go

create table InwardFiles
(OutwardNo varchar(20) not null constraint fkOutwardNoInwardFiles 
references OutwardFiles (OutwardNo) on delete cascade on update cascade
constraint pkOutwardNoInwardFiles primary key,
ReturnDateTime smalldatetime,
ReturnedBy varchar(100),
LoginID varchar(20) constraint fkLoginIDInwardFiles references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInwardFiles default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInwardFiles default getdate()
)
go

create table SmartCardAuthorisations
(PatientNo varchar(20) not null constraint fkPatientNoSmartCardAuthorisations 
references Patients (PatientNo) on delete cascade on update cascade,
BillModesID varchar(10) not null constraint fkBillModesIDSmartCardAuthorisations references LookupData (DataID),
BillNo varchar(20)not null, -- Reference BillCustomers and SchemeMembers
ToVisitDate Smalldatetime not null,
constraint pkPatientNoBillModesIDBillNoToVisitDate primary key(PatientNo, BillModesID, BillNo, ToVisitDate),
MedicalCardNo varchar(20),
AuthorisedBy varchar(41),
AuthorisationReason varchar(10) constraint fkAuthorisationReasonSmartCardAuthorisations references LookupData (DataID),
ClaimReferenceNo varchar(30),
LoginID varchar(20) constraint fkLoginIDSmartCardAuthorisations references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineSmartCardAuthorisations default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSmartCardAuthorisations default getdate()
)
go

create table Alerts
(AlertID int not null identity(1,1) constraint pkAlertID primary key,
AlertTypeID varchar(10) constraint fkAlertTypeIDAlerts references LookupData (DataID),
VisitNo varchar(20) constraint fkVisitNoAlerts references Visits (VisitNo)
on delete cascade on update cascade,
StaffNo varchar(10) constraint fkStaffNoAlerts references Staff (StaffNo) on delete cascade on update cascade,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDAlerts references Logins (LoginID),
SentDate smalldatetime constraint uqAlertTypeIDVisitNoSentDate unique(AlertTypeID, VisitNo, SentDate),
SentTime varchar(8)
)
go

create table IPDAlerts
(AlertID int not null identity(1,1) constraint pkAlertIDIPDAlerts primary key,
AlertTypeID varchar(10) constraint fkAlertTypeIDIPDAlerts references LookupData (DataID),
RoundNo varchar(20) constraint fkRoundNoIPDAlerts references IPDDoctor (RoundNo)
on delete cascade on update cascade,
StaffNo varchar(10) constraint fkStaffNoIPDAlerts references Staff (StaffNo)
on delete cascade on update cascade,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDAlerts references Logins (LoginID),
SentDate smalldatetime constraint uqAlertTypeIDRoundNoSentDate unique(AlertTypeID, RoundNo, SentDate),
SentTime varchar(8)
)
go

create table PrintDetails
(PatientNo varchar(20),
DocumentNo varchar(20),
PrintDesc varchar(200),
PrintCategoryID varchar(10) constraint fkPrintCategoryIDPrintDetails references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPrintDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePrintDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePrintDetails default getdate(),
constraint pkPatientNoPrintDescRecordDateTime primary key(PatientNo, PrintDesc, RecordDateTime)
)
go

create table SuspiciousLogins
(Username varchar(20),
Details varchar(200),
ClientMachine varchar(41) constraint dfClientMachineSuspiciousLogins default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSuspiciousLogins default getdate()
)
go

create table ItemsBalanceDetails
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDItemsBalanceDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDItemsBalanceDetails primary key (VisitNo, ItemCode, ItemCategoryID),
ItemName varchar(800),
Balance int constraint dfBalanceItemsBalanceDetails default 0,
BalanceStatus varchar(10) constraint fkBalanceStatusItemsBalanceDetails references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDitemsBalanceDetails references Logins (LoginID),
NextVisitNo varchar(20) not null,
ClientMachine varchar(40) constraint dfClientMachineitemsBalanceDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeitemsBalanceDetails default getdate()
)
go

create table StaffLocations
(StaffLoginID Varchar(20) constraint fkStaffLoginIDStaffLocations references Logins (LoginID),
LocationID varchar(10) constraint fkLocationIDStaffLocations references LookupData (DataID),
StartDate smallDateTime, constraint pkStaffLoginIDLocationIDStartDate primary key(StaffLoginID, LocationID, StartDate),
Notes varchar(200),
LoginID varchar(20)constraint fkLoginIDStaffLocations references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineStaffLocations default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeStaffLocations default getdate()
)
go

create table BulkMessaging
(MessageID int constraint dfMessageIDBulkMessaging default 0,
MessageNo Varchar(20) not null,
Phone varchar(7500),
Message Varchar(600) not null,
SentID varchar(10) constraint fkSentIDBulkMessaging references LookupData (DataID),
flagID varchar(10) constraint fkflagIDBulkMessaging references LookupData (DataID),
LoginID Varchar(20) constraint fkLoginIDBulkMessaging references Logins (LoginID),
TextLifeSpan int,
SendDateTime SmallDateTime,
ClientMachine Varchar(40) constraint dfClientMachineBulkMessaging default host_name(),
RecordDateTime smallDatetime constraint dfRecordDateTimeBulkMessaging default getdate(),
constraint pkMessageNoMessageRecordDateTime primary key(MessageNo, Message,RecordDateTime)
)
go

create table Messenger
(ReceiverStaffNo varchar(20) constraint fkReceiverStaffNoMessenger references Logins (LoginID),
MessageInfo varchar(2000),
LoginID varchar(20) constraint fkLoginIDMessenger references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineMessenger default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeMessenger default getdate(),
Status bit
)
go

create table BankAccounts
(AccountNo Varchar(20) constraint pkAccountNoBankAccounts primary key,
AccountName Varchar(40),
BankNameID Varchar(10) constraint fkBankNameIDBankAccounts references LookupData (DataID),
CurrencyID Varchar(10) constraint fkCurrencyIDBankAccounts references LookupData (DataID),
LoginID Varchar(20) constraint fkLoginIDBankAccounts references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineBankAccounts default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBankAccounts default getdate()
)
go

create table BankingRegister
(RegisterID int not null constraint dfRegisterIDBankingRegister default 1,
RegisterNo Varchar(20) not null constraint pkRegisterNo primary key,
CollectionStartDate smalldatetime,
CollectionEndDate smalldatetime,
BankingDate smalldatetime,
BankNameID Varchar(10) constraint fkBankNameIDBankingRegister references LookupData (DataID),
CollectionSourceTypeID varchar(10),
AccountName Varchar(20),
AccountNo Varchar(20) constraint fkAccountNoBankingRegister references BankAccounts (AccountNo),
AmountCollected money,
AmountBanked money,
AmountInWords Varchar(800),
CurrencyID Varchar(10) constraint fkCurrencyIDBankingRegister references LookupData (DataID),
ExchangeRate  money,
BankedBy Varchar(40),
LoginID Varchar(20) constraint fkLoginIDBankingRegister references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineBankingRegister default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBankingRegister default getdate()
)
go

create table BankingRegisterDetails
(RegisterNo Varchar(20) not null
constraint fkRegisterNoBankingRegisterDetails references BankingRegister (RegisterNo),
CollectionModesID Varchar(10) not null
constraint fkCollectionModesIDBankingRegisterDetails references LookupData (DataID),
BankModesID varchar(10)
constraint fkBankModesIDBankingRegisterDetails references LookupData (DataID),
Amount money,
DocumentNo varchar(20),
constraint pkRegisterNoCollectionModesIDDocumentNo primary key(RegisterNo, CollectionModesID, DocumentNo),
LoginID Varchar(20)
constraint fkLoginIDBankingRegisterDetails references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineBankingRegisterDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeBankingRegisterDetails default getdate()
)
go

create table BankPaymentDetails
(ReceiptNo varchar(10) not null
constraint pkReceiptNoBankPaymentDetails primary key,
BankNamesID varchar(10)
constraint fkBankNamesIDBankPaymentDetails references LookupData (DataID),
AccountNo varchar(20),
DocumentNo varchar(20),
PayModesID varchar(10)
constraint fkPayModesIDBankPaymentDetails references LookupData (DataID),
ClientMachine varchar(40) constraint dfClientMachineBankPaymentDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBankPaymentDetails default getdate(),
LoginID varchar(20)
constraint fkLoginIDBankPaymentDetails references Logins (LoginID)
)
go


create table StaffPayments
(PaymentVoucherID int not null,
PaymentVoucherNo varchar(20) not null
constraint pkPaymentVoucherNo primary key,
VisitTypeID varchar(10) not null
constraint fkVisitTypeIDStaffPayments references LookupData (DataID),
StartDateTime SmallDateTime not null,
EndDateTime SmallDateTime not null,
BillModesID varchar(10) not null
constraint fkBillModesIDStaffPayments references LookupData (DataID),
StaffNo varchar(10) not null
constraint fkStaffNoStaffPayments references Staff (StaffNo),
VoucherStatusID varchar(10) not null
constraint fkVoucherStatusIDStaffPayments references LookupData (DataID),
LoginID varchar(20) not null
constraint fkLoginIDStaffPayments references Logins (LoginID),
ClientMachine Varchar(40) not null constraint dfClientMachineStaffPayments default Host_Name(),
RecordDateTime SmallDateTime not null constraint dfRecordDateTimeStaffPayments default GetDate()
)
go



create table StaffPaymentsEXT
(PaymentVoucherNo varchar(20)
constraint fkPaymentVoucherNoStaffPaymentsEXT references StaffPayments (PaymentVoucherNo)
constraint pkPaymentVoucherNoStaffPaymentsEXT primary key,
ApprovalDateTime SmallDateTime,
PayModeID varchar(10)
constraint fkPayModeIDStaffPaymentsEXT references LookupData (DataID),
DocumentNo varchar(20) not null,
CurrenciesID varchar(10)
constraint fkCurrenciesIDStaffPaymentsEXT references LookupData (DataID),
ExchangeRate money not null,
Amount money not null,
AmountWords varchar(400) not null,
ApprovalStatusID varchar(10)
constraint fkApprovalStatusIDStaffPaymentsEXT references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDStaffPaymentsEXT references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineStaffPaymentsEXT default Host_Name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeStaffPaymentsEXT default GetDate()
)
go


create table IPDStaffPaymentDetails
(PaymentVoucherNo varchar(20) not null
constraint fkPaymentVoucherNoIPDStaffPaymentDetails references StaffPayments (PaymentVoucherNo),
VisitNo varchar(20) not null constraint fkVisitNoIPDStaffPaymentDetails references Visits (VisitNo),
RoundNo varchar(20) not null,
ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkExtraBillNoItemCodeItemCategoryIDIPDStaffPaymentDetails foreign key (ExtraBillNo, ItemCode, ItemCategoryID)
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkOPDStaffPaymentDetailsPaymentVoucherNoVisitNoExtraBillNoItemCodeItemCategoryID primary key(PaymentVoucherNo, VisitNo, ExtraBillNo, ItemCode, ItemCategoryID),
Amount money not null,
ApprovalStatusID varchar(10) not null constraint fkApprovalStatusIDIPDStaffPaymentDetails references LookupData (DataID),
ApprovalNotes varchar(200),
LoginID varchar(20) not null constraint fkLoginIDIPDStaffPaymentDetails references Logins (LoginID),
ClientMachine Varchar(40) not null constraint dfClientMachineIPDStaffPaymentDetails default Host_Name(),
RecordDateTime SmallDateTime not null constraint dfRecordDateTimeIPDStaffPaymentDetails default GetDate()
)
go


create table OPDStaffPaymentDetails
(PaymentVoucherNo varchar(20) not null
constraint fkPaymentVoucherNoOPDStaffPaymentDetails references StaffPayments (PaymentVoucherNo),
VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDOPDStaffPaymentDetails foreign key (VisitNo, ItemCode, ItemCategoryID)
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkOPDStaffPaymentDetailsPaymentVoucherNoVisitNoItemCodeItemCategoryID primary key(PaymentVoucherNo, VisitNo, ItemCode, ItemCategoryID),
Amount money not null,
ApprovalStatusID varchar(10) not null constraint fkApprovalStatusIDOPDStaffPaymentDetails references LookupData (DataID),
ApprovalNotes varchar(200),
LoginID varchar(20) not null constraint fkLoginIDOPDStaffPaymentDetails references Logins (LoginID),
ClientMachine Varchar(40) not null constraint dfClientMachineOPDStaffPaymentDetails default host_Name(),
RecordDateTime SmallDateTime not null constraint dfRecordDateTimeOPDStaffPaymentDetails default GetDate()
)
go

create table ResourcesINT
(Code varchar(20),
Description varchar(10),
ItemCategoryID varchar(10) constraint fkItemCategoryIDResourcesINT references LookupData (DataID),
constraint pkCodeItemCategoryID primary key(Code, ItemCategoryID),
Cost money,
Price money,
Agent varchar(10),
SyncStatus bit,
RecordDateTime smalldatetime constraint dfRecordDateTimeResourcesINT default getdate()
)
go

create table RejectedSpecimens
(SpecimenNo varchar(20)
constraint pkSpecimenNoRejectedSpecimens primary key,
VisitNo varchar(20),
RejectectionReasonID varchar(10)
constraint fkRejectectionReasonIDRejectedSpecimens references LookupData (DataID),
RejectionDate smalldatetime,
RejectedAt varchar(10),
RejectedBy varchar(40),
IsReAccepted bit,
LoginID varchar(20)
constraint fkLoginIDRejectedSpecimens references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRejectedSpecimens default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRejectedSpecimens default getdate()
)
go


------------- This ensures newline after go above for the installer -----------------------------------------------------

create table ServiceInvoices
(ServiceInvoiceID int not null constraint dfServiceInvoiceIDServiceInvoices default 1,
ServiceInvoiceNo varchar(20) not null constraint pkServiceInvoiceNoServiceInvoices primary key,
InvoiceDate smalldatetime,
DocumentNo varchar(20),
SupplierNo varchar(20) constraint fkSupplierNoServiceInvoices references Suppliers (SupplierNo),
ShipAddress varchar(300),
LoginID varchar(20) constraint fkLoginIDServiceInvoices references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServiceInvoices default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServiceInvoices default getdate()
)
go

create table ServiceInvoiceDetails
(ServiceInvoiceNo varchar(20) not null constraint fkServiceInvoiceNoServiceInvoiceDetails 
references ServiceInvoices (ServiceInvoiceNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDServiceInvoiceDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkServiceInvoiceNoItemCategoryIDItemCodeServiceInvoiceDetails primary key(ServiceInvoiceNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqServiceInvoiceNoItemCategoryIDItemName unique(ServiceInvoiceNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
ItemGroup varchar(100),
PackID varchar(10) not null constraint fkPackIDServiceInvoiceDetails references LookupData (DataID),
PackSize int constraint dfPackSizeServiceInvoiceDetails default 1,
Quantity int,
Rate money,
Amount money,
VATValue money constraint dfVATValueServiceInvoiceDetails default 0,
Notes varchar(200),
PayStatusID varchar(10) constraint fkPayStatusIDServiceInvoiceDetails references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDServiceInvoiceDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServiceInvoiceDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServiceInvoiceDetails default getdate()
)
go

create table MappedCodesFinance
(ItemCode varchar(20),
ItemCategoryID varchar(10)
constraint fkItemCategoryIDMappedCodesFinance references LookupData (DataID),
AccountTypeID Varchar(10)
constraint fkAccountTypeIDMappedCodesFinance references LookupData (DataID),
constraint pkItemCodeItemCategoryIDAccountTypeID primary key(ItemCode, ItemCategoryID, AccountTypeID),
ItemName varchar(200),
AccountNo varchar(20),
LoginID varchar(20) constraint fkLoginIDMappedCodesFinance references Logins (LoginID),
Username varchar(41),
ClientMachine varchar(40) constraint dfClientMachineMappedCodesFinance default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeMappedCodesFinance default getdate()
)
go

create table MappedCodes
(AccountNo varchar(20) constraint fkAccountNoMappedCodes references BillCustomers (AccountNo),
ItemCode varchar(200),
ItemCategoryID varchar(10) constraint fkItemCategoryIDMappedCodes references LookupData (DataID),
CustomCode varchar(20),
LoginID varchar(20),
constraint pkAccountNoItemCodeItemCategoryIDLoginID primary key(AccountNo, ItemCode, ItemCategoryID, LoginID),
ClientMachine varchar(40) constraint dfClientMachineMappedCodes default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeMappedCodes default getdate()
)
go

create table OccupationalTherapy
(VisitNo Varchar(20)
constraint fkVisitNoOccupationalTherapy references Visits (VisitNo),
WalkingID varchar(10)
constraint fkWalkingIDOccupationalTherapy references LookupData (DataID),
SitStandTransfersID varchar(10)
constraint fkSitStandTransfersIDOccupationalTherapy references LookupData (DataID),
BathingID varchar(10)
constraint fkBathingIDOccupationalTherapy references LookupData (DataID),
ToiletingID varchar(10)
constraint fkToiletingIDOccupationalTherapy references LookupData (DataID),
DressingID varchar(10)
constraint fkDressingIDOccupationalTherapy references LookupData (DataID),
HandFunctionID varchar(10)
constraint fkHandFunctionIDOccupationalTherapy references LookupData (DataID),
WashingID varchar(10)
constraint fkWashingIDOccupationalTherapy references LookupData (DataID),
FeedingID varchar(10)
constraint fkFeedingIDOccupationalTherapy references LookupData (DataID),
GroomingID varchar(10)
constraint fkGroomingIDOccupationalTherapy references LookupData (DataID),
MealPreparationID varchar(10)
constraint fkMealPreparationIDOccupationalTherapy references LookupData (DataID),
WorkPlaySchoolID varchar(10)
constraint fkWorkPlaySchoolIDOccupationalTherapy references LookupData (DataID),
LeisureID varchar(10)
constraint fkLeisureIDOccupationalTherapy references LookupData (DataID),
CommunicationID varchar(10)
constraint fkCommunicationIDOccupationalTherapy references LookupData (DataID),
CognitionID varchar(10)
constraint fkCognitionIDOccupationalTherapy references LookupData (DataID),
AttentionID varchar(10)
constraint fkAttentionIDOccupationalTherapy references LookupData (DataID),
ImpulseControlID varchar(10)
constraint fkImpulseControlIDOccupationalTherapy references LookupData (DataID),
SleepID varchar(10)
constraint fkSleepIDOccupationalTherapy references LookupData (DataID),
MemoryID varchar(10)
constraint fkMemoryIDOccupationalTherapy references LookupData (DataID),
PerceptionID varchar(10)
constraint fkPerceptionIDOccupationalTherapy references LookupData (DataID),
ThoughtID varchar(10)
constraint fkThoughtIDOccupationalTherapy references LookupData (DataID),
SightID varchar(10)
constraint fkSightIDOccupationalTherapy references LookupData (DataID),
TasteID varchar(10)
constraint fkTasteIDOccupationalTherapy references LookupData (DataID),
HearingID varchar(10)
constraint fkHearingIDOccupationalTherapy references LookupData (DataID),
TouchID varchar(10)
constraint fkTouchIDOccupationalTherapy references LookupData (DataID),
SmellID varchar(10)
constraint fkSmellIDOccupationalTherapy references LookupData (DataID),
PainID varchar(10)
constraint fkPainIDOccupationalTherapy references LookupData (DataID),
VestibularID varchar(10)
constraint fkVestibularIDOccupationalTherapy references LookupData (DataID),
TemperatureAndPressureID varchar(10)
constraint fkTemperatureAndPressureIDOccupationalTherapy references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDOccupationalTherapy references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOccupationalTherapy default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeOccupationalTherapy default getdate()
)
go

create table OTIntervention
(VisitNo Varchar(20)
constraint fkVisitNoOTIntervention references Visits (VisitNo),
LeadTherapist Varchar(10)
constraint fkLeadTherapistOTIntervention references Staff (StaffNo),
InterventionTypeID Varchar(10)
constraint fkInterventionTypeIDOTIntervention references LookupData (DataID),
CognitiveAssessment bit,
HandTherapy bit,
HealthEducation bit,
TherapeuticGroupActivities bit,
HomebasedRehabilitation bit,
AssistiveDevices bit,
MobilitySkillsTraining bit,
NeurocognitiveRehabilitation bit,
OrientationTechniques bit,
VocationalRehabilitation bit,
SelfCareTraining bit,
PlayTherapy bit,
StressManagement bit,
OtherAssessment varchar(100),
Notes varchar(200),
LoginID varchar(20)
constraint fkLoginIDOTIntervention references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOTIntervention default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeOTIntervention default getdate()
)
go

-----------------------------------------------------------------------------------
create table MaternalEnrollment
(ANCID int constraint dfANCIDMaternalEnrollment default 1,
ANCNo varchar(20) constraint pkMaternalEnrollmentANCNo primary key, 
PatientNo varchar(20) constraint fkPatientNoMaternalEnrollment references Patients (PatientNo),
HIVStatusID varchar(10) constraint fkHIVStatusIDMaternalEnrollment references LookupData (DataID),
PartnersHIVStatusID varchar(10) constraint fkPartnersHIVStatusIDMaternalEnrollment references LookupData (DataID),
Gravida int,
Para int,
LNMP smalldatetime,
LNMPDateReliable bit,
CycleRegularID varchar(10) constraint fkCycleRegularIDMaternalEnrollment references LookupData (DataID),
EDD smalldatetime,
ScanDate smalldatetime,
MedicalHistory varchar(200),
MedicalHistoryNotes varchar(200),
BloodTransfusion varchar(10) constraint fkBloodTransfusionMaternalEnrollment references LookupData (DataID),
BloodTransfusionDate smalldatetime,
SurgicalHistory varchar(200),
SurgicalHistoryNotes varchar(200),
GynaecologicalHistory varchar(200),
GynaecologicalHistoryNotes varchar(200),
FamilyHistory varchar(200),
FamilyHistoryNotes varchar(200),
SocialHistory varchar(200),
SocialHistoryNotes varchar(200),
PatientStatusID varchar(10) constraint fkPatientStatusIDMaternalEnrollment references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDMaternalEnrollment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineMaternalEnrollment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeMaternalEnrollment default getdate()
)
go

create table Obstetric
( PatientNo varchar(20) not null
constraint fkPatientNoObstetric references Patients (PatientNo)  on delete cascade on update cascade,
Pregnancy int constraint uqPregnancyObstetric unique,
constraint pkPatientNoPregnancy primary key(PatientNo, Pregnancy),
YearPregnant int,
AbortionID varchar(10) constraint fkAbortionIDObstetric references LookupData (DataID),
AbortionPeriodID varchar(10) constraint fkAbortionPeriodIDObstetric references LookupData (DataID),
TypeOfDeliveryID varchar(10) constraint fkTypeOfDeliveryIDObstetric references LookupData (DataID),
ThirdStageID Varchar(10) constraint fkThirdStageIDObstetric references LookupData (DataID),
PuerPeriumID Varchar(10) constraint fkPuerPeriumIDObstetric references LookupData (DataID),
ChildStatusID varchar(10) constraint fkChildStatusIDObstetric references LookupData (DataID),
GenderID Varchar(10) constraint fkGenderIDObstetric references LookupData (DataID),
BirthWeight decimal,
ChildImmunised bit,
HealthCondition Varchar(200),
LoginID Varchar(20) constraint fkLoginIDObstetric references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineObstetric default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeObstetric default getdate()
)
go

create table ContraceptivesHistory
(PatientNo varchar(20) not null constraint fkPatientNoContraceptivesHistory references Patients (PatientNo)  on delete cascade on update cascade,
ContraceptiveID varchar(10) constraint fkContraceptiveIDContraceptivesHistory references LookupData (DataID),
ComplicationsID varchar(10)  constraint fkComplicationsIDContraceptivesHistory references LookupData (DataID),
constraint pkPatientNoContraceptiveID primary key(PatientNo, ContraceptiveID),
ComplicationDetails varchar(200),
DateStarted smalldatetime,
DiscontinuedRemovedID varchar(10) constraint fkDiscontinuedRemovedIDContraceptivesHistory references LookupData (DataID),
RemovalReasonsID varchar(10) constraint fkRemovalReasonsIDContraceptivesHistory references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDContraceptivesHistory references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineContraceptivesHistory default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeContraceptivesHistory default getdate()
)
go


create table Antenatal
(VisitNo Varchar(20) constraint fkVisitNoAntenatal references Visits (VisitNo),
Infection Varchar(10) constraint fkInfectionAntenatal references LookupData (DataID),
InfectionDetails Varchar(100),
AccidentDuringPregnancy Varchar(10) constraint fkAccidentDuringPregnancyAntenatal references LookupData (DataID),
DetailsOfAccident Varchar(100),
UseOfDrugsOrPrescription Varchar(10) constraint fkUseOfDrugsOrPrescriptionAntenatal references LookupData (DataID),
DrugDetails Varchar(100),
Smoking Varchar(10) constraint fkSmokingAntenatal references LookupData (DataID),
ChronicIllness varchar(10) constraint fkChronicIllnessAntenatal references LookupData (DataID),
DetailsOfIllness varchar(100),
LoginID Varchar(20) constraint fkLoginIDAntenatal references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAntenatal default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeAntenatal default getdate()
)
go

create table PostNatal
(PatientNo Varchar(20) not null constraint fkPatientNoPostNatal references Patients (PatientNo)
on delete cascade on update cascade,
DeliveryComplications varchar(10) constraint fkDeliveryComplicationsPostNatal references LookupData (DataID),
ConditionOnBirth varchar(10) constraint fkConditionOnBirthPostNatal references LookupData (DataID),
ConditionDetails varchar(100),
PhysicalAbnormalityDetails varchar(100),
UmblicalCordDetails varchar(100),
Jaundice varchar(10) constraint fkJaundicePostNatal references LookupData (DataID),
EarlyInfection varchar(10) constraint fkEarlyInfectionPostNatal references LookupData (DataID),
InfectionDetails varchar(100),
Convulsions varchar(10) constraint fkConvulsionsPostNatal references LookupData (DataID),
ConvulsionsDetails varchar(100),
EIDResults varchar(10) constraint fkEIDResultsPostNatal references LookupData (DataID),
ApgarScore int,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDPostNatal references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachinePostNatal default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePostNatal default getdate()
)
go

create table AntenatalVisits
(VisitNo Varchar(20) constraint fkVisitNoAntenatalVisits references Visits (VisitNo) constraint pkAntenatalVisitsVisitNo primary key,
ANCNo varchar(20) constraint fkANCNoAntenatalVisits references MaternalEnrollment (ANCNo),
PallorID varchar(10) constraint fkPallorIDAntenatalVisits references LookupData (DataID),
JaundiceID varchar(10) constraint fkJaundiceIDAntenatalVisits references LookupData (DataID),
LynphadenopathyID varchar(10) constraint fkLynphadenopathyIDAntenatalVisits references LookupData (DataID),
VaricoseID varchar(10) constraint fkVaricoseIDAntenatalVisits references LookupData (DataID),
OedemaID Varchar(10) constraint fkOedemaIDAntenatalVisits references LookupData (DataID),
HeartSoundID Varchar(10) constraint fkHeartSoundIDAntenatalVisits references LookupData (DataID),
AirEntryID varchar(10) constraint fkAirEntryIDAntenatalVisits references LookupData (DataID),
BreastID Varchar(10) constraint fkBreastIDAntenatalVisits references LookupData (DataID),
LiverID Varchar(10) constraint fkLiverIDAntenatalVisits references LookupData (DataID),
SpleenID Varchar(10) constraint fkSpleenIDAntenatalVisits references LookupData (DataID),
BowelSoundsID varchar(10) constraint fkBowelSoundsIDAntenatalVisits references LookupData (DataID),
ScarID Varchar(10) constraint fkScarIDAntenatalVisits references LookupData (DataID),
PupilReactionID Varchar(10) constraint fkPupilReactionIDAntenatalVisits references LookupData (DataID),
ReflexesID Varchar(10) constraint fkReflexesIDAntenatalVisits references LookupData (DataID),
OtherSTIID varchar(10) constraint fkOtherSTIIDAntenatalVisits references LookupData (DataID),
STIDetails Varchar(200),
SkeletalDeformityID Varchar(10) constraint fkSkeletalDeformityIDAntenatalVisits references LookupData (DataID),
AnenorrheaWeeks int,
FundalHeight varchar(10),
PresentationID Varchar(10) constraint fkPresentationIDAntenatalVisits references LookupData (DataID),
LieID varchar(10) constraint fkLieDAntenatalVisits references LookupData (DataID),
PositionID varchar(10) constraint fkPositionIDAntenatalVisits references LookupData (DataID),
RelationPPOrBrim varchar(10),
FoetalHeart int,
TTGiven bit,
IPTID  varchar(10) constraint fkIPTIDAntenatalVisits references LookupData (DataID),
NetUseID varchar(10) constraint fkNetUseIDAntenatalVisits references LookupData (DataID),
Remarks varchar(200),
ReturnDate smalldatetime,
DoctorSpecialityID varchar(10) constraint fkDoctorSpecialityIDAntenatalVisits references LookupData (DataID),
DoctorID varchar(10) constraint fkDoctorIDAntenatalVisits references Staff (StaffNo),
NurseInChargeID varchar(10) constraint fkNurseInChargeIDAntenatalVisits references Staff(StaffNo),
LoginID Varchar(20) constraint fkLoginIDAntenatalVisits references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAntenatalVisits default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeAntenatalVisits default getdate()
)
go

create table ImmunisationVaccines
(ImmunisationID Int constraint dfImmunisationIDImmunisationVaccines default 1,
ImmunisationNo Varchar(20),
PatientNo Varchar(20) constraint pkPatientNoVaccineNameImmunisationVaccines primary key(PatientNo, VaccineName),
VaccineName Varchar(10) constraint fkVaccineNameImmunisationVaccines references LookupData (DataID),
VaccineReceived varchar(10) constraint fkVaccineReceivedImmunisationVaccines references LookupData (DataID),
DateGiven smalldatetime,
PlaceReceived varchar(10) constraint fkPlaceReceivedImmunisationVaccines references LookupData (DataID),
Notes varchar(100),
MothersName varchar(20),
UpToDate bit,
LoginID Varchar(20) constraint fkLoginIDImmunisationVaccines references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineImmunisationVaccines default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeImmunisationVaccines default getdate()
)
go

create table ChildNutrition
(VisitNo Varchar(20) constraint fkVisitNoChildNutrition references Visits (VisitNo),
BreastFeeding Varchar(10) constraint fkBreastFeedingChildNutrition references LookupData (DataID),
IfNoDetails Varchar(100),
ComplementaryFoods Varchar(10) constraint fkComplementaryFoodsChildNutrition references LookupData (DataID),
ComplementaryFoodsDetails Varchar(100),
LoginID Varchar(20) constraint fkLoginIDChildNutrition references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineChildNutrition default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeChildNutrition default getdate()
)
go

create table ChildGrowth
(VisitNo Varchar(20) not null constraint fkVisitNoChildGrowth references Visits (VisitNo)
on delete cascade on update cascade,
SocialSmile bit,
HeadControl bit,
ReactionToSound bit,
GraspReflex bit,
Sitting bit,
Standing bit,
WeightForAge Varchar(10) constraint fkWeightForAgeChildGrowth references LookupData (DataID),
HeightForAge Varchar(10) constraint fkHeightForAgeChildGrowth references LookupData (DataID),
WeightForHeight Varchar(10) constraint fkWeightForHeightChildGrowth references LookupData (DataID),
BreastFeedingID varchar(10) constraint fkBreastFeedingIDChildGrowth references LookupData (DataID),
Notes varchar(200),
LoginID Varchar(20) constraint fkLoginIDChildGrowth references Logins (LoginID),
ClientMachine Varchar(41) constraint dfClientMachineChildGrowth default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeChildGrowth default getdate()
)
go

create table ObstetricHistory
(PatientNo Varchar(20) constraint fkPatientNoObstetricHistory references Patients (PatientNo),
Gravidity int,
Parity int,
NoOfSurvivingChildren int,
LMP SmallDateTime,
EDD SmallDateTime,
GestationalAgeInWks int,
StillBirth Varchar(10) constraint fkStillBirthObstetricHistory references LookupData (DataID),
NoOfStillBirths int,
Abortions Varchar(10) constraint fkAbortionsObstetricHistory references LookupData (DataID),
NoOfAbortions int,
Caesarian Varchar(10) constraint fkCaesarianObstetricHistory references LookupData (DataID),
NoOfCaesarians int,
LoginID Varchar(20) constraint fkLoginIDObstetricHistory references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineObstetricHistory default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeObstetricHistory default getdate()
)
go

create table Perinatal
(VisitNo Varchar(20) constraint fkVisitNoPerinatal references Visits (VisitNo),
ModeOfDelivery Varchar(10) constraint fkModeOfDeliveryPerinatal references LookupData (DataID),
DurationOfLabour Decimal,
DeliveryComplications Varchar(10) constraint fkDeliveryComplicationsPerinatal references LookupData (DataID),
AmountOfBloodLoss Decimal,
MothersCondition Varchar(10) constraint fkMothersConditionPerinatal references LookupData (DataID),
DetailsOfCondition Varchar(100),
BabyAlive Varchar(10) constraint fkBabyAlivePerinatal references LookupData (DataID),
CauseOfDeath Varchar(10) constraint fkCauseOfDeathPerinatal references LookupData (DataID),
LoginID Varchar(20) constraint fkLoginIDPerinatal references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePerinatal default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePerinatal default getdate()
)
go

create table PelvicExamination
(VisitNo Varchar(20) constraint fkVisitNoPelvicExamination references Visits (VisitNo) constraint pkPelvicExaminationVisitNo primary key,
ANCNo varchar(20) constraint fkANCNoPelvicExamination references MaternalEnrollment (ANCNo),
VulvaID Varchar(10) constraint fkVulvaIDPelvicExamination references LookupData (DataID),
CervixID varchar(10) constraint fkCervixIDPelvicExamination references LookupData (DataID),
AdnexaID Varchar(10) constraint fkAdnexaIDPelvicExamination references LookupData (DataID),
VaginaID Varchar(10) constraint fkVaginaIDPelvicExamination references LookupData (DataID),
UterusID Varchar(10) constraint fkUterusIDPelvicExamination references LookupData (DataID),
DiagonalConjugate int,
SacralCurve int,
IschialSpine int,
SubPublicAngle int,
IschialTuberosities int,
ConclusionID varchar(10) constraint fkConclusionIDPelvicExamination references LookupData (DataID),
RiskFactors varchar(200),
Recommendations varchar(200),
LoginID Varchar(20) constraint fkLoginIDPelvicExamination references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePelvicExamination default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePelvicExamination default getdate()
)
go

create table INTAgents
(AgentNo varchar(20) not null
constraint pkAgentNo primary key,
AgentName varchar(60),
LoginID varchar(20)
constraint fkLoginIDINTAgents references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineINTAgents default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeINTAgents default GetDate()
)
go

create table LookupDataMappings
(DataID Varchar(10) constraint fkDataIDLookupDataMappings references LookupData (DataID) on delete cascade,
AgentNo Varchar(20) constraint fkAgentNoLookupDataMappings references INTAgents (AgentNo),
constraint pkDataIDAgentDataID primary key(DataID,AgentNo),
AgentDataID Varchar(10) not null,
ObjectName Varchar(10) ,
LoginID Varchar(20) constraint fkLoginIDLookupDataMappings references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeLookupDataMappings default getdate(),
ClientMachine Varchar(40) constraint dfClientMachineLookupDataMappings default host_name()
)
go

create table BillableMappings
(ItemCategoryID varchar(10)
constraint fkItemCategoryIDBillableMappings references LookupData (DataID),
ItemCode varchar(20),
MappedTypeID varchar(10)
constraint fkMappedTypeIDBillableMappings references LookupData (DataID),
AgentNo varchar(20)
constraint fkAgentNoBillableMappings references INTAgents (AgentNo),
constraint pkItemCategoryIDItemCode primary key(ItemCategoryID, ItemCode, MappedTypeID, AgentNo),
MappedCode varchar(20),
LoginID varchar(20)
constraint fkLoginIDBillableMappings references Logins (LoginID),
ClientMachine varchar(10) constraint dfClientMachineBillableMappings default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBillableMappings default getdate()
)
go

create table PatientConsent
(PatientNo Varchar(20) constraint fkPatientNoPatientConsent references Patients (PatientNo)
on delete cascade on update cascade constraint pkPatientNoPatientConsent primary key,
PhoneNo Varchar(30),
Notes Varchar(200),
FingerprintVerified bit constraint dfFingerprintVerifiedPatientConsent default 0,
LoginID Varchar(20) constraint fkLoginIDPatientConsent references Logins (LoginID),
ClientMachine Varchar(41) constraint dfClientMachinePatientConsent default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePatientConsent default GetDate()
)
go

