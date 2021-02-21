﻿CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NULL, 
    [Quantity] INT NULL DEFAULT 1, 
    [PurchasePrice] MONEY NULL, 
    [PurchaseDate] DATETIME2 NULL DEFAULT getutcdate()
)
