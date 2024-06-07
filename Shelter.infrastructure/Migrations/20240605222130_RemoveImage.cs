using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e567dd1d-adec-4f77-9a37-8bb6e8ca3282"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e72c30fa-3ccf-4691-b57a-71ae9965ff74"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Animals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6e4cea63-919b-4c63-b222-d335c0a5d1fb"), null, "User", "USER" },
                    { new Guid("6ff9d5b7-2ea9-4be3-8dd0-36c602da1ddf"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e4cea63-919b-4c63-b222-d335c0a5d1fb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6ff9d5b7-2ea9-4be3-8dd0-36c602da1ddf"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Animals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("e567dd1d-adec-4f77-9a37-8bb6e8ca3282"), null, "User", "USER" },
                    { new Guid("e72c30fa-3ccf-4691-b57a-71ae9965ff74"), null, "Admin", "ADMIN" }
                });
        }
    }
}
