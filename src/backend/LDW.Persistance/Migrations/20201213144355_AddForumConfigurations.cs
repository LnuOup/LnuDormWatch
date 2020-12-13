using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LDW.Persistence.Migrations
{
    public partial class AddForumConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumSectionEntity_UserRefs_AuthorId",
                table: "ForumSectionEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadEntity_UserRefs_AuthorId",
                table: "ForumThreadEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadEntity_ForumSectionEntity_ForumSectionId",
                table: "ForumThreadEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadReplyEntity_UserRefs_AuthorId1",
                table: "ForumThreadReplyEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadReplyEntity_ForumThreadEntity_ForumThreadId",
                table: "ForumThreadReplyEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadReplyEntity_ForumThreadReplyEntity_ParentForumThreadReplyId",
                table: "ForumThreadReplyEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumThreadReplyEntity",
                table: "ForumThreadReplyEntity");

            migrationBuilder.DropIndex(
                name: "IX_ForumThreadReplyEntity_AuthorId1",
                table: "ForumThreadReplyEntity");

            migrationBuilder.DropIndex(
                name: "IX_ForumThreadReplyEntity_ForumThreadId",
                table: "ForumThreadReplyEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumThreadEntity",
                table: "ForumThreadEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumSectionEntity",
                table: "ForumSectionEntity");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "ForumThreadReplyEntity");

            migrationBuilder.DropColumn(
                name: "ForumThreadId",
                table: "ForumThreadReplyEntity");

            migrationBuilder.RenameTable(
                name: "ForumThreadReplyEntity",
                newName: "ForumThreadReplies");

            migrationBuilder.RenameTable(
                name: "ForumThreadEntity",
                newName: "ForumThreads");

            migrationBuilder.RenameTable(
                name: "ForumSectionEntity",
                newName: "ForumSections");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreadReplyEntity_ParentForumThreadReplyId",
                table: "ForumThreadReplies",
                newName: "IX_ForumThreadReplies_ParentForumThreadReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreadEntity_ForumSectionId",
                table: "ForumThreads",
                newName: "IX_ForumThreads_ForumSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreadEntity_AuthorId",
                table: "ForumThreads",
                newName: "IX_ForumThreads_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumSectionEntity_AuthorId",
                table: "ForumSections",
                newName: "IX_ForumSections_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "ReplyBody",
                table: "ForumThreadReplies",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentForumThreadId",
                table: "ForumThreadReplies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "ForumThreadReplies",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ThreadTitle",
                table: "ForumThreads",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThreadBody",
                table: "ForumThreads",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "ForumThreads",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectionTitle",
                table: "ForumSections",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectionDescription",
                table: "ForumSections",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumThreadReplies",
                table: "ForumThreadReplies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumThreads",
                table: "ForumThreads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumSections",
                table: "ForumSections",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplies_AuthorId",
                table: "ForumThreadReplies",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplies_ParentForumThreadId",
                table: "ForumThreadReplies",
                column: "ParentForumThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumSections_UserRefs_AuthorId",
                table: "ForumSections",
                column: "AuthorId",
                principalTable: "UserRefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadReplies_UserRefs_AuthorId",
                table: "ForumThreadReplies",
                column: "AuthorId",
                principalTable: "UserRefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadReplies_ForumThreads_ParentForumThreadId",
                table: "ForumThreadReplies",
                column: "ParentForumThreadId",
                principalTable: "ForumThreads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadReplies_ForumThreadReplies_ParentForumThreadReplyId",
                table: "ForumThreadReplies",
                column: "ParentForumThreadReplyId",
                principalTable: "ForumThreadReplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreads_UserRefs_AuthorId",
                table: "ForumThreads",
                column: "AuthorId",
                principalTable: "UserRefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreads_ForumSections_ForumSectionId",
                table: "ForumThreads",
                column: "ForumSectionId",
                principalTable: "ForumSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumSections_UserRefs_AuthorId",
                table: "ForumSections");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadReplies_UserRefs_AuthorId",
                table: "ForumThreadReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadReplies_ForumThreads_ParentForumThreadId",
                table: "ForumThreadReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreadReplies_ForumThreadReplies_ParentForumThreadReplyId",
                table: "ForumThreadReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreads_UserRefs_AuthorId",
                table: "ForumThreads");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreads_ForumSections_ForumSectionId",
                table: "ForumThreads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumThreads",
                table: "ForumThreads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumThreadReplies",
                table: "ForumThreadReplies");

            migrationBuilder.DropIndex(
                name: "IX_ForumThreadReplies_AuthorId",
                table: "ForumThreadReplies");

            migrationBuilder.DropIndex(
                name: "IX_ForumThreadReplies_ParentForumThreadId",
                table: "ForumThreadReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumSections",
                table: "ForumSections");

            migrationBuilder.RenameTable(
                name: "ForumThreads",
                newName: "ForumThreadEntity");

            migrationBuilder.RenameTable(
                name: "ForumThreadReplies",
                newName: "ForumThreadReplyEntity");

            migrationBuilder.RenameTable(
                name: "ForumSections",
                newName: "ForumSectionEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreads_ForumSectionId",
                table: "ForumThreadEntity",
                newName: "IX_ForumThreadEntity_ForumSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreads_AuthorId",
                table: "ForumThreadEntity",
                newName: "IX_ForumThreadEntity_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreadReplies_ParentForumThreadReplyId",
                table: "ForumThreadReplyEntity",
                newName: "IX_ForumThreadReplyEntity_ParentForumThreadReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumSections_AuthorId",
                table: "ForumSectionEntity",
                newName: "IX_ForumSectionEntity_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "ThreadTitle",
                table: "ForumThreadEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ThreadBody",
                table: "ForumThreadEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "ForumThreadEntity",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ReplyBody",
                table: "ForumThreadReplyEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "ParentForumThreadId",
                table: "ForumThreadReplyEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "ForumThreadReplyEntity",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "ForumThreadReplyEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForumThreadId",
                table: "ForumThreadReplyEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectionTitle",
                table: "ForumSectionEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SectionDescription",
                table: "ForumSectionEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumThreadEntity",
                table: "ForumThreadEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumThreadReplyEntity",
                table: "ForumThreadReplyEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumSectionEntity",
                table: "ForumSectionEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplyEntity_AuthorId1",
                table: "ForumThreadReplyEntity",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadReplyEntity_ForumThreadId",
                table: "ForumThreadReplyEntity",
                column: "ForumThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumSectionEntity_UserRefs_AuthorId",
                table: "ForumSectionEntity",
                column: "AuthorId",
                principalTable: "UserRefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadEntity_UserRefs_AuthorId",
                table: "ForumThreadEntity",
                column: "AuthorId",
                principalTable: "UserRefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadEntity_ForumSectionEntity_ForumSectionId",
                table: "ForumThreadEntity",
                column: "ForumSectionId",
                principalTable: "ForumSectionEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadReplyEntity_UserRefs_AuthorId1",
                table: "ForumThreadReplyEntity",
                column: "AuthorId1",
                principalTable: "UserRefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadReplyEntity_ForumThreadEntity_ForumThreadId",
                table: "ForumThreadReplyEntity",
                column: "ForumThreadId",
                principalTable: "ForumThreadEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreadReplyEntity_ForumThreadReplyEntity_ParentForumThreadReplyId",
                table: "ForumThreadReplyEntity",
                column: "ParentForumThreadReplyId",
                principalTable: "ForumThreadReplyEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
