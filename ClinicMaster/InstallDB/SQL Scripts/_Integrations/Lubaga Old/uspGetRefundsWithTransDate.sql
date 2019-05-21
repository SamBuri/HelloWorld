--------GetRefundsWithTransDate----------------------------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspGetRefundsWithTransDate')
	drop proc uspGetRefundsWithTransDate
go

create proc uspGetRefundsWithTransDate(
@RefundNo varchar(20) = null,
@StartDateTime date = null,
@EndDateTime smalldatetime = null,
@LoginID varchar(20) = null,
@BranchID varchar(10) = null
)with encryption as

declare @ErrorMSG varchar(200)

if not (@RefundNo is null) and (@StartDateTime is null) and (@EndDateTime is null) and (@LoginID is null) and (@BranchID is null)
	begin
		if not exists(select RefundNo from Refunds where RefundNo = @RefundNo)
			begin
				set @ErrorMSG = 'The record with %s: %s, you are trying to enter does not exist in the registered %s'
				raiserror(@ErrorMSG, 16, 1, 'Refund No', @RefundNo, 'Refunds')
				return 1
			end
		else
			begin
				select dbo.FormatText(RefundNo, 'Refunds', 'RefundNo') as RefundNo, 
				dbo.FormatText(Refunds.ReceiptNo, 'Payments', 'ReceiptNo') as ReceiptNo,RefundRequestNo,
				dbo.FormatDate(PayDate) as PayDate, dbo.FormatDate(RefundDate) as RefundDate, 
				dbo.GetPayeeName(PayTypeID, PayNo) as PayeeName,dbo.GetLookupDataDes(Refunds.BranchID) as BranchName,
				dbo.GetAmountPaid(PayTypeID, VisitTypeID, Refunds.ReceiptNo) as AmountPaid, 
				dbo.FormatMoney(Amount) as Amount, Refunds.AmountWords, Refunds.Notes, 
				Refunds.LoginID, dbo.FormatDate(Refunds.RecordDateTime) as RecordDate, 
				dbo.GetTime(Refunds.RecordDateTime) as RecordTime
				from Refunds
				inner join Payments on Refunds.ReceiptNo = Payments.ReceiptNo
				where RefundNo = @RefundNo
			end
	end	
else if (@RefundNo is null) and not(@StartDateTime is null) and not(@EndDateTime is null) and (@LoginID is null) and (@BranchID is null)
	begin
		select dbo.FormatText(RefundNo, 'Refunds', 'RefundNo') as RefundNo, 
		dbo.FormatText(Refunds.ReceiptNo, 'Payments', 'ReceiptNo') as ReceiptNo,RefundRequestNo,
		dbo.FormatDate(PayDate) as PayDate, dbo.FormatDate(RefundDate) as RefundDate, 
		dbo.GetPayeeName(PayTypeID, PayNo) as PayeeName,dbo.GetLookupDataDes(Refunds.BranchID) as BranchName,	
		dbo.GetAmountPaid(PayTypeID, VisitTypeID, Refunds.ReceiptNo) as AmountPaid, 
		dbo.FormatMoney(Amount) as Amount, Refunds.AmountWords, Refunds.Notes, 
		Refunds.LoginID, dbo.FormatDate(Refunds.RecordDateTime) as RecordDate, 
		dbo.GetTime(Refunds.RecordDateTime) as RecordTime
		from Refunds
		inner join Payments on Refunds.ReceiptNo = Payments.ReceiptNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime
		order by RefundDate
	end
