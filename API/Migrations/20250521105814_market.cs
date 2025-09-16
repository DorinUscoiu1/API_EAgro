using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class market : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerFarmerId",
                table: "MarketItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MarketItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuyerFarmerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MarketItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "BuyerFarmerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MarketItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "BuyerFarmerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MarketItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "BuyerFarmerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_MarketItems_BuyerFarmerId",
                table: "MarketItems",
                column: "BuyerFarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketItems_Farmers_BuyerFarmerId",
                table: "MarketItems",
                column: "BuyerFarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketItems_Farmers_BuyerFarmerId",
                table: "MarketItems");

            migrationBuilder.DropIndex(
                name: "IX_MarketItems_BuyerFarmerId",
                table: "MarketItems");

            migrationBuilder.DropColumn(
                name: "BuyerFarmerId",
                table: "MarketItems");
        }
    }
}
