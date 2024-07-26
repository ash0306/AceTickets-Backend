﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieBookingBackend.Contexts;

#nullable disable

namespace MovieBookingBackend.Migrations
{
    [DbContext(typeof(MovieBookingContext))]
    [Migration("20240726043857_UpdatedDeleteBehaviour")]
    partial class UpdatedDeleteBehaviour
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieBookingBackend.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShowtimeId")
                        .HasColumnType("int");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShowtimeId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatStatus")
                        .HasColumnType("int");

                    b.Property<int>("ShowetimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("ShowetimeId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Showtime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.Property<float>("TicketPrice")
                        .HasColumnType("real");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheatreId");

                    b.ToTable("Showtimes");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Theatre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Theatres");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Email = "andrew@gmail.com",
                            Name = "Andrew",
                            PasswordHash = new byte[] { 143, 122, 242, 120, 4, 95, 187, 200, 119, 47, 233, 31, 217, 151, 108, 255, 31, 23, 107, 228, 136, 154, 152, 31, 193, 79, 195, 132, 252, 152, 100, 182, 99, 179, 111, 101, 207, 1, 166, 105, 96, 6, 223, 91, 156, 75, 82, 14, 175, 235, 80, 133, 113, 83, 193, 177, 110, 181, 167, 109, 174, 249, 237, 2 },
                            PasswordHashKey = new byte[] { 56, 135, 25, 100, 104, 17, 163, 201, 27, 104, 252, 226, 250, 197, 205, 95, 96, 245, 118, 27, 233, 114, 110, 221, 40, 12, 121, 86, 139, 81, 75, 3, 231, 235, 68, 232, 155, 225, 21, 231, 169, 242, 149, 46, 229, 235, 92, 117, 57, 174, 247, 71, 194, 238, 184, 199, 84, 142, 218, 177, 184, 112, 190, 73, 210, 95, 16, 45, 110, 60, 224, 35, 30, 142, 235, 23, 65, 6, 119, 59, 12, 17, 117, 97, 176, 194, 53, 246, 255, 172, 87, 138, 200, 109, 186, 117, 217, 40, 138, 95, 176, 130, 156, 16, 114, 71, 40, 59, 234, 239, 192, 33, 80, 34, 182, 85, 36, 71, 18, 198, 245, 112, 197, 156, 46, 240, 170, 230 },
                            Phone = "9333555908",
                            Role = 0
                        });
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Booking", b =>
                {
                    b.HasOne("MovieBookingBackend.Models.Showtime", "Showtime")
                        .WithMany()
                        .HasForeignKey("ShowtimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieBookingBackend.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Showtime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Seat", b =>
                {
                    b.HasOne("MovieBookingBackend.Models.Booking", "Booking")
                        .WithMany("Seats")
                        .HasForeignKey("BookingId");

                    b.HasOne("MovieBookingBackend.Models.Showtime", "Showtime")
                        .WithMany("Seats")
                        .HasForeignKey("ShowetimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Showtime", b =>
                {
                    b.HasOne("MovieBookingBackend.Models.Movie", "Movie")
                        .WithMany("Showtimes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieBookingBackend.Models.Theatre", "Theatre")
                        .WithMany("Showtimes")
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Theatre");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Booking", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Movie", b =>
                {
                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Showtime", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.Theatre", b =>
                {
                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("MovieBookingBackend.Models.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
