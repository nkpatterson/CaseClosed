CREATE TABLE [dbo].[AbpSettings] (
    [Id]                   BIGINT          IDENTITY (1, 1) NOT NULL,
    [TenantId]             INT             NULL,
    [UserId]               BIGINT          NULL,
    [Name]                 NVARCHAR (256)  NOT NULL,
    [Value]                NVARCHAR (2000) NULL,
    [LastModificationTime] DATETIME        NULL,
    [LastModifierUserId]   BIGINT          NULL,
    [CreationTime]         DATETIME        NOT NULL,
    [CreatorUserId]        BIGINT          NULL,
    CONSTRAINT [PK_dbo.AbpSettings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AbpSettings_dbo.AbpTenants_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[AbpTenants] ([Id]),
    CONSTRAINT [FK_dbo.AbpSettings_dbo.AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AbpUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_Name]
    ON [dbo].[AbpSettings]([TenantId] ASC, [Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId_Name]
    ON [dbo].[AbpSettings]([UserId] ASC, [Name] ASC);

