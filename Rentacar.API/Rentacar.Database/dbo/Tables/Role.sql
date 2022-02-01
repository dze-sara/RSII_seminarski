-- Table dbo.Role
create table
	[dbo].[Role]
(
	[RoleId] int identity(1,1) not null
	, [RoleName] nvarchar(20) not null
,
constraint [Pk_Role_RoleId] primary key clustered
(
	[RoleId] asc
)
);