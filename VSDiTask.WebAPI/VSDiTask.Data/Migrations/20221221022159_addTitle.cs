using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSDiTask.Core.Migrations
{
    public partial class addTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "ITasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TitleId",
                table: "AppUser",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    TitleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TitleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.TitleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_TitleId",
                table: "AppUser",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_TitleId",
                table: "Titles",
                column: "TitleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Titles_TitleId",
                table: "AppUser",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Titles_TitleId",
                table: "AppUser");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_TitleId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "ITasks");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "AppUser");
        }
    }
}
