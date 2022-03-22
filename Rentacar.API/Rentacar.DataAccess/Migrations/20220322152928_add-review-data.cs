using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentacar.DataAccess.Migrations
{
    public partial class addreviewdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Model_ModelId",
                table: "Review");

            migrationBuilder.AddColumn<bool>(
                name: "ReviewAdded",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Model_ModelId",
                table: "Review",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Model_ModelId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewAdded",
                table: "Booking");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Model_ModelId",
                table: "Review",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
