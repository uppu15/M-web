CREATE TABLE [dbo].[Users] (
    [userID]       INT           IDENTITY (1, 1) NOT NULL,
    [userName]     VARCHAR (18)  NOT NULL,
    [userEmail]    VARCHAR (MAX) NOT NULL,
    [userPassword] VARCHAR (50)  NOT NULL,
    [created]      ROWVERSION    NOT NULL,
    [userStatus]   VARCHAR (19)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([userID] ASC)
);

