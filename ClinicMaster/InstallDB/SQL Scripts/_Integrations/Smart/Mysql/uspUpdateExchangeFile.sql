USE smartlink;


DROP PROCEDURE IF EXISTS uspUpdateExchangeFile;

DELIMITER $$
CREATE PROCEDURE uspUpdateExchangeFile(_id int, exchangeFile blob, exchangeDate datetime)
BEGIN
  update exchange_files  set Progress_Flag = '2', Exchange_File = exchangeFile, Exchange_Date = exchangeDate
  where ID = _id;
END $$

/* call uspUpdateExchangeFile(1, null, now()); */