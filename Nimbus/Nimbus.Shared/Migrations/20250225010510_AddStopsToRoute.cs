using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddStopsToRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_RouteEntityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_routeId1",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_RouteEntityId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RouteEntityId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "routeId1",
                table: "Addresses",
                newName: "routeId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_routeId1",
                table: "Addresses",
                newName: "IX_Addresses_routeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses",
                column: "routeId",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "routeId",
                table: "Addresses",
                newName: "routeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_routeId",
                table: "Addresses",
                newName: "IX_Addresses_routeId1");

            migrationBuilder.AddColumn<int>(
                name: "RouteEntityId",
                table: "Addresses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RouteEntityId",
                table: "Addresses",
                column: "RouteEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_RouteEntityId",
                table: "Addresses",
                column: "RouteEntityId",
                principalTable: "Routes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_routeId1",
                table: "Addresses",
                column: "routeId1",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
