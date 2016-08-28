CREATE TABLE [Weekly].[ReviewWorkflowActors] (
    [ReviewWorkflowActor_Id] INT          IDENTITY (1, 1) NOT NULL,
    [ReviewWorkflow_Id]      INT          NOT NULL,
    [SequenceNo]             TINYINT      NOT NULL,
    [Group_Id]               INT          NULL,
    [User_Id]                INT          NULL,
    [CreatedBy]              VARCHAR (50) NOT NULL,
    [CreatedDate]            DATETIME     NOT NULL,
    [UpdateBy]               VARCHAR (50) NULL,
    [UpdatedDate]            DATETIME     NULL,
    [RowVersion]             ROWVERSION   NOT NULL,
    CONSTRAINT [PK_ReviewWorkflowActors_1] PRIMARY KEY CLUSTERED ([ReviewWorkflowActor_Id] ASC),
    CONSTRAINT [FK_ReviewWorkflowActors_ReviewWorkflows] FOREIGN KEY ([ReviewWorkflow_Id]) REFERENCES [Weekly].[ReviewWorkflows] ([ReviewWorkflow_Id])
);

