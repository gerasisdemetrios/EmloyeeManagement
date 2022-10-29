using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Api.Migrations
{
    public partial class Namesplitted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 18, 1, 49, 156, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 18, 1, 49, 158, DateTimeKind.Local).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 18, 1, 49, 158, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 18, 1, 49, 159, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 18, 1, 49, 159, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 18, 1, 49, 159, DateTimeKind.Local).AddTicks(436));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 9, 31, 14, 23, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(8229));
        }
    }
}
