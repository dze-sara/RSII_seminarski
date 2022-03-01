-- Table dbo.BookingHistory
create table
	[dbo].[BookingHistory]
(
	[BookingId] int identity(1,1) not null
	, [StartDate] datetime2(7) not null
	, [EndDate] datetime2(7) not null
	, [CreatedDate] datetime2(7) not null
	, [UpdatedDate] datetime2(7) null
	, [VehicleId] int not null
	, [UserId] int not null
,
constraint [Pk_BookingHistory_BookingId] primary key clustered
(
	[BookingId] asc
)
);
GO
-- Relationship Fk_User_BookingHistory_UserId
alter table [dbo].[BookingHistory]
add constraint [Fk_User_BookingHistory_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);
GO
-- Relationship Fk_Vehicle_BookingHistory_VehicleId
alter table [dbo].[BookingHistory]
add constraint [Fk_Vehicle_BookingHistory_VehicleId] foreign key ([VehicleId]) references [dbo].[Vehicle] ([VehicleId]);