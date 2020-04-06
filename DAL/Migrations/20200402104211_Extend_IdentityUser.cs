using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Extend_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "Opmerking",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Opmerking",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "Batterij",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Batterij",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktief",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XjoGebruikerCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opmerking_UserId",
                table: "Opmerking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Batterij_UserId",
                table: "Batterij",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batterij_AspNetUsers_UserId",
                table: "Batterij",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opmerking_AspNetUsers_UserId",
                table: "Opmerking",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batterij_AspNetUsers_UserId",
                table: "Batterij");

            migrationBuilder.DropForeignKey(
                name: "FK_Opmerking_AspNetUsers_UserId",
                table: "Opmerking");

            migrationBuilder.DropIndex(
                name: "IX_Opmerking_UserId",
                table: "Opmerking");

            migrationBuilder.DropIndex(
                name: "IX_Batterij_UserId",
                table: "Batterij");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Opmerking");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Batterij");

            migrationBuilder.DropColumn(
                name: "Aktief",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "XjoGebruikerCode",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "Opmerking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GebruikerId",
                table: "Batterij",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
