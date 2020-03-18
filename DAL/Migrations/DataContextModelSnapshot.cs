﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Artikel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtikelNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("XjoArtikelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Artikel");
                });

            modelBuilder.Entity("Model.Batterij", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtikelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<string>("GeplaatstIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstallatieId")
                        .HasColumnType("int");

                    b.Property<string>("Locatie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Vervangen")
                        .HasColumnType("bit");

                    b.Property<int?>("VervangenDoor")
                        .HasColumnType("int");

                    b.Property<int?>("XjoBasisApp2Id")
                        .HasColumnType("int");

                    b.Property<int?>("XjoBasisAppId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtikelId");

                    b.HasIndex("GebruikerId");

                    b.HasIndex("InstallatieId");

                    b.ToTable("Batterij");
                });

            modelBuilder.Entity("Model.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktief")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GebruikerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XjoGebruikerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerTypeId");

                    b.ToTable("Gebruiker");
                });

            modelBuilder.Entity("Model.GebruikerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GebruikerType");
                });

            modelBuilder.Entity("Model.Gemeente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LandId");

                    b.ToTable("Gemeente");
                });

            modelBuilder.Entity("Model.Installatie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InstallatieTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("LeveradresId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("RelatieId")
                        .HasColumnType("int");

                    b.Property<string>("XjoInstallatieCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstallatieTypeId");

                    b.HasIndex("LeveradresId");

                    b.HasIndex("RelatieId");

                    b.ToTable("Installatie");
                });

            modelBuilder.Entity("Model.InstallatieType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstalTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InstallatieType");
                });

            modelBuilder.Entity("Model.Land", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Land");
                });

            modelBuilder.Entity("Model.Leveradres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GemeenteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelatieId")
                        .HasColumnType("int");

                    b.Property<int>("XjoLeveradresId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GemeenteId");

                    b.HasIndex("RelatieId");

                    b.ToTable("Leveradres");
                });

            modelBuilder.Entity("Model.ModDatum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArtikelModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GemeenteModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InstallatieModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InstallatieTypeModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KlantModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LandModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeveradresModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OpmerkingModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("XjoBasisApp2ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("XjoBasisAppModDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ModDatum");
                });

            modelBuilder.Entity("Model.Opmerking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatterijId")
                        .HasColumnType("int");

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notitie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatterijId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Opmerking");
                });

            modelBuilder.Entity("Model.Relatie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GemeenteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roepnaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XjoRelatieCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GemeenteId");

                    b.ToTable("Relatie");
                });

            modelBuilder.Entity("Model.Batterij", b =>
                {
                    b.HasOne("Model.Artikel", "Artikel")
                        .WithMany("Batterijen")
                        .HasForeignKey("ArtikelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Gebruiker", "Gebruiker")
                        .WithMany("Batterijen")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Installatie", "Installatie")
                        .WithMany("Batterijen")
                        .HasForeignKey("InstallatieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Gebruiker", b =>
                {
                    b.HasOne("Model.GebruikerType", "GebruikerType")
                        .WithMany("Gebruikers")
                        .HasForeignKey("GebruikerTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Gemeente", b =>
                {
                    b.HasOne("Model.Land", "Land")
                        .WithMany("Gemeentes")
                        .HasForeignKey("LandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Installatie", b =>
                {
                    b.HasOne("Model.InstallatieType", "InstallatieType")
                        .WithMany("Installaties")
                        .HasForeignKey("InstallatieTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Leveradres", "Leveradres")
                        .WithMany("Installaties")
                        .HasForeignKey("LeveradresId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Model.Relatie", "Relatie")
                        .WithMany("Installaties")
                        .HasForeignKey("RelatieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Leveradres", b =>
                {
                    b.HasOne("Model.Gemeente", "Gemeente")
                        .WithMany("Leveradressen")
                        .HasForeignKey("GemeenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Relatie", "Relatie")
                        .WithMany("Leveradressen")
                        .HasForeignKey("RelatieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Opmerking", b =>
                {
                    b.HasOne("Model.Batterij", "Batterij")
                        .WithMany("Opmerkingen")
                        .HasForeignKey("BatterijId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Gebruiker", "Gebruiker")
                        .WithMany("Opmerkingen")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Relatie", b =>
                {
                    b.HasOne("Model.Gemeente", "Gemeente")
                        .WithMany("Relaties")
                        .HasForeignKey("GemeenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
