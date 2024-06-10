using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class emptyImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0baf5aa6-abb2-4065-80dd-20867549e5d8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d46097b-82f5-4841-aa94-f67d76fb6ea2"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5db3fa33-1075-4740-802e-51dc00131f71"), null, "User", "USER" },
                    { new Guid("dc5b987c-8106-4d3a-a58d-3bef6474f911"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0baf5aa6-abb2-4065-80dd-20867549e5d8"), null, "Admin", "ADMIN" },
                    { new Guid("5d46097b-82f5-4841-aa94-f67d76fb6ea2"), null, "User", "USER" }
                });
        }
    }
}
