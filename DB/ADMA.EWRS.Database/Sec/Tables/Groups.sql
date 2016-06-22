CREATE TABLE [Sec].[Groups] (
    [Group_Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [IsSystemGoup] BIT            CONSTRAINT [DF__Groups__IsSystem__44FF419A] DEFAULT ((1)) NOT NULL,
    [Owner_UserId] INT            NULL,
    [CreatedBy]    VARCHAR (50)   NOT NULL,
    [CreatedDate]  DATETIME       CONSTRAINT [DF_Groups_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdateBy]     VARCHAR (50)   NULL,
    [UpdatedDate]  DATETIME       NULL,
    [RowVersion]   ROWVERSION     NOT NULL,
    CONSTRAINT [PK__Groups__3198120910630712] PRIMARY KEY CLUSTERED ([Group_Id] ASC),
    CONSTRAINT [FK_Groups_Users] FOREIGN KEY ([Owner_UserId]) REFERENCES [HR].[Users] ([User_Id])
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Groups_Name]
    ON [Sec].[Groups]([Name] ASC);

