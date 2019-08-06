using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class DropAffiliationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAffiliation");

            migrationBuilder.DropTable(
                name: "Affiliations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affiliations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAffiliation",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(nullable: false),
                    AffiliationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAffiliation", x => new { x.MemberId, x.AffiliationId });
                    table.ForeignKey(
                        name: "FK_CharacterAffiliation_Affiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Affiliations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAffiliation_Characters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAffiliation_AffiliationId",
                table: "CharacterAffiliation",
                column: "AffiliationId");
        }
    }
}
