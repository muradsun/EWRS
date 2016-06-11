CREATE TABLE [System].[Notifications] (
    [Notification_Id]  INT           NOT NULL,
    [NotificationType] TINYINT       NOT NULL,
    [Message]          VARCHAR (MAX) NOT NULL,
    [xRef_PK]          INT           NULL,
    [RowVersion]       ROWVERSION    NOT NULL,
    CONSTRAINT [PK__Notifica__8C1160959184A31C] PRIMARY KEY CLUSTERED ([Notification_Id] ASC)
);

