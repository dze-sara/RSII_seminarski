-- Table dbo.Location
create table
	[dbo].[Location]
(
	[LocationId] int identity(1,1) not null
	, [LocationName] nvarchar(50) not null
	, [LocationDescription] text null
	, [Address] nvarchar(150) not null
,
constraint [Pk_Location_LocationId] primary key clustered
(
	[LocationId] asc
)
);