
/***************************************************************
This Script is a property of ClinicMaster INTERNATIONAL
Un authorised use or ammendment is not permitted
-- Last updated 10/02/2016 by Wilson Kutegeka
***************************************************************/

use ClinicMaster
go

-------------------------------------------------------------------------------------------------
-------------- IncomeSummaries ------------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIncomeSummaries')
	drop proc uspGetIncomeSummaries
go

create proc uspGetIncomeSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin

	declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	
	declare @COPAYVALUE varchar(3) 
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
	----------------------------------------------------------------------------
	set @COPAYVALUE = 'CPV'
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], 'Services' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,	
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items 
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @ServiceID and items.RecordDateTime between @StartDate and @EndDate
union
	select 2 as [No], 'Pharmacy' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @DrugID and items.RecordDateTime between @StartDate and @EndDate
union
	select 3 as [No], 'Consumables' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @ConsumableID and items.RecordDateTime between @StartDate and @EndDate
union
	select 4 as [No], 'Laboratory' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @TestID and items.RecordDateTime between @StartDate and @EndDate
union
	select 5 as [No], 'Radiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @RadiologyID and items.RecordDateTime between @StartDate and @EndDate
union
	select 6 as [No], 'Pathology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @PathologyID and items.RecordDateTime between @StartDate and @EndDate
union
	select 7 as [No], 'Dental' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @DentalID and items.RecordDateTime between @StartDate and @EndDate
union
	select 8 as [No], 'Theatre' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @TheatreID and items.RecordDateTime between @StartDate and @EndDate
union
	select 9 as [No], 'Optical' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @OpticalID and items.RecordDateTime between @StartDate and @EndDate
union
	select 10 as [No], 'Procedures' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @ProcedureID and items.RecordDateTime between @StartDate and @EndDate
union
	select 11 as [No], 'Extra Charge(s)' as IncomeCategory, 
	sum(case when (Items.ItemCode = @COPAYVALUE and Items.UnitPrice < 0) then 0 else (Items.Quantity * Items.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @ExtrasID and items.RecordDateTime between @StartDate and @EndDate
union
	select 12 as [No], 'Grand Total' as IncomeCategory, 
	sum(case when (Items.ItemCategoryID = @ExtrasID and Items.ItemCode = @COPAYVALUE and Items.UnitPrice < 0) then 0 else (Items.Quantity * Items.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where items.RecordDateTime between @StartDate and @EndDate
end
return 0
go

-- exec uspGetIncomeSummaries '1 May 2015', '3 May 2015'

-------------------------------------------------------------------------------------------------
-------------- ExtraChargeSummaries -------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetExtraChargeSummaries')
	drop proc uspGetExtraChargeSummaries
go

create proc uspGetExtraChargeSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin

	declare @ExtrasID varchar(10)
	declare @COPAYVALUE varchar(3) 
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
	set @COPAYVALUE = 'CPV'
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode) as ExtraChargeCategory, 
	sum(case when (Items.ItemCode = @COPAYVALUE and Items.UnitPrice < 0) then 0 else (Items.Quantity * Items.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @ExtrasID and items.RecordDateTime between @StartDate and @EndDate
	group by dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode)
union
	select 2 as [No], 'Grand Total' as ExtraChargeCategory, 
	sum(case when (Items.ItemCode = @COPAYVALUE and Items.UnitPrice < 0) then 0 else (Items.Quantity * Items.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.ItemCategoryID = @ExtrasID and items.RecordDateTime between @StartDate and @EndDate
	order by [No], [ExtraChargeCategory]
end
return 0
go

-- exec uspGetExtraChargeSummaries '1 Oct 2012', '31 Oct 2012'

-------------------------------------------------------------------------------------------------
-------------- IncomeSummariesByBills -----------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIncomeSummariesByBills')
	drop proc uspGetIncomeSummariesByBills
go

create proc uspGetIncomeSummariesByBills(
@StartDate smalldatetime,
@EndDate smalldatetime,
@BillModesID varchar(10),
@BillNo varchar(20),
@CompanyNo varchar(20) = null
) with encryption as

begin
	
	declare @ErrorMSG varchar(200)

	declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @CashBillModes varchar(100)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
		
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
		
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @CashBillModes = dbo.GetLookupDataDes(@CashBillModesID)
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
			
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------
	
if (@BillModesID = @CashBillModesID)
	begin
		set @ErrorMSG = 'Bill mode cash not supported!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else

if (@BillModesID = @AccountBillModesID) and (@BillNo = @CashBillModes)
	begin
		set @ErrorMSG = 'Bill No for Bill Mode Account can''t be Cash!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else
	if (@BillModesID = @AccountBillModesID) -- Bill Account 
		 if not(@CompanyNo is null)
			begin
				select 1 as [No], 'Services' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items 
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ServiceID and items.RecordDateTime between @StartDate and @EndDate				
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 2 as [No], 'Pharmacy' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @DrugID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 3 as [No], 'Consumables' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ConsumableID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 
			union
				select 4 as [No], 'Laboratory' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @TestID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 5 as [No], 'Radiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @RadiologyID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 6 as [No], 'Pathology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @PathologyID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 
			union
				select 7 as [No], 'Dental' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @DentalID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 8 as [No], 'Theatre' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @TheatreID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 9 as [No], 'Optical' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @OpticalID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 10 as [No], 'Procedures' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ProcedureID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 12 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			end
		else
		begin
			select 1 as [No], 'Services' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items 
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ServiceID and Items.RecordDateTime between @StartDate and @EndDate	
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 2 as [No], 'Pharmacy' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @DrugID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 	
		union
			select 3 as [No], 'Consumables' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ConsumableID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 4 as [No], 'Laboratory' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @TestID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 5 as [No], 'Radiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @RadiologyID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 			
		union
			select 6 as [No], 'Pathology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @PathologyID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 	
		union
			select 7 as [No], 'Dental' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @DentalID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 8 as [No], 'Theatre' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @TheatreID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 9 as [No], 'Optical' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @OpticalID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 10 as [No], 'Procedures' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ProcedureID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 12 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		end
	else if (@BillModesID = @InsuranceBillModesID) -- Bill Insurance
		 if not(@CompanyNo is null)
			begin
				select 1 as [No], 'Services' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items 
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ServiceID and Items.RecordDateTime between @StartDate and @EndDate	
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 2 as [No], 'Pharmacy' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @DrugID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 3 as [No], 'Consumables' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ConsumableID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 4 as [No], 'Laboratory' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @TestID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 5 as [No], 'Radiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @RadiologyID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo				
			union
				select 6 as [No], 'Pathology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @PathologyID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 7 as [No], 'Dental' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @DentalID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 8 as [No], 'Theatre' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @TheatreID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 9 as [No], 'Optical' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @OpticalID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 10 as [No], 'Procedures' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ProcedureID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 12 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			end
		else
		begin
			select 1 as [No], 'Services' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items 
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ServiceID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 2 as [No], 'Pharmacy' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @DrugID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 3 as [No], 'Consumables' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ConsumableID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 4 as [No], 'Laboratory' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @TestID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 5 as [No], 'Radiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @RadiologyID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 6 as [No], 'Pathology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @PathologyID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 7 as [No], 'Dental' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @DentalID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 8 as [No], 'Theatre' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @TheatreID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 9 as [No], 'Optical' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @OpticalID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 10 as [No], 'Procedures' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ProcedureID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 12 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		end	
	end
return 0
go

-- exec uspGetIncomeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', 'GMC'
-- exec uspGetIncomeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', '100041A'
-- exec uspGetIncomeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', '100041A', '100105A'
-- exec uspGetIncomeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17I', 'CMC'
-- exec uspGetIncomeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17I', 'CMC', 'URA'
-- exec uspGetIncomeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', 'CASH'
-- exec uspGetIncomeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17C', 'CASH'

-------------------------------------------------------------------------------------------------
-------------- ExtraChargeSummariesByBills ------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetExtraChargeSummariesByBills')
	drop proc uspGetExtraChargeSummariesByBills
go

create proc uspGetExtraChargeSummariesByBills(
@StartDate smalldatetime,
@EndDate smalldatetime,
@BillModesID varchar(10),
@BillNo varchar(20),
@CompanyNo varchar(20) = null
) with encryption as

begin

	declare @ErrorMSG varchar(200)
	
	declare @ExtrasID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @CashBillModes varchar(100)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
	
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @CashBillModes = dbo.GetLookupDataDes(@CashBillModesID)
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------
	
if (@BillModesID = @CashBillModesID)
	begin
		set @ErrorMSG = 'Bill mode cash not supported!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else

if (@BillModesID = @AccountBillModesID) and (@BillNo = @CashBillModes)
	begin
		set @ErrorMSG = 'Bill No for Bill Mode Account can''t be Cash!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else
	if (@BillModesID = @AccountBillModesID) -- Bill Account 
		 if not(@CompanyNo is null)
			begin				
				select 1 as [No], dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode) as ExtraChargeCategory, 
				sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate				
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
				group by dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode)
			union
				select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate				
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
				order by [No], [ExtraChargeCategory]
			end
		else
		begin
			select 1 as [No], dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode) as ExtraChargeCategory, 
			sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
			group by dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode)
		union
			select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
			order by [No], [ExtraChargeCategory]

		end
	else if (@BillModesID = @InsuranceBillModesID) -- Bill Insurance
		 if not(@CompanyNo is null)
			begin				
				select 1 as [No], dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode) as ExtraChargeCategory, 
				sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
				group by dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode)
			union
				select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
				order by [No], [ExtraChargeCategory]
			end
		else
		begin			
			select 1 as [No], dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode) as ExtraChargeCategory, 
			sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
			group by dbo.GetItemName(Items.ItemCategoryID, Items.ItemCode)
		union
			select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @ExtrasID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
			order by [No], [ExtraChargeCategory]
		end	
end
return 0
go

-- exec uspGetExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', 'GMC'
-- exec uspGetExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', '100041A'
-- exec uspGetExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', '100041A', '100105A'
-- exec uspGetExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17I', 'CMC'
-- exec uspGetExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17I', 'CMC', 'URA'
-- exec uspGetExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', 'CASH'
-- exec uspGetExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17C', 'CASH'

-------------------------------------------------------------------------------------------------
-------------- DoctorVisitSummaries -------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetDoctorVisitSummaries')
	drop proc uspGetDoctorVisitSummaries
