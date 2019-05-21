
use IPU
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

--------Function ConvertData--------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'ConvertData')
	drop function ConvertData
go

create function ConvertData(@Data as int, @Number as tinyint) returns varchar(200)
with encryption as

begin

	declare @NewData varchar(200)
	set @NewData = dbo.FormatNumber(cast(@Data as decimal(10, 2))/@Number, 2) 			

	return @NewData
	-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.ConvertData('8858', 10)
-- print dbo.ConvertData('788858', 10)
-- print dbo.ConvertData('788858', 100)
----------------------------------------------------------------------------------------------------------------------------

--------Function GetKX21NFullLabResults------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetKX21NFullLabResults')
	drop function GetKX21NFullLabResults
go

create function GetKX21NFullLabResults(@ResultID int) 
returns varchar(4000)
with encryption as
begin

declare @TestValue varchar(400)
declare @Results varchar(6000)
set @Results = ''

begin
					
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(WBC), 2) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'WBC: = , ' 
	else set @Results = @Results + 'WBC = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(RBC), 2) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RBC: = , ' 
	else set @Results = @Results + 'RBC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(HGB), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HGB: = , ' 
	else set @Results = @Results + 'HGB: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(HCT), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HCT: = , ' 
	else set @Results = @Results + 'HCT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MCV), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCV: = , ' 
	else set @Results = @Results + 'MCV: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MCH), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCH: = , ' 
	else set @Results = @Results + 'MCH: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MCHC), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCHC: = , ' 
	else set @Results = @Results + 'MCHC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(PLT), 0) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PLT: = , ' 
	else set @Results = @Results + 'PLT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(LYMP), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYM%: = , ' 
	else set @Results = @Results + 'LYM%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MXDP), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MXD%: = , ' 
	else set @Results = @Results + 'MXD%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(NEUTP), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT%: = , ' 
	else set @Results = @Results + 'NEUT%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(LYMH), 1) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYM#: = , ' 
	else set @Results = @Results + 'LYM#: = ' + @TestValue + ', ' 
	
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(MXDH), 2) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MXD#: = , ' 
	else set @Results = @Results + 'MXD#: = ' + @TestValue + ', ' 
		
	set @TestValue = (select dbo.FormatNumber(dbo.GetNumericResult(NEUTH), 2) from ResultsKX21N where ResultID = @ResultID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT#: = , ' 
	else set @Results = @Results + 'NEUT#: = ' + @TestValue + ', ' 
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO: = , ' 
	else set @Results = @Results + 'MONO: = ' + @TestValue + ', ' 
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EOSINO: = , ' 
	else set @Results = @Results + 'EOSINO: = ' + @TestValue + ', '
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO: = , ' 
	else set @Results = @Results + 'BASO: = ' + @TestValue + ', ' 
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO%: = , ' 
	else set @Results = @Results + 'MONO%: = ' + @TestValue + ', ' 
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EOSINO%: = , ' 
	else set @Results = @Results + 'EOSINO%: = ' + @TestValue + ', ' 
	
	set @TestValue = ''
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO%: = ' 
	else set @Results = @Results + 'BASO%: = ' + @TestValue

end
 
return @Results

end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetKX21NFullLabResults(3)
----------------------------------------------------------------------------------------------------------------------------

--------Function GetBC5380FullLabResults------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetBC5380FullLabResults')
	drop function GetBC5380FullLabResults
go

create function GetBC5380FullLabResults(@ID int) 
returns varchar(4000)
with encryption as
begin

declare @TestValue varchar(400)
declare @Results varchar(6000)
set @Results = ''

begin
				
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 5 or TestCodeId = 61) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'WBC: = , ' 
	else set @Results = @Results + 'WBC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 20 or TestCodeId = 76) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RBC: = , ' 
	else set @Results = @Results + 'RBC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 21 or TestCodeId = 77) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HGB: = , ' 
	else set @Results = @Results + 'HGB: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 27 or TestCodeId = 83) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HCT: = , ' 
	else set @Results = @Results + 'HCT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 22 or TestCodeId = 78) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCV: = , ' 
	else set @Results = @Results + 'MCV: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 23 or TestCodeId = 79) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCH: = , ' 
	else set @Results = @Results + 'MCH: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 24 or TestCodeId = 80) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCHC: = , ' 
	else set @Results = @Results + 'MCHC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 28 or TestCodeId = 84) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PLT: = , ' 
	else set @Results = @Results + 'PLT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 13 or TestCodeId = 69) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYM%: = , ' 
	else set @Results = @Results + 'LYM%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 0) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MXD%: = , ' 
	else set @Results = @Results + 'MXD%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 9 or TestCodeId = 65) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT%: = , ' 
	else set @Results = @Results + 'NEUT%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 12 or TestCodeId = 68) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYM#: = , ' 
	else set @Results = @Results + 'LYM#: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 0) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MXD#: = , ' 
	else set @Results = @Results + 'MXD#: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 8 or TestCodeId = 64) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT#: = , ' 
	else set @Results = @Results + 'NEUT#: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 14 or TestCodeId = 70) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO: = , ' 
	else set @Results = @Results + 'MONO: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 10 or TestCodeId = 66) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EOSINO: = , ' 
	else set @Results = @Results + 'EOSINO: = ' + @TestValue + ', '
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 6 or TestCodeId = 62) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO: = , ' 
	else set @Results = @Results + 'BASO: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 15 or TestCodeId = 71) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO%: = , ' 
	else set @Results = @Results + 'MONO%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 11 or TestCodeId = 67) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EOSINO%: = , ' 
	else set @Results = @Results + 'EOSINO%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBc5380 where (TestCodeId = 7 or TestCodeId = 63) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO%: = ' 
	else set @Results = @Results + 'BASO%: = ' + @TestValue

