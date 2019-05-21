USE smartlink;

DROP PROCEDURE IF EXISTS uspGetExchangeFileByID;

DELIMITER $$
CREATE PROCEDURE uspGetExchangeFileByID(_ID int)
BEGIN
select exchange_files.ID, Global_ID, Admit_ID, Member_Nr, Location_ID, Smart_FIle, Smart_Date, InOut_Type, 
Exchange_Type, SL_ID, SP_ID, Progress_Flag 
from exchange_files 
inner join exchange_locations on exchange_locations.ID =exchange_files.Location_ID
where exchange_files.ID = _ID;
END $$

-- call uspGetExchangeFileByID(3);