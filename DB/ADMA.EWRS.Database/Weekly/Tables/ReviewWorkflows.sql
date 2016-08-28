CREATE TABLE [Weekly].[ReviewWorkflows] (
    [ReviewWorkflow_Id] INT            IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (1000) NOT NULL,
    [CreatedBy]         VARCHAR (50)   NOT NULL,
    [CreatedDate]       DATETIME       NOT NULL,
    [UpdateBy]          VARCHAR (50)   NULL,
    [UpdatedDate]       DATETIME       NULL,
    [RowVersion]        ROWVERSION     NOT NULL,
    [Owner_UserId]      INT            NOT NULL,
    CONSTRAINT [PK__ReviewWo__01C8CA7A05660BD7] PRIMARY KEY CLUSTERED ([ReviewWorkflow_Id] ASC),
    CONSTRAINT [FK_ReviewWorkflows_Users1] FOREIGN KEY ([Owner_UserId]) REFERENCES [HR].[Users] ([User_Id])
);



