IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='tempBrand')
BEGIN
DROP TABLE [tempBrand]
END
 
CREATE TABLE [tempBrand](
	[BrandId] int not null
   ,[BrandName] nvarchar(30) not null
   ,[BrandDescription] nvarchar(250)
	);
GO

INSERT INTO tempBrand([BrandId]
					 ,[BrandName]
					 ,[BrandDescription])
VALUES 
	(1,'BMW', 'A German sports-car brand.')
	,(2,'Mercedes', 'A German luxury-car brand.')
	,(3,'Volvo', 'A Sweedish car brand.')
	,(4,'VW', 'A German car brand.')
	,(5,'Renault', 'A French car brand.')

GO
 
BEGIN TRAN
	SET IDENTITY_INSERT dbo.Brand ON;

	MERGE dbo.Brand Tgt
	USING tempBrand Src ON Tgt.[BrandId] =Src.[BrandId]
	WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT ([BrandId]
			   ,[BrandName]
			   ,[BrandDescription])
		VALUES (Src.[BrandId],
				Src.[BrandName],
				Src.[BrandDescription]);

	SET IDENTITY_INSERT dbo.Brand OFF;
				
COMMIT TRAN

DROP TABLE [tempBrand];
GO