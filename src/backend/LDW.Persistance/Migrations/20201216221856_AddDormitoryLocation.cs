using Microsoft.EntityFrameworkCore.Migrations;

namespace LDW.Persistence.Migrations
{
    public partial class AddDormitoryLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Dormitories",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Dormitories",
                nullable: true);
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
