using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inforce.TestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c20da32-a571-4ad0-9a29-14ee2bb165e2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e6d2254-5b15-466d-97f2-b648cdf54deb"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ShortenerUrls",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("97bd1d0b-485c-4e55-bc44-ca773d9ed63b"), null, "User", "USER" },
                    { new Guid("b0d1c225-39d2-4811-bcd3-d4a4218b4f8c"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortenerUrls_UserId",
                table: "ShortenerUrls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortenerUrls_AspNetUsers_UserId",
                table: "ShortenerUrls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortenerUrls_AspNetUsers_UserId",
                table: "ShortenerUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortenerUrls_UserId",
                table: "ShortenerUrls");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97bd1d0b-485c-4e55-bc44-ca773d9ed63b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0d1c225-39d2-4811-bcd3-d4a4218b4f8c"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShortenerUrls");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0c20da32-a571-4ad0-9a29-14ee2bb165e2"), null, "User", "USER" },
                    { new Guid("0e6d2254-5b15-466d-97f2-b648cdf54deb"), null, "Admin", "ADMIN" }
                });
        }
    }
}
