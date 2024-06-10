using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class news : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5db3fa33-1075-4740-802e-51dc00131f71"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc5b987c-8106-4d3a-a58d-3bef6474f911"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("78ea2e80-a5ac-479c-856f-7ad5110a9821"), null, "User", "USER" },
                    { new Guid("805e0d9a-a300-4438-aecd-40ca16fa97ba"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("78ea2e80-a5ac-479c-856f-7ad5110a9821"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("805e0d9a-a300-4438-aecd-40ca16fa97ba"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5db3fa33-1075-4740-802e-51dc00131f71"), null, "User", "USER" },
                    { new Guid("dc5b987c-8106-4d3a-a58d-3bef6474f911"), null, "Admin", "ADMIN" }
                });
        }
    }
}
