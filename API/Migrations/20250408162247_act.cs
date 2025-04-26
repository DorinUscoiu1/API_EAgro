using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class act : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    SoldAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SellerFarmerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketItems_Farmers_SellerFarmerId",
                        column: x => x.SellerFarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MarketItems",
                columns: new[] { "Id", "IsSold", "ItemId", "ItemType", "Price", "SellerFarmerId", "SoldAt" },
                values: new object[,]
                {
                    { 1, false, 1, "Animal", 1500m, 1, null },
                    { 2, false, 2, "Animal", 300m, 2, null },
                    { 3, false, 1, "Land", 5000m, 1, null },
                    { 4, false, 1, "Supply", 500m, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketItems_SellerFarmerId",
                table: "MarketItems",
                column: "SellerFarmerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketItems");
        }
    }
}
