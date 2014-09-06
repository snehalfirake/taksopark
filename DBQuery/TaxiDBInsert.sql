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