using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReportForm.Migrations
{
    public partial class changedReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Secondary_SecondaryPin",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Third_ThirdPin",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Secondary");

            migrationBuilder.DropTable(
                name: "Third");

            migrationBuilder.DropIndex(
                name: "IX_Reports_SecondaryPin",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ThirdPin",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Abuse",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CentreName",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CostCentre",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IncidentRoom",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ManagementUnit",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PRNBool",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PRN_Medication",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PersonPresent",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "SecondaryPin",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ThirdPin",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PRMP",
                table: "LineManager");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentFirstName",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentLastName",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PresentPhone",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Reports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Principal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "nextOfKin",
                table: "Principal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PresentFirstName",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PresentLastName",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PresentPhone",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Principal");

            migrationBuilder.DropColumn(
                name: "nextOfKin",
                table: "Principal");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "Abuse",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CentreName",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostCentre",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentRoom",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagementUnit",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PRNBool",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PRN_Medication",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonPresent",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryPin",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdPin",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PRMP",
                table: "LineManager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Secondary",
                columns: table => new
                {
                    Pin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secondary", x => x.Pin);
                });

            migrationBuilder.CreateTable(
                name: "Third",
                columns: table => new
                {
                    Pin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Third", x => x.Pin);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_SecondaryPin",
                table: "Reports",
                column: "SecondaryPin");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ThirdPin",
                table: "Reports",
                column: "ThirdPin");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Secondary_SecondaryPin",
                table: "Reports",
                column: "SecondaryPin",
                principalTable: "Secondary",
                principalColumn: "Pin",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Third_ThirdPin",
                table: "Reports",
                column: "ThirdPin",
                principalTable: "Third",
                principalColumn: "Pin",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
