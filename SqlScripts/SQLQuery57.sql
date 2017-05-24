USE [AuctionCommerce];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[User] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[User]([Id], [UserGuid], [Username], [Email], [Password], [PasswordFormatId], [PasswordSalt], [HasShoppingCartItems], [Active], [Deleted], [CreatedOnUtc], [LastActivityDateUtc])
SELECT 1, N'5398fb21-bef7-4093-aa79-7ab7db4a8943', N'kassymov17@gmail.com', N'kassymov17@gmail.com', N'FF08E48533642BE89E88083EBF3260FB39D6F663', 1, N'FF08E48533642BE89E88083EBF3260FB39D6F663', 1, 1, 0, '20170403 20:55:04.810', '20170403 20:55:04.810' UNION ALL
SELECT 11, N'31d4ffef-a1c4-40c5-84c5-437dbc403a64', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170413 20:40:30.663', '20170413 20:40:30.663' UNION ALL
SELECT 12, N'456d2914-d143-455b-9072-3dcd05ba0c10', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170413 21:29:27.443', '20170413 21:29:27.443' UNION ALL
SELECT 13, N'e410c08b-0ebf-45aa-8610-062d37e3f801', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170414 22:17:42.677', '20170414 22:17:42.677' UNION ALL
SELECT 14, N'09c76878-6904-4bf4-923f-3ad589c2c1bc', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170414 22:23:51.757', '20170414 22:23:51.757' UNION ALL
SELECT 15, N'ec68b779-3b70-476d-aa09-12fcec112728', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170414 22:38:48.833', '20170414 22:38:48.833' UNION ALL
SELECT 16, N'2ba20311-d3c0-4ab6-abaa-b72768775ca2', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170414 22:54:24.297', '20170414 22:54:24.297' UNION ALL
SELECT 17, N'3160a672-9328-4ba7-b1ba-797baf93c7d1', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170415 16:48:26.330', '20170415 16:48:26.330' UNION ALL
SELECT 18, N'2a85f497-7d6d-4fee-ad6d-c4d19a28d700', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170415 16:52:24.417', '20170415 16:52:24.417' UNION ALL
SELECT 19, N'e9cf374a-3400-47a2-bebd-7fff6709b87f', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170415 19:30:08.967', '20170415 19:30:08.967' UNION ALL
SELECT 20, N'b5ffd499-7491-431a-9660-9b4c9b7055ec', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170416 20:30:43.957', '20170416 20:30:43.957' UNION ALL
SELECT 21, N'e575eccb-7d57-470f-8027-d1e73bdbc738', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170417 21:18:06.040', '20170417 21:18:06.040' UNION ALL
SELECT 22, N'4d4e48f2-b1e4-403d-bfb2-eb2ff2c036c4', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170417 22:12:52.597', '20170417 22:12:52.597' UNION ALL
SELECT 23, N'68dee8fc-51b2-4d43-9d3f-080866789e14', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170419 14:19:07.090', '20170419 14:19:07.090' UNION ALL
SELECT 24, N'51888015-abd8-4be9-b68e-1341c6836527', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170419 20:44:51.030', '20170419 20:44:51.030' UNION ALL
SELECT 25, N'f5d97b03-f573-4c7b-b293-98f36f9cc583', N'yelamash@mail.ru', N'yelamash@mail.ru', N'E6DB85947312F6B0FE69656BB94B31C5C803A5E8', 1, N'Vx1pG7s=', 0, 1, 0, '20170419 21:32:33.713', '20170419 21:32:33.713' UNION ALL
SELECT 26, N'77a43b15-c2be-4b3e-a1c1-51efe48972ad', N'example@mail.com', N'example@mail.com', N'5908DB1E066E0252A286E4BCBCCEA566968706B1', 1, N'ZxKKzY0=', 0, 1, 0, '20170420 18:14:40.803', '20170420 18:14:40.803' UNION ALL
SELECT 27, N'04e4152c-a5ae-449f-a7a1-9473657b29f9', N'qwerty@mail.ru', N'qwerty@mail.ru', N'EF04529D4C442F613061B9B872322E73A53E3516', 1, N'7QQ1JOQ=', 0, 1, 0, '20170420 18:57:12.507', '20170420 18:57:12.507' UNION ALL
SELECT 28, N'd2f64c73-badb-4f89-8312-08b885830797', N'azaza@mail.ru', N'azaza@mail.ru', N'D9997C8548468F54C6B9725EE3E1EF10A0183641', 1, N'QmqVg/8=', 1, 1, 0, '20170420 18:58:13.467', '20170420 18:58:13.467' UNION ALL
SELECT 29, N'15266920-c1ab-4786-8f50-93ceaab7df16', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170420 20:44:15.130', '20170420 20:44:15.130' UNION ALL
SELECT 30, N'4b51a1a1-8b39-448e-ad2f-0fc57d01fe81', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170420 21:40:23.087', '20170420 21:40:23.087' UNION ALL
SELECT 31, N'47342ab3-0827-4694-b75f-f46d81415dac', N'ivanov.vanya@mail.ru', N'ivanov.vanya@mail.ru', N'82C83E98186339F6824A0C0A9DFA884F94848F21', 1, N'hLWUppA=', 0, 1, 0, '20170420 22:02:06.877', '20170420 22:02:06.877' UNION ALL
SELECT 32, N'0073663d-6fef-4785-91af-067da1a5fb20', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170421 09:14:13.480', '20170421 09:14:13.480' UNION ALL
SELECT 33, N'c4e6d662-bc25-4d3a-a3bd-ef5c3705cb4c', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170421 09:29:56.447', '20170421 09:29:56.447' UNION ALL
SELECT 34, N'ac78639c-6d88-4a03-ba77-e96b32d6126c', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170421 11:05:53.557', '20170421 11:05:53.557' UNION ALL
SELECT 35, N'a8b238dd-0a9a-419c-b096-40d26a1385b2', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170421 11:06:48.857', '20170421 11:06:48.857' UNION ALL
SELECT 36, N'e80cc132-b036-452f-8f8e-258e0d5c3654', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170422 12:02:53.037', '20170422 12:02:53.037' UNION ALL
SELECT 37, N'6296ee2b-85a9-4c28-866c-40afc15ffdf3', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170422 14:27:10.680', '20170422 14:27:10.680' UNION ALL
SELECT 38, N'22dd2caf-1c57-47ce-aeea-4806916ce60a', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170423 16:09:44.973', '20170423 16:09:44.973' UNION ALL
SELECT 39, N'2580cc22-e0ac-422b-96db-3d9254f8f74e', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170423 17:31:20.607', '20170423 17:31:20.607' UNION ALL
SELECT 40, N'2e750278-e017-49b0-a825-1540e6266a3c', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170423 19:45:39.043', '20170423 19:45:39.043' UNION ALL
SELECT 41, N'efc2b032-5495-4959-a749-c7e4efc0ac17', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170423 19:59:08.890', '20170423 19:59:08.890' UNION ALL
SELECT 42, N'acb19e4b-93a0-4fc9-af13-ed6e30bc2c6b', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170423 20:12:19.327', '20170423 20:12:19.327' UNION ALL
SELECT 43, N'3cde1c80-8742-4cc6-a7d2-7c24afb13340', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170423 21:30:09.817', '20170423 21:30:09.817' UNION ALL
SELECT 44, N'b4912a9a-19d4-44d8-ab02-662fbb849105', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170423 21:53:17.437', '20170423 21:53:17.437' UNION ALL
SELECT 45, N'7ba04934-8b37-4a06-9237-0d9f7056dbfa', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170424 16:42:34.147', '20170424 16:42:34.150' UNION ALL
SELECT 46, N'117671c6-a27d-41e1-a7f6-b31bf4cd1b1f', N'adfd@df.fd', N'adfd@df.fd', N'0C5D420F21F372033AD5855535DFAB04F56EAD63', 1, N'6dADlls=', 0, 1, 0, '20170424 17:38:41.247', '20170424 17:38:41.247' UNION ALL
SELECT 47, N'18c632eb-29ae-42c2-b51b-e25fb2484e56', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170424 18:41:27.773', '20170424 18:41:27.773' UNION ALL
SELECT 48, N'13e0742c-94e9-4630-af71-2e1500db8090', NULL, NULL, NULL, 0, NULL, 1, 1, 0, '20170425 08:34:51.243', '20170425 08:34:51.243' UNION ALL
SELECT 49, N'0c9e00b9-85b6-4912-8e50-3f234d7e2d0c', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170426 19:22:29.180', '20170426 19:22:29.183' UNION ALL
SELECT 50, N'1feaad4d-be7d-4bf9-920d-82f401ae5682', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170426 19:56:01.297', '20170426 19:56:01.297' UNION ALL
SELECT 51, N'fc61d266-c81c-45b2-9b4e-5c441b6f9572', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170426 21:39:22.683', '20170426 21:39:22.683' UNION ALL
SELECT 52, N'dc872197-6e19-4fcf-b39d-853c964a8b90', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 13:47:34.437', '20170429 13:47:34.437' UNION ALL
SELECT 53, N'8ecfe7aa-769c-47a3-abb2-3b16127131eb', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 14:39:47.867', '20170429 14:39:47.867' UNION ALL
SELECT 54, N'd1942edb-b0d8-4902-936d-8f33da0c0782', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 14:57:49.073', '20170429 14:57:49.073' UNION ALL
SELECT 55, N'647c8603-e6fa-4805-8946-1edf0b8384c8', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 15:12:50.060', '20170429 15:12:50.060' UNION ALL
SELECT 56, N'4b251626-0601-43e2-ad39-6299f5ed8d3c', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 15:17:20.863', '20170429 15:17:20.863' UNION ALL
SELECT 57, N'16ef1aee-5c0b-47a1-98c4-08181457fd28', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 17:09:22.287', '20170429 17:09:22.287' UNION ALL
SELECT 58, N'b8719c14-dbc3-4f59-bc33-2c6d59f5fffa', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 17:49:39.007', '20170429 17:49:39.007' UNION ALL
SELECT 59, N'ccf1f681-57f5-416c-a59b-c1ae867b163c', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 20:35:16.747', '20170429 20:35:16.747'
COMMIT;
RAISERROR (N'[dbo].[User]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[User]([Id], [UserGuid], [Username], [Email], [Password], [PasswordFormatId], [PasswordSalt], [HasShoppingCartItems], [Active], [Deleted], [CreatedOnUtc], [LastActivityDateUtc])
SELECT 60, N'620d3582-c0c2-4c6a-8c16-935f4e95ed02', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 21:00:19.457', '20170429 21:00:19.457' UNION ALL
SELECT 61, N'890bd2ce-5429-402c-9e75-aa668b137cfd', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170429 21:00:19.390', '20170429 21:00:19.390' UNION ALL
SELECT 62, N'6aace823-cd70-4cba-9dfa-289e0c73d537', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170430 07:37:52.160', '20170430 07:37:52.160' UNION ALL
SELECT 63, N'6fe231d0-a1ca-4b9b-88cd-edbbe273eb57', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170430 09:41:17.613', '20170430 09:41:17.613' UNION ALL
SELECT 64, N'de3e4b74-b27d-43ec-89de-9ab19d9424aa', N'user@mail.com', N'user@mail.com', N'E384F3FB54F9DE578F96E4CA6727F6EDD9B8ED2E', 1, N'ytZASuA=', 0, 1, 0, '20170502 19:42:16.047', '20170502 19:42:16.047' UNION ALL
SELECT 65, N'3d679c66-fcb0-4039-b562-bf5da34e3369', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170503 13:43:48.937', '20170503 13:43:48.937' UNION ALL
SELECT 66, N'0082a36b-b359-4d53-b4d8-5029dac8e44a', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170505 11:53:36.127', '20170505 11:53:36.127' UNION ALL
SELECT 67, N'af0531f2-742e-428f-a41c-eec14a60478b', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170508 21:11:50.713', '20170508 21:11:50.713' UNION ALL
SELECT 68, N'08ad9476-899e-4b9b-b4ce-529c7e8a42ff', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170509 21:24:19.187', '20170509 21:24:19.187' UNION ALL
SELECT 69, N'c9daa82d-59c6-4d28-a26e-40e045a38de3', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170513 12:19:49.553', '20170513 12:19:49.553' UNION ALL
SELECT 70, N'dc4c62f3-5d2b-4b13-9576-a454211586c0', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170513 13:55:53.333', '20170513 13:55:53.333' UNION ALL
SELECT 71, N'9040e1e8-4ccf-4d18-8c66-0f11c6029c3d', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170517 18:30:09.237', '20170517 18:30:09.237' UNION ALL
SELECT 72, N'2ae1a6c7-4c4d-4d95-aa82-bfdd41e9666a', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170517 19:36:36.643', '20170517 19:36:36.643' UNION ALL
SELECT 73, N'1e028202-387d-4d04-a2c9-c382d2b612dc', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170518 18:10:24.073', '20170518 18:10:24.073' UNION ALL
SELECT 74, N'dd908047-c8ef-454f-a874-a85bc3c1d417', NULL, NULL, NULL, 0, NULL, 0, 1, 0, '20170519 11:53:48.720', '20170519 11:53:48.720'
COMMIT;
RAISERROR (N'[dbo].[User]: Insert Batch: 2.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[User] OFF;

