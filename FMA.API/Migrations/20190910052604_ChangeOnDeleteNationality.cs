using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class ChangeOnDeleteNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
