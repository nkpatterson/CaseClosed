CREATE TABLE [dbo].[AbpUserOrganizationUnits] (
    [Id]                 BIGINT   IDENTITY (1, 1) NOT NULL,
    [TenantId]           INT      NULL,
    [UserId]             BIGINT   NOT NULL,
    [OrganizationUnitId] BIGINT   NOT NULL,
    [CreationTime]       DATETIME NOT NULL,
    [CreatorUserId]      BIGINT   NULL,
    CONSTRAINT [PK_dbo.AbpUserOrganizationUnits] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_UserId]
    ON [dbo].[AbpUserOrganizationUnits]([TenantId] ASC, [UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_OrganizationUnitId]
    ON [dbo].[AbpUserOrganizationUnits]([TenantId] ASC, [OrganizationUnitId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AbpUserOrganizationUnits]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrganizationUnitId]
    ON [dbo].[AbpUserOrganizationUnits]([OrganizationUnitId] ASC);

