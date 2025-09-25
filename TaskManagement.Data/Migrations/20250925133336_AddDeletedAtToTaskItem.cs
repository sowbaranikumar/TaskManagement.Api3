using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAtToTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Tasks",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                column: "DeletedAt",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tasks");
        }
    }
}
