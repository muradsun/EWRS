CREATE TABLE [Sec].[GroupUsers] (
    [GroupUsers_Id] INT          NOT NULL,
    [User_Id]       INT          NOT NULL,
    [Group_Id]      INT          NOT NULL,
    [CreatedDate]   DATETIME     NOT NULL,
    [UpdateBy]      VARCHAR (50) NULL,
    [UpdatedDate]   DATETIME     NULL,
    [RowVersion]    ROWVERSION   NOT NULL,
    CONSTRAINT [PK__GroupUse__B6C348D0FCC38C71] PRIMARY KEY CLUSTERED ([GroupUsers_Id] ASC),
    CONSTRAINT [FK_GroupUsers_Groups] FOREIGN KEY ([Group_Id]) REFERENCES [Sec].[Groups] ([Group_Id]),
    CONSTRAINT [FK_GroupUsers_Users] FOREIGN KEY ([User_Id]) REFERENCES [HR].[Users] ([User_Id])
);

