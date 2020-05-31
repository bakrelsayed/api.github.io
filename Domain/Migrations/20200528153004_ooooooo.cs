using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ooooooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BakrCredit",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MainTableId",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "YomeCredit",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "MainTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderColor = table.Column<string>(nullable: true),
                    DataColor = table.Column<string>(nullable: true),
                    CellColor = table.Column<string>(nullable: true),
                    FooterColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCalculations_MainTableId",
                table: "ListOfCalculations",
                column: "MainTableId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCalculations_MainTable_MainTableId",
                table: "ListOfCalculations",
                column: "MainTableId",
                principalTable: "MainTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCalculations_MainTable_MainTableId",
                table: "ListOfCalculations");

            migrationBuilder.DropTable(
                name: "MainTable");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCalculations_MainTableId",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "BakrCredit",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "MainTableId",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "YomeCredit",
                table: "ListOfCalculations");
        }
    }
}
