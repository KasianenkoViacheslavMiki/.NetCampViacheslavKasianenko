using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork15Task1.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuidCinema",
                table: "CinemaHalls",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_GuidCinema",
                table: "CinemaHalls",
                column: "GuidCinema");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_GuidCinema",
                table: "CinemaHalls",
                column: "GuidCinema",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_GuidCinema",
                table: "CinemaHalls");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_GuidCinema",
                table: "CinemaHalls");

            migrationBuilder.DropColumn(
                name: "GuidCinema",
                table: "CinemaHalls");
        }
    }
}
