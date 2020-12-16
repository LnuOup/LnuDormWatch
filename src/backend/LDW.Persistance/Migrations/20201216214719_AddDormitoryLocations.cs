using Microsoft.EntityFrameworkCore.Migrations;

namespace LDW.Persistence.Migrations
{
    public partial class AddDormitoryLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Dormitories",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Dormitories",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Dormitories");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Dormitories");
        }
    }
}
