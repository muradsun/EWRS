CREATE TABLE [Sec].[Delegations] (
    [Delegation_Id]    INT          IDENTITY (1, 1) NOT NULL,
    [User_Id]          INT          NOT NULL,
    [Delegated_UserId] INT          NOT NULL,
    [FromDate]         DATE         NOT NULL,
    [ToDate]           DATE         NOT NULL,
    [CreatedDate]      DATETIME     CONSTRAINT [DF_Delegations_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdateBy]         VARCHAR (50) NULL,
    [UpdatedDate]      DATETIME     NULL,
    [RowVersion]       ROWVERSION   NOT NULL,
    CONSTRAINT [PK__Delegati__BD854AEF503E4F7D] PRIMARY KEY CLUSTERED ([Delegation_Id] ASC),
    CONSTRAINT [FK_Delegations_Users] FOREIGN KEY ([User_Id]) REFERENCES [HR].[Users] ([User_Id]),
    CONSTRAINT [FK_Delegations_Users1] FOREIGN KEY ([Delegated_UserId]) REFERENCES [HR].[Users] ([User_Id])
);
GO

