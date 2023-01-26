using HomeWork16_Task1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_Task1
{
    static public class ActionDataBase
    {

        static NetworkCinemaHallsContext cinemaContext = new NetworkCinemaHallsContext();
        static public async Task CreateFilm(Films film)
        {
            await cinemaContext.Films.AddAsync(film);
        }
        static public async Task CreateUser(Client client)
        {
            await cinemaContext.Clients.AddAsync(client);
        }
        static public async Task<List<Showtimes>> ShowFutureShowTime()
        {
            return await cinemaContext.Showtimes.Where(x => x.ShowTime > DateTime.Now).ToListAsync();
        }
        static public async Task BuyTicket(Showtimes showtimes, PlacesCinemaHall placesCinemaHall,Client client)
        {
            Bookings bookings = new Bookings();
            bookings.PlacesCinemaHall = placesCinemaHall;
            bookings.GuidPlaceCinemaHall = placesCinemaHall.Id;
            bookings.GuidClient = client.Id;
            bookings.Client = client;
            bookings.GuidShowTimes = showtimes.Id;
            bookings.Showtimes = showtimes;

            await cinemaContext.Bookings.AddAsync(bookings);
        }
        static public async Task BuyTicket(Bookings bookings)
        {
            await cinemaContext.Bookings.AddAsync(bookings);
        }
        static public List<Showtimes> SelectAllTheShowtimes()
        {
            List<Showtimes> result = new List<Showtimes>();

            int dayWeek = (int)DateTime.Now.DayOfWeek != 0 ? (int)DateTime.Now.DayOfWeek : 7;

            DateTime startWeek = DateTime.Now.AddDays((int)(dayWeek - 1)*-1);
            DateTime endWeek = DateTime.Now.AddDays(7-(int)dayWeek);

            result = cinemaContext.Showtimes
                .Include(x => x.CinemaHall)
                .Include(x => x.Film)
                .Where(x => startWeek>x.ShowTime && endWeek>x.ShowTime).ToList();
            return result;
        }
        static public List<PlacesCinemaHall>? SelectAllAvailableSeats(string nameFilm,DateTime dateTime)
        {
            Showtimes? showtimes = cinemaContext.Showtimes.Include(x => x.Film)
                .FirstOrDefault(x => x.Film.FilmName == nameFilm && x.ShowTime == dateTime);

            if (showtimes == null)
            {
                return null;
            }

            List<PlacesCinemaHall> result = new List<PlacesCinemaHall>();

            result = cinemaContext.PlacesCinemaHalls
                .Include(x => x.Bookings)
                .Where(x=>!x.Bookings.Any(x=>x.GuidShowTimes==showtimes.Id) && x.GuidCinemaHall == showtimes.GuidCinemaHall)
                .ToList();

            return result;
        }
        static public List<PlacesCinemaHall> FindSeatsWhichNeverBooked()
        {
            List<PlacesCinemaHall> result = new List<PlacesCinemaHall>();

            result = cinemaContext.PlacesCinemaHalls
                .Include(x => x.Bookings)
                .Where(x=>x.Bookings.Count==0)
                .ToList();

            return result;
        }
        static public Dictionary<string, decimal> CalculateAllTheMoney()
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();

            result = cinemaContext.Showtimes.Include(x => x.Film)
                .Include(x => x.Bookings)
                .GroupBy(x => x.Film.FilmName)
                .Select(x => new
                {
                    x.Key,
                    sum = x.Sum(x => x.PriceShowTime),
                    count = x.Select(x => x.Bookings.Count()),

                })
                .Select(x => new
                {
                    x.Key,
                    sum = x.sum * x.count.Sum()
                }).ToDictionary(x=>x.Key,x=>x.sum);

            return result;
        }
        static public Dictionary<string, decimal> ShowTop3Users(DateTime firstDateTime, DateTime secondDateTime)
        {
            Dictionary<string,decimal> result = new Dictionary<string, decimal>();

            result = (from client in cinemaContext.Clients
                         from Booking in client.Bookings
                         where Booking.Showtimes.ShowTime > firstDateTime && Booking.Showtimes.ShowTime < secondDateTime
                         select client)
                         .GroupBy(x => x.Name)
                         .Select(x => new
                         {
                             x.Key,
                             CountBooking = x.Select(x => x.Bookings.Count),
                             Sum = x.Select(x => x.Bookings.Sum(x => x.Showtimes.PriceShowTime))
                         })
                         .Select(x => new
                         {
                             x.Key,
                             CountBooking = x.CountBooking.Sum(),
                             Sum = x.Sum.Sum()
                         })
                        .Select(x => new
                        {
                            x.Key,
                            Total = x.CountBooking * x.Sum
                        })
                        .ToDictionary(x=>x.Key,x=>x.Total);

            return result;
        }
        static public List<CinemaHalls> FindCinemaHallsWithLessVisitors()
        {
            List<CinemaHalls> result = new List<CinemaHalls>();


            var firstWeek = cinemaContext.CinemaHalls
                .Include(x => x.Showtimes)
                .ThenInclude(x => x.Bookings)
                .SelectMany(x => x.Showtimes.Where(x => x.ShowTime > DateTime.Now.AddDays(-7) && x.ShowTime < DateTime.Now.AddDays(0)), (x, y) => new { x, countBook = y.Bookings.Count() })
                .GroupBy(x => x.x)
                .Select(x => new
                {
                    x.Key,
                    V = x.Select(y => y.countBook)
                })
                .Select(x => new
                {
                    x.Key,
                    V = x.V.Sum()
                })
                .ToList();

            var secondWeek = cinemaContext.CinemaHalls
                .Include(x => x.Showtimes)
                .ThenInclude(x => x.Bookings)
                .SelectMany(x => x.Showtimes.Where(x => x.ShowTime > DateTime.Now.AddDays(-14) && x.ShowTime < DateTime.Now.AddDays(-7)), (x, y) => new { x, countBook = y.Bookings.Count() })
                .GroupBy(x => x.x)
                .Select(x => new
                {
                    x.Key,
                    V = x.Select(y=>y.countBook)
                })
                .Select(x => new
                {
                    x.Key,
                    V = x.V.Sum()
                })
                .ToList();

            var list = firstWeek.Where(x => x.V < (secondWeek.FirstOrDefault(y=>y.Key==x.Key)!=null? secondWeek.FirstOrDefault(y => y.Key == x.Key).V:0)).ToList();

            foreach (var item in list)
            {
                result.Add(item.Key);
            }

            return result;
        }
        static public List<(Client,Client)> FindCouplesUsers()
        {
            List<(Client, Client)> result = new List<(Client, Client)> ();

            var findAllClient = cinemaContext.Clients
                .Include(x => x.Bookings)
                .ThenInclude(x => x.Showtimes)
                .Select(x => new
                {
                    x,
                    Showtimes = string.Join(",", x.Bookings.Select(y => y.Showtimes.Id))
                })
                .ToList();

            var findAllCouples = (from Client1 in findAllClient
                        join Client2 in findAllClient
                        on Client1.Showtimes equals Client2.Showtimes
                        where Client1.x.Name.CompareTo(Client2.x.Name)>0
                        where Client1.Showtimes != ""
                        where Client2.Showtimes != ""
                        select new
                        {
                            Client1 = Client1.x,
                            Client2 = Client2.x,
                        }).ToList() ;

            foreach (var couples in findAllCouples)
            {
                result.Add((couples.Client1, couples.Client2));
            }

            return result;
        }
    }
}
