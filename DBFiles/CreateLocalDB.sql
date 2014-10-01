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
	[Price] int not null,
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

USE [TaxiServiseDB]
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Vitalik', 'Komaniak', 'Vitalik_93', '380969535748', 'vit@gmail.com.ua', '341190', 2, 2, 2)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Roman', 'Gusak', 'Gusak_93', '380969534548', 'rom@gmail.com.ua', '341190asd', 2, 2, 2)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Volodya', 'Komaniak', 'Volodya_93', '380967895748', 'vol@gmail.com.ua', 'asd341190', 4, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Operator', 'OperatorLN', 'Operator1', '380969535345', 'igor@gmail.com.ua', 'asd123', 4, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Ivan', 'SFedak', 'Ivan_93', '380969534566', 'iva@gmail.com.ua', 'asd12334', 8, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Client', 'ClientLN', 'Client1', '380969556789', 'romnov@gmail.com.ua', '654321', 8, 2, null)
insert into Users (Name, LastName, Login, PhoneNumber, Email, Password, Role, Status, DriverStatus) values ('Admin', 'AdminLN', 'Admin', '380969556789', 'orest@gmail.com.ua', '123456', 32, 2, null)

insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Honda', 2012, convert(datetime,'18-10-14 06:00:00 PM',5), convert(datetime,'18-10-14 19:30:00 PM',5), '-54.0000000', '54.23423423423')
insert into Cars (Brand, Year, StartWorkTime, FinishWorkTime, Latitude, Longitude) values ('Skoda', 2010, convert(datetime,'18-06-12 10:34:00 PM',5), convert(datetime,'18-06-12 18:34:00 PM',5), '-26.003245252', '14.1343434')


insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId, DriverId, Price, Additional) values (convert(datetime,'18-10-14 15:00:00 PM',5), null, '0631709471', 2, 'Prospekt Shevchenka', 'Syhiv', null, null, 43, null)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId, DriverId, Price, Additional) values (convert(datetime,'18-10-14 15:00:00 PM',5), 5, '0631709471', 4, 'Shevchenka', 'Kaluna', 3, 1, 56, null)
insert into [Request] (RequetTime, CreatorId, PhoneNumber, Status, StartPoint, FinishPoint, OperatorId, DriverId, Price, Additional) values (convert(datetime,'1-10-14 20:00:00 PM',5), 5, '0634564561', 8, 'Ryasne', 'Pidvalna', 4, 2, 88, null)


--Insert scripts--
insert into Coments (CreatorId, RequestId, CommentText) values (5, 2, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (6, 3, 'Greate trip. All was greate')
insert into Coments (CreatorId, RequestId, CommentText) values (1, 1, 'Greate trip. All was greate')

USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_UpdateCar') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_UpdateCar
GO

CREATE PROCEDURE sp_UpdateCar
   @Brand varchar(30),
   @Year varchar(4),
   @StartWorkTime DateTime,
   @FinishWorkTime DateTime,
   @Latitude varchar(100),
   @Longitude varchar(100),
   @CarId int
AS
BEGIN
    SET NOCOUNT ON 
    UPDATE [Cars] SET 
	[Brand] = @Brand,
        [Year] = @Year,
        [StartWorkTime] = @StartWorkTime,
        [FinishWorkTime] = @FinishWorkTime,
        [Latitude] = @Latitude,
        [Longitude] = @Longitude
        WHERE [Id] = @CarId;   
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_CreateCar') IS NOT NULL ) 
   DROP PROCEDURE sp_CreateCar
GO

CREATE PROCEDURE sp_CreateCar
   @Brand varchar(30),
   @Year varchar(4),
   @StartWorkTime DateTime,
   @FinishWorkTime DateTime,
   @Latitude varchar(100),
   @Longitude varchar(100),
   @CarId int
AS
BEGIN
   SET NOCOUNT ON 
   SET IDENTITY_INSERT [dbo].[Cars] ON
   INSERT INTO Cars ([Id], [Brand], [Year], [StartWorkTime], [FinishWorkTime], [Latitude], [Longitude])
					VALUES(@CarId, @Brand, @Year, @StartWorkTime, @FinishWorkTime, @Latitude, @Longitude);
   SET IDENTITY_INSERT [dbo].[Cars] OFF
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllCars') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllCars
GO

CREATE PROCEDURE sp_GetAllCars
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id], 
		[Brand], 
		[Year], 
		[StartWorkTime], 
		[FinishWorkTime], 
		[Latitude], 
		[Longitude]
		FROM dbo.Cars
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetCarById') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetCarById
GO