go

create proc uspGetDoctorVisitSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
		
	declare @ServiceID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], case dbo.GetSeenDoctor(Visits.VisitNo) when '' then 'SELF REQUEST' else dbo.GetSeenDoctor(Visits.VisitNo) end as SeenDoctor, 
	count(distinct Visits.VisitNo) as TotalVisits,	
	sum(case when (Items.ItemCategoryID = @ServiceID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalOnServices,
	sum(Items.Quantity * Items.UnitPrice) as TotalAmount,sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.RecordDateTime between @StartDate and @EndDate
	group by dbo.GetSeenDoctor(Visits.VisitNo)
union
	select 2 as [No], 'Grand Total' as DoctorVisitCategory, count(distinct Visits.VisitNo) as TotalVisits,
	sum(case when (Items.ItemCategoryID = @ServiceID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalOnServices,
	sum(Items.Quantity * Items.UnitPrice) as TotalAmount, sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.RecordDateTime between @StartDate and @EndDate
	order by [No], [SeenDoctor]
end
return 0
go

-- exec uspGetDoctorVisitSummaries '1 Oct 2013', '31 Oct 2013'

-------------------------------------------------------------------------------------------------
-------------- DoctorSpecialtyVisitSummaries ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetDoctorSpecialtyVisitSummaries')
	drop proc uspGetDoctorSpecialtyVisitSummaries
go

create proc uspGetDoctorSpecialtyVisitSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
		
	declare @ServiceID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], case dbo.GetSeenDoctorSpecialty(Visits.VisitNo) when '' then 'SELF REQUEST' else dbo.GetSeenDoctorSpecialty(Visits.VisitNo) end as SeenDoctorSpecialty, 
	count(distinct Visits.VisitNo) as TotalVisits,	
	sum(case when (Items.ItemCategoryID = @ServiceID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalOnServices,
	sum(Items.Quantity * Items.UnitPrice) as TotalAmount,sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.RecordDateTime between @StartDate and @EndDate
	group by dbo.GetSeenDoctorSpecialty(Visits.VisitNo)
union
	select 2 as [No], 'Grand Total' as DoctorSpecialtyVisitCategory, count(distinct Visits.VisitNo) as TotalVisits,
	sum(case when (Items.ItemCategoryID = @ServiceID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalOnServices,
	sum(Items.Quantity * Items.UnitPrice) as TotalAmount, sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (Items.Quantity * Items.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * Items.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as InsuranceNotPaid
	from Items  
	left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo	
	and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
	left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
	and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
	inner join Visits  on Items.VisitNo = Visits.VisitNo
	where Items.RecordDateTime between @StartDate and @EndDate
	order by [No], [SeenDoctorSpecialty]
end
return 0
go

-- exec uspGetDoctorSpecialtyVisitSummaries '1 Oct 2013', '31 Oct 2013'

-------------------------------------------------------------------------------------------------
-------------- IncomePaymentDetailsSummaries ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIncomePaymentDetailsSummaries')
	drop proc uspGetIncomePaymentDetailsSummaries
go

create proc uspGetIncomePaymentDetailsSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
		
	declare @VisitBillID varchar(10)
	declare @RecordStartDate smalldatetime
	declare @RecordEndDate smalldatetime

	--------------------------------------------------------------------------------------------------------
	set @VisitBillID = dbo.GetLookupDataID('PayType', 'CAS')	
	set @RecordStartDate = dbo.GetShortDate(@StartDate)
	set @RecordEndDate = dbo.GetShortDate(dateadd(day, 1, @EndDate))
	--------------------------------------------------------------------------------------------------------
		
	select 1 as [No], PaymentDetails.ReceiptNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(Amount)) as TotalAmount, 
	dbo.GetWaitingDays(VisitDate, Payments.RecordDateTime) as PaidAfterDays,
	dbo.GetShortDate(Payments.RecordDateTime) as RecordDate, 
	dbo.GetTime(Payments.RecordDateTime) as RecordTime
	from PaymentDetails 
	inner join Payments on PaymentDetails.ReceiptNo = Payments.ReceiptNo
	left outer join Visits on Payments.PayNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Payments.PayTypeID = @VisitBillID and 
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate)
	group by PaymentDetails.ReceiptNo, ItemCategoryID, LastName, MiddleName, FirstName, 
			VisitDate, Payments.RecordDateTime
union
	select 2 as [No], 'Grand Total' as ReceiptNo, '' as VisitDate, '' as FullName, 
	'' as ItemCategory, Sum(Abs(Amount)) as TotalAmount, '' as PaidAfterDays,
	'' as RecordDate, '' as RecordTime
	from PaymentDetails 
	inner join Payments on PaymentDetails.ReceiptNo = Payments.ReceiptNo
	left outer join Visits on Payments.PayNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Payments.PayTypeID = @VisitBillID and 
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate)
	
end
return 0
go

-- exec uspGetIncomePaymentDetailsSummaries '14 April 2015', '14 April 2015'

-------------------------------------------------------------------------------------------------
-------------- AccountsSummaries ----------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetAccountsSummaries')
	drop proc uspGetAccountsSummaries
go

create proc uspGetAccountsSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
	select AccountActionID, sum(Amount) as TotalAmount from Accounts  
	where TranDate between @StartDate and @EndDate
	group by AccountActionID
end
return 0
go

-- exec uspGetAccountsSummaries '1 Oct 2012', '31 Oct 2012'

-------------------------------------------------------------------------------------------------
-------------- ClaimSummaries -------------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetClaimSummaries')
	drop proc uspGetClaimSummaries
go

create proc uspGetClaimSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime,
@HealthUnitCode varchar(10) = null
) with encryption as

if not (@HealthUnitCode is null or @HealthUnitCode = '') 	
	begin
		select 1 as [No], BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join MemberBenefits on ClaimDetails.BenefitCode = MemberBenefits.BenefitCode
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate and Claims.HealthUnitCode = @HealthUnitCode
		group by BenefitName
	union
		select 2 as [No], 'Grand Total' as BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate and Claims.HealthUnitCode = @HealthUnitCode
		order by [No], [BenefitName]
	end
else if (@HealthUnitCode is null or @HealthUnitCode = '')
	begin
		select 1 as [No], BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join MemberBenefits on ClaimDetails.BenefitCode = MemberBenefits.BenefitCode
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate
		group by BenefitName
	union
		select 2 as [No], 'Grand Total' as BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate
		order by [No], [BenefitName]
	end

return 0
go

-- exec uspGetClaimSummaries '1 Jan 2011', '31 Oct 2013'
-- exec uspGetClaimSummaries '1 Jan 2011', '31 Oct 2013', 'CMC'

-------------------------------------------------------------------------------------------------
-------------- ClaimSummariesByCompany ----------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetClaimSummariesByCompany')
	drop proc uspGetClaimSummariesByCompany
go

create proc uspGetClaimSummariesByCompany(
@StartDate smalldatetime,
@EndDate smalldatetime,
@InsuranceNo varchar(20),
@CompanyNo varchar(20) = null
) with encryption as

if not (@CompanyNo is null or @CompanyNo = '') 	
	begin
		select 1 as [No], BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join MemberBenefits on ClaimDetails.BenefitCode = MemberBenefits.BenefitCode
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		inner join SchemeMembers on Claims.MedicalCardNo = SchemeMembers.MedicalCardNo
		inner join InsuranceSchemes on InsuranceSchemes.CompanyNo = SchemeMembers.CompanyNo
		and InsuranceSchemes.PolicyNo = SchemeMembers.PolicyNo
		inner join Companies on InsuranceSchemes.CompanyNo = Companies.CompanyNo
		inner join InsurancePolicies on InsuranceSchemes.PolicyNo = InsurancePolicies.PolicyNo
		inner join Insurances on InsurancePolicies.InsuranceNo = Insurances.InsuranceNo
		where VisitDate between @StartDate and @EndDate and InsurancePolicies.InsuranceNo = @InsuranceNo 
		and SchemeMembers.CompanyNo = @CompanyNo
		group by BenefitName
	union
		select 2 as [No], 'Grand Total' as BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		inner join SchemeMembers on Claims.MedicalCardNo = SchemeMembers.MedicalCardNo
		inner join InsuranceSchemes on InsuranceSchemes.CompanyNo = SchemeMembers.CompanyNo
		and InsuranceSchemes.PolicyNo = SchemeMembers.PolicyNo
		inner join Companies on InsuranceSchemes.CompanyNo = Companies.CompanyNo
		inner join InsurancePolicies on InsuranceSchemes.PolicyNo = InsurancePolicies.PolicyNo
		inner join Insurances on InsurancePolicies.InsuranceNo = Insurances.InsuranceNo
		where VisitDate between @StartDate and @EndDate and InsurancePolicies.InsuranceNo = @InsuranceNo 
		and SchemeMembers.CompanyNo = @CompanyNo
		order by [No], [BenefitName]
	end
else if (@CompanyNo is null or @CompanyNo = '')
	begin
		select 1 as [No], BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join MemberBenefits on ClaimDetails.BenefitCode = MemberBenefits.BenefitCode
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		inner join SchemeMembers on Claims.MedicalCardNo = SchemeMembers.MedicalCardNo
		inner join InsuranceSchemes on InsuranceSchemes.CompanyNo = SchemeMembers.CompanyNo
		and InsuranceSchemes.PolicyNo = SchemeMembers.PolicyNo
		inner join Companies on InsuranceSchemes.CompanyNo = Companies.CompanyNo
		inner join InsurancePolicies on InsuranceSchemes.PolicyNo = InsurancePolicies.PolicyNo
		inner join Insurances on InsurancePolicies.InsuranceNo = Insurances.InsuranceNo
		where VisitDate between @StartDate and @EndDate and InsurancePolicies.InsuranceNo = @InsuranceNo 
		group by BenefitName
	union
		select 2 as [No], 'Grand Total' as BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		inner join SchemeMembers on Claims.MedicalCardNo = SchemeMembers.MedicalCardNo
		inner join InsuranceSchemes on InsuranceSchemes.CompanyNo = SchemeMembers.CompanyNo
		and InsuranceSchemes.PolicyNo = SchemeMembers.PolicyNo
		inner join Companies on InsuranceSchemes.CompanyNo = Companies.CompanyNo
		inner join InsurancePolicies on InsuranceSchemes.PolicyNo = InsurancePolicies.PolicyNo
		inner join Insurances on InsurancePolicies.InsuranceNo = Insurances.InsuranceNo
		where VisitDate between @StartDate and @EndDate and InsurancePolicies.InsuranceNo = @InsuranceNo 
		order by [No], [BenefitName]
	end

return 0
go

-- exec uspGetClaimSummariesByCompany '1 Jan 2011', '31 Oct 2013', 'CMC'
-- exec uspGetClaimSummariesByCompany '1 Jan 2011', '31 Oct 2013', 'CMC', 'CPS'

-------------------------------------------------------------------------------------------------
-------------- ClaimSummariesByMedicalCardNo ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetClaimSummariesByMedicalCardNo')
	drop proc uspGetClaimSummariesByMedicalCardNo
go

create proc uspGetClaimSummariesByMedicalCardNo(
@StartDate smalldatetime,
@EndDate smalldatetime,
@MedicalCardNo varchar(20) = null
) with encryption as

if not (@MedicalCardNo is null or @MedicalCardNo = '') 	
	begin
		select 1 as [No], ClaimDetails.BenefitCode, BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join MemberBenefits on ClaimDetails.BenefitCode = MemberBenefits.BenefitCode
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate and Claims.MedicalCardNo = @MedicalCardNo
		group by ClaimDetails.BenefitCode, BenefitName
	union
		select 2 as [No], '' as BenefitCode, 'Grand Total' as BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate and Claims.MedicalCardNo = @MedicalCardNo
		order by [No], [BenefitName]
	end
else if (@MedicalCardNo is null or @MedicalCardNo = '')
	begin
		select 1 as [No], ClaimDetails.BenefitCode, BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join MemberBenefits on ClaimDetails.BenefitCode = MemberBenefits.BenefitCode
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate
		group by ClaimDetails.BenefitCode, BenefitName
	union
		select 2 as [No], '' as BenefitCode, 'Grand Total' as BenefitName, sum(Amount) as TotalAmount
		from ClaimDetails
		inner join Claims on ClaimDetails.ClaimNo = Claims.ClaimNo
		where VisitDate between @StartDate and @EndDate
		order by [No], [BenefitName]
	end

return 0
go

-- exec uspGetClaimSummariesByMedicalCardNo '1 Jan 2011', '31 Oct 2013'
-- exec uspGetClaimSummariesByMedicalCardNo '1 Jan 2011', '31 Oct 2013', 'ACF89'

-------------------------------------------------------------------------------------------------
-------------- DiagnosisSummaries ---------------------------------------------------------------
-------------------------------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'uspGetDiagnosisSummaries')
	drop proc uspGetDiagnosisSummaries
go

create proc uspGetDiagnosisSummaries(
@SearchAgeBy varchar(10),
@StartDate smalldatetime,
@EndDate smalldatetime,
@StartAge tinyint,
@EndAge tinyint
) with encryption as

begin

	----------------------------------------------------------------------------
	declare @MaleGenderID varchar(10)
	declare @FemaleGenderID varchar(10)

	----------------------------------------------------------------------------
	set @MaleGenderID = dbo.GetLookupDataID('Gender', 'M')
	set @FemaleGenderID = dbo.GetLookupDataID('Gender', 'F')

	----------------------------------------------------------------------------
	if @SearchAgeBy=dbo.GetLookupDataID('SearchAgeBy', 'YR')
	  begin
	     select DiseaseName, 
	     sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	     sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	     count(DiseaseName) as Total
	     from Diagnosis
	     inner join Visits on Diagnosis.VisitNo = Visits.VisitNo
	     inner join Patients on Visits.PatientNo = Patients.PatientNo
	     inner join Diseases on Diagnosis.DiseaseCode = Diseases.DiseaseCode
	     where VisitDate between @StartDate and @EndDate
	     and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
	     group by DiseaseName
     end
    
	else
	   if @SearchAgeBy= dbo.GetLookupDataID('SearchAgeBy', 'MT')
	  begin
	     select DiseaseName, 
	     sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	     sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	     count(DiseaseName) as Total
	     from Diagnosis
	     inner join Visits on Diagnosis.VisitNo = Visits.VisitNo
	     inner join Patients on Visits.PatientNo = Patients.PatientNo
	     inner join Diseases on Diagnosis.DiseaseCode = Diseases.DiseaseCode
	     where VisitDate between @StartDate and @EndDate
	     and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
	     group by DiseaseName
     end
	----------------------------------------------------------------------------
	
end
return 0
go

 --exec uspGetDiagnosisSummaries '250MT','1 Oct 2010', '31 Oct 2014', 0, 106

-------------------------------------------------------------------------------------------------
-------------- DiseaseCategorySummaries ---------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetDiseaseCategorySummaries')
	drop proc uspGetDiseaseCategorySummaries
go

create proc uspGetDiseaseCategorySummaries(
@SearchAgeBy varchar(10),
@StartDate smalldatetime,
@EndDate smalldatetime,
@StartAge tinyint,
@EndAge tinyint
) with encryption as

begin

	----------------------------------------------------------------------------
	declare @MaleGenderID varchar(10)
	declare @FemaleGenderID varchar(10)
	
	----------------------------------------------------------------------------
	set @MaleGenderID = dbo.GetLookupDataID('Gender', 'M')
	set @FemaleGenderID = dbo.GetLookupDataID('Gender', 'F')
	
	----------------------------------------------------------------------------
	if @SearchAgeBy= dbo.GetLookupDataID('SearchAgeBy', 'YR')
	  begin
	     select dbo.GetLookupDataDes(DiseaseCategoriesID) as DiseaseCategory, 
	     sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	     sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	     count(dbo.GetLookupDataDes(DiseaseCategoriesID)) as Total
	     from Diagnosis
	     inner join Visits on Diagnosis.VisitNo = Visits.VisitNo
	     inner join Patients on Visits.PatientNo = Patients.PatientNo
	     inner join Diseases on Diagnosis.DiseaseCode = Diseases.DiseaseCode
	     where VisitDate between @StartDate and @EndDate
	     and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
	     group by dbo.GetLookupDataDes(DiseaseCategoriesID)
	   end

	   else
	   if @SearchAgeBy=dbo.GetLookupDataID('SearchAgeBy', 'MT')
	    begin
	     select dbo.GetLookupDataDes(DiseaseCategoriesID) as DiseaseCategory, 
	     sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	     sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	     count(dbo.GetLookupDataDes(DiseaseCategoriesID)) as Total
	     from Diagnosis
	     inner join Visits on Diagnosis.VisitNo = Visits.VisitNo
	     inner join Patients on Visits.PatientNo = Patients.PatientNo
	     inner join Diseases on Diagnosis.DiseaseCode = Diseases.DiseaseCode
	     where VisitDate between @StartDate and @EndDate
	     and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
	     group by dbo.GetLookupDataDes(DiseaseCategoriesID)
	   end
	----------------------------------------------------------------------------
	
end
return 0
go

-- exec uspGetDiseaseCategorySummaries '250MT','1 Oct 2010', '31 Oct 2014', 0, 106


if exists (select * from sysobjects where name = 'uspGetIPDDiagnosisSummaries')
	drop proc uspGetIPDDiagnosisSummaries
go

create proc uspGetIPDDiagnosisSummaries(
@SearchAgeBy varchar(10),
@StartDate smalldatetime,
@EndDate smalldatetime,
@StartAge tinyint,
@EndAge tinyint
) with encryption as

begin

	----------------------------------------------------------------------------
	declare @MaleGenderID varchar(10)
	declare @FemaleGenderID varchar(10)
	
	----------------------------------------------------------------------------
	set @MaleGenderID = dbo.GetLookupDataID('Gender', 'M')
	set @FemaleGenderID = dbo.GetLookupDataID('Gender', 'F')
	
	----------------------------------------------------------------------------
	if @SearchAgeBy=dbo.GetLookupDataID('SearchAgeBy', 'YR')
	select DiseaseName, 
	sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	count(DiseaseName) as Total
	from IPDDiagnosis
    inner join IPDDoctor on IPDDiagnosis.RoundNo = IPDDoctor.RoundNo
	inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
	inner join Visits on Admissions.VisitNo = Visits.VisitNo
	inner join Patients on Visits.PatientNo = Patients.PatientNo
	inner join Diseases on IPDDiagnosis.DiseaseCode = Diseases.DiseaseCode
	where AdmissionDateTime between @StartDate and @EndDate
	and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
	group by DiseaseName

	else
	 if @SearchAgeBy=dbo.GetLookupDataID('SearchAgeBy', 'MT')
	    select DiseaseName, 
	sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	count(DiseaseName) as Total
	from IPDDiagnosis
    inner join IPDDoctor on IPDDiagnosis.RoundNo = IPDDoctor.RoundNo
	inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
	inner join Visits on Admissions.VisitNo = Visits.VisitNo
	inner join Patients on Visits.PatientNo = Patients.PatientNo
	inner join Diseases on IPDDiagnosis.DiseaseCode = Diseases.DiseaseCode
	where AdmissionDateTime between @StartDate and @EndDate
	and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
	group by DiseaseName
	----------------------------------------------------------------------------
	
end
return 0
go

-- exec uspGetIPDDiagnosisSummaries '1 Oct 2010', '31 Oct 2014', 0, 106

-------------------------------------------------------------------------------------------------
-------------- IPDDiseaseCategorySummaries ---------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDDiseaseCategorySummaries')
	drop proc uspGetIPDDiseaseCategorySummaries
go

create proc uspGetIPDDiseaseCategorySummaries(
@SearchAgeBy Varchar(10),
@StartDate smalldatetime,
@EndDate smalldatetime,
@StartAge tinyint,
@EndAge tinyint
) with encryption as

begin

	----------------------------------------------------------------------------
	declare @MaleGenderID varchar(10)
	declare @FemaleGenderID varchar(10)
	
	----------------------------------------------------------------------------
	set @MaleGenderID = dbo.GetLookupDataID('Gender', 'M')
	set @FemaleGenderID = dbo.GetLookupDataID('Gender', 'F')
	
	----------------------------------------------------------------------------
 if @SearchAgeBy=dbo.GetLookupDataID('SearchAgeBy', 'YR')
	select dbo.GetLookupDataDes(DiseaseCategoriesID) as DiseaseCategory, 
	sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	count(dbo.GetLookupDataDes(DiseaseCategoriesID)) as Total
	from IPDDiagnosis
   inner join IPDDoctor on IPDDiagnosis.RoundNo = IPDDoctor.RoundNo
	inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
	inner join Visits on Admissions.VisitNo = Visits.VisitNo
	inner join Patients on Visits.PatientNo = Patients.PatientNo
	inner join Diseases on IPDDiagnosis.DiseaseCode = Diseases.DiseaseCode
	where AdmissionDateTime between @StartDate and @EndDate
	and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
	group by dbo.GetLookupDataDes(DiseaseCategoriesID)

	else
	 if @SearchAgeBy=dbo.GetLookupDataID('SearchAgeBy', 'MT')
	 select dbo.GetLookupDataDes(DiseaseCategoriesID) as DiseaseCategory, 
	sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
	sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female, 
	count(dbo.GetLookupDataDes(DiseaseCategoriesID)) as Total
	from IPDDiagnosis
   inner join IPDDoctor on IPDDiagnosis.RoundNo = IPDDoctor.RoundNo
	inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
	inner join Visits on Admissions.VisitNo = Visits.VisitNo
	inner join Patients on Visits.PatientNo = Patients.PatientNo
	inner join Diseases on IPDDiagnosis.DiseaseCode = Diseases.DiseaseCode
	where AdmissionDateTime between @StartDate and @EndDate
	and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
	group by dbo.GetLookupDataDes(DiseaseCategoriesID)
	----------------------------------------------------------------------------
	
end
return 0
go

-- exec uspGetIPDDiseaseCategorySummaries '1 Oct 2010', '31 Oct 2014', 0, 106

-----------------------------Get SagePastelReport -----------------

if exists (select * from sysobjects where name = 'uspGetSagePastelReport')
	drop proc uspGetSagePastelReport
go

create proc uspGetSagePastelReport(
@StartDateTime smalldatetime = null,
@EndDateTime smalldatetime = null
)with encryption as
declare @ErrorMSG varchar(200)
declare @ItemStatusDoneID varchar(10)
declare @ItemStatusOfferedID varchar(10)
declare @ItemStatusPending varchar(10)

declare @NotPaidPayStatus varchar (10)
declare @PaidForPayStatus varchar (10)

set @ItemStatusDoneID = dbo.GetLookupDataID('ItemStatus', 'D')
set @ItemStatusOfferedID = dbo.GetLookupDataID('ItemStatus', 'O')
set @ItemStatusPending = dbo.GetLookupDataID('ItemStatus', 'P')

----------------------------------------------------------------------------
set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
set @PaidForPayStatus = dbo.GetLookupDataID('PayStatus', 'PF')
----------------------------------------------------------------------------

if not (@StartDateTime is null) and not(@EndDateTime is null)
begin
--select dbo.FormatDate(items.RecordDateTime)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
--Items.ItemName as Description,dbo.FormatMoney(Items.Quantity *Items.UnitPrice) as Debit,
--dbo.GetLookupDataDes(VisitCategoryID) as Project from Items
--inner join Visits on Items.VisitNo =visits.VisitNo 
--where Items.ItemStatusID IN(@ItemStatusOfferedID,@ItemStatusDoneID) and Items.PayStatusID IN (@PaidForPayStatus,@NotPaidPayStatus)
--and (items.RecordDateTime between @StartDateTime and @EndDateTime)

--union

--select distinct dbo.FormatDate(items.RecordDateTime)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
--Items.ItemName as Description,dbo.FormatMoney(Items.Quantity *Items.UnitPrice) as Debit,
--dbo.GetLookupDataDes(VisitCategoryID) as Project from Items
--inner join Visits on Items.VisitNo =visits.VisitNo 
--where (Items.ItemStatusID = @ItemStatusPending and Items.PayStatusID =@PaidForPayStatus)
--and (items.RecordDateTime between @StartDateTime and @EndDateTime)

--union

--select distinct dbo.FormatDate(items.RecordDateTime)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
--Items.ItemName as Description,dbo.FormatMoney(Items.Quantity *Items.UnitPrice) as Debit,
--dbo.GetLookupDataDes(VisitCategoryID) as Project from Items
--inner join Visits on Items.VisitNo =visits.VisitNo 
--where Items.ItemStatusID = @ItemStatusOfferedID
---- and Items.PayStatusID =@PaidForPayStatus)
--and (items.RecordDateTime between @StartDateTime and @EndDateTime)

--union

select  dbo.FormatDate(items.RecordDateTime)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
Items.ItemName as Description,dbo.FormatMoney(Items.Quantity *Items.UnitPrice) as Debit,
dbo.GetLookupDataDes(VisitCategoryID) as Project from Items
inner join Visits on Items.VisitNo =visits.VisitNo 
where NOT(Items.ItemStatusID = @ItemStatusPending and Items.PayStatusID =@NotPaidPayStatus)
and (items.RecordDateTime between @StartDateTime and @EndDateTime)

	
end
return 0
go

-----------------------------------------------------------------------------------------------------------------------------------------------
--------------IPD Sage Pastel Report
-----------------------------------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDSagePastelReport')
	drop proc uspGetIPDSagePastelReport
go

create proc uspGetIPDSagePastelReport(
@StartDateTime smalldatetime = null,
@EndDateTime smalldatetime = null
)with encryption as
declare @ErrorMSG varchar(200)

if not (@StartDateTime is null) and not(@EndDateTime is null)
begin

SELECT dbo.FormatDate(ExtraBillItems.RecordDateTime)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
ExtraBillItems.ItemName as Description,dbo.FormatMoney(ExtraBillItems.Quantity *ExtraBillItems.UnitPrice) as Debit,
dbo.GetLookupDataDes(WardsID) as Project FROM ExtraBillItems
inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
inner join Visits on ExtraBills.VisitNo = Visits.VisitNo
left outer join Admissions on Visits.VisitNo = Admissions.VisitNo
left outer join Beds on Admissions.BedNo = Beds.BedNo
left outer join Rooms on Beds.RoomNo = Rooms.RoomNo
where ExtraBillItems.RecordDateTime between @StartDateTime and @EndDateTime
end
return 0
go

-----------------------------------------------------------------------------------------------------------------------------------------------
--------------Get Operational OPD Items Report
-----------------------------------------------------------------------------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'uspGetOperationalOPDItemsReport')
	drop proc uspGetOperationalOPDItemsReport
go

create proc uspGetOperationalOPDItemsReport(

@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@ItemCategoryID varchar(10)=null,
@ItemStatusID varchar(10)=null,
@PayStatusID varchar(10)=null,
@BillModesID varchar(10)=null

)with encryption as

declare @ErrorMSG varchar(200)

 if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null) and not (@PayStatusID is null) and not (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and 
Items.ItemStatusID =@ItemStatusID and 
Items.ItemCategoryID =@ItemCategoryID and
BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

 else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) and (@PayStatusID is null) and  (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where ItemCategoryID =@ItemCategoryID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and not (@ItemStatusID is null) and not (@PayStatusID is null) and not (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and 
Items.ItemStatusID =@ItemStatusID and 
BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null) and (@PayStatusID is null) and not (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.ItemStatusID =@ItemStatusID and 
Items.ItemCategoryID =@ItemCategoryID and
BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) and not (@PayStatusID is null) and not (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and 
Items.ItemCategoryID =@ItemCategoryID and
BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null) and not (@PayStatusID is null) and (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and 
Items.ItemStatusID =@ItemStatusID and 
Items.ItemCategoryID =@ItemCategoryID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) and not (@PayStatusID is null) and (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and
Items.ItemCategoryID =@ItemCategoryID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

 else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null) and (@PayStatusID is null) and (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where
Items.ItemStatusID =@ItemStatusID and 
Items.ItemCategoryID =@ItemCategoryID 
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end


 else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) and (@PayStatusID is null) and not (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where
Items.ItemCategoryID =@ItemCategoryID and
BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

 else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and (@ItemStatusID is null) and not(@PayStatusID is null) and  (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where PayStatusID =@PayStatusID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
end

 else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and (@ItemStatusID is null) and (@PayStatusID is null) and  not(@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
end


else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and not(@ItemStatusID is null) and (@PayStatusID is null) and  (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where ItemStatusID =@ItemStatusID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and (@ItemStatusID is null) and not (@PayStatusID is null) and not (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and
BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and not (@ItemStatusID is null) and not (@PayStatusID is null) and (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and 
Items.ItemStatusID =@ItemStatusID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) and not (@PayStatusID is null) and (@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.PayStatusID =@PayStatusID and
Items.ItemCategoryID =@ItemCategoryID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end


else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and not(@ItemStatusID is null) and  (@PayStatusID is null) and not(@BillModesID is null)
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where 
Items.ItemStatusID =@ItemStatusID and
BillModesID =@BillModesID
and Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end


else
begin

select dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Items.VisitNo as VisitNo,ItemName,Quantity,UnitPrice,
(Quantity*UnitPrice) as TotalAmount,ItemCategoryID,BillModesID,PayStatusID,ItemStatusID,Items.LoginID as Offeredby, CreatorClientMachine,dbo.GetLookupDataDes(BillModesID) as BillMode from Items
inner join Visits On Visits.VisitNo = Items.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo
where
Items.RecordDateTime between @StartDateTime and @EndDateTime order by Items.RecordDateTime
	
end

return 0
go



-------- Get Appointments Report ----------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetAppointmentsReport')
	drop proc uspGetAppointmentsReport
go

create proc uspGetAppointmentsReport(
@StartDateTime smalldatetime = null,
@EndDateTime smalldatetime = null
)with encryption as
declare @ErrorMSG varchar(200)
if not (@StartDateTime is null) and not(@EndDateTime is null)
begin
	select Appointments.PatientNo As AppointmentsPatientNo ,Patients.LastName,Patients.FirstName,Patients.MiddleName
	,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,dbo.GetLookupDataDes(Patients.GenderID) As Gender,
	dbo.GetAge(BirthDate, getdate()) as Age,Patients.Phone as PhoneNo,
	dbo.FormatDate(StartDate) as StartDate, 
		AppointmentPrecisionID, dbo.GetLookupDataDes(AppointmentPrecisionID) as AppointmentPrecision, 
		StartTime, Duration, dbo.FormatDate(EndDate) as EndDate, 
		Appointments.DoctorSpecialtyID, dbo.GetLookupDataDes(Appointments.DoctorSpecialtyID) as DoctorSpecialty,
		Appointments.StaffNo, dbo.GetStaffFullName(Appointments.StaffNo) as StaffFullName, 		
		AppointmentDes, dbo.GetRemainingDays(StartDate, AppointmentStatusID, getdate()) as RemainingDays,
		AppointmentStatusID, dbo.GetLookupDataDes(AppointmentStatusID) as AppointmentStatus
		from Appointments
		inner join Patients on Appointments.PatientNo = Patients.PatientNo
		where Appointments.StartDate between @StartDateTime and @EndDateTime
	order by Appointments.RecordDateTime
	end
return 0
go


--------Get Daily Cash Payments----------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetDailyCashPayments')
	drop proc uspGetDailyCashPayments
go
create proc uspGetDailyCashPayments(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as

declare @ErrorMSG varchar(200)
 if not(@StartDateTime is null) and not(@EndDateTime is null)
	begin
		select dbo.FormatDate(PayDate) as PayDate,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
		dbo.GetSeenDoctor(VisitNo) as SeenDoctor,
		 dbo.FormatText(VisitNo, 'Visits', 'VisitNo') as VisitNo,
	    dbo.FormatMoney(AmountPaid) as AmountPaid, 
		 dbo.GetLookupDataDes(CurrenciesID) as Currency, dbo.GetTime(RecordDateTime) as RecordTime
		from CashPayments
		where RecordDateTime between @StartDateTime and @EndDateTime
		order by PayDate, RecordDateTime
	end
	return 0
go
-------------------------------------Get Daily Isurance Payments-------------------------------------------------------
							
if exists (select * from sysobjects where name = 'uspGetDailyIsurancePayments')
	drop proc uspGetDailyIsurancePayments
go

create proc uspGetDailyIsurancePayments(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@BranchID varchar(10) =null
)with encryption as

declare @ErrorMSG varchar(200)							
declare @InsuranceBillModeID varchar(10)
set @InsuranceBillModeID = dbo.GetLookupDataID('BillModes', 'I')

if (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null) 
begin							
select Visits.VisitNo as VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,dbo.FormatDate(VisitDate) As VisitDate,
dbo.GetSeenDoctor(Visits.VisitNo) as SeenDoctor,isnull(dbo.GetTotalBill(Visits.VisitNo, 'NP'),0) as TotalBill,
dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
dbo.GetBillName(BillModesID, BillNo) as ToBillCustomer,BillModesID,dbo.GetInsuranceName(BillModesID, InsuranceNo) As InsuranceName,
dbo.GetTime(Visits.RecordDateTime) As RecordTime From Visits
inner join Patients on Visits.PatientNo = Patients.PatientNo
left outer join Services on Visits.ServiceCode = Services.ServiceCode
Where BillModesID = @InsuranceBillModeID and Visits.RecordDateTime between @StartDateTime and @EndDateTime
order by Visits.RecordDateTime
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and not (@BranchID is null)
begin							
select Visits.VisitNo as VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,dbo.FormatDate(VisitDate) As VisitDate,
dbo.GetSeenDoctor(Visits.VisitNo) as SeenDoctor,
isnull(dbo.GetTotalBill(Visits.VisitNo, 'NP'),0) as TotalBill,VisitCategoryID,dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
dbo.GetBillName(BillModesID, BillNo) as ToBillCustomer,BillModesID,dbo.GetInsuranceName(BillModesID, InsuranceNo) As InsuranceName,
dbo.GetTime(Visits.RecordDateTime) As RecordTime From Visits
inner join Patients on Visits.PatientNo = Patients.PatientNo
left outer join Services on Visits.ServiceCode = Services.ServiceCode
Where BillModesID = @InsuranceBillModeID and Visits.RecordDateTime between @StartDateTime and
 @EndDateTime and VisitCategoryID =@BranchID
order by Visits.RecordDateTime
end


return 0
go
-----------------------------------Get Daily Account Payments-------------------------------------------------------
							
							
if exists (select * from sysobjects where name = 'uspGetDailyAccountPayments')
	drop proc uspGetDailyAccountPayments
go

create proc uspGetDailyAccountPayments(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@BranchID varchar(10) =null
)with encryption as

declare @ErrorMSG varchar(200)							
declare @InsuranceBillModeID varchar(10)
set @InsuranceBillModeID = dbo.GetLookupDataID('BillModes', 'A')

if (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin							
select Visits.VisitNo as AcVisitNo,dbo.FormatDate(VisitDate) As AcVisitDate,
dbo.GetFullName(LastName, MiddleName, FirstName) as AcFullName
,dbo.GetSeenDoctor(Visits.VisitNo) as AcSeenDoctor,isnull(dbo.GetTotalBill(Visits.VisitNo, 'NP'),0) as AcTotalBill,
dbo.GetBillName(BillModesID, BillNo) as AcToBillCustomer,BillModesID,dbo.GetInsuranceName(BillModesID, InsuranceNo) As AcInsuranceName,
dbo.GetTime(Visits.RecordDateTime) As AcRecordTime,VisitCategoryID,
dbo.GetLookupDataDes(VisitCategoryID) as BranchName
 From Visits
inner join Patients on Visits.PatientNo = Patients.PatientNo
left outer join Services on Visits.ServiceCode = Services.ServiceCode
Where BillModesID = @InsuranceBillModeID and Visits.RecordDateTime between @StartDateTime and @EndDateTime
order by Visits.RecordDateTime
end

else if not(@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin							
select Visits.VisitNo as AcVisitNo,dbo.FormatDate(VisitDate) As AcVisitDate,
dbo.GetFullName(LastName, MiddleName, FirstName) as AcFullName
,dbo.GetSeenDoctor(Visits.VisitNo) as AcSeenDoctor,isnull(dbo.GetTotalBill(Visits.VisitNo, 'NP'),0) as AcTotalBill,
dbo.GetBillName(BillModesID, BillNo) as AcToBillCustomer,BillModesID,dbo.GetInsuranceName(BillModesID, InsuranceNo) As AcInsuranceName,
dbo.GetTime(Visits.RecordDateTime) As AcRecordTime,VisitCategoryID,
dbo.GetLookupDataDes(VisitCategoryID) as BranchName
 From Visits
inner join Patients on Visits.PatientNo = Patients.PatientNo
left outer join Services on Visits.ServiceCode = Services.ServiceCode
Where BillModesID = @InsuranceBillModeID and Visits.RecordDateTime between @StartDateTime and @EndDateTime and VisitCategoryID =@BranchID
order by Visits.RecordDateTime
end
return 0
go

-----------------------------------Get Manage Account Debits-------------------------------------------------------

 if exists (select * from sysobjects where name = 'uspGetManageAccountDebits')
	drop proc uspGetManageAccountDebits
go
create proc uspGetManageAccountDebits(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@BranchID varchar(10) = null
) with encryption as
----------------------------------------------------------------------------
declare @AccountActionID varchar(10)
set @AccountActionID = dbo.GetLookupDataID('AccountAction', 'DR')
----------------------------------------------------------------------------
if (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin
select dbo.FormatText(TranNo, 'Accounts', 'TranNo') as TranNo, 
		dbo.GetLookupDataDes(AccountBillModesID) as AccountCategory, dbo.GetLookupDataDes(PayModesID) as PayModes, 
		AccountBillNo, dbo.GetAccountName(AccountBillModesID, AccountBillNo) as AccountName, Amount,DocumentNo,
		dbo.GetLookupDataDes(EntryModeID) As EntryMode,dbo.GetLookupDataDes(BranchID) as BranchName, 
		dbo.GetLookupDataDes(CurrenciesID) as Currency,AccountGroupID, dbo.GetTime(RecordDateTime) as RecordTime,LoginID
		from Accounts
		where AccountActionID =@AccountActionID and RecordDateTime between @StartDateTime and @EndDateTime
		order by TranDate, RecordDateTime
end

else if not (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin
select dbo.FormatText(TranNo, 'Accounts', 'TranNo') as TranNo, 
		dbo.GetLookupDataDes(AccountBillModesID) as AccountCategory, dbo.GetLookupDataDes(PayModesID) as PayModes, 
		AccountBillNo, dbo.GetAccountName(AccountBillModesID, AccountBillNo) as AccountName, Amount,DocumentNo,
		dbo.GetLookupDataDes(EntryModeID) As EntryMode,dbo.GetLookupDataDes(BranchID) as BranchName, 
		dbo.GetLookupDataDes(CurrenciesID) as Currency,AccountGroupID, dbo.GetTime(RecordDateTime) as RecordTime,LoginID
		from Accounts
		where AccountActionID =@AccountActionID and RecordDateTime between @StartDateTime and @EndDateTime and BranchID =@BranchID
		order by TranDate, RecordDateTime 
end

		
return 0

go

 -------------------------------Get Manage Account Credits---------------------------------------------
   
if exists (select * from sysobjects where name = 'uspGetManageAccountCredits')
	drop proc uspGetManageAccountCredits
go

create proc uspGetManageAccountCredits(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@BranchID varchar(10) = null
) with encryption as

----------------------------------------------------------------------------
declare @AccountActionID varchar(10)
set @AccountActionID = dbo.GetLookupDataID('AccountAction', 'CR')
----------------------------------------------------------------------------
if (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin
select dbo.FormatText(TranNo, 'Accounts', 'TranNo') as TranNo, 
		dbo.GetLookupDataDes(AccountBillModesID) as AccountCategory, dbo.GetLookupDataDes(PayModesID) as PayModes,
		dbo.GetLookupDataDes(EntryModeID) As EntryMode,dbo.GetLookupDataDes(BranchID) as BranchName, 
		AccountBillNo, dbo.GetAccountName(AccountBillModesID, AccountBillNo) as AccountName, Amount,DocumentNo, 
		dbo.GetLookupDataDes(CurrenciesID) as Currency,AccountGroupID, dbo.GetTime(RecordDateTime) as RecordTime,LoginID
		from Accounts
		where AccountActionID =@AccountActionID and RecordDateTime between @StartDateTime and @EndDateTime
		order by TranDate, RecordDateTime
end

else if not(@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin
select dbo.FormatText(TranNo, 'Accounts', 'TranNo') as TranNo, 
		dbo.GetLookupDataDes(AccountBillModesID) as AccountCategory, dbo.GetLookupDataDes(PayModesID) as PayModes,
		dbo.GetLookupDataDes(EntryModeID) As EntryMode, dbo.GetLookupDataDes(BranchID) as BranchName, 
		AccountBillNo, dbo.GetAccountName(AccountBillModesID, AccountBillNo) as AccountName, Amount,DocumentNo, 
		dbo.GetLookupDataDes(CurrenciesID) as Currency,AccountGroupID, dbo.GetTime(RecordDateTime) as RecordTime,LoginID
		from Accounts
		where AccountActionID =@AccountActionID and RecordDateTime between @StartDateTime and @EndDateTime and BranchID =@BranchID
		order by TranDate, RecordDateTime
end

		
return 0

go

 -------------------------------Get Other Payments--------------------------------------------
if exists (select * from sysobjects where name = 'UspGetOtherPayments')
	drop proc UspGetOtherPayments
go

create proc UspGetOtherPayments(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@PaymentsModeID varchar(10) = null,
@BranchID varchar(10) = null
)with encryption as
----------------------------------------------------------------------------
declare @ErrorMSG varchar(200)
----------------------------------------------------------------------------
if not(@PaymentsModeID is null) and not (@BranchID is null)
	begin
		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(PayNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, 
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		 dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayModesID =@PaymentsModeID and
		VisitCategoryID = @BranchID
		

		union

		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(FilterNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, 
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		 dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.FilterNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayModesID =@PaymentsModeID and
		VisitCategoryID = @BranchID

	end

	else if not (@PaymentsModeID is null) and (@BranchID is null)
	begin
		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(PayNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, VisitCategoryID,
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayModesID =@PaymentsModeID
		union

		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(FilterNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, 
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		 dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.FilterNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayModesID =@PaymentsModeID and
		VisitCategoryID = @BranchID
	end

		else if  not (@BranchID is null) and (@PaymentsModeID is null)
	begin
		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(PayNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, 
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName,VisitCategoryID, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and VisitCategoryID =@BranchID
		union

		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(FilterNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, 
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		 dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.FilterNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and
		VisitCategoryID = @BranchID
	end
else
	begin
		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(PayNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, 
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime
		union

		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(FilterNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, 
		dbo.GetFullName(LastName, MiddleName, FirstName) as OFullName,dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(FilterNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency,
		 dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.FilterNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime
	end

	return 0
go

-------------------------------Get Discounts---------------------------------------------
   
if exists (select * from sysobjects where name = 'uspGetDiscounts')
	drop proc uspGetDiscounts
go

create proc uspGetDiscounts(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@BranchID varchar(10) =null
) with encryption as


----------------------------------------------------------------------------
if (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin

select Payments.ReceiptNo As ReceiptNo, PaymentDetails. VisitNo,dbo.FormatDate(VisitDate)As VisitDate,
dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,dbo.FormatDate(PayDate)As PayDate,
dbo.GetItemName(ItemCategoryID, ItemCode) as ItemName,Discount,dbo.GetLookupDataDes(Payments.BranchID) as BranchName,
Payments.LoginID,dbo.GetTime(Payments.RecordDateTime) as RecordTime
from PaymentDetails 
inner join Payments on PaymentDetails.VisitNo = Payments.PayNo
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Discount > 0 and Payments.RecordDateTime between @StartDateTime and @EndDateTime
		order by  Payments.RecordDateTime
end

else if not(@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
begin

select Payments.ReceiptNo As ReceiptNo, PaymentDetails. VisitNo,dbo.FormatDate(VisitDate)As VisitDate,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
dbo.GetItemName(ItemCategoryID, ItemCode) as ItemName,Discount,dbo.GetLookupDataDes(Payments.BranchID) as BranchName,
Payments.LoginID,dbo.GetTime(Payments.RecordDateTime) as RecordTime
from PaymentDetails 
inner join Payments on PaymentDetails.VisitNo = Payments.PayNo
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Discount > 0 and Payments.RecordDateTime between @StartDateTime and @EndDateTime and Visits.BranchID =@BranchID
		order by  Payments.RecordDateTime
end		
return 0

go

------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-------------- IPDIncomeSummaries ------------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDIncomeSummaries')
	drop proc uspGetIPDIncomeSummaries
go

create proc uspGetIPDIncomeSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin

	declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	
	declare @COPAYVALUE varchar(3) 
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
	----------------------------------------------------------------------------
	set @COPAYVALUE = 'CPV'
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], 'Services' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,	
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems 
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @ServiceID and VisitDate between @StartDate and @EndDate
union
	select 2 as [No], 'Pharmacy' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @DrugID and VisitDate between @StartDate and @EndDate
union
	select 3 as [No], 'Consumables' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @ConsumableID and VisitDate between @StartDate and @EndDate
union
	select 4 as [No], 'Laboratory' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @TestID and VisitDate between @StartDate and @EndDate
union
	select 5 as [No], 'Radiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @RadiologyID and VisitDate between @StartDate and @EndDate
union
	select 6 as [No], 'Pathology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @PathologyID and VisitDate between @StartDate and @EndDate
union
	select 7 as [No], 'Dental' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @DentalID and VisitDate between @StartDate and @EndDate
union
	select 8 as [No], 'Theatre' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @TheatreID and VisitDate between @StartDate and @EndDate
union
	select 9 as [No], 'Optical' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @OpticalID and VisitDate between @StartDate and @EndDate
union
	select 10 as [No], 'Procedures' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @ProcedureID and VisitDate between @StartDate and @EndDate
union
	select 11 as [No], 'Extra Charge(s)' as IncomeCategory, 
	sum(case when (ExtraBillItems.ItemCode = @COPAYVALUE and ExtraBillItems.UnitPrice < 0) then 0 else (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
union
	select 12 as [No], 'Grand Total' as IncomeCategory, 
	sum(case when (ExtraBillItems.ItemCategoryID = @ExtrasID and ExtraBillItems.ItemCode = @COPAYVALUE and ExtraBillItems.UnitPrice < 0) then 0 else (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,	
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where VisitDate between @StartDate and @EndDate
end
return 0
go

-- exec uspGetIPDIncomeSummaries '1 May 2015', '3 May 2015'

-------------------------------------------------------------------------------------------------
-------------- ExtraChargeSummaries -------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDExtraChargeSummaries')
	drop proc uspGetIPDExtraChargeSummaries
go

create proc uspGetIPDExtraChargeSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin

	declare @ExtrasID varchar(10)
	declare @COPAYVALUE varchar(3) 
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
	set @COPAYVALUE = 'CPV'
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExtraChargeCategory, 
	sum(case when (ExtraBillItems.ItemCode = @COPAYVALUE and ExtraBillItems.UnitPrice < 0) then 0 else (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
	group by dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode)
union
	select 2 as [No], 'Grand Total' as ExtraChargeCategory, 
	sum(case when (ExtraBillItems.ItemCode = @COPAYVALUE and ExtraBillItems.UnitPrice < 0) then 0 else (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) end) as TotalAmount,
	sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (CashPayStatusID = @NotPaidPayStatus) then (CashAmount) else 0 end) as CoPayNotPaid,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
	order by [No], [ExtraChargeCategory]
end
return 0
go

-- exec uspGetIPDExtraChargeSummaries '1 Oct 2012', '31 Oct 2012'

-------------------------------------------------------------------------------------------------
-------------- IPDDoctorVisitSummaries -------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDDoctorVisitSummaries')
	drop proc uspGetIPDDoctorVisitSummaries
go

create proc uspGetIPDDoctorVisitSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
		
	declare @ServiceID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], case dbo.GetSeenDoctor(Visits.VisitNo) when '' then 'SELF REQUEST' else dbo.GetSeenDoctor(Visits.VisitNo) end as SeenDoctor, 
	count(distinct Visits.VisitNo) as TotalVisits,	
	sum(case when (ExtraBillItems.ItemCategoryID = @ServiceID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalOnServices,
	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
		left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where VisitDate between @StartDate and @EndDate
	group by dbo.GetSeenDoctor(Visits.VisitNo)
union
	select 2 as [No], 'Grand Total' as DoctorVisitCategory, count(distinct Visits.VisitNo) as TotalVisits,
	sum(case when (ExtraBillItems.ItemCategoryID = @ServiceID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalOnServices,
	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
		left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where VisitDate between @StartDate and @EndDate
	order by [No], [SeenDoctor]
end
return 0
go

-- exec uspGetIPDDoctorVisitSummaries '1 Oct 2013', '31 Oct 2013'

-------------------------------------------------------------------------------------------------
-------------- IPDDoctorSpecialtyVisitSummaries ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDDoctorSpecialtyVisitSummaries')
	drop proc uspGetIPDDoctorSpecialtyVisitSummaries
go

create proc uspGetIPDDoctorSpecialtyVisitSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
		
	declare @ServiceID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], case dbo.GetSeenDoctorSpecialty(Visits.VisitNo) when '' then 'SELF REQUEST' else dbo.GetSeenDoctorSpecialty(Visits.VisitNo) end as SeenDoctorSpecialty, 
	count(distinct Visits.VisitNo) as TotalVisits,	
	sum(case when (ExtraBillItems.ItemCategoryID = @ServiceID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalOnServices,
	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where VisitDate between @StartDate and @EndDate
	group by dbo.GetSeenDoctorSpecialty(Visits.VisitNo)
union
	select 2 as [No], 'Grand Total' as DoctorSpecialtyVisitCategory, count(distinct Visits.VisitNo) as TotalVisits,
	sum(case when (ExtraBillItems.ItemCategoryID = @ServiceID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalOnServices,
	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where VisitDate between @StartDate and @EndDate
	order by [No], [SeenDoctorSpecialty]
end
return 0
go

-- exec uspGetIPDDoctorSpecialtyVisitSummaries '1 Oct 2013', '31 Oct 2013'

if exists (select * from sysobjects where name = 'uspIPDGetDoctorVisitSummaries')
	drop proc uspIPDGetDoctorVisitSummaries
go

create proc uspIPDGetDoctorVisitSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
		
	declare @ServiceID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------

	select 1 as [No], case dbo.GetSeenDoctor(Visits.VisitNo) when '' then 'SELF REQUEST' else dbo.GetSeenDoctor(Visits.VisitNo) end as SeenDoctor, 
	count(distinct Visits.VisitNo) as TotalVisits,	
	sum(case when (ExtraBillItems.ItemCategoryID = @ServiceID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalOnServices,
	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where VisitDate between @StartDate and @EndDate
	group by dbo.GetSeenDoctor(Visits.VisitNo)
union
	select 2 as [No], 'Grand Total' as DoctorVisitCategory, count(distinct Visits.VisitNo) as TotalVisits,
	sum(case when (ExtraBillItems.ItemCategoryID = @ServiceID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalOnServices,
	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, sum(CashAmount) as CoPayAmount, sum(Discount) as CashDiscount,
	sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashAmount, sum(Amount) as CashPaid,	
	isnull(sum(CashAmount), 0) + sum(case when (BillModesID = @CashBillModesID) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as TotalCash,
	sum(case when (BillModesID = @CashBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) else 0 end) as CashNotPaid,
	sum(case when (BillModesID = @AccountBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountAmount,
	sum(case when (BillModesID = @AccountBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as AccountNotPaid,
	sum(case when (BillModesID = @InsuranceBillModesID) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceAmount,
	sum(case when (BillModesID = @InsuranceBillModesID and PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as InsuranceNotPaid
	from ExtraBillItems  
	left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
	left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
	and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
	where VisitDate between @StartDate and @EndDate
	order by [No], [SeenDoctor]
end
return 0
go

-- exec uspIPDGetDoctorVisitSummaries '1 Mar 2016', '31 Mar 2016'
-------------- IPDIncomeSummariesByBills -----------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDIncomeSummariesByBills')
	drop proc uspGetIPDIncomeSummariesByBills
go

create proc uspGetIPDIncomeSummariesByBills(
@StartDate smalldatetime,
@EndDate smalldatetime,
@BillModesID varchar(10),
@BillNo varchar(20),
@CompanyNo varchar(20) = null
) with encryption as

begin
	
	declare @ErrorMSG varchar(200)

	declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @CashBillModes varchar(100)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
		
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
		
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @CashBillModes = dbo.GetLookupDataDes(@CashBillModesID)
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
			
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------
	
if (@BillModesID = @CashBillModesID)
	begin
		set @ErrorMSG = 'Bill mode cash not supported!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else

if (@BillModesID = @AccountBillModesID) and (@BillNo = @CashBillModes)
	begin
		set @ErrorMSG = 'Bill No for Bill Mode Account can''t be Cash!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else
	if (@BillModesID = @AccountBillModesID) -- Bill Account 
		 if not(@CompanyNo is null)
			begin
				select 1 as [No], 'Services' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems 
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ServiceID and VisitDate between @StartDate and @EndDate				
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 2 as [No], 'Pharmacy' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @DrugID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 3 as [No], 'Consumables' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ConsumableID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 
			union
				select 4 as [No], 'Laboratory' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @TestID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 5 as [No], 'Radiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @RadiologyID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 6 as [No], 'Pathology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @PathologyID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 
			union
				select 7 as [No], 'Dental' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @DentalID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 8 as [No], 'Theatre' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @TheatreID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 9 as [No], 'Optical' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @OpticalID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 10 as [No], 'Procedures' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ProcedureID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 12 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			end
		else
		begin
			select 1 as [No], 'Services' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems 
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ServiceID and VisitDate between @StartDate and @EndDate	
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 2 as [No], 'Pharmacy' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @DrugID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 	
		union
			select 3 as [No], 'Consumables' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ConsumableID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 4 as [No], 'Laboratory' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @TestID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 5 as [No], 'Radiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @RadiologyID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 			
		union
			select 6 as [No], 'Pathology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @PathologyID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 	
		union
			select 7 as [No], 'Dental' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @DentalID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 8 as [No], 'Theatre' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @TheatreID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 9 as [No], 'Optical' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @OpticalID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 10 as [No], 'Procedures' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ProcedureID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		union
			select 12 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
		end
	else if (@BillModesID = @InsuranceBillModesID) -- Bill Insurance
		 if not(@CompanyNo is null)
			begin
				select 1 as [No], 'Services' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems 
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ServiceID and VisitDate between @StartDate and @EndDate	
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 2 as [No], 'Pharmacy' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @DrugID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 3 as [No], 'Consumables' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ConsumableID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 4 as [No], 'Laboratory' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @TestID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 5 as [No], 'Radiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @RadiologyID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo				
			union
				select 6 as [No], 'Pathology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @PathologyID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 7 as [No], 'Dental' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @DentalID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 8 as [No], 'Theatre' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @TheatreID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 9 as [No], 'Optical' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @OpticalID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 10 as [No], 'Procedures' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ProcedureID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			union
				select 12 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
			end
		else
		begin
			select 1 as [No], 'Services' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems 
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
		     inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ServiceID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 2 as [No], 'Pharmacy' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @DrugID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 3 as [No], 'Consumables' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ConsumableID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 4 as [No], 'Laboratory' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @TestID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 5 as [No], 'Radiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @RadiologyID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 6 as [No], 'Pathology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @PathologyID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 7 as [No], 'Dental' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @DentalID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 8 as [No], 'Theatre' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @TheatreID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 9 as [No], 'Optical' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @OpticalID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 10 as [No], 'Procedures' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ProcedureID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 11 as [No], 'Extra Charge(s)' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount,
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 12 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		end	
	end
return 0
go

-- exec uspGetIPDIncomeSummariesByBills '1 Oct 2015', '31 Oct 2015', '17A', 'GMC'
-- exec uspGetIPDIncomeSummariesByBills '1 Oct 2015', '31 Oct 2015', '17A', '100041A'
-- exec uspGetIPDIncomeSummariesByBills '1 Oct 2015', '31 Oct 2015', '17A', '100041A', '100105A'
-- exec uspGetIPDIncomeSummariesByBills '1 Oct 2015', '31 Oct 2015', '17I', 'CMC'
-- exec uspGetIPDIncomeSummariesByBills '1 Oct 2015', '31 Oct 2015', '17I', 'CMC', 'URA'
-- exec uspGetIPDIncomeSummariesByBills '1 Oct 2015', '31 Oct 2015', '17A', 'CASH'
-- exec uspGetIPDIncomeSummariesByBills '1 Oct 2015', '31 Oct 2015', '17C', 'CASH'

-------------------------------------------------------------------------------------------------
-------------- uspGetIPDIncomePaymentDetailsSummaries ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDIncomePaymentDetailsSummaries')
	drop proc uspGetIPDIncomePaymentDetailsSummaries
go

create proc uspGetIPDIncomePaymentDetailsSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime
) with encryption as

begin
		
	declare @VisitBillID varchar(10)
	declare @RecordStartDate smalldatetime
	declare @RecordEndDate smalldatetime

	--------------------------------------------------------------------------------------------------------
	set @VisitBillID = dbo.GetLookupDataID('PayType', 'EXT')	
	set @RecordStartDate = dbo.GetShortDate(@StartDate)
	set @RecordEndDate = dbo.GetShortDate(dateadd(day, 1, @EndDate))
	--------------------------------------------------------------------------------------------------------
		
	select 1 as [No], PaymentExtraBillItems.ReceiptNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(Amount)) as TotalAmount, 
	dbo.GetWaitingDays(VisitDate, Payments.RecordDateTime) as PaidAfterDays,
	dbo.GetShortDate(Payments.RecordDateTime) as RecordDate, 
	dbo.GetTime(Payments.RecordDateTime) as RecordTime
	from PaymentExtraBillItems
	inner join Payments on Payments.ReceiptNo = PaymentExtraBillItems.ReceiptNo
	left outer join Visits on Payments.PayNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Payments.PayTypeID = @VisitBillID and 
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate)
	group by PaymentExtraBillItems.ReceiptNo, ItemCategoryID, LastName, MiddleName, FirstName, 
			VisitDate, Payments.RecordDateTime
union
	select 2 as [No], 'Grand Total' as ReceiptNo, '' as VisitDate, '' as FullName, 
	'' as ItemCategory, Sum(Abs(Amount)) as TotalAmount, '' as PaidAfterDays,
	'' as RecordDate, '' as RecordTime
	from PaymentExtraBillItems 
	inner join Payments on Payments.ReceiptNo = PaymentExtraBillItems.ReceiptNo
	left outer join Visits on Payments.PayNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Payments.PayTypeID = @VisitBillID and 
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate)
	
end
return 0
go

-- exec uspGetIPDIncomePaymentDetailsSummaries '1 April 2016', '27 April 2016'


if exists (select * from sysobjects where name = 'uspGetIPDExtraChargeSummariesByBills')
	drop proc uspGetIPDExtraChargeSummariesByBills
go

create proc uspGetIPDExtraChargeSummariesByBills(
@StartDate smalldatetime,
@EndDate smalldatetime,
@BillModesID varchar(10),
@BillNo varchar(20),
@CompanyNo varchar(20) = null
) with encryption as

begin

	declare @ErrorMSG varchar(200)
	
	declare @ExtrasID varchar(10)
	
	declare @CashBillModesID varchar(10)
	declare @CashBillModes varchar(100)
	declare @AccountBillModesID varchar(10)
	declare @InsuranceBillModesID varchar(10)
	
	declare @NotPaidPayStatus  varchar(10)

	----------------------------------------------------------------------------
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
	
	----------------------------------------------------------------------------
	set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
	set @CashBillModes = dbo.GetLookupDataDes(@CashBillModesID)
	set @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsuranceBillModesID = dbo.GetLookupDataID('BillModes', 'I')
	
	----------------------------------------------------------------------------
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	----------------------------------------------------------------------------
	
if (@BillModesID = @CashBillModesID)
	begin
		set @ErrorMSG = 'Bill mode cash not supported!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else

if (@BillModesID = @AccountBillModesID) and (@BillNo = @CashBillModes)
	begin
		set @ErrorMSG = 'Bill No for Bill Mode Account can''t be Cash!'
		raiserror(@ErrorMSG,16, 1)	
		return 1
	end
else
	if (@BillModesID = @AccountBillModesID) -- Bill Account 
		 if not(@CompanyNo is null)
			begin				
				select 1 as [No], dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExtraChargeCategory, 
				sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			  inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate				
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
				group by dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode)
			union
				select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				  inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate				
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
				order by [No], [ExtraChargeCategory]
			end
		else
		begin
			select 1 as [No], dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExtraChargeCategory, 
			sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			  inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
			group by dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode)
		union
			select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
  inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 
			order by [No], [ExtraChargeCategory]

		end
	else if (@BillModesID = @InsuranceBillModesID) -- Bill Insurance
		 if not(@CompanyNo is null)
			begin				
				select 1 as [No], dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExtraChargeCategory, 
				sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				  inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	              inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
				group by dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode)
			union
				select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
				sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
				sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
				from ExtraBillItems  
				left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
				left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
				and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
				inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	            inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
				where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo
				order by [No], [ExtraChargeCategory]
			end
		else
		begin			
			select 1 as [No], dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExtraChargeCategory, 
			sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
			inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
			where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
			group by dbo.GetItemName(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode)
		union
			select 2 as [No], 'Grand Total' as ExtraChargeCategory,	sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 				
			sum(ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) as BillAmount,				
			sum(case when (PayStatusID = @NotPaidPayStatus) then (ExtraBillItems.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, ExtraBillItems.UnitPrice)) else 0 end) as BillNotPaid
			from ExtraBillItems  
			left outer join ExtraBillItemsCASH on ExtraBillItemsCASH.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and ExtraBillItemsCASH.ItemCode = ExtraBillItems.ItemCode and ExtraBillItemsCASH.ItemCategoryID = ExtraBillItems.ItemCategoryID
			left outer join PaymentExtraBillItems on PaymentExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo	
			and PaymentExtraBillItems.ItemCode = ExtraBillItems.ItemCode and PaymentExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
		    inner join ExtraBills on ExtraBills.ExtraBillNo = ExtraBillItems.ExtraBillNo
	        inner join Visits  on ExtraBills.VisitNo = Visits.VisitNo
		    where ExtraBillItems.ItemCategoryID = @ExtrasID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
			order by [No], [ExtraChargeCategory]
		end	
end
return 0
go

-- exec uspGetIPDExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', 'GMC'
-- exec uspGetIPDExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', '100041A'
-- exec uspGetIPDExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', '100041A', '100105A'
-- exec uspGetIPDExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17I', 'CMC'
-- exec uspGetIPDExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17I', 'CMC', 'URA'
-- exec uspGetIPDExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17A', 'CASH'
-- exec uspGetIPDExtraChargeSummariesByBills '1 Oct 2012', '31 Oct 2012', '17C', 'CASH'

-------------------------------------------------------------------------------------------------
-------------- GetOPDDoctorVisitsCount -------------------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetOPDDoctorVisitsCount')
	drop proc uspGetOPDDoctorVisitsCount
go

create proc uspGetOPDDoctorVisitsCount(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@ItemCategoryID varchar(10)
)
with encryption as
declare @ErrorMSG varchar(200)
begin
select count(DoctorVisits.VisitNo) as SeenVisits, dbo.GetLookupDataDes(BillModesID) as BillMode,
case dbo.GetSeenDoctorSpecialty(Visits.VisitNo) when '' then 'SELF REQUEST' else dbo.GetSeenDoctorSpecialty(Visits.VisitNo) end as SeenSpeciality, 
dbo.GetStaffName(DoctorVisits.StaffNo) as SeenDoctor from DoctorVisits
inner join Visits on DoctorVisits.VisitNo = visits.VisitNo
inner join Items on DoctorVisits.VisitNo = Items.VisitNo
where Visits.RecordDateTime between @StartDateTime and @EndDateTime and Items.ItemCategoryID = @ItemCategoryID
group by dbo.GetStaffName(DoctorVisits.StaffNo),dbo.GetSeenDoctorSpecialty(Visits.VisitNo),dbo.GetLookupDataDes(BillModesID)
end
return 0
go
-------------------------------------------------------------------------------------------------
-------------- Get SchemeMembers MainMember -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSchemeMembersMainMember')
	drop proc uspGetSchemeMembersMainMember
go

create proc uspGetSchemeMembersMainMember(
@MainMemberNo varchar(20)=null
)with encryption as

declare @ErrorMSG varchar(200)

if not (@MainMemberNo is null)
begin
	if not exists(select MainMemberNo from SchemeMembers where MainMemberNo = @MainMemberNo)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Main Member No', @MainMemberNo, 'Scheme Members')
		return 1
	end
	else
	begin
	select  dbo.GetLookupDataDes(MemberTypeID) as MemberType, 
	MainMemberNo, dbo.GetSchemeMemberName(MainMemberNo) as MainMemberName,
	MedicalCardNo, SchemeMembers.CompanyNo, CompanyName
	from SchemeMembers	
	inner join InsuranceSchemes on InsuranceSchemes.CompanyNo = SchemeMembers.CompanyNo
	and InsuranceSchemes.PolicyNo = SchemeMembers.PolicyNo
	inner join Companies on InsuranceSchemes.CompanyNo = Companies.CompanyNo
	where MainMemberNo = @MainMemberNo
	end
end


go


/******************************************************************************************************
exec uspGetSchemeMembersMainMember '150000100'

******************************************************************************************************/

-------------- Get SchemeMembersMainMemberConsumption -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSchemeMembersMainMemberConsumption')
	drop proc uspGetSchemeMembersMainMemberConsumption
go

create proc uspGetSchemeMembersMainMemberConsumption(
@MainMemberNo varchar(20)=null,
@StartDate smalldatetime = null,
@EndDate smalldatetime = null
)with encryption as

declare @ErrorMSG varchar(200)

if not (@MainMemberNo is null)
begin
	
select dbo.GetLookupDataDes(MembertypeID) as Membertype, (SchemeMembers.MedicalCardNo) as MedicalCardNo,(ClaimsEXT.ClaimNo) as ClaimNo,MainMemberNo,MainMemberName,
dbo.GetFullName(SchemeMembers.Surname, SchemeMembers.MiddleName, SchemeMembers.FirstName) as FullName,(ClaimsEXT.VisitNo) as VisitNo,(Claims.PatientNo) as PatientNo,
dbo.FormatMoney(dbo.GetClaimAmount(Claims.ClaimNo)) As ClaimAmount
from Visits
--inner join Items on Items.VisitNo = Visits.VisitNo
inner join ClaimsEXT on Visits.VisitNo = ClaimsEXT.VisitNo
inner join Claims on ClaimsEXT.ClaimNo =Claims.ClaimNo
inner join SchemeMembers on Claims.MedicalCardNo = SchemeMembers.MedicalCardNo
where MainMemberNo =@MainMemberNo and Claims.RecordDateTime between @StartDate and @EndDate
Group by Visits.VisitNo,MembertypeID,SchemeMembers.MedicalCardNo,ClaimsEXT.ClaimNo,MainMemberNo,MainMemberName,
dbo.GetFullName(SchemeMembers.Surname, SchemeMembers.MiddleName, SchemeMembers.FirstName),ClaimsEXT.VisitNo,Claims.PatientNo,
dbo.FormatMoney(dbo.GetClaimAmount(Claims.ClaimNo))
	end

go


/******************************************************************************************************
exec uspGetSchemeMembersMainMemberConsumption '160000800','1 jan 15','9 sep 16'

******************************************************************************************************/

------------- Get SchemeMembers MainMember Consumption Details -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSchemeMembersMainMemberConsumptionDetails')
	drop proc uspGetSchemeMembersMainMemberConsumptionDetails
go

create proc uspGetSchemeMembersMainMemberConsumptionDetails(
@MainMemberNo varchar(20)=null,
@StartDate smalldatetime = null,
@EndDate smalldatetime = null
)with encryption as

declare @ErrorMSG varchar(200)

if not (@MainMemberNo is null)
begin
	
select dbo.GetLookupDataDes(MembertypeID) as Membertype, dbo.GetFullName(SchemeMembers.Surname, SchemeMembers.MiddleName, SchemeMembers.FirstName) as FullName,
ItemName,Visits.VisitNo,Claims.ClaimNo,
MainMemberNo,Claims.MedicalCardNo,UnitPrice,Quantity,Amount
from  Visits 
inner join ClaimsEXT on Visits.VisitNo = ClaimsEXT.VisitNo
inner join Claims on ClaimsEXT.ClaimNo =Claims.ClaimNo
inner join ClaimDetails on Claims.ClaimNo = ClaimDetails.ClaimNo
inner join SchemeMembers on Claims.MedicalCardNo = SchemeMembers.MedicalCardNo
where MainMemberNo =@MainMemberNo and Claims.RecordDateTime between @StartDate and @EndDate
order by Claims.RecordDateTime desc
end

go

/******************************************************************************************************
exec uspGetSchemeMembersMainMemberConsumptionDetails '160001700','1 jan 15','9 sep 16'

******************************************************************************************************/


if exists (select * from sysobjects where name = 'GetTimelySMSIncomeSummaries')
	drop function GetTimelySMSIncomeSummaries
go

create function GetTimelySMSIncomeSummaries(@startDateTime as smalldatetime, @EndDateTime as smalldatetime) returns varchar(2000)
with encryption as
begin

declare @Account varchar(100)
declare @Amount int
declare @AccountDetails varchar(2000)

set @AccountDetails = ''

begin
	
DECLARE AccountDetails_Cursor CURSOR FOR

select  (dbo.GetLookupDataDes(PayModesID))  As PayMode,dbo.FormatMoney(SUM(AmountTendered-Change)) as TotalEarned from Payments
where RecordDateTime between @startDateTime And @EndDateTime
Group by PayModesID
OPEN AccountDetails_Cursor
	FETCH NEXT FROM AccountDetails_Cursor INTO @Account, @Amount
	WHILE (@@FETCH_STATUS <> -1)
		BEGIN
				SET @AccountDetails = @AccountDetails + @Account + ': ' + cast(@Amount as varchar(12)) + ', '
				FETCH NEXT FROM AccountDetails_Cursor INTO @Account, @Amount
		END

	CLOSE AccountDetails_Cursor
	DEALLOCATE AccountDetails_Cursor

if len(@AccountDetails) > 0 set @AccountDetails = left(@AccountDetails, len(@AccountDetails)-1)
end

return @AccountDetails

end

go



----------------------------------------------------------------------------------------------------------------
-- print dbo.GetTimelySMSIncomeSummaries('14 dec 16  12:00:00', '14 dec 16 12:00:00')
--select TOP 1 dbo.GetTimelySMSIncomeSummaries('14 dec 16  12:00:00', '14 dec 16 18:00:00') as finalMoney from Payments
----------------------------------------------------------------------------------------------------------------




