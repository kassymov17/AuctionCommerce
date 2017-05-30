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
SELECT 30, 20, N'User', N'LanguageId', N'1' UNION ALL
SELECT 31, 21, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 32, 21, N'User', N'LanguageId', N'1' UNION ALL
SELECT 33, 22, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 34, 22, N'User', N'LanguageId', N'1' UNION ALL
SELECT 35, 23, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 36, 23, N'User', N'LanguageId', N'1' UNION ALL
SELECT 37, 24, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 38, 24, N'User', N'LanguageId', N'1' UNION ALL
SELECT 39, 25, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 40, 25, N'User', N'LanguageId', N'1' UNION ALL
SELECT 41, 25, N'User', N'FirstName', N'Еламан' UNION ALL
SELECT 42, 25, N'User', N'LastName', N'Касымов' UNION ALL
SELECT 43, 26, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 44, 26, N'User', N'LanguageId', N'1' UNION ALL
SELECT 45, 26, N'User', N'FirstName', N'qwerty' UNION ALL
SELECT 46, 26, N'User', N'LastName', N'qwerty' UNION ALL
SELECT 47, 27, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 48, 27, N'User', N'LanguageId', N'1' UNION ALL
SELECT 49, 27, N'User', N'FirstName', N'qwerty' UNION ALL
SELECT 50, 27, N'User', N'LastName', N'qwerty'
COMMIT;
RAISERROR (N'[dbo].[GenericAttribute]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[GenericAttribute]([Id], [EntityId], [KeyGroup], [Key], [Value])
SELECT 51, 28, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 52, 28, N'User', N'LanguageId', N'1' UNION ALL
SELECT 53, 28, N'User', N'FirstName', N'Пример' UNION ALL
SELECT 54, 28, N'User', N'LastName', N'Примеров' UNION ALL
SELECT 55, 29, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 56, 29, N'User', N'LanguageId', N'1' UNION ALL
SELECT 57, 30, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 58, 30, N'User', N'LanguageId', N'1' UNION ALL
SELECT 59, 31, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 60, 31, N'User', N'LanguageId', N'1' UNION ALL
SELECT 61, 31, N'User', N'FirstName', N'Иванов' UNION ALL
SELECT 62, 31, N'User', N'LastName', N'Иван' UNION ALL
SELECT 63, 32, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 64, 32, N'User', N'LanguageId', N'1' UNION ALL
SELECT 65, 33, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 66, 33, N'User', N'LanguageId', N'1' UNION ALL
SELECT 67, 34, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 68, 34, N'User', N'LanguageId', N'1' UNION ALL
SELECT 69, 35, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 70, 35, N'User', N'LanguageId', N'1' UNION ALL
SELECT 71, 36, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 72, 36, N'User', N'LanguageId', N'1' UNION ALL
SELECT 73, 37, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 74, 37, N'User', N'LanguageId', N'1' UNION ALL
SELECT 75, 38, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 76, 38, N'User', N'LanguageId', N'1' UNION ALL
SELECT 77, 39, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 78, 39, N'User', N'LanguageId', N'1' UNION ALL
SELECT 79, 40, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 80, 40, N'User', N'LanguageId', N'1' UNION ALL
SELECT 81, 41, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 82, 41, N'User', N'LanguageId', N'1' UNION ALL
SELECT 83, 42, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 84, 42, N'User', N'LanguageId', N'1' UNION ALL
SELECT 85, 43, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 86, 43, N'User', N'LanguageId', N'1' UNION ALL
SELECT 87, 44, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 88, 44, N'User', N'LanguageId', N'1' UNION ALL
SELECT 89, 45, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 90, 45, N'User', N'LanguageId', N'1' UNION ALL
SELECT 91, 46, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 92, 46, N'User', N'LanguageId', N'1' UNION ALL
SELECT 93, 47, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 94, 47, N'User', N'LanguageId', N'1' UNION ALL
SELECT 95, 48, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 96, 48, N'User', N'LanguageId', N'1' UNION ALL
SELECT 97, 49, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 98, 49, N'User', N'LanguageId', N'1' UNION ALL
SELECT 99, 50, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 100, 50, N'User', N'LanguageId', N'1'
COMMIT;
RAISERROR (N'[dbo].[GenericAttribute]: Insert Batch: 2.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[GenericAttribute]([Id], [EntityId], [KeyGroup], [Key], [Value])
SELECT 101, 51, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 102, 51, N'User', N'LanguageId', N'1' UNION ALL
SELECT 103, 52, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 104, 52, N'User', N'LanguageId', N'1' UNION ALL
SELECT 105, 53, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 106, 53, N'User', N'LanguageId', N'1' UNION ALL
SELECT 107, 54, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 108, 54, N'User', N'LanguageId', N'1' UNION ALL
SELECT 109, 55, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 110, 55, N'User', N'LanguageId', N'1' UNION ALL
SELECT 111, 56, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 112, 56, N'User', N'LanguageId', N'1' UNION ALL
SELECT 113, 57, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 114, 57, N'User', N'LanguageId', N'1' UNION ALL
SELECT 115, 58, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 116, 58, N'User', N'LanguageId', N'1' UNION ALL
SELECT 117, 59, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 118, 59, N'User', N'LanguageId', N'1' UNION ALL
SELECT 119, 60, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 120, 60, N'User', N'LanguageId', N'1' UNION ALL
SELECT 121, 62, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 122, 62, N'User', N'LanguageId', N'1' UNION ALL
SELECT 123, 63, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 124, 63, N'User', N'LanguageId', N'1' UNION ALL
SELECT 125, 64, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 126, 64, N'User', N'LanguageId', N'1' UNION ALL
SELECT 127, 64, N'User', N'Gender', N'M' UNION ALL
SELECT 128, 64, N'User', N'FirstName', N'Новый пользователь' UNION ALL
SELECT 129, 64, N'User', N'LastName', N'Пользователь' UNION ALL
SELECT 130, 65, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 131, 65, N'User', N'LanguageId', N'1' UNION ALL
SELECT 132, 66, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 133, 66, N'User', N'LanguageId', N'1' UNION ALL
SELECT 134, 67, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 135, 67, N'User', N'LanguageId', N'1' UNION ALL
SELECT 136, 68, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 137, 68, N'User', N'LanguageId', N'1' UNION ALL
SELECT 138, 69, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 139, 69, N'User', N'LanguageId', N'1' UNION ALL
SELECT 140, 70, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 141, 70, N'User', N'LanguageId', N'1' UNION ALL
SELECT 142, 71, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 143, 71, N'User', N'LanguageId', N'1' UNION ALL
SELECT 144, 72, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 145, 72, N'User', N'LanguageId', N'1' UNION ALL
SELECT 146, 73, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 147, 73, N'User', N'LanguageId', N'1' UNION ALL
SELECT 148, 74, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 149, 74, N'User', N'LanguageId', N'1' UNION ALL
SELECT 150, 75, N'User', N'LanguageAutomaticallyDetected', N'True'
COMMIT;
RAISERROR (N'[dbo].[GenericAttribute]: Insert Batch: 3.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[GenericAttribute]([Id], [EntityId], [KeyGroup], [Key], [Value])
SELECT 151, 75, N'User', N'LanguageId', N'1' UNION ALL
SELECT 152, 76, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 153, 76, N'User', N'LanguageId', N'1' UNION ALL
SELECT 154, 77, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 155, 77, N'User', N'LanguageId', N'1' UNION ALL
SELECT 156, 78, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 157, 78, N'User', N'LanguageId', N'1' UNION ALL
SELECT 158, 79, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 159, 79, N'User', N'LanguageId', N'1' UNION ALL
SELECT 160, 80, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 161, 80, N'User', N'LanguageId', N'1' UNION ALL
SELECT 162, 81, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 163, 81, N'User', N'LanguageId', N'1' UNION ALL
SELECT 164, 82, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 165, 82, N'User', N'LanguageId', N'1' UNION ALL
SELECT 166, 83, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 167, 83, N'User', N'LanguageId', N'1' UNION ALL
SELECT 168, 84, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 169, 84, N'User', N'LanguageId', N'1' UNION ALL
SELECT 170, 85, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 171, 85, N'User', N'LanguageId', N'1' UNION ALL
SELECT 172, 86, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 173, 86, N'User', N'LanguageId', N'1' UNION ALL
SELECT 174, 87, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 175, 87, N'User', N'LanguageId', N'1' UNION ALL
SELECT 176, 88, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 177, 88, N'User', N'LanguageId', N'1' UNION ALL
SELECT 178, 89, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 179, 89, N'User', N'LanguageId', N'1' UNION ALL
SELECT 180, 90, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 181, 90, N'User', N'LanguageId', N'1' UNION ALL
SELECT 182, 91, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 183, 91, N'User', N'LanguageId', N'1' UNION ALL
SELECT 184, 92, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 185, 92, N'User', N'LanguageId', N'1' UNION ALL
SELECT 186, 93, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 187, 93, N'User', N'LanguageId', N'1' UNION ALL
SELECT 188, 94, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 189, 94, N'User', N'LanguageId', N'1' UNION ALL
SELECT 190, 95, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 191, 95, N'User', N'LanguageId', N'1' UNION ALL
SELECT 192, 96, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 193, 96, N'User', N'LanguageId', N'1' UNION ALL
SELECT 194, 97, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 195, 97, N'User', N'LanguageId', N'1' UNION ALL
SELECT 196, 98, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 197, 98, N'User', N'LanguageId', N'1' UNION ALL
SELECT 198, 99, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 199, 99, N'User', N'LanguageId', N'1' UNION ALL
SELECT 200, 100, N'User', N'LanguageAutomaticallyDetected', N'True'
COMMIT;
RAISERROR (N'[dbo].[GenericAttribute]: Insert Batch: 4.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[GenericAttribute]([Id], [EntityId], [KeyGroup], [Key], [Value])
SELECT 201, 100, N'User', N'LanguageId', N'1' UNION ALL
SELECT 202, 101, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 203, 101, N'User', N'LanguageId', N'1' UNION ALL
SELECT 204, 102, N'User', N'LanguageAutomaticallyDetected', N'True' UNION ALL
SELECT 205, 102, N'User', N'LanguageId', N'1'
COMMIT;
RAISERROR (N'[dbo].[GenericAttribute]: Insert Batch: 5.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[GenericAttribute] OFF;

