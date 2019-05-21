
/***************************************************************
This Script is a property of ClinicMaster INTERNATIONAL
Un authorised use or ammendment is not permitted
-- Last updated 03/01/2017 by Wilson Kutegeka
***************************************************************/

------------------------------------------------------------------------------------------------------

------------------------------- Logins ---------------------------------------------------------------
------------------------------------------------------------------------------------------------------

--1-------------Insert Logins-------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertLogins')
	drop proc uspInsertLogins
go

create proc uspInsertLogins(
@LoginID varchar(20),
@FirstName varchar(20),
@LastName varchar(20),
@LoginPassword nvarchar(200),
@LoginLevel tinyint,
@StatusID varchar(10),
@ChangePassword bit = 0,
@CreatorLoginID varchar(20),
@CreatorClientMachine varchar(40)
)with encryption as 

declare @ErrorMSG varchar(200)

if  @LoginID = ''
begin
	raiserror('Must supply Login ID', 16, 1)
	return 1
end

if exists(select LoginID from Logins where LoginID = @LoginID)
	begin
		raiserror('The Login ID you are trying to enter arleady exists', 16, 1)
		return 1
	end

if not exists(select DataID from LookupData where DataID = @StatusID)
	begin
		set @ErrorMSG = 'The Status ID: %s, you''re trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @StatusID, 'Lookup Data')	
		return 1
	end

if (not exists(select LoginID from Logins where LoginID = @CreatorLoginID) and (not (@CreatorLoginID is null or @CreatorLoginID = '')))
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s and not empty'
		raiserror(@ErrorMSG, 16, 1, 'Creator Login ID', @CreatorLoginID, 'Logins')
		return 1
	end
else if (@CreatorLoginID is null or @CreatorLoginID = '') begin set @CreatorLoginID = null end

begin

----------------------------------------------------------------------------------------------
if (@CreatorClientMachine is null or @CreatorClientMachine = '') begin set @CreatorClientMachine = host_name() end
----------------------------------------------------------------------------------------------

insert into Logins
(LoginID, FirstName, LastName, LoginPassword, LoginLevel, StatusID, ChangePassword, CreatorLoginID, CreatorClientMachine) 
values
(@LoginID, @FirstName, @LastName, @LoginPassword, @LoginLevel, @StatusID, @ChangePassword, @CreatorLoginID, @CreatorClientMachine)
return 0
-- comment: sp_password
end
go

--2----------------Get Logins------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetLogins')
	drop proc uspGetLogins
go

create proc uspGetLogins(
@LoginID varchar(20),
@FullName varchar(41) = null output,
@LoginPassword nvarchar (200) = null output,
@LoginLevel tinyint = null output,
@StatusID varchar(10) = null output,
@ChangePassword bit = null output
)with encryption as  

if not exists(select LoginID from Logins where LoginID = @LoginID)
begin
	raiserror('Wrong User Name', 16, 1)	
	exec uspInsertSuspiciousLogins @LoginID,'Wrong Username attempted'
	return 1
end

set @FullName = (select FirstName + ' ' + LastName from Logins where LoginID = @LoginID)
set @LoginPassword = (select LoginPassword from Logins where LoginID = @LoginID)
set @LoginLevel = (select LoginLevel from Logins where LoginID = @LoginID)
set @StatusID = (select StatusID from Logins where LoginID = @LoginID)
set @ChangePassword = (select ChangePassword from Logins where LoginID = @LoginID)

return 0
-- comment: sp_password
go

--3------------Count Logins-------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspCountLogins')
	drop proc uspCountLogins
go

create proc uspCountLogins(
@NoLogins int = null output
)with encryption as   

set @NoLogins = (select count(*) as NoLogins from Logins) 

return 0
-- comment: sp_password

go

--4--------Delete Logins---------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteLogins')
	drop proc uspDeleteLogins
go

create proc uspDeleteLogins(
@LoginID varchar(20),
@RecordsDeleted varchar(40) = null output
)with encryption as   

if not exists(select LoginID from Logins where LoginID = @LoginID)
begin
	raiserror('Wrong User Name', 16, 1)	
	return 1
end

delete Logins where (LoginID = @LoginID)

if @@rowcount > 0
set @RecordsDeleted = 'Login ID: ' + @LoginID + ', successfully deleted!'

return 0
-- comment: sp_password

go

--5--------Update Logins--------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateLogins')
	drop proc uspUpdateLogins
go

create proc uspUpdateLogins(
@LoginID varchar(20),
@FirstName varchar(20) = null,
@LastName varchar(20) = null,
@LoginPassword nvarchar(200) = null,
@LoginLevel tinyint = null,
@StatusID varchar(10) = null,
@ChangePassword bit = null
)with encryption as   

if not exists(select LoginID from Logins where LoginID = @LoginID)
	begin
		raiserror('Wrong User Name', 16, 1)	
		return 1
	end

if not (@FirstName is null or @FirstName = '') 
	begin update Logins set FirstName = @FirstName where LoginID = @LoginID end
	
if not (@LastName is null or @LastName = '') 
	begin update Logins set LastName = @LastName where LoginID = @LoginID end
	
if not (@LoginPassword is null) and (@LoginLevel is null)
	begin update Logins set LoginPassword = @LoginPassword where LoginID = @LoginID end
	
if  (@LoginPassword is null) and not (@LoginLevel is null)
	begin update Logins set LoginLevel = @LoginLevel where LoginID = @LoginID end
	
if not (@StatusID is null or @StatusID = '') 
	begin update Logins set StatusID = @StatusID where LoginID = @LoginID end
	
if not (@ChangePassword is null)
	begin update Logins set ChangePassword = @ChangePassword where LoginID = @LoginID end

return 0
-- comment: sp_password
go

-- select * from Logins

------------------------------------------------------------------------------------------------------
-------------- Update: Logins ------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateLogins')
	drop trigger utrUpdateLogins
go

create trigger utrUpdateLogins
on Logins
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
if @ObjectName <> 'Logins' return

set @FullDate = (select FullDate from AuditTrail where AuditID = @Identity)
if @FullDate is null return
if datediff(second, @FullDate, getdate()) > 60 return

------------------- Key-LoginID  -----------------------------------------------------

begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'LoginID ', Deleted.LoginID , Inserted.LoginID 
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
end

-------------------  FirstName  -----------------------------------------------------

if update(FirstName)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'FirstName', Deleted.FirstName, Inserted.FirstName
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.FirstName <> Deleted.FirstName
end

-------------------  LastName  -----------------------------------------------------

if update(LastName)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'LastName', Deleted.LastName, Inserted.LastName
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.LastName <> Deleted.LastName
end

-------------------  LoginLevel  -----------------------------------------------------

if update(LoginLevel)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'LoginLevel', Deleted.LoginLevel, Inserted.LoginLevel
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.LoginLevel <> Deleted.LoginLevel
end

-------------------  StatusID  -----------------------------------------------------

if update(StatusID)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'StatusID', Deleted.StatusID, Inserted.StatusID
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.StatusID <> Deleted.StatusID
end

-------------------  ChangePassword  -----------------------------------------------------

if update(ChangePassword)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'ChangePassword', Deleted.ChangePassword, Inserted.ChangePassword
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.ChangePassword <> Deleted.ChangePassword
end

-------------------  CreatorLoginID  -----------------------------------------------------

if update(CreatorLoginID)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'CreatorLoginID', Deleted.CreatorLoginID, Inserted.CreatorLoginID
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.CreatorLoginID <> Deleted.CreatorLoginID
end

-------------------  CreatorClientMachine  -----------------------------------------------------

if update(CreatorClientMachine)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'CreatorClientMachine', Deleted.CreatorClientMachine, Inserted.CreatorClientMachine
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.CreatorClientMachine <> Deleted.CreatorClientMachine
end

-------------------  CreatorRecordDateTime  -----------------------------------------------------

if update(CreatorRecordDateTime)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'CreatorRecordDateTime', dbo.FormatDate(Deleted.CreatorRecordDateTime), dbo.FormatDate(Inserted.CreatorRecordDateTime)
	from Inserted inner join Deleted
	on Inserted.LoginID  = Deleted.LoginID 
	and Inserted.CreatorRecordDateTime <> Deleted.CreatorRecordDateTime
end
go

------------------------------------------------------------------------------------------------------
-------------- Delete: Logins ------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrDeleteLogins')
	drop trigger utrDeleteLogins
go

create trigger utrDeleteLogins
on Logins
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
if @ObjectName <> 'Logins' return

set @FullDate = (select FullDate from AuditTrail where AuditID = @Identity)
if @FullDate is null return
if datediff(second, @FullDate, getdate()) > 60 return

-------------------  LoginID   -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'LoginID ', Deleted.LoginID , null from Deleted

-------------------  FirstName  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'FirstName', Deleted.FirstName, null from Deleted

-------------------  LastName  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'LastName', Deleted.LastName, null from Deleted

-------------------  LoginLevel  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'LoginLevel', Deleted.LoginLevel, null from Deleted

-------------------  StatusID  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'StatusID', Deleted.StatusID, null from Deleted

-------------------  ChangePassword  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'ChangePassword', Deleted.ChangePassword, null from Deleted

-------------------  CreatorLoginID  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'CreatorLoginID', Deleted.CreatorLoginID, null from Deleted

-------------------  CreatorClientMachine  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'CreatorClientMachine', Deleted.CreatorClientMachine, null from Deleted

-------------------  CreatorRecordDateTime  -----------------------------------------------------
insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
select @Identity, 'CreatorRecordDateTime', dbo.FormatDate(Deleted.CreatorRecordDateTime), null from Deleted
go

------------------------------------------------------------------------------------------------------
------------- Lookup ---------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

--------Insert Lookup Objects-------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertLookupObjects')
	drop proc uspInsertLookupObjects
go

create proc uspInsertLookupObjects(
@ObjectID smallint,
@ObjectName varchar(40),
@ObjectDes varchar(60),
@IsReadOnly char(1)= "Y"
)with encryption as   

declare @ErrorMSG varchar(200)

if exists(select ObjectID from LookupObjects where ObjectID = @ObjectID)
	begin
		set @ErrorMSG = 'The Object ID: ' + cast(@ObjectID as varchar) + ', you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1)	
		return 1
	end

else

begin
insert into LookupObjects
(ObjectID ,ObjectName ,ObjectDes ,IsReadOnly) 
values
(@ObjectID ,@ObjectName,@ObjectDes ,@IsReadOnly)
return 0
-- comment: sp_password
end
go

-------Insert Lookup Data------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertLookupData')
	drop proc uspInsertLookupData
go

create proc uspInsertLookupData(
@DataID varchar(10),
@ObjectID smallint,
@DataDes varchar(100),
@IsDefault char(1)= 'N', --Y-Yes, N-No
@IsHidden char(1)= 'N'
)with encryption as   

declare @ErrorMSG varchar(200)

if exists(select DataID from LookupData where DataID = @DataID)
	begin
		set @ErrorMSG = 'The Data ID: ' + @DataID + ', you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1)	
		return 1
	end

if not exists(select ObjectID from LookupObjects where ObjectID = @ObjectID)
	begin
		set @ErrorMSG = 'The Object ID: ' + cast(@ObjectID as varchar) + ', you are trying to enter does not exists in the registered Lookup Objects'
		raiserror(@ErrorMSG, 16, 1)	
		return 1
	end

else

begin
insert into LookupData
(DataID, ObjectID, DataDes, IsDefault, IsHidden) values
(@DataID, @ObjectID, @DataDes, @IsDefault, @IsHidden)
return 0
-- comment: sp_password
end
go

--1------ Get Lookup Objects---------------------------------------------

if exists (select * from sysobjects where name = 'uspGetLookupObjects')
	drop proc uspGetLookupObjects
go

create proc uspGetLookupObjects
with encryption as
select ObjectID,ObjectDes as ObjectName, (ObjectDes + ' -> ' + cast( ObjectID as varchar)) AS ObjectDes, IsReadOnly
from LookupObjects
order by ObjectDes
return 0
-- comment: sp_password
go

-- exec uspGetLookupObjects

------------Get Lookup Data--------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetLookupData')
	drop proc uspGetLookupData
go

create proc uspGetLookupData(
@ObjectID smallint,
@DataID varchar(10) = null ,
@DataDes varchar(100) = null,
@RemoveHidden bit = 0
)with encryption as 

----------------------------------------------------------------------------------------------
declare @IsHidden char(1)
set @IsHidden = 'N'
----------------------------------------------------------------------------------------------

if (@DataID is null) and (@DataDes is null)
	begin
		if (@RemoveHidden = 1)
			begin
				Select LookupOrder, DataID, ObjectID, DataDes, DataDes + ' -> ' + DataID as DataName, 
					case IsDefault when 'N' then 'No' else 'Yes' end as DefaultDes,
					case IsHidden when 'N' then 'No' else 'Yes' end as Hidden  
				from LookupData
				where ObjectID = @ObjectID and IsHidden = @IsHidden order by LookupOrder
			end
		else
		begin
			Select LookupOrder, DataID, ObjectID, DataDes, DataDes + ' -> ' + DataID as DataName, 
				case IsDefault when 'N' then 'No' else 'Yes' end as DefaultDes,
				case IsHidden when 'N' then 'No' else 'Yes' end as Hidden  
			from LookupData
			where ObjectID = @ObjectID order by LookupOrder
		end
	end

if not (@DataID is null) and (@DataDes is null)
	begin
		Select DataID, ObjectID, DataDes, 
			case IsDefault when 'N' then 'No' else 'Yes' end as DefaultDes,
			case IsHidden when 'N' then 'No' else 'Yes' end as Hidden 
		from LookupData
		where ObjectID = @ObjectID and DataID = @DataID
	end

if  (@DataID is null) and not(@DataDes is null)
	begin
		set @DataDes = convert(char(1),'%') + @DataDes + convert(char(1),'%')
		Select DataID, ObjectID, DataDes, 
			case IsDefault when 'N' then 'No' else 'Yes' end as DefaultDes,
			case IsHidden when 'N' then 'No' else 'Yes' end as Hidden   
		from LookupData
		where ObjectID = @ObjectID and DataDes like @DataDes
	end

return 0
-- comment: sp_password
go

-- exec uspGetLookupData 1
-- exec uspGetLookupData 7
-- exec uspGetLookupData 1,'1A', null
-- exec uspGetLookupData 11,null, 'e'

------------Get Lookup Data ID--------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetLookupDataID')
	drop proc uspGetLookupDataID
go

create proc uspGetLookupDataID(
@ObjectID smallint,
@DataDes varchar(100),
@DataID varchar(10) = null output
)with encryption as 

set @DataID = (select DataID from LookupData where ObjectID = @ObjectID and DataDes = @DataDes)

return 0
-- comment: sp_password
go

-- exec uspGetLookupDataID 1, 'Active'
-- exec uspGetLookupDataID 2, 'Between'

-- select * from LookupData

------------ Update Lookup Data-------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateLookupData')
	drop proc uspUpdateLookupData
go

create proc uspUpdateLookupData(
@DataID varchar(10),
@DataDes varchar(100),
@IsDefault char(1),
@IsHidden char(1)
)with encryption as   

declare @ErrorMSG varchar(40)
if not exists(select DataID from LookupData where DataID = @DataID)
begin
	set @ErrorMSG = 'No record(s) found for Data ID: ' + @DataID
	raiserror(@ErrorMSG,16,1)	
	return 1
end
else

update LookupData 
set DataDes = @DataDes , IsDefault = @IsDefault, IsHidden = @IsHidden
where DataID = @DataID

return 0
-- comment: sp_password
go

/*-----------------------------------------------------------
exec uspUpdateLookupData '10C', 'Consultation', 'N'
------------------------------------------------------------*/

--select * from LookupData
-----------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteLookupData')
	drop proc uspDeleteLookupData
go

create proc uspDeleteLookupData(
@DataID varchar(10)
)with encryption as  

declare @ErrorMSG varchar(40)

if not exists(select DataID from LookupData where DataID = @DataID)
begin
	set @ErrorMSG = 'No record(s) found for Data ID: ' + @DataID
	raiserror(@ErrorMSG,16,1)	
	return 1
end

