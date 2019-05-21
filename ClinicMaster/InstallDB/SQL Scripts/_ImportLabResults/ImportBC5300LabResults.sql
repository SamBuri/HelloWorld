use BC5300DataBase
go

------------------------------------------------------------------------------------------------------
------------------------------- Functions ------------------------------------------------------------
------------------------------------------------------------------------------------------------------

--------Function Get Full Name------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetFullName')
	drop function GetFullName
go

create function GetFullName(@LastName varchar(30), @Name varchar(30)) returns varchar(100)
with encryption as

begin

declare @FullName varchar(100)

if (@LastName is null or @LastName = '')
	begin set @FullName = @Name  end
else if (@Name is null or @Name = '')
	begin set @FullName = @LastName  end
else
begin set @FullName = @LastName  + ' ' + @Name end

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

--------Function GetNumericResult----------------------------------------------------------------

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


--------Function GetBC5300LabResults------------------------------------------------------------------------------------------

--if exists (select * from sysobjects where name = 'GetBC5300LabResults')
--	drop function GetBC5300LabResults
--go

--create function GetBC5300LabResults(@ID varchar(40)) 
--returns varchar(4000)
--with encryption as
--begin

--declare @TestValue varchar(400)
--declare @Results varchar(6000)
--set @Results = ''

