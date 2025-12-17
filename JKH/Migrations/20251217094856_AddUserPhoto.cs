using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKH.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
