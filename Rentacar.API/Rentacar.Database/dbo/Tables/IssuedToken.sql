CREATE TABLE [dbo].[IssuedToken]
(
	[TokenId] INT NOT NULL PRIMARY KEY, 
    [TokenValue] NVARCHAR(MAX) NOT NULL, 
    [IssuedOn] DATETIME2 NOT NULL, 
    [ValidFor] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_IssuedToken_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
