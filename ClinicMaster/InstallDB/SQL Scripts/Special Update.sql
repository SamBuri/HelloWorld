
------------------------------------------------------------------------------------------------------
-------------- Options -------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------

-------------- Edit Options ------------------------------------------------------------------------

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

--------Function Get Full Name----------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetFullName')
	drop function GetFullName
go

create function GetFullName(@LastName varchar(30), @MiddleName varchar(30), @FirstName varchar(30)) returns varchar(100)
with encryption as

begin

declare @FullName varchar(100)

if (@MiddleName is null or @MiddleName = '')

begin	
	set @FullName = @LastName + ' ' + @FirstName
end
else

if not (@MiddleName is null or @MiddleName = '')
begin	
	set @FullName = @LastName + ' ' + @MiddleName + ' ' + @FirstName
end

return @FullName
-- comment: sp_password
end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.GetFullName('Wilson', 'Kutegeka', null)
-- print dbo.GetFullName('Wilson', 'Kutegeka', 'Kateeba')
----------------------------------------------------------------------------------------------------------------------------


---------LabTestsEXT-------------------------------------------

select * from LabTestsEXT where TestCode = 'T001'
go

update LabTestsEXT set SortOrder = 1
where TestCode = 'T001' and SubTestCode = 'GR%'

update LabTestsEXT set SortOrder = 2
where TestCode = 'T001' and SubTestCode = 'GRA'

update LabTestsEXT set SortOrder = 3
where TestCode = 'T001' and SubTestCode = 'HB'

update LabTestsEXT set SortOrder = 4
where TestCode = 'T001' and SubTestCode = 'HCT'

update LabTestsEXT set SortOrder = 5
where TestCode = 'T001' and SubTestCode = 'LY%'

update LabTestsEXT set SortOrder = 6
where TestCode = 'T001' and SubTestCode = 'LYM'

update LabTestsEXT set SortOrder = 7
where TestCode = 'T001' and SubTestCode = 'MCH'

update LabTestsEXT set SortOrder = 8
where TestCode = 'T001' and SubTestCode = 'MCHC'

update LabTestsEXT set SortOrder = 9
where TestCode = 'T001' and SubTestCode = 'MCV'

update LabTestsEXT set SortOrder = 10
where TestCode = 'T001' and SubTestCode = 'MON'

update LabTestsEXT set SortOrder = 11
where TestCode = 'T001' and SubTestCode = 'MON%'

update LabTestsEXT set SortOrder = 12
where TestCode = 'T001' and SubTestCode = 'MPV'

update LabTestsEXT set SortOrder = 13
where TestCode = 'T001' and SubTestCode = 'PCT'

update LabTestsEXT set SortOrder = 14
where TestCode = 'T001' and SubTestCode = 'PDWC'

update LabTestsEXT set SortOrder = 15
where TestCode = 'T001' and SubTestCode = 'PLT'

update LabTestsEXT set SortOrder = 16
where TestCode = 'T001' and SubTestCode = 'RBC'

update LabTestsEXT set SortOrder = 17
where TestCode = 'T001' and SubTestCode = 'RDWC'

update LabTestsEXT set SortOrder = 18
where TestCode = 'T001' and SubTestCode = 'WBC'


--------------------------------------------------------------------------------------------------------


select * from Visits
where VisitStatusID = '9DR' and VisitDate < 'apr 1 2011'
go

update Visits set VisitStatusID = '9CO'
where VisitStatusID = '9DR' and VisitDate < 'apr 1 2011'
go


------ Copy drugs price update script from here ------
------ This Script applies 5% increment on the price of Drugs -----
------ Make sure that this script is run only once -------
------ if run more than once it will apply 5% increament the number of times run ------

use ClinicMaster
go

update Drugs set UnitPrice = 1.05 * UnitPrice

--- Update scrip ends here-------------------


--------Function GetChange -------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'GetChange')
	drop function GetChange
go

create function GetChange(@TotalBill money, @AmountTendered money, @ExchangeRate money) returns money
with encryption as

begin

declare @Change money

