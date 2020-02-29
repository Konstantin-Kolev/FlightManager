using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManager.Migrations
{
    public partial class changednameAvailableBusinesscolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableBussines",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "AvailableBusiness",
                table: "Flights",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableBusiness",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "AvailableBussines",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
