use CLinicMaster
go
------------Get Auto Numbers ----------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetCMFinAutoNumbers')
	drop proc uspGetCMFinAutoNumbers
go 

create proc uspGetCMFinAutoNumbers(
@ObjectName as varchar(40) = null ,
@AutoColumnName varchar(60) = null
)with encryption as  

declare @ErrorMSG varchar(200)

if (not (@ObjectName is null)) and (not (@AutoColumnName is null))
begin
	if not exists(select AutoColumnName from ClinicMasterFinance.dbo.AutoNumbers where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName)
		begin
			set @ErrorMSG = 'The Object Name: %s and Auto Column Name: %s, you''re trying to enter does not exists in the registered %s'
			raiserror(@ErrorMSG, 16, 1, @ObjectName, @AutoColumnName, 'Auto Numbers')	
			return 1
		end
	else
	begin

	select ObjectName, AutoColumnName, HelperColumnName, AutoColumnLEN, PaddingCHAR, PaddingLEN, 
	SeparatorCHAR, SeparatorPositions, StartValue, Increment, AllowJumpTo, JumpToValue 
	from ClinicMasterFinance.dbo.AutoNumbers 
	where ObjectName = @ObjectName and AutoColumnName = @AutoColumnName

	end
end
else
if  (@ObjectName is null)and (@AutoColumnName is null)

begin
	select AutoNumbers.ObjectName, ObjectCaption, AutoColumnName, HelperColumnName, AutoColumnLEN, 
	PaddingCHAR, PaddingLEN, SeparatorCHAR, SeparatorPositions, StartValue, Increment, AllowJumpTo, JumpToValue 
	from ClinicMasterFinance.dbo.AutoNumbers 
	inner join AccessObjects on AutoNumbers.ObjectName = AccessObjects.ObjectName
end
-- comment: sp_password
return 0

go

-- exec uspGetCMFinAutoNumbers 'Payments', 'ReceiptNo'
-- exec uspGetCMFinAutoNumbers
-- select * from AutoNumbers

-------- GetNextChartAccountID ------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetNextChartAccountID')
	drop proc uspGetNextChartAccountID
go

create proc uspGetNextChartAccountID(
@CategoryNo varchar(20),
@AccountID int = null output
)with encryption as

set @AccountID = (select max(AccountID) from ClinicMasterFinance.dbo.ChartAccounts where CategoryNo = @CategoryNo)
set @AccountID = ClinicMasterFinance.dbo.GetNextAutoNumber('ChartAccounts', 'AccountNo', @AccountID)

return 0

go

-- exec uspGetNextChartAccountID '101001'
-- select * from ChartAccounts where CategoryNo = '101'



if exists (select * from sysobjects where name = 'uspGetAccountCategories')
	drop proc uspGetAccountCategories
go

create proc uspGetAccountCategories(
@CategoryNo varchar(20) = null,
@Hidden bit = 0
)with encryption as

declare @ErrorMSG varchar(200)

if not (@CategoryNo is null)
begin
	if not exists(select CategoryNo from ClinicMasterFinance.dbo.AccountCategories where CategoryNo = @CategoryNo)
		begin
			set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
			raiserror(@ErrorMSG, 16, 1, 'Category No', @CategoryNo, 'Account Categories')
			return 1
		end

		begin
			select CategoryNo, AccountTypeID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountTypeID) as AccountType, CategoryName, 
			ParentCategoryNo, ClinicMasterFinance.dbo.GetAccountCategoryName(ParentCategoryNo) as ParentCategory, IsReadOnly, Hidden
			from ClinicMasterFinance.dbo.AccountCategories 
			where CategoryNo = @CategoryNo
		end
end
else if (@CategoryNo is null)
	begin
		select CategoryNo, AccountTypeID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountTypeID) as AccountType, CategoryName, 
		ParentCategoryNo, ClinicMasterFinance.dbo.GetAccountCategoryName(ParentCategoryNo) as ParentCategory, IsReadOnly, Hidden
		from ClinicMasterFinance.dbo.AccountCategories 
		where Hidden = @Hidden
		order by CategoryName
	end
	return 0
	go
	/******************************************************************************************************
  exec uspGetAccountCategories '101'
  exec uspGetAccountCategories
******************************************************************************************************/
-- select * from AccountCategories
-- delete from AccountCategories



------------------------------------------------------------------------------------------------------
-------------- ChartAccounts -------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Insert ChartAccounts ------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertChartAccounts')
	drop proc uspInsertChartAccounts
