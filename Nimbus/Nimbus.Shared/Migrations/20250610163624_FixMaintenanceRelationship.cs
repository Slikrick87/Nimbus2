using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus.Shared.Migrations
{
    /// <inheritdoc />
    public partial class FixMaintenanceRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trucks_truckId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Routes_routeId",
                table: "Trucks");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Trucks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Addresses",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Addresses",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "index",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Maintenance Records",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cost = table.Column<float>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Mileage = table.Column<int>(type: "INTEGER", nullable: false),
                    TruckId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance Records", x => x.id);
                    table.ForeignKey(
                        name: "FK_Maintenance Records_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance Records_TruckId",
                table: "Maintenance Records",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses",
                column: "routeId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trucks_truckId",
                table: "Routes",
                column: "truckId",
                principalTable: "Trucks",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Routes_routeId",
                table: "Trucks",
                column: "routeId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trucks_truckId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Routes_routeId",
                table: "Trucks");

            migrationBuilder.DropTable(
                name: "Maintenance Records");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "index",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Trucks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses",
                column: "routeId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trucks_truckId",
                table: "Routes",
                column: "truckId",
                principalTable: "Trucks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Routes_routeId",
                table: "Trucks",
                column: "routeId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
