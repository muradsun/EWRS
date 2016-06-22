CREATE TABLE [Sec].[Permissions] (
    [Permission_Id] INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (500) NOT NULL,
    [CreatedBy]     VARCHAR (50)   NOT NULL,
    [CreatedDate]   DATETIME       CONSTRAINT [DF_Permissions_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdateBy]      VARCHAR (50)   NULL,
    [UpdatedDate]   DATETIME       NULL,
    [RowVersion]    ROWVERSION     NOT NULL,
    CONSTRAINT [PK__Permissi__89B744854905478A] PRIMARY KEY CLUSTERED ([Permission_Id] ASC)
);





