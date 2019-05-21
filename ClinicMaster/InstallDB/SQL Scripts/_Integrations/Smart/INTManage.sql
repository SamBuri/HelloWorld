

-------------- Edit INTExtraBills -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspEditINTExtraBills')
	drop proc uspEditINTExtraBills
go

create proc uspEditINTExtraBills(
@AgentNo varchar(20),
@ExtraBillNo varchar(20),
@SyncStatus bit  =1
)with encryption as

if exists(select ExtraBillNo from INTExtraBills where AgentNo = @AgentNo and ExtraBillNo = @ExtraBillNo)
	begin
		update INTExtraBills set
		SyncStatus = @SyncStatus
		where AgentNo = @AgentNo and ExtraBillNo = @ExtraBillNo
		return 0
	end
else
begin
	insert into INTExtraBills
	(AgentNo, ExtraBillNo, SyncStatus)
	values
	(@AgentNo, @ExtraBillNo, @SyncStatus)
	return 0
end
go

/******************************************************************************************************
exec uspEditINTExtraBills 'NAV', '160026001'
select * from ExtraBills
******************************************************************************************************/
-- select * from INTExtraBills
-- select TOP 10 * from ExtraBills
-- delete from INTExtraBills



-------------- Edit INTExtraBillItems -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspEditINTExtraBillItems')
	drop proc uspEditINTExtraBillItems
go

create proc uspEditINTExtraBillItems(
@AgentNo varchar(20),
@ExtraBillNo varchar(20),
@ItemCategoryID varchar(10),
@ItemCode varchar(20),
@SyncStatus bit = 1
)with encryption as

declare @ErrorMSG varchar(200)


if exists(select ExtraBillNo from INTExtraBillItems where AgentNo = @AgentNo AND ExtraBillNo = @ExtraBillNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode)
	begin
		update INTExtraBillItems set
		SyncStatus = @SyncStatus
		where AgentNo = @AgentNo AND ExtraBillNo = @ExtraBillNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode
		return 0
	end
else
begin
	insert into INTExtraBillItems
	(AgentNo, ExtraBillNo, ItemCategoryID, ItemCode, SyncStatus)
	values
	(@AgentNo, @ExtraBillNo, @ItemCategoryID, @ItemCode, @SyncStatus)
	return 0
end
go

/******************************************************************************************************
 select * from INTExtraBillItems
 select top 10 * from ExtraBillItems WHERE ExtraBillNo ='170012002'
 delete from INTExtraBillItems
 exec uspEditINTExtraBillItems 'SMART', 'P1800355840001', '7D','DRG0015', 1
******************************************************************************************************/



------------ Get INT Extra Bill Items By Sync Status -----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetINTExtraBillItemsBySyncStatus')
drop proc uspGetINTExtraBillItemsBySyncStatus
go

create proc uspGetINTExtraBillItemsBySyncStatus(
@AgentNo Varchar(20),
@VisitNo Varchar(20),
@SyncStatus bit = 0

)with encryption as

declare @ErrorMSG varchar(200)
declare @NotPaidStatusID varchar(10)
set @NotPaidStatusID =  dbo.GetLookupDataID('PayStatus', 'NP')
if not exists(select AgentNo from INTAgents where AgentNo = @AgentNo)
begin
set @ErrorMSG = 'The Agent with %s: %s, you are trying to enter does not exist in the registered %s'
raiserror(@ErrorMSG, 16, 1, 'Agent No', @AgentNo, 'Agents')
return 1
end

begin
	 select ExtraBillItems.ExtraBillNo, ExtraBills.VisitNo, ExtraBills.RecordDateTime, ExtraBillItems.ItemCategoryID,
	 dbo.GetLookupDataDes(ExtraBillItems.ItemCategoryID) as ItemCategory ,ExtraBillItems.ItemCode, ItemName, UnitPrice, Quantity, (UnitPrice*Quantity) as Amount, isnull(CashAmount, 0) as CashAmount,
	 Notes, PayStatusID, dbo.GetLookupDataDes(PayStatusID) as PayStatus, EntryModeID, dbo.GetLookupDataDes(EntryModeID) as EntryMode, Notes,
	 dbo.GetInventoryBatchNo('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as BatchNo, 1 as AutoInclude,
	 UnitMeasure, dbo.GetInventoryExpiryDate('', ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as ExpiryDate,ExtraBillItems.LoginID, SyncStatus
	 from INTExtraBillItems
	 inner join ExtraBillItems on INTExtraBillItems.ExtraBillNo = ExtraBillItems.ExtraBillNo and INTExtraBillItems.ItemCode = ExtraBillItems.ItemCode and INTExtraBillItems.ItemCategoryID = ExtraBillItems.ItemCategoryID
	 inner join ExtraBills on ExtraBillItems.ExtraBillNo = ExtraBills.ExtraBillNo
	 left outer join ExtraBillItemsCASH on INTExtraBillItems.ExtraBillNo = ExtraBillItemsCASH.ExtraBillNo and INTExtraBillItems.ItemCode = ExtraBillItemsCASH.ItemCode and INTExtraBillItems.ItemCategoryID = ExtraBillItemsCASH.ItemCategoryID
	 WHERE  AgentNo = @AgentNo  and VisitNo = @VisitNo and SyncStatus = @SyncStatus and PayStatusID = @NotPaidStatusID
end
go

/****************************************************************************************
exec uspGetINTExtraBillItemsBySyncStatus '167SMART','P1800355870001', 0
 select * from INTExtraBillItems
  select * from ExtraBillItemsCASH
select * from ExtraBills where ExtraBillNo ='P160001850002'
****************************************************************************************/

--- select * from Admissions where VisitNo = 'P1800355870001'

