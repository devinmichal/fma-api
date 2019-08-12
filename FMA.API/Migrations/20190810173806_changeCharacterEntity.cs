using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class changeCharacterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterCharacter",
                columns: table => new
                {
                    Id2 = table.Column<Guid>(nullable: false),
                    FamilyMember2Id = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCharacter", x => new { x.Id, x.Id2 });
                    table.ForeignKey(
                        name: "FK_CharacterCharacter_Characters_FamilyMember2Id",
                        column: x => x.FamilyMember2Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterCharacter_Characters_Id2",
                        column: x => x.Id2,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCharacter_FamilyMember2Id",
                table: "CharacterCharacter",
                column: "FamilyMember2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCharacter_Id2",
                table: "CharacterCharacter",
                column: "Id2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterCharacter");
        }
    }
}
