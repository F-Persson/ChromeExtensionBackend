CREATE TABLE [dbo].[TagItems] (
    [TagItemId]        INT            IDENTITY (1, 1) NOT NULL,
    [Time]            NVARCHAR (MAX) NOT NULL,
    [Selection]       NVARCHAR (MAX) NOT NULL,
    [Url]             NVARCHAR (MAX) NOT NULL,
    [Title]           NVARCHAR (MAX) NOT NULL,
    [IsEditing]       BIT            NOT NULL,
    [IsFlipped]       BIT            NOT NULL,
    [IsShowing]       BIT            NOT NULL,
    [MetaDescription] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_TagItems] PRIMARY KEY CLUSTERED ([TagItemId] ASC)
);