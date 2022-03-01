IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='tempMake')
BEGIN
DROP TABLE [tempMake]
END
 
CREATE TABLE [tempMake](
	[MakeId] int not null
   ,[MakeName] nvarchar(30) not null
   ,[MakeDescription] nvarchar(250)
	);
GO

INSERT INTO tempMake([MakeId]
					 ,[MakeName]
					 ,[MakeDescription])
VALUES 
	(1,'BMW', 'A German sports-car Make.')
	,(2,'Mercedes', 'A German luxury-car Make.')
	,(3,'Volvo', 'A Sweedish car Make.')
	,(4,'VW', 'A German car Make.')
	,(5,'Renault', 'A French car Make.')

GO
 
BEGIN TRAN
	SET IDENTITY_INSERT dbo.Make ON;

	MERGE dbo.Make Tgt
	USING tempMake Src ON Tgt.[MakeId] =Src.[MakeId]
	WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT ([MakeId]
			   ,[MakeName]
			   ,[MakeDescription])
		VALUES (Src.[MakeId],
				Src.[MakeName],
				Src.[MakeDescription]);

	SET IDENTITY_INSERT dbo.Make OFF;
				
COMMIT TRAN

DROP TABLE [tempMake];
GO