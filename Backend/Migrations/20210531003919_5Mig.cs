using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.Migrations
{
    public partial class _5Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Users_StudentsId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Marks",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "Attendances",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_StudentsId",
                table: "Attendances",
                newName: "IX_Attendances_StudentId");

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Lessons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "Attendances",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Users_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Users_StudentId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Marks",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Attendances",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                newName: "IX_Attendances_StudentsId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Attendances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Users_StudentsId",
                table: "Attendances",
                column: "StudentsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
