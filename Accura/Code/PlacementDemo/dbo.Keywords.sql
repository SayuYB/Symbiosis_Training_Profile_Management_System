CREATE TABLE [dbo].[Keywords] (
    [KeyId]       INT            IDENTITY (1, 1) NOT NULL,
    [KeywordName] NVARCHAR (MAX) NOT NULL,
    [Category]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Keywords] PRIMARY KEY CLUSTERED ([KeyId] ASC)
);

