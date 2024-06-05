using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class афавафа : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6dcb9c40-8b55-46c9-83b9-2eb055f96387"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff2c72fd-5e80-4227-95a8-2607a8c66e9a"));

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Animals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0c6bb84f-47a3-422a-8d3f-b761286fb0db"), null, "Admin", "ADMIN" },
                    { new Guid("ad894c5c-0b3a-4ac2-afb0-b7efeebeab10"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c6bb84f-47a3-422a-8d3f-b761286fb0db"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad894c5c-0b3a-4ac2-afb0-b7efeebeab10"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Animals",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "Animals",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Animals",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6dcb9c40-8b55-46c9-83b9-2eb055f96387"), null, "Admin", "ADMIN" },
                    { new Guid("ff2c72fd-5e80-4227-95a8-2607a8c66e9a"), null, "User", "USER" }
                });
        }
    }
}
