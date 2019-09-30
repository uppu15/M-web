using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MWeb_test.Migrations
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
                    userName = table.Column<string>(unicode: false, maxLength: 18, nullable: false),
                    userEmail = table.Column<string>(unicode: false, nullable: false),
                    userPassword = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    created = table.Column<byte[]>(rowVersion: true, nullable: false),
                    userStatus = table.Column<string>(unicode: false, maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Markers",
                columns: table => new
                {
                    markerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<int>(nullable: false),
                    markerLat = table.Column<decimal>(type: "decimal(10, 6)", nullable: false),
                    markerLng = table.Column<decimal>(type: "decimal(10, 6)", nullable: false),
                    photo = table.Column<byte[]>(type: "image", nullable: false),
                    photoPath = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marker", x => x.markerID);
                    table.ForeignKey(
                        name: "FK_Marker_User",
                        column: x => x.userID,
                        principalTable: "Userss",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    settingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<int>(nullable: false),
                    centerLat = table.Column<decimal>(type: "decimal(10, 6)", nullable: false),
                    centerLng = table.Column<decimal>(type: "decimal(10, 6)", nullable: false),
                    centerZoom = table.Column<int>(nullable: false),
                    mapType = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    pinRadius = table.Column<int>(nullable: false),
                    GPS = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.settingID);
                    table.ForeignKey(
                        name: "FK_Settings_Users",
                        column: x => x.userID,
                        principalTable: "Userss",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    markerID = table.Column<int>(nullable: false),
                    userID = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comment_Marker",
                        column: x => x.markerID,
                        principalTable: "Markers",
                        principalColumn: "markerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.userID,
                        principalTable: "Userss",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
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
