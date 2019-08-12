using Microsoft.EntityFrameworkCore.Migrations;

namespace FMA.API.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCharacter_Characters_FamilyMember2Id",
                table: "CharacterCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterCharacter_Characters_Id2",
                table: "CharacterCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterCharacter",
                table: "CharacterCharacter");

            migrationBuilder.RenameTable(
                name: "CharacterCharacter",
                newName: "FamilyMembers");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCharacter_Id2",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_Id2");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterCharacter_FamilyMember2Id",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_FamilyMember2Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers",
                columns: new[] { "Id", "Id2" });

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Characters_FamilyMember2Id",
                table: "FamilyMembers",
                column: "FamilyMember2Id",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Characters_Id2",
                table: "FamilyMembers",
                column: "Id2",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Characters_FamilyMember2Id",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Characters_Id2",
                table: "FamilyMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers");

            migrationBuilder.RenameTable(
                name: "FamilyMembers",
                newName: "CharacterCharacter");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_Id2",
                table: "CharacterCharacter",
                newName: "IX_CharacterCharacter_Id2");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_FamilyMember2Id",
                table: "CharacterCharacter",
                newName: "IX_CharacterCharacter_FamilyMember2Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterCharacter",
                table: "CharacterCharacter",
                columns: new[] { "Id", "Id2" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCharacter_Characters_FamilyMember2Id",
                table: "CharacterCharacter",
                column: "FamilyMember2Id",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterCharacter_Characters_Id2",
                table: "CharacterCharacter",
                column: "Id2",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
