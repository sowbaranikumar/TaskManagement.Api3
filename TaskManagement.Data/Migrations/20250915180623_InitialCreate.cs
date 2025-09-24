using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Project Alpha" },
                    { 2, "Project Beta" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice Johnson", "Manager" },
                    { 2, "bob@example.com", "Bob Smith", "Developer" },
                    { 3, "charlie@example.com", "Charlie Brown", "Tester" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "Priority", "ProjectId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Create ER diagram", new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 1, "Design DB Schema", 1 },
                    { 2, "Initialize Web API", new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, "Setup API Project", 2 },
                    { 3, "Add JWT support", new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, 1, "Implement Authentication", 2 },
                    { 4, "Cover service layer", new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 1, "Write Unit Tests", 3 },
                    { 5, "Configure GitHub Actions", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, "Setup CI/CD", 1 },
                    { 6, "Connect React app", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, 2, "Frontend Integration", 2 },
                    { 7, "Generate Swagger docs", new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 2, "API Documentation", 1 },
                    { 8, "Apply EF Core migrations", new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 2, "Database Migration", 3 },
                    { 9, "Fix API endpoints", new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 2, "Bug Fixing", 2 },
                    { 10, "Run regression tests", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 2, "Final Testing", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
