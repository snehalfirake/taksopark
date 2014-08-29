create table [Request]
(
	[Id] int identity(1 ,1) not null primary key,
	[RequetTime] datetime not null,
	[CreatorId] int not null,
	[PhoneNumber] text,
	[Status] varchar(15),
	[StartPoint] text,
	[FinishPoint] text,
	[OperatorId] int
)

create table [Users]
(
	[Id] int identity(1 ,1) not null primary key,
	[Name] text not null,
	[LastName] text not null,
	[Login] text,
	[Password] char(60),
	[Role] varchar(15),
	[Status] varchar(15)
)

create table [Cars]
(
	[Id] int identity(1 ,1) not null primary key references [Users](Id),
	[Brand] text,
	[Year] varchar(4),
	[StartWorkTime] datetime not null,	
	[FinishWorkTime] datetime not null,
	[Location] text
)

create table [Image]
(
	[Id] int identity(1 ,1) not null primary key,
	[Photo] image not null,
	[OwnerId] int,
	[CarId] int,
)

create table [Coments]
(
	[Id] int identity(1 ,1) not null primary key,
	[CreatorId] int not null,
	[RequestId] int not null,
	[CommentText] text	
)


alter table [Request]
	add constraint fk_Creator_Request foreign key(CreatorId) references [Users](Id)
	on delete cascade
	on update cascade

alter table [Coments]
	add constraint fk_Request_Coment foreign key(RequestId) references [Request](Id)

	
alter table [Coments]
	add constraint fk_User_Coment foreign key(CreatorId) references [Users](Id)

alter table [Image]
	add constraint fk_Cars_Image foreign key(CarId) references [Cars](Id)

	
alter table [Image]
	add constraint fk_User_Image foreign key(OwnerId) references [Users](Id)