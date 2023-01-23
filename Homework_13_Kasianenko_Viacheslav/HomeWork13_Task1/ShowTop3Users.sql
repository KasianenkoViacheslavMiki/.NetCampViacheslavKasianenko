DECLARE @FirstDate as Varchar(100)
SET @FirstDate = '2023-01-12 12:00:00'
DECLARE @SecondDate as varchar(100)
SET @SecondDate = '2023-01-15 12:00:00'

USE CinemaSigmaUA

SELECT  TOP(3)      Client.NameClient, SUM(Showtimes.PriceShowTime) * Count(Bookings.PhoneNumberClient) AS Total
FROM            Client INNER JOIN
                         Bookings ON Client.PhoneNumberClient = Bookings.PhoneNumberClient INNER JOIN
                         Showtimes ON Bookings.GuidShowtimes = Showtimes.GuidShowtimes
WHERE Showtimes.ShowTime BETWEEN CONVERT(DATETIME, @FirstDate, 102) AND CONVERT(DATETIME, @SecondDate, 102)
GROUP BY Client.NameClient
ORDER BY Total DESC