CREATE TABLE [dbo].[AbpUserLogins] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]        BIGINT         NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AbpUserLogins] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AbpUserLogins_dbo.AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AbpUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId_LoginProvider]
    ON [dbo].[AbpUserLogins]([UserId] ASC, [LoginProvider] ASC);

