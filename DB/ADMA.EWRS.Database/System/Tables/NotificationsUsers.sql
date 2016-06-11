CREATE TABLE [System].[NotificationsUsers] (
    [NotificationUser_Id] INT        NOT NULL,
    [Notification_Id]     INT        NOT NULL,
    [User_id]             INT        NOT NULL,
    [IsRead]              BIT        CONSTRAINT [DF__Notificat__IsRea__45F365D3] DEFAULT ((0)) NOT NULL,
    [RowVersion]          ROWVERSION NOT NULL,
    CONSTRAINT [PK__Notifica__15FEC1C85DAD0265] PRIMARY KEY CLUSTERED ([NotificationUser_Id] ASC),
    CONSTRAINT [FK_NotificationsUsers_Notifications] FOREIGN KEY ([Notification_Id]) REFERENCES [System].[Notifications] ([Notification_Id]),
    CONSTRAINT [FK_NotificationsUsers_Users] FOREIGN KEY ([User_id]) REFERENCES [HR].[Users] ([User_Id])
);

