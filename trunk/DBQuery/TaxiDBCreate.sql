create table [Request]
(
	[Id] int identity(1 ,1) not null primary key,
	[RequetTime] datetime not null,
	[CreatorId] int,
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


--Insert scripts--
insert into Coments (CreatorId, RequestId, CommentText) values (5, 2, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (6, 3, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (1, 1, 'Greate trip. All was greate')

insert into Users (Name, LastName, Login, Password, Role, Status) values ('Vitalik', 'Komaniak', 'Vitalik_93', '341190', 'Driver', 'Active')
insert into Users (Name, LastName, Login, Password, Role, Status) values ('Roman', 'Gusak', 'Gusak_93', '341190asd', 'Driver', 'Active')
insert into Users (Name, LastName, Login, Password, Role, Status) values ('Volodya', 'Komaniak', 'Volodya_93', 'asd341190', 'Operator', 'Active')
insert into Users (Name, LastName, Login, Password, Role, Status) values ('Ihor', 'Shpak', 'Shpak_93', 'asd123341190', 'Operator', 'Active')
insert into Users (Name, LastName, Login, Password, Role, Status) values ('Ivan', 'SFedak', 'Ivan_93', 'asd12334', 'Client', 'Active')
insert into Users (Name, LastName, Login, Password, Role, Status) values ('Roman', 'Novak', 'Novar_93', 'asd12334', 'Client', 'Active')

INSERT INTO [Image] (Photo, OwnerId, CarId) 
SELECT  BulkColumn, null, 1
FROM Openrowset( Bulk 'E:\cars\car2.jpg', Single_Blob) as image

INSERT INTO [Image] (Photo, OwnerId, CarId) 
SELECT  BulkColumn, null, 2
FROM Openrowset( Bulk 'E:\cars\car1.jpg', Single_Blob) as image

INSERT INTO [Image] (Photo, OwnerId, CarId) 
SELECT  BulkColumn, null, 3
FROM Openrowset( Bulk 'E:\cars\car3.jpg', Single_Blob) as image

INSERT INTO [Image] (Photo, OwnerId, CarId) 
SELECT  BulkColumn, 1, null
FROM Openrowset( Bulk 'E:\cars\user1.jpg', Single_Blob) as image

insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Location) values ('Honda', 2012, convert(datetime,'18-10-14 06:00:00 PM',5), convert(datetime,'18-10-14 19:30:00 PM',5), 'Pasichna 60')
insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Location) values ('Skoda', 2010, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-12 10:34:09 PM',5), 'Lychakivska 25')
insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Location) values ('Toyota', 2011, convert(datetime,'12-10-14 10:00:00 PM',5), convert(datetime,'12-10-14 22:30:00 PM',5), 'Pidvalna 2')

insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId) values (convert(datetime,'18-10-14 15:00:00 PM',5), null, '0631709471', 'InProgress', 'Prospekt Shevchenka', 'Syhiv', 3)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId) values (convert(datetime,'18-10-14 15:00:00 PM',5), 5, '0631709471', 'InProgress', 'Shevchenka', 'Kaluna', 3)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId) values (convert(datetime,'1-10-14 20:00:00 PM',5), 5, '0634564561', 'InProgress', 'Ryasne', 'Pidvalna', 4)