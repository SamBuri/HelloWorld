USE smartlink;


DROP PROCEDURE IF EXISTS uspUpdateResultFile;

DELIMITER $$
CREATE PROCEDURE uspUpdateResultFile(_id int, resultFile blob, resultDate datetime)
BEGIN
  update exchange_files  set Progress_Flag = 0, Result_File = resultFile, Result_Date = resultDate
  where ID = _id;
END $$

/* call uspUpdateResultFile(1, '23567890', now()) */