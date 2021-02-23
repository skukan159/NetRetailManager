﻿CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SaleId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [PurchasePrice] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL DEFAULT 0, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_SaleDetail_ToSale] FOREIGN KEY (SaleId) REFERENCES Sale(Id), 
    CONSTRAINT [FK_SaleDetail_ToProduct] FOREIGN KEY (ProductId) REFERENCES Product(Id) 
)
