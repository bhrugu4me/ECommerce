USE [Ecommerce]
GO
/****** Object:  StoredProcedure [dbo].[SP_MANAGE_BRAND]    Script Date: 2017-05-26 2:42:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_MANAGE_BRAND]
@action Varchar(50),
@BrandId int=0,
@BrandName nvarchar(100)='',
@Description nvarchar(100)='',
@requestedby nvarchar(10)=''
as
begin
	if @action='INSERT'
	begin
		INSERT INTO tblBrand (BrandName,[Description],InsertedBy,InsertedOn,UpdatedOn,UpdatedBy) 
		VALUES (@BrandName,@Description,@requestedby,GETDATE(),GETDATE(), @requestedby);

		SELECT @@IDENTITY;
	end
	else if @action='UPDATE'
	begin
		UPDATE tblBrand SET
		BrandName=@BrandName,[Description]=@Description,UpdatedOn=getdate(),UpdatedBy=@requestedby WHERE BrandId=@BrandId

		SELECT @BrandId;
	end
	else if @action='GETALL'
	begin
		select BrandId,BrandName,[Description],InsertedBy,InsertedOn,UpdatedOn,UpdatedBy from tblBrand
	end
	else if @action='GETBYID'
	begin
		select BrandId,BrandName,[Description],InsertedBy,InsertedOn,UpdatedOn,UpdatedBy from tblBrand where BrandId=@BrandId
	end
	else if @action ='DELETE'
	begin
	delete FROM tblBrand WHERE  BrandId=@BrandId;
	select @BrandId;
	end
end