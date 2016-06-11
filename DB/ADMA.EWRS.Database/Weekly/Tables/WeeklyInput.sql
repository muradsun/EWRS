CREATE TABLE [Weekly].[WeeklyInput] (
    [WeeklyInput_Id]  INT            IDENTITY (1, 1) NOT NULL,
    [InputText]       NVARCHAR (MAX) NOT NULL,
    [Subject_Id]      INT            NOT NULL,
    [WeekNo]          INT            NOT NULL,
    [IsLocked]        BIT            NOT NULL,
    [LockedBy_UserId] INT            NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [UpdateBy]        VARCHAR (50)   NULL,
    [UpdatedDate]     DATETIME       NULL,
    [RowVersion]      ROWVERSION     NOT NULL,
    CONSTRAINT [PK__WeeklyIn__3214EC07A02742CA] PRIMARY KEY CLUSTERED ([WeeklyInput_Id] ASC),
    CONSTRAINT [FK_WeeklyInput_Subjects] FOREIGN KEY ([Subject_Id]) REFERENCES [Weekly].[Subjects] ([Subject_Id])
);

