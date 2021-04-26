using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolRegister.Migrations
{
    public partial class AddLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Groups_GroupName",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Subject_SubjectId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Users_TeacherId",
                table: "Lesson");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_SubjectId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Lesson");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_TeacherId",
                table: "Lessons",
                newName: "IX_Lessons_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_GroupName",
                table: "Lessons",
                newName: "IX_Lessons_GroupName");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Lessons",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupName",
                table: "Lessons",
                column: "GroupName",
                principalTable: "Groups",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Users_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupName",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Users_TeacherId",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Lessons");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lesson",
                newName: "IX_Lesson_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_GroupName",
                table: "Lesson",
                newName: "IX_Lesson_GroupName");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Lesson",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SubjectId",
                table: "Lesson",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Groups_GroupName",
                table: "Lesson",
                column: "GroupName",
                principalTable: "Groups",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Subject_SubjectId",
                table: "Lesson",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Users_TeacherId",
                table: "Lesson",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
