using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKH.Migrations
{
    /// <inheritdoc />
    public partial class Photor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhotos_AspNetUsers_UserId1",
                table: "UserPhotos");

            migrationBuilder.DropIndex(
                name: "IX_UserPhotos_UserId1",
                table: "UserPhotos");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserPhotos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserPhotos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhotos_UserId1",
                table: "UserPhotos",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhotos_AspNetUsers_UserId1",
                table: "UserPhotos",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
