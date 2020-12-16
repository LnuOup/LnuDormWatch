using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LDW.Persistence.Migrations
{
    public partial class ChangeDormitoryImageToImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "DormitoryPictures");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "DormitoryPictures",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "DormitoryPictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "DormitoryPictures",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
