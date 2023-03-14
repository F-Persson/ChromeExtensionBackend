CREATE TABLE [dbo].[Tags] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [TagItemId]       INT            NOT NULL,
    [Tag]             NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tag_TagItems_TagItemId] FOREIGN KEY ([TagItemId]) REFERENCES [dbo].[TagItems] ([TagItemId])
);