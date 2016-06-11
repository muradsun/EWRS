CREATE TABLE [Sec].[Groups] (
    [Group_Id]     INT           NOT NULL,
    [Name]         VARCHAR (MAX) NOT NULL,
    [IsSystemGoup] BIT           CONSTRAINT [DF__Groups__IsSystem__44FF419A] DEFAULT ((1)) NOT NULL,
    [Owner_UserId] INT           NOT NULL,
    [CreatedDate]  DATETIME      NOT NULL,
    [UpdateBy]     VARCHAR (50)  NULL,
    [UpdatedDate]  DATETIME      NULL,
    [RowVersion]   ROWVERSION    NOT NULL,
    CONSTRAINT [PK__Groups__3198120910630712] PRIMARY KEY CLUSTERED ([Group_Id] ASC),
    CONSTRAINT [FK_Groups_Users] FOREIGN KEY ([Owner_UserId]) REFERENCES [HR].[Users] ([User_Id])
);

