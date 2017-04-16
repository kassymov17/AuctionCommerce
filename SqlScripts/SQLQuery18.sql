USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[GenericAttribute] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[GenericAttribute]([Id], [EntityId], [KeyGroup], [Key], [Value])
SELECT 1, 6, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 2, 6, N'User', N'LanguageId', N'1' UNION ALL
SELECT 3, 7, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 4, 7, N'User', N'LanguageId', N'1' UNION ALL
SELECT 5, 8, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 6, 8, N'User', N'LanguageId', N'1' UNION ALL
SELECT 7, 9, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 8, 9, N'User', N'LanguageId', N'1'
COMMIT;
RAISERROR (N'[dbo].[GenericAttribute]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[GenericAttribute] OFF;

