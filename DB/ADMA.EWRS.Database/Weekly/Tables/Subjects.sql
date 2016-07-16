CREATE TABLE [Weekly].[Subjects] (
    [Subject_Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (1000) NOT NULL,
    [Template_Id]      INT            NOT NULL,
    [SubjectStatus_Id] TINYINT        CONSTRAINT [DF_Subjects_ProjectStatus_Id] DEFAULT ((1)) NOT NULL,
    [PercentComplete]  TINYINT        CONSTRAINT [DF__Subjects__Percen__46E78A0C] DEFAULT ((0)) NOT NULL,
    [DueDate]          DATE           NULL,
    [IsMandatory]      BIT            CONSTRAINT [DF_Subjects_IsMandatory] DEFAULT ((0)) NOT NULL,
    [CreatedBy]        VARCHAR (50)   NOT NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [UpdateBy]         VARCHAR (50)   NULL,
    [UpdatedDate]      DATETIME       NULL,
    [RowVersion]       ROWVERSION     NOT NULL,
    [Project_Id]       INT            NOT NULL,
    [SequenceNo]       TINYINT        NOT NULL,
    CONSTRAINT [PK__Subjects__D98F54B685E97555] PRIMARY KEY CLUSTERED ([Subject_Id] ASC),
    CONSTRAINT [FK_Subjects_SubjectStatuses] FOREIGN KEY ([SubjectStatus_Id]) REFERENCES [Weekly].[SubjectStatuses] ([SubjectStatus_Id]),
    CONSTRAINT [FK_Subjects_Templates] FOREIGN KEY ([Template_Id]) REFERENCES [Weekly].[Templates] ([Template_Id])
);



