
use xt2000i
go

------------------------------------------------------------------------------------------------------
------------------------------- Functions ------------------------------------------------------------
------------------------------------------------------------------------------------------------------

--------Function Get Full Name------------------------------------------------------------------------

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

-----------------------------------------------------------------------------------------
-- print dbo.GetFullName('Kutegeka', null, 'Wilson')
-- print dbo.GetFullName('Kutegeka', 'Kateeba', 'Wilson')
-----------------------------------------------------------------------------------------

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
-- print dbo.FormatDate('23 mar 1992') 
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

--------Function GetTime --------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetTime')
	drop function GetTime
go

create function GetTime(@FullDate as smalldatetime) returns varchar(8)
with encryption as

begin

declare @Time varchar(8)

declare @Hour varchar(2)
declare @Minutes varchar(2)
declare @Seconds varchar(2)

set @Hour = dbo.PadLeft(datepart(hour, @FullDate), 2)
set @Minutes = dbo.PadLeft(datepart(minute, @FullDate), 2)
set @Seconds = dbo.PadLeft(datepart(second, @FullDate), 2)

set @Time = @Hour + ':' + @Minutes + ':' + @Seconds

return @Time
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetTime('Jan 3 1900 23:55:10')
----------------------------------------------------------------------------------------------------------------------------

--------Function FormatNumber-----------------------------------------------------------------------------------------------

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

--------Function GetNumericResult-------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetNumericResult')
	drop function GetNumericResult
go

create function GetNumericResult(@Result as varchar(200)) returns varchar(200)
with encryption as

begin
	
declare @SearchCHAR char(1)
declare @Index tinyint
declare @NewResult as varchar(200)

set @SearchCHAR = '['

set @Result = replace(@Result, ' ' , '')
set @Result = replace(@Result, '*' , '')
set @Index = charindex(@SearchCHAR, @Result, 0)

if @Index = 0 begin set @NewResult = @Result end
else begin set @NewResult = ltrim(rtrim(substring(@Result, 0, @Index))) end

set @NewResult = isnull(@NewResult, '')

return @NewResult
-- comment: sp_password
end

go

--------------------------------------------------------------------------------------------------------
-- print dbo.GetNumericResult('0.610 0  [×106/L]')
-- print dbo.GetNumericResult(null)
--------------------------------------------------------------------------------------------------------

--------Function GetXT2000IFullLabResults------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetXT2000IFullLabResults')
	drop function GetXT2000IFullLabResults
go

create function GetXT2000IFullLabResults(@ResultID int) 
returns varchar(4000)
with encryption as
begin

declare @TestValue varchar(400)
declare @Results varchar(6000)
set @Results = ''

begin
					
	set @TestValue = (select round(WBC, 2) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'WBC: = , ' 
	else set @Results = @Results + 'WBC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(RBC, 2) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RBC: = , ' 
	else set @Results = @Results + 'RBC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(HGB, 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HGB: = , ' 
	else set @Results = @Results + 'HGB: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(HCT, 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HCT: = , ' 
	else set @Results = @Results + 'HCT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(MCV, 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCV: = , ' 
	else set @Results = @Results + 'MCV: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(MCH, 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCH: = , ' 
	else set @Results = @Results + 'MCH: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(MCHC, 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCHC: = , ' 
	else set @Results = @Results + 'MCHC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(PLT, 0) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PLT: = , ' 
	else set @Results = @Results + 'PLT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round([LYMPHP], 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYM%: = , ' 
	else set @Results = @Results + 'LYM%: = ' + @TestValue + ', ' 
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MXD%: = , ' 
	else set @Results = @Results + 'MXD%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round(NEUTP, 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT%: = , ' 
	else set @Results = @Results + 'NEUT%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round([LYMPHH], 2) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYM#: = , ' 
	else set @Results = @Results + 'LYM#: = ' + @TestValue + ', ' 
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MXD#: = , ' 
	else set @Results = @Results + 'MXD#: = ' + @TestValue + ', ' 
		
	set @TestValue = (select round(NEUTH, 2) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT#: = , ' 
	else set @Results = @Results + 'NEUT#: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round([MONOH], 2) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO: = , ' 
	else set @Results = @Results + 'MONO: = ' + @TestValue + ', ' 
	
	set @TestValue =  (select round([EOH], 2) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EOSINO: = , ' 
	else set @Results = @Results + 'EOSINO: = ' + @TestValue + ', '
	
	set @TestValue = (select round([BASOH], 2) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO: = , ' 
	else set @Results = @Results + 'BASO: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round([MONOP], 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO%: = , ' 
	else set @Results = @Results + 'MONO%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round([EOP], 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EOSINO%: = , ' 
	else set @Results = @Results + 'EOSINO%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select round([BASOP], 1) from Results where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO%: = ' 
	else set @Results = @Results + 'BASO%: = ' + @TestValue
	
end
 
return @Results

end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetXT2000IFullLabResults(3)
----------------------------------------------------------------------------------------------------------------------------

--------GetExternalLabResults-----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetExternalLabResults')
	drop proc uspGetExternalLabResults
go

create proc uspGetExternalLabResults(
@SourceCaption varchar(100),
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@SpecimenNo varchar(20) = null
)with encryption as

declare @ErrorMSG varchar(200)

if (not (@SpecimenNo is null))
begin
	select dbo.FormatDate([Date]) as TestDate, dbo.GetTime([Date]) as TestTime,	
	ResultID as SpecimenNo, PatientID as PatientNo, [PatientName] as FullName, 	
	dbo.GetXT2000IFullLabResults(ResultID) as Results
	from Results 
	where [Date] between @StartDateTime and @EndDateTime and ResultID Like @SpecimenNo 
	order by [Date] desc
end
else
	begin
		select dbo.FormatDate([Date]) as TestDate, dbo.GetTime([Date]) as TestTime,	
		ResultID as SpecimenNo, PatientID as PatientNo, [PatientName] as FullName, 	
		dbo.GetXT2000IFullLabResults(ResultID) as Results
		from Results 
		where [Date] between @StartDateTime and @EndDateTime
		order by [Date] desc
	end
return 0
-- comment: sp_password
go

/******************************************************************************************************
exec uspGetExternalLabResults '', '1 Sep 2013', '12 Dec 2013 10:02'
exec uspGetExternalLabResults '', '1 Sep 2013', '12 Dec 2013 10:02', '%777%'

******************************************************************************************************/
