USE smartlink;

DROP PROCEDURE IF EXISTS GetMACAddressExchangeLocation;

DELIMITER $$
CREATE PROCEDURE GetMACAddressExchangeLocation(mackAddress varchar(20), locationID int)
BEGIN
  select ID as locationID  from exchange_locations where SL_ID = mackAddress;
END $$

-- call GetMACAddressExchangeLocation('A0AFBD44782F',  1);