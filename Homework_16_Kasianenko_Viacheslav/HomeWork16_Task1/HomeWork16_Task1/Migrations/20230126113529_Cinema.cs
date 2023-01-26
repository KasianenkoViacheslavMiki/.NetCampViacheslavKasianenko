using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork16Task1.Migrations
{
    /// <inheritdoc />
    public partial class Cinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FilmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmYear = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHalls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuidCinema = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaHalls_Cinemas_GuidCinema",
                        column: x => x.GuidCinema,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlacesCinemaHalls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    NumberPlace = table.Column<long>(type: "bigint", nullable: true),
                    GuidCinemaHall = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesCinemaHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacesCinemaHalls_CinemaHalls_GuidCinemaHall",
                        column: x => x.GuidCinemaHall,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Showtimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceShowTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GuidFilm = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GuidCinemaHall = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Showtimes_CinemaHalls_GuidCinemaHall",
                        column: x => x.GuidCinemaHall,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Showtimes_Films_GuidFilm",
                        column: x => x.GuidFilm,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    GuidClient = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GuidShowTimes = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GuidPlaceCinemaHall = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Clients_GuidClient",
                        column: x => x.GuidClient,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_PlacesCinemaHalls_GuidPlaceCinemaHall",
                        column: x => x.GuidPlaceCinemaHall,
                        principalTable: "PlacesCinemaHalls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Showtimes_GuidShowTimes",
                        column: x => x.GuidShowTimes,
                        principalTable: "Showtimes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuidClient",
                table: "Bookings",
                column: "GuidClient");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuidPlaceCinemaHall",
                table: "Bookings",
                column: "GuidPlaceCinemaHall");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuidShowTimes",
                table: "Bookings",
                column: "GuidShowTimes");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_GuidCinema",
                table: "CinemaHalls",
                column: "GuidCinema");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesCinemaHalls_GuidCinemaHall",
                table: "PlacesCinemaHalls",
                column: "GuidCinemaHall");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_GuidCinemaHall",
                table: "Showtimes",
                column: "GuidCinemaHall");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_GuidFilm",
                table: "Showtimes",
                column: "GuidFilm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PlacesCinemaHalls");

            migrationBuilder.DropTable(
                name: "Showtimes");

            migrationBuilder.DropTable(
                name: "CinemaHalls");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
