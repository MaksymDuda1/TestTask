using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inforce.TestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserLinkRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("6541d686-afe8-459a-b623-6450d5075891"), null, "User", "USER" },
                    { new Guid("9d0fc063-6e5d-4348-a421-f608a6ac0dab"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6541d686-afe8-459a-b623-6450d5075891"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9d0fc063-6e5d-4348-a421-f608a6ac0dab"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("577f9e2a-3a04-4766-b574-a95d55e03d78"), null, "User", "USER" },
                    { new Guid("9c28d4a5-babc-4eee-8d41-9c2988b83a3d"), null, "Admin", "ADMIN" }
                });
        }
    }
}
