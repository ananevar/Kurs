using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKH.Migrations
{
    /// <inheritdoc />
    public partial class PhotoMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoContentType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoUpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserPhotos",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId1 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserPhotos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPhotos_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPhotos_UserId1",
                table: "UserPhotos",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPhotos");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "AspNetUsers",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoContentType",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PhotoUpdatedAt",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }
    }
}
