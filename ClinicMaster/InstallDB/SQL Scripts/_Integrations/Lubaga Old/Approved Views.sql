-----------------------------------------------------------------------------------------------------------

------------VIEWS FOR NAV INTEGRATION


----------------------------------------------------------------------------------------------------
--------------------------------- IsPackageInvoice -------------------------------------------------
if exists (select * from sysobjects where name = 'IsPackageInvoice')
drop function IsPackageInvoice
go

create function IsPackageInvoice(@InvoiceNo varchar(20)) returns bit
with encryption as
begin

declare @HasActivePackage bit
declare @ItemCategory varchar(10)

set @ItemCategory = dbo.GetLookupDataID('ItemCategory', 'G')

if exists (select Top 1 ItemCategoryID from InvoiceDetails where InvoiceNo =@InvoiceNo and ItemCategoryID =@ItemCategory)
set @HasActivePackage = 1
else set @HasActivePackage = 0

return @HasActivePackage

end

go

--------Function GetOPDIssuingLocation----------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetOPDIssuingLocation')
drop function GetOPDIssuingLocation
go

create function GetOPDIssuingLocation( @VisitNo varchar(20), @ItemCategoryID varchar(10),@ItemCode varchar(20)) returns varchar(10)
with encryption as
begin 

declare @LocationID varchar(10)

begin
set @LocationID = (select LocationID from ItemsEXT where VisitNo = @VisitNo 
		and ItemCode= @ItemCode and ItemCategoryID= @ItemCategoryID)
end

set @LocationID = isnull(@LocationID,'')

return @LocationID
end

go

-----------------------------------------------------------------------------------------------------------------
-----print dbo.GetOPDIssuingLocation('1300001008','7D','M231')
-----------------------------------------------------------------------------------------------------------------
--------Function FormatDateTimeCustom--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'FormatDateTimeCustom')
	drop function FormatDateTimeCustom
go

create function FormatDateTimeCustom(@DateTime smalldatetime,@Format varchar(20)) returns varchar(100)
with encryption as

begin
declare @NewDateTime varchar(100)

if isdate(@DateTime) = 1
	begin
		set @NewDateTime =(FORMAT(@DateTime,@Format))
	end

return @NewDateTime
end
go

----------------------------------------------------------------------------------------------------------------------------
------- Print dbo.FormatDateTimeCustom(GetDate(),'dd/MM/yyyy')
------- Print dbo.FormatDateTimeCustom(GetDate(),'yyyy-MM-dd hh:mm tt')
------- Print dbo.FormatDateTimeCustom(GetDate(),'MM-dd-yyyy')
------- Print dbo.FormatDateTimeCustom(GetDate(),'hh:mm:ss')
------- Print dbo.FormatDateTimeCustom(GetDate(),'hh:mm:ss tt')
------- Print dbo.FormatDateTimeCustom(GetDate(),'dddd, MMMM, yyyy')

----------------------------------------------------------------------------------------------------

-------------------------CountInvoiceLines-------------------------------

if exists (select * from sysobjects where name = 'CountInvoiceLines')
drop function CountInvoiceLines
go

create function CountInvoiceLines (@InvoiceNo varchar(20)) returns Int
with encryption as

begin

declare @InvoiceCountNo Int

set @InvoiceCountNo= (select count(InvoiceNo) from InvoiceDetails where InvoiceNo=@InvoiceNo)

set @InvoiceCountNo= isnull(@InvoiceCountNo,0)

return @InvoiceCountNo

end

go


----------------------------------------------------------------------------------------------
-----    print dbo.CountInvoiceLines('1700005001')
----------------------------------------------------------------------------------------------

-------------------------IPDCountInvoiceLines-------------------------------

if exists (select * from sysobjects where name = 'IPDCountInvoiceLines')
drop function IPDCountInvoiceLines
go

create function IPDCountInvoiceLines (@ExtraBillNo varchar(20)) returns Int
with encryption as

begin

declare @InvoiceCountNo Int

set @InvoiceCountNo= (select count(ExtraBillNo) from ExtraBillItems where ExtraBillNo=@ExtraBillNo)

set @InvoiceCountNo= isnull(@InvoiceCountNo,0)

return @InvoiceCountNo

end

go


----------------------------------------------------------------------------------------------
-----    print dbo.IPDCountInvoiceLines('1303065001')
----------------------------------------------------------------------------------------------



------------ PatientsINTView  -----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'PatientsINTView')
	drop view PatientsINTView
go

create view PatientsINTView
with encryption 
as 
	select UPPER(SUBSTRING(Patients.PatientNo, 1, 3)) + '-' + UPPER(SUBSTRING(Patients.PatientNo, 4, 50)) as PatientNo,NOKName,NOKPhone, NOKRelationship, BirthDate,dbo.GetAge(BirthDate, getdate()) as Age,
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,GenderID, dbo.GetLookupDataDes(GenderID) as Gender,Phone, Address,DefaultBillModesID,
(case when (DefaultBillNo) ='CASH' then (SUBSTRING(Patients.PatientNo, 1, 3) + '-' + SUBSTRING(Patients.PatientNo, 4, 50)) else
	 case when LEN(DefaultBillNo)> 1 then (SUBSTRING(DefaultBillNo, 1, 4) + '-' + SUBSTRING(DefaultBillNo, 5, 50)) end end ) as BillToCustomer, 
