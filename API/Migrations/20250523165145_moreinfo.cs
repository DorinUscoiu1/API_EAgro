using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class moreinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "County", "Location", "Name" },
                values: new object[,]
                {
                    { 13, "Brasov", "Brașov", "Centrul Județean Brașov" },
                    { 14, "Brasov", "Poiana Mărului", "Centrul Local Poiana Mărului" },
                    { 15, "Brasov", "Șercaia", "Centrul Local Șercaia" },
                    { 16, "Brasov", "Făgăraș", "Centrul Local Făgăraș" },
                    { 17, "Brasov", "Codlea", "Centrul Local Codlea" },
                    { 18, "Brasov", "Predeal", "Centrul Local Predeal" },
                    { 19, "Brasov", "Rupea", "Centrul Local Rupea" },
                    { 20, "Brasov", "Zărnești", "Centrul Local Zărnești" },
                    { 21, "Brasov", "Victoria", "Centrul Local Victoria" },
                    { 22, "Brasov", "Râșnov", "Centrul Local Râșnov" },
                    { 23, "Brasov", "Săcele", "Centrul Local Săcele" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "County", "Location", "Name" },
                values: new object[,]
                {
                    { 6, "Brasov", "Fagaras", "Centrul Local Fagaras" },
                    { 7, "Brasov", "Codlea", "Centrul Local Codlea" }
                });
        }
    }
}
