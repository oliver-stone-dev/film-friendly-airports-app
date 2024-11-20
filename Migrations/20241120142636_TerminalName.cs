using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace film_friendly_airports_app.Migrations
{
    /// <inheritdoc />
    public partial class TerminalName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Terminals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Terminals");
        }
    }
}