(case when (DefaultBillModesID) ='17C' then 'Cash' else 'Insurance' end) as PostingGroup,
	(case when (DefaultBillModesID) ='17C' then 'General' else 'Private' end) as PriceGroup, SyncStatus

   from Patients inner join PatientsINT on Patients.PatientNo=PatientsINT.PatientNo and SyncStatus= 0 
go

----------------------------------------------------------------MannualIssuedInventoryINTView




if exists (select * from sysobjects where name = 'MannualIssuedInventoryINTView')
	drop view MannualIssuedInventoryINTView
go
create view MannualIssuedInventoryINTView
with encryption 
as 
  
select Inventory.TranID as TranID,ItemCode,Quantity, dbo.GetLookupDataDes(ItemCategoryID) as ItemCategory, EntryModeID, 
substring(Details,0,50) as Details, dbo.GetLookupDataDes(StockTypeID) as StockType, 'CM' as LocationCode,
dbo.GetInventoryBatchNo(LocationID, ItemCategoryID, ItemCode) as BatchNo,
cast(dbo.GetInventoryExpiryDate(LocationID, ItemCategoryID, ItemCode) as date) as ExpiryDate, dbo.GetUnitMeasure(ItemCategoryID, ItemCode) as UnitMeasure,
ShipStatus, LoginID
from Inventory
inner join InventoryINT on InventoryINT.TranID=Inventory.TranID and StockTypeID=dbo.GetLookupDataID('StockType', 'I') and Agent='NAV'
and EntryModeID=dbo.GetLookupDataID('EntryMode', 'MAN')
where ShipStatus=0 and Agent ='NAV'
go



/*
select * from MannualIssuedInventoryINTView
select * from PatientsINTView
select * from InventoryINT
select * from ExtraBillINT
select * from ExtraBillINTView

*/


------------------------------------------ResourcesINTView´----------------------------------------

if exists (select * from sysobjects where name = 'ResourcesINTView')
	drop view ResourcesINTView
go
create view ResourcesINTView
with encryption 
as 
  
	select code as ItemCode, Description, ItemCategoryID, dbo.GetLookupDataDes(ItemCategoryID) as ItemCategory,
	 Cost as UnitCost, Price as UnitPrice,(case when (ItemCategoryID) =dbo.GetLookupDataID('ItemCategory', 'S') then 
	 (select RevenueStreamCode from Services where ServiceCode=Code) 
	 else case when (ItemCategoryID) = dbo.GetLookupDataID('ItemCategory', 'E')  then (select RevenueStreamCode from ExtraChargeItems where ExtraItemCode=Code) 
	 else ItemCategoryID end end) as RevenueStream, SyncStatus
   from ResourcesINT
   where SyncStatus=0 and Agent='NAV' and not (ItemCategoryID= dbo.GetLookupDataID('ItemCategory', 'D') or ItemCategoryID=dbo.GetLookupDataID('ItemCategory', 'C'))

go

---select * from ResourcesINTView

-----------------------------   InventoryItemsINTView ---------------------------------------------------------------

if exists (select * from sysobjects where name = 'InventoryItemsINTVIew')
	drop view InventoryItemsINTVIew
go
create view InventoryItemsINTVIew
with encryption 
as 
  
	select Code, Description, ItemCategoryID, dbo.GetLookupDataDes(ItemCategoryID) as ItemCategory, Cost as UnitCost, Price as UnitPrice, SyncStatus
   from ResourcesINT where SyncStatus=0 and Agent='NAV' and  (ItemCategoryID= dbo.GetLookupDataID('ItemCategory', 'D') or
    ItemCategoryID=dbo.GetLookupDataID('ItemCategory', 'C'))
go



------------------------------------------------------------------------------------------------------------------------
--------------------------------     Invoices   ------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTOPDInvoicesHeader')
	drop view INTOPDInvoicesHeader
go

create view INTOPDInvoicesHeader
with encryption
as 
select UPPER(SUBSTRING(visits.PatientNo, 1, 3)) + '-' + UPPER(SUBSTRING(visits.PatientNo, 4, 50))  as PatientID, Invoices.InvoiceNo,UPPER(visits.VisitNo) as RegistrationNo,
(Invoices.RecordDateTime) as TransactionDate,
Invoices.loginID as userid,dbo.GetLookupDataDes(VisitTypeID) as PatientType,MemberCardNo as MTO,'OPD' as RevenueStream,
(case when LEN(AssociatedBillNo)> 1 then UPPER(SUBSTRING(AssociatedBillNo, 1, 4)) + '-' + UPPER(SUBSTRING(AssociatedBillNo, 5, 50))
 else case when LEN(InsuranceNo) > 1 then UPPER(SUBSTRING(InsuranceNo, 1, 4) + '-' + UPPER(SUBSTRING(InsuranceNo, 5, 50)))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
  else 
UPPER(SUBSTRING(Patients.PatientNo, 1, 3) + '-' + SUBSTRING(Patients.PatientNo, 4, 50))
 end  end end) AS BillToCustomer,dbo.CountInvoiceLines(Invoices.InvoiceNo) as InvoiceCount,

