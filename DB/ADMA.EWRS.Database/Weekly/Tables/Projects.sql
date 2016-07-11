CREATE TABLE [Weekly].[Projects] (
    [Project_Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (500)   NOT NULL,
    [Description]      NVARCHAR (1000) NULL,
    [PercentComplete]  TINYINT         CONSTRAINT [DF__tmp_ms_xx__Perce__2EA5EC27] DEFAULT ((0)) NOT NULL,
    [ProjectStatus_Id] INT             CONSTRAINT [DF__tmp_ms_xx__Proje__2F9A1060] DEFAULT ((1)) NOT NULL,
    [StatusReason]     NVARCHAR (MAX)  NULL,
    [ORGANIZATION_ID]  INT             NOT NULL,
    [Owner_UserId]     INT             NOT NULL,
    [CreatedBy]        VARCHAR (50)    NOT NULL,
    [CreatedDate]      DATETIME        NOT NULL,
    [UpdateBy]         VARCHAR (50)    NULL,
    [UpdatedDate]      DATETIME        NULL,
    [RowVersion]       ROWVERSION      NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__1CB92E03462033B7] PRIMARY KEY CLUSTERED ([Project_Id] ASC),
    CONSTRAINT [FK_Projects_ProjectStatuses] FOREIGN KEY ([ProjectStatus_Id]) REFERENCES [Weekly].[ProjectStatuses] ([ProjectStatus_Id]),
    CONSTRAINT [FK_Projects_Users] FOREIGN KEY ([Owner_UserId]) REFERENCES [HR].[Users] ([User_Id])
);
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'See 5.1.1	PROJECTS : 2. Deactivate/1. Activate, 3. Complete,  4. Close', @level0type = N'SCHEMA', @level0name = N'Weekly', @level1type = N'TABLE', @level1name = N'Projects', @level2type = N'COLUMN', @level2name = N'ProjectStatus_Id';
GO

