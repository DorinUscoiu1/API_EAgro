using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class optionalSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketItems_Farmers_BuyerFarmerId",
                table: "MarketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketItems_Farmers_SellerFarmerId",
                table: "MarketItems");

            migrationBuilder.AlterColumn<int>(
                name: "SellerFarmerId",
                table: "MarketItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketItems_Farmers_BuyerFarmerId",
                table: "MarketItems",
                column: "BuyerFarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketItems_Farmers_SellerFarmerId",
                table: "MarketItems",
                column: "SellerFarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketItems_Farmers_BuyerFarmerId",
                table: "MarketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketItems_Farmers_SellerFarmerId",
                table: "MarketItems");

            migrationBuilder.AlterColumn<int>(
                name: "SellerFarmerId",
                table: "MarketItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketItems_Farmers_BuyerFarmerId",
                table: "MarketItems",
                column: "BuyerFarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketItems_Farmers_SellerFarmerId",
                table: "MarketItems",
                column: "SellerFarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
