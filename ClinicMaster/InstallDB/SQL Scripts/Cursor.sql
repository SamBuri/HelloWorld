
--------run cursor below, but be very carefull--------------------------------------------------------------

declare @DrugNo varchar(20)
declare @DrugName varchar(100)
declare @OrderLevel int
declare @KeepingUnit int

DECLARE Drugs_Cursor INSENSITIVE CURSOR FOR

SELECT DrugNo FROM Drugs

OPEN Drugs_Cursor
FETCH NEXT FROM Drugs_Cursor INTO @DrugNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
		set @DrugName = (select DrugName from DrugTemp where DrugNo = @DrugNo)
		set @OrderLevel = (select OrderLevel from DrugTemp where DrugNo = @DrugNo)
		set @KeepingUnit = (select KeepingUnit from DrugTemp where DrugNo = @DrugNo)

		UPDATE Drugs Set DrugName = @DrugName WHERE DrugNo = @DrugNo and not @DrugName is null				
		UPDATE Drugs Set OrderLevel = @OrderLevel WHERE DrugNo = @DrugNo and not @OrderLevel is null				
		UPDATE Drugs Set KeepingUnit = @KeepingUnit  WHERE DrugNo = @DrugNo and not @KeepingUnit is null
		
		FETCH NEXT FROM Drugs_Cursor INTO @DrugNo
	END
CLOSE Drugs_Cursor
deallocate Drugs_Cursor


--------run cursor below, but be very carefull--------------------------------------------------------------

DECLARE @DrugNo VARCHAR(20)
DECLARE @UnitsInStock INT
DECLARE @TotalUnitsAtHand INT

DECLARE Drugs_Cursor INSENSITIVE CURSOR FOR
SELECT DrugNo FROM Drugs

OPEN Drugs_Cursor
FETCH NEXT FROM Drugs_Cursor INTO @DrugNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
		SET @TotalUnitsAtHand = (SELECT sum(UnitsAtHand) FROM InventoryLocation WHERE ItemCode = @DrugNo)
		
		UPDATE Inventory SET Balance = @TotalUnitsAtHand
		WHERE TranID = (SELECT MAX(TranID) FROM Inventory WHERE ItemCategoryID = '7D' and ItemCode = @DrugNo)			
		
		UPDATE Drugs SET UnitsInStock = @TotalUnitsAtHand WHERE DrugNo = @DrugNo 
		
		FETCH NEXT FROM Drugs_Cursor INTO @DrugNo
	END
CLOSE Drugs_Cursor
DEALLOCATE Drugs_Cursor


go

--------run cursor below, but be very carefull--------------------------------------------------------------
--------Updates VATValue for all itemsIncomes---------------------------------------------------------------
--------Should be run after updating the VATPercentage for setup billables otherwise, it would have no impact---------------------------------------------------------------

declare @VisitNo varchar(20)
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)
declare @ItemStatusID varchar(10)
declare @UnitPrice money
declare @Quantity int
declare @VATValue money


DECLARE VATValue_Cursor INSENSITIVE CURSOR FOR

SELECT VisitNo,ItemCategoryID, ItemCode, ItemStatusID  FROM Items
 

OPEN VATValue_Cursor
FETCH NEXT FROM VATValue_Cursor into @VisitNo,@ItemCategoryID,@ItemCode,@ItemStatusID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
	  set @VisitNo= (select VisitNo  FROM Items
       WHERE VisitNo=@VisitNo and ItemCategoryID=@ItemCategoryID and ItemCode=@ItemCode)
	   
	   set @ItemCategoryID= (select ItemCategoryID  FROM Items
       WHERE VisitNo=@VisitNo and ItemCategoryID=@ItemCategoryID and ItemCode=@ItemCode)
	   
	   set @ItemCode= (select ItemCode  FROM Items
	   WHERE VisitNo=@VisitNo and ItemCategoryID=@ItemCategoryID and ItemCode=@ItemCode)

	   set @ItemStatusID = (select ItemStatusID  FROM Items
       WHERE VisitNo=@VisitNo and ItemCategoryID=@ItemCategoryID and ItemCode=@ItemCode)
	   
	   set @UnitPrice= (select UnitPrice  FROM Items
       WHERE VisitNo=@VisitNo and ItemCategoryID=@ItemCategoryID and ItemCode=@ItemCode)

	   set @Quantity = (select Quantity  FROM Items
       WHERE VisitNo=@VisitNo and ItemCategoryID=@ItemCategoryID and ItemCode=@ItemCode)

	   set @VATValue = dbo.GetVATValue(@ItemCategoryID,@ItemCode,@ItemStatusID,@Quantity,@UnitPrice)
		

		UPDATE ItemsIncome Set VATValue = @VATValue
		WHERE VisitNo=@VisitNo and ItemCategoryID=@ItemCategoryID and ItemCode=@ItemCode 		
		
		FETCH NEXT FROM VATValue_Cursor into @VisitNo,@ItemCategoryID,@ItemCode,@ItemStatusID
	END
CLOSE VATValue_Cursor
deallocate VATValue_Cursor

go

--------run cursor below, but be very carefull-----------------------------------------------------------------------------
--------To be run once immediately after change the column VATPercent to TotalVAt. Converts VATPercent to TotalVAT for GoodsReceivedNote-----------------------------------------------
--------Run this cursor may cause significant changes to the system. Please run it only if you are sure

declare @GRNNo varchar(20)
declare @TotalVAT money
declare @DiscountTotal money
declare @GrossAmount money



DECLARE TotalVAT_Cursor INSENSITIVE CURSOR FOR

SELECT GRNNo FROM GoodsReceivedNote
 
OPEN TotalVAT_Cursor
FETCH NEXT FROM TotalVAT_Cursor into @GRNNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
	  set @DiscountTotal= (select DiscountTotal  FROM GoodsReceivedNote
       WHERE GRNNo= @GRNNo)
	   
	   set @TotalVAT= (select TotalVAT  FROM GoodsReceivedNote
       WHERE GRNNo= @GRNNo)
	   
	   set @GrossAmount= dbo.GetGoodsReceivedNoteTotalAmount(@GRNNo)

	   set @TotalVAT = ((@GrossAmount - @DiscountTotal) * @TotalVAT)/ 100
	   

		UPDATE GoodsReceivedNote Set TotalVAT = @TotalVAT
		WHERE GRNNo= @GRNNo and TotalVAT<100		
		
		FETCH NEXT FROM TotalVAT_Cursor into @GRNNo
	END
CLOSE TotalVAT_Cursor
deallocate TotalVAT_Cursor