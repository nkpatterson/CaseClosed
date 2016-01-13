CREATE TABLE [dbo].[AbpOrganizationUnits] (
    [Id]                   BIGINT         IDENTITY (1, 1) NOT NULL,
    [TenantId]             INT            NULL,
    [ParentId]             BIGINT         NULL,
    [Code]                 NVARCHAR (128) NOT NULL,
    [DisplayName]          NVARCHAR (128) NOT NULL,
    [IsDeleted]            BIT            NOT NULL,
    [DeleterUserId]        BIGINT         NULL,
    [DeletionTime]         DATETIME       NULL,
    [LastModificationTime] DATETIME       NULL,
    [LastModifierUserId]   BIGINT         NULL,
    [CreationTime]         DATETIME       NOT NULL,
    [CreatorUserId]        BIGINT         NULL,
    CONSTRAINT [PK_dbo.AbpOrganizationUnits] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AbpOrganizationUnits_dbo.AbpOrganizationUnits_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[AbpOrganizationUnits] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ParentId]
    ON [dbo].[AbpOrganizationUnits]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_ParentId]
    ON [dbo].[AbpOrganizationUnits]([TenantId] ASC, [ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_Code]
    ON [dbo].[AbpOrganizationUnits]([TenantId] ASC, [Code] ASC);