end
 
return @Results

end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetBC5380FullLabResults(3)
----------------------------------------------------------------------------------------------------------------------------

--------Function GetBS200FullLabResults------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetBS200FullLabResults')
	drop function GetBS200FullLabResults
go

create function GetBS200FullLabResults(@ID int) 
returns varchar(4000)
with encryption as
begin

declare @TestValue varchar(400)
declare @Results varchar(6000)
set @Results = ''

begin
				
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 1) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Total_cholesterol = , ' 
	else set @Results = @Results + 'Total_cholesterol = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 2) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Triglycerides = , ' 
	else set @Results = @Results + 'Triglycerides = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 3) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HDL_c = , ' 
	else set @Results = @Results + 'HDL_c = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 4) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LDL_c = , ' 
	else set @Results = @Results + 'LDL_c = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 5) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LDL_c/HDL_c_Ratio = , ' 
	else set @Results = @Results + 'LDL_c/HDL_c_Ratio = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 6) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'FASTING BLOOD SUGAR = , ' 
	else set @Results = @Results + 'FASTING BLOOD SUGAR = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 	
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 7) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Urea = , ' 
	else set @Results = @Results + 'Urea = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 8) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Creatinine_J = , ' 
	else set @Results = @Results + 'Creatinine_J = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 9) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'ALT = , ' 
	else set @Results = @Results + 'ALT = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 10) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'AST = , ' 
	else set @Results = @Results + 'AST = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 11) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'ALP = , ' 
	else set @Results = @Results + 'ALP = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 12) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'GGT = , ' 
	else set @Results = @Results + 'GGT = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 13) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Albumin = , ' 
	else set @Results = @Results + 'Albumin = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 14) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Calcium_(Arsenazo_III) = , ' 
	else set @Results = @Results + 'Calcium_(Arsenazo_III) = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 15) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Magnesium_ = , ' 
	else set @Results = @Results + 'Magnesium_ = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 16) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Chloride = , ' 
	else set @Results = @Results + 'Chloride = ' + dbo.FormatNumber(@TestValue, 2) + ', '
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 17) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Potassium = , ' 
	else set @Results = @Results + 'Potassium = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 18) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Sodium = , ' 
	else set @Results = @Results + 'Sodium = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 19) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Total Protein = , ' 
	else set @Results = @Results + 'Total Protein = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 20) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Bilirubin_Total = , ' 
	else set @Results = @Results + 'Bilirubin_Total = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 	
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 21) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Bilirubin_Direct = , ' 
	else set @Results = @Results + 'Bilirubin_Direct = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 22) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PH = , ' 
	else set @Results = @Results + 'PH = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 23) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Ionized_Calcium(ISE) = , ' 
	else set @Results = @Results + 'Ionized_Calcium(ISE) = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 24) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Neglect (Hb) = , ' 
	else set @Results = @Results + 'Neglect (Hb) = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
		
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 25) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Neglect (HbA1C) = , ' 
	else set @Results = @Results + 'Neglect (HbA1C) = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 26) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HBA1c. (Sub Test of HBA 1C) = , ' 
	else set @Results = @Results + 'HBA1c. (Sub Test of HBA 1C) = ' + dbo.FormatNumber(@TestValue, 2) + ', '
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 27) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Uric_acid = , ' 
	else set @Results = @Results + 'Uric_acid = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 28) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LDH_ = , ' 
	else set @Results = @Results + 'LDH_ = ' + dbo.FormatNumber(@TestValue, 2) + ', ' 
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 29) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'CK_Total = , ' 
	else set @Results = @Results + 'CK_Total = ' + dbo.FormatNumber(@TestValue, 2) + ', '
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 30) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Amylase_ = , ' 
	else set @Results = @Results + 'Amylase_ = ' + dbo.FormatNumber(@TestValue, 2) + ', '
	
	set @TestValue = (select top 1 Value from TestResultsBS200 where (TestCodeId = 37) and ResultId = @ID)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'Phosphorus_ = ' 
	else set @Results = @Results + 'Phosphorus_ = ' + dbo.FormatNumber(@TestValue, 2)

