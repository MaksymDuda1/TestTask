using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inforce.TestTask.Migrations
{
    /// <inheritdoc />
    public partial class AfterDropMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b68bbe0-2c18-4f3e-b4f1-94f5b4254f50"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a88628bd-3dac-4aaa-9aa7-057c2c11ff3d"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ShortenerUrls",
                type: "character varying(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4229b059-98f2-4de4-b6a5-c110aa0ce3b2"), null, "User", "USER" },
                    { new Guid("600bbe73-858c-48f4-9d0e-7be5a4f5b5e9"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4229b059-98f2-4de4-b6a5-c110aa0ce3b2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("600bbe73-858c-48f4-9d0e-7be5a4f5b5e9"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ShortenerUrls",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(7)",
                oldMaxLength: 7);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5b68bbe0-2c18-4f3e-b4f1-94f5b4254f50"), null, "User", "USER" },
                    { new Guid("a88628bd-3dac-4aaa-9aa7-057c2c11ff3d"), null, "Admin", "ADMIN" }
                });
        }
    }
}