CREATE PROCEDURE sp_GetCarById
	@CarID int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id], 
		[Brand], 
		[Year], 
		[StartWorkTime], 
		[FinishWorkTime], 
		[Latitude], 
		[Longitude]
	FROM dbo.Cars
	WHERE
		[Id] = 	@CarID
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_UpdateComment') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_UpdateComment
GO

CREATE PROCEDURE sp_UpdateComment
	@CreatorId int,
    @RequestId int,
    @CommentText varchar(max),
    @CommentId int
AS
BEGIN
    SET NOCOUNT ON 
    UPDATE [Coments] SET 
		   [CreatorId] = @CreatorId,
           [RequestId] = @RequestId, 
           [CommentText] = @CommentText
    WHERE 
	[Id] = @CommentId;  
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_CreateComment') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_CreateComment
GO

CREATE PROCEDURE sp_CreateComment
	@CreatorId int,
    @RequestId int,
    @CommentText varchar(max)
AS
BEGIN
    SET NOCOUNT ON 
	INSERT INTO [Coments]([CreatorId], [RequestId], [CommentText]) VALUES(@CreatorId, @RequestId, @CommentText);
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllCommentsByCreatorId') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllCommentsByCreatorId
GO

CREATE PROCEDURE sp_GetAllCommentsByCreatorId
	@CreatorId int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[ID],
		[CreatorId],
		[RequestId],
		[CommentText]
	FROM dbo.Coments
	WHERE
		[Id] = 	@CreatorId
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllCommentsByRequestId') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllCommentsByRequestId
GO

CREATE PROCEDURE sp_GetAllCommentsByRequestId
	@RequestId int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[ID],
		[CreatorId],
		[RequestId],
		[CommentText]
	FROM dbo.Coments
	WHERE
		[RequestId] = 	@RequestId
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllDrivers') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllDrivers
GO

CREATE PROCEDURE sp_GetAllDrivers
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Users].Id, 
		[Users].Name, 
		[Users].LastName, 
		[Users].Login, 
		[Users].PhoneNumber, 
		[Users].Email, 
		[Users].Password, 
		[Users].Role, 
		[Users].Status, 
		[Users].DriverStatus,
		[Cars].Brand, 
		[Cars].Year, 
		[Cars].StartWorkTime, 
		[Cars].FinishWorkTime, 
		[Cars].Latitude, 
		[Cars].Longitude
	FROM [Users] INNER JOIN [Cars] 
	ON [Users].Id = [Cars].Id AND [Users].Role = 2;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllDriversByStatus') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllDriversByStatus
GO

CREATE PROCEDURE sp_GetAllDriversByStatus
	@Status int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT [Users].Id, 
		   [Users].Name, 
		   [Users].LastName, 
		   [Users].Login, 
		   [Users].PhoneNumber, 
		   [Users].Email, 
		   [Users].Password, 
		   [Users].Role, 
		   [Users].Status,
		   [Users].DriverStatus, 
		   [Cars].Brand, 
		   [Cars].Year, 
		   [Cars].StartWorkTime, 
		   [Cars].FinishWorkTime, 
		   [Cars].Latitude, 
		   [Cars].Longitude
	FROM [Users] INNER JOIN [Cars] 
	ON [Users].Id = [Cars].Id AND [Users].Role = 2 AND [Users].Status = @Status;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_UpdateUser') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_UpdateUser
