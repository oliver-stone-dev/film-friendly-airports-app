using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace film_friendly_airports_app.Migrations
{
    /// <inheritdoc />
    public partial class ModelCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Terminals_AirportId",
                table: "Terminals",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TerminalId",
                table: "Reviews",
                column: "TerminalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Terminals_TerminalId",
                table: "Reviews",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Terminals_Airports_AirportId",
                table: "Terminals",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Terminals_TerminalId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminals_Airports_AirportId",
                table: "Terminals");

            migrationBuilder.DropIndex(
                name: "IX_Terminals_AirportId",
                table: "Terminals");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TerminalId",
                table: "Reviews");
        }
    }
}
