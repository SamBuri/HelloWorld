Use ClinicMaster
go


if exists (select * from sysobjects where name = 'SearchINTOPDInvoicesHeader')
	drop view SearchINTOPDInvoicesHeader
go

create view SearchINTOPDInvoicesHeader
with encryption
as 

select STUFF(Visits.PatientNo, 4, 0, '-')  as PatientID, Invoices.InvoiceNo,UPPER(visits.VisitNo) as RegistrationNo,
Invoices.RecordDateTime as TransactionDate, PackageVisits.PackageNo, PackageVisitNo as PackageID,
Invoices.loginID as userid,dbo.GetLookupDataDes(VisitTypeID) as PatientType,MemberCardNo as MTO,'OPD' as RevenueStream,
(case when LEN(AssociatedBillNo)> 0 then UPPER(SUBSTRING(AssociatedBillNo, 1, 4)) + '-' + UPPER(SUBSTRING(AssociatedBillNo, 5, 50))
 else case when LEN(InsuranceNo) > 0 then UPPER(SUBSTRING(InsuranceNo, 1, 4) + '-' + UPPER(SUBSTRING(InsuranceNo, 5, 50)))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
 else 
UPPER(SUBSTRING(Visits.PatientNo, 1, 3) + '-' + SUBSTRING(Visits.PatientNo, 4, 50))
 end  end end) AS BillToCustomer
from Invoices
inner join Visits on Invoices.PayNo = Visits.VisitNo
Left Outer join PackageVisits on PackageVisits.VisitNo = visits.VisitNo
inner join INTInvoices on INTInvoices.InvoiceNo =Invoices.InvoiceNo
WHERE VisitTypeID = dbo.GetLookupDataID('VisitType', 'OPD')
AND PayTypeID = '47CAS'


go


if exists (select * from sysobjects where name = 'SearchINTPackageDetails')
	drop view SearchINTPackageDetails
go

create view SearchINTPackageDetails
with encryption
as
	
select PackageConsumption.VisitNo as InvoiceNo,PackageConsumption.PackageNo as PackageNo, PackageConsumption.RecordDateTime as TransactionDate,
UPPER(case when LEN(AssociatedBillNo)> 0 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
else case when LEN(InsuranceNo) > 0 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
else (SUBSTRING(Visits.PatientNo, 1, 3) + '-' + SUBSTRING(Visits.PatientNo, 4, 50))end  end end) AS BillToCustomer,
PackageConsumption.ItemCode as No, dbo.GetOPDIssuingLocation(PackageConsumption.VisitNo, PackageConsumption.ItemCategoryID, PackageConsumption.ItemCode) as LocationCode,
PackageConsumption.Quantity as QuantityInvoiced, dbo.GetUnitMeasure(PackageConsumption.ItemCategoryID,PackageConsumption.ItemCode) as UnitMeasure,
0 as IssuePrice,dbo.GetConsumptionUnitPrice(PackageConsumption.VisitNo,PackageConsumption.ItemCode,PackageConsumption.ItemCategoryID) as UnitPrice,
0 as Discount,
dbo.GetInventoryBatchNo('', PackageConsumption.ItemCategoryID, PackageConsumption.ItemCode) as LotNo,
dbo.GetInventoryExpiryDate('', PackageConsumption.ItemCategoryID , PackageConsumption.ItemCode) as Expiry,
PackageConsumption.ItemCategoryID as ItemCategoryCode
from PackageConsumption
inner join PackageVisits on PackageVisits.VisitNo = PackageConsumption.VisitNo and PackageVisits.PackageVisitNo =PackageConsumption.PackageVisitNo
inner join Visits on PackageVisits.VisitNo= Visits.VisitNo
inner join INTPackageDetails on INTPackageDetails.VisitNo  =PackageConsumption.VisitNo and INTPackageDetails.ItemCode =PackageConsumption.ItemCode
and INTPackageDetails.ItemCategoryID =PackageConsumption.ItemCategoryID 

go


--------------------- SearchINTOPDInvoicesDetails-----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'SearchINTOPDInvoicesDetails')
	drop view SearchINTOPDInvoicesDetails
go

create view SearchINTOPDInvoicesDetails
with encryption 
as 