--begin
					
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(WBC * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'WBC = , ' 
--	else set @Results = @Results + 'WBC = ' + @TestValue + ', ' 

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Neu_Percent * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Neu% = , ' 
--	else set @Results = @Results + 'Neu% = ' + @TestValue + ', '
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Lym_Percent * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Lym% = , ' 
--	else set @Results = @Results + 'Lym% = ' + @TestValue + ', ' 

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Mon_Percent * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Mon% = , ' 
--	else set @Results = @Results + 'Mon% = ' + @TestValue + ', '

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Eos_Percent * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Eos% = , ' 
--	else set @Results = @Results + 'Eos% = ' + @TestValue + ', '

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Bas_Percent * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Bas% = , ' 
--	else set @Results = @Results + 'Bas% = ' + @TestValue + ', '

	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Neu# * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Neu# = , ' 
--	else set @Results = @Results + 'Neu# = ' + @TestValue + ', '
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Lym# * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Lym# = , ' 
--	else set @Results = @Results + 'Lym# = ' + @TestValue + ', '

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Mon# * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Mon# = , ' 
--	else set @Results = @Results + 'Mon# = ' + @TestValue + ', '

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Eos# * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Eos# = , ' 
--	else set @Results = @Results + 'Eos# = ' + @TestValue + ', '

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Bas# * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Bas# = , ' 
--	else set @Results = @Results + 'Bas# = ' + @TestValue + ', '
	
--    set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(RBC * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RBC = , ' 
--	else set @Results = @Results + 'RBC = ' + @TestValue + ', ' 
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(HGB * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HGB = , ' 
--	else set @Results = @Results + 'HGB = ' + @TestValue + ', ' 
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(HCT * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HCT = , ' 
--	else set @Results = @Results + 'HCT = ' + @TestValue + ', ' 
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MCV * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCV = , ' 
--	else set @Results = @Results + 'MCV = ' + @TestValue + ', ' 
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MCH * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCH = , ' 
--	else set @Results = @Results + 'MCH = ' + @TestValue + ', ' 
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MCHC * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCHC = , ' 
--	else set @Results = @Results + 'MCHC = ' + @TestValue + ', ' 
    
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(RDW_CV * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RDW-CV = , ' 
--	else set @Results = @Results + 'RDW-CV = ' + @TestValue + ', '
	
--	 set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(RDW_SD * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RDW-SD = , ' 
--	else set @Results = @Results + 'RDW-SD = ' + @TestValue + ', '
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(PLT), 0) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PLT = , ' 
--	else set @Results = @Results + 'PLT = ' + @TestValue + ', ' 

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MPV * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MPV = , ' 
--	else set @Results = @Results + 'MPV = ' + @TestValue + ', ' 

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(PDW * 0.1), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PDW = , ' 
--	else set @Results = @Results + 'PDW = ' + @TestValue + ', ' 

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(PCT * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PCT = , ' 
--	else set @Results = @Results + 'PCT = ' + @TestValue + ', ' 
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(ALY_Percent * 0.01), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'ALY% = , ' 
--	else set @Results = @Results + 'ALY% = ' + @TestValue + ', ' 

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(LIC_Percent * 0.01), 1) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LIC% = , ' 
--	else set @Results = @Results + 'LIC% = ' + @TestValue + ', '
	
--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(ALY# * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'ALY# = , ' 
--	else set @Results = @Results + 'ALY# = ' + @TestValue + ', '

--	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(LIC# * 0.01), 2) from SampleInfoTable where ID = @ID)
--	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LIC# = , ' 
--	else set @Results = @Results + 'LIC# = ' + @TestValue + ', '
--end
 
--return @Results
--end

--go

------------------------------------------------------------------------------------------------------------------------------
---- print dbo.GetBC5300LabResults(3)
------------------------------------------------------------------------------------------------------------------------------

----------GetExternalLabResults-----------------------------------------------------------------------------------------------

--if exists (select * from sysobjects where name = 'uspGetExternalLabResults')
--	drop proc uspGetExternalLabResults
--go

--create proc uspGetExternalLabResults(
--@SourceCaption varchar(100),
--@StartDateTime smalldatetime,
--@EndDateTime smalldatetime,
--@SpecimenNo varchar(20) = null
--)with encryption as

--declare @ErrorMSG varchar(200)

--begin
--if (not (@SpecimenNo is null))
--begin
--	select dbo.FormatDate(InputDateTime) as TestDate, dbo.GetTime(InputDateTime) as TestTime,	
--	ID as SpecimenNo, PatientNo, dbo.GetFullName([Name],LastName) as FullName, 	
--	dbo.GetBC5300LabResults(ID) as Results
--	from SampleInfoTable 
--	where InputDateTime between @StartDateTime and @EndDateTime and PatientNo Like @SpecimenNo
--	order by InputDateTime desc
--	 end
--else

--	begin
--	select dbo.FormatDate(InputDateTime) as TestDate, dbo.GetTime(InputDateTime) as TestTime,	
--	ID as SpecimenNo, PatientNo, dbo.GetFullName([Name],LastName) as FullName, 	
--	dbo.GetBC5300LabResults(ID) as Results
--	from SampleInfoTable 
--	where InputDateTime between @StartDateTime and @EndDateTime
--	order by InputDateTime desc

--end
--end
--return 0


if exists (select * from sysobjects where name = 'GetBC5300LabResultsHB')
	drop function GetBC5300LabResultsHB
go

create function GetBC5300LabResultsHB(@ID varchar(40)) 
returns varchar(4000)
with encryption as
begin

declare @TestValue varchar(400)
declare @Results varchar(6000)
set @Results = ''

begin
					


	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Mon# * 0.01), 2) from SampleInfoTable where ID = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PCV = , ' 
	else set @Results = @Results + 'PCV = ' + @TestValue + ', '

	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(Eos# * 0.01), 2) from SampleInfoTable where ID = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Hb = , ' 
	else set @Results = @Results + 'Hb = ' + @TestValue + ', '

	
end
 
return @Results
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetBC5300LabResultsHB(3)
----------------------------------------------------------------------------------------------------------------------------

--------GetExternalLabResults-----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetExternalLabResultsHB')
	drop proc uspGetExternalLabResultsHB
go

create proc uspGetExternalLabResultsHB(
@SourceCaption varchar(100),
@StartDateTime smalldatetime,
@EndDateTime smalldatetime,
@SpecimenNo varchar(20) = null
)with encryption as

declare @ErrorMSG varchar(200)

begin
if (not (@SpecimenNo is null))
begin
	select dbo.FormatDate(InputDateTime) as TestDate, dbo.GetTime(InputDateTime) as TestTime,	
	ID as SpecimenNo, PatientNo, dbo.GetFullName([Name],LastName) as FullName, 	
	dbo.GetBC5300LabResultsHB(ID) as Results
	from SampleInfoTable 
	where InputDateTime between @StartDateTime and @EndDateTime and PatientNo Like @SpecimenNo
	order by InputDateTime desc
	 end
else

	begin
	select dbo.FormatDate(InputDateTime) as TestDate, dbo.GetTime(InputDateTime) as TestTime,	
	ID as SpecimenNo, PatientNo, dbo.GetFullName([Name],LastName) as FullName, 	
	dbo.GetBC5300LabResultsHB(ID) as Results
	from SampleInfoTable 
	where InputDateTime between @StartDateTime and @EndDateTime
	order by InputDateTime desc

end
end
return 0
-- comment: sp_password
go

/******************************************************************************************************
exec uspGetExternalLabResults '', '1 Nov 2013', '12 Jan 2014 10:02'

******************************************************************************************************/
