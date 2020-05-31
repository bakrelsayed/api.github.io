using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_ListOfCalculations_MainTable_MainTableId",
               table: "ListOfCalculations");
            migrationBuilder.DropIndex(
               name: "IX_ListOfCalculations_MainTableId",
               table: "ListOfCalculations");

            migrationBuilder.CreateIndex(
              name: "IX_ListOfCalculations_MainTableId",
              table: "ListOfCalculations",
              column: "MainTableId",
              unique: false);

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

        }
    }
}
