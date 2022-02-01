-- Table dbo.VehicleType
create table
	[dbo].[VehicleType]
(
	[VehicleTypeId] int identity(1,1) not null
	, [VehicleTypeName] nvarchar(30) not null
,
constraint [Pk_VehicleType_VehicleTypeId] primary key clustered
(
	[VehicleTypeId] asc
)
);