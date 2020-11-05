using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dentist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: true),
                    Observatii = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    NumarFisa = table.Column<string>(nullable: true),
                    Medic = table.Column<string>(nullable: false),
                    SerieCi = table.Column<string>(nullable: true),
                    NumarCi = table.Column<string>(nullable: true),
                    Cnp = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Observatii = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dentist");

            migrationBuilder.DropTable(
                name: "Pacient");
        }
    }
}
