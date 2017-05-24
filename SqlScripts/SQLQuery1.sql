USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Category] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Category]([Id], [Name], [Description], [MetaKeywords], [MetaDescription], [MetaTitle], [ParentCategoryId], [PictureId], [PageSize], [AllowUsersToSelectPages], [PageSizeOptions], [PriceRanges], [ShowOnHomePage], [IncludeInTopMenu], [Published], [Deleted], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc])
SELECT 3, N'Электроника', N'Электроника', NULL, NULL, NULL, 0, 1, 6, 1, N'6, 3, 9', NULL, 0, 1, 1, 0, 1, '20170429 00:00:00.000', '20170429 00:00:00.000' UNION ALL
SELECT 8, N'Антиквариат', N'Антиквариат', NULL, NULL, NULL, 0, 2, 6, 1, N'6, 3, 9', NULL, 0, 1, 1, 0, 2, '20170429 00:00:00.000', '20170429 00:00:00.000' UNION ALL
SELECT 11, N'Украшения', N'Ювелирные украшения', NULL, NULL, NULL, 0, 3, 6, 1, N'6, 3, 9', NULL, 0, 1, 1, 0, 3, '20170429 00:00:00.000', '20170429 00:00:00.000' UNION ALL
SELECT 12, N'Компьютеры', N'Настольные компьютеры', NULL, NULL, NULL, 3, 4, 6, 1, N'6, 3, 9', NULL, 0, 1, 1, 0, 4, '20170429 00:00:00.000', '20170429 00:00:00.000' UNION ALL
SELECT 14, N'Телефоны', N'Мобильные телефоны', NULL, NULL, NULL, 3, 5, 6, 1, N'6, 3, 9', NULL, 0, 1, 1, 0, 0, '20170429 00:00:00.000', '20170429 00:00:00.000'
COMMIT;
RAISERROR (N'[dbo].[Category]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Category] OFF;

