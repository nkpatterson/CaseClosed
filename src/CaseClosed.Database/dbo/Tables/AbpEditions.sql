CREATE TABLE [dbo].[AbpEditions] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (32) NOT NULL,
    [DisplayName]          NVARCHAR (64) NOT NULL,
    [IsDeleted]            BIT           NOT NULL,
    [DeleterUserId]        BIGINT        NULL,
    [DeletionTime]         DATETIME      NULL,
    [LastModificationTime] DATETIME      NULL,
    [LastModifierUserId]   BIGINT        NULL,
    [CreationTime]         DATETIME      NOT NULL,
    [CreatorUserId]        BIGINT        NULL,
    CONSTRAINT [PK_dbo.AbpEditions] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[AbpEditions]([Name] ASC);

