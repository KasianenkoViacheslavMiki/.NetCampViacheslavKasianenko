using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork15Task1.Migrations
{
    /// <inheritdoc />
    public partial class AddPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_PlacesCinemaHalls_PlacesCinemaHallId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PlacesCinemaHallId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PlacesCinemaHallId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuidPlaceCinemaHall",
                table: "Bookings",
                column: "GuidPlaceCinemaHall");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_PlacesCinemaHalls_GuidPlaceCinemaHall",
                table: "Bookings",
                column: "GuidPlaceCinemaHall",
                principalTable: "PlacesCinemaHalls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_PlacesCinemaHalls_GuidPlaceCinemaHall",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_GuidPlaceCinemaHall",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "PlacesCinemaHallId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlacesCinemaHallId",
                table: "Bookings",
                column: "PlacesCinemaHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_PlacesCinemaHalls_PlacesCinemaHallId",
                table: "Bookings",
                column: "PlacesCinemaHallId",
                principalTable: "PlacesCinemaHalls",
                principalColumn: "Id");
        }
    }
}