InvoiceheadersINT.SyncStatus
from Invoices
inner join InvoiceheadersINT on InvoiceheadersINT.InvoiceNo = Invoices.InvoiceNo
inner join Visits on Invoices.PayNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
WHERE VisitTypeID = dbo.GetLookupDataID('VisitType', 'OPD') and InvoiceheadersINT.SyncStatus ='0'  
and dbo.IsPackageInvoice(Invoices.InvoiceNo)=0
AND PayTypeID ='47CAS' and dbo.CountInvoiceLines(Invoices.InvoiceNo) >0

go


--------------------- INTOPDInvoicesDetails-----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTOPDInvoicesDetails')
	drop view INTOPDInvoicesDetails
go

create view INTOPDInvoicesDetails
with encryption 
as 

select SUBSTRING(visits.PatientNo, 1, 3) + '-' + SUBSTRING(visits.PatientNo, 4, 50) as PatientID,(visits.VisitNo) as RegistrationNo,
(Invoices.RecordDateTime) as TransactionDate
,dbo.GetLookupDataDes(VisitTypeID) as PatientType,MemberCardNo as MTO,'OPD' as RevenueStream,
InvoiceDetails.ItemCode as ItemCode,
(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
 else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
  else 
(SUBSTRING(Patients.PatientNo, 1, 3) + '-' + SUBSTRING(Patients.PatientNo, 4, 50))
 end  end end) AS BillToCustomer,
dbo.FormatDate(invoiceDate) as PayDate,Amount,dbo.GetItemName(InvoiceDetails.ItemCategoryID, InvoiceDetails.ItemCode) as PaymentFor,
Invoices.LoginID as UserID,Discount as PaymentDiscount,
(Invoices.InvoiceNo) as InvoiceNo,
InvoiceDetails.Quantity as InvoicedQuantities,UnitMeasure,InvoiceDetails.UnitPrice,
dbo.GetInventoryBatchNo(null, Items.ItemCategoryID, Items.ItemCode) as BatchNo,InvoiceDetails.ItemCategoryID,
dbo.GetInventoryExpiryDate(null, Items.ItemCategoryID, Items.ItemCode) as ExpiryDate,PackageNo,InvoicesDetailsINT.SyncStatus
from InvoiceDetails
inner join Invoices on Invoices.InvoiceNo = InvoiceDetails.InvoiceNo
inner join Items on Items.VisitNo = InvoiceDetails.VisitNo
inner join InvoicesDetailsINT on Invoices.InvoiceNo = InvoicesDetailsINT.InvoiceNo 
and Items.ItemCode = InvoiceDetails.ItemCode and Items.ItemCategoryID = InvoiceDetails.ItemCategoryID
inner join Visits on Items.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
WHERE VisitTypeID = dbo.GetLookupDataID('VisitType', 'OPD') and InvoicesDetailsINT.SyncStatus ='0' 
and InvoiceDetails.ItemCategoryID <> '7G'
AND PayTypeID ='47CAS'

go
-------------------------------------------------------------------------------------------------------------------





--------------------- INTIPDExtraBills-----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTIPDExtraBillsHeaders')
	drop view INTIPDExtraBillsHeaders
go

create view INTIPDExtraBillsHeaders
with encryption
as
select SUBSTRING(visits.PatientNo, 1, 3) + '-' + SUBSTRING(visits.PatientNo, 4, 50) as PatientID,(ExtraBills.ExtraBillNo) as InvoiceNo,
(visits.VisitNo) as RegistrationNo,
(ExtraBills.RecordDateTime) as TransactionDate,
ExtraBills.loginID as userid,'IPD' as PatientType,MemberCardNo as MTO,'InPatient' as RevenueStream,

UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
 else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
 else (SUBSTRING(Patients.PatientNo, 1, 3) + '-' + SUBSTRING(Patients.PatientNo, 4, 50))end  end end) AS BillToCustomer,
 dbo.IPDCountInvoiceLines(ExtraBills.ExtraBillNo) as InvoiceCount,SyncStatus
from ExtraBills
inner join Visits on ExtraBills.VisitNo = Visits.VisitNo and Visits.PackageNo is null
inner join ExtraBillsINT on ExtraBills.ExtraBillNo= ExtraBillsINT.ExtraBillNo and SyncStatus=0 and ExtraBillsINT.AgentID='NAV'
inner join Patients on Visits.PatientNo = Patients.PatientNo AND ExtraBills.RecordDateTime > '2018-04-16 12:00:00'


go

----------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTIPDExtraBillItemsDetails')
	drop view INTIPDExtraBillItemsDetails
