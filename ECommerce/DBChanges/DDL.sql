USE [Ecommerce]
GO
/****** Object:  StoredProcedure [dbo].[SP_MANAGE_BRAND]    Script Date: 2017-05-26 2:42:40 AM ******/
ALTER TABLE [dbo].[tblProduct] Add ActualImage nvarchar(50)
ALTER TABLE [dbo].[tblProduct] Add ProductImage nvarchar(50)