select STUFF(Visits.PatientNo, 4, 0, '-') as PatientID,(visits.VisitNo) as RegistrationNo,
Invoices.RecordDateTime as TransactionDate
,dbo.GetLookupDataDes(VisitTypeID) as PatientType,MemberCardNo as MTO,'OPD' as RevenueStream,
InvoiceDetails.ItemCode as ItemCode,(case when LEN(AssociatedBillNo)> 0 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
 else case when LEN(InsuranceNo) > 0 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
 else (SUBSTRING(Visits.PatientNo, 1, 3) + '-' + SUBSTRING(Visits.PatientNo, 4, 50))
 end  end end) AS BillToCustomer, invoiceDate as PayDate, Amount, dbo.GetItemName(InvoiceDetails.ItemCategoryID, InvoiceDetails.ItemCode) as PaymentFor,
Invoices.LoginID as UserID,Discount as PaymentDiscount,
(Invoices.InvoiceNo) as InvoiceNo,InvoiceDetails.Quantity as InvoicedQuantities,UnitMeasure,InvoiceDetails.UnitPrice,
dbo.GetInventoryBatchNo(null, Items.ItemCategoryID, Items.ItemCode) as BatchNo,InvoiceDetails.ItemCategoryID,
 dbo.GetInventoryExpiryDate(null, Items.ItemCategoryID, Items.ItemCode)  as ExpiryDate
from InvoiceDetails
inner join Invoices on Invoices.InvoiceNo = InvoiceDetails.InvoiceNo
inner join Items on Items.VisitNo = InvoiceDetails.VisitNo
and Items.ItemCode = InvoiceDetails.ItemCode and Items.ItemCategoryID = InvoiceDetails.ItemCategoryID 
inner join Visits on Items.VisitNo = Visits.VisitNo
inner join INTInvoiceDetails on InvoiceDetails.InvoiceNo =INTInvoiceDetails.InvoiceNo And
InvoiceDetails.VisitNo=INTInvoiceDetails.VisitNo And InvoiceDetails.ItemCode=INTInvoiceDetails.ItemCode And
InvoiceDetails.ItemCategoryID =INTInvoiceDetails.ItemCategoryID

go
-------------------------------------------------------------------------------------------------------------------





--------------------- SearchINTIPDExtraBillsHeaders-----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'SearchINTIPDExtraBillsHeaders')
	drop view SearchINTIPDExtraBillsHeaders
go

create view SearchINTIPDExtraBillsHeaders
with encryption
as
select SUBSTRING(visits.PatientNo, 1, 3) + '-' + SUBSTRING(visits.PatientNo, 4, 50) as PatientID,(ExtraBills.ExtraBillNo) as InvoiceNo,
	(visits.VisitNo) as RegistrationNo, PackageVisits.PackageNo, PackageVisitNo as PackageID,
	ExtraBills.RecordDateTime as TransactionDate,
	 ExtraBills.loginID as userid,'IPD' as PatientType, MemberCardNo as MTO,'InPatient' as RevenueStream,

     UPPER(case when LEN(AssociatedBillNo)> 0 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
	 else case when LEN(InsuranceNo) > 0 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
	 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
	 else (SUBSTRING(visits.PatientNo, 1, 3) + '-' + SUBSTRING(visits.PatientNo, 4, 50))end  end end) AS BillToCustomer
	from ExtraBills
	inner join Visits on ExtraBills.VisitNo = Visits.VisitNo
	Left Outer join PackageVisits on PackageVisits.VisitNo = visits.VisitNo
	inner join INTExtraBills on ExtraBills.ExtraBillNo =INTExtraBills.ExtraBillNo


go


---------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'SearchINTIPDExtraBillItemsDetails')
	drop view SearchINTIPDExtraBillItemsDetails