go
create view INTIPDExtraBillItemsDetails
with encryption 
as 
  
	select UPPER(SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50)) as PatientID, ExtraBillItems.ExtraBillNo as InvoiceNo,
	ExtraBills.VisitNo,(ExtraBills.RecordDateTime) as TransactionDate,
	ExtraBillItems.ItemCategoryID,ExtraBillItems.ItemCode, UnitPrice,Quantity,'InPatient' as RevenueStream,
	UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
    else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
    else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
    else (SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50))end  end end) AS BillToCustomer,
	dbo.GetInventoryBatchNo('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as BatchNo,UnitMeasure,
	dbo.GetInventoryExpiryDate('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExpiryDate,ExtraBillItems.LoginID as UserID,SyncStatus 
    from ExtraBillItems
    inner join ExtraBillItemsINT on ExtraBillItems.ExtraBillNo= ExtraBillItemsINT.ExtraBillNo and ExtraBillItems.ItemCode=ExtraBillItemsINT.ItemCode 
	and ExtraBillItems.ItemCategoryID =ExtraBillItemsINT.ItemCategoryID
	 and SyncStatus=0 and Agent='NAV'
   inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
   --inner join Visits on Visits.VisitNo= Extrabills.VisitNo and Visits.PackageNo is null AND ExtraBills.RecordDateTime > '2018-04-16 12:00:00'
    inner join Visits on Visits.VisitNo= Extrabills.VisitNo and ExtraBills.RecordDateTime > '2018-04-16 12:00:00'
go


-----------------------------------------------------------------------------------------------------------
------------ INTPaymentsView  -----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTPaymentsView')
	drop view INTPaymentsView
go

create view INTPaymentsView
with encryption
as 

SELECT  UPPER(SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50)) as PatientID,
(Payments.[RecordDateTime]) as PaymentDate,

(case when UseAccountBalance =1 then (AmountTendered - Change) 
else dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo ) end) as Amount,

(dbo.GetTotalDiscount(PayTypeID, VisitTypeID, Payments.ReceiptNo)) As Discount,
InvoiceNo as PaymentFor,Payments.[LoginID] as UserID,Payments.ReceiptNo,InvoiceNo,SyncStatus,VisitTypeID,
PackageNo,dbo.GetBillCustomerName(AssociatedBillNo) as AssociatedBill FROM Payments
inner join Visits On Visits.VisitNo =Payments.PayNo
Inner join ReceiptInvoiceDetails on ReceiptInvoiceDetails.ReceiptNo = Payments.ReceiptNo
inner join PaymentsINT on Payments.ReceiptNo = PaymentsINT.ReceiptNo where SyncStatus =0 and AgentID ='NAV'

go

--------------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTRefundsView')
	drop view INTRefundsView
go
create view INTRefundsView
with encryption 
as 

select UPPER(SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50)) as PatientID,ReceiptInvoiceDetails.InvoiceNo,
PackageNo,ItemCategoryID,
 Refunds.ReceiptNo,ItemCode,RefundDetails.Quantity,RefundDetails.UnitPrice,Refunds.LoginID as UserID,dbo.GetReceiptRecordDateTime(Refunds.ReceiptNo) as RefundDate,'OPD' as PatientType,
 UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
 else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
 else (SUBSTRING(Visits.PatientNo, 1, 3) + '-' + SUBSTRING(Visits.PatientNo, 4, 50))end  end end) AS BillToCustomer,SyncStatus 
 from Refunds
inner join ReceiptInvoiceDetails on Refunds.ReceiptNo =ReceiptInvoiceDetails.ReceiptNo
inner join RefundDetails on RefundDetails.ReceiptNo =Refunds.ReceiptNo
inner join Invoices on Invoices.InvoiceNo= ReceiptInvoiceDetails.InvoiceNo
inner join Visits on Visits.VisitNo =invoices.PayNo


inner join INTRefunds on INTRefunds.ReceiptNo = Refunds.ReceiptNo where SyncStatus =0 and AgentID ='NAV'

--select UPPER(SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50)) as PatientID,
--(case when (VisitTypeID) ='110OPD' then dbo.GetItemInvoiceNo(Payments.PayNo,ItemCategoryID,ItemCode)  
--else dbo.GetIPDItemInvoiceNo(Payments.PayNo,ItemCategoryID,ItemCode) end) as InvoiceNo,
--PackageNo,ItemCategoryID,
-- Refunds.ReceiptNo,ItemCode,Quantity,UnitPrice,Refunds.LoginID as UserID,INTRefunds.RecordDateTime as RefundDate, (case when (VisitTypeID) ='110OPD' then 'OPD' else 'IPD' end) as PatientType,
-- UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
-- else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
-- else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
-- else (SUBSTRING(Visits.PatientNo, 1, 3) + '-' + SUBSTRING(Visits.PatientNo, 4, 50))end  end end) AS BillToCustomer,SyncStatus from Refunds
--inner join RefundDetails on RefundDetails.ReceiptNo =Refunds.ReceiptNo
--inner join Payments on Payments.ReceiptNo=RefundDetails.ReceiptNo
--inner join Visits on Visits.VisitNo =Payments.PayNo
--inner join INTRefunds on INTRefunds.ReceiptNo = Refunds.ReceiptNo where SyncStatus =0 and AgentID ='NAV'
go

