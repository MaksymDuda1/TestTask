using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inforce.TestTask.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("61f1e15c-c8e4-4eb1-ae4b-1adea33616dd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("630b92c3-da6e-453d-817c-887e303befed"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5d834d42-393a-44ff-a0ae-7e7d7d14e7de"), null, "Admin", "ADMIN" },
                    { new Guid("d61a4d2e-3988-4619-bc8f-96697c3ae042"), null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d834d42-393a-44ff-a0ae-7e7d7d14e7de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d61a4d2e-3988-4619-bc8f-96697c3ae042"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("61f1e15c-c8e4-4eb1-ae4b-1adea33616dd"), null, "Admin", "ADMIN" },
                    { new Guid("630b92c3-da6e-453d-817c-887e303befed"), null, "User", "USER" }
                });
        }
    }
}
