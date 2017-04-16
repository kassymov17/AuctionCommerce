USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Category] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Category]([Id], [Name], [Description], [MetaKeywords], [MetaDescription], [MetaTitle], [ParentCategoryId], [PictureId], [PageSize], [AllowUsersToSelectPages], [PageSizeOptions], [PriceRanges], [ShowOnHomePage], [IncludeInTopMenu], [Published], [Deleted], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc])
SELECT 2, N'����������', NULL, NULL, NULL, NULL, 0, 1, 6, 1, N'6, 3, 9', NULL, 1, 1, 1, 0, 1, '20170407 00:00:00.000', '20170407 00:00:00.000' UNION ALL
SELECT 11, N'��������', NULL, NULL, NULL, NULL, 2, 11, 6, 1, N'6, 3, 9', NULL, 0, 1, 1, 0, 1, '20170407 00:00:00.000', '20170407 00:00:00.000' UNION ALL
SELECT 14, N'��������', NULL, NULL, NULL, NULL, 2, 14, 6, 1, N'6, 3, 9', NULL, 0, 1, 1, 0, 2, '20170407 00:00:00.000', '20170407 00:00:00.000' UNION ALL
SELECT 16, N'������', NULL, NULL, NULL, NULL, 0, 11, 6, 1, N'6, 3, 9', NULL, 1, 1, 1, 0, 2, '20170407 00:00:00.000', '20170407 00:00:00.000' UNION ALL
SELECT 17, N'���������', NULL, NULL, NULL, NULL, 0, 15, 6, 1, N'6, 3, 9', NULL, 1, 1, 1, 0, 3, '20170407 00:00:00.000', '20170407 00:00:00.000'
COMMIT;
RAISERROR (N'[dbo].[Category]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Category] OFF;