---------------------------------------------------------------------------------------------------------------------------


--------------------- INTPackageHeaders------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTPackageHeaders')
	drop view INTPackageHeaders
go

create view INTPackageHeaders
with encryption
as
select UPPER(SUBSTRING(visits.PatientNo, 1, 3) + '-' + SUBSTRING(visits.PatientNo, 4, 50)) as PatientID,(visits.VisitNo) as InvoiceNo,
(visits.VisitNo) as RegistrationNo,
(Visits.RecordDateTime) as TransactionDate,
dbo.GetLoginsFullName(Visits.loginID) as UserName,'OPD' as PatientType,Packages.PackageNo as PackageNo,Packages.RevenueStreamCode as RevenueStream,

UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
 else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
 else (SUBSTRING(Visits.PatientNo, 1, 3) + '-' + SUBSTRING(Visits.PatientNo, 4, 50))end  end end) AS BillToCustomer,
 MemberCardNo as MTO,SyncStatus
from Visits
inner join PackageHeadersINT on PackageHeadersINT.VisitNo = Visits.VisitNo
inner join Packages on Packages.PackageNo= Visits.PackageNo
inner join RevenueStreams on RevenueStreams.RevenueStreamCode = Packages.RevenueStreamCode
where PackageHeadersINT.SyncStatus=0 and PackageHeadersINT.AgentID='NAV'

go


	--------------------- INTPackageDetails------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTPackageDetails')
	drop view INTPackageDetails
go

create view INTPackageDetails
with encryption
as
	
select PackageConsumption.VisitNo as InvoiceNo, PackageConsumption.RecordDateTime as TransactionDate,
UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
else (SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50))end  end end) AS BillToCustomer,
PackageConsumption.ItemCode as No,dbo.GetOPDIssuingLocation(PackageConsumption.VisitNo,PackageConsumption.ItemCategoryID,PackageConsumption.ItemCode) as LocationCode,PackageConsumption.Quantity as QuantityInvoiced,dbo.GetUnitMeasure(PackageConsumption.ItemCategoryID,PackageConsumption.ItemCode) as UnitMeasure,
0 as IssuePrice,dbo.GetConsumptionUnitPrice(PackageConsumption.VisitNo,PackageConsumption.ItemCode,PackageConsumption.ItemCategoryID) as UnitPrice,

0 as Discount,dbo.GetInventoryBatchNo('', PackageConsumption.ItemCategoryID, PackageConsumption.ItemCode) as LotNo,
dbo.GetInventoryExpiryDate('', PackageConsumption.ItemCategoryID, PackageConsumption.ItemCode) as Expiry,
PackageConsumption.ItemCategoryID as ItemCategoryCode,
SyncStatus 
from PackageConsumption
inner join Visits on PackageConsumption.VisitNo= Visits.VisitNo
inner join PackageDetailsINT on PackageConsumption.ItemCode = PackageDetailsINT.ItemCode and PackageDetailsINT.ItemCategoryID=PackageDetailsINT.ItemCategoryID and
PackageDetailsINT.TransactionNo=PackageConsumption.VisitNo

where SyncStatus =0 and AgentID ='NAV'

go



--------------------- INTDepositDetails------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTDepositDetails')
drop view INTDepositDetails
go

create view INTDepositDetails
with encryption
as

SELECT (case when AccountBillNo LIKE 'CUST%' then UPPER( SUBSTRING(AccountBillNo, 1, 4) + '-' + SUBSTRING(AccountBillNo, 5, 50)) 
else UPPER( SUBSTRING(AccountBillNo, 1, 3) + '-' + SUBSTRING(AccountBillNo, 4, 50) ) end) as PatientID
,Accounts.[RecordDateTime] as PaymentDate, Amount,
dbo.GetLookupDataDes(AccountGroupID) as PaymentFor,Accounts.[LoginID] as UserID,
TranNo as ReceiptNo,dbo.GetLookupDataDes(AccountActionID) as AccountAction,SyncStatus
FROM Accounts
inner join DepositsINT on Accounts.TranNo = DepositsINT.TransNo
where DepositsINT.SyncStatus=0 and DepositsINT.AgentID='NAV' and AccountActionID ='19CR'

go

--------------------------------------------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTManualDebits')
drop view INTManualDebits
go

create view INTManualDebits
with encryption
as
SELECT (case when AccountBillNo LIKE 'CUST%' then UPPER( SUBSTRING(AccountBillNo, 1, 4) + '-' + SUBSTRING(AccountBillNo, 5, 50)) 
else UPPER( SUBSTRING(AccountBillNo, 1, 3) + '-' + SUBSTRING(AccountBillNo, 4, 50) ) end) as PatientID,
Accounts.[RecordDateTime] as PaymentDate, -(Amount) as Amount,
dbo.GetLookupDataDes(AccountGroupID) as PaymentFor,Accounts.[LoginID] as UserID,
TranNo as ReceiptNo,dbo.GetLookupDataDes(AccountActionID) as AccountAction,SyncStatus
FROM Accounts
inner join DepositsINT on Accounts.TranNo = DepositsINT.TransNo
where DepositsINT.SyncStatus=0 and DepositsINT.AgentID='NAV' and AccountActionID ='19DR' and EntryModeID='46MAN'
go

