USE [TaxiServiseDB]
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Vitalik', 'Komaniak', 'Vitalik_93', '380969535748', 'vit@gmail.com.ua', '341190', 2, 2, 2)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Roman', 'Gusak', 'Gusak_93', '380969534548', 'rom@gmail.com.ua', '341190asd', 2, 2, 2)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Volodya', 'Komaniak', 'Volodya_93', '380967895748', 'vol@gmail.com.ua', 'asd341190', 4, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Operator', 'OperatorLN', 'Operator1', '380969535345', 'igor@gmail.com.ua', 'asd123', 4, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Ivan', 'SFedak', 'Ivan_93', '380969534566', 'iva@gmail.com.ua', 'asd12334', 8, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Client', 'ClientLN', 'Client1', '380969556789', 'romnov@gmail.com.ua', '654321', 8, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Admin', 'AdminLN', 'Admin', '380969556789', 'orest@gmail.com.ua', '123456', 32, 2, null)

insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Honda', 2012, convert(datetime,'18-10-14 06:00:00 PM',5), convert(datetime,'18-10-14 19:30:00 PM',5), '-54.0000000', '54.23423423423')
insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Skoda', 2010, convert(datetime,'18-06-12 10:34:09 PM',5), convert(datetime,'18-06-12 10:34:09 PM',5), '-26.003245252', '14.1343434')
insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Toyota', 2011, convert(datetime,'12-10-14 10:00:00 PM',5), convert(datetime,'12-10-14 22:30:00 PM',5), '-37.0000000', '54.23424323423')

insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId, DriverId, Price, Additional) values (convert(datetime,'18-10-14 15:00:00 PM',5), null, '0631709471', 2, 'Prospekt Shevchenka', 'Syhiv', null, null, 43, null)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId, DriverId, Price, Additional) values (convert(datetime,'18-10-14 15:00:00 PM',5), 5, '0631709471', 4, 'Shevchenka', 'Kaluna', 3, 1, 56, null)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId, DriverId, Price, Additional) values (convert(datetime,'1-10-14 20:00:00 PM',5), 5, '0634564561', 8, 'Ryasne', 'Pidvalna', 4, 2, 88, null)


--Insert scripts--
insert into Coments (CreatorId, RequestId, CommentText) values (5, 2, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (6, 3, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (1, 1, 'Greate trip. All was greate')
