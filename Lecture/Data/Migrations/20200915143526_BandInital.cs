using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Data.Migrations
{
    public partial class BandInital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bands",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bandName = table.Column<string>(nullable: false),
                    yearFormed = table.Column<int>(nullable: false),
                    numberOfMembers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bands", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bands");
        }
    }
}