go

create proc uspInsertChartAccounts(
@AccountNo varchar(20),
@CategoryNo varchar(20),
@AccountName varchar(40),
@AccountReportID varchar(10),
@AccountActionID varchar(10),
@IsContra bit,
@IsReadOnly bit,
@Hidden bit,
@LoginID varchar(20),
@UserName varchar(41),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)
declare @AccountID int

declare @PaddingLEN tinyint

declare @PassedAccountID int
declare @PassedAccountNo varchar(20)
declare @PassedCategoryNo varchar(20)

if exists(select AccountNo from ClinicMasterFinance.dbo.ChartAccounts where AccountNo = @AccountNo)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Account No', @AccountNo)
		return 1
	end

if not exists(select CategoryNo from ClinicMasterFinance.dbo.AccountCategories where CategoryNo = @CategoryNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Category No', @CategoryNo, 'Account Categories')
		return 1
	end

if not exists(select DataID from ClinicMasterFinance.dbo.LookupData where DataID = @AccountReportID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Account Report', @AccountReportID, 'Lookup Data')
		return 1
	end

if not exists(select DataID from ClinicMasterFinance.dbo.LookupData where DataID = @AccountActionID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Account Action', @AccountActionID, 'Lookup Data')
		return 1
	end

--if not exists(select LoginID from Logins where LoginID  = @LoginID)
--	begin
--		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
--		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID, 'Logins')
--		return 1
--	end

begin

----------------------------------------------------------------------------------------------------------------------
	select @PaddingLEN = PaddingLEN from ClinicMasterFinance.dbo.AutoNumbers where ObjectName = 'ChartAccounts' and AutoColumnName = 'AccountNo'

	set @PassedCategoryNo = ltrim(rtrim(substring(@AccountNo, 1, len(@AccountNo) - @PaddingLEN)))

	if (@PassedCategoryNo = @CategoryNo)

	begin

		set @PassedAccountID = 1
		set @PassedAccountNo = @AccountNo

		set @PassedAccountNo = ltrim(rtrim(substring(@PassedAccountNo, len(@PassedCategoryNo) + 1, @PaddingLEN)))

		if isnumeric(@PassedAccountNo) = 1 set @PassedAccountID = @PassedAccountNo
		else set @PassedAccountID = 1

		set @AccountID = (select max(AccountID) from ClinicMasterFinance.dbo.ChartAccounts where CategoryNo = @CategoryNo)
		set @AccountID = dbo.GetNextAutoNumber('ChartAccounts', 'AccountNo', @AccountID)

		if @PassedAccountID < @AccountID set @AccountID = @PassedAccountID
		if @PassedAccountID > @AccountID set @AccountID = @PassedAccountID

	end else set @AccountID = 1

----------------------------------------------------------------------------------------------------------------------
insert into ClinicMasterFinance.dbo.ChartAccounts
(AccountID, AccountNo, CategoryNo, AccountName, AccountReportID, AccountActionID, IsContra, IsReadOnly, Hidden, LoginID, UserName, ClientMachine)
values
(@AccountID, @AccountNo, @CategoryNo, @AccountName, @AccountReportID, @AccountActionID, @IsContra, @IsReadOnly, @Hidden, @LoginID, @UserName, @ClientMachine)
return 0
end
go

/**************************************************************************************************************************************************
exec uspInsertChartAccounts '101001', '101', 'Plant & Buildings', '1004BS', '19DR', 0, 0, 0, 'Admin', 'System Administrator', 'CEO'
exec uspInsertChartAccounts '101002', '101', 'Furniture & Fittings', '1004BS', '19DR', 0, 0, 0, 'Admin', 'System Administrator', 'CEO'
exec uspInsertChartAccounts '101008', '101', 'Computers & Accessories', '1004BS', '19DR', 0, 0, 0, 'Admin', 'System Administrator', 'CEO'
exec uspInsertChartAccounts '101009', '101', 'Accumulated Dep. Plant & Buildings', '1004BS', '19CR', 1, 0, 0, 'Admin', 'System Administrator', 'CEO'

exec uspInsertChartAccounts '103001', '103', 'Barclays Bank USD', '1004BS', '19DR', 0, 0, 1, 'Admin', 'System Administrator', 'CEO'
exec uspInsertChartAccounts '103002', '103', 'Barclays Bank UGX', '1004BS', '19DR', 0, 0, 0, 'Admin', 'System Administrator', 'CEO'
exec uspInsertChartAccounts '104001', '104', 'Petty Cash', '1004BS', '19DR', 0, 0, 0, 'Admin', 'System Administrator', 'CEO'

exec uspInsertChartAccounts '301001', '301', 'Retained Earnings', '1004BS', '19CR', 0, 0, 1, 'Admin', 'System Administrator', 'CEO'
exec uspInsertChartAccounts '301002', '301', 'Share Capital', '1004BS', '19CR', 0, 0, 0, 'Admin', 'System Administrator', 'CEO'

***************************************************************************************************************************************************/
-- select * from ChartAccounts
-- delete from ChartAccounts

-------------- Get Chart Accounts------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetChartAccounts')
	drop proc uspGetChartAccounts
go

create proc uspGetChartAccounts(
@AccountNo varchar(20) = null,
@Hidden bit = 0
)with encryption as

declare @ErrorMSG varchar(200)


if not @AccountNo is null
begin

		select AccountNo, ChartAccounts.CategoryNo, CategoryName, AccountName, AccountTypeID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountTypeID) as AccountType, 
		AccountReportID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountReportID) as AccountReport, AccountActionID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountActionID) as AccountAction, 
		IsContra, ChartAccounts.IsReadOnly, ChartAccounts.Hidden
		from ClinicMasterFinance. dbo.ChartAccounts
		inner join ClinicMasterFinance. dbo.AccountCategories on ChartAccounts.CategoryNo = AccountCategories.CategoryNo
		where AccountNo = @AccountNo and ChartAccounts.Hidden = @Hidden
		order by AccountName
