using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnimalSupplies",
                columns: new[] { "Id", "AnimalId", "Quantity", "SupplyId" },
                values: new object[] { 2, 2, 10, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalSupplies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