--------------------------------------------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTDepositSuspense')
drop view INTDepositSuspense
go

create view INTDepositSuspense
with encryption
as

SELECT (case when AccountBillNo LIKE 'CUST%' then UPPER( SUBSTRING(AccountBillNo, 1, 4) + '-' + SUBSTRING(AccountBillNo, 5, 50)) 
else UPPER( SUBSTRING(AccountBillNo, 1, 3) + '-' + SUBSTRING(AccountBillNo, 4, 50) ) end) as PatientID,Accounts.[RecordDateTime] as PaymentDate, -(Amount) as Amount,
dbo.GetLookupDataDes(AccountGroupID) as PaymentFor,Accounts.[LoginID] as UserID,
TranNo as ReceiptNo,dbo.GetLookupDataDes(AccountActionID) as AccountAction,SyncStatus
FROM Accounts
inner join DepositsINT on Accounts.TranNo = DepositsINT.TransNo
where DepositsINT.SyncStatus=0 and DepositsINT.AgentID='NAV' and  AccountActionID ='19CR' AND AccountBillNo ='SUSP'

go


------------------------------------------------------------------------------------------------------------------------
--------------------------------     CreditNote   ------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------



--------Function HasPendingCreditNoteNo ---------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'HasPendingCreditNoteNo')
drop function HasPendingCreditNoteNo
go

create function HasPendingCreditNoteNo(@InvoiceNo varchar(20)) returns bit
with encryption as

begin

declare @Exists bit

--------------------------------------------------------------------------------------------------------------
 if exists(select  CreditNoteINT.CreditNoteNo from CreditNoteINT
 inner join CreditNote on CreditNote.CreditNoteNo=CreditNoteINT.CreditNoteNo 
  where SyncStatus=0 and InvoiceNo=@InvoiceNo) 
--------------------------------------------------------------------------------------------------------------
set @Exists =1
else set @Exists =0
set @Exists= isnull(@Exists,0)
return @Exists
end

go
-------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------


--------Function HasPendingExtraBillNo ---------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'HasPendingExtraBillNo')
drop function HasPendingExtraBillNo
go

create function HasPendingExtraBillNo(@ExtraBillNo varchar(20)) returns bit
with encryption as

begin

declare @Exists bit

--------------------------------------------------------------------------------------------------------------
 if exists(select top 1 ExtraBillNo from InvoiceExtraBillItems
 inner join CreditNote on CreditNote.InvoiceNo=InvoiceExtraBillItems.InvoiceNo
 inner join CreditNoteINT on CreditNoteINT.CreditNoteNo=CreditNote.CreditNoteNo 
  where SyncStatus=0 and InvoiceExtraBillItems.ExtraBillNo=@ExtraBillNo) 
--------------------------------------------------------------------------------------------------------------
set @Exists =1
else set @Exists =0
set @Exists= isnull(@Exists,0)
return @Exists
end

go




---------------print dbo.HasPendingCreditNoteNo('17000008')


if exists (select * from sysobjects where name = 'INTOPDCreditNoteView')
	drop view INTOPDCreditNoteView
go

create view INTOPDCreditNoteView
with encryption
as 
select UPPER(SUBSTRING(visits.PatientNo, 1, 3)) + '-' + UPPER(SUBSTRING(visits.PatientNo, 4, 50))  as PatientID, Invoices.InvoiceNo,UPPER(visits.VisitNo) as RegistrationNo,
(Invoices.RecordDateTime) as TransactionDate,
Invoices.loginID as userid,dbo.GetLookupDataDes(VisitTypeID) as PatientType,MemberCardNo as MTO,'OPD' as RevenueStream,
(case when LEN(AssociatedBillNo)> 1 then UPPER(SUBSTRING(AssociatedBillNo, 1, 4)) + '-' + UPPER(SUBSTRING(AssociatedBillNo, 5, 50))
 else case when LEN(InsuranceNo) > 1 then UPPER(SUBSTRING(InsuranceNo, 1, 4) + '-' + UPPER(SUBSTRING(InsuranceNo, 5, 50)))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
  else 
UPPER(SUBSTRING(Patients.PatientNo, 1, 3) + '-' + SUBSTRING(Patients.PatientNo, 4, 50))
 end  end end) AS BillToCustomer,

CreditNoteINT.SyncStatus
from CreditNote
inner join Invoices on Invoices.InvoiceNo=CreditNote.InvoiceNo
inner join CreditNoteINT on CreditNoteINT.CreditNoteNo = CreditNote.CreditNoteNo
inner join Visits on Invoices.PayNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
WHERE VisitTypeID = dbo.GetLookupDataID('VisitType', 'OPD') and SyncStatus ='0'  and AgentID='NAV' 
go

