using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class ChangeOnDeleteOccupation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
