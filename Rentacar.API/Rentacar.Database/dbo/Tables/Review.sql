-- Table dbo.Review
create table
	[dbo].[Review]
(
	[ReviewId] int identity(1,1) not null
	, [Content] text not null
	, [Score] smallint not null
	, [ModelId] int not null
,
constraint [Pk_Review_ReviewId] primary key clustered
(
	[ReviewId] asc
)
);
GO
-- Relationship Fk_Model_Review_ModelId
alter table [dbo].[Review]
add constraint [Fk_Model_Review_ModelId] foreign key ([ModelId]) references [dbo].[Model] ([ModelId]);