end
 
return @Results

end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetBS200FullLabResults(36)
----------------------------------------------------------------------------------------------------------------------------


--------Function GetDATA_TBLFullLabResults-----------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetDATA_TBLFullLabResults')
	drop function GetDATA_TBLFullLabResults
go

create function GetDATA_TBLFullLabResults(@Sequence_No int) 
returns varchar(4000)
with encryption as
begin

declare @TestValue varchar(400)
declare @Results varchar(6000)
set @Results = ''

begin
				
	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 0) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'WBC: = , ' 
	else set @Results = @Results + 'WBC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 1) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RBC: = , ' 
	else set @Results = @Results + 'RBC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 2) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HGB: = , ' 
	else set @Results = @Results + 'HGB: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 3) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'HCT: = , ' 
	else set @Results = @Results + 'HCT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 4) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCV: = , ' 
	else set @Results = @Results + 'MCV: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 5) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCH: = , ' 
	else set @Results = @Results + 'MCH: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 6) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MCHC: = , ' 
	else set @Results = @Results + 'MCHC: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 1) from DATA_TBL where (Test_CD = 7) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PLT: = , ' 
	else set @Results = @Results + 'PLT: = ' + @TestValue + ', ' 

	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 8) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RDW-SD = , ' 
	else set @Results = @Results + 'RDW-SD = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 9) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'RDW-CV = , ' 
	else set @Results = @Results + 'RDW-CV = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 10) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PDW: = , ' 
	else set @Results = @Results + 'PDW: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 11) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MPV: = , ' 
	else set @Results = @Results + 'MPV: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 12) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'P-LCR: = , ' 
	else set @Results = @Results + 'P-LCR: = ' + @TestValue + ', ' 

	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 13) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'PCT: = , ' 
	else set @Results = @Results + 'PCT: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 20) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT: = , ' 
	else set @Results = @Results + 'NEUT: = ' + @TestValue + ', ' 

	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 21) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYMPH: = , ' 
	else set @Results = @Results + 'LYMPH: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 22) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO: = , ' 
	else set @Results = @Results + 'MONO: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 23) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EO: = , ' 
	else set @Results = @Results + 'EO: = ' + @TestValue + ', '
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 100) from DATA_TBL where (Test_CD = 24) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO: = , ' 
	else set @Results = @Results + 'BASO: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 25) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'NEUT%: = , ' 
	else set @Results = @Results + 'NEUT%: = ' + @TestValue + ', ' 

	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 26) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'LYMPH%: = , ' 
	else set @Results = @Results + 'LYMPH%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 27) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'MONO%: = , ' 
	else set @Results = @Results + 'MONO%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 28) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'EO%: = , ' 
	else set @Results = @Results + 'EO%: = ' + @TestValue + ', ' 
	
	set @TestValue = (select top 1 dbo.ConvertData(Data, 10) from DATA_TBL where (Test_CD = 29) and Sequence_No = @Sequence_No)
	if @TestValue = '' or @TestValue is null set @Results = @Results + 'BASO%: = ' 
	else set @Results = @Results + 'BASO%: = ' + @TestValue

end
 
return @Results

end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetDATA_TBLFullLabResults(39065)
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

if (@SourceCaption = 'Sysmex KX-21N')
begin
	if (not (@SpecimenNo is null))
		begin
			select dbo.FormatDate([Date]) as TestDate, dbo.GetTime([Date]) as TestTime,	
			SampleID as SpecimenNo, '' as PatientNo, dbo.GetFullName('', '', '') as FullName,
			dbo.GetKX21NFullLabResults(ResultID) as Results
			from ResultsKX21N
			where [Date] between @StartDateTime and @EndDateTime and SampleID Like @SpecimenNo 
			order by [Date] desc	
		end
	else
		begin
			select dbo.FormatDate([Date]) as TestDate, dbo.GetTime([Date]) as TestTime,	
			SampleID as SpecimenNo, '' as PatientNo, dbo.GetFullName('', '', '') as FullName,
			dbo.GetKX21NFullLabResults(ResultID) as Results
			from ResultsKX21N
			where [Date] between @StartDateTime and @EndDateTime
			order by [Date] desc
		end
