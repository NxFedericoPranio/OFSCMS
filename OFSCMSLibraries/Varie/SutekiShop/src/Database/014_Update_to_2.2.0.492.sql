/*
Upgrade Suteki Shop database to version 2.2.0.492

Script created by SQL Compare version 9.0.0 from Red Gate Software Ltd at 20/02/2011 10:30:31
Additional data tweeks by Mike Hadlow
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Dropping foreign keys from [dbo].[Content]'
GO
ALTER TABLE [dbo].[Content] DROP
CONSTRAINT [FK4FEDF4B6E53A5F80],
CONSTRAINT [FK4FEDF4B6722A22C5]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[BasketItem]'
GO
ALTER TABLE [dbo].[BasketItem] DROP
CONSTRAINT [FK729387BD8B64590B],
CONSTRAINT [FK729387BD318371E4]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Order]'
GO
ALTER TABLE [dbo].[Order] DROP
CONSTRAINT [FK3117099BB1026BB4],
CONSTRAINT [FK3117099B6BE90924],
CONSTRAINT [FK3117099B9A379CC1],
CONSTRAINT [FK3117099BD8D66880],
CONSTRAINT [FK3117099B8703A8E0],
CONSTRAINT [FK3117099BA708CB3A]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[ProductCategory]'
GO
ALTER TABLE [dbo].[ProductCategory] DROP
CONSTRAINT [FK4022F9D7EEC058F7],
CONSTRAINT [FK4022F9D7655B84E7]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Category]'
GO
ALTER TABLE [dbo].[Category] DROP
CONSTRAINT [FK6482F24565E1830],
CONSTRAINT [FK6482F242EC1B23E]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Comment]'
GO
ALTER TABLE [dbo].[Comment] DROP
CONSTRAINT [FKE24667035273ED9D]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[MailingListSubscription]'
GO
ALTER TABLE [dbo].[MailingListSubscription] DROP
CONSTRAINT [FK1CD411ADF3F5630]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Contact]'
GO
ALTER TABLE [dbo].[Contact] DROP
CONSTRAINT [FK4FF8F4B2350E3BF0]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Basket]'
GO
ALTER TABLE [dbo].[Basket] DROP
CONSTRAINT [FKD4474AC2350E3BF0],
CONSTRAINT [FKD4474AC28703A8E0]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Review]'
GO
ALTER TABLE [dbo].[Review] DROP
CONSTRAINT [FKD28CAB635273ED9D],
CONSTRAINT [FKD28CAB63655B84E7]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[ProductImage]'
GO
ALTER TABLE [dbo].[ProductImage] DROP
CONSTRAINT [FKD8C46FDB2EC1B23E],
CONSTRAINT [FKD8C46FDB655B84E7]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[OrderLine]'
GO
ALTER TABLE [dbo].[OrderLine] DROP
CONSTRAINT [FK9D642A8F71931278]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[OrderAdjustment]'
GO
ALTER TABLE [dbo].[OrderAdjustment] DROP
CONSTRAINT [FKF3A9DF3A71931278]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Country]'
GO
ALTER TABLE [dbo].[Country] DROP
CONSTRAINT [FK2ABF29C369941CDB]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[Size]'
GO
ALTER TABLE [dbo].[Size] DROP
CONSTRAINT [FKF1577525655B84E7]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping foreign keys from [dbo].[User]'
GO
ALTER TABLE [dbo].[User] DROP
CONSTRAINT [FK7185C17CEF538E9E]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Basket]'
GO
ALTER TABLE [dbo].[Basket] DROP CONSTRAINT [PK__Basket__8FDA77B50EA330E9]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[BasketItem]'
GO
ALTER TABLE [dbo].[BasketItem] DROP CONSTRAINT [PK__BasketIt__6051AA0B403A8C7D]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Card]'
GO
ALTER TABLE [dbo].[Card] DROP CONSTRAINT [PK__Card__55FECDAE4F7CD00D]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Category]'
GO
ALTER TABLE [dbo].[Category] DROP CONSTRAINT [PK__Category__19093A0B07020F21]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Comment]'
GO
ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [PK__Comment__9A61929130F848ED]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Contact]'
GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [PK__Contact__5C66259B03317E3D]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Content]'
GO
ALTER TABLE [dbo].[Content] DROP CONSTRAINT [PK__Content__2907A81E1A14E395]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Country]'
GO
ALTER TABLE [dbo].[Country] DROP CONSTRAINT [PK__Country__10D1609F47DBAE45]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[IComment]'
GO
ALTER TABLE [dbo].[IComment] DROP CONSTRAINT [PK__IComment__5ADFDE572D27B809]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Image]'
GO
ALTER TABLE [dbo].[Image] DROP CONSTRAINT [PK__Image__7516F70C164452B1]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[MailingListSubscription]'
GO
ALTER TABLE [dbo].[MailingListSubscription] DROP CONSTRAINT [PK__MailingL__75B998BF5AEE82B9]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Order]'
GO
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [PK__Order__C3905BCF534D60F1]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[OrderAdjustment]'
GO
ALTER TABLE [dbo].[OrderAdjustment] DROP CONSTRAINT [PK__OrderAdj__CDB07B715EBF139D]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[OrderLine]'
GO
ALTER TABLE [dbo].[OrderLine] DROP CONSTRAINT [PK__OrderLin__29068A107F60ED59]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[OrderStatus]'
GO
ALTER TABLE [dbo].[OrderStatus] DROP CONSTRAINT [PK__OrderSta__BC674CA129572725]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Postage]'
GO
ALTER TABLE [dbo].[Postage] DROP CONSTRAINT [PK__Postage__203F354A3C69FB99]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[PostZone]'
GO
ALTER TABLE [dbo].[PostZone] DROP CONSTRAINT [PK__PostZone__F5DC874238996AB5]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Product]'
GO
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [PK__Product__B40CC6CD1273C1CD]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[ProductCategory]'
GO
ALTER TABLE [dbo].[ProductCategory] DROP CONSTRAINT [PK__ProductC__3224ECCE25869641]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[ProductImage]'
GO
ALTER TABLE [dbo].[ProductImage] DROP CONSTRAINT [PK__ProductI__07B2B1B8571DF1D5]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Review]'
GO
ALTER TABLE [dbo].[Review] DROP CONSTRAINT [PK__Review__9A61929134C8D9D1]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Role]'
GO
ALTER TABLE [dbo].[Role] DROP CONSTRAINT [PK__Role__8AFACE1A1DE57479]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[Size]'
GO
ALTER TABLE [dbo].[Size] DROP CONSTRAINT [PK__Size__83BD097A4BAC3F29]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[User]'
GO
ALTER TABLE [dbo].[User] DROP CONSTRAINT [PK__User__1788CC4C21B6055D]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping constraints from [dbo].[ContentType]'
GO
ALTER TABLE [dbo].[ContentType] DROP CONSTRAINT [PK__ContentT__2026064A440B1D61]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Dropping [dbo].[ContentType]'
GO
DROP TABLE [dbo].[ContentType]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[OrderLine]'
GO
ALTER TABLE [dbo].[OrderLine] ADD
[ProductId] [int] NULL,
[SizeName] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__OrderLin__29068A1034C8D9D1] on [dbo].[OrderLine]'
GO
ALTER TABLE [dbo].[OrderLine] ADD CONSTRAINT [PK__OrderLin__29068A1034C8D9D1] PRIMARY KEY CLUSTERED  ([OrderLineId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[StockItem]'
GO
CREATE TABLE [dbo].[StockItem]
(
[StockItemId] [int] NOT NULL IDENTITY(1, 1),
[Level] [int] NULL,
[IsActive] [bit] NULL,
[ProductName] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL,
[SizeName] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__StockIte__454484BC628FA481] on [dbo].[StockItem]'
GO
ALTER TABLE [dbo].[StockItem] ADD CONSTRAINT [PK__StockIte__454484BC628FA481] PRIMARY KEY CLUSTERED  ([StockItemId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[StockItemHistoryBase]'
GO
CREATE TABLE [dbo].[StockItemHistoryBase]
(
[StockItemHistoryBaseId] [int] NOT NULL IDENTITY(1, 1),
[StockItemHistoryType] [nvarchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
[DateTime] [datetime] NULL,
[User] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL,
[Level] [int] NULL,
[Comment] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL,
[StockItemId] [int] NULL,
[NumberOfItemsDispatched] [int] NULL,
[OrderNumber] [int] NULL,
[NumberOfItemsRecieved] [int] NULL,
[NewLevel] [int] NULL,
[OldProductName] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL,
[NewProductName] [nvarchar] (255) COLLATE Latin1_General_CI_AS NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__StockIte__D0EE2EF65EBF139D] on [dbo].[StockItemHistoryBase]'
GO
ALTER TABLE [dbo].[StockItemHistoryBase] ADD CONSTRAINT [PK__StockIte__D0EE2EF65EBF139D] PRIMARY KEY CLUSTERED  ([StockItemHistoryBaseId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Altering [dbo].[Content]'
GO
ALTER TABLE [dbo].[Content] DROP
COLUMN [ContentTypeId]
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Content__2907A81E21B6055D] on [dbo].[Content]'
GO
ALTER TABLE [dbo].[Content] ADD CONSTRAINT [PK__Content__2907A81E21B6055D] PRIMARY KEY CLUSTERED  ([ContentId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Basket__8FDA77B503317E3D] on [dbo].[Basket]'
GO
ALTER TABLE [dbo].[Basket] ADD CONSTRAINT [PK__Basket__8FDA77B503317E3D] PRIMARY KEY CLUSTERED  ([BasketId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__BasketIt__6051AA0B7F60ED59] on [dbo].[BasketItem]'
GO
ALTER TABLE [dbo].[BasketItem] ADD CONSTRAINT [PK__BasketIt__6051AA0B7F60ED59] PRIMARY KEY CLUSTERED  ([BasketItemId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Card__55FECDAE07020F21] on [dbo].[Card]'
GO
ALTER TABLE [dbo].[Card] ADD CONSTRAINT [PK__Card__55FECDAE07020F21] PRIMARY KEY CLUSTERED  ([CardId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Category__19093A0B0EA330E9] on [dbo].[Category]'
GO
ALTER TABLE [dbo].[Category] ADD CONSTRAINT [PK__Category__19093A0B0EA330E9] PRIMARY KEY CLUSTERED  ([CategoryId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Comment__9A619291164452B1] on [dbo].[Comment]'
GO
ALTER TABLE [dbo].[Comment] ADD CONSTRAINT [PK__Comment__9A619291164452B1] PRIMARY KEY CLUSTERED  ([ObjectId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Contact__5C66259B1DE57479] on [dbo].[Contact]'
GO
ALTER TABLE [dbo].[Contact] ADD CONSTRAINT [PK__Contact__5C66259B1DE57479] PRIMARY KEY CLUSTERED  ([ContactId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Country__10D1609F25869641] on [dbo].[Country]'
GO
ALTER TABLE [dbo].[Country] ADD CONSTRAINT [PK__Country__10D1609F25869641] PRIMARY KEY CLUSTERED  ([CountryId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__IComment__5ADFDE571273C1CD] on [dbo].[IComment]'
GO
ALTER TABLE [dbo].[IComment] ADD CONSTRAINT [PK__IComment__5ADFDE571273C1CD] PRIMARY KEY CLUSTERED  ([ICommentId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Image__7516F70C29572725] on [dbo].[Image]'
GO
ALTER TABLE [dbo].[Image] ADD CONSTRAINT [PK__Image__7516F70C29572725] PRIMARY KEY CLUSTERED  ([ImageId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__MailingL__75B998BF2D27B809] on [dbo].[MailingListSubscription]'
GO
ALTER TABLE [dbo].[MailingListSubscription] ADD CONSTRAINT [PK__MailingL__75B998BF2D27B809] PRIMARY KEY CLUSTERED  ([MailingListSubscriptionId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Order__C3905BCF38996AB5] on [dbo].[Order]'
GO
ALTER TABLE [dbo].[Order] ADD CONSTRAINT [PK__Order__C3905BCF38996AB5] PRIMARY KEY CLUSTERED  ([OrderId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__OrderAdj__CDB07B7130F848ED] on [dbo].[OrderAdjustment]'
GO
ALTER TABLE [dbo].[OrderAdjustment] ADD CONSTRAINT [PK__OrderAdj__CDB07B7130F848ED] PRIMARY KEY CLUSTERED  ([OrderAdjustmentId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__OrderSta__BC674CA13C69FB99] on [dbo].[OrderStatus]'
GO
ALTER TABLE [dbo].[OrderStatus] ADD CONSTRAINT [PK__OrderSta__BC674CA13C69FB99] PRIMARY KEY CLUSTERED  ([OrderStatusId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Postage__203F354A403A8C7D] on [dbo].[Postage]'
GO
ALTER TABLE [dbo].[Postage] ADD CONSTRAINT [PK__Postage__203F354A403A8C7D] PRIMARY KEY CLUSTERED  ([PostageId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__PostZone__F5DC8742440B1D61] on [dbo].[PostZone]'
GO
ALTER TABLE [dbo].[PostZone] ADD CONSTRAINT [PK__PostZone__F5DC8742440B1D61] PRIMARY KEY CLUSTERED  ([PostZoneId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Product__B40CC6CD4F7CD00D] on [dbo].[Product]'
GO
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [PK__Product__B40CC6CD4F7CD00D] PRIMARY KEY CLUSTERED  ([ProductId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__ProductC__3224ECCE47DBAE45] on [dbo].[ProductCategory]'
GO
ALTER TABLE [dbo].[ProductCategory] ADD CONSTRAINT [PK__ProductC__3224ECCE47DBAE45] PRIMARY KEY CLUSTERED  ([ProductCategoryId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__ProductI__07B2B1B84BAC3F29] on [dbo].[ProductImage]'
GO
ALTER TABLE [dbo].[ProductImage] ADD CONSTRAINT [PK__ProductI__07B2B1B84BAC3F29] PRIMARY KEY CLUSTERED  ([ProductImageId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Review__9A6192911A14E395] on [dbo].[Review]'
GO
ALTER TABLE [dbo].[Review] ADD CONSTRAINT [PK__Review__9A6192911A14E395] PRIMARY KEY CLUSTERED  ([ObjectId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Role__8AFACE1A534D60F1] on [dbo].[Role]'
GO
ALTER TABLE [dbo].[Role] ADD CONSTRAINT [PK__Role__8AFACE1A534D60F1] PRIMARY KEY CLUSTERED  ([RoleId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__Size__83BD097A571DF1D5] on [dbo].[Size]'
GO
ALTER TABLE [dbo].[Size] ADD CONSTRAINT [PK__Size__83BD097A571DF1D5] PRIMARY KEY CLUSTERED  ([SizeId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK__User__1788CC4C5AEE82B9] on [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK__User__1788CC4C5AEE82B9] PRIMARY KEY CLUSTERED  ([UserId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Content]'
GO
ALTER TABLE [dbo].[Content] ADD
CONSTRAINT [FK4FEDF4B6B6D51D18] FOREIGN KEY ([ParentContentId]) REFERENCES [dbo].[Content] ([ContentId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[StockItemHistoryBase]'
GO
ALTER TABLE [dbo].[StockItemHistoryBase] ADD
CONSTRAINT [FKBAB29AA9D1E5AA7A] FOREIGN KEY ([StockItemId]) REFERENCES [dbo].[StockItem] ([StockItemId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[BasketItem]'
GO
ALTER TABLE [dbo].[BasketItem] ADD
CONSTRAINT [FK729387BD8B64590B] FOREIGN KEY ([BasketId]) REFERENCES [dbo].[Basket] ([BasketId]),
CONSTRAINT [FK729387BD318371E4] FOREIGN KEY ([SizeId]) REFERENCES [dbo].[Size] ([SizeId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Order]'
GO
ALTER TABLE [dbo].[Order] ADD
CONSTRAINT [FK3117099BB1026BB4] FOREIGN KEY ([CardId]) REFERENCES [dbo].[Card] ([CardId]),
CONSTRAINT [FK3117099B6BE90924] FOREIGN KEY ([DeliveryContactId]) REFERENCES [dbo].[Contact] ([ContactId]),
CONSTRAINT [FK3117099B9A379CC1] FOREIGN KEY ([CardContactId]) REFERENCES [dbo].[Contact] ([ContactId]),
CONSTRAINT [FK3117099BD8D66880] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus] ([OrderStatusId]),
CONSTRAINT [FK3117099B8703A8E0] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
CONSTRAINT [FK3117099BA708CB3A] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[User] ([UserId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[ProductCategory]'
GO
ALTER TABLE [dbo].[ProductCategory] ADD
CONSTRAINT [FK4022F9D7EEC058F7] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]),
CONSTRAINT [FK4022F9D7655B84E7] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Category]'
GO
ALTER TABLE [dbo].[Category] ADD
CONSTRAINT [FK6482F24565E1830] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Category] ([CategoryId]),
CONSTRAINT [FK6482F242EC1B23E] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Image] ([ImageId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Comment]'
GO
ALTER TABLE [dbo].[Comment] ADD
CONSTRAINT [FKE24667035273ED9D] FOREIGN KEY ([ObjectId]) REFERENCES [dbo].[IComment] ([ICommentId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[MailingListSubscription]'
GO
ALTER TABLE [dbo].[MailingListSubscription] ADD
CONSTRAINT [FK1CD411ADF3F5630] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact] ([ContactId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Contact]'
GO
ALTER TABLE [dbo].[Contact] ADD
CONSTRAINT [FK4FF8F4B2350E3BF0] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([CountryId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Basket]'
GO
ALTER TABLE [dbo].[Basket] ADD
CONSTRAINT [FKD4474AC2350E3BF0] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([CountryId]),
CONSTRAINT [FKD4474AC28703A8E0] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Review]'
GO
ALTER TABLE [dbo].[Review] ADD
CONSTRAINT [FKD28CAB635273ED9D] FOREIGN KEY ([ObjectId]) REFERENCES [dbo].[IComment] ([ICommentId]),
CONSTRAINT [FKD28CAB63655B84E7] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[ProductImage]'
GO
ALTER TABLE [dbo].[ProductImage] ADD
CONSTRAINT [FKD8C46FDB2EC1B23E] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Image] ([ImageId]),
CONSTRAINT [FKD8C46FDB655B84E7] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[OrderLine]'
GO
ALTER TABLE [dbo].[OrderLine] ADD
CONSTRAINT [FK9D642A8F71931278] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[OrderAdjustment]'
GO
ALTER TABLE [dbo].[OrderAdjustment] ADD
CONSTRAINT [FKF3A9DF3A71931278] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Country]'
GO
ALTER TABLE [dbo].[Country] ADD
CONSTRAINT [FK2ABF29C369941CDB] FOREIGN KEY ([PostZoneId]) REFERENCES [dbo].[PostZone] ([PostZoneId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[Size]'
GO
ALTER TABLE [dbo].[Size] ADD
CONSTRAINT [FKF1577525655B84E7] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD
CONSTRAINT [FK7185C17CEF538E9E] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO

-- insert StockItems with initial history
insert StockItem ([Level], IsActive, ProductName, SizeName)
select
	0,
	s.IsActive,
	p.UrlName as ProductName,
	s.Name as SizeName
from Size s
join Product p on s.ProductId = p.ProductId

insert StockItemHistoryBase (
	StockItemHistoryType,
	[DateTime],
	[User],
	[Level],
	StockItemId
)
select
	'StockItemCreated',
	GETDATE(),
	'stock control upgrade script',
	0,
	StockItemId
from StockItem	

GO

-- add IsInStock column
alter table StockItem
add IsInStock bit default 1

GO

-- update is in stock
update StockItem set IsInStock = s.IsInStock
from StockItem
join (select 
			Size.Name as SizeName,
			Product.UrlName as ProductName,
			Size.IsInStock as IsInStock
		from Size 
		join Product on Size.ProductId = Product.ProductId
		where ((Size.IsActive = 1 and Product.IsActive = 1) or Size.Name = '-')) s
	on s.SizeName = StockItem.SizeName and s.ProductName = StockItem.ProductName

GO

-- update old order lines
update OrderLine set ProductId = OrderLineNew.ProductId, SizeName = OrderLineNew.NewSizeName
from OrderLine
join (
	select
		OrderLineId,
		Product.ProductId,
		Product.UrlName,
		NewSizeName = CASE SUBSTRING(ProductName, len(Product.Name)+4, LEN(ProductName))
			WHEN '' THEN '-'
			ELSE SUBSTRING(ProductName, len(Product.Name)+4, LEN(ProductName))
		END
	from OrderLine 
	join Product on OrderLine.ProductUrlName = Product.UrlName
	where OrderLine.SizeName is null
	) AS OrderLineNew on OrderLineNew.OrderLineId = OrderLine.OrderLineId
left join Size on OrderLineNew.ProductId = Size.ProductId AND ltrim(rtrim(Size.Name)) = ltrim(rtrim(NewSizeName)) AND Size.IsActive = 1
where Size.Name is not null
GO

-- update orders for default sizes AND any old orders with inactive sizes.
update OrderLine set ProductId = OrderLineNew.ProductId, SizeName = OrderLineNew.NewSizeName
from OrderLine
join (
	select
		OrderLineId,
		Product.ProductId,
		Product.UrlName,
		NewSizeName = CASE SUBSTRING(ProductName, len(Product.Name)+4, LEN(ProductName))
			WHEN '' THEN '-'
			ELSE SUBSTRING(ProductName, len(Product.Name)+4, LEN(ProductName))
		END
	from OrderLine 
	join Product on OrderLine.ProductUrlName = Product.UrlName
	where OrderLine.SizeName is null
	) AS OrderLineNew on OrderLineNew.OrderLineId = OrderLine.OrderLineId
left join Size on OrderLineNew.ProductId = Size.ProductId AND ltrim(rtrim(Size.Name)) = ltrim(rtrim(NewSizeName))
where Size.Name is not null
GO