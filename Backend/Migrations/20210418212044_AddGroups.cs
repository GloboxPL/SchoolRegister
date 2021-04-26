using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.Migrations
{
    public partial class AddGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Users_TeacherId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Group_GroupsName",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Group_GroupName",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Group_TeacherId",
                table: "Groups",
                newName: "IX_Groups_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Groups_GroupsName",
                table: "GroupStudent",
                column: "GroupsName",
                principalTable: "Groups",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Groups_GroupName",
                table: "Lesson",
                column: "GroupName",
                principalTable: "Groups",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_TeacherId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Groups_GroupsName",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Groups_GroupName",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_TeacherId",
                table: "Group",
                newName: "IX_Group_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Users_TeacherId",
                table: "Group",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Group_GroupsName",
                table: "GroupStudent",
                column: "GroupsName",
                principalTable: "Group",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Group_GroupName",
                table: "Lesson",
                column: "GroupName",
                principalTable: "Group",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
