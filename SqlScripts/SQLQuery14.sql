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
SELECT 8, 9, N'User', N'LanguageId', N'1' UNION ALL
SELECT 9, 10, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 10, 10, N'User', N'LanguageId', N'1' UNION ALL
SELECT 11, 11, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 12, 11, N'User', N'LanguageId', N'1' UNION ALL
SELECT 13, 12, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 14, 12, N'User', N'LanguageId', N'1' UNION ALL
SELECT 15, 13, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 16, 13, N'User', N'LanguageId', N'1' UNION ALL
SELECT 17, 14, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 18, 14, N'User', N'LanguageId', N'1' UNION ALL
SELECT 19, 15, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 20, 15, N'User', N'LanguageId', N'1' UNION ALL
SELECT 21, 16, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 22, 16, N'User', N'LanguageId', N'1' UNION ALL
SELECT 23, 17, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 24, 17, N'User', N'LanguageId', N'1' UNION ALL
SELECT 25, 18, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 26, 18, N'User', N'LanguageId', N'1' UNION ALL
SELECT 27, 19, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 28, 19, N'User', N'LanguageId', N'1' UNION ALL
SELECT 29, 20, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 30, 20, N'User', N'LanguageId', N'1'
COMMIT;
RAISERROR (N'[dbo].[GenericAttribute]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[GenericAttribute] OFF;

