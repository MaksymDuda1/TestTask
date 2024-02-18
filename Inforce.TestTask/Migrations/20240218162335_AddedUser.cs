using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inforce.TestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97bd1d0b-485c-4e55-bc44-ca773d9ed63b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0d1c225-39d2-4811-bcd3-d4a4218b4f8c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("577f9e2a-3a04-4766-b574-a95d55e03d78"), null, "User", "USER" },
                    { new Guid("9c28d4a5-babc-4eee-8d41-9c2988b83a3d"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("577f9e2a-3a04-4766-b574-a95d55e03d78"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c28d4a5-babc-4eee-8d41-9c2988b83a3d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("97bd1d0b-485c-4e55-bc44-ca773d9ed63b"), null, "User", "USER" },
                    { new Guid("b0d1c225-39d2-4811-bcd3-d4a4218b4f8c"), null, "Admin", "ADMIN" }
                });
        }
    }
}