GO

CREATE PROCEDURE sp_UpdateUser
	@UserName varchar(100), 
    @LastName varchar(100), 
    @Login varchar(100), 
    @PhoneNumber varchar(15), 
    @Email varchar(100), 
    @Password varchar(100), 
    @Role int, 
    @Status int,
	@DriverStatus int,
    @UserId int
AS
BEGIN
    SET NOCOUNT ON 
    UPDATE [Users] SET 
				[Name] = @userName, 
                [LastName] = @LastName,
                [Login] = @Login,
                [PhoneNumber] = @PhoneNumber,
                [Email] = @Email,
                [Password] = @Password,
                [Role] = @Role,
                [Status] = @Status,
				[DriverStatus] = @DriverStatus
    WHERE 
		Id = @UserId;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_CreateUser') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_CreateUser
GO

CREATE PROCEDURE sp_CreateUser
	@UserName varchar(100), 
    @LastName varchar(100), 
    @Login varchar(100), 
    @PhoneNumber varchar(15), 
    @Email varchar(100), 
    @Password varchar(100), 
    @Role int, 
    @Status int,
	@DriverStatus int
AS
BEGIN
    SET NOCOUNT ON 
 INSERT INTO [Users] ([Name], [LastName], [Login], [PhoneNumber], [Email], [Password], [Role], [Status], [DriverStatus]) 
		VALUES(@UserName, @LastName, @Login, @PhoneNumber, @Email, @Password, @Role, @Status, @DriverStatus);
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetUsersByRole') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetUsersByRole
GO

CREATE PROCEDURE sp_GetUsersByRole
    @Role int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Role] = @Role;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetUserById') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetUserById
GO

CREATE PROCEDURE sp_GetUserById
    @Id int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Id] = @Id;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetUserByLogInAndPassword') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetUserByLogInAndPassword
GO

CREATE PROCEDURE sp_GetUserByLogInAndPassword
	@Login varchar(100),
    @Password varchar(100)
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Login] = @Login AND 
		[Password] = @Password;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetUserByLogIn') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetUserByLogIn
GO

CREATE PROCEDURE sp_GetUserByLogIn
	@Login varchar(100)
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Login] = @Login;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllOperatorsByStatus') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllOperatorsByStatus
GO

CREATE PROCEDURE sp_GetAllOperatorsByStatus
	@Status int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Status] = @Status 
	AND [Role] = 4;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllUsersByStatus') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllUsersByStatus
GO

CREATE PROCEDURE sp_GetAllUsersByStatus
	@Status int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Status] = @Status AND [Role] = 8;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_IsLoginBookedByOtherId') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_IsLoginBookedByOtherId
GO

CREATE PROCEDURE sp_IsLoginBookedByOtherId
	@Login varchar(100),
	@ID int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Login] = @Login
	AND [Id] <> @ID;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_IsLoginBooked') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_IsLoginBooked
GO

CREATE PROCEDURE sp_IsLoginBooked
	@Login varchar(100)
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[Name], 
		[LastName], 
		[Login], 
		[PhoneNumber], 
		[Email], 
		[Password], 
		[Role], 
		[Status], 
		[DriverStatus] 
	FROM [Users] 
	WHERE 
		[Login] = @Login;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_CreateRequest') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_CreateRequest
GO

CREATE PROCEDURE sp_CreateRequest
   @RequestTime DateTime,
   @CreatorId int,
   @PhoneNumber varchar(15),
   @Status varchar(15),
   @StartPoint nvarchar(512),
   @FinishPoint nvarchar(512),
   @OperatorId int,
   @DriverId int,
   @Price int,
   @Additional nvarchar(2048),
   @RequestId int = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON 
	INSERT INTO [Request] ([RequetTime], [CreatorId], [PhoneNumber], [Status], [StartPoint], [FinishPoint], [OperatorId], [DriverId], [Price], [Additional]) 
		VALUES(@RequestTime, @CreatorId, @PhoneNumber, @Status, @StartPoint, @FinishPoint, @OperatorId, @DriverId, @Price, @Additional);
		SET @RequestId = SCOPE_IDENTITY(); 
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllRequests') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllRequests
GO

