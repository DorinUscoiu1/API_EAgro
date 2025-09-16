using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class pointsuri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lands",
                columns: new[] { "Id", "Area", "CoordinatesJson", "FarmerId", "Location", "Type" },
                values: new object[] { 7, 25.0, "[{\"lat\":45.7416,\"lng\":25.1282},{\"lat\":45.7418,\"lng\":25.1287},{\"lat\":45.7415,\"lng\":25.1285}]", 9, "Șinca Nouă", "Fâneață" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
