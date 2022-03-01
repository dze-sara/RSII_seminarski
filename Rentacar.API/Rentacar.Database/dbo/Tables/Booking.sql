-- Model New Model
-- Updated 3/1/2022 4:02:01 PM
-- DDL Generated 3/1/2022 4:02:04 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Booking
create table
	[dbo].[Booking]
(
	[BookingId] int identity(1,1) not null
	, [StartDate] datetime2(7) not null
	, [EndDate] datetime2(7) not null
	, [CreatedDate] datetime2(7) not null
	, [UpdatedDate] datetime2(7) null
	, [UserId] int not null
	, [VehicleId] int not null
,
constraint [Pk_Booking_BookingId] primary key clustered
(
	[BookingId] asc
)
);
GO
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_User_Booking_UserId
alter table [dbo].[Booking]
add constraint [Fk_User_Booking_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);
GO
-- Relationship Fk_Vehicle_Booking_VehicleId
alter table [dbo].[Booking]
add constraint [Fk_Vehicle_Booking_VehicleId] foreign key ([VehicleId]) references [dbo].[Vehicle] ([VehicleId]);