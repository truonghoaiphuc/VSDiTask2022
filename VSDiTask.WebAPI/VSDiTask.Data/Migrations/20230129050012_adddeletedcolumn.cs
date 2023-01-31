using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSDiTask.Core.Migrations
{
    public partial class adddeletedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "AppUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "AppUser");
        }
    }
}
