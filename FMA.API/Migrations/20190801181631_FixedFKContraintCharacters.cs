using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class FixedFKContraintCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_GovernorId",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernorId",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Characters",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries",
                column: "GovernorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CountryId",
                table: "Characters",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Countries_CountryId",
                table: "Characters",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries",
                column: "GovernorId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Countries_CountryId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CountryId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Characters");

            migrationBuilder.AlterColumn<Guid>(
                name: "GovernorId",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Capitals",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("4c793930-8632-48ad-9850-499f74de0853"), "Central City is the official capital and also the seat of government in Amestris. The National Central Library, Central Command, the 5 National Laboratories, and Amestris' Parliament are all located in Central. Aside from its symbol as a military headquarters, Central is also a bustling metropolis and arguably Amestris' largest city, complete with nearly everything Amestrian society has to offer as well as a lasting and rarely disturbed sense of peace created by its proximity to the government's imposing presence. After the events in the eastern regions of Amestris and the Elrics' excursion to the southern region, much of the Fullmetal Alchemist story takes place in Central, as it also serves as the Homunculi's home base, the heart of which is located deep beneath Central Command Headquarters", "Central City" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("f268e74c-1840-4835-ae3e-47e6915099ae"), "The Cens is the standard unit of currency in Amestris and is available in both paper bills and varied metal coins. It can be inferred that the paper bills are worth more, similar to many real-life currencies. It is equal to about one Japanese Yen in the real world.", "Cenz" });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"), "Amestrian" });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "Decsription", "Name" },
                values: new object[] { new Guid("99216871-834b-4108-9bfc-86e7bc1f5a50"), "A State Alchemist is an alchemist employed by the Amestrian State Military as part of an elite government mandated program.", "State Alchemist" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Abilities", "Age", "FirstName", "Goal", "LastName", "NationalityId", "OccupationId", "Rank", "Weapon" },
                values: new object[] { new Guid("b8be8110-3841-4064-b0a5-b8987bf8c3b2"), "Flame-Based Alchemy", 29, "Roy", "Becoming Fuhrer", "Mustang", new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"), new Guid("99216871-834b-4108-9bfc-86e7bc1f5a50"), "Lieutenant Colonel", "Ignition Cloth Gloves" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CapitalId", "CurrencyId", "Founded", "Government", "GovernorId", "Name", "NationalityId", "Population" },
                values: new object[] { new Guid("63891193-dce2-41ee-bdb0-6cfaf69b6d27"), new Guid("4c793930-8632-48ad-9850-499f74de0853"), new Guid("f268e74c-1840-4835-ae3e-47e6915099ae"), 0, null, new Guid("00000000-0000-0000-0000-000000000000"), "Amestris", new Guid("900f6350-82c5-4e5d-aff3-1b74adf3612d"), 50000000 });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GovernorId",
                table: "Countries",
                column: "GovernorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Characters_GovernorId",
                table: "Countries",
                column: "GovernorId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
