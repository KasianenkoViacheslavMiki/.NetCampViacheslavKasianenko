USE CinemaSigmaUA

DECLARE @NameFilm as Varchar(100)
SET @NameFilm = 'Шоу Трумана'
DECLARE @DateTimeShow as varchar(100)
SET @DateTimeShow = '2023-01-14 12:00:00'

SELECT        PlacesCinemaHall.NumberPlace, Films.NameFilm
FROM            PlacesCinemaHall INNER JOIN
                         CinemaHalls ON PlacesCinemaHall.GuidCinemaHall = CinemaHalls.GuidCinemaHall INNER JOIN
                         Showtimes ON CinemaHalls.GuidCinemaHall = Showtimes.GuidCinemaHall INNER JOIN
                         Films ON Showtimes.GuidFilm = Films.GuidFilm
WHERE Films.NameFilm = @NameFilm
AND Showtimes.ShowTime = CONVERT(DATETIME, @DateTimeShow, 102)
AND NOT EXISTS 
(SELECT        *
FROM   Bookings 
WHERE  PlacesCinemaHall.GuidPlacesCinemaHall = Bookings.GuidPlacesCinemaHall 
and Bookings.GuidShowtimes = 
							(SELECT GuidShowtimes 
							from Showtimes 
							where Showtimes.ShowTime = CONVERT(DATETIME, @DateTimeShow, 102) 
							and Showtimes.GuidFilm = (SELECT GuidFilm from Films where Films.NameFilm = @NameFilm)))
