CREATE TABLE [dbo].[SmokeTests] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [IsSuccess]            BIT            NOT NULL,
    [Message]              NVARCHAR (MAX) NULL,
    [LastModificationTime] DATETIME       NULL,
    [LastModifierUserId]   BIGINT         NULL,
    [CreationTime]         DATETIME       NOT NULL,
    [CreatorUserId]        BIGINT         NULL,
    [FirstName] VARCHAR(50) NULL, 
    CONSTRAINT [PK_dbo.SmokeTests] PRIMARY KEY CLUSTERED ([Id] ASC)
);

