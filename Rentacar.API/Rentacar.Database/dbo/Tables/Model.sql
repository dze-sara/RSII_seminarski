-- Table dbo.Model
create table
	[dbo].[Model]
(
	[ModelId] int identity(1,1) not null
	, [ModelName] nvarchar(50) not null
	, [ModelDescription] text not null
	, [Year] nvarchar(5) not null
	, [NoOfSeats] smallint not null
	, [MakeId] int not null
	, [VehicleTypeId] int not null
,
constraint [Pk_Model_ModelId] primary key clustered
(
	[ModelId] asc
)
);
GO
-- Relationship Fk_VehicleType_Model_VehicleTypeId
alter table [dbo].[Model]
add constraint [Fk_VehicleType_Model_VehicleTypeId] foreign key ([VehicleTypeId]) references [dbo].[VehicleType] ([VehicleTypeId]);
GO
-- Relationship Fk_Make_Model_MakeId
alter table [dbo].[Model]
add constraint [Fk_Make_Model_MakeId] foreign key ([MakeId]) references [dbo].[Make] ([MakeId]);