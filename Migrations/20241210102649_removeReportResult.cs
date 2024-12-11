using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace film_friendly_airports_app.Migrations
{
    /// <inheritdoc />
    public partial class removeReportResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Reports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Result",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
