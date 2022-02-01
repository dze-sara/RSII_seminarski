-- Table dbo.Vehicle
create table
	[dbo].[Vehicle]
(
	[VehicleId] int identity(1,1) not null
	, [RatePerDay] decimal(18,0) not null
	, [IsActive] bit not null
	, [VehicleTypeId] int not null
	, [TransmissionType] smallint not null
	, [MakeId] int not null
,
constraint [Pk_Vehicle_VehicleId] primary key clustered
(
	[VehicleId] asc
)
);
GO
-- Relationship Fk_VehicleType_Vehicle_VehicleTypeId
alter table [dbo].[Vehicle]
add constraint [Fk_VehicleType_Vehicle_VehicleTypeId] foreign key ([VehicleTypeId]) references [dbo].[VehicleType] ([VehicleTypeId]);
GO
-- Relationship Fk_Make_Vehicle_MakeId
alter table [dbo].[Vehicle]
add constraint [Fk_Make_Vehicle_MakeId] foreign key ([MakeId]) references [dbo].[Make] ([MakeId]);