IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='tempVehicleTypes')
BEGIN
DROP TABLE [tempVehicleTypes]
END
 
CREATE TABLE [tempVehicleTypes](
	[VehicleTypeId] int not null
   ,[VehicleTypeName] nvarchar(30) not null
	);
GO

INSERT INTO tempVehicleTypes([VehicleTypeId]
							,[VehicleTypeName])
VALUES 
	(1,'Small-Car'),
	(2,'Sedan'),
	(3,'SUV')

GO
 
BEGIN TRAN
	SET IDENTITY_INSERT dbo.VehicleType ON;

	MERGE dbo.VehicleType Tgt
	USING tempVehicleTypes Src ON Tgt.[VehicleTypeId] =Src.[VehicleTypeId]
	WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT ([VehicleTypeId]
			   ,[VehicleTypeName])
		VALUES (Src.[VehicleTypeId],
				Src.[VehicleTypeName]);

	SET IDENTITY_INSERT dbo.VehicleType OFF;
				
COMMIT TRAN

DROP TABLE [tempVehicleTypes];
GO