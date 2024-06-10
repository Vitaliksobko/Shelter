using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6d366d9-21ce-446f-b895-7d9e5ed5b435"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4b3a25d-902e-4b0f-883c-5459d53c9059"));

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Animals");

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
                    { new Guid("0baf5aa6-abb2-4065-80dd-20867549e5d8"), null, "Admin", "ADMIN" },
                    { new Guid("5d46097b-82f5-4841-aa94-f67d76fb6ea2"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0baf5aa6-abb2-4065-80dd-20867549e5d8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d46097b-82f5-4841-aa94-f67d76fb6ea2"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Animals");

            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "Animals",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a6d366d9-21ce-446f-b895-7d9e5ed5b435"), null, "Admin", "ADMIN" },
                    { new Guid("f4b3a25d-902e-4b0f-883c-5459d53c9059"), null, "User", "USER" }
                });
        }
    }
}
