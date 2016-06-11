CREATE TABLE [Weekly].[ReviewWorkflowInstances] (
    [ReviewWorkflowInstance_Id]  INT             IDENTITY (1, 1) NOT NULL,
    [SequenceNo]                 TINYINT         NOT NULL,
    [WeeklyInput_Id]             INT             NULL,
    [ReviewWorkflowsProjects_Id] INT             NOT NULL,
    [Comment]                    NVARCHAR (1000) NULL,
    [Action]                     CHAR (10)       NOT NULL,
    [ReadDate]                   DATETIME        NULL,
    [ActionDate]                 DATETIME        NULL,
    [User_Id]                    INT             NULL,
    [Group_Id]                   INT             NULL,
    [ActionBy_UserId]            INT             NULL,
    [CreatedDate]                DATETIME        NOT NULL,
    [UpdateBy]                   VARCHAR (50)    NULL,
    [UpdatedDate]                DATETIME        NULL,
    [RowVersion]                 ROWVERSION      NOT NULL,
    CONSTRAINT [PK_ReviewWorkflowInstances] PRIMARY KEY CLUSTERED ([ReviewWorkflowInstance_Id] ASC),
    CONSTRAINT [FK_ReviewWorkflowInstances_ReviewWorkflowsProjects] FOREIGN KEY ([ReviewWorkflowsProjects_Id]) REFERENCES [Weekly].[ReviewWorkflowsProjects] ([ReviewWorkflowsProjects_Id]),
    CONSTRAINT [FK_ReviewWorkflowInstances_WeeklyInput] FOREIGN KEY ([WeeklyInput_Id]) REFERENCES [Weekly].[WeeklyInput] ([WeeklyInput_Id])
);

