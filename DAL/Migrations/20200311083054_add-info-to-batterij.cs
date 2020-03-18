using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addinfotobatterij : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruiker_GebruikerType_GebruikerTypeID",
                table: "Gebruiker");

            migrationBuilder.DropForeignKey(
                name: "FK_Installatie_InstallatieType_InstallatieTypeID",
                table: "Installatie");

            migrationBuilder.DropForeignKey(
                name: "FK_Installatie_Leveradres_LeveradresID",
                table: "Installatie");

            migrationBuilder.DropForeignKey(
                name: "FK_Opmerking_Batterij_BatterijID",
                table: "Opmerking");

            migrationBuilder.DropForeignKey(
                name: "FK_Opmerking_Gebruiker_GebruikerID",
                table: "Opmerking");

            migrationBuilder.RenameColumn(
                name: "GebruikerID",
                table: "Opmerking",
                newName: "GebruikerId");

            migrationBuilder.RenameColumn(
                name: "BatterijID",
                table: "Opmerking",
                newName: "BatterijId");

            migrationBuilder.RenameIndex(
                name: "IX_Opmerking_GebruikerID",
                table: "Opmerking",
                newName: "IX_Opmerking_GebruikerId");

            migrationBuilder.RenameIndex(
                name: "IX_Opmerking_BatterijID",
                table: "Opmerking",
                newName: "IX_Opmerking_BatterijId");

            migrationBuilder.RenameColumn(
                name: "LeveradresID",
                table: "Installatie",
                newName: "LeveradresId");

            migrationBuilder.RenameColumn(
                name: "InstallatieTypeID",
                table: "Installatie",
                newName: "InstallatieTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Installatie_LeveradresID",
                table: "Installatie",
                newName: "IX_Installatie_LeveradresId");

            migrationBuilder.RenameIndex(
                name: "IX_Installatie_InstallatieTypeID",
                table: "Installatie",
                newName: "IX_Installatie_InstallatieTypeId");

            migrationBuilder.RenameColumn(
                name: "GebruikerTypeID",
                table: "Gebruiker",
                newName: "GebruikerTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Gebruiker_GebruikerTypeID",
                table: "Gebruiker",
                newName: "IX_Gebruiker_GebruikerTypeId");

            migrationBuilder.RenameColumn(
                name: "XjoBasisAppID",
                table: "Batterij",
                newName: "XjoBasisAppId");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Batterij",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruiker_GebruikerType_GebruikerTypeId",
                table: "Gebruiker",
                column: "GebruikerTypeId",
                principalTable: "GebruikerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Installatie_InstallatieType_InstallatieTypeId",
                table: "Installatie",
                column: "InstallatieTypeId",
                principalTable: "InstallatieType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Installatie_Leveradres_LeveradresId",
                table: "Installatie",
                column: "LeveradresId",
                principalTable: "Leveradres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opmerking_Batterij_BatterijId",
                table: "Opmerking",
                column: "BatterijId",
                principalTable: "Batterij",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opmerking_Gebruiker_GebruikerId",
                table: "Opmerking",
                column: "GebruikerId",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruiker_GebruikerType_GebruikerTypeId",
                table: "Gebruiker");

            migrationBuilder.DropForeignKey(
                name: "FK_Installatie_InstallatieType_InstallatieTypeId",
                table: "Installatie");

            migrationBuilder.DropForeignKey(
                name: "FK_Installatie_Leveradres_LeveradresId",
                table: "Installatie");

            migrationBuilder.DropForeignKey(
                name: "FK_Opmerking_Batterij_BatterijId",
                table: "Opmerking");

            migrationBuilder.DropForeignKey(
                name: "FK_Opmerking_Gebruiker_GebruikerId",
                table: "Opmerking");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Batterij");

            migrationBuilder.RenameColumn(
                name: "GebruikerId",
                table: "Opmerking",
                newName: "GebruikerID");

            migrationBuilder.RenameColumn(
                name: "BatterijId",
                table: "Opmerking",
                newName: "BatterijID");

            migrationBuilder.RenameIndex(
                name: "IX_Opmerking_GebruikerId",
                table: "Opmerking",
                newName: "IX_Opmerking_GebruikerID");

            migrationBuilder.RenameIndex(
                name: "IX_Opmerking_BatterijId",
                table: "Opmerking",
                newName: "IX_Opmerking_BatterijID");

            migrationBuilder.RenameColumn(
                name: "LeveradresId",
                table: "Installatie",
                newName: "LeveradresID");

            migrationBuilder.RenameColumn(
                name: "InstallatieTypeId",
                table: "Installatie",
                newName: "InstallatieTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Installatie_LeveradresId",
                table: "Installatie",
                newName: "IX_Installatie_LeveradresID");

            migrationBuilder.RenameIndex(
                name: "IX_Installatie_InstallatieTypeId",
                table: "Installatie",
                newName: "IX_Installatie_InstallatieTypeID");

            migrationBuilder.RenameColumn(
                name: "GebruikerTypeId",
                table: "Gebruiker",
                newName: "GebruikerTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Gebruiker_GebruikerTypeId",
                table: "Gebruiker",
                newName: "IX_Gebruiker_GebruikerTypeID");

            migrationBuilder.RenameColumn(
                name: "XjoBasisAppId",
                table: "Batterij",
                newName: "XjoBasisAppID");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruiker_GebruikerType_GebruikerTypeID",
                table: "Gebruiker",
                column: "GebruikerTypeID",
                principalTable: "GebruikerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Installatie_InstallatieType_InstallatieTypeID",
                table: "Installatie",
                column: "InstallatieTypeID",
                principalTable: "InstallatieType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Installatie_Leveradres_LeveradresID",
                table: "Installatie",
                column: "LeveradresID",
                principalTable: "Leveradres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opmerking_Batterij_BatterijID",
                table: "Opmerking",
                column: "BatterijID",
                principalTable: "Batterij",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opmerking_Gebruiker_GebruikerID",
                table: "Opmerking",
                column: "GebruikerID",
                principalTable: "Gebruiker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
