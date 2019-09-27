using Microsoft.EntityFrameworkCore.Migrations;

namespace MWeb1_2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markers",
                columns: table => new
                {
                    markerID = table.Column<string>(nullable: false),
                    userID = table.Column<int>(nullable: false),
                    markerLat = table.Column<decimal>(nullable: false),
                    markerLng = table.Column<decimal>(nullable: false),
                    photo = table.Column<string>(nullable: true),
                    photoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.markerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markers");
        }
    }
}
