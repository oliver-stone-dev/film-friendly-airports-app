using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace film_friendly_airports_app.Migrations
{
    /// <inheritdoc />
    public partial class reports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_AspNetUsers_AccountId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_ReportType_TypeId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Terminals_TerminalId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportType",
                table: "ReportType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "ReportType",
                newName: "ReportTypes");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameIndex(
                name: "IX_Report_TypeId",
                table: "Reports",
                newName: "IX_Reports_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_TerminalId",
                table: "Reports",
                newName: "IX_Reports_TerminalId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_AccountId",
                table: "Reports",
                newName: "IX_Reports_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportTypes",
                table: "ReportTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_AccountId",
                table: "Reports",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportTypes_TypeId",
                table: "Reports",
                column: "TypeId",
                principalTable: "ReportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Terminals_TerminalId",
                table: "Reports",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_AccountId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportTypes_TypeId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Terminals_TerminalId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportTypes",
                table: "ReportTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "ReportTypes",
                newName: "ReportType");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_TypeId",
                table: "Report",
                newName: "IX_Report_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_TerminalId",
                table: "Report",
                newName: "IX_Report_TerminalId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_AccountId",
                table: "Report",
                newName: "IX_Report_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportType",
                table: "ReportType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_AspNetUsers_AccountId",
                table: "Report",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_ReportType_TypeId",
                table: "Report",
                column: "TypeId",
                principalTable: "ReportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Terminals_TerminalId",
                table: "Report",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
