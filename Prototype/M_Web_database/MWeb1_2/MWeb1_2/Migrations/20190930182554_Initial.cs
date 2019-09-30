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
                name: "Userss",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: true),
                    userEmail = table.Column<string>(nullable: true),
                    userPassword = table.Column<string>(nullable: true),
                    created = table.Column<byte[]>(nullable: true),
                    userStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userss", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Markers",
                columns: table => new
                {
                    markerID = table.Column<string>(nullable: false),
                    userID = table.Column<int>(nullable: false),
                    markerLat = table.Column<double>(nullable: false),
                    markerLng = table.Column<double>(nullable: false),
                    photo = table.Column<byte[]>(nullable: true),
                    photoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.markerID);
                    table.ForeignKey(
                        name: "FK_Markers_Userss_userID",
                        column: x => x.userID,
                        principalTable: "Userss",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    settingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<int>(nullable: false),
                    centerLat = table.Column<decimal>(nullable: false),
                    centerLng = table.Column<decimal>(nullable: false),
                    centerZoom = table.Column<int>(nullable: false),
                    mapType = table.Column<string>(nullable: true),
                    pinRadius = table.Column<int>(nullable: false),
                    Gps = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.settingID);
                    table.ForeignKey(
                        name: "FK_UserSettings_Userss_userID",
                        column: x => x.userID,
                        principalTable: "Userss",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    markerID = table.Column<string>(nullable: true),
                    userID = table.Column<int>(nullable: false),
                    comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comments_Markers_markerID",
                        column: x => x.markerID,
                        principalTable: "Markers",
                        principalColumn: "markerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Userss_userID",
                        column: x => x.userID,
                        principalTable: "Userss",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_markerID",
                table: "Comments",
                column: "markerID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userID",
                table: "Comments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Markers_userID",
                table: "Markers",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_userID",
                table: "UserSettings",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Markers");

            migrationBuilder.DropTable(
                name: "Userss");
        }
    }
}
