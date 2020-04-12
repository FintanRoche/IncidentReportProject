using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReportForm.Migrations
{
    public partial class ModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "WitnessId",
                table: "Reports",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Witness",
                columns: table => new
                {
                    WitnessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Witness", x => x.WitnessId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_WitnessId",
                table: "Reports",
                column: "WitnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Witness_WitnessId",
                table: "Reports",
                column: "WitnessId",
                principalTable: "Witness",
                principalColumn: "WitnessId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Witness_WitnessId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Witness");

            migrationBuilder.DropIndex(
                name: "IX_Reports_WitnessId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "WitnessId",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "PresentFirstName",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentLastName",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PresentPhone",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
