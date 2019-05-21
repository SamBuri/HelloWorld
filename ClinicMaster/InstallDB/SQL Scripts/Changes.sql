

-- IPDItemCreatorCUR CURSOR does not execute, Invalid column name: ItemName, UnitMeasure
-- uqRoundNoItemCategoryIDItemCodeItems unique(RoundNo, ItemCategoryID, ItemCode), looks like pk
-- ItemCreatorCUR CURSOR complains as above and ExtraBillItemsCreatorCUR

--  table Items check the construct of constraint uqVisitNoItemCategoryIDItemCodeItems unique(VisitNo, ItemCategoryID, ItemCode)

-- On uspGetItems, uspGetToReturnItems,  uspGetReturnedItems, uspGetPeriodicPendingReturnedItems, uspGetPendingReturnedItems, uspGetPendingReturnedItemsDetails, uspGetSelfRequestItems
-- check with dbo.GetMergedNameCode(dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode), Items.ItemCode) as ItemFullName as well as ItemName

-- table HIVCARE choice for ComputerName vs ClientMachine
-- VisitsPriorityID best at VisitPriorityID, but its OK
-- ItemsBalanceDetails LoginID, ClientMachine and RecordDateTime, best together

-- view AccessedServices, DoctorLaboratory, DoctorPrescription, IPDDoctorPrescription ect.


Alter table Items add CreatorClientMachine varchar(40) constraint dfCreatorClientMachine default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginID references Logins (LoginID),
ItemName varchar(800),
constraint uqVisitNoItemCategoryIDItemCodeItemNameItems unique(VisitNo, ItemCategoryID, ItemCode, ItemName),
UnitMeasure varchar(100)
go

------------------------------------------14-02-2016------------------------------------------------------------------------------------

Alter table ExtraBillItems add CreatorClientMachine varchar(40) constraint dfCreatorClientMachineExtraBillItems default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginIDExtraBillItems references Logins (LoginID), ItemName varchar(800),
constraint uqExtraBillNoItemCategoryIDItemCodeItemNameExtraBillItems unique(ExtraBillNo, ItemCategoryID, ItemCode, ItemName),
UnitMeasure varchar(100)
go

Alter table IPDItems add CreatorClientMachine varchar(40) constraint dfCreatorClientMachineIPDItems default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginIDIPDItems references Logins (LoginID), ItemName varchar(800),
constraint uqRoundNoItemCategoryIDItemCodeItemNameIPDItems unique(RoundNo, ItemCategoryID, ItemCode, ItemName),
UnitMeasure varchar(100)
go

-- HIVCARE choice for ComputerName
-- To have column Amount in ItemsIncome chack on vat also
-- To have unique constraing in ItemsIncome
-- To let SendSMSUsingAPI001 option be hidden
-- Column CreditNoteOnTotal not included on table GoodsReceivedNote
-- InventoryAlertDays knowlegde sharing welcome
-- InheritOPDServicesAtIPD not enlisted in global options
-- include unique constraint on GoodsReturnedNoteDetails
-- What's this for updateHistory
-- Check BulkMessaging columns
-- drop table LowVision??? alarming.... and not deleted from tables structures.... seen later but confirm columns
-- To have VATPercent for IPDItems
-- 
-- EnableSMSNotificationAtRadiology, EnableSMSNotificationAtVisits, ...., EnableSMSNotificationForBirthdays consider table structures
-- On ReturnedExtrabillItems column ItemTransferStatus best as ItemTransferStatusID
-- exec uspInsertLookupData '46RTD', 46, 'Returned','N' not added on data scripts
-- How is ForceDiagnosisAtDoctor different from ForceDiagnosisOnPrescription
-- AllowAccessCashConsultation what's for
-- 
-- Ideas as to why drop table IPDNurse?
-- Use drop table IPDDrugAdministration with care
-- On IPDDrugAdministration, is uqNurseRoundNoTakenDateTimeItemNameIPDDrugAdministration right?
-- drop table IPDNurseFluids run with care
-- On IPDNurseFluids pk is enoug, no need for uq
-- Option IPDNurseAlertDays missing in scripts
-- On GoodsReceivedNoteDetails dropped column VATPercentage, but remnds in structures
-- ForceSelfRequestVisitsToPayConsultation not included onto the scripts
--
-- On AssetMaintainanceLog Column NextDue best as NextDueDate
-- What's StaffLocations for?
-- ClaimPaymentsAlertDays is missing in scripts
-- EnableSMSNotificationAtPharmacy missing in the scripts
-- On IPDStaffPaymentDetails to confirm the set pk
-- On OPDStaffPaymentDetails check on set pk
-- AllowIssueStockOnLabRequest not listed on scripts
-- On Queues fkVisitNoQueues not cascaded on structures
-- On Patients replacing / with , not applied to other phone fields
-- On BulkMessaging, SendDateTime not indicated on structures
-- EnableUseOfInventoryPackSizes not on scripts
-- On BulkMessaging, TextLifeSpan not on structures
