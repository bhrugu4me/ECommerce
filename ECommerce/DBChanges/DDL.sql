USE [Ecommerce]
GO
/****** Object:  StoredProcedure [dbo].[SP_MANAGE_BRAND]    Script Date: 2017-05-26 2:42:40 AM ******/
ALTER TABLE [dbo].[tblProduct] Add ActualImage nvarchar(50)
ALTER TABLE [dbo].[tblProduct] Add ProductImage nvarchar(50)

USE [Ecommerce]
GO
/****** Object:  StoredProcedure [dbo].[SP_MANAGE_PRODUCT]    Script Date: 2017-06-01 5:25:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	ALTER PROCEDURE [dbo].[SP_MANAGE_PRODUCT]
	@action varchar(50),
	@productid int=0,
	@productname nvarchar(100)='',
	@categaryid nvarchar(10)='',
	@subcategaryid nvarchar(10)='',
	@description nvarchar(500)='',
	@sellerid nvarchar(10)='',
	@productimage nvarchar(50)='',
	@actualimage nvarchar(50)='',
	@sellerdescr nvarchar(500)='',
	@requestedby nvarchar(10)=''
	as
	begin
		if @action='INSERT'
	begin
	insert into tblProduct(ProductName,ProductImage,ActualImage,SubCategaryId,Description,SellerId,SellerDescr,InsertedOn,InsertedBy,UpdatedOn,UpdatedBy)
	values
	(@productname,@productimage,@actualimage,@categaryid,@subcategaryid,@description,@sellerid,@sellerdescr,GETDATE(),@requestedby,GETDATE(),@requestedby);

	select @@IDENTITY
	end
	else if @action='UPDATE'
	begin
	update tblProduct
	set ProductName=@productname,
	CategaryId=@categaryid,
	SubCategaryId=@subcategaryid,
	Description=@description,
	SellerId=@sellerid,
	SellerDescr=@sellerdescr,
	ProductImage=@productimage,
	ActualImage=@actualimage,
	UpdatedOn=GETDATE(),
	UpdatedBy=@requestedby
	where
	ProductId=@productid;

		select @productimage;

		end
	else if @action='GETALL'
	begin
	select ProductId,ProductName,ProductImage,ActualImage,CategaryId,SubCategaryId,Description,SellerId,SellerDescr,InsertedOn,InsertedBy,UpdatedOn,UpdatedBy from tblProduct

		end
else if @action='GETBYID'
		begin
	select ProductId,ProductName,ProductImage,ActualImage,CategaryId,SubCategaryId,Description,SellerId,SellerDescr,InsertedOn,InsertedBy,UpdatedOn,UpdatedBy from tblProduct
	where ProductId=@productid

	end
else if @action='GETBYCAT'
		begin
	select ProductId,ProductName,ProductImage,ActualImage,CategaryId,SubCategaryId,Description,SellerId,SellerDescr,InsertedOn,InsertedBy,UpdatedOn,UpdatedBy from tblProduct
	where CategaryId=@CategaryId

	end

else if @action='delete'
		begin
	delete from tblProduct where ProductId=@productid
	end
end
