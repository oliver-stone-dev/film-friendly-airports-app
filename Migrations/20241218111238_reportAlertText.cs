using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace film_friendly_airports_app.Migrations
{
    /// <inheritdoc />
    public partial class reportAlertText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlertText",
                table: "ReportTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertText",
                table: "ReportTypes");
        }
    }
}