end
else if (@AccountNo is null)
	begin
		select AccountNo, ChartAccounts.CategoryNo, CategoryName, AccountName, AccountTypeID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountTypeID) as AccountType, 
		AccountReportID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountReportID) as AccountReport, AccountActionID, ClinicMasterFinance.dbo.GetLookupDataDes(AccountActionID) as AccountAction, 
		IsContra, ChartAccounts.IsReadOnly, ChartAccounts.Hidden
		from ClinicMasterFinance. dbo.ChartAccounts
		inner join ClinicMasterFinance.dbo.AccountCategories on ChartAccounts.CategoryNo = AccountCategories.CategoryNo
		where ChartAccounts.Hidden = @Hidden
		order by AccountName
	end
	return 0
go

--- exec uspGetChartAccounts '210144'

-------------- Get Chart Accounts Parent Category------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetChartAccountsByParentCategory')
	drop proc uspGetChartAccountsByParentCategory
go

create proc uspGetChartAccountsByParentCategory(
@ParentCategoryNo varchar(20),
@Hidden bit = 0
)with encryption as

declare @ErrorMSG varchar(200)
begin

		select AccountNo, ChartAccounts.CategoryNo, CategoryName, AccountName, AccountTypeID, dbo.GetLookupDataDes(AccountTypeID) as AccountType, 
		AccountReportID, dbo.GetLookupDataDes(AccountReportID) as AccountReport, AccountActionID, dbo.GetLookupDataDes(AccountActionID) as AccountAction, 
		IsContra, ChartAccounts.IsReadOnly, ChartAccounts.Hidden
		from ClinicMasterFinance. dbo.ChartAccounts
		inner join ClinicMasterFinance. dbo.AccountCategories on ChartAccounts.CategoryNo = AccountCategories.CategoryNo
		where ParentCategoryNo = @ParentCategoryNo and ChartAccounts.Hidden = @Hidden
		order by AccountName
return 0
end
	
go

--exec uspGetChartAccountsByParentCategory '112'

 
-------------- Get Chart Accounts Category------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetChartAccountsByCategoryNo')
	drop proc uspGetChartAccountsByCategoryNo
go

create proc uspGetChartAccountsByCategoryNo(
@CategoryNo varchar(20),
@Hidden bit = 0
)with encryption as

begin

		select AccountNo, ChartAccounts.CategoryNo, CategoryName, AccountName, AccountTypeID, dbo.GetLookupDataDes(AccountTypeID) as AccountType, 
		AccountReportID, dbo.GetLookupDataDes(AccountReportID) as AccountReport, AccountActionID, dbo.GetLookupDataDes(AccountActionID) as AccountAction, 
		IsContra, ChartAccounts.IsReadOnly, ChartAccounts.Hidden
		from ClinicMasterFinance. dbo.ChartAccounts
		inner join ClinicMasterFinance. dbo.AccountCategories on ChartAccounts.CategoryNo = AccountCategories.CategoryNo
		where ChartAccounts.CategoryNo = @CategoryNo and ChartAccounts.Hidden = @Hidden
		order by AccountName

 return 0
