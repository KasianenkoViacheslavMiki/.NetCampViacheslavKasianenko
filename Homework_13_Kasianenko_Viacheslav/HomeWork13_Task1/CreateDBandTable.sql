CREATE DATABASE CinemaSigmaUA;
GO
USE CinemaSigmaUA;
GO
CREATE TABLE Films
(
 	GuidFilm UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	NameFilm varchar(100),
	YearFilm Date
);
CREATE TABLE CinemaHalls
(
 	GuidCinemaHall UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	Adress varchar(100)
);
Create table PlacesCinemaHall
(
 	GuidPlacesCinemaHall UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	GuidCinemaHall UNIQUEIDENTIFIER FOREIGN KEY REFERENCES CinemaHalls(GuidCinemaHall),
	NumberPlace int
)
Create table Client
(
	PhoneNumberClient varchar(10) PRIMARY KEY,
	NameClient varchar(100) 
);
CREATE TABLE Showtimes
(
 	GuidShowtimes UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	ShowTime DateTime,
	GuidFilm UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Films(GuidFilm),
	GuidCinemaHall UNIQUEIDENTIFIER FOREIGN KEY REFERENCES CinemaHalls(GuidCinemaHall),
	PriceShowTime decimal,
);
Create table Bookings
(
	GuidBooking UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	PhoneNumberClient varchar(10) FOREIGN KEY REFERENCES Client(PhoneNumberClient),
	GuidShowtimes UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Showtimes(GuidShowtimes),
	GuidPlacesCinemaHall UNIQUEIDENTIFIER FOREIGN KEY REFERENCES PlacesCinemaHall(GuidPlacesCinemaHall),
);

INSERT INTO [dbo].[Client]
           ([PhoneNumberClient]
           ,[NameClient])
     VALUES
           ('061677883'
           ,'��������'),
		   ('062677883'
           ,'����'),
		   ('061671113'
           ,'̳��'),
		   ('061437883'
           ,'����')
GO

INSERT INTO [dbo].[Films]
           ([GuidFilm]
           ,[NameFilm]
           ,[YearFilm])
     VALUES
           (default
           ,'��� �������'
           ,'1998-6-5'),
		   (default
           ,'������ ����'
           ,'1994-7-4'),
		   (default
           ,'����� ����: ��������� �������'
           ,'1999-4-19')
GO

INSERT INTO [dbo].[CinemaHalls]
           ([GuidCinemaHall]
           ,[Adress])
     VALUES
           (default
           ,'�. ���, �������� ����� 36'),
		   (default
           ,'�. ���, ������ ������� ���� 30')
GO


INSERT INTO [dbo].[PlacesCinemaHall]
           ([GuidPlacesCinemaHall]
           ,[GuidCinemaHall]
           ,[NumberPlace])
     VALUES
           (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,1),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,2),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,3),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,4),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,5),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,6),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,7),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,8),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,9),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,10),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, �������� ����� 36')
           ,11),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, ������ ������� ���� 30')
           ,1),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, ������ ������� ���� 30')
           ,2),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, ������ ������� ���� 30')
           ,3),
		   (default
           ,(SELECT GuidCinemaHall FROM CinemaHalls WHERE Adress = '�. ���, ������ ������� ���� 30')
           ,4)
GO	

INSERT INTO [dbo].[Showtimes]
           ([GuidShowtimes]
           ,[ShowTime]
           ,[GuidFilm]
           ,[GuidCinemaHall]
           ,[PriceShowTime])
     VALUES
           (default
           ,'20230114 12:00:00.000'
           ,(SELECT [GuidFilm] from Films where NameFilm ='��� �������')
           ,(SELECT [GuidCinemaHall] from CinemaHalls where Adress ='�. ���, �������� ����� 36')
           ,150),
		   (default
           ,'20230115 14:00:00.000'
           ,(SELECT [GuidFilm] from Films where NameFilm ='����� ����: ��������� �������')
           ,(SELECT [GuidCinemaHall] from CinemaHalls where Adress ='�. ���, �������� ����� 36')
           ,120),
		   (default
           ,'20230120 12:00:00.000'
           ,(SELECT [GuidFilm] from Films where NameFilm ='������ ����')
           ,(SELECT [GuidCinemaHall] from CinemaHalls where Adress ='�. ���, ������ ������� ���� 30')
           ,100)
GO

INSERT INTO [dbo].[Bookings]
           ([GuidBooking]
           ,[PhoneNumberClient]
           ,[GuidShowtimes]
           ,[GuidPlacesCinemaHall])
     VALUES
           (default
           ,'061677883'
           ,(SELECT GuidShowtimes FROM Showtimes WHERE ShowTime = '20230114 12:00:00' AND GuidCinemaHall = (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, �������� ����� 36'))
           ,(SELECT [GuidPlacesCinemaHall] from [PlacesCinemaHall] where NumberPlace=5 and GuidCinemaHall= (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, �������� ����� 36'))),
		   (default
           ,'062677883'
           ,(SELECT GuidShowtimes FROM Showtimes WHERE ShowTime = '20230115 14:00:00' AND GuidCinemaHall = (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, �������� ����� 36'))
           ,(SELECT [GuidPlacesCinemaHall] from [PlacesCinemaHall] where NumberPlace=4 and GuidCinemaHall= (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, �������� ����� 36'))),
		   (default
           ,'061671113'
           ,(SELECT GuidShowtimes FROM Showtimes WHERE ShowTime = '20230120 12:00:00' AND GuidCinemaHall = (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, ������ ������� ���� 30'))
           ,(SELECT [GuidPlacesCinemaHall] from [PlacesCinemaHall] where NumberPlace=3 and GuidCinemaHall= (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, ������ ������� ���� 30'))),
		   (default
           ,'061437883'
           ,(SELECT GuidShowtimes FROM Showtimes WHERE ShowTime = '20230115 14:00:00' AND GuidCinemaHall = (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, �������� ����� 36'))
           ,(SELECT [GuidPlacesCinemaHall] from [PlacesCinemaHall] where NumberPlace=2 and GuidCinemaHall= (SELECT GuidCinemaHall from CinemaHalls where Adress = '�. ���, �������� ����� 36')))
GO