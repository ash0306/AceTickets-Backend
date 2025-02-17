﻿using Microsoft.EntityFrameworkCore;
using MovieBookingBackend.Models;
using MovieBookingBackend.Models.Enums;
using System.Security.Cryptography;
using System.Text;

namespace MovieBookingBackend.Contexts
{
    public class MovieBookingContext : DbContext
    {
        public MovieBookingContext(DbContextOptions<MovieBookingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<EmailVerification> EmailVerifications { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hmac = new HMACSHA512();

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 101,
                    Name = "Andrew",
                    Email = "andrew@gmail.com",
                    Phone = "9988674562",
                    PasswordHashKey = hmac.Key,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("andrew123")),
                    Role = UserRole.Admin,
                    Status = UserStatus.Active,
                }
                );

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.QRCode)
                .WithOne(qr => qr.Booking)
                .HasForeignKey<QRCode>(qr => qr.BookingId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Showtimes)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Theatre>()
                .HasMany(t => t.Showtimes)
                .WithOne(s => s.Theatre)
                .HasForeignKey(s => s.TheatreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Showtime>()
                .HasMany(sh => sh.Seats)
                .WithOne(s => s.Showtime)
                .HasForeignKey(s => s.ShowetimeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Seats)
                .WithOne(s => s.Booking)
                .HasForeignKey(s => s.BookingId);
        }
    }
}
