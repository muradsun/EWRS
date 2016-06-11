CREATE TABLE [Weekly].[WeeklyInputHistory] (
    [WeeklyInputHistory_Id] INT             IDENTITY (1, 1) NOT NULL,
    [WeeklyInput_Id]        INT             NOT NULL,
    [Comment]               NVARCHAR (1000) NULL,
    [InputText]             NVARCHAR (MAX)  NOT NULL,
    [ActionBy_UserId]       INT             NOT NULL,
    [Action]                CHAR (10)       NOT NULL,
    [ActionDate]            DATETIME        NOT NULL,
    [Subject_Id]            INT             NOT NULL,
    [CreatedDate]           DATETIME        NOT NULL,
    [UpdateBy]              VARCHAR (50)    NULL,
    [UpdatedDate]           DATETIME        NULL,
    [RowVersion]            ROWVERSION      NOT NULL,
    CONSTRAINT [PK_WeeklyInputHistory] PRIMARY KEY CLUSTERED ([WeeklyInputHistory_Id] ASC),
    CONSTRAINT [FK_WeeklyInputHistory_Subjects] FOREIGN KEY ([Subject_Id]) REFERENCES [Weekly].[Subjects] ([Subject_Id]),
    CONSTRAINT [FK_WeeklyInputHistory_WeeklyInput] FOREIGN KEY ([WeeklyInput_Id]) REFERENCES [Weekly].[WeeklyInput] ([WeeklyInput_Id])
);

