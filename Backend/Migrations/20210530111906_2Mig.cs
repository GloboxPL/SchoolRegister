using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.Migrations
{
    public partial class _2Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWholeClass",
                table: "Groups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWholeClass",
                table: "Groups",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
