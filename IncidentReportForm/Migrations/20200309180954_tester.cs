using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReportForm.Migrations
{
    public partial class tester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "complete",
                table: "Reports",
                newName: "Complete");

            migrationBuilder.AddColumn<int>(
                name: "LineManagerId",
                table: "Reports",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LineManager",
                columns: table => new
                {
                    LineManagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notified = table.Column<string>(nullable: true),
                    Responses = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Debriefing = table.Column<string>(nullable: true),
                    PRMP = table.Column<bool>(nullable: false),
                    Abuse = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineManager", x => x.LineManagerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_LineManagerId",
                table: "Reports",
                column: "LineManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_LineManager_LineManagerId",
                table: "Reports",
                column: "LineManagerId",
                principalTable: "LineManager",
                principalColumn: "LineManagerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_LineManager_LineManagerId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "LineManager");

            migrationBuilder.DropIndex(
                name: "IX_Reports_LineManagerId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "LineManagerId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "Complete",
                table: "Reports",
                newName: "complete");
        }
    }
}