end
go

--exec uspGetChartAccountsByCategoryNo '111'



-------------- Get Chart Accounts Category------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetChartAccountsByType')
	drop proc uspGetChartAccountsByType
go

create proc uspGetChartAccountsByType(
@AccountTypeID varchar(10),
@AccountNo varchar(20)=null,

@Hidden bit = 0
)with encryption as

begin

if @AccountNo is null
begin
		select AccountNo, ChartAccounts.CategoryNo, CategoryName, AccountName, AccountTypeID, dbo.GetLookupDataDes(AccountTypeID) as AccountType, 
		AccountReportID, dbo.GetLookupDataDes(AccountReportID) as AccountReport, AccountActionID, dbo.GetLookupDataDes(AccountActionID) as AccountAction, 
		IsContra, dbo.GetMergedNameCode(AccountName, AccountNo) as AccountFullName, ChartAccounts.IsReadOnly, ChartAccounts.Hidden
		from ClinicMasterFinance. dbo.ChartAccounts
		inner join ClinicMasterFinance. dbo.AccountCategories on ChartAccounts.CategoryNo = AccountCategories.CategoryNo
		where AccountCategories.AccountTypeID = @AccountTypeID and ChartAccounts.Hidden = @Hidden
		order by AccountName

 end

 else
 begin
		select AccountNo, ChartAccounts.CategoryNo, CategoryName, AccountName, AccountTypeID, dbo.GetLookupDataDes(AccountTypeID) as AccountType, 
		AccountReportID, dbo.GetLookupDataDes(AccountReportID) as AccountReport, AccountActionID, dbo.GetLookupDataDes(AccountActionID) as AccountAction, 
		IsContra, dbo.GetMergedNameCode(AccountName, AccountNo) as AccountFullName, ChartAccounts.IsReadOnly, ChartAccounts.Hidden
		from ClinicMasterFinance. dbo.ChartAccounts
		inner join ClinicMasterFinance. dbo.AccountCategories on ChartAccounts.CategoryNo = AccountCategories.CategoryNo
		where AccountCategories.AccountTypeID = @AccountTypeID and AccountNo = @AccountNo and ChartAccounts.Hidden = @Hidden
		order by AccountName

 end

 return 0
end
go

-- exec uspGetChartAccountsByType '10031'

-------------- Get Account Categories By Type -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetAccountCategoriesByType')
	drop proc uspGetAccountCategoriesByType
go

create proc uspGetAccountCategoriesByType(
@AccountTypeID varchar(20),
@Hidden bit = 0
)with encryption as

declare @ErrorMSG varchar(200)

begin
		select CategoryNo, AccountTypeID, dbo.GetLookupDataDes(AccountTypeID) as AccountType, CategoryName, 
		ParentCategoryNo, ClinicMasterFinance.dbo.GetAccountCategoryName(ParentCategoryNo) as ParentCategoryName, IsReadOnly, Hidden
		from ClinicMasterFinance.dbo.AccountCategories 
		where Hidden = @Hidden and AccountTypeID=@AccountTypeID
		order by CategoryName
	end
	return 0
go


-- exec uspGetAccountCategoriesByType '10031'


-------------- Update FinancialPeriodAccounts -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateFinancialPeriodAccounts')
	drop proc uspUpdateFinancialPeriodAccounts
go