delete LookupData where (DataID = @DataID)

return 0
-- comment: sp_password
go

-- uspDeleteLookupData '10C'
--------------------------------------------------------------------

--3------------Count Lookup Default-------------------------------------------

if exists (select * from sysobjects where name = 'uspCountLookupDefault')
	drop proc uspCountLookupDefault
go

create proc uspCountLookupDefault(
@ObjectID smallint,
@IsDefault char(1),
@NoDefault  int = null output
)with encryption as   

set @NoDefault = (select count(IsDefault) from LookupData
where  (ObjectID = @ObjectID and IsDefault = @IsDefault))

return 0
-- comment: sp_password
go

-- exec uspCountLookupDefault 1, 'Y'

-----------uspGetLookupDataName-----------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetLookupDataName')
	drop proc uspGetLookupDataName
go

create proc uspGetLookupDataName(
@DataID varchar(10) = null,
@ObjectID smallint = null,
@IsDefault char(1) = null
)with encryption as

if (@DataID is null)
	begin
		select DataID, (DataDes + ' -> ' + DataID)  as DataName from LookupData
		where (ObjectID Like @ObjectID and IsDefault Like @IsDefault)
	end 
else
	begin
		select DataID, (DataDes + ' -> ' + DataID)  as DataName from LookupData
		where (DataID Like @DataID)
	end 
-- comment: sp_password
go
-----------------------------------------------------
--exec uspGetLookupDataName '10C', null, null
--exec uspGetLookupDataName null, 7, 'N'
-----------------------------------------------------

-- select *  from LookupData
-- delete from LookupData

------------------------------------------------------------------------------------------------------
------------------------------- Functions ------------------------------------------------------------
------------------------------------------------------------------------------------------------------

--------Function Get Lookup Object ID-----------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetLookupObjectID')
	drop function GetLookupObjectID
go

create function GetLookupObjectID(@ObjectName varchar(40)) returns smallint
with encryption as 

begin
	declare @ObjectID smallint

	if exists (select ObjectID from LookupObjects where ObjectName = @ObjectName)
	set @ObjectID = (select ObjectID from LookupObjects where ObjectName = @ObjectName)
	else set @ObjectID = 0

	return @ObjectID
-- comment: sp_password
end
go

/*declare @value tinyint
set @value = dbo.GetLookupObjectID('SearchCriterion')
print cast(@value as varchar)*/

--------Function Get Lookup Data ID--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetLookupDataID')
	drop function GetLookupDataID
go

create function GetLookupDataID(@ObjectName varchar(40), @ID varchar(8)) returns varchar(10)
with encryption as 

begin

declare @DataID varchar(10)

if dbo.GetLookupObjectID(@ObjectName) < 1 set @DataID = null
else set @DataID = cast(dbo.GetLookupObjectID(@ObjectName) as varchar) + @ID

return @DataID
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetLookupDataID('Status', 'G') 
----------------------------------------------------------------------------------------------------------------------------

--------Function Get Lookup DataDes-----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetLookupDataDes')
	drop function GetLookupDataDes
go

create function GetLookupDataDes(@DataID as varchar(10)) returns varchar(100)
with encryption as 

begin
	
	declare @DataDes varchar(100)

	set @DataDes = (select DataDes from LookupData where DataID = @DataID)
	set @DataDes = isnull(@DataDes, '')

	return @DataDes
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetLookupDataDes('10C')
--  select * from LookupData
----------------------------------------------------------------------------------------------------------------------------

--------Function Get Lookup DataName-----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetLookupDataName')
	drop function GetLookupDataName
go

create function GetLookupDataName(@Text as varchar(200)) returns varchar(1000)
with encryption as

begin
	
declare @SplitCHAR char(1)
declare @Index tinyint
declare @DataID as varchar(10)
declare @DataDes varchar(100)
declare @NewText as varchar(1000)

set @SplitCHAR = ','

set @Index = charindex(@SplitCHAR, @Text, 0)

if @Index = 0
begin
	set @DataDes = dbo.GetLookupDataDes(@Text)	
	set @NewText = @DataDes
end

else
begin

	set @DataID = ltrim(rtrim(substring(@Text, 0, @Index)))
	set @Text = ltrim(rtrim(substring(@Text, @Index + 1 , len(@Text))))

	set @DataDes = dbo.GetLookupDataDes(@DataID)
	set @NewText = @DataDes

while @Index > 0
	
	begin
		
		set @Index = charindex(@SplitCHAR, @Text, 0)
		set @DataID = ltrim(rtrim(substring(@Text, 0, @Index)))
		set @Text = ltrim(rtrim(substring(@Text, @Index + 1 , len(@Text))))

		set @DataDes = dbo.GetLookupDataDes(@DataID)

		set @NewText = @NewText + ', ' + @DataDes
				
	end

	set @DataDes = dbo.GetLookupDataDes(@Text)
	set @NewText = @NewText + @DataDes

end

	return @NewText
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetLookupDataName('10C,10F,10S,10R,15F,1A')
-- print dbo.GetLookupDataName('10C')
--  select * from LookupData
----------------------------------------------------------------------------------------------------------------------------

--------Function GetAge-----------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetAge')
	drop function GetAge
go

create function GetAge(@BirthDate smalldatetime, @Today as smalldatetime) returns tinyint
with encryption as
begin

declare @Age tinyint
declare @BirthMonth tinyint
declare @TodayMonth tinyint
declare @BirthDay tinyint
declare @TodayDay tinyint

set @Age = datediff(year, @BirthDate, @Today)	
set @BirthMonth = month(@BirthDate)
set @TodayMonth = month(@Today)
set @BirthDay = day(@BirthDate)
set @TodayDay = day(@Today)

if ((@Age > 0 and @BirthMonth > @TodayMonth) or 
	(@Age > 0 and @BirthMonth = @TodayMonth and @BirthDay > @TodayDay))
	begin set @Age = @Age - 1 end

set @Age = isnull(@Age, 0)

return @Age
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetAge('23 Apr 1982', getdate())
-- print dbo.GetAge('30 Mar 2011', getdate())
----------------------------------------------------------------------------------------------------------------------------

--------Function GetAgeInMonths--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetAgeInMonths')
	drop function GetAgeInMonths
go

create function GetAgeInMonths(@BirthDate smalldatetime, @Today as smalldatetime) returns int
with encryption as
begin

declare @Age int
declare @BirthDay tinyint
declare @TodayDay tinyint
	
set @Age = datediff(month, @BirthDate, @Today)	
set @BirthDay = day(@BirthDate)
set @TodayDay = day(@Today)
	
if ((@Age > 0 and @BirthDay > @TodayDay))
	begin set @Age = @Age - 1 end

set @Age = isnull(@Age, 0)

return @Age
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print cast(dbo.GetAgeInMonths('9 Sep 2008', getdate()) as varchar)
----------------------------------------------------------------------------------------------------------------------------

--------Function GetAgeInDays--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetAgeInDays')
	drop function GetAgeInDays
go

create function GetAgeInDays(@BirthDate smalldatetime, @Today as smalldatetime) returns int
with encryption as
begin

declare @Age int
	
set @Age = datediff(day, @BirthDate, @Today)	

set @Age = isnull(@Age, 0)

return @Age
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetAgeInDays('23 Mar 1972', getdate())
----------------------------------------------------------------------------------------------------------------------------

--------Function GetWaitingTime---------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetWaitingTime')
	drop function GetWaitingTime
go

create function GetWaitingTime(@StartDate smalldatetime, @EndDate as smalldatetime) returns int
with encryption as
begin

declare @WaitingTime int
	
set @WaitingTime = datediff(minute, @StartDate, @EndDate)	

set @WaitingTime = isnull(@WaitingTime, 0)

return @WaitingTime
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetWaitingTime('Feb 10 2015  09:28AM', getdate())
----------------------------------------------------------------------------------------------------------------------------

--------Function GetWaitingDays---------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetWaitingDays')
	drop function GetWaitingDays
go

create function GetWaitingDays(@StartDate smalldatetime, @EndDate as smalldatetime) returns int
with encryption as
begin

declare @WaitingDays int
	
set @WaitingDays = datediff(day, @StartDate, @EndDate)	

set @WaitingDays = isnull(@WaitingDays, 0)

return @WaitingDays
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetWaitingDays('May 6 2015  09:28AM', getdate())
----------------------------------------------------------------------------------------------------------------------------

--------Function Merged Name Code-------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetMergedNameCode')
	drop function GetMergedNameCode
go

create function GetMergedNameCode(@Name varchar(400), @Code varchar(100)) returns varchar(510)
with encryption as

begin

declare @MergedNameCode varchar(510)
set @MergedNameCode = @Name + ' -> ' + @Code

return @MergedNameCode
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetMergedNameCode('Debit','DR')
----------------------------------------------------------------------------------------------------------------------------

--------Function Get Full Name----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetFullName')
	drop function GetFullName
go

create function GetFullName(@LastName varchar(30), @MiddleName varchar(30), @FirstName varchar(30)) returns varchar(100)
with encryption as

begin

declare @FullName varchar(100)

if (@MiddleName is null or @MiddleName = '')
	begin set @FullName = @LastName + ' ' + @FirstName end
else
if not (@MiddleName is null or @MiddleName = '')
	begin set @FullName = @LastName + ' ' + @MiddleName + ' ' + @FirstName end

return @FullName
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetFullName('Kutegeka', null, 'Wilson')
-- print dbo.GetFullName('Kutegeka', 'Kateeba', 'Wilson')
----------------------------------------------------------------------------------------------------------------------------

--------Function FormatDate--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'FormatDate')
	drop function FormatDate
go

create function FormatDate(@Date smalldatetime) returns varchar(12)
with encryption as

begin

declare @NewDate varchar(12)

if isdate(@Date) = 1
	begin
		set @NewDate = cast(@Date as varchar(12))
	end

return @NewDate
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.FormatDate('mar 23 1992') 
----------------------------------------------------------------------------------------------------------------------------

--------Function FormatDateTime--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'FormatDateTime')
	drop function FormatDateTime
go

create function FormatDateTime(@DateTime smalldatetime) returns varchar(20)
with encryption as

begin

declare @NewDateTime varchar(20)

if isdate(@DateTime) = 1
	begin
		set @NewDateTime = cast(@DateTime as varchar(20))
	end

return @NewDateTime
-- comment: sp_password
end

go


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

--------Function Format Money--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'FormatMoney')
	drop function FormatMoney
go

create function FormatMoney(@Money as money) returns money
with encryption as

begin

declare @NewMoney money
set @NewMoney = round(@Money, 2)

return @NewMoney
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.FormatMoney('99909987888800.69878')
----------------------------------------------------------------------------------------------------------------------------

--------Function FormatNumber--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'FormatNumber')
	drop function FormatNumber
go

create function FormatNumber(@Text as varchar(200), @Number as tinyint) returns varchar(200)
with encryption as

begin

declare @NewText varchar(200)
if (isnumeric(@Text) = 1)
	begin
		if (@Number = 0)
			begin set @NewText = cast(@Text as decimal(10, 0)) end
		else if (@Number = 1)
			begin set @NewText = cast(@Text as decimal(10, 1)) end
		else if (@Number = 2)
			begin set @NewText = cast(@Text as decimal(10, 2)) end
		else if (@Number = 3)
			begin set @NewText = cast(@Text as decimal(10, 3)) end
		else if (@Number = 4)
			begin set @NewText = cast(@Text as decimal(10, 4)) end
		else begin set @NewText = cast(@Text as decimal(10, 2)) end
	end
else begin set @NewText = @Text end

return @NewText
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.FormatNumber('8858.69878', 0)
-- print dbo.FormatNumber('788858.64878', 1)
-- print dbo.FormatNumber('788858.69278', 2)
-- print dbo.FormatNumber('788858.69878', 3)
-- print dbo.FormatNumber('8858.69878', 4)
-- print dbo.FormatNumber('788858.69878', 5)
----------------------------------------------------------------------------------------------------------------------------

--------Function Pad Left--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'PadLeft')
	drop function PadLeft
go

create function PadLeft(@ID as int, @PaddingLEN as int) returns varchar(20)
with encryption as

begin

declare @PaddingCHAR as char(1)
declare @Digits as int
declare @Count as int
declare @PaddedText as varchar(20) 

set @PaddingCHAR = '0'
set @Digits = len(@ID)
set @Count = @PaddingLEN - @Digits
set @PaddedText = ''
-- print replicate('0', 5)
if @Count > 0 
	while @Count > 0
		begin
			set @PaddedText = @PaddedText + @PaddingCHAR
			set @Count = @Count - 1
		end

set @PaddedText = @PaddedText + cast(@ID as varchar) 
return @PaddedText
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.PadLeft(61, 3) 
----------------------------------------------------------------------------------------------------------------------------

--------Function Format Text-------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'FormatText')
	drop function FormatText
go

create function FormatText(@Text as varchar(20), @ObjectName as varchar(40), @AutoColumnName varchar(60)) returns varchar(40)
with encryption as

