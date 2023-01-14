SELECT        PlacesCinemaHall.NumberPlace, CinemaHalls.Adress
FROM            PlacesCinemaHall INNER JOIN
                         CinemaHalls ON PlacesCinemaHall.GuidCinemaHall = CinemaHalls.GuidCinemaHall
WHERE        (NOT EXISTS
                             (SELECT        GuidBooking, PhoneNumberClient, GuidShowtimes, GuidPlacesCinemaHall
                               FROM            Bookings
                               WHERE        (PlacesCinemaHall.GuidPlacesCinemaHall = GuidPlacesCinemaHall)))