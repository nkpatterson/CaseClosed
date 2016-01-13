CREATE TABLE [dbo].[AbpPermissions] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (128) NOT NULL,
    [IsGranted]     BIT            NOT NULL,
    [CreationTime]  DATETIME       NOT NULL,
    [CreatorUserId] BIGINT         NULL,
    [RoleId]        INT            NULL,
    [UserId]        BIGINT         NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AbpPermissions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AbpPermissions_dbo.AbpRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AbpRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AbpPermissions_dbo.AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AbpUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId_Name]
    ON [dbo].[AbpPermissions]([UserId] ASC, [Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId_Name]
    ON [dbo].[AbpPermissions]([RoleId] ASC, [Name] ASC);

