CREATE TABLE [dbo].[AbpTenants] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [TenancyName]          NVARCHAR (64)  NOT NULL,
    [Name]                 NVARCHAR (128) NOT NULL,
    [IsActive]             BIT            NOT NULL,
    [IsDeleted]            BIT            NOT NULL,
    [DeleterUserId]        BIGINT         NULL,
    [DeletionTime]         DATETIME       NULL,
    [LastModificationTime] DATETIME       NULL,
    [LastModifierUserId]   BIGINT         NULL,
    [CreationTime]         DATETIME       NOT NULL,
    [CreatorUserId]        BIGINT         NULL,
    [EditionId]            INT            NULL,
    CONSTRAINT [PK_dbo.AbpTenants] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AbpTenants_dbo.AbpEditions_EditionId] FOREIGN KEY ([EditionId]) REFERENCES [dbo].[AbpEditions] ([Id]),
    CONSTRAINT [FK_dbo.AbpTenants_dbo.AbpUsers_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[AbpUsers] ([Id]),
    CONSTRAINT [FK_dbo.AbpTenants_dbo.AbpUsers_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[AbpUsers] ([Id]),
    CONSTRAINT [FK_dbo.AbpTenants_dbo.AbpUsers_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[AbpUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DeleterUserId]
    ON [dbo].[AbpTenants]([DeleterUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LastModifierUserId]
    ON [dbo].[AbpTenants]([LastModifierUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreatorUserId]
    ON [dbo].[AbpTenants]([CreatorUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EditionId]
    ON [dbo].[AbpTenants]([EditionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TenancyName]
    ON [dbo].[AbpTenants]([TenancyName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsDeleted_TenancyName]
    ON [dbo].[AbpTenants]([IsDeleted] ASC, [TenancyName] ASC);

