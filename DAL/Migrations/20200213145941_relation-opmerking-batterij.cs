using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class relationopmerkingbatterij : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opmerking_Installatie_InstallatieID",
                table: "Opmerking");

            migrationBuilder.DropIndex(
                name: "IX_Opmerking_InstallatieID",
                table: "Opmerking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batterij",
                table: "Batterij");

            migrationBuilder.DropColumn(
                name: "InstallatieID",
                table: "Opmerking");

            migrationBuilder.DropColumn(
                name: "BatterijID",
                table: "Batterij");

            migrationBuilder.AddColumn<int>(
                name: "BatterijID",
                table: "Opmerking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Batterij",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batterij",
                table: "Batterij",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Opmerking_BatterijID",
                table: "Opmerking",
                column: "BatterijID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opmerking_Batterij_BatterijID",
                table: "Opmerking",
                column: "BatterijID",
                principalTable: "Batterij",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opmerking_Batterij_BatterijID",
                table: "Opmerking");

            migrationBuilder.DropIndex(
                name: "IX_Opmerking_BatterijID",
                table: "Opmerking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batterij",
                table: "Batterij");

            migrationBuilder.DropColumn(
                name: "BatterijID",
                table: "Opmerking");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Batterij");

            migrationBuilder.AddColumn<int>(
                name: "InstallatieID",
                table: "Opmerking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BatterijID",
                table: "Batterij",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batterij",
                table: "Batterij",
                column: "BatterijID");

            migrationBuilder.CreateIndex(
                name: "IX_Opmerking_InstallatieID",
                table: "Opmerking",
                column: "InstallatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opmerking_Installatie_InstallatieID",
                table: "Opmerking",
                column: "InstallatieID",
                principalTable: "Installatie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
