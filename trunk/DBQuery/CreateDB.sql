create table [Request]
(
	[Id] int identity(1 ,1) not null primary key,
	[RequetTime] datetime,
	[CreatorId] int,
	[PhoneNumber] varchar(15),
	[Status] varchar(15),
	[StartPoint] nvarchar(512),
	[FinishPoint] nvarchar(512),
	[OperatorId] int,
	[DriverId] int,
	[Price] int,
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
	[Role] varchar(15),
	[Status] varchar(15)
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


insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status) values ('Vitalik', 'Komaniak', 'Vitalik_93', '380969535748', 'vit@gmail.com.ua', '341190', 'Driver', 'Active')
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status) values ('Roman', 'Gusak', 'Gusak_93', '380969534548', 'rom@gmail.com.ua', '341190asd', 'Driver', 'Active')
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status) values ('Volodya', 'Komaniak', 'Volodya_93', '380967895748', 'vol@gmail.com.ua', 'asd341190', 'Operator', 'Active')
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status) values ('Ihor', 'Shpak', 'Shpak_93', '380969535345', 'igor@gmail.com.ua', 'asd123341190', 'Operator', 'Active')
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status) values ('Ivan', 'SFedak', 'Ivan_93', '380969534566', 'iva@gmail.com.ua', 'asd12334', 'Client', 'Active')
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status) values ('Roman', 'Novak', 'Novar_93', '380969556789', 'romnov@gmail.com.ua', 'asd12334', 'Client', 'Active')

insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Honda', 2012, convert(datetime,'18-10-14 06:00:00 PM',5), convert(datetime,'18-10-14 19:30:00 PM',5), '-54.0000000', '54.23423423423')
insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Skoda', 2010, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-12 10:34:09 PM',5), '-26.003245252', '14.1343434')
insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Toyota', 2011, convert(datetime,'12-10-14 10:00:00 PM',5), convert(datetime,'12-10-14 22:30:00 PM',5), '-37.0000000', '54.23424323423')

insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId) values (convert(datetime,'18-10-14 15:00:00 PM',5), null, '0631709471', 'InProgress', 'Prospekt Shevchenka', 'Syhiv', 3)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId) values (convert(datetime,'18-10-14 15:00:00 PM',5), 5, '0631709471', 'InProgress', 'Shevchenka', 'Kaluna', 3)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId) values (convert(datetime,'1-10-14 20:00:00 PM',5), 5, '0634564561', 'InProgress', 'Ryasne', 'Pidvalna', 4)


--Insert scripts--
insert into Coments (CreatorId, RequestId, CommentText) values (5, 2, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (6, 3, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (1, 1, 'Greate trip. All was greate')