--------------------- INTOPDInvoicesDetails-----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTOPDCreditNoteDetailsView')
	drop view INTOPDCreditNoteDetailsView
go

create view INTOPDCreditNoteDetailsView
with encryption 
as 

select SUBSTRING(visits.PatientNo, 1, 3) + '-' + SUBSTRING(visits.PatientNo, 4, 50) as PatientID,(visits.VisitNo) as RegistrationNo,(Invoices.RecordDateTime) as TransactionDate
,dbo.GetLookupDataDes(VisitTypeID) as PatientType,MemberCardNo as MTO,'OPD' as RevenueStream,
InvoiceDetails.ItemCode as ItemCode,
(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
 else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
  else 
(SUBSTRING(Patients.PatientNo, 1, 3) + '-' + SUBSTRING(Patients.PatientNo, 4, 50))
 end  end end) AS BillToCustomer,
invoiceDate as PayDate,Amount,dbo.GetItemName(InvoiceDetails.ItemCategoryID, InvoiceDetails.ItemCode) as PaymentFor,
Invoices.LoginID as UserID,Discount as PaymentDiscount,
(Invoices.InvoiceNo) as InvoiceNo,
InvoiceDetails.Quantity as InvoicedQuantities,UnitMeasure,InvoiceDetails.UnitPrice, 'CM' as LocationCode,
CreditNoteDetails.Quantity as ReversedQuantity, CreditNoteDetails.UnitPrice as ReversedPrice,
dbo.GetInventoryBatchNo(null, Items.ItemCategoryID, Items.ItemCode) as BatchNo,InvoiceDetails.ItemCategoryID,
dbo.GetInventoryExpiryDate(null, Items.ItemCategoryID, Items.ItemCode) as ExpiryDate,PackageNo,InvoicesDetailsINT.SyncStatus
from CreditNoteDetails
inner join InvoiceDetails on CreditNoteDetails.ItemCategoryID=InvoiceDetails.ItemCategoryID and CreditNoteDetails.ItemCode=InvoiceDetails.ItemCode 
inner join Invoices on Invoices.InvoiceNo = InvoiceDetails.InvoiceNo
inner join Items on Items.VisitNo = InvoiceDetails.VisitNo and Items.ItemCategoryID=InvoiceDetails.ItemCategoryID and Items.ItemCode=InvoiceDetails.ItemCode
inner join ItemsEXT on ItemsEXT.VisitNo=items.VisitNo and ItemsEXT.ItemCategoryID=Items.ItemCategoryID and ItemsEXT.ItemCode=Items.ItemCode
inner join InvoicesDetailsINT on Invoices.InvoiceNo = InvoicesDetailsINT.InvoiceNo 
and Items.ItemCode = InvoiceDetails.ItemCode and Items.ItemCategoryID = InvoiceDetails.ItemCategoryID
inner join Visits on Items.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
WHERE VisitTypeID = dbo.GetLookupDataID('VisitType', 'OPD') and InvoicesDetailsINT.SyncStatus ='0' and InvoiceDetails.UnitPrice=0 and InvoiceDetails.ItemCategoryID <> '7G'
go
-------------------------------------------------------------------------------------------------------------------


--------------------- INTIPDExtraBillsReversalHeaders-----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTIPDExtraBillsReversalHeaders')
	drop view INTIPDExtraBillsReversalHeaders
go

create view INTIPDExtraBillsReversalHeaders
with encryption
as
select distinct CreditNoteINT.CreditNoteNo as InvoiceNo,
(visits.VisitNo) as RegistrationNo,
(ExtraBills.RecordDateTime) as TransactionDate,
ExtraBills.loginID as userid,'IPD' as PatientType,MemberCardNo as MTO,'InPatient' as RevenueStream,

UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
 else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
 else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
 else (SUBSTRING(Patients.PatientNo, 1, 3) + '-' + SUBSTRING(Patients.PatientNo, 4, 50))end  end end) AS BillToCustomer,SyncStatus
from CreditNoteINT 
inner join CreditNote on CreditNoteINT.CreditNoteNo=CreditNote.CreditNoteNo
inner join Invoices on Invoices.InvoiceNo=CreditNote.InvoiceNo and Invoices.VisitTypeID='110IPD'
inner join ExtraBills on dbo.HasPendingExtraBillNo(ExtraBills.ExtraBillNo)=1
inner join Visits on ExtraBills.VisitNo = Visits.VisitNo and Visits.PackageNo is null
inner join Patients on Visits.PatientNo = Patients.PatientNo 

go


----------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTIPDExtraBillItemsDetailsReversal')
	drop view INTIPDExtraBillItemsDetailsReversal
