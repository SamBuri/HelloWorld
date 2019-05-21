--------run cursor below, but be very carefull--------------------------------------------------------------
declare @IssuedID varchar(10)
declare @DrugCategoryID varchar(10)
declare @ConsumableCategoryID varchar(10)

---Replace with LocationID  you are to reset to Zero
declare @LocationID varchar(10) ='18901'
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)
declare @UnitsAtHand int
declare @TranDate smalldatetime
declare @ClientMachine varchar(40)
declare @Notes varchar(200)
set @Notes = 'Stock Issued To Reset Stock at '+dbo.GetLookupDataDes(@LocationID)
set @TranDate = dbo.GetShortDate(getdate())
set @ClientMachine = host_name()

DECLARE InventoryLocation_Cursor INSENSITIVE CURSOR FOR

select ItemCode, ItemCategoryID,UnitsAtHand
from InventoryLocation where LocationID =@LocationID and UnitsAtHand > 0

OPEN InventoryLocation_Cursor
FETCH NEXT FROM InventoryLocation_Cursor INTO @ItemCode, @ItemCategoryID,@UnitsAtHand
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

set @IssuedID = dbo.GetLookupDataID('StockType', 'I')

exec uspInsertInventory @LocationID,@ItemCategoryID,@ItemCode, @TranDate, @IssuedID, @UnitsAtHand, @Notes, '46MAN','Admin', @ClientMachine

FETCH NEXT FROM InventoryLocation_Cursor INTO @ItemCode, @ItemCategoryID,@UnitsAtHand 
	END
CLOSE InventoryLocation_Cursor
deallocate InventoryLocation_Cursor

-----------------------------------------------------------------------------------------------------------------------------------------------------
---select * from InventoryLocation where   LocationID ='117EYE PHA'