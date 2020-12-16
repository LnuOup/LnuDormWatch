using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LDW.Persistence.Migrations
{
    public partial class AddForum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForumSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    SectionTitle = table.Column<string>(maxLength: 100, nullable: false),
                    SectionDescription = table.Column<string>(maxLength: 200, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumSections_UserRefs_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "UserRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumThreads",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    ThreadTitle = table.Column<string>(maxLength: 200, nullable: false),
                    ThreadBody = table.Column<string>(maxLength: 5000, nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    ForumSectionId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThreads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumThreads_UserRefs_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "UserRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumThreads_ForumSections_ForumSectionId",
                        column: x => x.ForumSectionId,
                        principalTable: "ForumSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumThreadReplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    AuthorId = table.Column<string>(nullable: false),
                    ReplyBody = table.Column<string>(maxLength: 5000, nullable: false),
                    ParentForumThreadId = table.Column<Guid>(nullable: false),
                    ParentForumThreadReplyId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThreadReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumThreadReplies_UserRefs_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "UserRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumThreadReplies_ForumThreads_ParentForumThreadId",
                        column: x => x.ParentForumThreadId,
                        principalTable: "ForumThreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumThreadReplies_ForumThreadReplies_ParentForumThreadReplyId",
                        column: x => x.ParentForumThreadReplyId,
                        principalTable: "ForumThreadReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumSections_AuthorId",
                table: "ForumSections",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplies_AuthorId",
                table: "ForumThreadReplies",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplies_ParentForumThreadId",
                table: "ForumThreadReplies",
                column: "ParentForumThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplies_ParentForumThreadReplyId",
                table: "ForumThreadReplies",
                column: "ParentForumThreadReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreads_AuthorId",
                table: "ForumThreads",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreads_ForumSectionId",
                table: "ForumThreads",
                column: "ForumSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumThreadReplies");

            migrationBuilder.DropTable(
                name: "ForumThreads");

            migrationBuilder.DropTable(
                name: "ForumSections");
        }
    }
}
