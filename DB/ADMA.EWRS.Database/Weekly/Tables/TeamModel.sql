CREATE TABLE [Weekly].[TeamModel] (
    [TeamModel_Id]          INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]               INT            NULL,
    [Group_Id]              INT            NULL,
    [Project_Id]            INT            NOT NULL,
    [IsUpdater]             BIT            NOT NULL,
    [IsProjectLevelUpdater] BIT            NOT NULL,
    [CreatedBy]             VARCHAR (50)   NOT NULL,
    [CreatedDate]           DATETIME       NOT NULL,
    [UpdateBy]              VARCHAR (50)   NULL,
    [UpdatedDate]           DATETIME       NULL,
    [RowVersion]            ROWVERSION     NOT NULL,
    [Name]                  NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK__TeamMode__0B36CEAB8F01680B] PRIMARY KEY CLUSTERED ([TeamModel_Id] ASC),
    CONSTRAINT [FK_TeamModel_Groups] FOREIGN KEY ([Group_Id]) REFERENCES [Sec].[Groups] ([Group_Id]),
    CONSTRAINT [FK_TeamModel_Projects] FOREIGN KEY ([Project_Id]) REFERENCES [Weekly].[Projects] ([Project_Id]),
    CONSTRAINT [FK_TeamModel_Users] FOREIGN KEY ([User_Id]) REFERENCES [HR].[Users] ([User_Id])
);

