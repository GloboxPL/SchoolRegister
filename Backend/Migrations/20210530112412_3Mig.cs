using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.Migrations
{
    public partial class _3Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStudent");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupName",
                table: "Users",
                column: "GroupName");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupName",
                table: "Users",
                column: "GroupName",
                principalTable: "Groups",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "GroupStudent",
                columns: table => new
                {
                    GroupsName = table.Column<string>(type: "text", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudent", x => new { x.GroupsName, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GroupStudent_Groups_GroupsName",
                        column: x => x.GroupsName,
                        principalTable: "Groups",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStudent_Users_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_StudentsId",
                table: "GroupStudent",
                column: "StudentsId");
        }
    }
}
