-- Table dbo.Brand
create table
	[dbo].[Brand]
(
	[BrandId] int identity(1,1) not null
	, [BrandName] nvarchar(50) not null
	, [BrandDescription] nvarchar(250) not null
,
constraint [Pk_Brand_BrandId] primary key clustered
(
	[BrandId] asc
)
);