CREATE TABLE [dbo].[Vehicle] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Wheel]   INT          NOT NULL,
    [OwnerId] INT          NOT NULL,
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vehicle_Owner] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Owner] ([Id])
);

