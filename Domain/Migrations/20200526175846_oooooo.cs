using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class oooooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BakrDebit",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BakrPortion",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ListDate",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "ListOfCalculations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YomeDebit",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YomePortion",
                table: "ListOfCalculations",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BakrDebit",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "BakrPortion",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "ListDate",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "YomeDebit",
                table: "ListOfCalculations");

            migrationBuilder.DropColumn(
                name: "YomePortion",
                table: "ListOfCalculations");
        }
    }
}
