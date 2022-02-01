-- Table dbo.User
create table
	[dbo].[User]
(
	[UserId] int identity(1,1) not null
	, [Email] nvarchar(250) not null
	, [FirstName] nvarchar(50) not null
	, [LastName] nvarchar(50) not null
	, [Password] nvarchar(10) not null
	, [DateCreated] datetime2(7) not null
	, [DateUpdated] datetime2(7) null
	, [RoleId] int not null
,
constraint [Pk_User_UserId] primary key clustered
(
	[UserId] asc
)
);
GO
-- Relationship Fk_Role_User_RoleId
alter table [dbo].[User]
add constraint [Fk_Role_User_RoleId] foreign key ([RoleId]) references [dbo].[Role] ([RoleId]);