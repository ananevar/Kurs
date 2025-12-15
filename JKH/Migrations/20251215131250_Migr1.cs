using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKH.Migrations
{
    /// <inheritdoc />
    public partial class Migr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillLines_Bills_BillId",
                table: "BillLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BillLines_Meters_MeterId",
                table: "BillLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Properties_PropertyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Meters_MeterId",
                table: "MeterReadings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meters_Properties_PropertyId",
                table: "Meters");

            migrationBuilder.DropForeignKey(
                name: "FK_Meters_ServiceTypes_ServiceTypeId",
                table: "Meters");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_ServiceTypes_ServiceTypeId",
                table: "Tariffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tariffs",
                table: "Tariffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meters",
                table: "Meters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeterReadings",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_MeterId_ReadingDate",
                table: "MeterReadings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bills",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PropertyId_Period",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillLines",
                table: "BillLines");

            migrationBuilder.DropIndex(
                name: "IX_BillLines_BillId_MeterId",
                table: "BillLines");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Tariffs",
                newName: "Tariff");

            migrationBuilder.RenameTable(
                name: "ServiceTypes",
                newName: "ServiceType");

            migrationBuilder.RenameTable(
                name: "Meters",
                newName: "Meter");

            migrationBuilder.RenameTable(
                name: "MeterReadings",
                newName: "MeterReading");

            migrationBuilder.RenameTable(
                name: "Bills",
                newName: "Bill");

            migrationBuilder.RenameTable(
                name: "BillLines",
                newName: "BillLine");

            migrationBuilder.RenameIndex(
                name: "IX_Tariffs_ServiceTypeId",
                table: "Tariff",
                newName: "IX_Tariff_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Meters_ServiceTypeId",
                table: "Meter",
                newName: "IX_Meter_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Meters_PropertyId",
                table: "Meter",
                newName: "IX_Meter_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_BillLines_MeterId",
                table: "BillLine",
                newName: "IX_BillLine_MeterId");

            migrationBuilder.AlterColumn<string>(
                name: "Apartment",
                table: "Properties",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tariff",
                table: "Tariff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meter",
                table: "Meter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeterReading",
                table: "MeterReading",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillLine",
                table: "BillLine",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DistrictId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StreetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BuildingId",
                table: "Properties",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId_BuildingId_Apartment",
                table: "Properties",
                columns: new[] { "UserId", "BuildingId", "Apartment" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeterReading_MeterId",
                table: "MeterReading",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PropertyId",
                table: "Bill",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLine_BillId",
                table: "BillLine",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_StreetId_Number",
                table: "Buildings",
                columns: new[] { "StreetId", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId_Name",
                table: "Districts",
                columns: new[] { "CityId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_DistrictId_Name",
                table: "Streets",
                columns: new[] { "DistrictId", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Properties_PropertyId",
                table: "Bill",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillLine_Bill_BillId",
                table: "BillLine",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillLine_Meter_MeterId",
                table: "BillLine",
                column: "MeterId",
                principalTable: "Meter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_Properties_PropertyId",
                table: "Meter",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meter_ServiceType_ServiceTypeId",
                table: "Meter",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReading_Meter_MeterId",
                table: "MeterReading",
                column: "MeterId",
                principalTable: "Meter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Buildings_BuildingId",
                table: "Properties",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariff_ServiceType_ServiceTypeId",
                table: "Tariff",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Properties_PropertyId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_BillLine_Bill_BillId",
                table: "BillLine");

            migrationBuilder.DropForeignKey(
                name: "FK_BillLine_Meter_MeterId",
                table: "BillLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Meter_Properties_PropertyId",
                table: "Meter");

            migrationBuilder.DropForeignKey(
                name: "FK_Meter_ServiceType_ServiceTypeId",
                table: "Meter");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReading_Meter_MeterId",
                table: "MeterReading");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Buildings_BuildingId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariff_ServiceType_ServiceTypeId",
                table: "Tariff");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Properties_BuildingId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_UserId_BuildingId_Apartment",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tariff",
                table: "Tariff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeterReading",
                table: "MeterReading");

            migrationBuilder.DropIndex(
                name: "IX_MeterReading_MeterId",
                table: "MeterReading");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meter",
                table: "Meter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillLine",
                table: "BillLine");

            migrationBuilder.DropIndex(
                name: "IX_BillLine_BillId",
                table: "BillLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_PropertyId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Tariff",
                newName: "Tariffs");

            migrationBuilder.RenameTable(
                name: "ServiceType",
                newName: "ServiceTypes");

            migrationBuilder.RenameTable(
                name: "MeterReading",
                newName: "MeterReadings");

            migrationBuilder.RenameTable(
                name: "Meter",
                newName: "Meters");

            migrationBuilder.RenameTable(
                name: "BillLine",
                newName: "BillLines");

            migrationBuilder.RenameTable(
                name: "Bill",
                newName: "Bills");

            migrationBuilder.RenameIndex(
                name: "IX_Tariff_ServiceTypeId",
                table: "Tariffs",
                newName: "IX_Tariffs_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Meter_ServiceTypeId",
                table: "Meters",
                newName: "IX_Meters_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Meter_PropertyId",
                table: "Meters",
                newName: "IX_Meters_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_BillLine_MeterId",
                table: "BillLines",
                newName: "IX_BillLines_MeterId");

            migrationBuilder.AlterColumn<string>(
                name: "Apartment",
                table: "Properties",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Properties",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tariffs",
                table: "Tariffs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeterReadings",
                table: "MeterReadings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meters",
                table: "Meters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillLines",
                table: "BillLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bills",
                table: "Bills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_MeterId_ReadingDate",
                table: "MeterReadings",
                columns: new[] { "MeterId", "ReadingDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillLines_BillId_MeterId",
                table: "BillLines",
                columns: new[] { "BillId", "MeterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PropertyId_Period",
                table: "Bills",
                columns: new[] { "PropertyId", "Period" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillLines_Bills_BillId",
                table: "BillLines",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillLines_Meters_MeterId",
                table: "BillLines",
                column: "MeterId",
                principalTable: "Meters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Properties_PropertyId",
                table: "Bills",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Meters_MeterId",
                table: "MeterReadings",
                column: "MeterId",
                principalTable: "Meters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meters_Properties_PropertyId",
                table: "Meters",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meters_ServiceTypes_ServiceTypeId",
                table: "Meters",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_ServiceTypes_ServiceTypeId",
                table: "Tariffs",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