begin
	declare @SplitCHAR char(1) 
	declare @AutoColumnLEN tinyint
	declare @SeparatorPositions varchar(20)
	declare @SeparatorCHAR char(1)
	declare @Index tinyint
	declare @Position tinyint
	declare @NewText as varchar(40)

	set @SplitCHAR = ','

	set @AutoColumnLEN = (select AutoColumnLEN from AutoNumbers
			      where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	set @SeparatorPositions = (select SeparatorPositions from AutoNumbers
				   where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	set @SeparatorCHAR = (select SeparatorCHAR from AutoNumbers
			      where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	set @NewText = @Text

	if len(@NewText) = @AutoColumnLEN

	begin
	
	set @Index = charindex(@SplitCHAR, @SeparatorPositions, 0)
	set @Position = ltrim(rtrim(substring(@SeparatorPositions, 0, @Index)))
	set @SeparatorPositions = ltrim(rtrim(substring(@SeparatorPositions, @Index + 1 , len(@SeparatorPositions))))
	
	if isnumeric(@Position) = 1
	begin
		if (@Position > 0) and @Position < len(@NewText)
		begin
			set @NewText = stuff(@NewText, @Position + 1, 0, @SeparatorCHAR)
		end	
	end
	
	while @Index > 0

	begin
		set @Index = charindex(@SplitCHAR, @SeparatorPositions, 0)
		set @Position = ltrim(rtrim(substring(@SeparatorPositions, 0, @Index)))
		set @SeparatorPositions = ltrim(rtrim(substring(@SeparatorPositions, @Index + 1 , len(@SeparatorPositions))))
	
		if isnumeric(@Position) = 1
		begin
			if @Position > 0 and @Position < len(@NewText)
			begin set @NewText = stuff(@NewText, @Position + 1, 0, @SeparatorCHAR) end		
		end	
	end
	
	if isnumeric(@SeparatorPositions) = 1
	begin
		set @Position = @SeparatorPositions
		if @Position > 0 and @Position < len(@NewText)
		begin set @NewText = stuff(@NewText, @Position + 1, 0, @SeparatorCHAR) end
	end
		else begin set @NewText = @Text end
	end
	
	return @NewText
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.FormatText('hello there', 'Payments', 'ReceiptNo')
--  select * from AutoNumbers
----------------------------------------------------------------------------------------------------------------------------

--------Function Get Next AutoNumber----------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetNextAutoNumber')
	drop function GetNextAutoNumber
go

create function GetNextAutoNumber(@ObjectName as varchar(40), @AutoColumnName varchar(60), @ID int) returns int
with encryption as

begin
	declare @NewID int
	declare @SeparatorPositions varchar(20)
	declare @StartValue int
	declare @Increment smallint
	declare @AllowJumpTo bit
	declare @JumpToValue int

	set @SeparatorPositions = (select SeparatorPositions from AutoNumbers
				   where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	set @StartValue = (select StartValue from AutoNumbers
			   where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	set @Increment = (select Increment from AutoNumbers
			  where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	set @AllowJumpTo = (select AllowJumpTo from AutoNumbers
			  where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	set @JumpToValue = (select JumpToValue from AutoNumbers
			  where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)

	if (@AllowJumpTo = 1) and (@JumpToValue > @ID) and (@JumpToValue > @StartValue)
	begin set @NewID = @JumpToValue + @Increment end
	else begin set @NewID = isnull(@ID, @StartValue) + @Increment end
	
return @NewID
-- comment: sp_password
end
go

/*declare @value tinyint
set @value = dbo.GetNextAutoNumber('Payments', 'ReceiptNo', 0)
print cast(@value as varchar)*/

--  select * from AutoNumbers

--------Function GetAuditActionDes----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetAuditActionDes')
	drop function GetAuditActionDes
go

create function GetAuditActionDes(@AuditAction char(1)) returns varchar(10)
with encryption as

begin

declare @AuditActionDes varchar(10)

if @AuditAction = 'U' set @AuditActionDes = 'Update'
else if @AuditAction = 'D' set @AuditActionDes = 'Delete'
else set @AuditActionDes = @AuditAction

return @AuditActionDes
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetAuditActionDes('U')
-- print dbo.GetAuditActionDes('D')
-- print dbo.GetAuditActionDes('I')
----------------------------------------------------------------------------------------------------------------------------

--------Function GetTime --------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetTime')
	drop function GetTime
go

create function GetTime(@FullDate as smalldatetime) returns varchar(8)
with encryption as

begin

declare @Time varchar(8)

declare @Hours varchar(2)
declare @Minutes varchar(2)
declare @Seconds varchar(2)

set @Hours = dbo.PadLeft(datepart(hour, @FullDate), 2)
set @Minutes = dbo.PadLeft(datepart(minute, @FullDate), 2)
set @Seconds = dbo.PadLeft(datepart(second, @FullDate), 2)

set @Time = @Hours + ':' + @Minutes + ':' + @Seconds

return @Time
-- comment: sp_password
end

go

---------------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetTime('Jan 3 1900 23:55:10')
---------------------------------------------------------------------------------------------------------------------------------

--------Function Get ShortDate --------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetShortDate')
	drop function GetShortDate
go

create function GetShortDate(@FullDate as smalldatetime) returns smalldatetime
with encryption as

begin

declare @ShortDate smalldatetime

set @ShortDate = dbo.FormatDate(@FullDate)

return @ShortDate
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetShortDate('2008-02-28 13:18:00')
----------------------------------------------------------------------------------------------------------------------------

--------Function Get IsDataIDIn -----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetIsDataIDIn')
	drop function GetIsDataIDIn
go

create function GetIsDataIDIn(@Text as varchar(200), @ID as varchar(10)) returns bit
with encryption as

begin
	
declare @SplitCHAR char(1)
declare @Index tinyint
declare @DataID as varchar(10)
declare @Found bit

set @SplitCHAR = ','

set @Index = charindex(@SplitCHAR, @Text, 0)

if @Index = 0
begin 
	set @DataID = @Text
	if @DataID = @ID set @Found = 1 else set @Found = 0
end

else
begin

	set @DataID = ltrim(rtrim(substring(@Text, 0, @Index)))
	set @Text = ltrim(rtrim(substring(@Text, @Index + 1 , len(@Text))))

	if @DataID = @ID set @Found = 1 else set @Found = 0

while @Index > 0
	
	begin
		if  @Found = 1 break

		set @Index = charindex(@SplitCHAR, @Text, 0)
		set @DataID = ltrim(rtrim(substring(@Text, 0, @Index)))
		set @Text = ltrim(rtrim(substring(@Text, @Index + 1 , len(@Text))))

		if @DataID = @ID set @Found = 1 else set @Found = 0
				
	end
	if @Index = 0
		begin 
			set @DataID = @Text
			if @DataID = @ID set @Found = 1 else set @Found = 0
		end 

end
	return @Found
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetIsDataIDIn('10C,10F,10S,10R,15F,1A', '10C')
-- print dbo.GetIsDataIDIn('10C,10F,10S,10R,15F,1A', '1B')
-- print dbo.GetIsDataIDIn('10C', '10C')
-- print dbo.GetIsDataIDIn(null, null)
----------------------------------------------------------------------------------------------------------------------------

--------Function Get GetMonthName -----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetMonthName')
	drop function GetMonthName
go

create function GetMonthName(@MonthNumber as tinyint, @ShortName as bit) returns varchar(100)
with encryption as 

begin
	
	declare @MonthName varchar(100)

	if @MonthNumber = 1 and @ShortName = 0 set @MonthName = 'January'
	else if @MonthNumber = 1 and @ShortName = 1 set @MonthName = 'Jan'

	if @MonthNumber = 2 and @ShortName = 0 set @MonthName = 'February'
	else if @MonthNumber = 2 and @ShortName = 1 set @MonthName = 'Feb'

	if @MonthNumber = 3 and @ShortName = 0 set @MonthName = 'March'
	else if @MonthNumber = 3 and @ShortName = 1 set @MonthName = 'Mar'

	if @MonthNumber = 4 and @ShortName = 0 set @MonthName = 'April'
	else if @MonthNumber = 4 and @ShortName = 1 set @MonthName = 'Apr'

	if @MonthNumber = 5 and @ShortName = 0 set @MonthName = 'May'
	else if @MonthNumber = 5 and @ShortName = 1 set @MonthName = 'May'

	if @MonthNumber = 6 and @ShortName = 0 set @MonthName = 'June'
	else if @MonthNumber = 6 and @ShortName = 1 set @MonthName = 'Jun'

	if @MonthNumber = 7 and @ShortName = 0 set @MonthName = 'July'
	else if @MonthNumber = 7 and @ShortName = 1 set @MonthName = 'Jul'

	if @MonthNumber = 8 and @ShortName = 0 set @MonthName = 'August'
	else if @MonthNumber = 8 and @ShortName = 1 set @MonthName = 'Aug'

	if @MonthNumber = 9 and @ShortName = 0 set @MonthName = 'September'
	else if @MonthNumber = 9 and @ShortName = 1 set @MonthName = 'Sep'

	if @MonthNumber = 10 and @ShortName = 0 set @MonthName = 'October'
	else if @MonthNumber = 10 and @ShortName = 1 set @MonthName = 'Oct'

	if @MonthNumber = 11 and @ShortName = 0 set @MonthName = 'November'
	else if @MonthNumber = 11 and @ShortName = 1 set @MonthName = 'Nov'

	if @MonthNumber = 12 and @ShortName = 0 set @MonthName = 'December'
	else if @MonthNumber = 12 and @ShortName = 1 set @MonthName = 'Dec'

	return @MonthName
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetMonthName(1, 0) 
----------------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name ='GetMonthDays')
drop function GetMonthDays
go

create function GetMonthDays (@MonthNumber tinyint, @Year smallint)
returns tinyint with encryption as 
  
begin
	declare @Days tinyint
	if @MonthNumber < 1 or @MonthNumber > 12 or @Year < 1900 or @Year > 30000 
	begin set @Days = 0 end
	else
    	set @Days = case when @MonthNumber in (1, 3, 5, 7, 8, 10, 12) then 31
				when @MonthNumber in (4, 6, 9, 11) then 30
				else case when (@Year % 4 = 0 and @Year % 100 != 0)
				or (@Year % 400 = 0) then 29 else 28 end
    end
  return @Days
-- comment: sp_password
  end
go

-- select dbo.GetMonthDays(10, 2009) MonthDays

--------Function Get GetWeekName -----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetWeekName')
	drop function GetWeekName
go

create function GetWeekName(@WeekNumber as tinyint, @ShortName as bit) returns varchar(100)
with encryption as 

begin
	
	declare @WeekName varchar(100)

	if @WeekNumber = 1 and @ShortName = 0 set @WeekName = 'Monday'
	else if @WeekNumber = 1 and @ShortName = 1 set @WeekName = 'Mon'

	if @WeekNumber = 2 and @ShortName = 0 set @WeekName = 'Tuesday'
	else if @WeekNumber = 2 and @ShortName = 1 set @WeekName = 'Tue'

	if @WeekNumber = 3 and @ShortName = 0 set @WeekName = 'Wednesday'
	else if @WeekNumber = 3 and @ShortName = 1 set @WeekName = 'Wed'

	if @WeekNumber = 4 and @ShortName = 0 set @WeekName = 'Thursday'
	else if @WeekNumber = 4 and @ShortName = 1 set @WeekName = 'Thu'

	if @WeekNumber = 5 and @ShortName = 0 set @WeekName = 'Friday'
	else if @WeekNumber = 5 and @ShortName = 1 set @WeekName = 'Fri'

	if @WeekNumber = 6 and @ShortName = 0 set @WeekName = 'Saturday'
	else if @WeekNumber = 6 and @ShortName = 1 set @WeekName = 'Sat'

	if @WeekNumber = 7 and @ShortName = 0 set @WeekName = 'Sunday'
	else if @WeekNumber = 7 and @ShortName = 1 set @WeekName = 'Sun'

	return @WeekName
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetWeekName(1, 0) 
----------------------------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------------------------------------

--1--------Delete Object ---------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteObject')
	drop proc uspDeleteObject
go

create proc uspDeleteObject(
@ObjectName varchar(40) ,
@Where varchar(200) ,
@ErrorPart varchar(100) = null
)with encryption as   

exec('declare @Records int declare @errorMSG varchar(200)
select  @Records  =  count(*) from ' + @ObjectName + ' where ' + @Where + '
if @Records <= 0 
begin
	set @errorMSG = ''The record ' + @ErrorPart + ', you are trying to delete does not exist in the registered ' + @ObjectName + '.''
	raiserror(@errorMSG,16, 1)	
	return 
end
delete from  ' + @ObjectName + ' where ' + @Where + '')
-- comment: sp_password
go

-- exec uspDeleteObject 'Logins', 'LoginID = ''Admin''', 'Login ID: Admin'

-- select * from Logins


------------------------------------------------------------------------------------------------------
------------- Roles ----------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

--------Insert Access Objects-------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertAccessObjects')
	drop proc uspInsertAccessObjects
go

create proc uspInsertAccessObjects(
@ObjectName varchar(40),
@ObjectCaption varchar(60),
@ObjectType char(1) = 'T' 
)with encryption as   

declare @ErrorMSG varchar(200)

if exists(select ObjectName from AccessObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, @ObjectName)	
		return 1
	end
else

begin
insert into AccessObjects(
ObjectName ,ObjectCaption ,ObjectType
) values(
@ObjectName ,@ObjectCaption ,@ObjectType
)
return 0
-- comment: sp_password
end
go

-- exec uspInsertAccessObjects 'Payments', 'Payments','T'
-- exec uspInsertAccessObjects 'PaymentDetails', 'Payment Details','T'
-- select * from AccessObjects
-- delete from AccessObjects

--------Insert Roles -------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertRoles')
	drop proc uspInsertRoles
go

create proc uspInsertRoles(
@RoleName varchar(40) ,
@RoleDes varchar(100) ,
@InBuilt bit = 0
)with encryption as   

declare @ErrorMSG varchar(200)

if exists(select @RoleName from Roles where RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Role Name: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, @RoleName)	
		return 1
	end
else

begin
insert into Roles
(RoleName ,RoleDes ,InBuilt) 
values
(@RoleName ,@RoleDes ,@InBuilt)
return 0
-- comment: sp_password
end
go


-- exec uspInsertRoles 'Administrator', 'This role has all rights to access the system', 1
-- exec uspInsertRoles 'User', 'This role has basic rights to access the the system', 1
-- select * from Roles
-- delete from Roles

-------Insert Object Roles-------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertObjectRoles')
	drop proc uspInsertObjectRoles
go

create proc uspInsertObjectRoles(
@ObjectName varchar(40),
@RoleName varchar(40),
@Write bit = 0 ,
@Read bit = 0 ,
@Update bit = 0 ,
@Delete bit = 0
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from AccessObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @ObjectName, 'Access Objects')	
		return 1
	end

if not exists(select RoleName from Roles where RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Role Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16,1, @RoleName, 'Roles')	
		return 1
	end

if exists(select ObjectName from ObjectRoles where ObjectName = @ObjectName and RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Object Name: %s and Role Name: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG,16,1, @ObjectName, @RoleName)	
		return 1
	end


else

begin
insert into ObjectRoles(
ObjectName ,RoleName  ,Write ,[Read] ,[Update] ,[Delete] 
) values(
@ObjectName ,@RoleName ,@Write ,@Read ,@Update ,@Delete 
)
return 0
-- comment: sp_password
end
go

-- exec uspInsertObjectRoles 'Payments', 'Administrator', 1, 1, 1, 1
-- exec uspInsertObjectRoles 'Payments', 'User', 0, 0, 0, 0
-- select * from ObjectRoles
-- delete from ObjectRoles 

-------Insert Login Roles------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertLoginRoles')
	drop proc uspInsertLoginRoles
go

create proc uspInsertLoginRoles(
@LoginID varchar(20),
@RoleName varchar(40),
@AssignDate smalldatetime ,
@RoleExpires bit = 0 ,
@ExpiryDate smalldatetime 
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select LoginID from Logins where LoginID = @LoginID)
	begin
		set @ErrorMSG = 'The Login ID: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @LoginID, 'Logins')	
		return 1
	end

if not exists(select RoleName from Roles where RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Role Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16,1, @RoleName, 'Roles')	
		return 1
	end

if exists(select LoginID from LoginRoles where LoginID = @LoginID and RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Login ID: %s and Role Name: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG,16,1, @LoginID, @RoleName)	
		return 1
	end


else

begin
insert into LoginRoles
(LoginID ,RoleName ,AssignDate ,RoleExpires ,ExpiryDate ) 
values
(@LoginID ,@RoleName ,@AssignDate ,@RoleExpires ,@ExpiryDate )

return 0
-- comment: sp_password
end
go

-- exec uspInsertLoginRoles 'Admin', 'Administrator', '31 May 2006', 0, '1 Jan 1900'
-- select * from LoginRoles
-- delete from LoginRoles
-- select * from Logins

--------Get AccessObjects----------------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetAccessObjects')
	drop proc uspGetAccessObjects
go

create proc uspGetAccessObjects(
@ObjectName varchar(40) = null output
)with encryption as  

declare @ErrorMSG varchar(200)

if not (@ObjectName is null)
begin
	if not exists(select ObjectName from AccessObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: %s, you''re trying to enter does not exists in the registered %s'
			raiserror(@ErrorMSG,16,1,@ObjectName, 'Access Objects')	
			return 1
	end
	begin
		select ObjectName, ObjectCaption, 
		case ObjectType
		when 'T' then 'Table'
		when 'V' then 'View'
		when 'R' then 'Report'
		when 'F' then 'Form'
		when 'D' then 'Data File'
		when 'O' then 'Others'
		else 'Other'
		end as ObjectType from AccessObjects
		where ObjectName = @ObjectName
	
	end
end
else
if  (@ObjectName is null)

begin
	select ObjectName, ObjectCaption, 
	case ObjectType
	when 'T' then 'Table'
	when 'V' then 'View'
	when 'R' then 'Report'
	when 'F' then 'Form'
	when 'D' then 'Data File'
	when 'O' then 'Others'
	else 'Other'
	end as ObjectType from AccessObjects
end

--------------------------------------------------------------------------------------------------------------------------------

return 0
-- comment: sp_password
go
-- select * from AccessObjects
-- exec uspGetAccessObjects 'ItemRates'
-- exec uspGetAccessObjects null


--1------ Get Roles---------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetRoles')
	drop proc uspGetRoles
go

create proc uspGetRoles(
@RoleName varchar(40) = null output
)with encryption as

if not (@RoleName is null)
begin
	Select RoleName, RoleDes, InBuilt from Roles 
	where RoleName = @RoleName
end
else
if (@RoleName is null)
begin
	Select RoleName, RoleDes, InBuilt from Roles
end

return 0
-- comment: sp_password
go

-- exec uspGetRoles
-- select * from Roles

--1------ Delete Roles----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteRoles')
	drop proc uspDeleteRoles
go

create proc uspDeleteRoles(
@RoleName varchar(40)
)with encryption as   

declare @ErrorMSG varchar(200)
declare @InBuilt bit

if not exists(select RoleName from Roles where RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Role Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @RoleName, 'Roles')	
		return 1
	end

set @InBuilt = (select InBuilt from Roles where RoleName = @RoleName)

if @InBuilt = 1
begin
	set @ErrorMSG = '%s is an in built role. You can''t deleted this role!'
	raiserror(@ErrorMSG,16, 1, @RoleName)	
	return 1
end

delete Roles where (RoleName = @RoleName)

return 0
-- comment: sp_password
go

-- exec uspDeleteRoles 'Administrator'
-- select * from Roles

--1------ Get ObjectRoles---------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetObjectRoles')
	drop proc uspGetObjectRoles
go

create proc uspGetObjectRoles(
@RoleName varchar(40) = null ,
@LoginID varchar(20) = null 
)with encryption as

if not (@RoleName is null) and (@LoginID is null)
begin
	select ObjectRoles.ObjectName, ObjectCaption, 
		case ObjectType
		when 'T' then 'Table'
		when 'V' then 'View'
		when 'R' then 'Report'
		when 'F' then 'Form'
		when 'D' then 'Data File'
		when 'O' then 'Others'
		else 'Other'
		end as ObjectType, RoleName, Write, [Read], [Update], [Delete] 
	from ObjectRoles
	inner join AccessObjects on ObjectRoles.ObjectName=AccessObjects.ObjectName
	where RoleName = @RoleName

	return 0
end
else

if (@RoleName is null) and not (@LoginID is null)
begin
	select ObjectRoles.ObjectName, ObjectCaption, 
		case ObjectType
		when 'T' then 'Table'
		when 'V' then 'View'
		when 'R' then 'Report'
		when 'F' then 'Form'
		when 'D' then 'Data File'
		when 'O' then 'Others'
		else 'Other'
		end as ObjectType, RoleName, Write, [Read], [Update], [Delete] 
	from ObjectRoles
	inner join AccessObjects on ObjectRoles.ObjectName=AccessObjects.ObjectName
	where RoleName in(select RoleName from LoginRoles where LoginID = @LoginID)

end
-- comment: sp_password
go

-- exec uspGetObjectRoles 'Administrator', null
-- exec uspGetObjectRoles null, 'Admin'
-- exec uspGetObjectRoles null, 'user'
-- select * from ObjectRoles
-- select * from AccessObjects
-- select * from LoginRoles

--1------ Get LoginRoles---------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetLoginRoles')
	drop proc uspGetLoginRoles
go

create proc uspGetLoginRoles(
@LoginID varchar(20) ,
@RoleName varchar(40) = null
)with encryption as

if (@RoleName is null)
begin
	select LoginID, LoginRoles.RoleName, RoleDes, cast(AssignDate as varchar(12)) as AssignDate, 
	RoleExpires, cast(ExpiryDate as varchar(12)) as ExpiryDate from LoginRoles
	inner join Roles on LoginRoles.RoleName=Roles.RoleName
	where LoginID = @LoginID

	return 0
end

else
if not (@RoleName is null)
begin
	select LoginID, LoginRoles.RoleName, RoleDes, cast(AssignDate as varchar(12)) as AssignDate, 
	RoleExpires, cast(ExpiryDate as varchar(12)) as ExpiryDate from LoginRoles
	inner join Roles on LoginRoles.RoleName=Roles.RoleName
	where LoginID = @LoginID and LoginRoles.RoleName = @RoleName

	return 0
end

return 0
-- comment: sp_password
go

-- exec uspGetLoginRoles 'Admin'
-- exec uspGetLoginRoles 'User'
-- exec uspGetLoginRoles 'Admin' , 'Administrator'
-- exec uspGetLoginRoles 'User', 'Cashier'
-- select * from LoginRoles
-- select * from Roles

--1------ Delete ObjectRoles----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteObjectRoles')
	drop proc uspDeleteObjectRoles
go

create proc uspDeleteObjectRoles(
@ObjectName varchar(40),
@RoleName varchar(40) 
)with encryption as   

declare @ErrorMSG varchar(200)
declare @InBuilt bit

if not exists(select RoleName from ObjectRoles where ObjectName = @ObjectName and RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Object Name: %s and Role Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @ObjectName, @RoleName, 'Object Roles')	
		return 1
	end

set @InBuilt = (select InBuilt from Roles where RoleName = @RoleName)

if @InBuilt = 1
begin
	set @ErrorMSG = '%s is an in built role. You can''t deleted this object role!'
	raiserror(@ErrorMSG,16, 1, @RoleName)	
	return 1
end

delete ObjectRoles where (ObjectName = @ObjectName and RoleName = @RoleName)

return 0
-- comment: sp_password
go

-- exec uspDeleteObjectRoles 'TaxRegisterDetails', 'Ward Agent'
-- select * from ObjectRoles
-- select * from ObjectRoles where RoleName = 'Ward Agent'

--1------ Delete LoginRoles----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteLoginRoles')
	drop proc uspDeleteLoginRoles
go

create proc uspDeleteLoginRoles(
@LoginID varchar(20),
@RoleName varchar(40) 
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select RoleName from LoginRoles where LoginID = @LoginID and RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Login ID: %s and Role Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @LoginID, @RoleName, 'Login Roles')	
		return 1
	end

delete LoginRoles where (LoginID = @LoginID and RoleName = @RoleName)

return 0
-- comment: sp_password
go

-- exec uspDeleteLoginRoles 'Admin', 'Setup'
-- select * from LoginRoles
-- select * from LoginRoles where RoleName = 'Ward Agent'

--------Update Roles -------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateRoles')
	drop proc uspUpdateRoles
go

create proc uspUpdateRoles(
@RoleName varchar(40) ,
@RoleDes varchar(100)
)with encryption as   

declare @ErrorMSG varchar(200)
declare @InBuilt bit

if not exists(select @RoleName from Roles where RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Role Name: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, @RoleName, 'Roles')	
		return 1
	end
else

set @InBuilt = (select InBuilt from Roles where RoleName = @RoleName)

if @InBuilt = 1
begin
	set @ErrorMSG = '%s is an in built role. You can''t deleted this object role!'
	raiserror(@ErrorMSG,16, 1, @RoleName)	
	return 1
end

begin
update Roles
set RoleDes = @RoleDes where RoleName = @RoleName

return 0
-- comment: sp_password
end
go

-- exec uspUpdateRoles 'Administrator', 'This role has all rights to access the system'
-- exec uspUpdateRoles 'User', 'This role has basic rights to access the system'
-- exec uspUpdateRoles 'Ward Agent', 'This role has rights to access the tax register'
-- select * from Roles
-- delete from Roles

-------Update Object Roles-------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateObjectRoles')
	drop proc uspUpdateObjectRoles
go

create proc uspUpdateObjectRoles(
@ObjectName varchar(40),
@RoleName varchar(40),
@Write bit = 0 ,
@Read bit = 0 ,
@Update bit = 0 ,
@Delete bit = 0
)with encryption as   

declare @ErrorMSG varchar(200)
declare @InBuilt bit

if not exists(select ObjectName from AccessObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @ObjectName, 'Access Objects')	
		return 1
	end

if not exists(select RoleName from Roles where RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Role Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16,1, @RoleName, 'Roles')	
		return 1
	end

set @InBuilt = (select InBuilt from Roles where RoleName = @RoleName)

if @InBuilt = 1
begin
	set @ErrorMSG = '%s is an in built role. You can''t deleted this object role!'
	raiserror(@ErrorMSG,16, 1, @RoleName)	
	return 1
end

if not  exists(select ObjectName from ObjectRoles where ObjectName = @ObjectName and RoleName = @RoleName)
	begin
		insert into ObjectRoles(ObjectName, RoleName, Write, [Read], [Update], [Delete]) 
		values(@ObjectName, @RoleName, @Write, @Read, @Update, @Delete)

		return 0
	end
else

begin
update ObjectRoles
set Write = @Write, [Read] = @Read, [Update] = @Update, [Delete] = @Delete
where ObjectName = @ObjectName and RoleName = @RoleName

return 0
-- comment: sp_password
end
go

-- exec uspUpdateObjectRoles 'Payments', 'Administrator', 1, 1, 1, 1
-- exec uspUpdateObjectRoles 'Payments', 'User', 0, 0, 0, 0
-- exec uspUpdateObjectRoles 'TaxRegisterDetails', 'Ward Agent', 1, 1, 1, 1
-- exec uspUpdateObjectRoles 'Payments', 'Ward Agent', 1, 1, 1, 1
-- select * from ObjectRoles
-- delete from ObjectRoles 


-------Update LoginRoles-------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateLoginRoles')
	drop proc uspUpdateLoginRoles
go

create proc uspUpdateLoginRoles(
@LoginID varchar(20),
@RoleName varchar(40),
@AssignDate smalldatetime ,
@RoleExpires bit = 0 ,
@ExpiryDate smalldatetime
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select LoginID from Logins where LoginID = @LoginID)
	begin
		set @ErrorMSG = 'The Login ID: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @LoginID, 'Logins')	
		return 1
	end

if not exists(select RoleName from Roles where RoleName = @RoleName)
	begin
		set @ErrorMSG = 'The Role Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16,1, @RoleName, 'Roles')	
		return 1
	end

if not exists(select LoginID from LoginRoles where LoginID = @LoginID and RoleName = @RoleName)
	begin
		insert into LoginRoles(LoginID, RoleName, AssignDate, RoleExpires, ExpiryDate) 
		values(@LoginID, @RoleName, @AssignDate, @RoleExpires, @ExpiryDate)
		return 0
	end
else

begin
update LoginRoles
set 
LoginID = @LoginID, RoleName = @RoleName, AssignDate = @AssignDate,
RoleExpires = @RoleExpires, ExpiryDate = @ExpiryDate 
where LoginID = @LoginID and RoleName = @RoleName

return 0
-- comment: sp_password
end
go

-- exec uspUpdateLoginRoles  'Admin', 'Administrator', '31 May 2006', 0, '1 Jan 1900'
-- exec uspUpdateLoginRoles  'User', 'Administrator', '31 May 2006', 0, '1 Jan 1900'
-- exec uspUpdateLoginRoles  'User', 'Cashier', '31 May 2006', 1, '1 Jan 2009'
-- exec uspUpdateLoginRoles  'Admin', 'Administrator', '31 May 2006', 0, '1 Jan 1900'
-- select * from LoginRoles
-- delete from LoginRoles 

--------Function GetAssignedLoginRole------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetAssignedLoginRole')
	drop function GetAssignedLoginRole
go

create function GetAssignedLoginRole(@LoginID varchar(20)) returns varchar(200)
with encryption as
begin

declare @RoleName varchar(40)
declare @AssignedLoginRole varchar(200)
set @AssignedLoginRole = ''

begin
	
	DECLARE Role_Cursor CURSOR FOR

	select RoleName from LoginRoles where LoginID = @LoginID

	OPEN Role_Cursor
	FETCH NEXT FROM Role_Cursor INTO @RoleName
	WHILE (@@FETCH_STATUS <> -1)
		BEGIN
				SET @AssignedLoginRole = @AssignedLoginRole + @RoleName + ', '
				FETCH NEXT FROM Role_Cursor INTO @RoleName
		END

	CLOSE Role_Cursor
	DEALLOCATE Role_Cursor

	if len(@AssignedLoginRole) > 0 set @AssignedLoginRole = left(@AssignedLoginRole, len(@AssignedLoginRole)-1)
end

return @AssignedLoginRole

end

go

----------------------------------------------------------------------------------------------------------------
-- print dbo.GetAssignedLoginRole('Admin')
----------------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------------------------
------------- Search -------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------

--------Insert Search Objects-----------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertSearchObjects')
	drop proc uspInsertSearchObjects
go

create proc uspInsertSearchObjects(
@ObjectName varchar(40),
@SP_Name varchar(60),
@JoinsText varchar(1000) = null,
@IsGrouped bit = 0,
@HasDefault bit = 0,
@TopValue smallint = 1000,
@OrderColumns varchar(1000) = null,
@IsDistinct bit = 0
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from AccessObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @ObjectName, 'Access Objects')	
		return 1
	end

if exists(select ObjectName from SearchObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG,16,1, @ObjectName )	
		return 1
	end

if not @SP_Name Like 'uspSearch%'
	begin
		set @ErrorMSG = 'The SP_Name must begin with ''uspSearch'' for name'
		raiserror(@ErrorMSG,16,1)	
		return 1
	end

else

begin
insert into SearchObjects
(ObjectName, SP_Name, JoinsText, IsGrouped, HasDefault, TopValue, OrderColumns, IsDistinct) 
values
(@ObjectName ,@SP_Name, @JoinsText, @IsGrouped, @HasDefault, @TopValue, @OrderColumns, @IsDistinct)
return 0
-- comment: sp_password
end
go


/********************************************************************************************
exec uspInsertSearchObjects 'Payments', 'uspSearchPayments', 
			'inner join Visits on Payments.VisitNo = Visits.VisitNo
			inner join PaymentDetails on Payments.ReceiptNo = PaymentDetails.ReceiptNo', 1, 1,
			500, 'PaymentDetails.ReceiptNo, Payments.VisitNo', 1

exec uspInsertSearchObjects 'PaymentDetails', 'uspSearchPaymentDetails'

*********************************************************************************************/
	
-- select * from SearchObjects
-- delete from SearchObjects

-------------- Update SearchObjects -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateSearchObjects')
	drop proc uspUpdateSearchObjects
go

create proc uspUpdateSearchObjects(
@ObjectName varchar(40),
@SearhInclude bit
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from SearchObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Search Objects')
		return 1
	end
begin
update SearchObjects set SearhInclude = @SearhInclude
where ObjectName = @ObjectName
return 0
end
go

/******************************************************************************************************
exec uspUpdateSearchObjects 'AccessedServices', 1

******************************************************************************************************/
-- select * from SearchObjects
-- delete from SearchObjects

--1------ GetSearchObjects ----------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSearchObjects')
	drop proc uspGetSearchObjects
go

create proc uspGetSearchObjects(
@SearhInclude as bit = null,
@ObjectName varchar(40) = null
)with encryption as
	
	if (@SearhInclude is null and @ObjectName is null)
		begin
			select SearchObjects.ObjectName, ObjectCaption, SP_Name, JoinsText, IsGrouped, 
			HasDefault, TopValue, OrderColumns, IsDistinct, SearhInclude from SearchObjects 
			inner join AccessObjects on SearchObjects.ObjectName=AccessObjects.ObjectName
			order by SearchObjects.SortOrder, SearchObjects.ObjectName
		end
	else if (not @SearhInclude is null and @ObjectName is null)
		begin
			select SearchObjects.ObjectName, ObjectCaption, SP_Name, JoinsText, IsGrouped, 
			HasDefault, TopValue, OrderColumns, IsDistinct, SearhInclude from SearchObjects 
			inner join AccessObjects on SearchObjects.ObjectName=AccessObjects.ObjectName
			where SearhInclude = @SearhInclude
			order by SearchObjects.SortOrder, SearchObjects.ObjectName
		end
	else if (@SearhInclude is null and not @ObjectName is null)
		begin
			select SearchObjects.ObjectName, ObjectCaption, SP_Name, JoinsText, IsGrouped, 
			HasDefault, TopValue, OrderColumns, IsDistinct, SearhInclude from SearchObjects 
			inner join AccessObjects on SearchObjects.ObjectName=AccessObjects.ObjectName
			where SearchObjects.ObjectName = @ObjectName
			order by SearchObjects.SortOrder, SearchObjects.ObjectName
		end
	else if (not @SearhInclude is null and not @ObjectName is null)
		begin
			select SearchObjects.ObjectName, ObjectCaption, SP_Name, JoinsText, IsGrouped, 
			HasDefault, TopValue, OrderColumns, IsDistinct, SearhInclude from SearchObjects 
			inner join AccessObjects on SearchObjects.ObjectName=AccessObjects.ObjectName
			where SearhInclude = @SearhInclude and SearchObjects.ObjectName = @ObjectName
			order by SearchObjects.SortOrder, SearchObjects.ObjectName
		end
return 0
-- comment: sp_password
go

-- exec uspGetSearchObjects
-- exec uspGetSearchObjects 1, 'Logins'
-- exec uspGetSearchObjects 0, 'Logins'

--------- Update SearchObjects Trigger -------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateSearchObjects')
	drop trigger utrUpdateSearchObjects
go

create trigger utrUpdateSearchObjects
on SearchObjects
for update
as
declare @ErrorMSG varchar(100)

if @@rowcount = 0 return 

if update(SP_Name)
Begin
	set @ErrorMSG = 'You can''t update SP_Name for Search Objects, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(JoinsText)
Begin
	set @ErrorMSG = 'You can''t update JoinsText for Search Objects, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(IsGrouped)
Begin
	set @ErrorMSG = 'You can''t update IsGrouped for Search Objects, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(HasDefault)
Begin
	set @ErrorMSG = 'You can''t update HasDefault for Search Objects, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(TopValue)
Begin
	set @ErrorMSG = 'You can''t update TopValue for Search Objects, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(OrderColumns)
Begin
	set @ErrorMSG = 'You can''t update OrderColumns for Search Objects, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(IsDistinct)
Begin
	set @ErrorMSG = 'You can''t update IsDistinct for Search Objects, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
-- comment: sp_password
end
go

-------Insert SearchColumns---------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertSearchColumns')
	drop proc uspInsertSearchColumns
go

create proc uspInsertSearchColumns(
@ObjectName varchar(40),
@ColumnName varchar(200),
@ColumnCaption varchar(200),
@IncludeInitially bit,
@Searchable bit,
@IsAggregate bit = 0,
@SearchCriterionID varchar(10) = '',
@SearchDataTypeID varchar(10) = '',
@MaxLength tinyint = 0,
@IsPrimaryKey bit = 0,
@SearchCriterionLocked bit = 0,
@InColumns bit = 1
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from SearchObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: ' + @ObjectName + ', you are trying to enter does not exists in the registered Search Objects'
		raiserror(@ErrorMSG,16,1)	
		return 1
	end

if exists(select ColumnName from SearchColumns where ColumnName = @ColumnName and ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Column Name: ' + @ColumnName + ' and Object Name: ' + @ObjectName + ', you are trying to enter already exists'
		raiserror(@ErrorMSG,16,1)	
		return 1
	end

if @Searchable = 1
	begin
		if exists(select ColumnCaption from SearchColumns where ColumnCaption = @ColumnCaption and ObjectName = @ObjectName and Searchable = 1)
			begin
				set @ErrorMSG = 'The Column Caption: ' + @ColumnCaption + ' and Object Name: ' + @ObjectName + ', you are trying to enter already exists'
				raiserror(@ErrorMSG,16,1)	
				return 1
			end

		if not exists(select DataID from LookupData where DataID = @SearchCriterionID)
			begin
				set @ErrorMSG = 'The Search Criterion ID: ' + @SearchCriterionID + ', you are trying to enter does not exists in the registered Lookup Data'
				raiserror(@ErrorMSG,16,1)	
				return 1
			end

		if not exists(select DataID from LookupData where DataID = @SearchDataTypeID)
			begin
				set @ErrorMSG = 'The Search Data Type ID: ' + @SearchDataTypeID + ', you are trying to enter does not exists in the registered Lookup Data'
				raiserror(@ErrorMSG,16,1)	
				return 1
			end
	end

begin
begin tran
	insert into SearchColumns
	(ObjectName, ColumnName, ColumnCaption, IncludeInitially, Searchable, IsAggregate) 
	values
	(@ObjectName, @ColumnName, @ColumnCaption, @IncludeInitially, @Searchable, @IsAggregate)

if @Searchable = 1
begin
	insert into SearchColumnsEXT
	(ObjectName, ColumnName , SearchCriterionID , SearchDataTypeID ,
	MaxLength , IsPrimaryKey, SearchCriterionLocked, InColumns) 
	values
	(@ObjectName, @ColumnName , @SearchCriterionID , @SearchDataTypeID ,
	@MaxLength , @IsPrimaryKey , @SearchCriterionLocked, @InColumns)
end

if @@error > 0
	begin
		rollback tran
		return 1		
	end
commit tran

return 0
-- comment: sp_password
end
go

/* exec uspInsertSearchColumns 'Payments', 'ReceiptNo', 'Receipt Number', 1, 1, 0,
				'2LIK', '3NUM',5, 1,0

exec uspInsertSearchColumns 'PaymentDetails', 'ReceiptNo', 'Receipt Number', 1, 1, 0,
				'2LIK', '3NUM',5, 1,0

exec uspInsertSearchColumns 'Payments', 'PayDate', 'Pay Date', 1, 1, 0,'2BTN', '3DTE', 0, 0, 0, 0

exec uspInsertSearchColumns 'Payments', 'VisitNo', 'Visit Number', 1, 0
*/

-- select * from SearchColumns
-- delete from SearchColumns

-- select * from SearchColumnsEXT
-- delete from SearchColumnsEXT

------------Get Search Columns --------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSearchColumns')
	drop proc uspGetSearchColumns
go

create proc uspGetSearchColumns(
@ObjectName as varchar(40)
)with encryption as  

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from SearchObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: ' + @ObjectName + ', you are trying to enter does not exists in the registered Search Objects'
		raiserror(@ErrorMSG,16,1)	
		return 1
	end

else

begin

	select SearchColumns.ObjectName, SearchColumns.ColumnName, ColumnCaption, IncludeInitially, 
	Searchable, IsAggregate, isnull(InColumns, 1) as InColumns 
	from SearchColumns
	left outer join SearchColumnsEXT on SearchColumnsEXT.ColumnName = SearchColumns.ColumnName
	and SearchColumnsEXT.ObjectName = SearchColumns.ObjectName
	where SearchColumns.ObjectName = @ObjectName and isnull(InColumns, 1) = 1
	order by SortOrder, ColumnCaption

return 0
-- comment: sp_password
end

go

-- select * from SearchColumns order by SortOrder
-- exec uspGetSearchColumns 'Payments'
-- exec uspGetSearchColumns 'Logins'

--------- Update SearchColumns Trigger -------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateSearchColumns')
	drop trigger utrUpdateSearchColumns
go

create trigger utrUpdateSearchColumns
on SearchColumns
for update
as
declare @ErrorMSG varchar(100)

if @@rowcount = 0 return 

if update(Searchable)
Begin
	set @ErrorMSG = 'You can''t update Searchable for Search Columns, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
-- comment: sp_password
end

go

------------Get Search Columns EXT-----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSearchColumnsEXT')
	drop proc uspGetSearchColumnsEXT
go

create proc uspGetSearchColumnsEXT(
@ObjectName as varchar(40)
)with encryption as  

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from SearchObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: ' + @ObjectName + ', you are trying to enter does not exists in the registered Search Objects'
		raiserror(@ErrorMSG,16,1)	
		return 1
	end

else

begin

select SearchColumnsEXT.ColumnName as ColumnName, SearchColumnsEXT.ObjectName as ObjectName, ColumnCaption, 
	SearchCriterionID, SearchDataTypeID, MaxLength, SearchCriterion.DataDes as SearchCriterion, 
	SearchDataType.DataDes as SearchDataType, IsPrimaryKey, SearchCriterionLocked 
	from SearchColumnsEXT
	inner join SearchColumns on SearchColumns.ObjectName = SearchColumnsEXT.ObjectName
							and SearchColumns.ColumnName = SearchColumnsEXT.ColumnName
	inner join LookupData SearchCriterion on SearchColumnsEXT.SearchCriterionID = SearchCriterion.DataID
	inner join LookupData SearchDataType on SearchColumnsEXT.SearchDataTypeID = SearchDataType.DataID
	where SearchColumnsEXT.ObjectName = @ObjectName
	order by SortOrder, ColumnCaption
return 0
-- comment: sp_password
end

go

-- exec uspGetSearchColumnsEXT 'Payments'
-- exec uspGetSearchColumnsEXT 'Logins'

---------Trigger Delete Search Columns EXT  ---------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrDeleteSearchColumnsEXT')
	drop trigger utrDeleteSearchColumnsEXT
go

create trigger utrDeleteSearchColumnsEXT 
on SearchColumnsEXT
for  delete
as

declare @ErrorMSG varchar(100)

if @@rowcount = 0 return 

if exists (select ObjectName from SearchColumns 
		where (ObjectName in (select ObjectName from Deleted) and ColumnName in (select ColumnName from Deleted)))
	Begin
		set @ErrorMSG = 'Can''t delete record with corresponding entries in Search Columns'
		raiserror(@ErrorMSG,16,10)
		rollback tran
		return
		-- comment: sp_password
	end
go

------------------------------------------------------------------------------------------------------
-------------- SearchQueries -------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Insert SearchQueries ------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertSearchQueries')
	drop proc uspInsertSearchQueries
go

create proc uspInsertSearchQueries(
@QueryName varchar(40),
@ObjectName varchar(40),
@QueryData xml,
@Notes varchar(200),
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)

if exists(select QueryName from SearchQueries where QueryName = @QueryName)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Query Name', @QueryName)
		return 1
	end

if not exists(select ObjectName from AccessObjects where ObjectName  = @ObjectName)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Access Objects')
		return 1
	end

if not exists(select LoginID from Logins where LoginID  = @LoginID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID, 'Logins')
		return 1
	end

begin
insert into SearchQueries
(QueryName, ObjectName, QueryData, Notes, LoginID, ClientMachine)
values
(@QueryName, @ObjectName, @QueryData, @Notes, @LoginID, @ClientMachine)
return 0
end
go

/******************************************************************************************************

exec uspInsertSearchQueries 'Weekly New Patients', 'Patients', '<Patients>
		<Criterion Position = ''0''>Age = ''16''</Criterion> 
		<Criterion Position = ''1''>Gender = ''Female''</Criterion>
		<Criterion Position = ''2''>JoinDate Between ''1 Jan 2015'' and ''31 Mar 2015''</Criterion>
		</Patients>', 'New Patients in the Week', 'Admin', 'CEO'

exec uspInsertSearchQueries 'Active Patients', 'Patients', '<Patients>
		<Criterion Position = ''0''>Status = ''Active''</Criterion> 
		<Criterion Position = ''1''>JoinDate Between ''1 Jan 2015'' and ''31 Mar 2015''</Criterion>
  </Patients>', 'Active Patients', 'Admin', 'CEO'
  
exec uspInsertSearchQueries 'Weekly Visits', 'Visits', '<Visits>
		<Criterion Position = ''0''>Age = ''16''</Criterion> 
		<Criterion Position = ''1''>Gender = ''Female''</Criterion>
		<Criterion Position = ''2''>VisitDate Between ''1 Jan 2015'' and ''31 Mar 2015''</Criterion>
		</Visits>', 'Visits of the Week', 'Admin', 'CEO'

******************************************************************************************************/
-- select * from SearchQueries
-- delete from SearchQueries

-------------- Get SearchQueries --------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSearchQueries')
	drop proc uspGetSearchQueries
go

create proc uspGetSearchQueries(
@ObjectName varchar(40),
@LoginID varchar(20) = null
)with encryption as

declare @ErrorMSG varchar(200)

if (@LoginID is null or @LoginID = '')
	begin
		select QueryName, ObjectName, QueryData, Notes, LoginID,
		dbo.FormatDate(RecordDateTime) as RecordDate, dbo.GetTime(RecordDateTime) as RecordTime
		from SearchQueries
		where ObjectName = @ObjectName
	end
else 
	begin
		select QueryName, ObjectName, QueryData, Notes, LoginID,
		dbo.FormatDate(RecordDateTime) as RecordDate, dbo.GetTime(RecordDateTime) as RecordTime
		from SearchQueries
		where ObjectName = @ObjectName and LoginID = @LoginID 
	end

return 0
go

/******************************************************************************************************
exec uspGetSearchQueries 'Patients'
exec uspGetSearchQueries 'Patients', 'Admin'

******************************************************************************************************/
-- select * from SearchQueries
-- delete from SearchQueries

------------------------------------------------------------------------------------------------------
-------------- Update: SearchQueries -----------------------------------------------------------------
------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateSearchQueries')
	drop trigger utrUpdateSearchQueries
go

create trigger utrUpdateSearchQueries
on SearchQueries
for update
as
declare @ErrorMSG varchar(200)
declare @Identity int
declare @ObjectName varchar(40)
declare @FullDate smalldatetime

if @@rowcount = 0 return

----------------------------------------------------------------------------------------------
if update(QueryName)
begin
	set @ErrorMSG = 'You can''t update Query Name for Search Queries, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(ObjectName)
begin
	set @ErrorMSG = 'You can''t update Object Name for Search Queries, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(QueryData)
begin
	set @ErrorMSG = 'You can''t update Query Data for Search Queries, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

------------------- Log Updates ----------------------------------------------

if ident_current('AuditTrail') <>  @@identity return
set @Identity = ident_current('AuditTrail')

if @Identity is null return

set @ObjectName = (select ObjectName from AuditTrail where AuditID = @Identity and AuditAction = 'U')
if @ObjectName is null return
if @ObjectName <> 'SearchQueries' return

set @FullDate = (select FullDate from AuditTrail where AuditID = @Identity)
if @FullDate is null return
if datediff(second, @FullDate, getdate()) > 60 return

------------------- Key-QueryName -----------------------------------------------------

begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'QueryName', Deleted.QueryName, Inserted.QueryName
	from Inserted inner join Deleted
	on Inserted.QueryName = Deleted.QueryName
end

-------------------  Notes  -----------------------------------------------------

if update(Notes)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'Notes', Deleted.Notes, Inserted.Notes
	from Inserted inner join Deleted
	on Inserted.QueryName = Deleted.QueryName
	and Inserted.Notes <> Deleted.Notes
end

-------------------  LoginID  -----------------------------------------------------

if update(LoginID)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'LoginID', Deleted.LoginID, Inserted.LoginID
	from Inserted inner join Deleted
	on Inserted.QueryName = Deleted.QueryName
	and Inserted.LoginID <> Deleted.LoginID
end

-------------------  ClientMachine  -----------------------------------------------------

if update(ClientMachine)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'ClientMachine', Deleted.ClientMachine, Inserted.ClientMachine
	from Inserted inner join Deleted
	on Inserted.QueryName = Deleted.QueryName
	and Inserted.ClientMachine <> Deleted.ClientMachine
end

-------------------  RecordDateTime  -----------------------------------------------------

if update(RecordDateTime)
begin
	insert AuditTrailDetails (AuditID, ColumnName, OriginalValue, NewValue)
	select @Identity, 'RecordDateTime', dbo.FormatDateTime(Deleted.RecordDateTime), dbo.FormatDateTime(Inserted.RecordDateTime)
	from Inserted inner join Deleted
	on Inserted.QueryName = Deleted.QueryName
	and Inserted.RecordDateTime <> Deleted.RecordDateTime
end
go

----------------------------------------------------------------------------------------------------------------
-------------Quick Search --------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------

-------Insert QuickSearchColumns--------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertQuickSearchColumns')
	drop proc uspInsertQuickSearchColumns
go

create proc uspInsertQuickSearchColumns(
@ObjectName varchar(40),
@ColumnName varchar(200),
@ColumnCaption varchar(200),
@ColumnReference varchar(200),
@SearchCriterionID varchar(10),
@Searchable bit
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from SearchObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Search Objects')	
		return 1
	end

if exists(select ColumnName from QuickSearchColumns where ColumnName = @ColumnName and ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The %s: %s and %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Column Name', @ColumnName, 'Object Name', @ObjectName)	
		return 1
	end
	
if not exists(select DataID from LookupData where DataID = @SearchCriterionID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG,16,1, 'Search Criterion ID', @SearchCriterionID, 'Lookup Data')	
		return 1
	end

begin

insert into QuickSearchColumns
(ObjectName, ColumnName, ColumnCaption, ColumnReference, SearchCriterionID, Searchable) 
values
(@ObjectName, @ColumnName, @ColumnCaption, @ColumnReference, @SearchCriterionID, @Searchable)

return 0
-- comment: sp_password
end
go

/*************************************************************************************

exec uspInsertQuickSearchColumns 'Payments', 'ReceiptNo', 'Receipt Number', 'Code', '2EQL', 1
exec uspInsertQuickSearchColumns 'Payments', 'Notes', 'Notes', 'Description','2CON', 0
exec uspInsertQuickSearchColumns 'Accounts', 'AccountNo', 'Account No', 'Code','2EQL', 1

**************************************************************************************/

-- select * from QuickSearchColumns
-- delete from QuickSearchColumns

------------Get Quick Search Columns --------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetQuickSearchColumns')
	drop proc uspGetQuickSearchColumns
go

create proc uspGetQuickSearchColumns(
@ObjectName as varchar(40)
)with encryption as  

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from SearchObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Search Objects')	
		return 1
	end

else

begin

	select ObjectName, ColumnName, ColumnCaption, ColumnReference, SearchCriterionID,
	dbo.GetLookupDataDes(SearchCriterionID) as SearchCriterion, Searchable
	from QuickSearchColumns
	where ObjectName = @ObjectName 
	order by SortOrder, ColumnCaption

return 0
-- comment: sp_password
end

go

-- exec uspGetQuickSearchColumns 'Payments'

--------- Update QuickSearchColumns Trigger -------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateQuickSearchColumns')
	drop trigger utrUpdateQuickSearchColumns
go

create trigger utrUpdateQuickSearchColumns
on QuickSearchColumns
for update
as

declare @ErrorMSG varchar(100)

if @@rowcount = 0 return 

if update(ColumnReference)
Begin
	set @ErrorMSG = 'You can''t update Column Reference for Quick Search Columns, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
-- comment: sp_password
end

go

-------------------------------------------------------------------------------------------------------
------------- Auto Numbers ----------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------

--------Insert Auto Numbers ---------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertAutoNumbers')
	drop proc uspInsertAutoNumbers
go

create proc uspInsertAutoNumbers(
@ObjectName varchar(40) ,
@AutoColumnName varchar(60),
@HelperColumnName varchar(60),
@AutoColumnLEN tinyint,
@PaddingCHAR char(1),
@PaddingLEN tinyint,
@SeparatorCHAR char(1),
@SeparatorPositions varchar(20),-- coma separated
@StartValue int,
@Increment smallint,
@AllowJumpTo bit,
@JumpToValue int
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from AccessObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Access Objects')	
		return 1
	end

if exists(select AutoColumnName from AutoNumbers where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)
	begin
		set @ErrorMSG = 'The Object Name: %s and Auto Column Name: %s, you''re trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, @ObjectName, @AutoColumnName)	
		return 1
	end

else
begin

insert into AutoNumbers
(ObjectName, AutoColumnName, HelperColumnName, AutoColumnLEN, PaddingCHAR, PaddingLEN, 
AllowJumpTo, JumpToValue, SeparatorCHAR, SeparatorPositions, StartValue, Increment) 
values
(@ObjectName, @AutoColumnName, @HelperColumnName, @AutoColumnLEN, @PaddingCHAR, @PaddingLEN, 
@AllowJumpTo, @JumpToValue, @SeparatorCHAR, @SeparatorPositions, @StartValue, @Increment)
return 0
-- comment: sp_password
end
go

/**************************************************************************************************************
--1------------------------------------------------------------------------------------------------------------
exec uspInsertAutoNumbers 'Payments', 'ReceiptNo', 'ReceiptID', 20, '0', 5, '-', '', 0, 1, 0, 0

**************************************************************************************************************/

-- select * from AutoNumbers
-- delete from AutoNumbers

--------Update Auto Numbers ---------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateAutoNumbers')
	drop proc uspUpdateAutoNumbers
go

create proc uspUpdateAutoNumbers(
@ObjectName varchar(40) ,
@AutoColumnName varchar(60),
@AutoColumnLEN tinyint,
@PaddingCHAR char(1),
@PaddingLEN tinyint,
@SeparatorCHAR char(1),
@SeparatorPositions varchar(20),-- coma separated
@StartValue int,
@Increment smallint,
@AllowJumpTo bit,
@JumpToValue int
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select AutoColumnName from AutoNumbers where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)
	begin
		set @ErrorMSG = 'The record with Object Name: %s and Auto Column Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG, 16, 1, @ObjectName, @AutoColumnName, 'Auto Numbers')	
		return 1
	end

else
begin

update AutoNumbers set
PaddingCHAR = @PaddingCHAR, PaddingLEN = @PaddingLEN, AutoColumnLEN = @AutoColumnLEN,
SeparatorCHAR = @SeparatorCHAR, SeparatorPositions = @SeparatorPositions, StartValue = @StartValue, 
Increment = @Increment, AllowJumpTo = @AllowJumpTo,  JumpToValue  = @JumpToValue 

where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName

return 0
-- comment: sp_password
end
go

/**************************************************************************************************************
--1------------------------------------------------------------------------------------------------------------
exec uspUpdateAutoNumbers 'Payments', 'ReceiptNo', 20, '0', 5, '-', '', 0, 1, 0, 0

**************************************************************************************************************/

-- select * from AutoNumbers
-- delete from AutoNumbers

------------Get Auto Numbers ----------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetAutoNumbers')
	drop proc uspGetAutoNumbers
go

create proc uspGetAutoNumbers(
@ObjectName as varchar(40) = null ,
@AutoColumnName varchar(60) = null
)with encryption as  

declare @ErrorMSG varchar(200)

if (not (@ObjectName is null)) and (not (@AutoColumnName is null))
begin
	if not exists(select AutoColumnName from AutoNumbers where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)
		begin
			set @ErrorMSG = 'The Object Name: %s and Auto Column Name: %s, you''re trying to enter does not exists in the registered %s'
			raiserror(@ErrorMSG, 16, 1, @ObjectName, @AutoColumnName, 'Auto Numbers')	
			return 1
		end
	else
	begin

	select ObjectName, AutoColumnName, HelperColumnName, AutoColumnLEN, PaddingCHAR, PaddingLEN, 
	SeparatorCHAR, SeparatorPositions, StartValue, Increment, AllowJumpTo, JumpToValue 
	from AutoNumbers 
	where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName

	end
end
else
if  (@ObjectName is null)and (@AutoColumnName is null)

begin
	select AutoNumbers.ObjectName, ObjectCaption, AutoColumnName, HelperColumnName, AutoColumnLEN, 
	PaddingCHAR, PaddingLEN, SeparatorCHAR, SeparatorPositions, StartValue, Increment, AllowJumpTo, JumpToValue 
	from AutoNumbers 
	inner join AccessObjects on AutoNumbers.ObjectName = AccessObjects.ObjectName
end
-- comment: sp_password
return 0

go

-- exec uspGetAutoNumbers 'Payments', 'ReceiptNo'
-- exec uspGetAutoNumbers
-- select * from AutoNumbers

--------Search Object--------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspSearchObject')
	drop proc uspSearchObject
go

create proc uspSearchObject(
@SearchText varchar(8000)
)with encryption as

	begin exec('Select ' + @SearchText) end
	-- comment: sp_password
	return 0
go

/* 
exec uspSearchObject 'top 2 LoginID As [Login ID], 
dbo.GetFullName(FirstName, LastName, null)as [Name], LoginLevel As [Level], 
dbo.GetLookupDataDes(StatusID) As [Status] From Logins'
*/

------------------------------------------------------------------------------------------------------
------------------------------- Utilities ------------------------------------------------------------
------------------------------------------------------------------------------------------------------

------------ Backup Database --------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspBackupDatabase')
	drop proc uspBackupDatabase
go

create proc uspBackupDatabase(
@DatabaseName sysname,
@Path sysname
)with encryption as   
begin

--DBCC CHECKDB (@DatabaseName)with NO_INFOMSGS
backup database @DatabaseName to disk = @Path 

return 0
-- comment: sp_password
end
go

-- restore database @DatabaseName from disk = @Path 
-- 

/********************************************************************************************************
--1------------------------------------------------------------------------------------------------------
exec uspBackupDatabase 'ClinicMaster', 
			'C:\Clinic Master Treat\Backup\FortPortal\2000\ClinicMaster-00-240607-62.dat'
*********************************************************************************************************/

------------------------------------------------------------------------------------------------------
------------- Licenses -------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

------------ Insert Licenses -------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertLicenses')
	drop proc uspInsertLicenses
go

create proc uspInsertLicenses(
@LicenseNo nvarchar(100),
@Company nvarchar(100),
@SupportPhone nvarchar(100),
@SupportEmail nvarchar(100),
@SupportWebsite nvarchar(100),
@ContactInfo nvarchar(100),
@ProductOwner nvarchar(100),
@ContractDate nvarchar(100),
@StartDate nvarchar(100),
@EndDate nvarchar(100),
@WarningDays nvarchar(100),
@NoUsers nvarchar(100),
@IdleDuration nvarchar(100),
@KeyTable nvarchar(100),
@NoRecords nvarchar(100),
@WarningRecords nvarchar(100) 
)with encryption as   

declare @ErrorMSG varchar(200)

if exists(select LLN from Licenses where LLN = @LicenseNo)
	begin
		set @ErrorMSG = 'The License No: ' + @LicenseNo + ', you are trying to enter already exists'
		raiserror(@ErrorMSG,16,1)	
		return 1
	end

begin
insert into Licenses
	(LLN, LCO, LSP, LSE, LSW, LCI, LPO, LCD, LSD, LED, LWD, LNU, LID, LKT, LNR, LWR) 
	values
	(@LicenseNo, @Company, @SupportPhone, @SupportEmail, @SupportWebsite, 
	@ContactInfo, @ProductOwner, @ContractDate, @StartDate, @EndDate, @WarningDays, 
	@NoUsers, @IdleDuration, @KeyTable, @NoRecords, @WarningRecords)

return 0
-- comment: sp_password
end
go

/* exec uspInsertLicenses '07/SIL/01', 'SyncSoft INT''L LTD', 'Jan 1 2008', 'Dec 31 2008', 
						'30', '5', 	'30', 'Patients', '10000', '200'

 exec uspInsertLicenses 'AefCBx6mZRKNrKL4hqte2g==', 'QzipqXcWek+mqXEbqRXbCS3im+zVTlHg', 'S8zvchsGbrD1BGuoPv+r4g==', 
						'ej7SYODPnVBhA0cT5FYRZw==', 'pl0J7v1YRjE=', 'JSlUTy5sqzs=', 'pl0J7v1YRjE=', 
						'jxzQLpEUmQyAJLGuTB+EFA==', '65tit2CQOW8=', 'E5cuFUHFJNw='

 exec uspInsertLicenses 'AefCBx6mZRI6mLCO9Rv9Yg==', 'QzipqXcWek+mqXEbqRXbCS3im+zVTlHg', 'S8zvchsGbrCUmOeYXKgajQ==', 
						'ej7SYODPnVAubnjDOT3fRA==', 'pl0J7v1YRjE=', 'JSlUTy5sqzs=', 'pl0J7v1YRjE=', 
						'jxzQLpEUmQyAJLGuTB+EFA==', '65tit2CQOW8=', 'E5cuFUHFJNw='

 exec uspInsertLicenses 'AefCBx6mZRLbfLFGQR/A9w==', 'QzipqXcWek+mqXEbqRXbCS3im+zVTlHg', 'S8zvchsGbrCUmOeYXKgajQ==', 
						'ej7SYODPnVChD8XmXnYX/g==', 'pl0J7v1YRjE=', 'Ld998te50GI=', 'pl0J7v1YRjE=', 
						'jxzQLpEUmQyAJLGuTB+EFA==', 'oHEKzKfa3I8=', 'E5cuFUHFJNw='

*/

-- select * from Licenses
-- delete from Licenses

--------Get Licenses-------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetLicenses')
	drop proc uspGetLicenses
go

create proc uspGetLicenses(
@LicenseNo nvarchar(100)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select LLN from Licenses where LLN = @LicenseNo)
	begin
		set @ErrorMSG = 'The %s: %s, you''re trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16,1, 'License No', @LicenseNo, 'Licenses')	
		return 1
	end
else
begin 
	select LLN as LicenseNo, LCO as Company, LSP as SupportPhone, LSE as SupportEmail, 
		LSW as SupportWebsite, LCI as ContactInfo, LPO as ProductOwner, LCD as ContractDate, 
		LSD as StartDate, LED as EndDate, LWD as WarningDays, LNU as NoUsers, LID as IdleDuration, 
		LKT as KeyTable, LNR as NoRecords, LWR as WarningRecords
	from Licenses
	where LLN = @LicenseNo
end
-- comment: sp_password
return 0
go

-- select * from Licenses
-- exec uspGetLicenses ''
-- exec uspGetLicenses '07/SIL/01'
-- exec uspGetLicenses 'AefCBx6mZRKNrKL4hqte2g=='

--------- Update Licenses Trigger -------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateLicenses')
	drop trigger utrUpdateLicenses
go

create trigger utrUpdateLicenses
on Licenses
for update
as
declare @ErrorMSG varchar(100)

if @@rowcount = 0 return 

if update(LLN)
Begin
	set @ErrorMSG = 'You can''t update LLN for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LCO)
Begin
	set @ErrorMSG = 'You can''t update LCO for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LSP)
Begin
	set @ErrorMSG = 'You can''t update LSP for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LSE)
Begin
	set @ErrorMSG = 'You can''t update LSE for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LSW)
Begin
	set @ErrorMSG = 'You can''t update LSW for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LCI)
Begin
	set @ErrorMSG = 'You can''t update LCI for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LPO)
Begin
	set @ErrorMSG = 'You can''t update LPO for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LCD)
Begin
	set @ErrorMSG = 'You can''t update LCD for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LSD)
Begin
	set @ErrorMSG = 'You can''t update LSD for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LED)
Begin
	set @ErrorMSG = 'You can''t update LED for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LWD)
Begin
	set @ErrorMSG = 'You can''t update LWD for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LNU)
Begin
	set @ErrorMSG = 'You can''t update LNU for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LID)
Begin
	set @ErrorMSG = 'You can''t update LID for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LKT)
Begin
	set @ErrorMSG = 'You can''t update LKT for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LNR)
Begin
	set @ErrorMSG = 'You can''t update LNR for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(LWR)
Begin
	set @ErrorMSG = 'You can''t update LWR for Licenses, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
	-- comment: sp_password
end
go

--------Count Active Users---------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspCountActiveUsers')
	drop proc uspCountActiveUsers
go

create proc uspCountActiveUsers
with encryption as

begin select count(*) as [ActiveUsers] from ActiveUsers end

return 0
-- comment: sp_password
go

-- select * from ActiveUsers
-- exec uspCountActiveUsers

--------Count Registered Records---------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspCountRegisteredRecords')
	drop proc uspCountRegisteredRecords
go

create proc uspCountRegisteredRecords(
@KeyTable varchar(100)
)with encryption as

begin
	exec('select count(*) as [RegisteredRecords] from ' + @KeyTable + '')
end

return 0
-- comment: sp_password
go

-- select * from Patients
-- exec uspCountRegisteredRecords 'Patients'

------------------------------------------------------------------------------------------------------
------------- ActiveUsers ----------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

------------ Insert Active Users ---------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertActiveUsers')
	drop proc uspInsertActiveUsers
go

create proc uspInsertActiveUsers(
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as   

declare @ErrorMSG varchar(200)

declare @LoginDate smalldatetime 
declare @LastUpdate smalldatetime
declare @NoLogins smallint

declare @AllowNetworkMultipleLogins tinyint
declare @ActiveClientMachine varchar(40)

set @LoginDate = GetDate()
set @LastUpdate = GetDate()
set @NoLogins = 1

set @AllowNetworkMultipleLogins = dbo.GetOptionValue('AllowNetworkMultipleLogins')

if not exists(select LoginID from Logins where LoginID = @LoginID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exists in the registered Logins'
		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID)
		return 1
	end

if exists(select LoginID from ActiveUsers where LoginID = @LoginID and ClientMachine = @ClientMachine)
	begin
			set @NoLogins = (select NoLogins from ActiveUsers where LoginID = @LoginID and ClientMachine = @ClientMachine)
			
			set @NoLogins = isnull(@NoLogins, 1)
			set @NoLogins = @NoLogins + 1

			update ActiveUsers set
			LastUpdate = @LastUpdate, NoLogins = @NoLogins
			where LoginID = @LoginID and ClientMachine = @ClientMachine

			return 0
	end
else

if ((exists(select LoginID from ActiveUsers where LoginID = @LoginID and not ClientMachine = @ClientMachine)) 
	and (@AllowNetworkMultipleLogins = 0))
	begin
		set @ActiveClientMachine = (select top 1 ClientMachine from ActiveUsers where LoginID = @LoginID)
		set @ActiveClientMachine = isnull(@ActiveClientMachine, '')
		set @ErrorMSG = 'The %s: %s, is known to be active on %s, multiple logins on same network are not allowed by administrator!'
		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID, @ActiveClientMachine)	
		return 1
	end
else	

begin

	insert into ActiveUsers
	(LoginID, ClientMachine, LoginDate, LastUpdate, NoLogins)  
	values 
	(@LoginID, @ClientMachine, @LoginDate, @LastUpdate, @NoLogins)

return 0
-- comment: sp_password
end
go

/* 
exec uspInsertActiveUsers 'Kutegz', 'Developer'
exec uspInsertActiveUsers 'Kutegz', 'Programmer'
exec uspInsertActiveUsers 'Admin', 'Developer'
exec uspInsertActiveUsers 'Clare', 'Data-03'
exec uspInsertActiveUsers 'User', 'Data-25'
*/

-- select * from ActiveUsers
-- delete from ActiveUsers

------------ Update Active Users ---------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateActiveUsers')
	drop proc uspUpdateActiveUsers
go

create proc uspUpdateActiveUsers(
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as   

declare @ErrorMSG varchar(200)
declare @LastUpdate smalldatetime

set @LastUpdate = GetDate()

if not exists(select LoginID from Logins where LoginID = @LoginID)
	begin
		set @ErrorMSG = 'The Login ID: ' + @LoginID + ', you are trying to enter does not exists in the registered Logins'
		raiserror(@ErrorMSG, 16, 1)	
		return 1
	end

begin
	update ActiveUsers set LastUpdate = @LastUpdate
	where LoginID = @LoginID and ClientMachine = @ClientMachine
	return 0
-- comment: sp_password
end
go

/* 
exec uspUpdateActiveUsers 'Kutegz', 'Developer'
exec uspUpdateActiveUsers 'Kutegz', 'Programmer'
exec uspUpdateActiveUsers 'Admin', 'Developer'
exec uspUpdateActiveUsers 'Clare', 'Data-03'
exec uspUpdateActiveUsers 'User', 'Data-25'
*/

-- select * from ActiveUsers
-- delete from ActiveUsers

--------Get Active Users-------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetActiveUsers')
	drop proc uspGetActiveUsers
go

create proc uspGetActiveUsers(
@LoginID varchar(20) = null,
@ClientMachine varchar(40) = null
)with encryption as

if (not (@LoginID is null) and not (@ClientMachine is null))
	begin
		select ActiveUsers.LoginID, ClientMachine, LoginDate, LastUpdate, NoLogins, 
		datediff (minute, LastUpdate, GetDate()) as IdleDuration
		from ActiveUsers
		where ActiveUsers.LoginID = @LoginID and ClientMachine = @ClientMachine
	end
else
	begin
		select ActiveUsers.LoginID as [Login ID], ClientMachine as [Client Machine], 
		LoginDate as [Login Date], LastUpdate as [Last Activity], 
		datediff(minute, LastUpdate, GetDate()) as [Idle Duration (Min)], 
		NoLogins as [No. of Logins], dbo.GetFullName(FirstName, null, LastName) as [User Name], 
		dbo.GetAssignedLoginRole(ActiveUsers.LoginID) as [Login Role], LoginLevel as [Login Level]
		from ActiveUsers
		inner join Logins on ActiveUsers.LoginID = Logins.LoginID
	end

return 0
-- comment: sp_password
go

-- select * from ActiveUsers
-- exec uspGetActiveUsers
-- exec uspGetActiveUsers 'Admin', 'SyncSoft'

--------- DeleteActiveUsers ----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteActiveUsers')
	drop proc uspDeleteActiveUsers
go

create proc uspDeleteActiveUsers(
@LoginID varchar(20),
@ClientMachine varchar(40),
@IdleDuration smallint
)with encryption as   

declare @NoLogins smallint

-------------------------------------------------------------------------------------------------------------------------
delete ActiveUsers where (datediff(minute, LastUpdate, GetDate()) >= @IdleDuration)
-------------------------------------------------------------------------------------------------------------------------

set @NoLogins = (select NoLogins from ActiveUsers where LoginID = @LoginID and ClientMachine = @ClientMachine)
set @NoLogins = isnull(@NoLogins, 1)

-------------------------------------------------------------------------------------------------------------------------
if @NoLogins > 1
	begin update ActiveUsers set NoLogins = @NoLogins - 1 where LoginID = @LoginID and ClientMachine = @ClientMachine end
else begin delete ActiveUsers where (LoginID = @LoginID and ClientMachine = @ClientMachine) end

-------------------------------------------------------------------------------------------------------------------------

return 0
-- comment: sp_password
go

-- exec uspDeleteActiveUsers '', '', 30
-- exec uspDeleteActiveUsers 'Kutegz', 'Developer', 30
-- exec uspDeleteActiveUsers 'Admin', 'Developer', 30
-- select * from ActiveUsers
-- select *, datediff (minute, LastUpdate, GetDate()) as IdleDuration from ActiveUsers

------------------------------------------------------------------------------------------------------
------------- Audit Trail ---------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

------------ Insert Audit Trail ---------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertAuditTrail')
	drop proc uspInsertAuditTrail
go

create proc uspInsertAuditTrail(
@AuditAction char(1), --[U-Update, D-Delete]
@ObjectName varchar(40),
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as   

declare @ErrorMSG varchar(200)
declare @UserID varchar(40)
declare @FullDate smalldatetime 

set @UserID = System_User
set @FullDate = GetDate()

if not exists(select ObjectName from AccessObjects where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The Object Name: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, @ObjectName, 'Access Objects')	
		return 1
	end

if not exists(select LoginID from Logins where LoginID = @LoginID)
	begin
		set @ErrorMSG = 'The Login ID: %s, you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG, 16, 1, @LoginID, 'Logins')	
		return 1
	end
else	
begin

	insert into AuditTrail
	(AuditAction, ObjectName, LoginID, ClientMachine, UserID, FullDate) 
	values
	(@AuditAction, @ObjectName, @LoginID, @ClientMachine, @UserID, @FullDate)

return 0
-- comment: sp_password
end
go

/* 
exec uspInsertAuditTrail 'D', 'Patients', 'Kutegz', 'Developer'
exec uspInsertAuditTrail 'D', 'Patients', 'Kutegz', 'Developer'
exec uspInsertAuditTrail 'U', 'Payments', 'Kutegz', 'Developer'
exec uspInsertAuditTrail 'U', 'Visits', 'Kutegz', ''
exec uspInsertAuditTrail 'D', 'Items', 'Kutegz', 'Developer'
*/

-- select * from AuditTrail
-- delete from AuditTrail

-- print @@identity
-- print ident_current('AuditTrail')

------------------------------------------------------------------------------------------------------
------------- Audit Trail Details --------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

------------ Insert Audit Trail Details --------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertAuditTrailDetails')
	drop proc uspInsertAuditTrailDetails
go

create proc uspInsertAuditTrailDetails(
@AuditID int, 
@ColumnName varchar(60), 
@OriginalValue varchar(2000), 
@NewValue varchar(2000)
)with encryption as   

declare @ErrorMSG varchar(200)

if not exists(select AuditID from AuditTrail where AuditID = @AuditID)
	begin
		set @ErrorMSG = 'The Audit ID: ' + cast(@AuditID as varchar(50)) + ', you are trying to enter does not exists in the registered %s'
		raiserror(@ErrorMSG,16, 1, 'Audit Trail')	
		return 1
	end

if exists(select AuditID from AuditTrailDetails where AuditID = @AuditID and ColumnName = @ColumnName )
	begin
		set @ErrorMSG = 'The record with Audit ID: ' + cast(@AuditID as varchar(50)) + ' and Column Name: %s, you are trying to enter already exist'
		raiserror(@ErrorMSG, 16, 1, @ColumnName)	
		return 1
	end

else	
begin

	insert into AuditTrailDetails
	(AuditID, ColumnName, OriginalValue, NewValue) 
	values
	(@AuditID, @ColumnName, @OriginalValue, @NewValue)

return 0
-- comment: sp_password
end
go

/* 
exec uspInsertAuditTrailDetails 1, 'PatientNo', '123', '321'
exec uspInsertAuditTrailDetails 1, 'JoinDate', '1 Jan 2008', '6 Feb 2008'
exec uspInsertAuditTrailDetails 1, 'GenderID', '15M', '15F'
exec uspInsertAuditTrailDetails 3, 'PatientNo', '0820006', '0820006NH'
exec uspInsertAuditTrailDetails 3, 'JoinDate', '15 Aug 2007', '15 Sep 2007'
*/

-- select * from AuditTrailDetails
-- delete from AuditTrailDetails

------------------------------------------------------------------------------------------------------
-------------- RestrictedKeys ------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Insert RestrictedKeys -----------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertRestrictedKeys')
	drop proc uspInsertRestrictedKeys
go

create proc uspInsertRestrictedKeys(
@ObjectName varchar(40),
@ColumnName varchar(60),
@ColumnCaption varchar(70)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from AccessObjects where ObjectName  = @ObjectName)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Access Objects')
		return 1
	end

if exists(select ObjectName from RestrictedKeys where ObjectName = @ObjectName and ColumnName = @ColumnName)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Column Name', @ColumnName)
		return 1
	end

begin
insert into RestrictedKeys
(ObjectName, ColumnName, ColumnCaption)
values
(@ObjectName, @ColumnName, @ColumnCaption)

return 0
-- comment: sp_password
end
go

/******************************************************************************************************
exec uspInsertRestrictedKeys 'Patients', 'PatientNo', 'Patient No'
exec uspInsertRestrictedKeys 'Visits', 'VisitNo', 'Visit No'
******************************************************************************************************/

-- select * from RestrictedKeys
-- delete from RestrictedKeys

-------------- Get RestrictedColumnKeys ---------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetRestrictedColumnKeys')
	drop proc uspGetRestrictedColumnKeys
go

create proc uspGetRestrictedColumnKeys(
@ObjectName varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)
begin	
	select ObjectName, ColumnName, ColumnCaption from RestrictedKeys
	where ObjectName = @ObjectName
return 0
-- comment: sp_password
end
go

/******************************************************************************************************
exec uspGetRestrictedColumnKeys 'Visits'
exec uspGetRestrictedColumnKeys 'Patients'
******************************************************************************************************/
-- select * from RestrictedKeys
-- delete from RestrictedKeys

-------------- Get RestrictedObjectKeys -------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetRestrictedObjectKeys')
	drop proc uspGetRestrictedObjectKeys
go

create proc uspGetRestrictedObjectKeys
with encryption as
begin	
	select distinct RestrictedKeys.ObjectName, ObjectCaption from RestrictedKeys
	inner join AccessObjects on AccessObjects.ObjectName = RestrictedKeys.ObjectName
return 0
-- comment: sp_password
end
go

/******************************************************************************************************
exec uspGetRestrictedObjectKeys
******************************************************************************************************/

-- select * from AccessObjects
-- select * from RestrictedKeys
-- delete from RestrictedKeys

--1--------Delete Many ---------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspDeleteMany')
	drop proc uspDeleteMany
go

create proc uspDeleteMany(
@ObjectName varchar(40),
@Where varchar(6000)
)with encryption as   
begin
	exec('delete from ' + @ObjectName + ' where ' + @Where + '')
end
-- comment: sp_password
go

-- exec uspDeleteMany 'Logins', 'LoginID = ''Admin'''

-- select * from Logins

 --1--------Update Keys ---------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateKeys')
	drop proc uspUpdateKeys
go

create proc uspUpdateKeys(
@ObjectName varchar(40),
@Set varchar(6000),
@Where varchar(6000) 
)with encryption as   
begin
	exec('update ' + @ObjectName + ' set ' + @Set + ' where ' + @Where + '')
end
-- comment: sp_password
go

-- exec uspUpdateKeys 'Logins', 'LoginID = ''Admin''', 'LoginID = ''Admin'''

-- select * from Logins

------------------------------------------------------------------------------------------------------
-------------- Options -------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Edit Options --------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspEditOptions')
	drop proc uspEditOptions
go

create proc uspEditOptions(
@OptionName varchar(40),
@OptionValue varchar(200),
@DataTypeID varchar(10),
@MaxLength tinyint,
@Hidden bit = 0
)with encryption as

declare @ErrorMSG varchar(200)

declare @StringDataTypeID varchar(10)
declare @DateTimeDataTypeID varchar(10)
declare @NumberDataTypeID varchar(10)
declare @MoneyDataTypeID varchar(10)
declare @DecimalDataTypeID varchar(10)
declare @BooleanDataTypeID varchar(10)

set @StringDataTypeID = dbo.GetLookupDataID('SearchDataType', 'STR')
set @DateTimeDataTypeID = dbo.GetLookupDataID('SearchDataType', 'DTE')
set @NumberDataTypeID = dbo.GetLookupDataID('SearchDataType', 'NUM')
set @MoneyDataTypeID = dbo.GetLookupDataID('SearchDataType', 'MON')
set @DecimalDataTypeID = dbo.GetLookupDataID('SearchDataType', 'DEC')
set @BooleanDataTypeID = dbo.GetLookupDataID('SearchDataType', 'BIT')

if not exists(select DataID from LookupData where DataID = @DataTypeID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Data Type ID', @DataTypeID, 'Lookup Data')
		return 1
	end

if (@DataTypeID = @DateTimeDataTypeID) and (IsDate(@OptionValue) = 0)
	begin
		set @ErrorMSG = 'Option Value''s data type is invalid'
		raiserror(@ErrorMSG, 16, 1)
		return 1
	end
else

if (@DataTypeID = @NumberDataTypeID) and (IsNumeric(@OptionValue) = 0)
	begin
		set @ErrorMSG = 'Option Value''s data type is invalid'
		raiserror(@ErrorMSG, 16, 1)
		return 1
	end
else

if (@DataTypeID = @MoneyDataTypeID) and (IsNumeric(@OptionValue) = 0)
	begin
		set @ErrorMSG = 'Option Value''s data type is invalid'
		raiserror(@ErrorMSG, 16, 1)
		return 1
	end
else

if (@DataTypeID = @DecimalDataTypeID) and (IsNumeric(@OptionValue) = 0)
	begin
		set @ErrorMSG = 'Option Value''s data type is invalid'
		raiserror(@ErrorMSG, 16, 1)
		return 1
	end
else

if (@DataTypeID = @BooleanDataTypeID) and (IsNumeric(@OptionValue) = 0)
	begin
		set @ErrorMSG = 'Option Value''s data type is invalid'
		raiserror(@ErrorMSG, 16, 1)
		return 1
	end
else

if (len(@OptionValue) > @MaxLength)
	begin
		set @ErrorMSG = 'Option Value''s length is more than maximum allowed length'
		raiserror(@ErrorMSG, 16, 1)
		return 1
	end
else

if exists(select OptionName from Options where OptionName = @OptionName)
	begin
		update Options set
		OptionValue = @OptionValue, DataTypeID = @DataTypeID, MaxLength = @MaxLength, Hidden = @Hidden
		where OptionName = @OptionName
		return 0
	end
else
begin
insert into Options
(OptionName, OptionValue, DataTypeID, MaxLength, Hidden)
values
(@OptionName, @OptionValue, @DataTypeID, @MaxLength, @Hidden)
return 0
end
-- comment: sp_password
go

/******************************************************************************************************
exec uspEditOptions 'Currency', 'UGX', '3STR', 3, 1

*******************************************************************************************************/

-- select * from Options
-- delete from Options

-------------- Get Options ----------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetOptions')
	drop proc uspGetOptions
go

create proc uspGetOptions(
@OptionName varchar(40) = null,
@Hidden bit = 0
)with encryption as

declare @ErrorMSG varchar(200)

if not (@OptionName is null)
begin
	if not exists(select OptionName from Options where OptionName = @OptionName)
		begin
			set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
			raiserror(@ErrorMSG, 16, 1, 'Option Name', @OptionName, 'Options')
			return 1
		end
	else
	begin
		select OptionName, OptionValue, DataTypeID, dbo.GetLookupDataDes(DataTypeID) as DataType, MaxLength, Hidden
		from Options
		where OptionName = @OptionName
		return 0
	end
end
else
if  (@OptionName is null)
begin
	select OptionName, OptionValue, DataTypeID, dbo.GetLookupDataDes(DataTypeID) as DataType, MaxLength, Hidden
	from Options where Hidden = @Hidden 	
return 0
end
-- comment: sp_password
go

/******************************************************************************************************
exec uspGetOptions
exec uspGetOptions 'IncorporateFingerprintCapture'
******************************************************************************************************/
-- select * from Options
-- delete from Options

--------Function GetOptionValue-----------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetOptionValue')
	drop function GetOptionValue
go

create function GetOptionValue(@OptionName varchar(40)) returns varchar(200)
with encryption as

begin

	declare @OptionValue varchar(200)
	
	set @OptionValue = (select OptionValue from Options where OptionName = @OptionName)
	set @OptionValue = isnull(@OptionValue, '')
	
	return @OptionValue

end
-- comment: sp_password
go

-- print dbo.GetOptionValue('PatientNoPrefix')
-- print dbo.GetOptionValue('DisableConstraints')
-- print dbo.GetOptionValue('FingerprintCaptureAgeLimit')

--------- Update Options Trigger -------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateOptions')
	drop trigger utrUpdateOptions
go

create trigger utrUpdateOptions
on Options
for update
as

declare @ErrorMSG varchar(100)

declare @StringDataTypeID varchar(10)
declare @DateTimeDataTypeID varchar(10)
declare @NumberDataTypeID varchar(10)
declare @MoneyDataTypeID varchar(10)
declare @DecimalDataTypeID varchar(10)
declare @BooleanDataTypeID varchar(10)

declare @OptionValue varchar(200)
declare @DataTypeID varchar(10)
declare @MaxLength tinyint

if @@rowcount = 0 return 

---------------------------------------------------------------------------------------------

set @StringDataTypeID = dbo.GetLookupDataID('SearchDataType', 'STR')
set @DateTimeDataTypeID = dbo.GetLookupDataID('SearchDataType', 'DTE')
set @NumberDataTypeID = dbo.GetLookupDataID('SearchDataType', 'NUM')
set @MoneyDataTypeID = dbo.GetLookupDataID('SearchDataType', 'MON')
set @DecimalDataTypeID = dbo.GetLookupDataID('SearchDataType', 'DEC')
set @BooleanDataTypeID = dbo.GetLookupDataID('SearchDataType', 'BIT')

set @OptionValue = (select OptionValue from Inserted)
set @DataTypeID = (select DataTypeID from Inserted)
set @MaxLength = (select MaxLength from Inserted)
---------------------------------------------------------------------------------------------

if update(OptionName)
Begin
	set @ErrorMSG = 'You can''t update Option Name for Options, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

---------------------------------------------------------------------------------------------

if update(OptionValue)
Begin

	if (@DataTypeID = @DateTimeDataTypeID) and (IsDate(@OptionValue) = 0)
		begin
			set @ErrorMSG = 'Option Value''s data type is invalid'
			raiserror(@ErrorMSG,16,10)
			rollback tran
			return
		end
	else

	if (@DataTypeID = @NumberDataTypeID) and (IsNumeric(@OptionValue) = 0)
		begin
			set @ErrorMSG = 'Option Value''s data type is invalid'
			raiserror(@ErrorMSG,16,10)
			rollback tran
			return
		end
	else

	if (@DataTypeID = @MoneyDataTypeID) and (IsNumeric(@OptionValue) = 0)
		begin
			set @ErrorMSG = 'Option Value''s data type is invalid'
			raiserror(@ErrorMSG,16,10)
			rollback tran
			return
		end
	else

	if (@DataTypeID = @DecimalDataTypeID) and (IsNumeric(@OptionValue) = 0)
		begin
			set @ErrorMSG = 'Option Value''s data type is invalid'
			raiserror(@ErrorMSG,16,10)
			rollback tran
			return
		end
	else

	if (@DataTypeID = @BooleanDataTypeID) and (IsNumeric(@OptionValue) = 0)
		begin
			set @ErrorMSG = 'Option Value''s data type is invalid'
			raiserror(@ErrorMSG,16,10)
			rollback tran
			return
		end
	else

	if (len(@OptionValue) > @MaxLength)
		begin
			set @ErrorMSG = 'Option Value''s length is more than maximum allowed length'
			raiserror(@ErrorMSG,16,10)
			rollback tran
			return
		end
end

go

------------------------------------------------------------------------------------------------------
-------------- ProductOwnerInfo ----------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Edit ProductOwnerInfo -----------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspEditProductOwnerInfo')
	drop proc uspEditProductOwnerInfo
go

create proc uspEditProductOwnerInfo(
@ProductOwner varchar(200),
@Address varchar(200),
@Phone varchar(100),
@AlternatePhone varchar(100),
@Fax varchar(100),
@Email varchar(100),
@AlternateEmail varchar(100),
@Website varchar(100),
@Photo image = null,
@AlternatePhoto image = null,
@TINNo varchar(100),
@VATNo varchar(100),
@PrintHeaderAlignmentID varchar(10),
@LogoTopMargin tinyint,
@TextTopMargin tinyint,
@LogoLeftMargin tinyint,
@TextLeftMargin tinyint,
@ProductVersion varchar(100)
)with encryption as

declare @ErrorMSG varchar(200)

if exists(select ProductOwner from ProductOwnerInfo where ProductOwner = @ProductOwner)
	begin
		update ProductOwnerInfo set 
		Address = @Address, Phone = @Phone, AlternatePhone = @AlternatePhone, Fax = @Fax, 
		Email = @Email, AlternateEmail = @AlternateEmail, Website = @Website, Photo = @Photo, 
		AlternatePhoto = @AlternatePhoto, TINNo = @TINNo, VATNo = @VATNo, 
		PrintHeaderAlignmentID = @PrintHeaderAlignmentID, LogoTopMargin = @LogoTopMargin, 
		LogoLeftMargin = @LogoLeftMargin, TextLeftMargin = @TextLeftMargin, 
		TextTopMargin = @TextTopMargin, ProductVersion = @ProductVersion
		where ProductOwner = @ProductOwner
		return 0
	end
else
begin
insert into ProductOwnerInfo
(ProductOwner, Address, Phone, AlternatePhone, Fax, Email, AlternateEmail, Website, Photo, AlternatePhoto, 
TINNo, VATNo, PrintHeaderAlignmentID, LogoTopMargin, TextTopMargin, LogoLeftMargin, TextLeftMargin, ProductVersion)
values
(@ProductOwner, @Address, @Phone, @AlternatePhone, @Fax, @Email, @AlternateEmail, @Website, @Photo, @AlternatePhoto, 
@TINNo, @VATNo, @PrintHeaderAlignmentID, @LogoTopMargin, @TextTopMargin, @LogoLeftMargin, @TextLeftMargin, @ProductVersion)
return 0
end
-- comment: sp_password
go

/******************************************************************************************************
exec uspEditProductOwnerInfo 'SyncSoft INTERNATIONAL LTD', 'P.O Box 7370, Kampala', '+256 772 609113', 
							'', '+256 772 609993', 'kutegz@yahoo.com', '', 
							'http://www.clinicmaster.net', null, '1.0', '', ''
******************************************************************************************************/

-- select * from ProductOwnerInfo
-- delete from ProductOwnerInfo

-------------- Get ProductOwnerInfo -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetProductOwnerInfo')
	drop proc uspGetProductOwnerInfo
go

create proc uspGetProductOwnerInfo(
@ProductOwner varchar(200)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select ProductOwner from ProductOwnerInfo where ProductOwner = @ProductOwner)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Product Owner', @ProductOwner, 'Product Owner Info')
		return 1
	end
else
begin
	select ProductOwner, Address, Phone, AlternatePhone, Fax, Email, AlternateEmail, 
	Website, Photo, AlternatePhoto, ProductVersion, TINNo, VATNo, PrintHeaderAlignmentID, 
	dbo.GetLookupDataDes(PrintHeaderAlignmentID) as PrintHeaderAlignment, 
	LogoTopMargin, TextTopMargin, LogoLeftMargin, TextLeftMargin, LastUpdate
	from ProductOwnerInfo
	where ProductOwner = @ProductOwner
return 0
end
-- comment: sp_password
go

/******************************************************************************************************
exec uspGetProductOwnerInfo 'ClinicMaster INTERNATIONAL'
******************************************************************************************************/
-- select * from ProductOwnerInfo
-- delete from ProductOwnerInfo

------------------------------------------------------------------------------------------------------
-------------- SpecialEdits --------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Insert SpecialEdits -------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertSpecialEdits')
	drop proc uspInsertSpecialEdits
go

create proc uspInsertSpecialEdits(
@ObjectName varchar(40),
@KeyColumnName varchar(100),
@KeyColumnCaption varchar(100)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from AccessObjects where ObjectName  = @ObjectName)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Access Objects')
		return 1
	end

if exists(select ObjectName from SpecialEdits where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName)
		return 1
	end

begin
insert into SpecialEdits 
(ObjectName, KeyColumnName, KeyColumnCaption) 
values 
(@ObjectName, @KeyColumnName, @KeyColumnCaption)
return 0
end
go

/******************************************************************************************************
exec uspInsertSpecialEdits 'BillCustomers', 'AccountNo', 'Account No'
exec uspInsertSpecialEdits 'Drugs', 'DrugNo', 'Drug No'

******************************************************************************************************/
-- select * from SpecialEdits
-- delete from SpecialEdits

-------------- Update SpecialEdits -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateSpecialEdits')
	drop proc uspUpdateSpecialEdits
go

create proc uspUpdateSpecialEdits(
@ObjectName varchar(40),
@KeyColumnName varchar(100),
@KeyColumnCaption varchar(100)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select ObjectName from SpecialEdits where ObjectName = @ObjectName)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Special Edits')
		return 1
	end

begin
update SpecialEdits set
KeyColumnName = @KeyColumnName, KeyColumnCaption = @KeyColumnCaption
where ObjectName = @ObjectName
return 0
end
go

/******************************************************************************************************
exec uspUpdateSpecialEdits 'BillCustomers', 'AccountNo', 'Account No'

******************************************************************************************************/
-- select * from SpecialEdits
-- delete from SpecialEdits

-------------- Get SpecialEdits -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetSpecialEdits')
	drop proc uspGetSpecialEdits
go

create proc uspGetSpecialEdits(
@ObjectName varchar(40) = null
)with encryption as

declare @ErrorMSG varchar(200)

if (not @ObjectName is null)
begin
	if not exists(select ObjectName from SpecialEdits where ObjectName = @ObjectName)
		begin
			set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
			raiserror(@ErrorMSG, 16, 1, 'Object Name', @ObjectName, 'Special Edits')
			return 1
		end
	else
	begin
		select SpecialEdits.ObjectName, ObjectCaption, KeyColumnName, KeyColumnCaption
		from SpecialEdits
		inner join AccessObjects on SpecialEdits.ObjectName = AccessObjects.ObjectName
		where SpecialEdits.ObjectName = @ObjectName
	end
end
else
if (@ObjectName is null)
begin
	select SpecialEdits.ObjectName, ObjectCaption, KeyColumnName, KeyColumnCaption
	from SpecialEdits
	inner join AccessObjects on SpecialEdits.ObjectName = AccessObjects.ObjectName
end
return 0
go

/******************************************************************************************************
exec uspGetSpecialEdits
exec uspGetSpecialEdits 'Drugs'
exec uspGetSpecialEdits 'BillCustomers'

******************************************************************************************************/
-- select * from SpecialEdits
-- delete from SpecialEdits

--------- Update SpecialEdits Trigger -------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'utrUpdateSpecialEdits')
	drop trigger utrUpdateSpecialEdits
go

create trigger utrUpdateSpecialEdits
on SpecialEdits
for update
as
declare @ErrorMSG varchar(100)

if @@rowcount = 0 return 

if update(ObjectName)
Begin
	set @ErrorMSG = 'You can''t update Object Name for Special Edits, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(KeyColumnName)
Begin
	set @ErrorMSG = 'You can''t update Key Column Name for Special Edits, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
end

if update(KeyColumnCaption)
Begin
	set @ErrorMSG = 'You can''t update Key Column Caption for Special Edits, transaction cancelled'
	raiserror(@ErrorMSG,16,10)
	rollback tran
	return
	-- comment: sp_password
end
go

------------------------------------------------------------------------------------------------------
-------------- ServerCredentials ---------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Insert ServerCredentials --------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertServerCredentials')
	drop proc uspInsertServerCredentials
go

create proc uspInsertServerCredentials(
@SourceName varchar(60),
@ConnectionModeID varchar(10),
@SourceLogin varchar(100),
@SourcePassword nvarchar(100)
)with encryption as

declare @ErrorMSG varchar(200)

if exists(select SourceName from ServerCredentials where SourceName = @SourceName)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Source Name', @SourceName)
		return 1
	end

if not exists(select DataID from LookupData where DataID = @ConnectionModeID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Connection Mode ID', @ConnectionModeID, 'Lookup Data')
		return 1
	end

if exists(select count(SourceName) from ServerCredentials having count(SourceName) > 0)
	begin
		raiserror('We already have an entry for server credentials!', 16, 1)
		return 1
	end

begin
insert into ServerCredentials
(SourceName, ConnectionModeID, SourceLogin, SourcePassword)
values
(@SourceName, @ConnectionModeID, @SourceLogin, @SourcePassword)
return 0
end
go

/******************************************************************************************************
exec uspInsertServerCredentials
******************************************************************************************************/
-- select * from ServerCredentials
-- delete from ServerCredentials

-------------- Update ServerCredentials -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateServerCredentials')
	drop proc uspUpdateServerCredentials
go

create proc uspUpdateServerCredentials(
@SourceName varchar(60),
@ConnectionModeID varchar(10),
@SourceLogin varchar(100),
@SourcePassword nvarchar(100)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select SourceName from ServerCredentials where SourceName = @SourceName)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Source Name', @SourceName, 'Server Credentials')
		return 1
	end

if not exists(select DataID from LookupData where DataID = @ConnectionModeID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Connection Mode ID', @ConnectionModeID, 'Lookup Data')
		return 1
	end

begin
update ServerCredentials set
ConnectionModeID = @ConnectionModeID, SourceLogin = @SourceLogin, SourcePassword = @SourcePassword
where SourceName = @SourceName
return 0
end
go

/******************************************************************************************************
exec uspUpdateServerCredentials
******************************************************************************************************/
-- select * from ServerCredentials
-- delete from ServerCredentials

-------------- Get ServerCredentials -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetServerCredentials')
	drop proc uspGetServerCredentials
go

create proc uspGetServerCredentials(
@SourceName varchar(60)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select SourceName from ServerCredentials where SourceName = @SourceName)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Source Name', @SourceName, 'Server Credentials')
		return 1
	end
else
begin
	select SourceName, ConnectionModeID, dbo.GetLookupDataDes(ConnectionModeID) as ConnectionMode, SourceLogin, SourcePassword
	from ServerCredentials
	where SourceName = @SourceName
return 0
end
go

/******************************************************************************************************
exec uspGetServerCredentials
******************************************************************************************************/
-- select * from ServerCredentials
-- delete from ServerCredentials

----------------------------------------------------------------------------------------------------------------------------
--------- Functions --------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

--------Function Null Date Value--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetNullDateValue')
	drop function GetNullDateValue
go

create function GetNullDateValue(@DateValue smalldatetime) returns varchar(12)
with encryption as
begin

declare @NullDateValue smalldatetime

set @NullDateValue = dbo.GetOptionValue('NullDateValue')
set @DateValue = dbo.FormatDate(@DateValue) 

if @NullDateValue = @DateValue begin set @DateValue = null end
	
return @DateValue
-- comment: sp_password
end

go

-------------------------------------------------------------------------------------------------------------------------------
-- print cast(dbo.GetNullDateValue('1 Jan 1900') as varchar)
-------------------------------------------------------------------------------------------------------------------------------

------------- This ensures newline after go above for the installer ----------------------------------