create proc uspUpdateFinancialPeriodAccounts(
@PeriodNo varchar(20),
@AccountNo varchar(20),
@OpeningBalance money,
@LoginID varchar(20),
@Username varchar(41),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select PeriodNo from ClinicMasterFinance.dbo.FinancialPeriods where PeriodNo  = @PeriodNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Period No', @PeriodNo, 'Financial Periods')
		return 1
	end

if not exists(select AccountNo from ClinicMasterFinance.dbo.ChartAccounts where AccountNo  = @AccountNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Account No', @AccountNo, 'Chart Accounts')
		return 1
	end

if not exists(select PeriodNo from ClinicMasterFinance.dbo.FinancialPeriodAccounts where PeriodNo = @PeriodNo and AccountNo = @AccountNo)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s, you are trying to enter does not exists in the table %s'
		raiserror(@ErrorMSG, 16, 1, 'Period No', @PeriodNo, 'Account No', @AccountNo, 'Financial Period Accounts')
		return 1
	end

--if not exists(select LoginID from Logins where LoginID  = @LoginID)
--	begin
--		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
--		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID, 'Logins')
--		return 1
--	end

begin
	update ClinicMasterFinance.dbo.FinancialPeriodAccounts set OpeningBalance=@OpeningBalance, LoginID= @LoginID, Username = @Username, ClientMachine=@ClientMachine
	where PeriodNo=@PeriodNo and AccountNo=@AccountNo
	return 0
end
go

/****************************************************************************************************************
exec uspUpdateFinancialPeriodAccounts '1801', '101001', 800000 , 'Admin', 'System administrator', 'CEO'
exec uspUpdateFinancialPeriodAccounts '1801', '101002', 450000 , 'Admin', 'System administrator', 'CEO'
exec uspUpdateFinancialPeriodAccounts '1801', '103001', 50000,  'Admin', 'System administrator', 'CEO'
exec uspUpdateFinancialPeriodAccounts '1802', '101001', 0 , 'Admin', 'System administrator', 'CEO'
exec uspUpdateFinancialPeriodAccounts '1802', '101002', 34000, 'Admin', 'System administrator', 'CEO'

*****************************************************************************************************************/

-------------- Update ChartAccounts -----------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateChartAccounts')
	drop proc uspUpdateChartAccounts
go

create proc uspUpdateChartAccounts(
@AccountNo varchar(20),
@CategoryNo varchar(20),
@AccountName varchar(40),
@AccountReportID varchar(10),
@AccountActionID varchar(10),
@IsContra bit,
@IsReadOnly bit,
@Hidden bit,
@LoginID varchar(20),
@UserName varchar(41),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select AccountNo from ClinicMasterFinance.dbo.ChartAccounts where AccountNo = @AccountNo)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Account No', @AccountNo, 'Chart Accounts')
		return 1
	end

if not exists(select CategoryNo from ClinicMasterFinance.dbo.AccountCategories where CategoryNo  = @CategoryNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Category No', @CategoryNo, 'Account Categories')
		return 1
	end

if not exists(select DataID from ClinicMasterFinance.dbo.LookupData where DataID = @AccountReportID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Account Report', @AccountReportID, 'Lookup Data')
		return 1
	end

if not exists(select DataID from ClinicMasterFinance.dbo.LookupData where DataID = @AccountActionID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Account Action', @AccountActionID, 'Lookup Data')
		return 1
	end

--if not exists(select LoginID from Logins where LoginID  = @LoginID)
--	begin
--		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
--		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID, 'Logins')
--		return 1
--	end

begin
	update ClinicMasterFinance.dbo.ChartAccounts set 
	CategoryNo = @CategoryNo, AccountName = @AccountName, AccountReportID = @AccountReportID, AccountActionID = @AccountActionID, 
	IsContra = @IsContra, IsReadOnly = @IsReadOnly, Hidden = @Hidden, LoginID = @LoginID, UserName = @UserName, ClientMachine = @ClientMachine
	where AccountNo = @AccountNo
	return 0
end
go

/*********************************************************************************************************************************
exec uspUpdateChartAccounts '301002', '301', 'Share Capital1', '1004BS', '19CR', 0, 1, 1, 'Admin', 'System Administrator1', 'CEO1'

**********************************************************************************************************************************/
-- select * from ChartAccounts
-- delete from ChartAccounts



------------Functions

if exists (select * from sysobjects where name = 'GetChartAccountName')
	drop function  GetChartAccountName
go

create function  GetChartAccountName(@AccountNo varchar(20)) returns varchar(40)
with encryption as
   
begin
 declare @AccountName varchar(40)
   set @AccountName=(select AccountName from ClinicMasterFinance.dbo.ChartAccounts where AccountNo=@AccountNo)
   set @AccountName= isnull(@AccountName,'')
   return @AccountName
 end
go

-----print dbo.GetChartAccountName('')

if exists (select * from sysobjects where name = 'GetChartAccountName')
	drop function  GetChartAccountName
go

create function  GetChartAccountName(@AccountNo varchar(20)) returns varchar(40)
with encryption as
   
begin
 declare @AccountName varchar(40)
   set @AccountName=(select AccountName from ClinicMasterFinance.dbo.ChartAccounts where AccountNo=@AccountNo)
   set @AccountName= isnull(@AccountName,'')
   return @AccountName
 end
go

