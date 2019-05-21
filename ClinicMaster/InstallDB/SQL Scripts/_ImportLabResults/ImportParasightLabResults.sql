
use parasight
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

--------Function GetParasightLabResults------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetParasightLabResults')
	drop function GetParasightLabResults
go

create function GetParasightLabResults(@LabNo varchar (20)) 
returns varchar(4000)
with encryption as
begin

declare @TestValue varchar(400)
declare @Results varchar(6000)
set @Results = ''

begin
					
	set @TestValue = (select top 1 (value) from ParasightResults where Name= ('Malaria Diagnosis') and LabNo = @LabNo)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Diagnosis =N/A , ' 
	else set @Results = @Results + 'Diagnosis = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 (value) from ParasightResults where Name= ('SPEC') and LabNo = @LabNo)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Species = N/A, ' 
	else set @Results = @Results + 'Species = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 (round(value,5)) from ParasightResults where Name= ('PTEMIA') and LabNo = @LabNo)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Parasitemia =N/A , ' 
	else set @Results = @Results + 'Parasitemia = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 (value) from ParasightResults where Name= ('GAMETOCYTES') and LabNo = @LabNo)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Gametocytes =N/A , ' 
	else set @Results = @Results + 'Gametocytes = ' + @TestValue + ', '
	
	--set @TestValue = (select isnull((Cast(Value as int) * 1000),0)  from ParasightResults where Name= ('PLT') and LabNo = @LabNo and dbo.FormatDate(Timestamp) between @StartDateTime and @EndDateTime)
	--if @TestValue = '' or @TestValue is null set @Results = @Results + 'PLT = , ' 
	--else set @Results = @Results + 'PLT = ' + @TestValue + ', ' 
	
	set @TestValue = 'N/A'
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Blood smear = , ' 
	else set @Results = @Results + 'Blood smear = ' + @TestValue + ', '

	set @TestValue = 'N/A'
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Antigen = , ' 
	else set @Results = @Results + 'Antigen = ' + @TestValue
	
end
 
return isnull(@Results,'N/A')

end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetParasightLabResults('MADINA')
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
	select  dbo.FormatDate([Timestamp]) as TestDate, dbo.GetTime([Timestamp]) as TestTime,	
	LabNo as SpecimenNo,PatientNo, [PatientName] as FullName, 	
	dbo.GetParasightLabResults(LabNo) as Results
	from ParasightResults 
	where [Timestamp] between @StartDateTime and @EndDateTime and LabNo Like @SpecimenNo
	group by Timestamp,LabNo,PatientNo,PatientName 
	order by [Timestamp] desc
end
else
	begin
		select dbo.FormatDate([Timestamp]) as TestDate, dbo.GetTime([Timestamp]) as TestTime,	
		LabNo as SpecimenNo,PatientNo, [PatientName] as FullName, 	
		dbo.GetParasightLabResults(LabNo) as Results
		from ParasightResults 
		where [Timestamp] between @StartDateTime and @EndDateTime
		group by Timestamp,LabNo,PatientNo,PatientName 
		order by [Timestamp] desc
	end
return 0
-- comment: sp_password
go

/******************************************************************************************************
exec uspGetExternalLabResults '', '1 mar 17', '18 Dec 2017 10:02'
exec uspGetExternalLabResults '', '1 mar 2017 10:00', '19 mar 2017 19:00', '%MADINA%'

******************************************************************************************************/
