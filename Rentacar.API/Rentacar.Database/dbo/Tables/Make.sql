-- Table dbo.Make
create table
	[dbo].[Make]
(
	[MakeId] int identity(1,1) not null
	, [MakeName] nvarchar(50) not null
	, [MakeDescription] nvarchar(250) not null
,
constraint [Pk_Make_MakeId] primary key clustered
(
	[MakeId] asc
)
);