using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReportForm.Migrations
{
    public partial class modelChange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectedIncidentDetails",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ManagerEmail",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "Reports",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Reports",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentType",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IncidentLocation",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Reports",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reports",
                newName: "date");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentType",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IncidentLocation",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ConnectedIncidentDetails",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerEmail",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
