using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LDW.Persistence.Migrations
{
    public partial class AddForum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForumSectionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SectionTitle = table.Column<string>(nullable: true),
                    SectionDescription = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumSectionEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumSectionEntity_UserRefs_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "UserRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumThreadEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ThreadTitle = table.Column<string>(nullable: true),
                    ThreadBody = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    ForumSectionId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThreadEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumThreadEntity_UserRefs_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "UserRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumThreadEntity_ForumSectionEntity_ForumSectionId",
                        column: x => x.ForumSectionId,
                        principalTable: "ForumSectionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumThreadReplyEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    ReplyBody = table.Column<string>(nullable: true),
                    ParentForumThreadId = table.Column<string>(nullable: true),
                    ParentForumThreadReplyId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    AuthorId1 = table.Column<string>(nullable: true),
                    ForumThreadId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThreadReplyEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumThreadReplyEntity_UserRefs_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "UserRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumThreadReplyEntity_ForumThreadEntity_ForumThreadId",
                        column: x => x.ForumThreadId,
                        principalTable: "ForumThreadEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumThreadReplyEntity_ForumThreadReplyEntity_ParentForumThreadReplyId",
                        column: x => x.ParentForumThreadReplyId,
                        principalTable: "ForumThreadReplyEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumSectionEntity_AuthorId",
                table: "ForumSectionEntity",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadEntity_AuthorId",
                table: "ForumThreadEntity",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadEntity_ForumSectionId",
                table: "ForumThreadEntity",
                column: "ForumSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplyEntity_AuthorId1",
                table: "ForumThreadReplyEntity",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplyEntity_ForumThreadId",
                table: "ForumThreadReplyEntity",
                column: "ForumThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplyEntity_ParentForumThreadReplyId",
                table: "ForumThreadReplyEntity",
                column: "ParentForumThreadReplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumThreadReplyEntity");

            migrationBuilder.DropTable(
                name: "ForumThreadEntity");

            migrationBuilder.DropTable(
                name: "ForumSectionEntity");
        }
    }
}
