CREATE DATABASE [TaxiServiseDB]
GO
USE [TaxiServiseDB]
GO
create table [Request]
(
	[Id] int identity(1 ,1) not null primary key,
	[RequetTime] datetime,
	[CreatorId] int,
	[PhoneNumber] varchar(15),
	[Status] int not null,
	[StartPoint] nvarchar(512),
	[FinishPoint] nvarchar(512),
	[OperatorId] int,
	[DriverId] int,
	[Price] numeric(18,4) not null,
	[Additional] nvarchar(2048)
)

create table [Users]
(
	[Id] int identity(1 ,1) not null primary key,
	[Name] nvarchar(512) not null,
	[LastName] nvarchar(512) not null,
	[Login] nvarchar(512),
	[PhoneNumber] varchar(15),
	[Email] nvarchar(70),
	[Password] nvarchar(60),
	[Role] int,
	[Status] int,
	[DriverStatus] int
)

create table [Cars]
(
	[Id] int identity(1 ,1) not null primary key references [Users](Id),
	[Brand] nvarchar(512),
	[Year] varchar(4),
	[StartWorkTime] datetime not null,	
	[FinishWorkTime] datetime not null,
	[Latitude] varchar(max),
	[Longitude] varchar(max)
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
	[CommentText] nvarchar(2048)	
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