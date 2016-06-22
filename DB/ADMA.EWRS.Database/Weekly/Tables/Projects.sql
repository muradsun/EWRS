CREATE TABLE [Weekly].[Projects] (
    [Project_Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (500)  NOT NULL,
    [Description]	nvarchar(1000),
    [PercentComplete]  TINYINT        DEFAULT ((0)) NOT NULL,
    [ProjectStatus_Id] TINYINT        DEFAULT ((1)) NOT NULL,
    [StatusReason]     NVARCHAR (MAX) NULL,
    [ORGANIZATION_ID]  INT            NOT NULL,
    [CreatedBy]        VARCHAR (50)   NOT NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [UpdateBy]         VARCHAR (50)   NULL,
    [UpdatedDate]      DATETIME       NULL,
    [RowVersion]       ROWVERSION     NOT NULL,
    PRIMARY KEY CLUSTERED ([Project_Id] ASC),
    CONSTRAINT [FK_Projects_ProjectStatuses] FOREIGN KEY ([ProjectStatus_Id]) REFERENCES [Weekly].[ProjectStatuses] ([ProjectStatus_Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'See 5.1.1	PROJECTS : 2. Deactivate/1. Activate, 3. Complete,  4. Close', @level0type = N'SCHEMA', @level0name = N'Weekly', @level1type = N'TABLE', @level1name = N'Projects', @level2type = N'COLUMN', @level2name = N'ProjectStatus_Id';

