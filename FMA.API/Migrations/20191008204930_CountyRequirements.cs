using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class CountyRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CapitalId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_NationalityId",
                table: "Countries");

            migrationBuilder.AlterColumn<Guid>(
                name: "NationalityId",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CapitalId",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CapitalId",
                table: "Countries",
                column: "CapitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NationalityId",
                table: "Countries",
                column: "NationalityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CapitalId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_NationalityId",
                table: "Countries");

            migrationBuilder.AlterColumn<Guid>(
                name: "NationalityId",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernorId",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CapitalId",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CapitalId",
                table: "Countries",
                column: "CapitalId",
                unique: true,
                filter: "[CapitalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId",
                unique: true,
                filter: "[CurrencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NationalityId",
                table: "Countries",
                column: "NationalityId",
                unique: true,
                filter: "[NationalityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries",
                column: "GovernorId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
