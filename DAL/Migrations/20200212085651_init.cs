using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelNr = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstallatieType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstalTypeCode = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallatieType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModDatum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XjoBasisAppModDatum = table.Column<DateTime>(nullable: false),
                    XjoBasisApp2ModDatum = table.Column<DateTime>(nullable: false),
                    InstallatieModDatum = table.Column<DateTime>(nullable: false),
                    OpmerkingModDatum = table.Column<DateTime>(nullable: false),
                    InstallatieTypeModDatum = table.Column<DateTime>(nullable: false),
                    LeveradresModDatum = table.Column<DateTime>(nullable: false),
                    KlantModDatum = table.Column<DateTime>(nullable: false),
                    GemeenteModDatum = table.Column<DateTime>(nullable: false),
                    LandModDatum = table.Column<DateTime>(nullable: false),
                    ArtikelModDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModDatum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Aktief = table.Column<bool>(nullable: false),
                    GebruikerTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gebruiker_GebruikerType_GebruikerTypeID",
                        column: x => x.GebruikerTypeID,
                        principalTable: "GebruikerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gemeente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false),
                    LandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemeente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gemeente_Land_LandId",
                        column: x => x.LandId,
                        principalTable: "Land",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relatie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Roepnaam = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false),
                    GemeenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatie_Gemeente_GemeenteId",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leveradres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevAdrId = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false),
                    RelatieId = table.Column<int>(nullable: false),
                    GemeenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leveradres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leveradres_Gemeente_GemeenteId",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leveradres_Relatie_RelatieId",
                        column: x => x.RelatieId,
                        principalTable: "Relatie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Installatie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallatieCode = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false),
                    LeveradresID = table.Column<int>(nullable: false),
                    InstallatieTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installatie_InstallatieType_InstallatieTypeID",
                        column: x => x.InstallatieTypeID,
                        principalTable: "InstallatieType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Installatie_Leveradres_LeveradresID",
                        column: x => x.LeveradresID,
                        principalTable: "Leveradres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Batterij",
                columns: table => new
                {
                    BatterijID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Locatie = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    ArtikelNr = table.Column<string>(nullable: true),
                    XjoBasisAppID = table.Column<int>(nullable: false),
                    XjoBasisApp2Id = table.Column<int>(nullable: false),
                    VervangenDoor = table.Column<int>(nullable: false),
                    Vervangen = table.Column<bool>(nullable: false),
                    ModDatum = table.Column<DateTime>(nullable: false),
                    InstallatieId = table.Column<int>(nullable: false),
                    GebruikerId = table.Column<int>(nullable: false),
                    ArtikelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batterij", x => x.BatterijID);
                    table.ForeignKey(
                        name: "FK_Batterij_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batterij_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batterij_Installatie_InstallatieId",
                        column: x => x.InstallatieId,
                        principalTable: "Installatie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opmerking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notitie = table.Column<string>(nullable: true),
                    ModDatum = table.Column<DateTime>(nullable: false),
                    InstallatieID = table.Column<int>(nullable: false),
                    GebruikerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opmerking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opmerking_Gebruiker_GebruikerID",
                        column: x => x.GebruikerID,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opmerking_Installatie_InstallatieID",
                        column: x => x.InstallatieID,
                        principalTable: "Installatie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batterij_ArtikelId",
                table: "Batterij",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_Batterij_GebruikerId",
                table: "Batterij",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Batterij_InstallatieId",
                table: "Batterij",
                column: "InstallatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_GebruikerTypeID",
                table: "Gebruiker",
                column: "GebruikerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Gemeente_LandId",
                table: "Gemeente",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Installatie_InstallatieTypeID",
                table: "Installatie",
                column: "InstallatieTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Installatie_LeveradresID",
                table: "Installatie",
                column: "LeveradresID");

            migrationBuilder.CreateIndex(
                name: "IX_Leveradres_GemeenteId",
                table: "Leveradres",
                column: "GemeenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Leveradres_RelatieId",
                table: "Leveradres",
                column: "RelatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Opmerking_GebruikerID",
                table: "Opmerking",
                column: "GebruikerID");

            migrationBuilder.CreateIndex(
                name: "IX_Opmerking_InstallatieID",
                table: "Opmerking",
                column: "InstallatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Relatie_GemeenteId",
                table: "Relatie",
                column: "GemeenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batterij");

            migrationBuilder.DropTable(
                name: "ModDatum");

            migrationBuilder.DropTable(
                name: "Opmerking");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropTable(
                name: "Installatie");

            migrationBuilder.DropTable(
                name: "GebruikerType");

            migrationBuilder.DropTable(
                name: "InstallatieType");

            migrationBuilder.DropTable(
                name: "Leveradres");

            migrationBuilder.DropTable(
                name: "Relatie");

            migrationBuilder.DropTable(
                name: "Gemeente");

            migrationBuilder.DropTable(
                name: "Land");
        }
    }
}
