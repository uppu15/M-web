CREATE TABLE [dbo].[UserSetting] (
    [settingID]  INT             IDENTITY (1, 1) NOT NULL,
    [userID]     INT             NOT NULL,
    [centerLat]  DECIMAL (10, 6) NOT NULL,
    [centerLng]  DECIMAL (10, 6) NOT NULL,
    [centerZoom] INT             NOT NULL,
    [mapType]    VARCHAR (10)    NOT NULL,
    [pinRadius]  INT             NOT NULL,
    [GPS]        BIT             NOT NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([settingID] ASC),
    CONSTRAINT [FK_Settings_Users] FOREIGN KEY ([userID]) REFERENCES [dbo].[Users] ([userID])
);

