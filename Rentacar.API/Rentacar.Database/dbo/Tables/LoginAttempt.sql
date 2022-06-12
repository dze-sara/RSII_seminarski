CREATE TABLE [dbo].[LoginAttempt]
(
	[LoginAttemptId] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NULL, 
    [AttemptedOn] DATETIME2 NOT NULL, 
    [Status] INT NOT NULL, 
    [Email] NVARCHAR(250) NULL, 
    CONSTRAINT [FK_LoginAttempt_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User](UserId)
)
