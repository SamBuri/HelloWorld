USE smartlink;

drop procedure if exists uspGetExchangeFile;

DELIMITER $$
create procedure uspGetExchangeFile(PatientNo varchar(20), MacAddress varchar(20))

begin
  declare errorMessage varchar(200);
if not exists (select ID from exchange_locations where SL_ID = MacAddress order by ID desc limit 1) then
  begin
  
   set errorMessage = concat('No corresponding location found  this computer with MAC address ',MacAddress, ' with Smart Link');
  
   SIGNAL SQLSTATE '45000'
   SET MESSAGE_TEXT = errorMessage;
   end;
 else
  begin
   select exchange_files.ID, Global_ID, Admit_ID, Member_Nr, Location_ID, Smart_FIle, Smart_Date, InOut_Type, 
   Exchange_Type, SL_ID, SP_ID 
   from exchange_files 
   inner join exchange_locations on exchange_locations.ID =exchange_files.Location_ID
   where Progress_Flag in (1,3,2) and Member_Nr = PatientNo and SL_ID = MacAddress and date(Smart_Date) = CURDATE()
   order by Smart_Date desc limit 1;
 end;
end if;

end $$

-- call uspGetExchangeFile('P180035584', 'E442A65C0D28');uspGetExchangeFile