go
create view SearchINTIPDExtraBillItemsDetails
with encryption 
as 
  
	select UPPER(SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50)) as PatientID, ExtraBillItems.ExtraBillNo as InvoiceNo,
	ExtraBills.VisitNo, ExtraBills.RecordDateTime as TransactionDate,
	ExtraBillItems.ItemCategoryID,ExtraBillItems.ItemCode, UnitPrice,Quantity,'InPatient' as RevenueStream,
	UPPER(case when LEN(AssociatedBillNo)> 0 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
    else case when LEN(InsuranceNo) > 0 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
    else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
    else (SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50))end  end end) AS BillToCustomer,
	dbo.GetInventoryBatchNo('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as BatchNo,UnitMeasure,
	dbo.GetInventoryExpiryDate('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExpiryDate,ExtraBillItems.LoginID as UserID 
    from ExtraBillItems
   inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
   inner join Visits on Visits.VisitNo= Extrabills.VisitNo
    inner join INTExtraBillItems on ExtraBillItems.ExtraBillNo =INTExtraBillItems.ExtraBillNo And ExtraBillItems.ItemCode=INTExtraBillItems.ItemCode And 
	ExtraBillItems.ItemCategoryID=INTExtraBillItems.ItemCategoryID 
	 
go

---------------------------------------------------------------------------------------------------------------



exec uspInsertAccessObjects 'SearchINTOPDInvoicesHeader', 'INT OPD Invoices Header','V'
exec uspInsertAccessObjects 'SearchINTOPDInvoicesDetails', 'INT OPD Invoices Details','V'
exec uspInsertAccessObjects 'SearchINTIPDExtraBillsHeaders', 'INT IPD Extra Bills Headers','V'
exec uspInsertAccessObjects 'SearchINTIPDExtraBillItemsDetails', 'INT IPD Extra Bill Items Details','V'
exec uspInsertAccessObjects 'SearchINTPackageDetails', 'INT Package Details','V'


exec uspInsertObjectRoles 'SearchINTOPDInvoicesHeader', 'Administrator', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTOPDInvoicesDetails', 'Administrator', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTIPDExtraBillsHeaders', 'Administrator', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTIPDExtraBillItemsDetails', 'Administrator', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTPackageDetails', 'Administrator', 1, 1, 1, 1

exec uspInsertObjectRoles 'SearchINTOPDInvoicesHeader', 'Transactional', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTOPDInvoicesDetails', 'Transactional', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTIPDExtraBillsHeaders', 'Transactional', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTIPDExtraBillItemsDetails', 'Transactional', 1, 1, 1, 1
exec uspInsertObjectRoles 'SearchINTPackageDetails', 'Transactional', 1, 1, 1, 1


exec uspInsertSearchObjects 'SearchINTOPDInvoicesHeader', 'uspSearchObject', null, 0,
							1, 1000, 'TransactionDate desc'
exec uspInsertSearchObjects 'SearchINTOPDInvoicesDetails', 'uspSearchObject', null, 0,
							1, 1000, 'TransactionDate desc'
exec uspInsertSearchObjects 'SearchINTIPDExtraBillsHeaders', 'uspSearchObject', null, 0,
							1, 1000, 'TransactionDate desc'
exec uspInsertSearchObjects 'SearchINTIPDExtraBillItemsDetails', 'uspSearchObject', null, 0,
							1, 1000, 'TransactionDate desc'
exec uspInsertSearchObjects 'SearchINTPackageDetails', 'uspSearchObject', null, 0,
							1, 1000, 'TransactionDate desc'

------------------------------------------------------------------------------------------------------
---------------------------- SearchINTOPDInvoicesHeader ----------------------------------------------
------------------------------------------------------------------------------------------------------
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'PatientID', 'Patient No',1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'RegistrationNo', 'Registration No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'InvoiceNo', 'Invoice No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'dbo.FormatDate(TransactionDate)', 'Transaction Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'dbo.GetShortDate(TransactionDate)', 'Transaction Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'dbo.GetTime(TransactionDate)', 'Transaction Time', 1, 1, 0,'2EQL', '3STR', 8, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'PackageNo', 'Package No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'PackageID', 'Package ID', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'userid', 'User id', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'PatientType', 'Patient Type', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'MTO', 'MTO', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'RevenueStream', 'Revenue Stream', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'BillToCustomer', 'Bill To Customer', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesHeader', 'SyncStatus', 'Sync Status', 1, 1, 0,'2EQL', '3BIT', 0, 0, 0
go

------------------------------------------------------------------------------------------------------
---------------------------- SearchINTOPDInvoicesDetails ----------------------------------------------
------------------------------------------------------------------------------------------------------
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'PatientID', 'Patient No',1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'RegistrationNo', 'Registration No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.FormatText(InvoiceNo, ''Invoices'', ''InvoiceNo'')', 'Invoice No', 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'InvoiceNo', 'Invoice No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.FormatDate(TransactionDate)', 'Transaction Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.GetShortDate(TransactionDate)', 'Transaction Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.GetTime(TransactionDate)', 'Transaction Time', 1, 1, 0,'2EQL', '3STR', 8, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'PatientType', 'Patient Type', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'MTO', 'MTO', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'RevenueStream', 'Revenue Stream', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'ItemCode', 'Item Code', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'BillToCustomer', 'Bill To Customer', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.FormatDate(PayDate)', 'Pay Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.GetShortDate(PayDate)', 'Pay Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.FormatMoney(Amount)', 'Amount', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'PaymentFor', 'Payment For', 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'UserID', 'User id', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.FormatMoney(PaymentDiscount)', 'Payment Discount', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'InvoiceNo', 'Invoice No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'InvoicedQuantities', 'Invoiced Quantities', 1, 1, 0,'2EQL', '3NUM', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'UnitMeasure', 'Unit Measure', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.FormatMoney(UnitPrice)', 'Unit Price', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'BatchNo', 'Batch No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.GetLookupDataDes(ItemCategoryID)', 'Item Category', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.FormatDate(ExpiryDate)', 'Expiry Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTOPDInvoicesDetails', 'dbo.GetShortDate(ExpiryDate)', 'Expiry Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
go


------------------------------------------------------------------------------------------------------
---------------------------- SearchINTIPDExtraBillsHeaders ----------------------------------------------
------------------------------------------------------------------------------------------------------
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'PatientID', 'Patient No',1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'RegistrationNo', 'Registration No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'InvoiceNo', 'Invoice No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'dbo.FormatDate(TransactionDate)', 'Transaction Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'dbo.GetShortDate(TransactionDate)', 'Transaction Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'dbo.GetTime(TransactionDate)', 'Transaction Time', 1, 1, 0,'2EQL', '3STR', 8, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'userid', 'User id', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'PatientType', 'Patient Type', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'PackageNo', 'Package No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'PackageID', 'Package ID', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'MTO', 'MTO', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'RevenueStream', 'Revenue Stream', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillsHeaders', 'BillToCustomer', 'Bill To Customer', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
go

------------------------------------------------------------------------------------------------------
---------------------------- SearchINTIPDExtraBillItemsDetails ----------------------------------------------
------------------------------------------------------------------------------------------------------
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'PatientID', 'Patient No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'InvoiceNo', 'Invoice No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'VisitNo', 'Visit No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'dbo.FormatDate(TransactionDate)', 'Transaction Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'dbo.GetShortDate(TransactionDate)', 'Transaction Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'dbo.GetTime(TransactionDate)', 'Transaction Time', 1, 1, 0,'2EQL', '3STR', 8, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'RevenueStream', 'Revenue Stream', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'ItemCode', 'Item Code', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'BillToCustomer', 'Bill To Customer', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'dbo.FormatMoney(UnitPrice)', 'Unit Price', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', '(Quantity * UnitPrice)', 'Amount', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'UserID', 'User id', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'Quantity', 'Quantities', 1, 1, 0,'2EQL', '3NUM', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'UnitMeasure', 'Unit Measure', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'BatchNo', 'Batch No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'dbo.GetLookupDataDes(ItemCategoryID)', 'Item Category', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'dbo.FormatDate(ExpiryDate)', 'Expiry Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTIPDExtraBillItemsDetails', 'ExpiryDate', 'Expiry Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
go

------------------------------------------------------------------------------------------------------
---------------------------- SearchINTPackageDetails ----------------------------------------------
------------------------------------------------------------------------------------------------------
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'PackageNo', 'Package No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'InvoiceNo', 'Invoice No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.FormatDate(TransactionDate)', 'Transaction Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.GetShortDate(TransactionDate)', 'Transaction Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.GetTime(TransactionDate)', 'Transaction Time', 1, 1, 0,'2EQL', '3STR', 8, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.GetLookupDataDes(ItemCategoryCode)', 'Item Category', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'No', 'Item Code', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'LocationCode', 'Location Code', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.FormatMoney(IssuePrice)', 'Issue Price', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.FormatMoney(UnitPrice)', 'Unit Price', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.FormatMoney(Discount)', 'Discount', 1, 1, 0,'2EQL', '3MON', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'QuantityInvoiced', 'Quantities', 1, 1, 0,'2EQL', '3NUM', 0, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'RevenueStream', 'Revenue Stream', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'BillToCustomer', 'Bill To Customer', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'LotNo', 'Batch No', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'UnitMeasure', 'Unit Measure', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.FormatDate(Expiry)', 'Expiry Date', 1, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'dbo.GetShortDate(Expiry)', 'Expiry Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0
exec uspInsertSearchColumns 'SearchINTPackageDetails', 'UserID', 'User id', 1, 1, 0,'2EQL', '3STR', 20, 1, 0
go

