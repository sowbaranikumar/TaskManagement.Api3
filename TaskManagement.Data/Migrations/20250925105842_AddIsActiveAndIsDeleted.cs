using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveAndIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                column: "isActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                column: "isActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Tasks");
        }
    }
}
