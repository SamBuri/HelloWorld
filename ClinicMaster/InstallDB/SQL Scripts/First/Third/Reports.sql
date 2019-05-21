
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
	declare @CardiologyID varchar(10)
	
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
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
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
	select 12 as [No], 'Cardiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
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
	where Items.ItemCategoryID = @CardiologyID and items.RecordDateTime between @StartDate and @EndDate
union
	select 13 as [No], 'Grand Total' as IncomeCategory, 
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

-- exec uspGetIncomeSummaries '13 Mar 2016 12:00 AM', '13 Mar 2016 7:00 PM'

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



-------------- usp Get InvoiceCategorization -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetInvoiceCategorization')
	drop proc uspGetInvoiceCategorization
go

create proc uspGetInvoiceCategorization(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@ExcludePendingItems bit,
@PatientNo varchar(20)=null,
@BillNo varchar(20)=null
)with encryption as

    declare @ErrorMSG varchar(200)
    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
  declare @Total money

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
   

begin
if @PatientNo is null and not (@BillNo is null)
	begin
     
        (select dbo.GetVisitClaimReferenceNo(visits.VisitNo) as ClaimReferenceNo,dbo.GetVisitMainMemberName(visits.VisitNo) as MainMemberName,
		dbo.GetInvoiceCategoryOPDINvoiceNo(visits.VisitNo) as InvoiceNo,
		dbo.FormatDate(visitdate) as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,visits.MemberCardNo,
        dbo.GetBillName(visits.BillModesID, visits.BillNo) as BillCustomerName, dbo.GetPeriodicTotalPerService(visits.VisitNo,@ServiceID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as services,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@DrugID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Drug, dbo.GetPeriodicTotalPerService(visits.VisitNo,@ConsumableID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Consumable,
		dbo.GetPeriodicTotalPerService(visits.VisitNo,@TestID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Laboratory,dbo.GetPeriodicTotalPerService(visits.VisitNo,@CardiologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Cardiology,
        
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@TestID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Laboratory,dbo.GetPeriodicTotalPerService(visits.VisitNo,@RadiologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Radiology,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@PathologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Pathology,dbo.GetPeriodicTotalPerService(visits.VisitNo,@DentalID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Dental,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@TheatreID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Theatre,dbo.GetPeriodicTotalPerService(visits.VisitNo,@OpticalID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Optical,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@ProcedureID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as ProcedureID,dbo.GetPeriodicTotalPerService(visits.VisitNo,@ExtrasID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Extras,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@MaternityID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Maternity,dbo.GetPeriodicTotalPerService(visits.VisitNo,@ICUID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as ICUID,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@EyeID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Eye,dbo.GetPeriodicTotalPerService(visits.VisitNo,@AdmissionID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Admission,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@PackageID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Packages,dbo.GetPeriodicTotalPerService(visits.VisitNo,null,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Total
    from visits
     inner join Patients on Visits.PatientNo = Patients.PatientNo
	where visits.RecordDateTime between dbo.FormatDate(@StartDateTime) and dbo.FormatDate(@EndDateTime) 
    and (BillNo=@BillNo or insuranceno=@BillNo) and dbo.GetPeriodicTotalPerService(visits.VisitNo,null,@ExcludePendingItems,@StartDateTime,@EndDateTime) > 0)
    order by visits.RecordDateTime asc
 end

else if not (@PatientNo is null)  and @BillNo is  null
	begin	
       select dbo.GetVisitClaimReferenceNo(visits.VisitNo) as ClaimReferenceNo,dbo.GetVisitMainMemberName(visits.VisitNo) as MainMemberName, dbo.GetInvoiceCategoryOPDINvoiceNo(visits.VisitNo) as InvoiceNo,dbo.FormatDate(visitdate)as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,visits.MemberCardNo,
        dbo.GetBillName(visits.BillModesID, visits.BillNo) as BillCustomerName, dbo.GetPeriodicTotalPerService(visits.VisitNo,@ServiceID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as services,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@DrugID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Drug, dbo.GetPeriodicTotalPerService(visits.VisitNo,@ConsumableID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Consumable,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@TestID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Laboratory,
		dbo.GetPeriodicTotalPerService(visits.VisitNo,@CardiologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Cardiology,

		dbo.GetPeriodicTotalPerService(visits.VisitNo,@RadiologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Radiology,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@PathologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Pathology,dbo.GetPeriodicTotalPerService(visits.VisitNo,@DentalID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Dental,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@TheatreID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Theatre,dbo.GetPeriodicTotalPerService(visits.VisitNo,@OpticalID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Optical,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@ProcedureID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as ProcedureID,dbo.GetPeriodicTotalPerService(visits.VisitNo,@ExtrasID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Extras,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@MaternityID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Maternity,dbo.GetPeriodicTotalPerService(visits.VisitNo,@ICUID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as ICUID,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@EyeID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Eye,dbo.GetPeriodicTotalPerService(visits.VisitNo,@AdmissionID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Admission,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@PackageID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Packages,dbo.GetPeriodicTotalPerService(visits.VisitNo,null,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Total
      from visits
    inner join Patients on Visits.PatientNo = Patients.PatientNo
	where visits.RecordDateTime between dbo.FormatDate(@StartDateTime) and dbo.FormatDate(@EndDateTime) and
    Visits.PatientNo = @PatientNo and dbo.GetPeriodicTotalPerService(visits.VisitNo,null,@ExcludePendingItems,@StartDateTime,@EndDateTime) > 0
 order by visits.RecordDateTime asc
end

else
	begin	
    select dbo.GetVisitClaimReferenceNo(visits.VisitNo) as ClaimReferenceNo,dbo.GetVisitMainMemberName(visits.VisitNo) as MainMemberName, dbo.GetInvoiceCategoryOPDINvoiceNo(visits.VisitNo) as InvoiceNo,dbo.FormatDate(visitdate)as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,visits.MemberCardNo,
        dbo.GetBillName(visits.BillModesID, visits.BillNo) as BillCustomerName,dbo.GetPeriodicTotalPerService(visits.VisitNo,@ServiceID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as services,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@DrugID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Drug, dbo.GetPeriodicTotalPerService(visits.VisitNo,@ConsumableID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Consumable,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@TestID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Laboratory,
		dbo.GetPeriodicTotalPerService(visits.VisitNo,@CardiologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Cardiology,
        
		dbo.GetPeriodicTotalPerService(visits.VisitNo,@RadiologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Radiology,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@PathologyID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Pathology,dbo.GetPeriodicTotalPerService(visits.VisitNo,@DentalID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Dental,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@TheatreID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Theatre,dbo.GetPeriodicTotalPerService(visits.VisitNo,@OpticalID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Optical,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@ProcedureID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as ProcedureID,dbo.GetPeriodicTotalPerService(visits.VisitNo,@ExtrasID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Extras,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@MaternityID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Maternity,dbo.GetPeriodicTotalPerService(visits.VisitNo,@ICUID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as ICUID,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@EyeID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Eye,dbo.GetPeriodicTotalPerService(visits.VisitNo,@AdmissionID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Admission,
        dbo.GetPeriodicTotalPerService(visits.VisitNo,@PackageID,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Packages,dbo.GetPeriodicTotalPerService(visits.VisitNo,null,@ExcludePendingItems,@StartDateTime,@EndDateTime) as Total
       from visits
    inner join Patients on Visits.PatientNo = Patients.PatientNo
    where visits.RecordDateTime between dbo.FormatDate(@StartDateTime) and dbo.FormatDate(@EndDateTime)
    and dbo.GetPeriodicTotalPerService(visits.VisitNo,null,@ExcludePendingItems,@StartDateTime,@EndDateTime) > 0
    order by visits.RecordDateTime asc 
end
return 0
end
go


-------------- usp Get ipdInvoiceCategorization -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDInvoiceCategorization')
	drop proc uspGetIPDInvoiceCategorization
go

create proc uspGetIPDInvoiceCategorization(
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@ExcludePaidFor bit,
@PatientNo varchar(20)=null,
@BillNo varchar(20)=null
)with encryption as

    declare @ErrorMSG varchar(200)
    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
  declare @Total money

	----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
   

begin
if @PatientNo is null and not (@BillNo is null)
	begin
     
        (select
		dbo.GetInvoiceCategoryIPDINvoiceNo(visits.VisitNo) as InvoiceNo,dbo.GetVisitClaimReferenceNo(visits.VisitNo) as ClaimReferenceNo,dbo.GetVisitMainMemberName(visits.VisitNo) as MainMemberName,
		 dbo.FormatDate(visitdate)as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,visits.MemberCardNo,
        dbo.GetBillName(visits.BillModesID, visits.BillNo) as BillCustomerName, dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ServiceID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as services,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@DrugID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Drug, dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ConsumableID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Consumable,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@TestID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Laboratory,
		dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@CardiologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Cardiology,

		dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@RadiologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Radiology,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@PathologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Pathology,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@DentalID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Dental,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@TheatreID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Theatre,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@OpticalID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Optical,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ProcedureID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as ProcedureID,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ExtrasID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Extras,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@MaternityID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Maternity,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ICUID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as ICUID,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@EyeID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Eye,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@AdmissionID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Admission,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@PackageID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Packages,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,null,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Total
    from visits
     inner join Patients on Visits.PatientNo = Patients.PatientNo
	where visits.RecordDateTime between dbo.FormatDate(@StartDateTime) and dbo.FormatDate(@EndDateTime) 
    and (BillNo=@BillNo or insuranceno=@BillNo) and dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,null,@ExcludePaidFor,@StartDateTime,@EndDateTime) > 0)
    order by visits.RecordDateTime asc
 end

else if not (@PatientNo is null)  and @BillNo is  null
	begin	
       (select dbo.GetInvoiceCategoryIPDINvoiceNo(visits.VisitNo) as InvoiceNo,dbo.GetVisitClaimReferenceNo(visits.VisitNo) as ClaimReferenceNo,dbo.GetVisitMainMemberName(visits.VisitNo) as MainMemberName, dbo.FormatDate(visitdate)as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,visits.MemberCardNo,
        dbo.GetBillName(visits.BillModesID, visits.BillNo) as BillCustomerName, dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ServiceID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as services,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@DrugID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Drug, dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ConsumableID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Consumable,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@TestID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Laboratory,
		dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@CardiologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Cardiology,

		dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@RadiologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Radiology,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@PathologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Pathology,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@DentalID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Dental,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@TheatreID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Theatre,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@OpticalID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Optical,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ProcedureID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as ProcedureID,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ExtrasID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Extras,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@MaternityID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Maternity,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ICUID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as ICUID,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@EyeID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Eye,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@AdmissionID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Admission,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@PackageID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Packages,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,null,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Total
      from visits
    inner join Patients on Visits.PatientNo = Patients.PatientNo
	where visits.RecordDateTime between dbo.FormatDate(@StartDateTime) and dbo.FormatDate(@EndDateTime) and
    Visits.PatientNo = @PatientNo and dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,null,@ExcludePaidFor,@StartDateTime,@EndDateTime) > 0)
 order by visits.RecordDateTime asc
end

else
	begin	
    (select dbo.GetInvoiceCategoryIPDINvoiceNo(visits.VisitNo) as InvoiceNo,dbo.GetVisitClaimReferenceNo(visits.VisitNo) as ClaimReferenceNo,dbo.GetVisitMainMemberName(visits.VisitNo) as MainMemberName,dbo.FormatDate(visitdate)as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,visits.MemberCardNo,
        dbo.GetBillName(visits.BillModesID, visits.BillNo) as BillCustomerName,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ServiceID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as services,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@DrugID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Drug, dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ConsumableID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Consumable,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@TestID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Laboratory,
		dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@CardiologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Cardiology,
        
		dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@RadiologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Radiology,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@PathologyID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Pathology,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@DentalID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Dental,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@TheatreID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Theatre,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@OpticalID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Optical,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ProcedureID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as ProcedureID,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ExtrasID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Extras,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@MaternityID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Maternity,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@ICUID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as ICUID,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@EyeID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Eye,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@AdmissionID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Admission,
        dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,@PackageID,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Packages,dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,null,@ExcludePaidFor,@StartDateTime,@EndDateTime) as Total
       from visits
    inner join Patients on Visits.PatientNo = Patients.PatientNo
    where visits.RecordDateTime between dbo.FormatDate(@StartDateTime) and dbo.FormatDate(@EndDateTime)
    and dbo.GetIPDPeriodicTotalPerService(visits.VisitNo,null,@ExcludePaidFor,@StartDateTime,@EndDateTime) > 0)
order by visits.RecordDateTime asc 
end
return 0
end
go



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
	declare @CardiologyID varchar(10)
	
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
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
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
				select 12 as [No], 'Cardiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @CardiologyID and Items.RecordDateTime between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 13 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
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
			select 12 as [No], 'Cardiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @CardiologyID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 			
		union
			select 13 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
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
				select 12 as [No], 'Cardiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
				sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
				sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
				sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
				from Items  
				left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
				and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
				left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
				and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
				inner join Visits  on Items.VisitNo = Visits.VisitNo
				where Items.ItemCategoryID = @CardiologyID and Items.RecordDateTime between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo				
			union
				select 13 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
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
			select 12 as [No], 'Cardiology' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
			sum(CashAmount) as CoPayAmount, sum(Discount) as BillDiscount, sum(Amount) as BillPaid, 
			sum(Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) as BillAmount,
			sum(case when (PayStatusID = @NotPaidPayStatus) then (Items.Quantity * dbo.GetCoPayFee(CoPayTypeID, CoPayPercent, Items.UnitPrice)) else 0 end) as BillNotPaid
			from Items  
			left outer join ItemsCASH on ItemsCASH.VisitNo = Items.VisitNo
			and ItemsCASH.ItemCode = Items.ItemCode and ItemsCASH.ItemCategoryID = Items.ItemCategoryID
			left outer join PaymentDetails on PaymentDetails.VisitNo = Items.VisitNo	
			and PaymentDetails.ItemCode = Items.ItemCode and PaymentDetails.ItemCategoryID = Items.ItemCategoryID
			inner join Visits  on Items.VisitNo = Visits.VisitNo
			where Items.ItemCategoryID = @CardiologyID and Items.RecordDateTime between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 13 as [No], 'Grand Total' as IncomeCategory, sum(Items.Quantity * Items.UnitPrice) as TotalAmount, 
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

if exists (select * from sysobjects where name = 'DetailedIncomePaymentDetailsSummaries')
	drop proc DetailedIncomePaymentDetailsSummaries
go

create proc DetailedIncomePaymentDetailsSummaries(
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

-- exec uspGetIncomePaymentDetailsSummaries '14 April 2017', '14 April 2017'

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
declare @ItemStatusOffered varchar(10)

declare @PaidPayStatus varchar (10)
declare @DrugID varchar(10)
declare @ConsumableID varchar(10)

----------------------------------------------------------------------------
set @PaidPayStatus = dbo.GetLookupDataID('PayStatus', 'PF')
set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
set @ItemStatusOffered = dbo.GetLookupDataID('ItemStatus', 'O')
----------------------------------------------------------------------------

if not (@StartDateTime is null) and not(@EndDateTime is null)
begin

select  dbo.FormatDate(items.ConclusionDate)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
Items.ItemName as Description,dbo.FormatMoney(Items.Quantity *Items.UnitPrice) as Debit,
dbo.GetLookupDataDes(VisitCategoryID) as Project from Items
inner join Visits on Items.VisitNo =visits.VisitNo
where ItemStatusID = @ItemStatusOffered AND ItemCategoryID IN (@DrugID,@ConsumableID)
and (items.ConclusionDate between @StartDateTime and @EndDateTime)
UNION
select  dbo.FormatDate(items.PayDate)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
Items.ItemName as Description,dbo.FormatMoney(Items.Quantity *Items.UnitPrice) as Debit,
dbo.GetLookupDataDes(VisitCategoryID) as Project from Items
inner join Visits on Items.VisitNo =visits.VisitNo
where PayStatusID = @PaidPayStatus AND ItemCategoryID NOT IN (@DrugID,@ConsumableID)
and (items.PayDate between @StartDateTime and @EndDateTime)

	
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
declare @ItemStatusPending varchar(10)
declare @NotPaidPayStatus varchar (10)

set @ItemStatusPending = dbo.GetLookupDataID('ItemStatus', 'P')
----------------------------------------------------------------------------
set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
----------------------------------------------------------------------------
if not (@StartDateTime is null) and not(@EndDateTime is null)
begin

SELECT dbo.FormatDate(IPDItems.RecordDateTime)  as Date,'1001' as Account,dbo.GetLookupDataDes(ItemCategoryID) as Reference,
IPDItems.ItemName as Description,dbo.FormatMoney(IPDItems.Quantity *IPDItems.UnitPrice) as Debit,
dbo.GetLookupDataDes(WardsID) as Project FROM IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 


where  NOT(IPDItems.ItemStatusID = @ItemStatusPending and IPDItems.PayStatusID =@NotPaidPayStatus) and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime
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


-----------------------------------------------------------------------------------------------------------------------------------------------
-------------- Get Operational IPD Items Report
-----------------------------------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetOperationalIPDItemsReport')
	drop proc uspGetOperationalIPDItemsReport
go

create proc uspGetOperationalIPDItemsReport(

@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@ItemCategoryID varchar(10)=null,
@ItemStatusID varchar(10)=null,
@PayStatusID varchar(10)=null,
@BillModesID varchar(10)=null

)with encryption as

declare @ErrorMSG varchar(200)

 if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null) and not (@PayStatusID is null) 
 and not (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,
ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby,
 CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and 
IPDItems.ItemStatusID =@ItemStatusID and 
IPDItems.ItemCategoryID =@ItemCategoryID and
Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) 
and (@PayStatusID is null) and  (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, CreatorClientMachine,
dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where IPDItems.ItemCategoryID =@ItemCategoryID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and not (@ItemStatusID is null) 
and not (@PayStatusID is null) and not (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby,
 CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and
IPDItems.ItemStatusID =@ItemStatusID and
Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null) 
and (@PayStatusID is null) and not (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, 
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where
IPDItems.ItemStatusID =@ItemStatusID and 
IPDItems.ItemCategoryID =@ItemCategoryID and
Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) and not (@PayStatusID is null) and not (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, CreatorClientMachine,
dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and
IPDItems.ItemCategoryID =@ItemCategoryID and
Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null)
 and not (@PayStatusID is null) and (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, 
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and 
IPDItems.ItemStatusID =@ItemStatusID and 
IPDItems.ItemCategoryID =@ItemCategoryID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

else  if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  
and (@ItemStatusID is null) and not (@PayStatusID is null) and (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, CreatorClientMachine,
dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and 
IPDItems.ItemCategoryID =@ItemCategoryID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

 else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and not (@ItemStatusID is null) 
 and (@PayStatusID is null) and (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, 
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where
IPDItems.ItemStatusID =@ItemStatusID and
IPDItems.ItemCategoryID =@ItemCategoryID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end


 else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) 
 and (@PayStatusID is null) and not (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby,
 CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where
IPDItems.ItemCategoryID =@ItemCategoryID and
Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

 else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and (@ItemStatusID is null) 
 and not(@PayStatusID is null) and  (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, 
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
end

 else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and (@ItemStatusID is null) 
 and (@PayStatusID is null) and  not(@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, CreatorClientMachine,
dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
end


else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and not(@ItemStatusID is null) 
and (@PayStatusID is null) and  (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, 
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where IPDItems.ItemStatusID =@ItemStatusID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and (@ItemStatusID is null) 
and not (@PayStatusID is null) and not (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, 
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and 
IPDItems.ItemStatusID =@ItemStatusID and 
IPDItems.ItemCategoryID =@ItemCategoryID and
Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  and 
not (@ItemStatusID is null) and not (@PayStatusID is null) and (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby,
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and IPDItems.ItemStatusID =@ItemStatusID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
end

else if not(@StartDateTime is null) and not(@EndDateTime is null) and not(@ItemCategoryID is null)  and (@ItemStatusID is null) 
and not (@PayStatusID is null) and (@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby,
 CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where 
IPDItems.PayStatusID =@PayStatusID and IPDItems.ItemCategoryID =@ItemCategoryID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end


else if not(@StartDateTime is null) and not(@EndDateTime is null) and (@ItemCategoryID is null)  
and not(@ItemStatusID is null) and  (@PayStatusID is null) and not(@BillModesID is null)
begin

select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby, 
CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where IPDItems.ItemStatusID =@ItemStatusID and
Admissions.BillModesID =@BillModesID
and IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end


else
begin
select Visits.PatientNo,dbo.GetFullName(LastName, MiddleName, FirstName) as PatientFullName,Phone, Visits.VisitNo as VisitNo,ItemName,Quantity,IPDItems.UnitPrice,
(IPDItems.Quantity*IPDItems.UnitPrice) as TotalAmount,ItemCategoryID,Admissions.BillModesID,PayStatusID,ItemStatusID,IPDItems.LoginID as Offeredby,
 CreatorClientMachine,dbo.GetLookupDataDes(Admissions.BillModesID) as BillMode
from IPDItems

inner join IPDDoctor on IPDDoctor.RoundNo = IPDItems.RoundNo
inner join Admissions on IPDDoctor.AdmissionNo = Admissions.AdmissionNo
inner join Beds on Admissions.BedNo = Beds.BedNo
join Rooms on Beds.RoomNo = Rooms.RoomNo
inner join Visits on Admissions.VisitNo = Visits.VisitNo
inner join Patients on Visits.PatientNo = Patients.PatientNo 
where IPDItems.RecordDateTime between @StartDateTime and @EndDateTime order by IPDItems.RecordDateTime
	
end

return 0
go

-----------------------------------------------------------------------------------------------------------------------------------------------



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
		select dbo.FormatDate(PayDate) as PayDate,ClientFullName as FullName,
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
		where AccountActionID =@AccountActionID and dbo.GetAccountsRecordDateTime(Accounts.TranNo) between @StartDateTime and @EndDateTime
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
		where AccountActionID =@AccountActionID and dbo.GetAccountsRecordDateTime(Accounts.TranNo) between @StartDateTime and @EndDateTime and BranchID =@BranchID
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
		where AccountActionID =@AccountActionID and dbo.GetAccountsRecordDateTime(Accounts.TranNo) between @StartDateTime and @EndDateTime
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
		where AccountActionID =@AccountActionID and dbo.GetAccountsRecordDateTime(Accounts.TranNo) between @StartDateTime and @EndDateTime and BranchID =@BranchID
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
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName,
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
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		 dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.FilterNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where  
		Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayModesID =@PaymentsModeID and
		VisitCategoryID = @BranchID

	end

	else if not (@PaymentsModeID is null) and (@BranchID is null)
	begin
		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(PayNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid, VisitCategoryID,
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayModesID =@PaymentsModeID
		union

		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(FilterNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid,VisitCategoryID, 
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName,dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, 
		 dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.FilterNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayModesID =@PaymentsModeID
	end

 else if  not (@BranchID is null) and (@PaymentsModeID is null)
	begin
		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(PayNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid,
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName,VisitCategoryID, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and VisitCategoryID =@BranchID
		union

		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(FilterNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid,
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName,
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
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName, dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
		dbo.GetSeenDoctor(VisitNo) as OSeenDoctor,VisitCategoryID,
		 dbo.GetLookupDataDes(CurrenciesID) as OCurrency, dbo.GetTime(Payments.RecordDateTime) as ORecordTime
		from Payments
		inner join Visits on Visits.VisitNo = Payments.PayNo
		inner join Patients on Visits.PatientNo = Patients.PatientNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime
		union

		select dbo.FormatDate(PayDate) as OPayDate, dbo.FormatText(FilterNo, 'Visits', 'VisitNo') as OVisitNo,
	    dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo) as OAmountPaid,
		dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,(dbo.GetAmountPaid(PayTypeID, VisitTypeID, ReceiptNo)-dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
		ClientFullName as OFullName,dbo.GetLookupDataDes(VisitCategoryID) as BranchName,
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
ClientFullName  as FullName,dbo.FormatDate(PayDate)As PayDate,
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

select Payments.ReceiptNo As ReceiptNo, PaymentDetails. VisitNo,dbo.FormatDate(VisitDate)As VisitDate,ClientFullName as FullName,
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



----------------------------------------------------------------------------------------------------------------
-------------- Get OPD Cash Payment Categorisation -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetOPDCashPaymentCategorisation')
	drop proc uspGetOPDCashPaymentCategorisation
go

create proc uspGetOPDCashPaymentCategorisation(
@PatientNo varchar(20) = null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as


    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @CashVisitPayTypeID varchar(10) 

    set @CashVisitPayTypeID = dbo.GetLookupDataID('PayType', 'CAS')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

Begin
if (@PatientNo is null)
begin
   select Visits.PatientNo as AccountNo,Payments.ReceiptNo,payno,dbo.FormatDate(Payments.Paydate) as Paydate,dbo.FormatDate(visitdate) as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) as TotalBill,
	   dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded, GrandDiscount, WithholdingTax,
	   (dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) -dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
       amountTendered ,dbo.calculateCollections(Payments.ReceiptNo) as Collections, dbo.CreditSaleAmount(Payments.ReceiptNo) as creditsales, 
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ServiceID ) as services,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,null ) as Total
    from visits 
    inner join Patients on Visits.PatientNo = Patients.PatientNo							
    inner join Payments on  Visits.VisitNo = Payments.PayNo
    where Payments.RecordDateTime between @StartDateTime and @EndDateTime and PayTypeID = @CashVisitPayTypeID
    order by Payments.recorddatetime desc
end
else
begin
 select Visits.PatientNo  as AccountNo,Payments.ReceiptNo,payno,dbo.FormatDate(Payments.Paydate) as Paydate,dbo.FormatDate(visitdate) as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) as TotalBill,
	   dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded, GrandDiscount, WithholdingTax,
	   (dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) -dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
       amountTendered ,dbo.calculateCollections(Payments.ReceiptNo) as Collections, dbo.CreditSaleAmount(Payments.ReceiptNo) as creditsales, 
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ServiceID ) as services,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCashPaymentsPerService(payments.ReceiptNo,null ) as Total
    from visits 
    inner join Patients on Visits.PatientNo = Patients.PatientNo							
    inner join Payments on  Visits.VisitNo = Payments.PayNo
    where Payments.RecordDateTime between @StartDateTime and @EndDateTime and 
    PayTypeID = @CashVisitPayTypeID and Visits.PatientNo = @PatientNo
    order by Payments.recorddatetime desc
end
return 0
end
go
-- Exec uspGetOPDCashPaymentCategorisation '182485', '1 jan 2018','31 jan 2018'
-- Exec uspGetOPDCashPaymentCategorisation null,'1 jun 2018','31 jul 2018'

-------------------------------------------------------------------------------------------------------------------------------
----------------------------- Get IPD Cash Payment Categorisation -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDCashPaymentCategorisation')
	drop proc uspGetIPDCashPaymentCategorisation
go

create proc uspGetIPDCashPaymentCategorisation(
@PatientNo varchar(20)= null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as

    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @IPDRoundPayTypeID varchar(10)
    declare @ExtraBillPayTypeID varchar(10)

    set @IPDRoundPayTypeID = dbo.GetLookupDataID('PayType', 'IPR')
    set @ExtraBillPayTypeID = dbo.GetLookupDataID('PayType', 'EXT')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

begin

if (@PatientNo is null)
begin
   select Visits.PatientNo  as AccountNo,Payments.ReceiptNo,payno,dbo.FormatDate(Payments.Paydate) as Paydate,dbo.FormatDate(visitdate) as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) as TotalBill, GrandDiscount, dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded, WithholdingTax, (dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) - dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
       amountTendered ,dbo.calculateCollections(Payments.ReceiptNo) as Collections, dbo.CreditSaleAmount(Payments.ReceiptNo) as creditsales, 
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ServiceID ) as services,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,null ) as Total

    from visits 
    inner join Patients on Visits.PatientNo = Patients.PatientNo							
    inner join Payments on  Visits.VisitNo = Payments.PayNo
    where Payments.RecordDateTime between @StartDateTime and @EndDateTime and
    (PayTypeId =  @IPDRoundPayTypeID or PayTypeId = @ExtraBillPayTypeID) 
    order by Payments.recorddatetime desc
end
else
begin
   select Visits.PatientNo  as AccountNo, Payments.ReceiptNo,payno,dbo.FormatDate(Payments.Paydate) as Paydate,dbo.FormatDate(visitdate) as visitdate,visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) as TotalBill, GrandDiscount, dbo.GetAmountRefunded(ReceiptNo) as AmountRefunded,  WithholdingTax, (dbo.GetAmountPaid(PayTypeID, VisitTypeID, Payments.ReceiptNo) - dbo.GetAmountRefunded(ReceiptNo)) as NetAmount,
       amountTendered ,dbo.calculateCollections(Payments.ReceiptNo) as Collections, dbo.CreditSaleAmount(Payments.ReceiptNo) as creditsales, 
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ServiceID ) as services,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCashPaymentsPerService(payments.ReceiptNo,null ) as Total
    from visits 
    inner join Patients on Visits.PatientNo = Patients.PatientNo							
    inner join Payments on  Visits.VisitNo = Payments.PayNo
    where Payments.RecordDateTime between @StartDateTime and @EndDateTime and Visits.PatientNo = @PatientNo
    and (PayTypeId =  @IPDRoundPayTypeID or PayTypeId = @ExtraBillPayTypeID) 
    order by Payments.recorddatetime desc
end
return 0
end
go

-- Exec uspGetIPDCashPaymentCategorisation null,'1 jan 2018','31 jan 2019'
-- Exec uspGetIPDCashPaymentCategorisation '1 march 2018','31 jul 2018'



----------------------------------------------------------------------------------------------------------------
-------------- Get OPD  Credit Categorisation -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetOPDCreditPaymentCategorisation')
	drop proc uspGetOPDCreditPaymentCategorisation
go

create proc uspGetOPDCreditPaymentCategorisation(
@AccountNo varchar(20) = null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as


    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @CashVisitPayTypeID varchar(10) 

    set @CashVisitPayTypeID = dbo.GetLookupDataID('PayType', 'CAS')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

Begin
if (@AccountNo is null)
begin
   select payno as AccountNo ,ReceiptNo,payno,dbo.FormatDate(Paydate) as Paydate,BillCustomerName as FullName,
       AmountPaid as TotalBill,
       amountTendered ,dbo.calculateCollections(ReceiptNo) as Collections, dbo.CreditSaleAmount(ReceiptNo) as creditsales, AmountRefunded, WithholdingTax, GrandDiscount, NetAmount,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ServiceID ) as services,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,null ) as Total
    from billspayment 
    where RecordDateTime between @StartDateTime and @EndDateTime
    order by recorddatetime desc
end
else
begin
 select payno as AccountNo, ReceiptNo,Payno,dbo.FormatDate(Paydate) as Paydate,BillCustomerName as Fullname,
       AmountPaid as TotalBill,
       amountTendered ,dbo.calculateCollections(ReceiptNo) as Collections, dbo.CreditSaleAmount(ReceiptNo) as creditsales, AmountRefunded, WithholdingTax, GrandDiscount, NetAmount,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ServiceID ) as services,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCashPaymentsPerService(ReceiptNo,null ) as Total
    from billspayment 
    where RecordDateTime between @StartDateTime and @EndDateTime and 
    Payno = @AccountNo
    order by recorddatetime desc
end
return 0
end
go
-- Exec uspGetOPDCreditPaymentCategorisation null, '5 june 2017', '5 jul 2018'
-- Exec uspGetOPDCreditPaymentCategorisation '173649','1 march 2018','31 jul 2018'
--- select * from billspayment
--- select * from creditbillformpayment

----------------------------------------------------------------------------------------------------------------
-------------- Get IPD  Credit Categorisation -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetIPDCreditPaymentCategorisation')
	drop proc uspGetIPDCreditPaymentCategorisation
go

create proc uspGetIPDCreditPaymentCategorisation(
@AccountNo varchar(20) = null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as


    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @CashVisitPayTypeID varchar(10) 

    set @CashVisitPayTypeID = dbo.GetLookupDataID('PayType', 'CAS')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

Begin
if (@AccountNo is null)
begin
   select payno as AccountNo,ReceiptNo,payno,dbo.FormatDate(Paydate) as Paydate,BillCustomerName as FullName,
       AmountPaid as TotalBill,
       amountTendered ,dbo.calculateCollections(ReceiptNo) as Collections, dbo.CreditSaleAmount(ReceiptNo) as creditsales, AmountRefunded, WithholdingTax, GrandDiscount, NetAmount,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ServiceID ) as services,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,null ) as Total
    from CreditBillFormPayment 
    where RecordDateTime between @StartDateTime and @EndDateTime
    order by recorddatetime desc
end
else
begin
 select payno as AccountNo, ReceiptNo,Payno,dbo.FormatDate(Paydate) as Paydate,BillCustomerName as Fullname,
       AmountPaid as TotalBill,
       amountTendered ,dbo.calculateCollections(ReceiptNo) as Collections, dbo.CreditSaleAmount(ReceiptNo) as creditsales, AmountRefunded, WithholdingTax, GrandDiscount, NetAmount,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ServiceID ) as services,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCashPaymentsPerService(ReceiptNo,null ) as Total
    from CreditBillFormPayment 
    where RecordDateTime between @StartDateTime and @EndDateTime and 
    Payno = @AccountNo
    order by recorddatetime desc
end
return 0
end
go
-- Exec uspGetIPDCreditPaymentCategorisation null, '5 june 2017', '17 jul 2018'
-- Exec uspGetIPDCreditPaymentCategorisation '173649','1 march 2018','31 jul 2018'
--- select * from CreditBillFormPayment


----------------------------------------------------------------------------------------------------------------
-------------- Get OPD Credit Invoice Categorisation Details ---------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetOPDCreditInvoiceCategorisationDetails')
	drop proc uspGetOPDCreditInvoiceCategorisationDetails
go

create proc uspGetOPDCreditInvoiceCategorisationDetails(
@AccountNo varchar(20) = null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as

    declare @CashBillModesID varchar(10)
	declare @OPDVisitTypeID varchar(10)
    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @CreditVisitPayTypeID varchar(10) 

   set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
   set @OPDVisitTypeID = dbo.GetLookupDataID('VisitType', 'OPD')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

Begin
if (@AccountNo is null)
begin
   select InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate) as Paydate,dbo.FormatDate(visitdate) as visitdate,
       visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo 
   where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
    not(BillModesID = @CashBillModesID) and VisitTypeID = @OPDVisitTypeID
    Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.PayTypeID, invoices.VisitTypeID
end
else
begin
   select InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate) as Paydate,dbo.FormatDate(visitdate) as visitdate,
       visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo 
   where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
    not(BillModesID = @CashBillModesID) and BillNo = @AccountNo and VisitTypeID = @OPDVisitTypeID
    Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.PayTypeID, invoices.VisitTypeID
end
return 0
end
go

----------------------------------------------------------------------------------------------------------------
--- exec uspGetOPDCreditInvoiceCategorisationDetails 'A18002','1 march 2017','31 jul 2018'
----------------------------------------------------------------------------------------------------------------



if exists (select * from sysobjects where name = 'uspGetIPDCreditInvoiceCategorisationDetails')
	drop proc uspGetIPDCreditInvoiceCategorisationDetails
go

create proc uspGetIPDCreditInvoiceCategorisationDetails(
@AccountNo varchar(20) = null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as


    declare @CashBillModesID varchar(10)
	declare @IPDVisitTypeID varchar(10)
    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @CreditVisitPayTypeID varchar(10) 

   set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
    set @IPDVisitTypeID = dbo.GetLookupDataID('VisitType', 'IPD')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

Begin
if (@AccountNo is null)
begin

   select InvoiceNo, Visits.PatientNo,visits.visitNo,invoices.payno,invoiceno,dbo.FormatDate(invoices.invoiceDate) as Paydate,
     dbo.FormatDate(visitdate) as visitdate,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,--ExtraBills.ExtraBillNo ExtraBillNo,
         dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo
    inner join ExtraBills on Visits.VisitNo = ExtraBills.VisitNo
    where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
    not(BillModesID = @CashBillModesID) and Invoices.VisitTypeID = @IPDVisitTypeID
    Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.PayTypeID, invoices.VisitTypeID
end
else
begin

   select InvoiceNo, Visits.PatientNo, visits.visitNo,invoices.payno,invoiceno,dbo.FormatDate(invoices.invoiceDate) as Paydate, --ExtraBillNo,
    dbo.FormatDate(visitdate) as visitdate,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,--ExtraBills.ExtraBillNo,
        dbo.GetInvoiceAmount(InvoiceNo, invoices.VisitTypeID) as InvoiceAmount, dbo.GetAmountPaid(invoices.PayTypeID, invoices.VisitTypeID, visits.visitNo) as TotalBill,
       dbo.calculateCollections(visits.visitNo) as Collections, dbo.CreditSaleAmount(visits.visitNo) as creditsales, 
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo
    inner join ExtraBills on Visits.VisitNo = ExtraBills.VisitNo
    where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
    not(BillModesID = @CashBillModesID) and BillNo = @AccountNo and invoices.VisitTypeID = @IPDVisitTypeID
    Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.PayTypeID, invoices.VisitTypeID
    
end
return 0
end
go

----------------------------------------------------------------------------------------------------------------
--- exec uspGetIPDCreditPaymentCategorisationDetails null,'1 march 2017','31 jul 2018'
----------------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------------------------
-------------- Get OPD Credit Payment Categorisation Details -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetOPDCashInvoiceCategorisationDetails')
	drop proc uspGetOPDCashInvoiceCategorisationDetails
go

create proc uspGetOPDCashInvoiceCategorisationDetails(
@PatientNo varchar(20) = null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as

    declare @CashBillModesID varchar(10)
	declare @OPDVisitTypeID varchar(10)
    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @CreditVisitPayTypeID varchar(10) 

   set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
  set @OPDVisitTypeID = dbo.GetLookupDataID('VisitType', 'OPD')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

Begin
if (@PatientNo is null)
begin
   select InvoiceNo,Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate) as Paydate,dbo.FormatDate(visitdate) as visitdate,
       visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo 
   where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
    (BillModesID = @CashBillModesID) and VisitTypeID = @OPDVisitTypeID
	Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.VisitTypeID

end
else
begin
   select Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate) as Paydate,dbo.FormatDate(visitdate) as visitdate,
       visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetOPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo 
   where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
   (BillModesID = @CashBillModesID) and Visits.PatientNo = @PatientNo and VisitTypeID = @OPDVisitTypeID
    Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.VisitTypeID
   
    
end
return 0
end
go

----------------------------------------------------------------------------------------------------------------
--- exec uspGetOPDCreditPaymentCategorisationDetails 'A18002','1 march 2017','31 jul 2018'
----------------------------------------------------------------------------------------------------------------



if exists (select * from sysobjects where name = 'uspGetIPDCashInvoiceCategorisationDetails')
	drop proc uspGetIPDCashInvoiceCategorisationDetails
go

create proc uspGetIPDCashInvoiceCategorisationDetails(
@PatientNo varchar(20) = null,
@StartDateTime smalldatetime,
@EndDateTime smalldatetime
)with encryption as


    declare @CashBillModesID varchar(10)
	declare @IPDVisitTypeID varchar(10)
    declare @ServiceID varchar(10)
	declare @DrugID varchar(10)
	declare @ConsumableID varchar(10)
	declare @TestID varchar(10)
	declare @CardiologyID varchar(10)
	declare @RadiologyID varchar(10)
	declare @PathologyID varchar(10)
	declare @DentalID varchar(10)
	declare @TheatreID varchar(10)
	declare @OpticalID varchar(10)
	declare @ProcedureID varchar(10)
	declare @ExtrasID varchar(10)
	declare @MaternityID varchar(10)
    declare @ICUID varchar(10)
    declare @EyeID varchar(10)
    declare @AdmissionID varchar(10)
    declare @PackageID varchar(10)
    declare @NonMedical varchar(10)
    declare @Total money
    declare @CreditVisitPayTypeID varchar(10) 

   set @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')
   set @IPDVisitTypeID = dbo.GetLookupDataID('VisitType', 'IPD')
----------------------------------------------------------------------------
	set @ServiceID = dbo.GetLookupDataID('ItemCategory', 'S')
	set @DrugID = dbo.GetLookupDataID('ItemCategory', 'D')
	set @ConsumableID = dbo.GetLookupDataID('ItemCategory', 'C')
	set @TestID = dbo.GetLookupDataID('ItemCategory', 'T')
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
	set @RadiologyID = dbo.GetLookupDataID('ItemCategory', 'R')
	set @PathologyID = dbo.GetLookupDataID('ItemCategory', 'L')
	set @DentalID = dbo.GetLookupDataID('ItemCategory', 'N')
	set @TheatreID = dbo.GetLookupDataID('ItemCategory', 'H')
	set @OpticalID = dbo.GetLookupDataID('ItemCategory', 'O')
	set @ProcedureID = dbo.GetLookupDataID('ItemCategory', 'P')
	set @ExtrasID = dbo.GetLookupDataID('ItemCategory', 'E')
    set @MaternityID = dbo.GetLookupDataID('ItemCategory','M')
    set @ICUID = dbo.GetLookupDataID('ItemCategory', 'I')
    set @EyeID = dbo.GetLookupDataID('ItemCategory','Y')
    set @AdmissionID = dbo.GetLookupDataID('ItemCategory','A')
    set @PackageID = dbo.GetLookupDataID('ItemCategory','G')
    set @NonMedical = dbo.GetLookupDataID('ItemCategory','NM')

Begin
if (@PatientNo is null)
begin

   select InvoiceNo, Visits.PatientNo,visits.visitNo,invoices.payno,invoiceno,dbo.FormatDate(invoices.invoiceDate) as Paydate,--ExtraBillNo,
     dbo.FormatDate(visitdate) as visitdate,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,--ExtraBills.ExtraBillNo,
         dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo
     where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
    (BillModesID = @CashBillModesID) and VisitTypeID = @IPDVisitTypeID
    Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.PayTypeID, invoices.VisitTypeID
end
else 
begin

   select InvoiceNo, Visits.PatientNo, visits.visitNo,invoices.payno,invoiceno,dbo.FormatDate(invoices.invoiceDate) as Paydate,dbo.FormatDate(visitdate) as visitdate,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName,
        dbo.GetInvoiceAmount(InvoiceNo, invoices.VisitTypeID) as InvoiceAmount, dbo.GetAmountPaid(invoices.PayTypeID, invoices.VisitTypeID, visits.visitNo) as TotalBill, --ExtraBillNo,ExtraBills.ExtraBillNo,
       dbo.calculateCollections(visits.visitNo) as Collections, dbo.CreditSaleAmount(visits.visitNo) as creditsales, 
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ServiceID ) as services,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DrugID ) as Drug,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ConsumableID ) as Consumable,
	   dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@CardiologyID ) as Cardiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TestID ) as Laboratory,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PathologyID ) as Pathology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@TheatreID ) as Theatre,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ProcedureID ) as ProcedureID,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@MaternityID ) as Maternity,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@EyeID ) as Eye,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@PackageID ) as Packages,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ICUID ) as ICU,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@AdmissionID ) as Admission,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@ExtrasID ) as Extras,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@OpticalID ) as Optical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@NonMedical ) as NonMedical,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@DentalID ) as Dental,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,@RadiologyID ) as Radiology,
       dbo.GetIPDTotalCreditPaymentsPerService(invoices.InvoiceNo,null ) as Total
    from invoices 
    inner join Visits on Visits.VisitNo = invoices.PayNo	
	inner join Patients on Visits.PatientNo = Patients.PatientNo
    where invoices.RecordDateTime between @StartDateTime and @EndDateTime and 
    (BillModesID = @CashBillModesID) and Visits.PatientNo = @PatientNo and VisitTypeID = @IPDVisitTypeID
    Group by InvoiceNo, Visits.PatientNo,visits.visitNo,payno,dbo.FormatDate(invoices.invoiceDate),dbo.FormatDate(visitdate),
    visits.VisitNo,dbo.GetFullName(LastName, MiddleName, FirstName),invoices.PayTypeID, invoices.VisitTypeID
end
return 0
end
go
----------------------------------------------------------------------------------------------------------------
--- exec uspGetIPDCashInvoiceCategorisationDetails NULL,'1 march 2017','19 jul 2019'
----------------------------------------------------------------------------------------------------------------


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
	declare @CardiologyID varchar(10)
	
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
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
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
	select 12 as [No], 'Cardiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
	where ExtraBillItems.ItemCategoryID = @CardiologyID and VisitDate between @StartDate and @EndDate
union
	select 13 as [No], 'Grand Total' as IncomeCategory, 
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
	declare @CardiologyID varchar(10)
	
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
	set @CardiologyID = dbo.GetLookupDataID('ItemCategory', 'CA')
	
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
				select 12 as [No], 'Cardiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
				where ExtraBillItems.ItemCategoryID = @CardiologyID and VisitDate between @StartDate and @EndDate			
				and BillModesID = @BillModesID and (BillNo = @CompanyNo and InsuranceNo = @BillNo) 	
			union
				select 13 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
			select 12 as [No], 'Cardiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
			where ExtraBillItems.ItemCategoryID = @CardiologyID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and (BillNo = @BillNo or InsuranceNo = @BillNo) 			
		union
			select 13 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
				select 12 as [No], 'Cardiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
				where ExtraBillItems.ItemCategoryID = @CardiologyID and VisitDate between @StartDate and @EndDate
				and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 	
				and dbo.GetSchemeCompanyNo(BillNo) = @CompanyNo				
			union
				select 13 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
			select 12 as [No], 'Cardiology' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
			where ExtraBillItems.ItemCategoryID = @CardiologyID and VisitDate between @StartDate and @EndDate
			and BillModesID = @BillModesID and dbo.GetSchemeInsuranceNo(BillNo) = @BillNo 
		union
			select 13 as [No], 'Grand Total' as IncomeCategory, sum(ExtraBillItems.Quantity * ExtraBillItems.UnitPrice) as TotalAmount, 
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
declare @StaffMemberTypeID varchar(10)
set @StaffMemberTypeID = dbo.GetLookupDataID('MemberType', '01')

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
	dbo.GetMergedNameCode(dbo.GetFullName(Surname, MiddleName, FirstName),MainMemberNo) as MemberFullName,
	MainMemberNo, dbo.GetSchemeMemberName(MainMemberNo) as MainMemberName,
	MedicalCardNo, SchemeMembers.CompanyNo, CompanyName
	from SchemeMembers	
	inner join InsuranceSchemes on InsuranceSchemes.CompanyNo = SchemeMembers.CompanyNo
	and InsuranceSchemes.PolicyNo = SchemeMembers.PolicyNo
	inner join Companies on InsuranceSchemes.CompanyNo = Companies.CompanyNo
	where MainMemberNo = @MainMemberNo and MemberTypeID= @StaffMemberTypeID
	end
end

else
if (@MainMemberNo is null)
begin
	begin
	select  dbo.GetLookupDataDes(MemberTypeID) as MemberType,
	dbo.GetMergedNameCode(dbo.GetFullName(Surname, MiddleName, FirstName),MainMemberNo) as MemberFullName,
	MainMemberNo, dbo.GetSchemeMemberName(MainMemberNo) as MainMemberName,
	MedicalCardNo, SchemeMembers.CompanyNo, CompanyName
	from SchemeMembers	
	inner join InsuranceSchemes on InsuranceSchemes.CompanyNo = SchemeMembers.CompanyNo
	and InsuranceSchemes.PolicyNo = SchemeMembers.PolicyNo
	inner join Companies on InsuranceSchemes.CompanyNo = Companies.CompanyNo
	where MemberTypeID= @StaffMemberTypeID
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
	
select dbo.GetLookupDataDes(MembertypeID) as Membertype, (SchemeMembers.MedicalCardNo) as MedicalCardNo,MainMemberNo,isnull(MainMemberName,'No Name Given') as MainMemberName,
isnull(dbo.GetFullName(SchemeMembers.Surname, SchemeMembers.MiddleName, SchemeMembers.FirstName),'No Name') as FullName,(Claims.PatientNo) as PatientNo,
dbo.FormatMoney(sum(dbo.GetClaimAmount(Claims.ClaimNo))) As ClaimAmount
from Visits
--inner join Items on Items.VisitNo = Visits.VisitNo
inner join ClaimsEXT on Visits.VisitNo = ClaimsEXT.VisitNo
inner join Claims on ClaimsEXT.ClaimNo =Claims.ClaimNo
inner join SchemeMembers on Claims.MedicalCardNo = SchemeMembers.MedicalCardNo
where MainMemberNo =@MainMemberNo and Claims.VisitDate between @StartDate and @EndDate
Group by MembertypeID,SchemeMembers.MedicalCardNo,MainMemberNo,MainMemberName,
dbo.GetFullName(SchemeMembers.Surname, SchemeMembers.MiddleName, SchemeMembers.FirstName),Claims.PatientNo
order by MainMemberNo,MembertypeID
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
where MainMemberNo =@MainMemberNo and Claims.VisitDate between @StartDate and @EndDate
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

if exists (select * from sysobjects where name = 'GetTimelySMSDeposits')
	drop function GetTimelySMSDeposits
go

create function GetTimelySMSDeposits(@startDateTime as smalldatetime, @EndDateTime as smalldatetime) returns varchar(2000)
with encryption as
begin

declare @Account varchar(100)
declare @Amount decimal(10,2)
declare @AccountCreditDetails varchar(2000)
declare @AccountActionID varchar(10)
set @AccountActionID =  dbo.GetLookupDataID('AccountAction', 'CR')

set @AccountCreditDetails = ''

begin
	
DECLARE AccountCreditDetails_Cursor CURSOR FOR

select  (dbo.GetLookupDataDes(PayModesID))  As Credits,dbo.FormatMoney(SUM(Amount)) as TotalEarned from Accounts
where dbo.GetAccountsRecordDateTime(Accounts.TranNo) between @startDateTime And @EndDateTime And AccountActionID=@AccountActionID
Group by PayModesID
OPEN AccountCreditDetails_Cursor
	FETCH NEXT FROM AccountCreditDetails_Cursor INTO @Account, @Amount
	WHILE (@@FETCH_STATUS <> -1)
		BEGIN
				SET @AccountCreditDetails = @AccountCreditDetails + @Account + ': ' + cast(@Amount as varchar(12)) + ', '
				FETCH NEXT FROM AccountCreditDetails_Cursor INTO @Account, @Amount
		END

	CLOSE AccountCreditDetails_Cursor
	DEALLOCATE AccountCreditDetails_Cursor

if len(@AccountCreditDetails) > 0 set @AccountCreditDetails = left(@AccountCreditDetails, len(@AccountCreditDetails)-1)
end

return @AccountCreditDetails

end

go

----------------------------------------------------------------------------------------------------------------
-- print dbo.GetTimelySMSDeposits('1 FEB 17  12:00:00', '10 FEB 17 12:00:00')
-- select TOP 1 dbo.GetTimelySMSDeposits('1 FEB 17  12:00:00', '10 FEB 17 18:00:00') as finalMoney from Accounts
----------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetTimelyOtherIncomes')
	drop function GetTimelyOtherIncomes
go

create function GetTimelyOtherIncomes(@startDateTime as smalldatetime, @EndDateTime as smalldatetime) returns varchar(2000)
with encryption as
begin

declare @Account varchar(100)
declare @Amount decimal(10,2)
declare @OtherIncomeDetails varchar(2000)
declare @AccountActionID varchar(10)

set @OtherIncomeDetails = ''

begin
	
DECLARE OtherIncomeDetails_Cursor CURSOR FOR

select  (dbo.GetLookupDataDes(PayModesID))  As PayMode,dbo.FormatMoney(SUM(Amount)) as TotalEarned from OtherIncome
where RecordDateTime between @startDateTime And @EndDateTime
Group by PayModesID
OPEN OtherIncomeDetails_Cursor
	FETCH NEXT FROM OtherIncomeDetails_Cursor INTO @Account, @Amount
	WHILE (@@FETCH_STATUS <> -1)
		BEGIN
				SET @OtherIncomeDetails = @OtherIncomeDetails + @Account + ': ' + cast(@Amount as varchar(12)) + ', '
				FETCH NEXT FROM OtherIncomeDetails_Cursor INTO @Account, @Amount
		END

	CLOSE OtherIncomeDetails_Cursor
	DEALLOCATE OtherIncomeDetails_Cursor

if len(@OtherIncomeDetails) > 0 set @OtherIncomeDetails = left(@OtherIncomeDetails, len(@OtherIncomeDetails)-1)
end

return @OtherIncomeDetails

end

go
----------------------------------------------------------------------------------------------------------------
-- print dbo.GetTimelyOtherIncomes('14 dec 16  12:00:00', '14 dec 16 12:00:00')
-- select top 1 dbo.GetTimelyOtherIncomes('1 dec 16  12:00:00', '14 dec 16 18:00:00') as finalMoney from OtherIncome
----------------------------------------------------------------------------------------------------------------


if exists (select * from sysobjects where name = 'GetTimelyExpenditures')
	drop function GetTimelyExpenditures
go

create function GetTimelyExpenditures(@startDateTime as smalldatetime, @EndDateTime as smalldatetime) returns varchar(2000)
with encryption as
begin

declare @SourceTypeID varchar(100)
declare @Amount decimal(10,2)
declare @ExpenditureDetails varchar(2000)

set @ExpenditureDetails = ''

begin
	
DECLARE ExpenditureDetails_Cursor CURSOR FOR

select dbo.GetLookupDataDes(ExpenditureSourceTypeID) ExpenditureType,dbo.FormatMoney(SUM(Amount)) SpentAmount from Expenditure
where RecordDateTime between @startDateTime And @EndDateTime
Group by ExpenditureSourceTypeID

OPEN ExpenditureDetails_Cursor
	FETCH NEXT FROM ExpenditureDetails_Cursor INTO @SourceTypeID, @Amount
	WHILE (@@FETCH_STATUS <> -1)
		BEGIN
				SET @ExpenditureDetails = @ExpenditureDetails + @SourceTypeID + ': ' + cast(@Amount as varchar(12)) + ', '
				FETCH NEXT FROM ExpenditureDetails_Cursor INTO @SourceTypeID, @Amount
		END

	CLOSE ExpenditureDetails_Cursor
	DEALLOCATE ExpenditureDetails_Cursor

if len(@ExpenditureDetails) > 0 set @ExpenditureDetails = left(@ExpenditureDetails, len(@ExpenditureDetails)-1)
end

return @ExpenditureDetails

end

go


----------------------------------------------------------------------------------------------------------------
-- print dbo.GetTimelyExpenditures('1 FEB 17  12:00:00', '10 FEB 17 12:00:00')
-- select TOP 1 dbo.GetTimelyExpenditures('1 FEB 17  12:00:00', '10 FEB 17 18:00:00') as finalMoney from Expenditure
----------------------------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------------
-------------- LabTestsDone ---------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'uspGetLabTestsDone')
	drop proc uspGetLabTestsDone
go

create proc uspGetLabTestsDone(
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

select LabResults.TestCode as TestCode,TestName,
sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female,
count(LabResults.TestCode) as Total from LabResults
inner join LabTests on LabResults.TestCode =LabTests.TestCode
inner join LabRequests on LabResults.SpecimenNo =LabRequests.SpecimenNo
inner join Visits on Visits.VisitNo= LabRequests.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo
where dbo.GetShortDate(LabResults.RecordDateTime) between @StartDate and @EndDate and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
group by LabResults.TestCode,TestName
end
    
else
if @SearchAgeBy= dbo.GetLookupDataID('SearchAgeBy', 'MT')
begin

select LabResults.TestCode as TestCode,TestName,
sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female,
count(LabResults.TestCode) as Total from LabResults
inner join LabTests on LabResults.TestCode =LabTests.TestCode
inner join LabRequests on LabResults.SpecimenNo =LabRequests.SpecimenNo
inner join Visits on Visits.VisitNo= LabRequests.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo
where dbo.GetShortDate(LabResults.RecordDateTime) between @StartDate and @EndDate and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
group by LabResults.TestCode,TestName

end
----------------------------------------------------------------------------
	
end
return 0
go



-------------------------------------------------------------------------------------------------
-------------- LabTestsResultsDone ---------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'uspGetLabTestsResultsDone')
	drop proc uspGetLabTestsResultsDone
go

create proc uspGetLabTestsResultsDone(
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


select LabResults.TestCode as TestCode,TestName,Result,
sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female,
count(LabResults.TestCode) as Occurances from LabResults
inner join LabTests on LabResults.TestCode =LabTests.TestCode
inner join LabRequests on LabResults.SpecimenNo =LabRequests.SpecimenNo
inner join Visits on Visits.VisitNo= LabRequests.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo


where dbo.GetShortDate(LabResults.RecordDateTime) between @StartDate and @EndDate and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
group by LabResults.TestCode,TestName,Result

end
    
else
if @SearchAgeBy= dbo.GetLookupDataID('SearchAgeBy', 'MT')
begin
select LabResults.TestCode as TestCode,TestName,Result,
sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female,
count(LabResults.TestCode) as Occurances from LabResults
inner join LabTests on LabResults.TestCode =LabTests.TestCode
inner join LabRequests on LabResults.SpecimenNo =LabRequests.SpecimenNo
inner join Visits on Visits.VisitNo= LabRequests.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo


where dbo.GetShortDate(LabResults.RecordDateTime) between @StartDate and @EndDate and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
group by LabResults.TestCode,TestName,Result
end
----------------------------------------------------------------------------
	
end
return 0
go

-------------------------------------------------------------------------------------------------
-------------- LabTestsResultsEXTDone ---------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
if exists (select * from sysobjects where name = 'uspGetLabTestsResultsEXTDone')
	drop proc uspGetLabTestsResultsEXTDone
go

create proc uspGetLabTestsResultsEXTDone(
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

select LabResultsEXT.SubTestCode as TestCode,SubTestName as TestName,Result,
count(LabResultsEXT.TestCode) as Occurances,
sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female
 from LabResultsEXT
inner join LabTestsEXT on LabResultsEXT.SubTestCode =LabTestsEXT.SubTestCode
inner join LabRequests on LabResultsEXT.SpecimenNo =LabRequests.SpecimenNo
inner join Visits on Visits.VisitNo= LabRequests.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo


where dbo.GetShortDate(LabRequests.RecordDateTime) between @StartDate and @EndDate and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
group by LabResultsEXT.SubTestCode,SubTestName,Result

end
    
else
if @SearchAgeBy= dbo.GetLookupDataID('SearchAgeBy', 'MT')
begin
select LabResultsEXT.SubTestCode as TestCode,SubTestName as TestName,Result,
sum(case when (GenderID = @MaleGenderID) then 1 else 0 end) as Male, 
sum(case when (GenderID = @FemaleGenderID) then 1 else 0 end) as Female,
count(LabResultsEXT.TestCode) as Occurances from LabResultsEXT

inner join LabTestsEXT on LabResultsEXT.SubTestCode =LabTestsEXT.SubTestCode
inner join LabRequests on LabResultsEXT.SpecimenNo =LabRequests.SpecimenNo
inner join Visits on Visits.VisitNo= LabRequests.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo


where dbo.GetShortDate(LabRequests.RecordDateTime) between @StartDate and @EndDate and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
group by LabResultsEXT.SubTestCode,SubTestName,Result
end
----------------------------------------------------------------------------
	
end
return 0
go

----------- EXEC uspGetLabTestsResultsEXTDone '168YR','30 OCT 2018','30 JAN 2019','0','100'


if exists (select * from sysobjects where name = 'uspGetLabTestsDoneStatistics')
	drop proc uspGetLabTestsDoneStatistics
go

create proc uspGetLabTestsDoneStatistics(
@SearchAgeBy varchar(10),
@StartDate smalldatetime,
@EndDate smalldatetime,
@StartAge tinyint,
@EndAge tinyint
)with encryption as 

declare @ErrorMSG varchar(200)
declare @ItemOfferedID varchar(10)
declare @ItemCategoryID varchar(10)
declare @ItemDoneID varchar(10)
declare @PendingItemStatusID varchar(10)
declare @ProcessingItemStatusID varchar(10)

set @ItemDoneID = dbo.GetLookupDataID('ItemStatus', 'D')
set @PendingItemStatusID = dbo.GetLookupDataID('ItemStatus', 'P')
set @ProcessingItemStatusID = dbo.GetLookupDataID('ItemStatus', 'R')
set @ItemCategoryID = dbo.GetLookupDataID('ItemCategory', 'T')

----------------------------------------------------------------------------
if @SearchAgeBy=dbo.GetLookupDataID('SearchAgeBy', 'YR')

begin

select ItemName,Count(Items.VisitNo) as NoOfPatients ,Count(case when (ItemStatusID =@ItemDoneID) then (ItemStatusID) else Null end) as Done
,Count(case when (ItemStatusID =@PendingItemStatusID) then (ItemStatusID) else Null end) as Pending
,Count(case when (ItemStatusID =@ProcessingItemStatusID) then (ItemStatusID) else Null end) as Processing
from Items
 inner join Visits on Visits.VisitNo= Items.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo
Where ItemCategoryID =@ItemCategoryID and dbo.GetShortDate(Items.RecordDateTime) between @StartDate and @EndDate
and dbo.GetAge(BirthDate, getdate()) between @StartAge and @EndAge
Group by ItemName

end
    
else

if @SearchAgeBy= dbo.GetLookupDataID('SearchAgeBy', 'MT')
begin
select ItemName,Count(Items.VisitNo) as NoOfPatients ,Count(case when (ItemStatusID =@ItemDoneID) then (ItemStatusID) else Null end) as Done
,Count(case when (ItemStatusID =@PendingItemStatusID) then (ItemStatusID) else Null end) as Pending
,Count(case when (ItemStatusID =@ProcessingItemStatusID) then (ItemStatusID) else Null end) as Processing
from Items
 inner join Visits on Visits.VisitNo= Items.VisitNo
inner join Patients on Patients.PatientNo =Visits.PatientNo
Where ItemCategoryID =@ItemCategoryID and dbo.GetShortDate(Items.RecordDateTime) between @StartDate and @EndDate
and dbo.GetAgeInMonths(BirthDate, getdate()) between @StartAge and @EndAge
Group by ItemName
end
----------------------------------------------------------------------------

return 0
go


-------------------------------------------------------------------------------------------------
-------------- DetailedIncomePaymentDetailsSummaries ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetDetailedIncomePaymentDetailsSummaries')
	drop proc uspGetDetailedIncomePaymentDetailsSummaries
go

create proc uspGetDetailedIncomePaymentDetailsSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime,
@ItemCategoryID varchar(10) =null
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
	 if not(@ItemCategoryID is null or @ItemCategoryID = '')
	begin	
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
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate and ItemCategoryID =@ItemCategoryID)
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
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate and ItemCategoryID =@ItemCategoryID)
	
end
else
 begin	
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
end
return 0
go

-- exec uspGetDetailedIncomePaymentDetailsSummaries '14 April 2017', '14 April 2017','7P'
--exec uspGetDetailedIncomePaymentDetailsSummaries '14 April 2017 12:00 Am', '14 April 2017 11:59 PM',''
--exec uspGetIncomePaymentDetailsSummaries '14 April 2017', '14 April 2017'


-------------------------------------------------------------------------------------------------
-------------- DetailedNotPaidIncomePaymentDetailsSummaries ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetDetailedNotPaidIncomePaymentDetailsSummaries')
	drop proc uspGetDetailedNotPaidIncomePaymentDetailsSummaries
go

create proc uspGetDetailedNotPaidIncomePaymentDetailsSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime,
@ItemCategoryID varchar(10) =null
) with encryption as

begin
		
	declare @VisitBillID varchar(10)
	declare @RecordStartDate smalldatetime
	declare @RecordEndDate smalldatetime
	declare @OfferedItems varchar(10)
	declare @DoneItems varchar(10)
	declare @NotPaidPayStatus  varchar(10)
	--------------------------------------------------------------------------------------------------------
	set @DoneItems =  dbo.GetLookupDataID('ItemStatus', 'D')
	set @OfferedItems =  dbo.GetLookupDataID('ItemStatus', 'O')
	set @VisitBillID = dbo.GetLookupDataID('BillModes', 'C')	
	set @RecordStartDate = dbo.GetShortDate(@StartDate)
	set @RecordEndDate = dbo.GetShortDate(dateadd(day, 1, @EndDate))
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	--------------------------------------------------------------------------------------------------------
	 if not(@ItemCategoryID is null or @ItemCategoryID = '')
	begin	
	select 1 as [No], Items.VisitNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(UnitPrice * Quantity)) as TotalAmount,
	dbo.GetShortDate(Items.RecordDateTime) as RecordDate, 
	dbo.GetTime(Items.RecordDateTime) as RecordTime
	from Items 
	
	left outer join Visits on Items.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Visits.BillModesID = @VisitBillID and ItemStatusID in(@DoneItems,@OfferedItems) and
	PayStatusID =@NotPaidPayStatus and
	(Items.RecordDateTime >= @RecordStartDate and Items.RecordDateTime < @RecordEndDate and ItemCategoryID =@ItemCategoryID)
	
	group by Items.VisitNo, ItemCategoryID, LastName, MiddleName, FirstName, 
			VisitDate, Items.RecordDateTime
union
	select 2 as [No], 'Grand Total' as ReceiptNo, '' as VisitDate, '' as FullName, 
	'' as ItemCategory, Sum(Abs(UnitPrice)) as TotalAmount,
	'' as RecordDate, '' as RecordTime
    from Items 
	
	left outer join Visits on Items.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Visits.BillModesID = @VisitBillID and ItemStatusID in(@DoneItems,@OfferedItems) and
	PayStatusID =@NotPaidPayStatus and
	(Items.RecordDateTime >= @RecordStartDate and Items.RecordDateTime < @RecordEndDate and ItemCategoryID =@ItemCategoryID)
	
end
else
	begin	
	select 1 as [No], Items.VisitNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(UnitPrice * Quantity)) as TotalAmount,
	dbo.GetShortDate(Items.RecordDateTime) as RecordDate, 
	dbo.GetTime(Items.RecordDateTime) as RecordTime
	from Items 
	
	left outer join Visits on Items.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Visits.BillModesID = @VisitBillID and ItemStatusID in(@DoneItems,@OfferedItems) and
	PayStatusID =@NotPaidPayStatus and
	(Items.RecordDateTime >= @RecordStartDate and Items.RecordDateTime < @RecordEndDate)
	
	group by Items.VisitNo, ItemCategoryID, LastName, MiddleName, FirstName, 
			VisitDate, Items.RecordDateTime
union
	select 2 as [No], 'Grand Total' as ReceiptNo, '' as VisitDate, '' as FullName, 
	'' as ItemCategory, Sum(Abs(UnitPrice)) as TotalAmount,
	'' as RecordDate, '' as RecordTime
    from Items 
	
	left outer join Visits on Items.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Visits.BillModesID = @VisitBillID and ItemStatusID in(@DoneItems,@OfferedItems) and
	PayStatusID =@NotPaidPayStatus and
	(Items.RecordDateTime >= @RecordStartDate and Items.RecordDateTime < @RecordEndDate)
	
end
end
return 0
go

--exec uspGetDetailedNotPaidIncomePaymentDetailsSummaries '1 OCT 2017', '31 OCT 2017','7D'
--exec uspGetDetailedNotPaidIncomePaymentDetailsSummaries '14 April 2017 12:00 Am', '14 April 2017 11:59 PM',''
--exec uspGetDetailedNotPaidIncomePaymentDetailsSummaries '1 OCT 2017', '14 OCT 2017'



if exists (select * from sysobjects where name = 'uspGetIPDDetailedIncomePaymentDetailsSummaries')
	drop proc uspGetIPDDetailedIncomePaymentDetailsSummaries
go

create proc uspGetIPDDetailedIncomePaymentDetailsSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime,
@ItemCategoryID varchar(10) =null
) with encryption as

begin
		
	declare @VisitBillID varchar(10)
	declare @RecordStartDate smalldatetime
	declare @RecordEndDate smalldatetime

	--------------------------------------------------------------------------------------------------------
	set @VisitBillID =  dbo.GetLookupDataID('PayType', 'EXT')	
	set @RecordStartDate = dbo.GetShortDate(@StartDate)
	set @RecordEndDate = dbo.GetShortDate(dateadd(day, 1, @EndDate))
	--------------------------------------------------------------------------------------------------------
	 if not(@ItemCategoryID is null or @ItemCategoryID = '')
	begin	
	select 1 as [No], PaymentExtraBillItems.ReceiptNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(Amount)) as TotalAmount, 
	dbo.GetWaitingDays(VisitDate, Payments.RecordDateTime) as PaidAfterDays,
	dbo.GetShortDate(Payments.RecordDateTime) as RecordDate, 
	dbo.GetTime(Payments.RecordDateTime) as RecordTime
	from PaymentExtraBillItems 
	inner join Payments on PaymentExtraBillItems.ReceiptNo = Payments.ReceiptNo
	left outer join Visits on Payments.PayNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where PayTypeID = @VisitBillID and 
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate and ItemCategoryID =@ItemCategoryID)
	group by PaymentExtraBillItems.ReceiptNo, ItemCategoryID, LastName, MiddleName, FirstName, 
			VisitDate, Payments.RecordDateTime
union
	select 2 as [No], 'Grand Total' as ReceiptNo, '' as VisitDate, '' as FullName, 
	'' as ItemCategory, Sum(Abs(Amount)) as TotalAmount, '' as PaidAfterDays,
	'' as RecordDate, '' as RecordTime
	from PaymentExtraBillItems 
	inner join Payments on PaymentExtraBillItems.ReceiptNo = Payments.ReceiptNo
	left outer join Visits on Payments.PayNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Payments.PayTypeID = @VisitBillID and 
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate and ItemCategoryID =@ItemCategoryID)
	
end
else
 begin	
	select 1 as [No], PaymentExtraBillItems.ReceiptNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(Amount)) as TotalAmount, 
	dbo.GetWaitingDays(VisitDate, Payments.RecordDateTime) as PaidAfterDays,
	dbo.GetShortDate(Payments.RecordDateTime) as RecordDate, 
	dbo.GetTime(Payments.RecordDateTime) as RecordTime
	from PaymentExtraBillItems 
	inner join Payments on PaymentExtraBillItems.ReceiptNo = Payments.ReceiptNo
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
	inner join Payments on PaymentExtraBillItems.ReceiptNo = Payments.ReceiptNo
	left outer join Visits on Payments.PayNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	where Payments.PayTypeID = @VisitBillID and 
	(Payments.RecordDateTime >= @RecordStartDate and Payments.RecordDateTime < @RecordEndDate)
	
end
end
return 0
go


--exec uspGetIPDDetailedIncomePaymentDetailsSummaries '14 April 2017 12:00 Am', '14 April 2017 11:59 PM',''
--exec uspGetIPDDetailedIncomePaymentDetailsSummaries '1 SEP 2017', '19 NOV 2017'


-------------------------------------------------------------------------------------------------
-------------- DetailedIPDNotPaidIncomePaymentDetailsSummaries ----------------------------------------------------
-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetDetailedIPDNotPaidIncomePaymentDetailsSummaries')
	drop proc uspGetDetailedIPDNotPaidIncomePaymentDetailsSummaries
go

create proc uspGetDetailedIPDNotPaidIncomePaymentDetailsSummaries(
@StartDate smalldatetime,
@EndDate smalldatetime,
@ItemCategoryID varchar(10) =null
) with encryption as

begin
		
	declare @VisitBillID varchar(10)
	declare @InsBillID varchar(10)
	declare @RecordStartDate smalldatetime
	declare @RecordEndDate smalldatetime
	declare @NotPaidPayStatus  varchar(10)
	--------------------------------------------------------------------------------------------------------
	
	set @VisitBillID = dbo.GetLookupDataID('BillModes', 'A')
	set @InsBillID = dbo.GetLookupDataID('BillModes', 'I')	
	set @RecordStartDate = dbo.GetShortDate(@StartDate)
	set @RecordEndDate = dbo.GetShortDate(dateadd(day, 1, @EndDate))
	set @NotPaidPayStatus = dbo.GetLookupDataID('PayStatus', 'NP')
	--------------------------------------------------------------------------------------------------------
	 if not(@ItemCategoryID is null or @ItemCategoryID = '')
	begin	
	select 1 as [No], Visits.VisitNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(UnitPrice * Quantity)) as TotalAmount,
	dbo.GetShortDate(ExtraBillItems.RecordDateTime) as RecordDate, 
	dbo.GetTime(ExtraBillItems.RecordDateTime) as RecordTime
	from ExtraBillItems 
	inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
	left outer join Visits on ExtraBills.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	
	where
	PayStatusID =@NotPaidPayStatus and
	(ExtraBillItems.RecordDateTime >= @RecordStartDate and ExtraBillItems.RecordDateTime < @RecordEndDate and
	 ItemCategoryID =@ItemCategoryID and Visits.BillModesID in (@VisitBillID,@InsBillID))
	
	group by Visits.VisitNo, ItemCategoryID, LastName, MiddleName, FirstName, 
			VisitDate, ExtraBillItems.RecordDateTime
union
	select 2 as [No], 'Grand Total' as ReceiptNo, '' as VisitDate, '' as FullName, 
	'' as ItemCategory, Sum(Abs(UnitPrice * Quantity)) as TotalAmount,
	'' as RecordDate, '' as RecordTime
    from ExtraBillItems 
	inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
	left outer join Visits on ExtraBills.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	
	where
	PayStatusID =@NotPaidPayStatus and
	(ExtraBillItems.RecordDateTime >= @RecordStartDate and ExtraBillItems.RecordDateTime < @RecordEndDate
	 and ItemCategoryID =@ItemCategoryID and Visits.BillModesID in (@VisitBillID,@InsBillID))
	
end
else
	begin	
	select 1 as [No], Visits.VisitNo, VisitDate, 
	dbo.GetFullName(LastName, MiddleName, FirstName) as FullName, 
	dbo.GetLookupDataDes(ItemCategoryID) as IncomeCategory, 
	Sum(Abs(UnitPrice * Quantity)) as TotalAmount,
	dbo.GetShortDate(ExtraBillItems.RecordDateTime) as RecordDate, 
	dbo.GetTime(ExtraBillItems.RecordDateTime) as RecordTime
	from ExtraBillItems 
	inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
	left outer join Visits on ExtraBills.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	
	where
	PayStatusID =@NotPaidPayStatus and Visits.BillModesID in (@VisitBillID,@InsBillID) and
	(ExtraBillItems.RecordDateTime >= @RecordStartDate and ExtraBillItems.RecordDateTime < @RecordEndDate)
	
	group by Visits.VisitNo, ItemCategoryID, LastName, MiddleName, FirstName, 
			VisitDate, ExtraBillItems.RecordDateTime
union
	select 2 as [No], 'Grand Total' as ReceiptNo, '' as VisitDate, '' as FullName, 
	'' as ItemCategory, Sum(Abs(UnitPrice * Quantity)) as TotalAmount,
	'' as RecordDate, '' as RecordTime
    from  ExtraBillItems 
	inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
	left outer join Visits on ExtraBills.VisitNo = Visits.VisitNo
	left outer join Patients on Visits.PatientNo = Patients.PatientNo
	
	where
	PayStatusID =@NotPaidPayStatus and Visits.BillModesID in (@VisitBillID,@InsBillID) and
	(ExtraBillItems.RecordDateTime >= @RecordStartDate and ExtraBillItems.RecordDateTime < @RecordEndDate)
	
end
end
return 0
go

--exec uspGetDetailedIPDNotPaidIncomePaymentDetailsSummaries '1 OCT 2017', '31 OCT 2017','7D'
--exec uspGetDetailedIPDNotPaidIncomePaymentDetailsSummaries '14 April 2017 12:00 Am', '14 April 2017 11:59 PM',''
--exec uspGetDetailedIPDNotPaidIncomePaymentDetailsSummaries '1 OCT 2017', '14 OCT 2017'


--------uspGetPatientRegistrationDetails----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetPatientRegistrationDetails')
	drop proc uspGetPatientRegistrationDetails
go

create proc uspGetPatientRegistrationDetails(
@StartDateTime smalldatetime = null,
@EndDateTime smalldatetime = null
)with encryption as

if not(@StartDateTime is null) and not(@EndDateTime is null)
begin
	select LoginID, dbo.GetLoginsFullName(LoginID) as FullName, count(PatientNo) as TotalPatients
	from Patients where RecordDateTime between @StartDateTime and @EndDateTime group by LoginID
end
else
begin
	select LoginID, dbo.GetLoginsFullName(LoginID) as FullName, count(PatientNo) as TotalPatients
	from Patients group by LoginID
end
return 0
go

--------uspGetVisitRegistrationDetails----------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetVisitRegistrationDetails')
	drop proc uspGetVisitRegistrationDetails
go

create proc uspGetVisitRegistrationDetails(
@StartDateTime smalldatetime = null,
@EndDateTime smalldatetime = null
)with encryption as

if not(@StartDateTime is null) and not(@EndDateTime is null)
begin
	select LoginID, dbo.GetLoginsFullName(LoginID) as FullName, count(VisitNo) as TotalVisits
	from Visits where RecordDateTime between @StartDateTime and @EndDateTime group by LoginID
end
else
begin
	select LoginID, dbo.GetLoginsFullName(LoginID) as FullName, count(VisitNo) as TotalVisits
	from Visits group by LoginID
end
return 0
go

----------------------------------------------------------------------------------------------------



