CREATE TABLE [dbo].[PaymentInfo]
(
	[PaymentInfoId] INT NOT NULL PRIMARY KEY, 
    [CreatedOn] DATETIME2 NOT NULL, 
    [PaymentIntentId] NVARCHAR(50) NULL, 
    [PaymentAmount] BIGINT NULL, 
    [Currency] NVARCHAR(10) NULL, 
    [InvoiceId] NVARCHAR(50) NULL, 
    [PaymentMethodId] NVARCHAR(50) NULL
)
