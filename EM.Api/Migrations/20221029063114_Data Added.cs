using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Api.Migrations
{
    public partial class DataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 29, 9, 31, 14, 23, DateTimeKind.Local).AddTicks(2398), "This the Development team", "Development" },
                    { 2, new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(220), "This the Consulting team", "Consulting" },
                    { 3, new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(244), "This the Back Office team", "Back Office" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(7875), "Ability to communicate", "Communication" },
                    { 2, new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(8222), "Ability to work with team", "Teamwork" },
                    { 3, new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(8229), "Ability to solve problems", "Problem solving" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
