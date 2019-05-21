if exists (select * from sysobjects where name = 'uspInsertPhysicalStockCountDetails')
	drop proc uspInsertPhysicalStockCountDetails
go

create proc uspInsertPhysicalStockCountDetails(
@PSCNo varchar(20),
@LocationID  varchar(10),
@ItemCategoryID  varchar(10),
@ItemCode Varchar(20),
@SystemQuantity int,
@PhysicalCountQuantity int,
@Notes Varchar(200),
@LoginID Varchar(20),
@ClientMachine Varchar(20),
@RecordDateTime SmallDateTime
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select PSCNo from PhysicalStockCount where PSCNo  = @PSCNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'PSC No', @PSCNo, 'PhysicalStockCount')
		return 1
	end

if not exists(select DataID from LookUpData where DataID = @LocationID )
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Location ID ', @LocationID , 'Lookup Data')
		return 1
	end

if not exists(select DataID from LookUpData where DataID = @ItemCategoryID )
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Item CategoryI D ', @ItemCategoryID , 'Lookup Data')
		return 1
	end

if exists(select PSCNo from PhysicalStockCountDetails where PSCNo = @PSCNo and LocationID  = @LocationID  and ItemCategoryID  = @ItemCategoryID  and ItemCode = @ItemCode)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s and %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'PSC No', @PSCNo, 'Location ID ', @LocationID , 'Item CategoryI D ', @ItemCategoryID , 'General Notes', @ItemCode)
		return 1
	end



begin
insert into PhysicalStockCountDetails
(PSCNo, LocationID , ItemCategoryID , ItemCode, SystemQuantity, PhysicalCountQuantity,Notes, LoginID, ClientMachine, RecordDateTime)
values
(@PSCNo, @LocationID , @ItemCategoryID , @ItemCode, @SystemQuantity, @PhysicalCountQuantity,@Notes, @LoginID, @ClientMachine, @RecordDateTime)


if (dbo.GetOptionValue('EnableIntegrationN001') > 0)
begin
exec uspEditINTStockTake @ItemCode,@ItemCategoryID,@PhysicalCountQuantity
end

return 0
end
go
