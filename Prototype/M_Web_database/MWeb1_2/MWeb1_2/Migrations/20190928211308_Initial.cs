using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                    markerLat = table.Column<double>(nullable: false),
                    markerLng = table.Column<double>(nullable: false),
                    photo = table.Column<string>(nullable: true),
                    photoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.markerID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: true),
                    userEmail = table.Column<string>(nullable: true),
                    userPassword = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    userStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
