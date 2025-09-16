using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class county : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Lands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 1,
                column: "County",
                value: "Brasov");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 2,
                column: "County",
                value: "Brasov");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 3,
                column: "County",
                value: "Brasov");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 4,
                column: "County",
                value: "Brasov");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 7,
                column: "County",
                value: "Brasov");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 8,
                column: "County",
                value: "Brasov");

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 9,
                column: "County",
                value: "Brasov");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "Lands");
        }
    }
}
