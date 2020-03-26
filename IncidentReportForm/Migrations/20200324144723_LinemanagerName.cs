using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReportForm.Migrations
{
    public partial class LinemanagerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContributingFactors",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Manageabillity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Solutions",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "LineManager",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "LineManager",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "LineManager");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "LineManager");

            migrationBuilder.AddColumn<string>(
                name: "ContributingFactors",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manageabillity",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Solutions",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
