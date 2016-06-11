CREATE TABLE [Sec].[Permissions] (
    [Permission_Id] INT            NOT NULL,
    [Name]          NVARCHAR (500) NOT NULL,
    [CreatedDate]   DATETIME       NOT NULL,
    [UpdateBy]      VARCHAR (50)   NULL,
    [UpdatedDate]   DATETIME       NULL,
    [RowVersion]    ROWVERSION     NOT NULL,
    CONSTRAINT [PK__Permissi__89B744854905478A] PRIMARY KEY CLUSTERED ([Permission_Id] ASC)
);

