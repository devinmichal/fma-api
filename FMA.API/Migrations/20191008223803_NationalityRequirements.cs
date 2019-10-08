using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class NationalityRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Countries_CountryId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "GovernorId",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Nationalities",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Countries_CountryId",
                table: "Characters",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries",
                column: "CapitalId",
                principalTable: "Capitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Countries_CountryId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Nationalities",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GovernorId",
                table: "Countries",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries",
                column: "GovernorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Countries_CountryId",
                table: "Characters",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Occupations_OccupationId",
                table: "Characters",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries",
                column: "CapitalId",
                principalTable: "Capitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries",
                column: "GovernorId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
