using HomeWork16_Task1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_Task1
{
    public class NetworkCinemaHallsContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Server=HOME-PC\SQLEXPRESS01;Database=SigmaCinema1;TrustServerCertificate=True; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany<Bookings>(x => x.Bookings)
                .WithOne(g => g.Client)
                .HasForeignKey(s => s.GuidClient);
            modelBuilder.Entity<Client>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Films>()
                .HasMany<Showtimes>(x => x.Showtimes)
                .WithOne(g => g.Film)
                .HasForeignKey(s => s.GuidFilm);
            modelBuilder.Entity<Films>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");



            modelBuilder.Entity<CinemaHalls>()
                .HasMany<PlacesCinemaHall>(x => x.PlacesCinemaHall)
                .WithOne(g => g.CinemaHalls)
                .HasForeignKey(s => s.GuidCinemaHall);
            modelBuilder.Entity<CinemaHalls>()
                .HasMany<Showtimes>(x => x.Showtimes)
                .WithOne(g => g.CinemaHall)
                .HasForeignKey(s => s.GuidCinemaHall);
            modelBuilder.Entity<CinemaHalls>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Showtimes>()
                .HasMany<Bookings>(x => x.Bookings)
                .WithOne(g => g.Showtimes)
                .HasForeignKey(s => s.GuidShowTimes);
            modelBuilder.Entity<Showtimes>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Bookings>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<PlacesCinemaHall>()
                .HasMany<Bookings>(x => x.Bookings)
                .WithOne(g => g.PlacesCinemaHall)
                .HasForeignKey(s => s.GuidPlaceCinemaHall);
            modelBuilder.Entity<PlacesCinemaHall>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Cinemas>()
                .HasMany<CinemaHalls>(x => x.CinemaHalls)
                .WithOne(g => g.Cinema)
                .HasForeignKey(s => s.GuidCinema);
            modelBuilder.Entity<Cinemas>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
        }

        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Films> Films { get; set; }
        public DbSet<CinemaHalls> CinemaHalls { get; set; }
        public DbSet<PlacesCinemaHall> PlacesCinemaHalls { get; set; }
        public DbSet<Showtimes> Showtimes { get; set; }
    }
}
