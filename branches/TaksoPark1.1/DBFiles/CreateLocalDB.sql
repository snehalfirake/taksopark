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
   @Price numeric(18,4),
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
    @Price numeric(18,4),
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
/*
  
   ELMAH - Error Logging Modules and Handlers for ASP.NET
   Copyright (c) 2004-9 Atif Aziz. All rights reserved.
  
    Author(s):
  
        Atif Aziz, http://www.raboof.com
        Phil Haacked, http://haacked.com
  
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
  
      http://www.apache.org/licenses/LICENSE-2.0
  
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
  
*/

-- ELMAH DDL script for Microsoft SQL Server 2000 or later.

-- $Id: SQLServer.sql 677 2009-09-29 18:02:39Z azizatif $

DECLARE @DBCompatibilityLevel INT
DECLARE @DBCompatibilityLevelMajor INT
DECLARE @DBCompatibilityLevelMinor INT

SELECT 
    @DBCompatibilityLevel = cmptlevel 
FROM 
    master.dbo.sysdatabases 
WHERE 
    name = DB_NAME()

IF @DBCompatibilityLevel <> 80
BEGIN

    SELECT @DBCompatibilityLevelMajor = @DBCompatibilityLevel / 10, 
           @DBCompatibilityLevelMinor = @DBCompatibilityLevel % 10
           
    PRINT N'
    ===========================================================================
    WARNING! 
    ---------------------------------------------------------------------------
    
    This script is designed for Microsoft SQL Server 2000 (8.0) but your 
    database is set up for compatibility with version ' 
    + CAST(@DBCompatibilityLevelMajor AS NVARCHAR(80)) 
    + N'.' 
    + CAST(@DBCompatibilityLevelMinor AS NVARCHAR(80)) 
    + N'. Although 
    the script should work with later versions of Microsoft SQL Server, 
    you can ensure compatibility by executing the following statement:
    
    ALTER DATABASE [' 
    + DB_NAME() 
    + N'] 
    SET COMPATIBILITY_LEVEL = 80

    If you are hosting ELMAH in the same database as your application 
    database and do not wish to change the compatibility option then you 
    should create a separate database to host ELMAH where you can set the 
    compatibility level more freely.
    
    If you continue with the current setup, please report any compatibility 
    issues you encounter over at:
    
    http://code.google.com/p/elmah/issues/list

    ===========================================================================
'
END
GO

/* ------------------------------------------------------------------------ 
        TABLES
   ------------------------------------------------------------------------ */

CREATE TABLE [dbo].[ELMAH_Error]
(
    [ErrorId]     UNIQUEIDENTIFIER NOT NULL,
    [Application] NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Host]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Type]        NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Source]      NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Message]     NVARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [User]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [StatusCode]  INT NOT NULL,
    [TimeUtc]     DATETIME NOT NULL,
    [Sequence]    INT IDENTITY (1, 1) NOT NULL,
    [AllXml]      NTEXT COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) 
ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ELMAH_Error] WITH NOCHECK ADD 
    CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED ([ErrorId]) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ELMAH_Error] ADD 
    CONSTRAINT [DF_ELMAH_Error_ErrorId] DEFAULT (NEWID()) FOR [ErrorId]
GO

CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error] 
(
    [Application]   ASC,
    [TimeUtc]       DESC,
    [Sequence]      DESC
) 
ON [PRIMARY]
GO

/* ------------------------------------------------------------------------ 
        STORED PROCEDURES                                                      
   ------------------------------------------------------------------------ */

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT 
        [AllXml]
    FROM 
        [ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT 
        @TotalCount = COUNT(1) 
    FROM 
        [ELMAH_Error]


    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM 
            [ELMAH_Error]
        ORDER BY 
            [TimeUtc] DESC, 
            [Sequence] DESC

    END
    ELSE
    BEGIN

        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT 
        errorId     = [ErrorId], 
        application = [Application],
        host        = [Host], 
        type        = [Type],
        source      = [Source],
        message     = [Message],
        [user]      = [User],
        statusCode  = [StatusCode], 
        time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM 
        [ELMAH_Error] error
    WHERE
        [TimeUtc] <= @FirstTimeUTC
    AND 
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC, 
        [Sequence] DESC
    FOR
        XML AUTO

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NTEXT,
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



