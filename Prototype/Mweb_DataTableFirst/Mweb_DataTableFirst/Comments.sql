CREATE TABLE [dbo].[Comments] (
    [commentID] INT            IDENTITY (1, 1) NOT NULL,
    [markerID]  INT            NOT NULL,
    [userID]    INT            NOT NULL,
    [comment]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([commentID] ASC),
    CONSTRAINT [FK_Comment_Marker] FOREIGN KEY ([markerID]) REFERENCES [dbo].[Markers] ([markerID]),
    CONSTRAINT [FK_Comment_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[Userss] ([userID])
);

