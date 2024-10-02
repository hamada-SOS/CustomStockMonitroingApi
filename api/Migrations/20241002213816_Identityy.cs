using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Identityy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "899cf1b0-aae4-4cef-a22d-595776b22553");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de406997-f65c-49fb-b3c9-cce7b2548864");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b6a4f92e-e899-41d9-995b-06d951da3161", null, "Admin", "ADMIN" },
                    { "f40684fe-f203-4cd8-a6d5-484bed3f8903", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6a4f92e-e899-41d9-995b-06d951da3161");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f40684fe-f203-4cd8-a6d5-484bed3f8903");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "899cf1b0-aae4-4cef-a22d-595776b22553", null, "User", "USER" },
                    { "de406997-f65c-49fb-b3c9-cce7b2548864", null, "Admin", "ADMIN" }
                });
        }
    }
}
