-------------- Get AllAllRefundDetails -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetAllRefundDetails')
	drop proc uspGetAllRefundDetails
go

create proc uspGetAllRefundDetails(
@RefundNo Varchar(20)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select RefundNo from RefundDetails where RefundNo = @RefundNo )
	begin
		set @ErrorMSG = 'The record with %s: %s , you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Refund No', @RefundNo, 'Refunds')
		return 1
	end
else
begin
	select dbo.GetRefundVisitNo(RefundDetails.ReceiptNo) as VisitNo,RefundNo,ReceiptNo, ItemCategoryID, ItemCode, Quantity, UnitPrice, ReturnReasonID, 
	dbo.GetLookupDataDes(ReturnReasonID) as [ReturnReason],RefundDetails.LoginID, dbo.GetItemName(ItemCategoryID, ItemCode) as ItemName,
	 dbo.GetPatientFullNameWithReceiptNo(ReceiptNo) as FullName,dbo.FormatDate(dbo.GetReceiptRecordDateTime(RefundDetails.ReceiptNo)) as PayDate,
	RefundDetails.ClientMachine, RefundDetails.RecordDateTime,(Quantity * UnitPrice) as Amount,dbo.IsOPDReceiptNo(ReceiptNo) as ReceiptType
	from RefundDetails
	--inner join Payments on Payments.ReceiptNo =RefundDetails.ReceiptNo
	where RefundNo = @RefundNo
return 0
end
go

-----------------------------------------------------------------------------------------------------------------------


/******************************************************************************************************
exec uspGetAllRefundDetails ''
exec uspGetAllRefundDetails '180000006001'
exec uspGetAllRefundDetails '160001097301'
******************************************************************************************************/