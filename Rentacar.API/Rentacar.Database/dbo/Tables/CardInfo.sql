CREATE TABLE [dbo].[CardInfo]
(
	[CardInfoId] INT NOT NULL PRIMARY KEY, 
    [CardNumber] NVARCHAR(50) NOT NULL, 
    [ExpiryDate] NCHAR(10) NOT NULL
)