CREATE PROCEDURE sp_GetAllRequests
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[RequetTime], 
		[CreatorId], 
		[PhoneNumber], 
		[Status], 
		[StartPoint], 
		[FinishPoint], 
		[OperatorId], 
		[DriverId], 
		[Price], 
		[Additional]
	FROM [Request];
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetRequestById') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetRequestById
GO

CREATE PROCEDURE sp_GetRequestById
	@RequestId int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[RequetTime], 
		[CreatorId], 
		[PhoneNumber], 
		[Status], 
		[StartPoint], 
		[FinishPoint], 
		[OperatorId], 
		[DriverId], 
		[Price], 
		[Additional]
	FROM [Request]
	WHERE [Id] = @RequestId;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllRequestsByCreatorId') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllRequestsByCreatorId
GO

CREATE PROCEDURE sp_GetAllRequestsByCreatorId
	@CreatorId int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[RequetTime], 
		[CreatorId], 
		[PhoneNumber], 
		[Status], 
		[StartPoint], 
		[FinishPoint], 
		[OperatorId], 
		[DriverId], 
		[Price], 
		[Additional]
	FROM [Request]
	WHERE [CreatorId] = @CreatorId;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_GetAllRequestsByState') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_GetAllRequestsByState
GO

CREATE PROCEDURE sp_GetAllRequestsByState
	@State int
AS
BEGIN
    SET NOCOUNT ON 
	SELECT 
		[Id],
		[RequetTime], 
		[CreatorId], 
		[PhoneNumber], 
		[Status], 
		[StartPoint], 
		[FinishPoint], 
		[OperatorId], 
		[DriverId], 
		[Price], 
		[Additional]
	FROM [Request]
	WHERE [Status] = @State;
END
GO
-----------------------------------------------------------------------------------------------
USE [TaxiServiseDB]
GO
IF ( OBJECT_ID('sp_UpdateRequest') IS NOT NULL ) 
   DROP PROCEDURE dbo.sp_UpdateRequest
GO

CREATE PROCEDURE sp_UpdateRequest
	@RequestTime DateTime,
    @PhoneNumber varchar(15),
    @Status int,
    @StartPoint nvarchar(512),
    @FinishPoint nvarchar(512),
    @RequestId int,
    @DriverId int,
    @Price int,
    @OperatorId int,
    @Additional nvarchar(2048)
AS
BEGIN
	DECLARE @OldStatus INT;
    SET NOCOUNT ON 
	Select @OldStatus = [Request].[Status] FROM [Request] WHERE [Id] = @RequestId;
	IF ((@OldStatus = 2 AND @Status = 8) OR (@OldStatus = 4 AND @Status = 2) 
	OR (@OldStatus = 32 AND @Status = 2) OR (@OldStatus = 32 AND @Status = 4) 
	OR (@OldStatus = 32 AND @Status = 8) OR (@OldStatus = 8 AND @Status = 2)
	OR (@OldStatus = 8 AND @Status = 4) OR (@OldStatus = 8 AND @Status = 32))
		BEGIN
			RAISERROR (15600,-1,-1, 'Wrong Request Update');
		END
	ELSE
	BEGIN
		UPDATE Request SET 
			RequetTime = @RequestTime,
			PhoneNumber = @PhoneNumber,
			Status = @Status,
			StartPoint = @StartPoint,
			FinishPoint = @FinishPoint,
			DriverId = @DriverId,
			Price = @Price,
			Additional = @Additional,
			OperatorId = @OperatorId
		WHERE Id = @RequestId;
	END

END
GO
-----------------------------------------------------------------------------------------------