else if (@RefundNo is null) and (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null) and not(@LoginID is null)
	begin
		select dbo.FormatText(RefundNo, 'Refunds', 'RefundNo') as RefundNo, 
		dbo.FormatText(Refunds.ReceiptNo, 'Payments', 'ReceiptNo') as ReceiptNo,RefundRequestNo,
		dbo.FormatDate(PayDate) as PayDate, dbo.FormatDate(RefundDate) as RefundDate, 
		dbo.GetPayeeName(PayTypeID, PayNo) as PayeeName,dbo.GetLookupDataDes(Refunds.BranchID) as BranchName,	
		dbo.GetAmountPaid(PayTypeID, VisitTypeID, Refunds.ReceiptNo) as AmountPaid, 
		dbo.FormatMoney(Amount) as Amount, Refunds.AmountWords, Refunds.Notes, 
		Refunds.LoginID, dbo.FormatDate(Refunds.RecordDateTime) as RecordDate, 
		dbo.GetTime(Refunds.RecordDateTime) as RecordTime
		from Refunds
		inner join Payments on Refunds.ReceiptNo = Payments.ReceiptNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and Refunds.LoginID = @LoginID
		order by RefundDate
	end

	else if (@RefundNo is null) and (@LoginID is null) and not (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null)
	begin
		select dbo.FormatText(RefundNo, 'Refunds', 'RefundNo') as RefundNo, 
		dbo.FormatText(Refunds.ReceiptNo, 'Payments', 'ReceiptNo') as ReceiptNo,
		dbo.FormatDate(PayDate) as PayDate, dbo.FormatDate(RefundDate) as RefundDate, 
		dbo.GetPayeeName(PayTypeID, PayNo) as PayeeName,dbo.GetLookupDataDes(Refunds.BranchID) as BranchName,	
		dbo.GetAmountPaid(PayTypeID, VisitTypeID, Refunds.ReceiptNo) as AmountPaid, 
		dbo.FormatMoney(Amount) as Amount, Refunds.AmountWords, Refunds.Notes, 
		Refunds.LoginID, dbo.FormatDate(Refunds.RecordDateTime) as RecordDate, 
		dbo.GetTime(Refunds.RecordDateTime) as RecordTime
		from Refunds
		inner join Payments on Refunds.ReceiptNo = Payments.ReceiptNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and Refunds.BranchID = @BranchID
		order by RefundDate
	end

	else if (@RefundNo is null) and not (@BranchID is null) and not(@StartDateTime is null) and not(@EndDateTime is null) and not(@LoginID is null)
	begin
		select dbo.FormatText(RefundNo, 'Refunds', 'RefundNo') as RefundNo, 
		dbo.FormatText(Refunds.ReceiptNo, 'Payments', 'ReceiptNo') as ReceiptNo,
		dbo.FormatDate(PayDate) as PayDate, dbo.FormatDate(RefundDate) as RefundDate, 
		dbo.GetPayeeName(PayTypeID, PayNo) as PayeeName,dbo.GetLookupDataDes(Refunds.BranchID) as BranchName,	
		dbo.GetAmountPaid(PayTypeID, VisitTypeID, Refunds.ReceiptNo) as AmountPaid, 
		dbo.FormatMoney(Amount) as Amount, Refunds.AmountWords, Refunds.Notes, 
		Refunds.LoginID, dbo.FormatDate(Refunds.RecordDateTime) as RecordDate, 
		dbo.GetTime(Refunds.RecordDateTime) as RecordTime
		from Refunds
		inner join Payments on Refunds.ReceiptNo = Payments.ReceiptNo
		where Payments.RecordDateTime between @StartDateTime and @EndDateTime and Refunds.LoginID = @LoginID and Refunds.BranchID = @BranchID
		order by RefundDate
	end

else 
	begin
		select dbo.FormatText(RefundNo, 'Refunds', 'RefundNo') as RefundNo, 
		dbo.FormatText(Refunds.ReceiptNo, 'Payments', 'ReceiptNo') as ReceiptNo,RefundRequestNo,
		dbo.FormatDate(PayDate) as PayDate, dbo.FormatDate(RefundDate) as RefundDate, 
		dbo.GetPayeeName(PayTypeID, PayNo) as PayeeName,dbo.GetLookupDataDes(Refunds.BranchID) as BranchName,	
		dbo.GetAmountPaid(PayTypeID, VisitTypeID, Refunds.ReceiptNo) as AmountPaid, 
		dbo.FormatMoney(Amount) as Amount, Refunds.Notes, Refunds.AmountWords, 
		Refunds.LoginID, dbo.FormatDate(Refunds.RecordDateTime) as RecordDate, 
		dbo.GetTime(Refunds.RecordDateTime) as RecordTime
		from Refunds
		inner join Payments on Refunds.ReceiptNo = Payments.ReceiptNo
	end	
return 0
go


--exec uspGetRefundsWithTransDate '1301035001'
--exec uspGetRefundsWithTransDate null, '10 Mar 2013', '11 Mar 2013'
--exec uspGetRefundsWithTransDate null, '05 Mar 2013', '11 Mar 2013', 'Admin'
--exec uspGetRefundsWithTransDate