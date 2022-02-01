IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='tempMake')
BEGIN
DROP TABLE [tempMake]
END
 
CREATE TABLE [tempMake](
	[MakeId] int not null
	, [MakeName] nvarchar(50) not null
	, [MakeDescription] text not null
	, [Year] nvarchar(5) not null
	, [NoOfSeats] smallint not null
	, [BrandId] int not null
	);
GO

INSERT INTO tempMake([MakeId]
					 ,[MakeName]
					 ,[MakeDescription]
					 ,[Year]
					 ,[NoOfSeats]
					 ,[BrandId])
VALUES 
	(1,'V40', 'A classic hatch.', '2019', 5, 3)
	,(2,'Up', 'A tiny city car.', '2020', 5, 4)
	,(3,'Polo', 'A small city car.', '2020', 5, 4)
	,(4,'Clio', 'A German car Make.', '2020', 5, 5)
	,(5,'M1', 'A fun sports car.', '2015', 5, 1)

GO
 
BEGIN TRAN
	SET IDENTITY_INSERT dbo.Make ON;

	MERGE dbo.Make Tgt
	USING tempMake Src ON Tgt.[MakeId] =Src.[MakeId]
	WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT ([MakeId]
			   ,[MakeName]
			   ,[MakeDescription]
			   ,[Year]
			   ,[NoOfSeats]
			   ,[BrandId])
		VALUES (Src.[MakeId],
				Src.[MakeName],
				Src.[MakeDescription],
				Src.[Year],
				Src.[NoOfSeats],
				Src.[BrandId]);

	SET IDENTITY_INSERT dbo.Make OFF;
				
COMMIT TRAN

DROP TABLE [tempMake];
GO