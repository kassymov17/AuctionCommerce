USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Language] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Language]([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder])
SELECT 1, N'Русский', N'ru-RU', N'ru', N'rus.png', 1, 1
COMMIT;
RAISERROR (N'[dbo].[Language]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Language] OFF;

