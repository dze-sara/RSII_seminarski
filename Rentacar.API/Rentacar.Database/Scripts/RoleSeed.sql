IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='tempRole')
BEGIN
DROP TABLE [tempRole]
END
 
CREATE TABLE [tempRole](
	[RoleId] int not null
   ,[RoleName] nvarchar(30) not null
	);
GO

INSERT INTO tempRole([RoleId]
					,[RoleName])
VALUES 
	(1,'Customer'),
	(2,'Administrator')

GO
 
BEGIN TRAN
	SET IDENTITY_INSERT dbo.Role ON;

	MERGE dbo.Role Tgt
	USING tempRole Src ON Tgt.[RoleId] =Src.[RoleId]
	WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT ([RoleId]
			   ,[RoleName])
		VALUES (Src.[RoleId],
				Src.[RoleName]);

	SET IDENTITY_INSERT dbo.Role OFF;
				
COMMIT TRAN

DROP TABLE [tempRole];
GO