CREATE TABLE [dbo].[User] 
(
    [GID]          INT   NOT NULL,
    [UserID]       INT   NOT NULL,
    [Username]     NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL,
    [PasswordHash] NVARCHAR (255) NOT NULL,
    [FirstName]    NVARCHAR (50)  NULL,
    [LastName]     NVARCHAR (50)  NULL,
    [PhoneNumber]  NVARCHAR (20)  NULL,
    [IsActive]     BIT            DEFAULT ((1)) NULL,
    [CreatedAt]    DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAt]    DATETIME       DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([GID] ASC, [UserID] ASC)
);
