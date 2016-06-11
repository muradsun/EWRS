CREATE TABLE [Weekly].[TeamModelSubjects] (
    [TeamModelSubjects_Id] INT          IDENTITY (1, 1) NOT NULL,
    [TeamModel_Id]         INT          NOT NULL,
    [Subject_Id]           INT          NOT NULL,
    [CreatedBy]            VARCHAR (50) NOT NULL,
    [CreatedDate]          DATETIME     NOT NULL,
    [UpdateBy]             VARCHAR (50) NULL,
    [UpdatedDate]          DATETIME     NULL,
    [RowVersion]           ROWVERSION   NOT NULL,
    CONSTRAINT [PK__TeamMode__F89B0A9BF9C2C0FF] PRIMARY KEY CLUSTERED ([TeamModelSubjects_Id] ASC),
    CONSTRAINT [FK_TeamModelSubjects_Subjects] FOREIGN KEY ([Subject_Id]) REFERENCES [Weekly].[Subjects] ([Subject_Id]),
    CONSTRAINT [FK_TeamModelSubjects_TeamModel] FOREIGN KEY ([TeamModel_Id]) REFERENCES [Weekly].[TeamModel] ([TeamModel_Id])
);

