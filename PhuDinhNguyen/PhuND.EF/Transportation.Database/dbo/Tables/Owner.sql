CREATE TABLE [dbo].[Owner] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    [Age]  INT          NOT NULL,
    CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED ([Id] ASC)
);

