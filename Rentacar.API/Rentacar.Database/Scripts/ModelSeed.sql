IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='tempModel')
BEGIN
DROP TABLE [tempModel]
END
 
CREATE TABLE [tempModel](
	[ModelId] int not null
	, [ModelName] nvarchar(50) not null
	, [ModelDescription] text not null
	, [Year] nvarchar(5) not null
	, [NoOfSeats] smallint not null
	, [BrandId] int not null
	);
GO

INSERT INTO tempModel([ModelId]
					 ,[ModelName]
					 ,[ModelDescription]
					 ,[Year]
					 ,[NoOfSeats]
					 ,[BrandId])
VALUES 
	(1,'V40', 'A classic hatch.', '2019', 5, 3)
	,(2,'Up', 'A tiny city car.', '2020', 5, 4)
	,(3,'Polo', 'A small city car.', '2020', 5, 4)
	,(4,'Clio', 'A German car Model.', '2020', 5, 5)
	,(5,'M1', 'A fun sports car.', '2015', 5, 1)

GO
 
BEGIN TRAN
	SET IDENTITY_INSERT dbo.Model ON;

	MERGE dbo.Model Tgt
	USING tempModel Src ON Tgt.[ModelId] =Src.[ModelId]
	WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT ([ModelId]
			   ,[ModelName]
			   ,[ModelDescription]
			   ,[Year]
			   ,[NoOfSeats]
			   ,[BrandId])
		VALUES (Src.[ModelId],
				Src.[ModelName],
				Src.[ModelDescription],
				Src.[Year],
				Src.[NoOfSeats],
				Src.[BrandId]);

	SET IDENTITY_INSERT dbo.Model OFF;
				
COMMIT TRAN

DROP TABLE [tempModel];
GO