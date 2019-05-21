
------------------------------------------------ IsOPDReceiptNo ---------------------------------------------------------

if exists (select * from sysobjects where name = 'IsOPDReceiptNo')
drop function  IsOPDReceiptNo
go

create function IsOPDReceiptNo (@ReceiptNo varchar(20)) returns bit
with encryption as


begin
declare @IsOPD bit
declare @VisitTypeID varchar(10)
set @VisitTypeID = dbo.GetLookupDataID('VisitType','OPD')
begin
if exists((select TOP 1 (ReceiptNo) from Payments where ReceiptNo= @ReceiptNo and VisitTypeID =@VisitTypeID)) begin set @IsOPD=1 end
else begin set @IsOPD=0 end
end
return @IsOPD 
end
go

----------------------------------------------------------------------------------------------------------------------------
-- print dbo.IsOPDReceiptNo('x')
-- print dbo.IsOPDReceiptNo('1800000044')
-- print dbo.IsOPDReceiptNo('x')