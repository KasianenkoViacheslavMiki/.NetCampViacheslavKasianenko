use CinemaSigmaUA
go

select CinemaHalls.Adress
from CinemaHalls
where 
(SELECT Count(Showtimes.GuidCinemaHall) as Count
FROM            Showtimes INNER JOIN
                         Bookings ON Showtimes.GuidShowtimes = Bookings.GuidShowtimes
where CinemaHalls.GuidCinemaHall=Showtimes.GuidCinemaHall and Showtimes.ShowTime BETWEEN DATEADD(day,-14, GETDATE()) AND DATEADD(day,-7, GETDATE())
Group by Showtimes.GuidCinemaHall)
<
(SELECT Count(Showtimes.GuidCinemaHall) as Count
FROM            Showtimes INNER JOIN
                         Bookings ON Showtimes.GuidShowtimes = Bookings.GuidShowtimes
where CinemaHalls.GuidCinemaHall=Showtimes.GuidCinemaHall and Showtimes.ShowTime BETWEEN DATEADD(day,-7, GETDATE()) AND DATEADD(day,0, GETDATE())
Group by Showtimes.GuidCinemaHall)