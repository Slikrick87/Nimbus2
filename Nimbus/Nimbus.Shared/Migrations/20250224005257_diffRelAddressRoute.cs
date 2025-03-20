using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus.Shared.Migrations
{
    /// <inheritdoc />
    public partial class diffRelAddressRoute : Migration
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

            migrationBuilder.DropColumn(
                name: "routeId",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "routeId",
                table: "Addresses",
                type: "INTEGER",
                nullable: true);

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
