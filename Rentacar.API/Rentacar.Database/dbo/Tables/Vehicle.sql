-- Table dbo.Vehicle
create table
	[dbo].[Vehicle]
(
	[VehicleId] int identity(1,1) not null
	, [RatePerDay] decimal(18,0) not null
	, [IsActive] bit not null
	, [TransmissionType] smallint not null
	, [ModelId] int not null
	, [LocationId] int not null
,
constraint [Pk_Vehicle_VehicleId] primary key clustered
(
	[VehicleId] asc
)
);
GO
-- Relationship Fk_Model_Vehicle_ModelId
alter table [dbo].[Vehicle]
add constraint [Fk_Model_Vehicle_ModelId] foreign key ([ModelId]) references [dbo].[Model] ([ModelId]);
GO
-- Relationship Fk_Location_Vehicle_LocationId
alter table [dbo].[Vehicle]
add constraint [Fk_Location_Vehicle_LocationId] foreign key ([LocationId]) references [dbo].[Location] ([LocationId]);