end
else if (@SourceCaption = 'Mindray BC 5380')
begin
	if (not (@SpecimenNo is null))
		begin
			select dbo.FormatDate([Timestamp]) as TestDate, dbo.GetTime([Timestamp]) as TestTime, 
			LabNo as SpecimenNo, PatientNo as PatientNo, 
			PatientName as FullName, dbo.GetBC5380FullLabResults(Id) as Results
			from ResultsBc5380
			where [Timestamp] between @StartDateTime and @EndDateTime and LabNo Like @SpecimenNo
			order by [Timestamp] desc	
		end
	else
		begin
			select dbo.FormatDate([Timestamp]) as TestDate, dbo.GetTime([Timestamp]) as TestTime, 
			LabNo as SpecimenNo, PatientNo as PatientNo, 
			PatientName as FullName, dbo.GetBC5380FullLabResults(Id) as Results
			from ResultsBc5380
			where [Timestamp] between @StartDateTime and @EndDateTime
			order by [Timestamp] desc
		end
end
else if (@SourceCaption = 'Mindray BS 200')
begin
	if (not (@SpecimenNo is null))
		begin
			select dbo.FormatDate([Timestamp]) as TestDate, dbo.GetTime([Timestamp]) as TestTime, 
			LabNo as SpecimenNo, PatientNo as PatientNo, 
			PatientName as FullName, dbo.GetBS200FullLabResults(Id) as Results
			from ResultsBS200
			where [Timestamp] between @StartDateTime and @EndDateTime and LabNo Like @SpecimenNo 
			order by [Timestamp] desc		
		end
	else
		begin
			select dbo.FormatDate([Timestamp]) as TestDate, dbo.GetTime([Timestamp]) as TestTime, 
			LabNo as SpecimenNo, PatientNo as PatientNo, 
			PatientName as FullName, dbo.GetBS200FullLabResults(Id) as Results
			from ResultsBS200
			where [Timestamp] between @StartDateTime and @EndDateTime
			order by [Timestamp] desc
		end
end
else if (@SourceCaption = 'SYMIX SX-1000i')
begin	
	if (not (@SpecimenNo is null))
		begin
			select dbo.FormatDate([TTime]) as TestDate, dbo.GetTime([TTime]) as TestTime, 
			Sample_No as SpecimenNo, Patient_ID as PatientNo, 
			dbo.GetFullName('', '', '') as FullName, dbo.GetDATA_TBLFullLabResults(Sequence_No) as Results
			from SAMPLE_TBL
			where [TTime] between @StartDateTime and @EndDateTime and Patient_ID Like @SpecimenNo 
			order by [TTime] desc		
		end
	else
		begin
			select dbo.FormatDate([TTime]) as TestDate, dbo.GetTime([TTime]) as TestTime, 
			Sample_No as SpecimenNo, Patient_ID as PatientNo, 
			dbo.GetFullName('', '', '') as FullName, dbo.GetDATA_TBLFullLabResults(Sequence_No) as Results
			from SAMPLE_TBL
			where [TTime] between @StartDateTime and @EndDateTime
			order by [TTime] desc
		end
end
return 0
-- comment: sp_password
go

/******************************************************************************************************
exec uspGetExternalLabResults 'Sysmex KX-21N', '1 Jan 2013', '10 Jan 2014 10:02'
exec uspGetExternalLabResults 'Sysmex KX-21N', '1 Jan 2013', '10 Jan 2014 10:02', '%30%'
exec uspGetExternalLabResults 'Mindray BC 5380', '1 Jan 2014', '15 Jan 2014 10:02'
exec uspGetExternalLabResults 'Mindray BC 5380', '1 Jan 2014', '15 Jan 2014 10:02', '%400%'
exec uspGetExternalLabResults 'Mindray BS 200', '1 Jan 2014', '15 Jan 2014 10:02'
exec uspGetExternalLabResults 'Mindray BS 200', '1 Jan 2014', '15 Jan 2014 10:02', '%2%'
exec uspGetExternalLabResults 'SYMIX SX-1000i', '1 Jun 2016', '15 Jun 2016 10:02'
exec uspGetExternalLabResults 'SYMIX SX-1000i', '1 Jan 2015', '15 Jan 2017 10:02', '%15074882%'


******************************************************************************************************/
