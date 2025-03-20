using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus.Shared.Migrations
{
    /// <inheritdoc />
    public partial class RelAddToRouteCorrectedAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_routeId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "routeId",
                table: "Addresses",
                newName: "routeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_routeId1",
                table: "Addresses",
                column: "routeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_routeId1",
                table: "Addresses",
                column: "routeId1",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Routes_routeId1",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_routeId1",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "routeId1",
                table: "Addresses",
                newName: "routeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_routeId",
                table: "Addresses",
                column: "routeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Routes_routeId",
                table: "Addresses",
                column: "routeId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
