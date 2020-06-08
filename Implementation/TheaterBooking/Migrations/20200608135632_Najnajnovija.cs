using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheaterBooking.Migrations
{
    public partial class Najnajnovija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserID",
                table: "Dogadjaj",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Dogadjaj",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "Dogadjaj");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Dogadjaj");
        }
    }
}
