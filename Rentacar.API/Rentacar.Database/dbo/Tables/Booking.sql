-- Model New Model
-- Updated 1/7/2022 10:02:20 PM
-- DDL Generated 1/7/2022 10:03:10 PM

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
[IsCancelled] BIT NOT NULL DEFAULT 0, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
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