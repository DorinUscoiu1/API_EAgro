using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class pyamentrequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LandFundingRequestId",
                table: "Lands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LandFundingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandFundingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandFundingRequests_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 1,
                column: "LandFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 2,
                column: "LandFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 3,
                column: "LandFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 4,
                column: "LandFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 7,
                column: "LandFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 8,
                column: "LandFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 9,
                column: "LandFundingRequestId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Lands_LandFundingRequestId",
                table: "Lands",
                column: "LandFundingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LandFundingRequests_FarmerId",
                table: "LandFundingRequests",
                column: "FarmerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lands_LandFundingRequests_LandFundingRequestId",
                table: "Lands",
                column: "LandFundingRequestId",
                principalTable: "LandFundingRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lands_LandFundingRequests_LandFundingRequestId",
                table: "Lands");

            migrationBuilder.DropTable(
                name: "LandFundingRequests");

            migrationBuilder.DropIndex(
                name: "IX_Lands_LandFundingRequestId",
                table: "Lands");

            migrationBuilder.DropColumn(
                name: "LandFundingRequestId",
                table: "Lands");
        }
    }
}
