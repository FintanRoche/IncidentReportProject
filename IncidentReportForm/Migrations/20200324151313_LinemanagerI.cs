using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReportForm.Migrations
{
    public partial class LinemanagerI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Principal_PrincipalPin",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PrincipalPin",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Principal",
                table: "Principal");

            migrationBuilder.DropColumn(
                name: "PrincipalPin",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Principal");

            migrationBuilder.AddColumn<int>(
                name: "PrincipalId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrincipalId",
                table: "Principal",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Principal",
                table: "Principal",
                column: "PrincipalId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Principal_PrincipalId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PrincipalId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Principal",
                table: "Principal");

            migrationBuilder.DropColumn(
                name: "PrincipalId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PrincipalId",
                table: "Principal");

            migrationBuilder.AddColumn<string>(
                name: "PrincipalPin",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Principal",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Principal",
                table: "Principal",
                column: "Pin");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PrincipalPin",
                table: "Reports",
                column: "PrincipalPin");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Principal_PrincipalPin",
                table: "Reports",
                column: "PrincipalPin",
                principalTable: "Principal",
                principalColumn: "Pin",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
