USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Item_Picture_Mapping] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Item_Picture_Mapping]([Id], [ItemId], [PictureId], [DisplayOrder])
SELECT 1, 4, 24, 1 UNION ALL
SELECT 2, 4, 25, 1 UNION ALL
SELECT 5, 10, 28, 1 UNION ALL
SELECT 6, 10, 29, 2
COMMIT;
RAISERROR (N'[dbo].[Item_Picture_Mapping]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Item_Picture_Mapping] OFF;

