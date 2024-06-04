using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shelter.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62618197-b677-4d02-8cf2-5544b477a03f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a07b034f-cc90-4747-bce4-0490fa99dbd5"));

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
                    { new Guid("3aadd642-600f-45f5-b90c-9a6a870d5c9b"), null, "Admin", "ADMIN" },
                    { new Guid("794db7da-574d-43b1-a0da-018152cdad3f"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3aadd642-600f-45f5-b90c-9a6a870d5c9b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("794db7da-574d-43b1-a0da-018152cdad3f"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Animals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("62618197-b677-4d02-8cf2-5544b477a03f"), null, "User", "USER" },
                    { new Guid("a07b034f-cc90-4747-bce4-0490fa99dbd5"), null, "Admin", "ADMIN" }
                });
        }
    }
}
