using Microsoft.EntityFrameworkCore.Migrations;

namespace LDW.Persistence.Migrations.UserDb
{
    public partial class AddCompressedPhotoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompressedPhotoUrl",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompressedPhotoUrl",
                table: "AspNetUsers");
        }
    }
}
