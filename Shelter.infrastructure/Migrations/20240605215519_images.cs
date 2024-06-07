using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41a2d739-3f09-498d-9989-8b07e1a73069"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9974388e-e1f7-4d52-9c49-0c36e5343810"));

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
                    { new Guid("e567dd1d-adec-4f77-9a37-8bb6e8ca3282"), null, "User", "USER" },
                    { new Guid("e72c30fa-3ccf-4691-b57a-71ae9965ff74"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Images",
                table: "Animals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("41a2d739-3f09-498d-9989-8b07e1a73069"), null, "User", "USER" },
                    { new Guid("9974388e-e1f7-4d52-9c49-0c36e5343810"), null, "Admin", "ADMIN" }
                });
        }
    }
}
