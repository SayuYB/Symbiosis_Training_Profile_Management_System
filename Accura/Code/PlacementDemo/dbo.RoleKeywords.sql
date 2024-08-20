CREATE TABLE [dbo].[RoleKeywords] (
    [RoleKeyId]    INT            IDENTITY (1, 1) NOT NULL,
    [RoleName]     NVARCHAR (MAX) NOT NULL,
    [KeyId]        INT            NOT NULL,
    [KeywordKeyId] INT            NOT NULL,
    [weight]       INT            NOT NULL,
    CONSTRAINT [PK_RoleKeywords] PRIMARY KEY CLUSTERED ([RoleKeyId] ASC),
    CONSTRAINT [FK_RoleKeywords_Keywords_KeywordKeyId] FOREIGN KEY ([KeywordKeyId]) REFERENCES [dbo].[Keywords] ([KeyId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RoleKeywords_KeywordKeyId]
    ON [dbo].[RoleKeywords]([KeywordKeyId] ASC);

