-- Table dbo.Make
create table
	[dbo].[Make]
(
	[MakeId] int identity(1,1) not null
	, [MakeName] nvarchar(50) not null
	, [MakeDescription] text not null
	, [Year] nvarchar(5) not null
	, [NoOfSeats] smallint not null
	, [BrandId] int not null
,
constraint [Pk_Make_MakeId] primary key clustered
(
	[MakeId] asc
)
);
GO
-- Relationship Fk_Brand_Make_BrandId
alter table [dbo].[Make]
add constraint [Fk_Brand_Make_BrandId] foreign key ([BrandId]) references [dbo].[Brand] ([BrandId]);