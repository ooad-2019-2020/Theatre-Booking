using Microsoft.EntityFrameworkCore.Migrations;

namespace TheaterBooking.Migrations
{
    public partial class novaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Korisnik_KorisnikID",
                table: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_KorisnikID",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "UkupniTrosak",
                table: "Rezervacija");

            migrationBuilder.RenameColumn(
                name: "opis",
                table: "Dogadjaj",
                newName: "Opis");

            migrationBuilder.RenameColumn(
                name: "naziv",
                table: "Dogadjaj",
                newName: "Naziv");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Dogadjaj",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "Dogadjaj",
                newName: "opis");

            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Dogadjaj",
                newName: "naziv");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Rezervacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UkupniTrosak",
                table: "Rezervacija",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "naziv",
                table: "Dogadjaj",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KarticaID = table.Column<int>(type: "int", nullable: false),
                    Popust = table.Column<int>(type: "int", nullable: false),
                    Uloga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrstaKartice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => x.KorisnikUlogaID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikUlogaID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnikUloga_KorisnikUlogaID",
                        column: x => x.KorisnikUlogaID,
                        principalTable: "KorisnikUloga",
                        principalColumn: "KorisnikUlogaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikID",
                table: "Rezervacija",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_KorisnikUlogaID",
                table: "Korisnik",
                column: "KorisnikUlogaID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Korisnik_KorisnikID",
                table: "Rezervacija",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "KorisnikID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
