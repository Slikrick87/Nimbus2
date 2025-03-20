using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddedForgottenOilChangeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "oilChange",
                table: "Trucks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oilChange",
                table: "Trucks");
        }
    }
}
