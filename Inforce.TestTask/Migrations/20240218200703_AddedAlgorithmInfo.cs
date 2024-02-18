using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inforce.TestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddedAlgorithmInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6541d686-afe8-459a-b623-6450d5075891"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9d0fc063-6e5d-4348-a421-f608a6ac0dab"));

            migrationBuilder.CreateTable(
                name: "AlgorithmModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Stage1 = table.Column<string>(type: "text", nullable: true),
                    Stage2 = table.Column<string>(type: "text", nullable: true),
                    Stage3 = table.Column<string>(type: "text", nullable: true),
                    Stage4 = table.Column<string>(type: "text", nullable: true),
                    Stage5 = table.Column<string>(type: "text", nullable: true),
                    Stage6 = table.Column<string>(type: "text", nullable: true),
                    Stage7 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgorithmModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AlgorithmModels",
                columns: new[] { "Id", "Stage1", "Stage2", "Stage3", "Stage4", "Stage5", "Stage6", "Stage7" },
                values: new object[] { new Guid("eac5ba03-6e4f-498d-b59c-b76d3d55230c"), "Take the user's url", "Check if he entered the code that will replace the url or if it needs to be generated randomly (the code must be unique)", "Add the url to the database", "Wait for the necessary get request", "Take the code from this request", "Take the corresponding record with the corresponding code in the database", "Redirect the user to the original request" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("42f35fda-48a0-469a-bb97-2d4c4e69f28f"), null, "User", "USER" },
                    { new Guid("ca24ea62-8333-48d2-a028-e63bbc194073"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgorithmModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42f35fda-48a0-469a-bb97-2d4c4e69f28f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca24ea62-8333-48d2-a028-e63bbc194073"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6541d686-afe8-459a-b623-6450d5075891"), null, "User", "USER" },
                    { new Guid("9d0fc063-6e5d-4348-a421-f608a6ac0dab"), null, "Admin", "ADMIN" }
                });
        }
    }
}
