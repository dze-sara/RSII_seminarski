-- Table dbo.Log
create table
	[dbo].[Log]
(
	[LogId] int not null
	, [Message] nvarchar(150) not null
	, [AdditionalInfo] nvarchar(150) null
,
constraint [Pk_Log_LogId] primary key clustered
(
	[LogId] asc
)
);