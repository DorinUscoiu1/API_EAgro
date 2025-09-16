using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class points : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoordinatesJson",
                table: "Lands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoordinatesJson",
                value: "[{\"lat\":45.7401,\"lng\":25.0659},{\"lat\":45.7402,\"lng\":25.0663},{\"lat\":45.7403,\"lng\":25.0660}]");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoordinatesJson",
                value: "[{\"lat\":45.7410,\"lng\":25.0671},{\"lat\":45.7412,\"lng\":25.0675},{\"lat\":45.7411,\"lng\":25.0672}]");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoordinatesJson",
                value: "[{\"lat\":45.7425,\"lng\":25.0680},{\"lat\":45.7427,\"lng\":25.0683},{\"lat\":45.7426,\"lng\":25.0681}]");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CoordinatesJson",
                value: "[{\"lat\":45.7430,\"lng\":25.0690},{\"lat\":45.7432,\"lng\":25.0695},{\"lat\":45.7431,\"lng\":25.0692}]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinatesJson",
                table: "Lands");
        }
    }
}
