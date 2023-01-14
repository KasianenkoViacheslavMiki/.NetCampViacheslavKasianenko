Use CinemaSigmaUA
go
SELECT T1.NameClient AS Êë³ºíò1, T2.NameClient AS Êë³ºíò2
FROM (
    SELECT Client.NameClient, STRING_AGG(CONVERT(varchar(100),Showtimes.GuidShowtimes),',') AS Showtimes
    FROM Client INNER JOIN Bookings on Client.PhoneNumberClient = Bookings.PhoneNumberClient INNER JOIN Showtimes on Showtimes.GuidShowtimes = Bookings.GuidShowtimes 
    GROUP BY NameClient) AS T1
JOIN (
    SELECT Client.NameClient, STRING_AGG(CONVERT(varchar(100),Showtimes.GuidShowtimes),',') AS Showtimes
    FROM Client INNER JOIN Bookings on Client.PhoneNumberClient = Bookings.PhoneNumberClient INNER JOIN Showtimes on Showtimes.GuidShowtimes = Bookings.GuidShowtimes 
    GROUP BY NameClient) AS T2
ON T1.Showtimes = T2.Showtimes
WHERE T1.NameClient > T2.NameClient