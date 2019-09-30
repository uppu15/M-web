CREATE TABLE [dbo].[Markers] (
    [markerID]  INT             IDENTITY (1, 1) NOT NULL,
    [userID]    INT             NOT NULL,
    [markerLat] DECIMAL (10, 6) NOT NULL,
    [markerLng] DECIMAL (10, 6) NOT NULL,
    [photo]     IMAGE           NOT NULL,
    [photoPath] VARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_Marker] PRIMARY KEY CLUSTERED ([markerID] ASC),
    CONSTRAINT [FK_Marker_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[Userss] ([userID])
);