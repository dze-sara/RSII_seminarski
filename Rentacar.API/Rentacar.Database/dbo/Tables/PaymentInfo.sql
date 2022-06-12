CREATE TABLE [dbo].[PaymentInfo]
(
	[PaymentInfoId] INT NOT NULL PRIMARY KEY, 
    [CreatedOn] DATETIME2 NOT NULL, 
    [PaymentIntentId] NVARCHAR(50) NOT NULL, 
    [PaymentAmount] BIGINT NOT NULL, 
    [Currency] NVARCHAR(10) NOT NULL, 
    [InvoiceId] NVARCHAR(50) NOT NULL, 
    [PaymentMethodId] NVARCHAR(50) NOT NULL
)
