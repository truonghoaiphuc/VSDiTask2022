using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSDiTask.Core.Migrations
{
    public partial class adddeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Companies",
                newName: "CompName");

            migrationBuilder.RenameColumn(
                name: "CompanyCode",
                table: "Companies",
                newName: "CompCode");

            migrationBuilder.RenameColumn(
                name: "CompanyAddress",
                table: "Companies",
                newName: "CompAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CompanyCode",
                table: "Companies",
                newName: "IX_Companies_CompCode");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "AppUser",
                newName: "DateOfBirth");

            migrationBuilder.AddColumn<string>(
                name: "DeptId",
                table: "AppUser",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AppUser",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AppUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "CompCode");

            migrationBuilder.CreateTable(
                name: "CATypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptCode);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_Branch",
                        column: x => x.Branch,
                        principalTable: "Companies",
                        principalColumn: "CompCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ITasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOffDates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OffDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOffDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "CASteps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATypeId = table.Column<long>(type: "bigint", nullable: false),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepOrder = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CASteps_CATypes_CATypeId",
                        column: x => x.CATypeId,
                        principalTable: "CATypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITaskSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITaskId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EventStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Deadline = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsKeyPerson = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITaskSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITaskSchedules_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITaskSchedules_ITasks_ITaskId",
                        column: x => x.ITaskId,
                        principalTable: "ITasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    FunctionId = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITaskDiscusses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STaskId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getutcdate()"),
                    UpdatedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITaskDiscusses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITaskDiscusses_ITaskSchedules_STaskId",
                        column: x => x.STaskId,
                        principalTable: "ITaskSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_DeptId",
                table: "AppUser",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_RoleId",
                table: "AppUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CASteps_CATypeId",
                table: "CASteps",
                column: "CATypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Branch",
                table: "Departments",
                column: "Branch");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeptCode",
                table: "Departments",
                column: "DeptCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Functions_Code",
                table: "Functions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ITaskDiscusses_STaskId",
                table: "ITaskDiscusses",
                column: "STaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ITaskSchedules_ITaskId",
                table: "ITaskSchedules",
                column: "ITaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ITaskSchedules_UserId",
                table: "ITaskSchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_FunctionId",
                table: "Permissions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                column: "RoleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Departments_DeptId",
                table: "AppUser",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Roles_RoleId",
                table: "AppUser",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Departments_DeptId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Roles_RoleId",
                table: "AppUser");

            migrationBuilder.DropTable(
                name: "CASteps");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "ITaskDiscusses");

            migrationBuilder.DropTable(
                name: "ListOffDates");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "CATypes");

            migrationBuilder.DropTable(
                name: "ITaskSchedules");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ITasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_DeptId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_RoleId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "CompName",
                table: "Companies",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "CompAddress",
                table: "Companies",
                newName: "CompanyAddress");

            migrationBuilder.RenameColumn(
                name: "CompCode",
                table: "Companies",
                newName: "CompanyCode");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CompCode",
                table: "Companies",
                newName: "IX_Companies_CompanyCode");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "AppUser",
                newName: "Birthday");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");
        }
    }
}
