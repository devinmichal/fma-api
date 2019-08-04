using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class changeToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Nationalities_Countries_CountryId",
                table: "Nationalities");

            migrationBuilder.DropIndex(
                name: "IX_Nationalities_CountryId",
                table: "Nationalities");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CapitalId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Nationalities");

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernorId",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(Guid),
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

            migrationBuilder.AddColumn<Guid>(
                name: "NationalityId",
                table: "Countries",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      
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
                name: "IX_Countries_GovernorId",
                table: "Countries",
                column: "GovernorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NationalityId",
                table: "Countries",
                column: "NationalityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries",
                column: "CapitalId",
                principalTable: "Capitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Nationalities_NationalityId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CapitalId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_NationalityId",
                table: "Countries");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("b8be8110-3841-4064-b0a5-b8987bf8c3b2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63891193-dce2-41ee-bdb0-6cfaf69b6d27"));

            migrationBuilder.DeleteData(
                table: "Capitals",
                keyColumn: "Id",
                keyValue: new Guid("4c793930-8632-48ad-9850-499f74de0853"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("f268e74c-1840-4835-ae3e-47e6915099ae"));

            migrationBuilder.DeleteData(
                table: "Nationalities",
                keyColumn: "Id",
                keyValue: new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("99216871-834b-4108-9bfc-86e7bc1f5a50"));

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Countries");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Nationalities",
                nullable: true);

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
                name: "IX_Nationalities_CountryId",
                table: "Nationalities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CapitalId",
                table: "Countries",
                column: "CapitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries",
                column: "GovernorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Capitals_CapitalId",
                table: "Countries",
                column: "CapitalId",
                principalTable: "Capitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Nationalities_Countries_CountryId",
                table: "Nationalities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
