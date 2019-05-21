
------------------------------------------------------------------------------------------------------
-------------- Create Table: INTStockTake ------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTStockTake')
	drop table INTStockTake
go

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


------------------------------------------------------------------------------------------------------
-------------- INTStockTake --------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Insert INTStockTake -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspEditINTStockTake')
	drop proc uspEditINTStockTake
go

create proc uspEditINTStockTake(
@PSCNo varchar(20),
@ItemCategoryID varchar(10),
@ItemCode varchar(20),
@Agent varchar(10),
@SyncStatus bit
)with encryption as

declare @ErrorMSG varchar(200)
begin
if exists(select PSCNo from INTStockTake where PSCNo = @PSCNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode)
	begin
		update INTStockTake set
           Agent = @Agent, SyncStatus = @SyncStatus
           where PSCNo = @PSCNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode
	end

else

	begin
	insert into INTStockTake
	(PSCNo, ItemCategoryID, ItemCode, Agent, SyncStatus)
	values
	(@PSCNo, @ItemCategoryID, @ItemCode,  @Agent, @SyncStatus)

	end
return 0
end
go

/******************************************************************************************************
exec uspEditINTStockTake
******************************************************************************************************/
-- select * from INTStockTake
-- delete from INTStockTake


-------------- Update INTStockTake -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateINTStockTake')
	drop proc uspUpdateINTStockTake
go

create proc uspUpdateINTStockTake(
@PSCNo varchar(20),
@ItemCategoryID varchar(10),
@ItemCode varchar(20),
@Quantity int,
@Agent varchar(10),
@SyncStatus bit,
@RecordDateTime smalldatetime
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select PSCNo from INTStockTake where PSCNo = @PSCNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'PSCNo', @PSCNo, 'Item Category', @ItemCategoryID, 'Item Code', @ItemCode, 'INTStockTake')
		return 1
	end



begin
update INTStockTake set
Agent = @Agent, SyncStatus = @SyncStatus, RecordDateTime = @RecordDateTime
where PSCNo = @PSCNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode
return 0
end
go

/******************************************************************************************************
exec uspUpdateINTStockTake
******************************************************************************************************/
-- select * from INTStockTake
-- delete from INTStockTake


-------------- Get INTStockTake -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetINTStockTake')
	drop proc uspGetINTStockTake
go

create proc uspGetINTStockTake(
@PSCNo varchar(20),
@ItemCategoryID varchar(10),
@ItemCode varchar(20)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select PSCNo from INTStockTake where PSCNo = @PSCNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'PSCNo', @PSCNo, 'Item Category', @ItemCategoryID, 'Item Code', @ItemCode, 'INTStockTake')
		return 1
	end
else
begin
	select PSCNo, ItemCategoryID, ItemCode, Agent, SyncStatus, RecordDateTime
	from INTStockTake

	where PSCNo = @PSCNo and ItemCategoryID = @ItemCategoryID and ItemCode = @ItemCode
return 0
end
go

/******************************************************************************************************
exec uspGetINTStockTake
******************************************************************************************************/
-- select * from INTStockTake
-- delete from INTStockTake


------------------------------------------------------------------------------------------------------
-------------- Update: INTStockTake ----------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateINTStockTake')
	drop trigger utrUpdateINTStockTake
go

create trigger utrUpdateINTStockTake
on INTStockTake
for update
as
declare @ErrorMSG varchar(200)
declare @Identity int
declare @ObjectName varchar(40)
declare @FullDate smalldatetime

if @@rowcount = 0 return

------------------- Log Updates ----------------------------------------------

if ident_current('AuditTrail') <>  @@identity return
set @Identity = ident_current('AuditTrail')

if @Identity is null return

set @ObjectName = (select ObjectName from AuditTrail where AuditID = @Identity and AuditAction = 'U')
if @ObjectName is null return
if @ObjectName <> 'INTStockTake' return

set @FullDate = (select FullDate from AuditTrail where AuditID = @Identity)
if @FullDate is null return
if datediff(second, @FullDate, getdate()) > 60 return



------------------- Key-PSCNo -----------------------------------------------------

begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'PSCNo', Deleted.PSCNo, Inserted.PSCNo
	from Inserted inner join Deleted
	on Inserted.PSCNo = Deleted.PSCNo
	and Inserted.ItemCategoryID = Deleted.ItemCategoryID
	and Inserted.ItemCode = Deleted.ItemCode
end

------------------- Key-ItemCategoryID -----------------------------------------------------

begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'ItemCategoryID', Deleted.ItemCategoryID, Inserted.ItemCategoryID
	from Inserted inner join Deleted
	on Inserted.PSCNo = Deleted.PSCNo
	and Inserted.ItemCategoryID = Deleted.ItemCategoryID
	and Inserted.ItemCode = Deleted.ItemCode
end

------------------- Key-ItemCode -----------------------------------------------------

begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'ItemCode', Deleted.ItemCode, Inserted.ItemCode
	from Inserted inner join Deleted
	on Inserted.PSCNo = Deleted.PSCNo
	and Inserted.ItemCategoryID = Deleted.ItemCategoryID
	and Inserted.ItemCode = Deleted.ItemCode
end


-------------------  Agent  -----------------------------------------------------

if update(Agent)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'Agent', Deleted.Agent, Inserted.Agent
	from Inserted inner join Deleted
	on Inserted.PSCNo = Deleted.PSCNo
	and Inserted.ItemCategoryID = Deleted.ItemCategoryID
	and Inserted.ItemCode = Deleted.ItemCode
	and Inserted.Agent <> Deleted.Agent
end

-------------------  SyncStatus  -----------------------------------------------------

if update(SyncStatus)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'SyncStatus', Deleted.SyncStatus, Inserted.SyncStatus
	from Inserted inner join Deleted
	on Inserted.PSCNo = Deleted.PSCNo
	and Inserted.ItemCategoryID = Deleted.ItemCategoryID
	and Inserted.ItemCode = Deleted.ItemCode
	and Inserted.SyncStatus <> Deleted.SyncStatus
end

-------------------  RecordDateTime  -----------------------------------------------------

if update(RecordDateTime)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'RecordDateTime', dbo.FormatDateTime(Deleted.RecordDateTime), dbo.FormatDateTime(Inserted.RecordDateTime)
	from Inserted inner join Deleted
	on Inserted.PSCNo = Deleted.PSCNo
	and Inserted.ItemCategoryID = Deleted.ItemCategoryID
	and Inserted.ItemCode = Deleted.ItemCode
	and Inserted.RecordDateTime <> Deleted.RecordDateTime
end
go


------------------------------------------------------------------------------------------------------
-------------- Delete: INTStockTake ----------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrDeleteINTStockTake')
	drop trigger utrDeleteINTStockTake
go

create trigger utrDeleteINTStockTake
on INTStockTake
for delete
as
declare @Identity int
declare @ObjectName varchar(40)
declare @FullDate smalldatetime

if @@rowcount = 0 return

------------------- Log Deletes ----------------------------------------------

if ident_current('AuditTrail') <>  @@identity return
set @Identity = ident_current('AuditTrail')

if @Identity is null return

set @ObjectName = (select ObjectName from AuditTrail where AuditID = @Identity and AuditAction = 'D')
if @ObjectName is null return
if @ObjectName <> 'INTStockTake' return

set @FullDate = (select FullDate from AuditTrail where AuditID = @Identity)
if @FullDate is null return
if datediff(second, @FullDate, getdate()) > 60 return

-------------------  PSCNo  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'PSCNo', Deleted.PSCNo, null from Deleted

-------------------  ItemCategoryID  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'ItemCategoryID', Deleted.ItemCategoryID, null from Deleted

-------------------  ItemCode  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'ItemCode', Deleted.ItemCode, null from Deleted

-------------------  Agent  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'Agent', Deleted.Agent, null from Deleted

-------------------  SyncStatus  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'SyncStatus', Deleted.SyncStatus, null from Deleted

-------------------  RecordDateTime  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'RecordDateTime', dbo.FormatDateTime(Deleted.RecordDateTime), null from Deleted
go

