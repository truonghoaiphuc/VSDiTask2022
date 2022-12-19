using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSDiTask.Core.Migrations
{
    public partial class addcreatedateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "AppUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedId",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "AppUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedId",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "UpdatedId",
                table: "AppUser");
        }
    }
}
