CREATE TABLE [dbo].[AbpUsers] (
    [Id]                    BIGINT         IDENTITY (1, 1) NOT NULL,
    [TenantId]              INT            NULL,
    [AuthenticationSource]  NVARCHAR (64)  NULL,
    [Name]                  NVARCHAR (32)  NOT NULL,
    [Surname]               NVARCHAR (32)  NOT NULL,
    [UserName]              NVARCHAR (32)  NOT NULL,
    [Password]              NVARCHAR (128) NOT NULL,
    [EmailAddress]          NVARCHAR (256) NOT NULL,
    [IsEmailConfirmed]      BIT            NOT NULL,
    [EmailConfirmationCode] NVARCHAR (128) NULL,
    [PasswordResetCode]     NVARCHAR (328) NULL,
    [LastLoginTime]         DATETIME       NULL,
    [IsActive]              BIT            NOT NULL,
    [IsDeleted]             BIT            NOT NULL,
    [DeleterUserId]         BIGINT         NULL,
    [DeletionTime]          DATETIME       NULL,
    [LastModificationTime]  DATETIME       NULL,
    [LastModifierUserId]    BIGINT         NULL,
    [CreationTime]          DATETIME       NOT NULL,
    [CreatorUserId]         BIGINT         NULL,
    CONSTRAINT [PK_dbo.AbpUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AbpUsers_dbo.AbpTenants_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[AbpTenants] ([Id]),
    CONSTRAINT [FK_dbo.AbpUsers_dbo.AbpUsers_CreatorUserId] FOREIGN KEY ([CreatorUserId]) REFERENCES [dbo].[AbpUsers] ([Id]),
    CONSTRAINT [FK_dbo.AbpUsers_dbo.AbpUsers_DeleterUserId] FOREIGN KEY ([DeleterUserId]) REFERENCES [dbo].[AbpUsers] ([Id]),
    CONSTRAINT [FK_dbo.AbpUsers_dbo.AbpUsers_LastModifierUserId] FOREIGN KEY ([LastModifierUserId]) REFERENCES [dbo].[AbpUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_UserName]
    ON [dbo].[AbpUsers]([TenantId] ASC, [UserName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DeleterUserId]
    ON [dbo].[AbpUsers]([DeleterUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LastModifierUserId]
    ON [dbo].[AbpUsers]([LastModifierUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreatorUserId]
    ON [dbo].[AbpUsers]([CreatorUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TenantId_EmailAddress]
    ON [dbo].[AbpUsers]([TenantId] ASC, [EmailAddress] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsDeleted_TenantId_UserName]
    ON [dbo].[AbpUsers]([IsDeleted] ASC, [TenantId] ASC, [UserName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsDeleted_TenantId_EmailAddress]
    ON [dbo].[AbpUsers]([IsDeleted] ASC, [TenantId] ASC, [EmailAddress] ASC);

