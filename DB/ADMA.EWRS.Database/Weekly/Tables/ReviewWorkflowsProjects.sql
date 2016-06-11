CREATE TABLE [Weekly].[ReviewWorkflowsProjects] (
    [ReviewWorkflowsProjects_Id] INT          IDENTITY (1, 1) NOT NULL,
    [IsProjectDefaultWorkflow]   BIT          NOT NULL,
    [TeamModel_Id]               INT          NULL,
    [Project_Id]                 INT          NOT NULL,
    [ReviewWorkflow_Id]          INT          NOT NULL,
    [CreatedBy]                  VARCHAR (50) NOT NULL,
    [CreatedDate]                DATETIME     NOT NULL,
    [UpdateBy]                   VARCHAR (50) NULL,
    [UpdatedDate]                DATETIME     NULL,
    [RowVersion]                 ROWVERSION   NOT NULL,
    CONSTRAINT [PK_ReviewWorkflowsProjects] PRIMARY KEY CLUSTERED ([ReviewWorkflowsProjects_Id] ASC),
    CONSTRAINT [FK_ReviewWorkflowsProjects_Projects] FOREIGN KEY ([Project_Id]) REFERENCES [Weekly].[Projects] ([Project_Id]),
    CONSTRAINT [FK_ReviewWorkflowsProjects_ReviewWorkflows] FOREIGN KEY ([ReviewWorkflow_Id]) REFERENCES [Weekly].[ReviewWorkflows] ([ReviewWorkflow_Id])
);