if @TotalBill <= 0 or @AmountTendered <= 0 or @ExchangeRate <= 0 set @Change = 0.00
else begin set @Change = @AmountTendered * @ExchangeRate - @TotalBill end

set @Change = isnull(@Change, 0.00)

return @Change

end

go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.FormatMoney(dbo.GetChange(900,1800,2))
----------------------------------------------------------------------------------------------------------------------------

--------run cursor below, but be very carefull and run it only once, it may take awhile to complete-------------------------

DECLARE @PatientNo VARCHAR(20)
DECLARE Patients_Cursor INSENSITIVE CURSOR FOR

SELECT PatientNo FROM Patients

OPEN Patients_Cursor
FETCH NEXT FROM Patients_Cursor INTO @PatientNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
			
		UPDATE Patients SET FirstVisitDate = dbo.GetFirstVisitDate(@PatientNo) WHERE PatientNo = @PatientNo									
		UPDATE Patients SET LastVisitDate = dbo.GetLastVisitDate(@PatientNo)  WHERE PatientNo = @PatientNo 				
		UPDATE Patients SET TotalVisits = dbo.GetTotalVisits(@PatientNo)  WHERE PatientNo = @PatientNo 				
		
		FETCH NEXT FROM Patients_Cursor INTO @PatientNo
	END
CLOSE Patients_Cursor
DEALLOCATE Patients_Cursor



select distinct DistrictsID, dbo.GetLookupDataDes(DistrictsID) as District
		from HealthUnits
		
exec uspInsertLookupData '51302', 51, 'APAC.','N'
exec uspInsertLookupData '51303', 51, 'ARUA.','N'
exec uspInsertLookupData '51201', 51, 'BUGIRI.','N'
exec uspInsertLookupData '51401', 51, 'BUNDIBUGYO.','N'
exec uspInsertLookupData '51402', 51, 'BUSHENYI.','N'
exec uspInsertLookupData '51202', 51, 'BUSIA.','N'
exec uspInsertLookupData '51304', 51, 'GULU.','N'
exec uspInsertLookupData '51403', 51, 'HOIMA.','N'
exec uspInsertLookupData '51204', 51, 'JINJA.','N'
exec uspInsertLookupData '51102', 51, 'KAMPALA.','N'
exec uspInsertLookupData '51406', 51, 'KASESE.','N'
exec uspInsertLookupData '51112', 51, 'KAYUNGA.','N'
exec uspInsertLookupData '51305', 51, 'KITGUM.','N'
exec uspInsertLookupData '51208', 51, 'KUMI.','N'
exec uspInsertLookupData '51307', 51, 'LIRA.','N'
exec uspInsertLookupData '51105', 51, 'MASAKA.','N'
exec uspInsertLookupData '51410', 51, 'MBARARA.','N'
exec uspInsertLookupData '51308', 51, 'MOROTO.','N'
exec uspInsertLookupData '51108', 51, 'MUKONO.','N'
exec uspInsertLookupData '51312', 51, 'PADER.','N'
exec uspInsertLookupData '51210', 51, 'PALLISA.','N'
exec uspInsertLookupData '51412', 51, 'RUKUNGIRI.','N'
exec uspInsertLookupData '51211', 51, 'SOROTI.','N'

-----------------------------------------------------------------------------------------------
-------------Reset  Inventory------------------------------------------------------------------
-----------------------------------------------------------------------------------------------

select * from drugs
select * from ConsumableItems

select * from InventoryLocation

select * from Inventory
select * from InventoryReceiving

--------------------------------------------------------------------------
delete from Inventory
delete from InventoryLocation

update drugs set UnitsInStock = 0
update ConsumableItems set UnitsInStock = 0

--------------------------------------------------------------------------

alter table InventoryReceiving drop constraint fkTranIDInventoryReceiving

truncate table Inventory

alter table InventoryReceiving 
add constraint fkTranIDInventoryReceiving foreign key (TranID) references Inventory (TranID)
on delete cascade on update cascade 

-----------------------------------------------------------------------------------------------
