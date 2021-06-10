CREATE TABLE [dbo].[Product] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [barcode]      INT           NULL,
    [product_name] NVARCHAR (50) NULL,
    [Price]        DECIMAL (18)  NULL,
    [Status]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

