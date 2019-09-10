using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class ChangeToCountrySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries",
                column: "CapitalId",
                principalTable: "Capitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries",
                column: "CapitalId",
                principalTable: "Capitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
