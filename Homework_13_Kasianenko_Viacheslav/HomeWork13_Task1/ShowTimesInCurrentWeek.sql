use CinemaSigmaUA
SELECT        Showtimes.ShowTime, Films.NameFilm, Films.YearFilm, CinemaHalls.Adress
FROM            Showtimes INNER JOIN
                         CinemaHalls ON Showtimes.GuidCinemaHall = CinemaHalls.GuidCinemaHall INNER JOIN
                         Films ON Showtimes.GuidFilm = Films.GuidFilm
where ShowTime >= dateadd(day, 1-datepart(dw, getdate()), CONVERT(date,getdate())) AND ShowTime <  dateadd(day, 8-datepart(dw, getdate()), CONVERT(date,getdate()))