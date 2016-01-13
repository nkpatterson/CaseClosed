CREATE TABLE [dbo].[AbpLanguages] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [TenantId]             INT            NULL,
    [Name]                 NVARCHAR (10)  NOT NULL,
    [DisplayName]          NVARCHAR (64)  NOT NULL,
    [Icon]                 NVARCHAR (128) NULL,
    [IsDeleted]            BIT            NOT NULL,
    [DeleterUserId]        BIGINT         NULL,
    [DeletionTime]         DATETIME       NULL,
    [LastModificationTime] DATETIME       NULL,
    [LastModifierUserId]   BIGINT         NULL,
    [CreationTime]         DATETIME       NOT NULL,
    [CreatorUserId]        BIGINT         NULL,
    CONSTRAINT [PK_dbo.AbpLanguages] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_Name]
    ON [dbo].[AbpLanguages]([TenantId] ASC, [Name] ASC);

