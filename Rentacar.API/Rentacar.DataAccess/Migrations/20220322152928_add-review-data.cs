using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.DataAccess.Migrations
{
    public partial class addreviewdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReviewAdded",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewAdded",
                table: "Booking");
        }
    }
}
