CREATE TABLE [Sec].[GroupPermissions] (
    [GroupPermissions_Id] INT          IDENTITY (1, 1) NOT NULL,
    [Group_Id]            INT          NOT NULL,
    [Permission_Id]       INT          NOT NULL,
    [CreatedBy]           VARCHAR (50) NOT NULL,
    [CreatedDate]         DATETIME     CONSTRAINT [DF_GroupPermissions_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdateBy]            VARCHAR (50) NULL,
    [UpdatedDate]         DATETIME     NULL,
    [RowVersion]          ROWVERSION   NOT NULL,
    CONSTRAINT [PK__GroupPer__981CE1C6311C8DCD] PRIMARY KEY CLUSTERED ([GroupPermissions_Id] ASC),
    CONSTRAINT [FK_GroupPermissions_Groups] FOREIGN KEY ([Group_Id]) REFERENCES [Sec].[Groups] ([Group_Id]),
    CONSTRAINT [FK_GroupPermissions_Permissions] FOREIGN KEY ([Permission_Id]) REFERENCES [Sec].[Permissions] ([Permission_Id])
);





