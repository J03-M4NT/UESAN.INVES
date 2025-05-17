CREATE TABLE [dbo].[Products] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100)  NULL,
    [UnitPrice]   DECIMAL (18, 2) NULL,
    [Status] BIT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

