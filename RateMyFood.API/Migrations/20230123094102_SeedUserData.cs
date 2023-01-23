using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RateMyFood.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"), "emma@provider.com", "Emma", "Flagg", "password", "General", "emma" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "jitesh@provider.com", "Jitesh", "Sureka", "password", "Admin", "jsureka" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "david@provider.com", "David", "Reigns", "password", "General", "david" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));
        }
    }
}
