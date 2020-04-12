using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReportForm.Migrations
{
    public partial class Subject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Principal_PrincipalId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Principal");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PrincipalId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PrincipalId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Abuse",
                table: "LineManager");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "LineManager");

            migrationBuilder.DropColumn(
                name: "Debriefing",
                table: "LineManager");

            migrationBuilder.DropColumn(
                name: "Notified",
                table: "LineManager");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "LineManager");

            migrationBuilder.DropColumn(
                name: "Responses",
                table: "LineManager");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notified",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responses",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Reports",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SubjectType = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    NextOfKin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_SubjectId",
                table: "Reports",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Subject_SubjectId",
                table: "Reports",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Subject_SubjectId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Reports_SubjectId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Notified",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Responses",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PrincipalId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Abuse",
                table: "LineManager",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "LineManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Debriefing",
                table: "LineManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notified",
                table: "LineManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "LineManager",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Responses",
                table: "LineManager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Principal",
                columns: table => new
                {
                    PrincipalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nextOfKin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principal", x => x.PrincipalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PrincipalId",
                table: "Reports",
                column: "PrincipalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Principal_PrincipalId",
                table: "Reports",
                column: "PrincipalId",
                principalTable: "Principal",
                principalColumn: "PrincipalId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
