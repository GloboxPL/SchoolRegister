using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.Migrations
{
    public partial class _4Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Lessons");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Lessons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Lessons",
                type: "text",
                nullable: true);
        }
    }
}
