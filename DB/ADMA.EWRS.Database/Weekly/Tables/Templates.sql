CREATE TABLE [Weekly].[Templates] (
    [Template_Id] INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (500) NOT NULL,
    [Project_Id]  INT            NOT NULL,
    [CreatedBy]   VARCHAR (50)   NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdateBy]    VARCHAR (50)   NULL,
    [UpdatedDate] DATETIME       NULL,
    [RowVersion]  ROWVERSION     NOT NULL,
    PRIMARY KEY CLUSTERED ([Template_Id] ASC),
    CONSTRAINT [FK_Templates_Projects] FOREIGN KEY ([Project_Id]) REFERENCES [Weekly].[Projects] ([Project_Id])
);

