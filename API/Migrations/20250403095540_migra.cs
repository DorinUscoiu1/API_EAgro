using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class migra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FarmerRatings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 16, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "FarmerRatings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Comment", "CreatedAt" },
                values: new object[] { "Excellent produce", new DateTime(2024, 1, 4, 9, 15, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FarmerRatings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 10, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "FarmerRatings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Comment", "CreatedAt" },
                values: new object[] { "Very efficient", new DateTime(2024, 1, 4, 9, 45, 0, 0, DateTimeKind.Utc) });
        }
    }
}
