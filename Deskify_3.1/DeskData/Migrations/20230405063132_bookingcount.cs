using Microsoft.EntityFrameworkCore.Migrations;

namespace DeskData.Migrations
{
    public partial class bookingcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookingrequesttype",
                table: "bookingSeats");

            migrationBuilder.AddColumn<int>(
                name: "bookingcount",
                table: "bookingSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookingcount",
                table: "bookingSeats");

            migrationBuilder.AddColumn<string>(
                name: "bookingrequesttype",
                table: "bookingSeats",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
