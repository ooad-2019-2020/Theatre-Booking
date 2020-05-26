using Microsoft.EntityFrameworkCore.Migrations;

namespace TheaterBooking.Migrations
{
    public partial class Migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PredstavaID",
                table: "Sjediste",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_PredstavaID",
                table: "Sjediste",
                column: "PredstavaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sjediste_Predstava_PredstavaID",
                table: "Sjediste",
                column: "PredstavaID",
                principalTable: "Predstava",
                principalColumn: "PredstavaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sjediste_Predstava_PredstavaID",
                table: "Sjediste");

            migrationBuilder.DropIndex(
                name: "IX_Sjediste_PredstavaID",
                table: "Sjediste");

            migrationBuilder.DropColumn(
                name: "PredstavaID",
                table: "Sjediste");
        }
    }
}
