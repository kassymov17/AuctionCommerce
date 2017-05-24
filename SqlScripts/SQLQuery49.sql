USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Item_Category_Mapping] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Item_Category_Mapping]([Id], [ItemId], [CategoryId], [IsFeaturedItem], [DisplayOrder])
SELECT 1, 16, 3, 0, 1 UNION ALL
SELECT 2, 16, 12, 0, 1
COMMIT;
RAISERROR (N'[dbo].[Item_Category_Mapping]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Item_Category_Mapping] OFF;

