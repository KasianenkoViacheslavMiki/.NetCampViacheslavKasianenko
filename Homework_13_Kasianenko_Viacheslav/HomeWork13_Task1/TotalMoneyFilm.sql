use CinemaSigmaUA
go

SELECT Films.NameFilm, SUM(Showtimes.PriceShowTime) * COUNT(Bookings.GuidBooking) AS Total
FROM Films INNER JOIN
           Showtimes ON Films.GuidFilm = Showtimes.GuidFilm INNER JOIN
           Bookings ON Showtimes.GuidShowtimes = Bookings.GuidShowtimes
GROUP BY NameFilm
ORDER BY NameFilm DESC;