
if exists (select * from sysobjects where name = 'uspReverseReceiptsOPD')
	drop proc uspReverseReceiptsOPD
go

create proc uspReverseReceiptsOPD(
@VisitNo varchar(20),
@ItemCategoryID varchar(10),
@ItemCode varchar(20)
)with encryption as 

declare @ErrorMSG varchar(200)
declare @NotPaidPayStatusID varchar(10)
declare @PaidPayStatusID varchar(10)
declare @PercentCoPayTypeID varchar(10)
declare @CoPayTypeID varchar(10)
declare @CoPayPercent decimal(5,2)

-----------------------------------------------------------------------------------------------
set @NotPaidPayStatusID = dbo.GetLookupDataID('PayStatus', 'NP')
set @PaidPayStatusID = dbo.GetLookupDataID('PayStatus', 'PF')
set @PercentCoPayTypeID = dbo.GetLookupDataID('CoPayType', 'PCT')
-----------------------------------------------------------------------------------------------


if not (@VisitNo is null or @VisitNo = '')
begin
if  exists(select VisitNo from Items where VisitNo = @VisitNo and ItemCode = @ItemCode and
ItemCategoryID = @ItemCategoryID and PayStatusID = @PaidPayStatusID) 
begin
if ((not exists(select VisitNo from ItemsCash where VisitNo = @VisitNo and 
ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)) 
or								
(exists(select VisitNo from ItemsCash where VisitNo = @VisitNo and ItemCode = @ItemCode and
ItemCategoryID = @ItemCategoryID and CashPayStatusID = @PaidPayStatusID))) 
						
begin
begin tran 						
												
set @CoPayTypeID = (select CoPayTypeID from Visits where VisitNo = @VisitNo)
								
---------------------------------------------------------------------------------------
update Items set PayStatusID = @NotPaidPayStatusID
where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID	
---------------------------------------------------------------------------------------
if (@CoPayTypeID = @PercentCoPayTypeID)
begin
	
update ItemsCash set CashPayStatusID = @NotPaidPayStatusID
	where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
end
---------------------------------------------------------------------------------------
											
if @@error > 0
begin
	rollback tran
	return 1		
end
commit tran
						
return 0
end
end	
end

/*--------------------------------------------------------------------------------------------------------
-- exec uspReverseReceiptsOPD '15007328001', '7T', 'T006'
---------------------------------------------------------------------------------------------------------*/