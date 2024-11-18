/*CREATE TABLE [dbo].[Colors] (
    [colorId]           INT IDENTITY(1,1) NOT NULL,
    [colorName]         NVARCHAR(50) NULL,
    [price]             INT NULL,
    [isInStock]         BIT NULL,
    [presentationOrder] INT NULL,
    CONSTRAINT [PK_Colors_Temp] PRIMARY KEY CLUSTERED ([colorId] ASC)
);*/
--DROP TABLE [dbo].[Colors];
CREATE TABLE [dbo].[Colors] (
    [colorId]           INT IDENTITY(1,1) NOT NULL,
    [colorName]         NVARCHAR(50) NULL,
    [price]             INT NULL,
    [isInStock]         BIT NULL,
    [presentationOrder] INT NULL,
    CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([colorId] ASC)
);