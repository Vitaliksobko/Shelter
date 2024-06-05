using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3aadd642-600f-45f5-b90c-9a6a870d5c9b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("794db7da-574d-43b1-a0da-018152cdad3f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("632c5f3f-6541-4b40-9d2e-61b0032e76fb"), null, "Admin", "ADMIN" },
                    { new Guid("d05ba290-218e-4c49-8046-ef8878d47d44"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("632c5f3f-6541-4b40-9d2e-61b0032e76fb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d05ba290-218e-4c49-8046-ef8878d47d44"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3aadd642-600f-45f5-b90c-9a6a870d5c9b"), null, "Admin", "ADMIN" },
                    { new Guid("794db7da-574d-43b1-a0da-018152cdad3f"), null, "User", "USER" }
                });
        }
    }
}
