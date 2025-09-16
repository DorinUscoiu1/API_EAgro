using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class msdfgsdfgasdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FarmerSupplies",
                columns: new[] { "Id", "FarmerId", "Quantity", "SupplyId" },
                values: new object[] { 3, 9, 20, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FarmerSupplies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
