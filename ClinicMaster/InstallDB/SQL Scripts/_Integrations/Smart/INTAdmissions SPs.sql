
------------------------------------------------------------------------------------------------------
-------------- Create Table: INTAdmissions ------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'INTAdmissions')
	drop table INTAdmissions
go

create table INTAdmissions
(AgentNo Varchar(20) not null,
AdmissionNo varchar(20) not null
constraint fkAdmissionNoINTAdmissions references Admissions (AdmissionNo),
constraint pkAgentNoAdmissionNo primary key(AgentNo, AdmissionNo),
MemberLimit money,
UserID varchar(100) constraint dfUserIDINTAdmissions default System_User,
SyncStatus bit constraint dfSyncStatusINTAdmissions default 1,
ClientMachine varchar(40) constraint dfClientMachineINTAdmissions default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeINTAdmissions default getdate()
)
go


------------------------------------------------------------------------------------------------------
-------------- INTAdmissions --------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Insert INTAdmissions -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspEditINTAdmissions')
	drop proc uspEditINTAdmissions
go

create proc uspEditINTAdmissions(
@AgentNo Varchar(20),
@AdmissionNo varchar(20),
@MemberLimit money,
@UserID varchar(100),
@SyncStatus bit =1,
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select AdmissionNo from Admissions where AdmissionNo  = @AdmissionNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Admission No', @AdmissionNo, 'Admissions')
		return 1
	end

begin

if exists(select AgentNo from INTAdmissions where AgentNo = @AgentNo and AdmissionNo = @AdmissionNo)
	begin
		update INTAdmissions set
        MemberLimit = @MemberLimit, UserID = @UserID, SyncStatus = @SyncStatus, ClientMachine = @ClientMachine
        where AgentNo = @AgentNo and AdmissionNo = @AdmissionNo
	end



begin
insert into INTAdmissions
(AgentNo, AdmissionNo, MemberLimit, UserID, SyncStatus, ClientMachine)
values
(@AgentNo, @AdmissionNo, @MemberLimit, @UserID, @SyncStatus, @ClientMachine)
end
return 0
end
go

/******************************************************************************************************
exec uspEditINTAdmissions
******************************************************************************************************/
-- select * from INTAdmissions
-- delete from INTAdmissions

-------------- Get INTAdmissions -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetINTAdmissions')
	drop proc uspGetINTAdmissions
go

create proc uspGetINTAdmissions(
@AgentNo Varchar(20),
@AdmissionNo varchar(20)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select AgentNo from INTAdmissions where AgentNo = @AgentNo and AdmissionNo = @AdmissionNo)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Agent No', @AgentNo, 'Admission No', @AdmissionNo, 'INTAdmissions')
		return 1
	end
else
begin
	select AgentNo, AdmissionNo, MemberLimit, UserID, SyncStatus, ClientMachine, RecordDateTime
	from INTAdmissions

	where AgentNo = @AgentNo and AdmissionNo = @AdmissionNo
return 0
end
go

/******************************************************************************************************
exec uspGetINTAdmissions
******************************************************************************************************/
-- select * from INTAdmissions
-- delete from INTAdmissions


------------------------------------------------------------------------------------------------------
-------------- Update: INTAdmissions ----------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateINTAdmissions')
	drop trigger utrUpdateINTAdmissions
go

create trigger utrUpdateINTAdmissions
on INTAdmissions
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
if @ObjectName <> 'INTAdmissions' return

set @FullDate = (select FullDate from AuditTrail where AuditID = @Identity)
if @FullDate is null return
if datediff(second, @FullDate, getdate()) > 60 return



------------------- Key-AgentNo -----------------------------------------------------

begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'AgentNo', Deleted.AgentNo, Inserted.AgentNo
	from Inserted inner join Deleted
	on Inserted.AgentNo = Deleted.AgentNo
	and Inserted.AdmissionNo = Deleted.AdmissionNo
end

------------------- Key-AdmissionNo -----------------------------------------------------

begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'AdmissionNo', Deleted.AdmissionNo, Inserted.AdmissionNo
	from Inserted inner join Deleted
	on Inserted.AgentNo = Deleted.AgentNo
	and Inserted.AdmissionNo = Deleted.AdmissionNo
end

-------------------  MemberLimit  -----------------------------------------------------

if update(MemberLimit)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'MemberLimit', cast(Deleted.MemberLimit as varchar(20)), cast(Inserted.MemberLimit as varchar(20))
	from Inserted inner join Deleted
	on Inserted.AgentNo = Deleted.AgentNo
	and Inserted.AdmissionNo = Deleted.AdmissionNo
	and Inserted.MemberLimit <> Deleted.MemberLimit
end

-------------------  UserID  -----------------------------------------------------

if update(UserID)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'UserID', Deleted.UserID, Inserted.UserID
	from Inserted inner join Deleted
	on Inserted.AgentNo = Deleted.AgentNo
	and Inserted.AdmissionNo = Deleted.AdmissionNo
	and Inserted.UserID <> Deleted.UserID
end

-------------------  SyncStatus  -----------------------------------------------------

if update(SyncStatus)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'SyncStatus', Deleted.SyncStatus, Inserted.SyncStatus
	from Inserted inner join Deleted
	on Inserted.AgentNo = Deleted.AgentNo
	and Inserted.AdmissionNo = Deleted.AdmissionNo
	and Inserted.SyncStatus <> Deleted.SyncStatus
end

-------------------  ClientMachine  -----------------------------------------------------

if update(ClientMachine)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'ClientMachine', Deleted.ClientMachine, Inserted.ClientMachine
	from Inserted inner join Deleted
	on Inserted.AgentNo = Deleted.AgentNo
	and Inserted.AdmissionNo = Deleted.AdmissionNo
	and Inserted.ClientMachine <> Deleted.ClientMachine
end



------------------------------------------------------------------------------------------------------
-------------- Delete: INTAdmissions ----------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrDeleteINTAdmissions')
	drop trigger utrDeleteINTAdmissions
go

create trigger utrDeleteINTAdmissions
on INTAdmissions
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
if @ObjectName <> 'INTAdmissions' return

set @FullDate = (select FullDate from AuditTrail where AuditID = @Identity)
if @FullDate is null return
if datediff(second, @FullDate, getdate()) > 60 return

-------------------  AgentNo  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'AgentNo', Deleted.AgentNo, null from Deleted

-------------------  AdmissionNo  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'AdmissionNo', Deleted.AdmissionNo, null from Deleted

-------------------  MemberLimit  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'MemberLimit', cast(Deleted.MemberLimit as varchar(20)), null from Deleted

-------------------  UserID  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'UserID', Deleted.UserID, null from Deleted

-------------------  SyncStatus  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'SyncStatus', Deleted.SyncStatus, null from Deleted

-------------------  ClientMachine  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'ClientMachine', Deleted.ClientMachine, null from Deleted