go
create view INTIPDExtraBillItemsDetailsReversal
with encryption 
as 
  
	select distinct CreditNoteDetailsINT.CreditNoteNo as CreditNoteNo,UPPER(SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50)) as PatientID, ExtraBillItems.ExtraBillNo as InvoiceNo,
	ExtraBills.VisitNo,ExtraBills.RecordDateTime as TransactionDate,
	ExtraBillItems.ItemCategoryID,ExtraBillItems.ItemCode, ExtraBillItems.UnitPrice as BillUnitPrice,ExtraBillItems.Quantity as BilledQuantity,'InPatient' as RevenueStream,
	UPPER(case when LEN(AssociatedBillNo)> 1 then SUBSTRING(AssociatedBillNo, 1, 4) + '-' + SUBSTRING(AssociatedBillNo, 5, 50)
    else case when LEN(InsuranceNo) > 1 then(SUBSTRING(InsuranceNo, 1, 4) + '-' + SUBSTRING(InsuranceNo, 5, 50))
    else case when (BillNo) <>'CASH' then(SUBSTRING(BillNo, 1, 4) + '-' + SUBSTRING(BillNo, 5, 50))
    else (SUBSTRING(PatientNo, 1, 3) + '-' + SUBSTRING(PatientNo, 4, 50))end  end end) AS BillToCustomer,
	dbo.GetInventoryBatchNo('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as BatchNo,UnitMeasure,
	dbo.GetInventoryExpiryDate('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) 
	as ExpiryDate,ExtraBillItems.LoginID as UserID,SyncStatus,
	dbo.GetInvoiceReversedItemQuantity(InvoiceExtraBillItems.InvoiceNo,InvoiceExtraBillItems.ItemCategoryID,InvoiceExtraBillItems.ItemCode) as ReturnedQuantity,
	dbo.GetInvoiceReversedItemAmount(InvoiceExtraBillItems.InvoiceNo,InvoiceExtraBillItems.ItemCategoryID,InvoiceExtraBillItems.ItemCode) as ReturnedAmount,
	(InvoiceExtraBillItems.Quantity-dbo.GetInvoiceReversedItemQuantity(InvoiceExtraBillItems.InvoiceNo,InvoiceExtraBillItems.ItemCategoryID,InvoiceExtraBillItems.ItemCode)) as QuantityBalance
	 from CreditNoteDetailsINT
	inner Join CreditNoteDetails on CreditNoteDetails.CreditNoteNo=CreditNoteDetailsINT.CreditNoteNo 
	and CreditNoteDetails.ItemCategoryID=CreditNoteDetailsINT.ItemCategoryID and CreditNoteDetails.ItemCode=CreditNoteDetailsINT.ItemCode
	inner join CreditNote on CreditNote.CreditNoteNo=CreditNoteDetails.CreditNoteNo
	
	inner join InvoiceExtraBillItems on CreditNote.InvoiceNo=InvoiceExtraBillItems.InvoiceNo 
	and InvoiceExtraBillItems.ItemCategoryID=CreditNoteDetailsINT.ItemCategoryID 
	and InvoiceExtraBillItems.ItemCode=CreditNoteDetailsINT.ItemCode and dbo.HasPendingCreditNoteNo(InvoiceExtraBillItems.InvoiceNo)=1
	
	inner join ExtraBillItems on InvoiceExtraBillItems.ExtraBillNo=ExtraBillItems.ExtraBillNo and CreditNoteDetailsINT.ItemCategoryID=ExtraBillItems.ItemCategoryID
   inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
   inner join Visits on Visits.VisitNo= Extrabills.VisitNo and Visits.PackageNo is null
   where CreditNoteDetailsINT.SyncStatus=0 and CreditNoteDetailsINT.AgentID='NAV'  and CreditNoteDetailsINT.ItemCode=ExtraBillItems.ItemCode  
   and dbo.HasPendingCreditNoteNo(CreditNote.InvoiceNo)=1
go



----if exists (select * from sysobjects where name = 'INTBacklogInvoicesHeader')
----	drop view INTBacklogInvoicesHeader
----go

----create view INTBacklogInvoicesHeader
----with encryption
----as 
----SELECT PatientID,InvoiceNo,RegistrationNo,TransactionDate,userid,PatientType, MTO,RevenueStream,
----BillToCustomer,SyncStatus
----FROM INTBacklog
----WHERE SyncStatus ='0'
----go


------------ StockTakeView  -----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'StockTakeView')
	drop view StockTakeView
go

create view StockTakeView
with encryption 
as 
 select dbo.GetShortDate(RecordDateTime) as PostingDate, ItemCode as ItemNo, ItemCategoryID, 
 'CM' as LocationCode, dbo.GetStockTakeQuantity(PSCNo, ItemCategoryID, ItemCode) as Quantity, 
 dbo.GetInventoryBatchNo('', ItemCategoryID, ItemCode) as LotNo, 
 dbo.GetInventoryExpiryDate('', ItemCategoryID, ItemCode) as ExpiryDate,
  dbo.GetUnitMeasure(ItemCategoryID, ItemCode) as UnitsOfMeasure, 
 'STOCKCOUNT' as ReasonCode,  PSCNo as DocumentNo, SyncStatus as Read_Status

   from INTStockTake where SyncStatus= 0 
go


select * from StockTakeView