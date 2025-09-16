using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FarmerRatings",
                columns: new[] { "Id", "Comment", "CreatedAt", "FarmerId", "Rating" },
                values: new object[] { 5, "Excellent produce", new DateTime(2024, 1, 4, 9, 15, 0, 0, DateTimeKind.Utc), 9, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FarmerRatings",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
